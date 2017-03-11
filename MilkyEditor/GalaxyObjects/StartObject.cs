using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.GalaxyObjects
{
    public class StartObject
    {
        public string name, layer;
        public int marioNo, arg0, cameraID;
        public float x, y, z, rotX, rotY, rotZ, scaleX, scaleY, scaleZ;

        [DisplayName("Object Name"), Category("General"), Description("The object's name.")]
        public string ObjectName
        {
            get { return name; }
            set { name = value; }
        }

        [DisplayName("Mario Number"), Category("General"), Description("An ID specified for this starting point.")]
        public int ID
        {
            get { return marioNo; }
            set { marioNo = value; }
        }

        [DisplayName("Layer"), Category("General"), Description("The object's layer it is on."), ReadOnly(true)]
        public string Layer
        {
            get { return layer; }
            set { layer = value; }
        }

        [DisplayName("Obj_arg0"), Category("Object Properties"), Description("Object properties.")]
        public int ObjArg0
        {
            get { return arg0; }
            set { arg0 = value; }
        }

        [DisplayName("Position X"), Category("Position"), Description("X position of the object.")]
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        [DisplayName("Position Y"), Category("Position"), Description("Y position of the object.")]
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        [DisplayName("Position Z"), Category("Position"), Description("Z position of the object.")]
        public float Z
        {
            get { return z; }
            set { z = value; }
        }

        [DisplayName("Rotation X"), Category("Position"), Description("X rotation of the object.")]
        public float RotX
        {
            get { return rotX; }
            set { rotX = value; }
        }

        [DisplayName("Rotation Y"), Category("Position"), Description("Y rotation of the object.")]
        public float RotY
        {
            get { return rotY; }
            set { rotY = value; }
        }

        [DisplayName("Rotation Z"), Category("Position"), Description("Z rotation of the object.")]
        public float RotZ
        {
            get { return rotZ; }
            set { rotZ = value; }
        }

        [DisplayName("Camera ID"), Category("Position"), Description("Some kind of id that specifies a camera.")]
        public int CameraID
        {
            get { return cameraID; }
            set { cameraID = value; }
        }

        [DisplayName("Scale X"), Category("Position"), Description("X scale.")]
        public float ScaleX
        {
            get { return scaleX; }
            set { scaleX = value; }
        }

        [DisplayName("Scale Y"), Category("Position"), Description("Y Scale.")]
        public float ScaleY
        {
            get { return scaleY; }
            set { scaleY = value; }
        }

        [DisplayName("Scale Z"), Category("Position"), Description("Z scale.")]
        public float ScaleZ
        {
            get { return scaleZ; }
            set { scaleZ = value; }
        }
    }
}
