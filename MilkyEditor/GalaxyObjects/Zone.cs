using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MilkyEditor.GalaxyObjects
{
    public class Zone
    {
        public int id;
        public string name;
        public float x, y, z, rotX, rotY, rotZ;

        [DisplayName("ID"), Category("General"), Description("Optional identifier. Can just be 0.")]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Zone Name"), Category("General"), Description("The zone name.")]
        public string ZoneName
        {
            get { return name; }
            set { name = value; }
        }

        [DisplayName("X Position"), Category("Position"), Description("X Position of the zone. All objects within the zone will be offsetted as well!")]
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        [DisplayName("Y Position"), Category("Position"), Description("Y Position of the zone. All objects within the zone will be offsetted as well!")]
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        [DisplayName("Z Position"), Category("Position"), Description("Z Position of the zone. All objects within the zone will be offsetted as well!")]
        public float Z
        {
            get { return z; }
            set { z = value; }
        }

        [DisplayName("X Rotation"), Category("Rotation"), Description("X rotation of the zone. All objects within the zone will be offsetted as well!")]
        public float XRot
        {
            get { return rotX; }
            set { rotX = value; }
        }

        [DisplayName("Y Rotation"), Category("Rotation"), Description("Y rotation of the zone. All objects within the zone will be offsetted as well!")]
        public float YRot
        {
            get { return rotY; }
            set { rotY = value; }
        }

        [DisplayName("Z Rotation"), Category("Rotation"), Description("Z rotation of the zone. All objects within the zone will be offsetted as well!")]
        public float ZRot
        {
            get { return rotZ; }
            set { rotZ = value; }
        }
    }
}
