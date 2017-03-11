using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.GalaxyObjects
{
    public class ScenarioData
    {
        public string scenarioName, comet, appearStarObj, powerStarType;
        public int scenarioNo, powerStarID, luigiTimer, timer;

        [DisplayName("Scenario Name"), Category("General"), Description("The scenario name. Usually in Shift-JIS. This doesn't appear to affect any other part of the game, however.")]
        public string ScenarioName
        {
            get { return scenarioName; }
            set { scenarioName = value; }
        }

        [DisplayName("Scenario Number"), Category("General"), Description("Scenario number. This sets the other of the stars. Very important!")]
        public int ScenarioNum
        {
            get { return scenarioNo; }
            set { scenarioNo = value; }
        }

        [DisplayName("Power Star ID"), Category("General"), Description("Unknown.")]
        public int PowerStarID
        {
            get { return powerStarID; }
            set { powerStarID = value; }
        }

        [DisplayName("AppearPowerStarObj"), Category("General"), Description("Unknown.")]
        public string AppearStarObj
        {
            get { return appearStarObj; }
            set { appearStarObj = value; }
        }

        /*[DisplayName("Comet Timer"), Category("General"), Description("The timer on a mission. Leave at 0 for no timer.")]
        public int Timer
        {
            get { return timer; }
            set { timer = value; }
        }*/

        [DisplayName("LuigiCometTimer"), Category("General"), Description("Unknown.")]
        public int LuigiTimer
        {
            get { return luigiTimer; }
            set { luigiTimer = value; }
        }

        [DisplayName("Comet Type"), Category("General"), Description("Comet. Nothing is none, Red is for dimmed screen w/ black borders, purple is Purple Coins.")]
        public string CometName
        {
            get { return comet; }
            set { comet = value; }
        }

        [DisplayName("Power Star Type"), Category("General"), Description("The type of power star. 'Hidden' for hidden, 'Green' for Green, 'Normal' for normal.")]
        public string PowerStarType
        {
            get { return powerStarType; }
            set { powerStarType = value; }
        }
    }
}