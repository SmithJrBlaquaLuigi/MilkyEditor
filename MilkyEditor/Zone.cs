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
        public Zone(string name, ExternalFilesystem gameFilesystem)
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

                lightData = new List<Light>();
                foreach (Bcsv.Entry entry in lightBcsv.Entries)
                    lightData.Add(new Light(entry, name));

                lightArchive.Close();
                lightBcsv.Close();
            }

            gameFilesystem.Close();
        }

        public List<Light> lightData;
    }
}
