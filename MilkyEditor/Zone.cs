using MilkyEditor.Filesystem;
using MilkyEditor.GalaxyObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor
{
    class Zone
    {
        // zones don't use scenario data
        public Zone(string name, string layer, ExternalFilesystem gameFilesystem)
        {
            /*
             * Light Data
             */
            string lightFile = String.Format("/StageData/{0}/{0}Light.arc", name);

            if (gameFilesystem.FileExists(lightFile))
            {
                string lightBcsvFile = String.Format("/Stage/csv/{0}Light.bcsv", name);
                RarcFilesystem lightArchive = new RarcFilesystem(gameFilesystem.OpenFile(lightFile));
                Bcsv lightBcsv = new Bcsv(lightArchive.OpenFile(lightBcsvFile));

                lights = new List<Light>();
                foreach (Bcsv.Entry entry in lightBcsv.Entries)
                    lights.Add(new Light(entry, name));

                lightArchive.Close();
                lightBcsv.Close();
            }

            string mapFile = String.Format("/StageData/{0}/{0}Map.arc", name);
            string designFile = String.Format("/StageData/{0}/{0}Design.arc", name);
            string soundFile = String.Format("/StageData/{0}/{0}Sound.arc", name);

            RarcFilesystem mapArchive = new RarcFilesystem(gameFilesystem.OpenFile(mapFile));

            // we need to check to see if it exists
            // if it doesn't, load Common
            if (!mapArchive.DirectoryExists("/Stage/jmp/Placement/" + layer))
                layer = "Common";

            string mapObjFile = String.Format("/Stage/jmp/Placement/{0}/ObjInfo", layer);
            string areaObjFile = String.Format("/Stage/jmp/Placement/{0}/AreaObjInfo", layer);
            string mapPartsFile = String.Format("/Stage/jmp/MapParts/{0}/MapPartsInfo", layer);
            string startingObjFile = String.Format("/Stage/jmp/Start/{0}/StartInfo", layer);
            string cameraAreaFile = String.Format("/Stage/jmp/Placement/{0}/CameraCubeInfo", layer);
            string stageInfoFile = String.Format("/Stage/jmp/Placement/{0}/StageObjInfo", layer);

            Bcsv mapObjBcsv = new Bcsv(mapArchive.OpenFile(mapObjFile));

            objects = new List<LevelObject>();

            foreach (Bcsv.Entry entry in mapObjBcsv.Entries)
                objects.Add(new LevelObject(entry, layer));

            mapObjBcsv.Close();

            Bcsv startObjBcsv = new Bcsv(mapArchive.OpenFile(startingObjFile));

            startingPoints = new List<StartObject>();

            foreach (Bcsv.Entry entry in startObjBcsv.Entries)
                startingPoints.Add(new StartObject(entry, layer, name));

            startObjBcsv.Close();

            /* Camera Areas */
            Bcsv cameraCubeBcsv = new Bcsv(mapArchive.OpenFile(cameraAreaFile));

            cameras = new List<CameraObject>();

            foreach (Bcsv.Entry entry in cameraCubeBcsv.Entries)
                cameras.Add(new CameraObject(entry, layer));

            cameraCubeBcsv.Close();

            /* Map Parts */
            mapParts = new List<MapPartsObject>();

            Bcsv mapPartsBcsv = new Bcsv(mapArchive.OpenFile(mapPartsFile));

            foreach (Bcsv.Entry entry in mapPartsBcsv.Entries)
                mapParts.Add(new MapPartsObject(entry, layer));

            mapPartsBcsv.Close();

            /* 
             * Area objects
             * This section requires the opening of 3 seperate files.
             * Map.arc, Design.arc, and Sound.arc
             * We'll open up the map bcsv first, since it's the easiest.
             */

            Bcsv mapAreaBcsv = new Bcsv(mapArchive.OpenFile(areaObjFile));

            areas = new List<AreaObject>();

            // type 0, map
            foreach (Bcsv.Entry entry in mapAreaBcsv.Entries)
                areas.Add(new AreaObject(entry, layer, 0));

            mapAreaBcsv.Close();
            mapArchive.Close();

            // type 1, design
            if (gameFilesystem.FileExists(designFile))
            {
                RarcFilesystem designArchive = new RarcFilesystem(gameFilesystem.OpenFile(designFile));

                // sometimes the ARC will exist, but the file with the layer does not.
                if (designArchive.FileExists(areaObjFile))
                {
                    Bcsv designBcsv = new Bcsv(designArchive.OpenFile(areaObjFile));

                    foreach (Bcsv.Entry entry in designBcsv.Entries)
                        areas.Add(new AreaObject(entry, layer, 1));

                    designBcsv.Close();
                }

                designArchive.Close();
            }

            // type 2, sound
            if (gameFilesystem.FileExists(soundFile))
            {
                RarcFilesystem soundArchive = new RarcFilesystem(gameFilesystem.OpenFile(soundFile));

                if (soundArchive.FileExists(areaObjFile))
                {
                    Bcsv soundBcsv = new Bcsv(soundArchive.OpenFile(areaObjFile));

                    foreach (Bcsv.Entry entry in soundBcsv.Entries)
                        areas.Add(new AreaObject(entry, layer, 2));

                    soundBcsv.Close();
                }

                if (soundArchive.FileExists(mapObjFile))
                {
                    Bcsv soundObjBcsv = new Bcsv(soundArchive.OpenFile(mapObjFile));

                    foreach (Bcsv.Entry entry in soundObjBcsv.Entries)
                        objects.Add(new LevelObject(entry, layer));

                    soundObjBcsv.Close();
                }

                soundArchive.Close();
            }

            mapArchive.Close();
            gameFilesystem.Close();
        }

        public List<Light> lights;
        public List<LevelObject> objects;
        public List<StartObject> startingPoints;
        public List<AreaObject> areas;
        public List<CameraObject> cameras;
        public List<MapPartsObject> mapParts;
    }
}
