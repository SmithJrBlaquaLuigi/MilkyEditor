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
            ScenarioName = "Scenario";
            ScenarioNo = 0;
            PowerStarId = 0;
            AppearPowerStarObj = "";
            Comet = "";
            CometLimitTimer = 0;
            LuigiModeTimer = 0;
            PowerStarType = "Normal";
        }

        public Scenario(Bcsv.Entry entry)
        {
            ScenarioEntry = entry; // for further use

            ScenarioName = Convert.ToString(entry["ScenarioName"]);
            ScenarioNo = Convert.ToInt32(entry["ScenarioNo"]);
            PowerStarId = Convert.ToInt32(entry["PowerStarId"]);
            AppearPowerStarObj = Convert.ToString(entry["AppearPowerStarObj"]);
            Comet = Convert.ToString(entry["Comet"]);
            CometLimitTimer = Convert.ToInt32(entry["CometLimitTimer"]);
            LuigiModeTimer = Convert.ToInt32(entry["LuigiModeTimer"]);
            PowerStarType = Convert.ToString(entry["PowerStarType"]);
        }

        public override string ToString() { return String.Format("[{0}] {1}", ScenarioNo, ScenarioName); }

        public string ScenarioName;
        public int ScenarioNo;
        public int PowerStarId;
        public string AppearPowerStarObj, Comet;
        public int CometLimitTimer;
        public int LuigiModeTimer;
        public string PowerStarType;
        public Bcsv.Entry ScenarioEntry;
    }
}
