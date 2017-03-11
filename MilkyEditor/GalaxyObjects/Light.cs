using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;

namespace MilkyEditor.GalaxyObjects
{
    public class Light
    {
        public int lightID;
        public string lightName;

        [DisplayName("Light ID"), Category("General"), Description("This gives each light a unique ID.")]
        public int LightID
        {
            get { return lightID; }
            set { lightID = value; }
        }

        [DisplayName("Light Name"), Category("General"), Description("Name of the light.")]
        public string LightName
        {
            get { return lightName; }
            set { lightName = value; }
        }
    }
}
