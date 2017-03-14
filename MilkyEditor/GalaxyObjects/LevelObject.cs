using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.GalaxyObjects
{
    public class LevelObject
    {
        public string name, layer, zone;
        public int obj_arg0, obj_arg1, obj_arg2, obj_arg3, obj_arg4, obj_arg5, obj_arg6, obj_arg7, id;
        public int cameraSetID, sw_appear, sw_dead, sw_a, sw_b, sw_awake, sw_param, sw_sleep, messageID, castID, viewGroupID;
        public float x, y, z, rotX, rotY, rotZ, scaleX, scaleY, scaleZ, paramScale;
        public short shapeModelNo, commonPathID, clipGroupID, groupID, demoGroupID, mapPartsID, objID, generatorID;

        [DisplayName("Object Name"), Category("General"), Description("The object's name.")]
        public string ObjectName
        {
            get { return name; }
            set { name = value; }
        }

        [DisplayName("Object ID"), Category("General"), Description("The object's ID.")]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Layer"), Category("General"), Description("The object's layer it is on."), ReadOnly(true)]
        public string Layer
        { 
            get { return layer; }
            set { layer = value; }
        }

        [DisplayName("Zone"), Category("General"), Description("The object's zone it is in."), ReadOnly(true)]
        public string Zone
        {
            get { return zone; }
            set { zone = value; }
        }

        [DisplayName("Obj_arg0"), Category("Object Properties"), Description("Object properties.")]
        public int ObjArg0
        {
            get { return obj_arg0; }
            set { obj_arg0 = value; }
        }

        [DisplayName("Obj_arg1"), Category("Object Properties"), Description("Object properties.")]
        public int ObjArg1
        {
            get { return obj_arg1; }
            set { obj_arg1 = value; }
        }

        [DisplayName("Obj_arg2"), Category("Object Properties"), Description("Object properties.")]
        public int ObjArg2
        {
            get { return obj_arg2; }
            set { obj_arg2 = value; }
        }

        [DisplayName("Obj_arg3"), Category("Object Properties"), Description("Object properties.")]
        public int ObjArg3
        {
            get { return obj_arg3; }
            set { obj_arg3 = value; }
        }

        [DisplayName("Obj_arg4"), Category("Object Properties"), Description("Object properties.")]
        public int ObjArg4
        {
            get { return obj_arg4; }
            set { obj_arg4 = value; }
        }

        [DisplayName("Obj_arg5"), Category("Object Properties"), Description("Object properties.")]
        public int ObjArg5
        {
            get { return obj_arg5; }
            set { obj_arg5 = value; }
        }

        [DisplayName("Obj_arg6"), Category("Object Properties"), Description("Object properties.")]
        public int ObjArg6
        {
            get { return obj_arg6; }
            set { obj_arg6 = value; }
        }

        [DisplayName("Obj_arg7"), Category("Object Properties"), Description("Object properties.")]
        public int ObjArg7
        {
            get { return obj_arg7; }
            set { obj_arg7 = value; }
        }

        [DisplayName("Spawn Switch"), Category("Events"), Description("This field is for making objects appear.")]
        public int SWAppear
        {
            get { return sw_appear; }
            set { sw_appear = value; }
        }

        [DisplayName("De-Spawn Switch"), Category("Events"), Description("This field is for making objects disappear.")]
        public int SWDead
        {
            get { return sw_dead; }
            set { sw_dead = value; }
        }

        [DisplayName("Activation Switch"), Category("Events"), Description("This field is for activating things, like switches.")]
        public int SWA
        {
            get { return sw_a; }
            set { sw_a = value; }
        }

        [DisplayName("De-Activation Switch"), Category("Events"), Description("This field is for de-activating things, like switches.")]
        public int SWB
        {
            get { return sw_b; }
            set { sw_b = value; }
        }

        [DisplayName("Awakening Switch"), Category("Events"), Description("This field is for activating a already existing object.")]
        public int SWAWAKE
        {
            get { return sw_awake; }
            set { sw_awake = value; }
        }

        [DisplayName("Awakening Switch"), Category("Events"), Description("Unknown.")]
        public int SWPARAM
        {
            get { return sw_param; }
            set { sw_param = value; }
        }

        [DisplayName("Sleep Switch"), Category("Events"), Description("SMG1 only.")]
        public int SWSLEEP
        {
            get { return sw_sleep; }
            set { sw_sleep = value; }
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

        [DisplayName("ParamScale"), Category("Position"), Description("Unknown. Usually set to 1.")]
        public float ParamScale
        {
            get { return paramScale; }
            set { paramScale = value; }
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

        [DisplayName("Message ID"), Category("Miscellaneous"), Description("The ID of the message that the object will load. The message is stored in /LocalizeData/lang/__.arc.")]
        public int MessageID
        {
            get { return messageID; }
            set { messageID = value; }
        }

        [DisplayName("Set Camera ID"), Category("Miscellaneous"), Description("Unknown.")]
        public int CameraSetID
        {
            get { return cameraSetID; }
            set { cameraSetID = value; }
        }

        [DisplayName("CastID"), Category("Miscellaneous"), Description("Unknown.")]
        public int CastID
        {
            get { return castID; }
            set { castID = value; }
        }

        [DisplayName("View Group ID"), Category("Miscellaneous"), Description("Ties to a ViewGroupCtrlArea.")]
        public int ViewGroupID
        {
            get { return viewGroupID; }
            set { viewGroupID = value; }
        }

        [DisplayName("Path ID"), Category("Miscellaneous"), Description("The path an object follows. -1 for no path.")]
        public short PathID
        {
            get { return commonPathID; }
            set { commonPathID = value; }
        }

        [DisplayName("Shape Model Number"), Category("Miscellaneous"), Description("Unknown.")]
        public short ShapeModelNo
        {
            get { return shapeModelNo; }
            set { shapeModelNo = value; }
        }

        [DisplayName("Clipping Group ID"), Category("Miscellaneous"), Description("Unknown.")]
        public short ClippingGroupID
        {
            get { return clipGroupID; }
            set { clipGroupID = value; }
        }

        [DisplayName("Group ID"), Category("Miscellaneous"), Description("Unknown.")]
        public short GroupID
        {
            get { return groupID; }
            set { groupID = value; }
        }

        [DisplayName("Demo Group ID"), Category("Miscellaneous"), Description("Cutscene related ID.")]
        public short DemoGroupID
        {
            get { return demoGroupID; }
            set { demoGroupID = value; }
        }

        [DisplayName("Map Parts ID"), Category("Miscellaneous"), Description("This ID can tie to a MapParts object.")]
        public short MapPartsID
        {
            get { return mapPartsID; }
            set { mapPartsID = value; }
        }

        [DisplayName("Object ID"), Category("Miscellaneous"), Description("Unknown.")]
        public short ObjectID
        {
            get { return objID; }
            set { objID = value; }
        }

        [DisplayName("Generator ID"), Category("Miscellaneous"), Description("Unknown.")]
        public short GeneratorID
        {
            get { return generatorID; }
            set { generatorID = value; }
        }

    }
}
