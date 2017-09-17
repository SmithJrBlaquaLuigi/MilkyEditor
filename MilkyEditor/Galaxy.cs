using MilkyEditor.Filesystem;
using MilkyEditor.GalaxyObject;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor
{
    class Galaxy
    { 
        /*
         * This class is in charge of loading multiple things
         * It loads all of the layers needed for the galaxy
         * It also appends the zones used in the galaxy to the instnace of this class
         */
        public Galaxy(string galaxyName, List<string> layers, ExternalFilesystem gameFilesystem)
        {
            filesystem = gameFilesystem;
            /*
             * Scenario data
             */
            string scenarioFile = String.Format("/StageData/{0}/{0}Scenario.arc", galaxyName);
            string scenarioInfoFile = String.Format("/{0}Scenario/ScenarioData.bcsv", galaxyName);

            // we open the archive and get the bcsv
            RarcFilesystem scenarioArchive = new RarcFilesystem(gameFilesystem.OpenFile(scenarioFile));
            Bcsv scenarioBcsv = new Bcsv(scenarioArchive.OpenFile(scenarioInfoFile));

            // init the list
            scenarios = new List<Scenario>();

            // go through each entry and add it to the list of scenarios. this will be needed later
            foreach (Bcsv.Entry entry in scenarioBcsv.Entries)
                scenarios.Add(new Scenario(entry));

            scenarioArchive.Close();
            scenarioBcsv.Close();

            // ===========================================================================================
            /*
             * Light data
             */
            string lightFile = String.Format("/StageData/{0}/{0}Light.arc", galaxyName);

            if (gameFilesystem.FileExists(lightFile))
            {
                string lightBcsvFile = String.Format("/Stage/csv/{0}Light.bcsv", galaxyName);
                RarcFilesystem lightArchive = new RarcFilesystem(gameFilesystem.OpenFile(lightFile));
                Bcsv lightBcsv = new Bcsv(lightArchive.OpenFile(lightBcsvFile));

                lights = new List<Light>();

                foreach (Bcsv.Entry entry in lightBcsv.Entries)
                    lights.Add(new Light(entry, galaxyName));

                lightArchive.Close();
                lightBcsv.Close();
            }

            // ===========================================================================================
            /*
             * Zone data
             * The zone data is the first thing loaded that requires a loop through each used layer
             */
            string mapFile = String.Format("/StageData/{0}/{0}Map.arc", galaxyName);
            string designFile = String.Format("/StageData/{0}/{0}Design.arc", galaxyName);
            string soundFile = String.Format("/StageData/{0}/{0}Sound.arc", galaxyName);

            zones = new List<Zone>();
            objects = new List<LevelObject>();
            cameras = new List<CameraObject>();
            startingPoints = new List<StartObject>();
            mapParts = new List<MapPartsObject>();
            demos = new List<DemoObject>();
            areas = new List<AreaObject>();

            int curID = 0;

            foreach (string layer in layers)
            {
                string mapObjFile = String.Format("/Stage/jmp/Placement/{0}/ObjInfo", layer);
                string areaObjFile = String.Format("/Stage/jmp/Placement/{0}/AreaObjInfo", layer);
                string mapPartsFile = String.Format("/Stage/jmp/MapParts/{0}/MapPartsInfo", layer);
                string demoObjFile = String.Format("/Stage/jmp/Placement/{0}/DemoObjInfo", layer);
                string startingObjFile = String.Format("/Stage/jmp/Start/{0}/StartInfo", layer);
                string cameraAreaFile = String.Format("/Stage/jmp/Placement/{0}/CameraCubeInfo", layer);
                string stageInfoFile = String.Format("/Stage/jmp/Placement/{0}/StageObjInfo", layer);

                RarcFilesystem mapArchive = new RarcFilesystem(gameFilesystem.OpenFile(mapFile));
                Bcsv stageObjBcsv = new Bcsv(mapArchive.OpenFile(stageInfoFile));

                foreach (Bcsv.Entry entry in stageObjBcsv.Entries)
                {
                    float x = Convert.ToSingle(entry["pos_x"]);
                    float y = Convert.ToSingle(entry["pos_y"]);
                    float z = Convert.ToSingle(entry["pos_z"]);

                    Vector3 PositionOffset = new Vector3(x, y, z);

                    float xRot = Convert.ToSingle(entry["dir_x"]);
                    float yRot = Convert.ToSingle(entry["dir_y"]);
                    float zRot = Convert.ToSingle(entry["dir_z"]);

                    Vector3 RotationOffset = new Vector3(xRot, yRot, zRot);

                    Zone zone = new Zone(Convert.ToString(entry["name"]), PositionOffset, RotationOffset, layer, gameFilesystem, curID);
                    curID = zone.ReturnUnique();
                    zones.Add(zone);
                }

                stageObjBcsv.Close();

                /* Map Objects */

                Bcsv mapObjBcsv = new Bcsv(mapArchive.OpenFile(mapObjFile));

                foreach (Bcsv.Entry entry in mapObjBcsv.Entries)
                {
                    LevelObject obj = new LevelObject(entry, layer, curID++);
                    obj.SetModelExistFlag(gameFilesystem);
                    objects.Add(obj);
                }

                mapObjBcsv.Close();

                /* Starting Point Objects
                 * Mind as well read these while we have the map file open
                 */

                Bcsv startObjBcsv = new Bcsv(mapArchive.OpenFile(startingObjFile));

                foreach (Bcsv.Entry entry in startObjBcsv.Entries)
                    startingPoints.Add(new StartObject(entry, layer, galaxyName, curID++));

                startObjBcsv.Close();

                /* Camera Areas */
                Bcsv cameraCubeBcsv = new Bcsv(mapArchive.OpenFile(cameraAreaFile));

                foreach (Bcsv.Entry entry in cameraCubeBcsv.Entries)
                    cameras.Add(new CameraObject(entry, layer, curID++));

                cameraCubeBcsv.Close();

                /* Map Parts */
                Bcsv mapPartsBcsv = new Bcsv(mapArchive.OpenFile(mapPartsFile));

                foreach(Bcsv.Entry entry in mapPartsBcsv.Entries)
                    mapParts.Add(new MapPartsObject(entry, layer, curID++));

                mapPartsBcsv.Close();

                /* Demo Objects */
                Bcsv demoInfoBcsv = new Bcsv(mapArchive.OpenFile(demoObjFile));

                foreach (Bcsv.Entry entry in demoInfoBcsv.Entries)
                    demos.Add(new DemoObject(entry, layer, curID++));

                demoInfoBcsv.Close();

                /* 
                 * Area objects
                 * This section requires the opening of 3 seperate files.
                 * Map.arc, Design.arc, and Sound.arc
                 * We'll open up the map bcsv first, since it's the easiest.
                 */

                Bcsv mapAreaBcsv = new Bcsv(mapArchive.OpenFile(areaObjFile));

                // type 0, map
                foreach (Bcsv.Entry entry in mapAreaBcsv.Entries)
                    areas.Add(new AreaObject(entry, layer, 0, curID++));

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
                            areas.Add(new AreaObject(entry, layer, 1, curID++));

                        designBcsv.Close();
                    }

                    designArchive.Close();
                }

                // type 2, sound
                // we also get some objects out of it too
                if (gameFilesystem.FileExists(soundFile))
                {
                    RarcFilesystem soundArchive = new RarcFilesystem(gameFilesystem.OpenFile(soundFile));

                    if (soundArchive.FileExists(areaObjFile))
                    {
                        Bcsv soundBcsv = new Bcsv(soundArchive.OpenFile(areaObjFile));

                        foreach (Bcsv.Entry entry in soundBcsv.Entries)
                            areas.Add(new AreaObject(entry, layer, 2, curID++));

                        soundBcsv.Close();
                    }
                    
                    if (soundArchive.FileExists(mapObjFile))
                    {
                        Bcsv soundObjBcsv = new Bcsv(soundArchive.OpenFile(mapObjFile));

                        foreach (Bcsv.Entry entry in soundObjBcsv.Entries)
                            objects.Add(new LevelObject(entry, layer, curID++));

                        soundObjBcsv.Close();
                    }

                    soundArchive.Close();
                }
            }

            /* Paths and Path Points */
            // yay we re-open the map file
            RarcFilesystem pathMapArchive = new RarcFilesystem(gameFilesystem.OpenFile(mapFile));

            Bcsv pathInfoBcsv = new Bcsv(pathMapArchive.OpenFile("/Stage/jmp/Path/CommonPathInfo"));

            paths = new List<PathObject>();

            foreach (Bcsv.Entry entry in pathInfoBcsv.Entries)
            {
                PathObject path = new PathObject(entry);
                path.AssignPathNodes(pathMapArchive);
                paths.Add(path);
            }

            pathInfoBcsv.Close();

            /* BCAM File for cameras */
            Bcsv bcamBcsv = new Bcsv(pathMapArchive.OpenFile("/Stage/camera/CameraParam.bcam"));

            lvlCameras = new List<CameraEntry>();

            foreach (Bcsv.Entry entry in bcamBcsv.Entries)
                lvlCameras.Add(new CameraEntry(entry));

            bcamBcsv.Close();

            pathMapArchive.Close();

            gameFilesystem.Close();

            finalID = curID;
        }

        public void Clear()
        {

        }

        public List<Scenario> scenarios;
        public List<Light> lights;
        public List<Zone> zones;
        public List<LevelObject> objects;
        public List<DemoObject> demos;
        public List<StartObject> startingPoints;
        public List<AreaObject> areas;
        public List<CameraObject> cameras;
        public List<MapPartsObject> mapParts;
        public List<PathObject> paths;
        public List<CameraEntry> lvlCameras;

        public ExternalFilesystem filesystem;

        public int finalID;
    }
}


