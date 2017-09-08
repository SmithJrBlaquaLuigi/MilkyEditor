using MilkyEditor.Filesystem;
using MilkyEditor.GalaxyObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor
{
    class Galaxy
    {
        public Galaxy(string name, ExternalFilesystem gameFilesystem)
        {
            galaxyName = name;

            /*
             * Scenario structure
             */
            string scenarioFile = String.Format("/StageData/{0}/{0}Scenario.arc", galaxyName);
            string scenarioInfoFile = String.Format("/{0}Scenario/ScenarioData.bcsv", galaxyName);

            string mapFile = String.Format("/StageData/{0}/{0}Map.arc", galaxyName);
            string designFile = String.Format("/StageData/{0}/{0}Design.arc", galaxyName);
            string lightFile = String.Format("/StageData/{0}/{0}Light.arc", galaxyName);
            string soundFile = String.Format("/StageData/{0}/{0}Sound.arc", galaxyName);

            /*
             * Scenario Data
             */
            RarcFilesystem scenarioArchive = new RarcFilesystem(gameFilesystem.OpenFile(scenarioFile));
            Bcsv scenarioBcsv = new Bcsv(scenarioArchive.OpenFile(scenarioInfoFile));
            scenario = new Scenario(scenarioBcsv);

            scenarioArchive.Close();
            scenarioBcsv.Close();

            /*
             * Getting the zones for reading the current layer's data (common)
             */
            RarcFilesystem mapArchive = new RarcFilesystem(gameFilesystem.OpenFile(mapFile));
            Bcsv stageObjBcsv = new Bcsv(mapArchive.OpenFile("/Stage/jmp/Placement/Common/StageObjInfo"));

            zones = new List<Zone>();

            // now we add each zone into the galaxy of the current selected layer
            foreach (Bcsv.Entry entry in stageObjBcsv.Entries)
                zones.Add(new Zone(Convert.ToString(entry["name"]), gameFilesystem));

            mapArchive.Close();
            stageObjBcsv.Close();

            if (gameFilesystem.FileExists(lightFile))
            {
                string lightBcsvFile = String.Format("/Stage/csv/{0}Light.bcsv", galaxyName);
                RarcFilesystem lightArchive = new RarcFilesystem(gameFilesystem.OpenFile(lightFile));
                Bcsv lightBcsv = new Bcsv(lightArchive.OpenFile(lightBcsvFile));

                lightData = new List<Light>();

                foreach (Bcsv.Entry entry in lightBcsv.Entries)
                    lightData.Add(new Light(entry, galaxyName));

                lightArchive.Close();
                lightBcsv.Close();
            }

            gameFilesystem.Close();
        }

        string galaxyName;
        public Scenario scenario;
        public List<Zone> zones;
        public List<Light> lightData;
    }
}
