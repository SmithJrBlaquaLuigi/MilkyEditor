using MilkyEditor.Filesystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor
{
    class Scenario
    {
        public Scenario()
        {
            entries = null;
        }

        public Scenario(Bcsv bcsv)
        {
            entries = new List<ScenarioEntry>();

            foreach(Bcsv.Entry entry in bcsv.Entries)
            {
                ScenarioEntry scenario = new ScenarioEntry();
                scenario.ScenarioName = Convert.ToString(entry["ScenarioName"]);
                scenario.ScenarioNo = Convert.ToInt32(entry["ScenarioNo"]);
                scenario.PowerStarId = Convert.ToInt32(entry["PowerStarId"]);
                scenario.AppearPowerStarObj = Convert.ToString(entry["AppearPowerStarObj"]);
                scenario.Comet = Convert.ToString(entry["Comet"]);
                scenario.CometLimitTimer = Convert.ToInt32(entry["CometLimitTimer"]);
                scenario.LuigiModeTimer = Convert.ToInt32(entry["LuigiModeTimer"]);
                scenario.PowerStarType = Convert.ToString(entry["PowerStarType"]);

                entries.Add(scenario);
            }

            bcsv.Close();
        }

        public List<ScenarioEntry> entries;
    }

    struct ScenarioEntry
    {
        public string ScenarioName;
        public int ScenarioNo;
        public int PowerStarId;
        public string AppearPowerStarObj, Comet;
        public int CometLimitTimer;
        public int LuigiModeTimer;
        public string PowerStarType;
    }
}
