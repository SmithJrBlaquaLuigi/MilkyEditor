using MilkyEditor.Filesystem;
using MilkyEditor.GalaxyObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor
{
    class Galaxy
    { 
        public Galaxy(string galaxyName, List<string> layers, ExternalFilesystem gameFilesystem)
        {
            foreach (string layer in layers)
                Console.WriteLine("Gotta load " + layer);

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

            zones = new List<Zone>();

            foreach (string layer in layers)
            {
                string stageInfoFile = String.Format("/Stage/jmp/Placement/{0}/StageObjInfo", layer);

                RarcFilesystem mapArchive = new RarcFilesystem(gameFilesystem.OpenFile(mapFile));
                Bcsv stageObjBcsv = new Bcsv(mapArchive.OpenFile(stageInfoFile));

                foreach (Bcsv.Entry entry in stageObjBcsv.Entries)
                    zones.Add(new Zone(Convert.ToString(entry["name"]), layer, gameFilesystem));

                mapArchive.Close();
                stageObjBcsv.Close();
            }


            gameFilesystem.Close();
        }

        public void Clear()
        {

        }

        public List<Scenario> scenarios;
        public List<Light> lights;
        public List<Zone> zones;
    }
}
