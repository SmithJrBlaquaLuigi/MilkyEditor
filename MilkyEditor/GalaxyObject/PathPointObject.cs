using MilkyEditor.Filesystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.GalaxyObject
{
    class PathPointObject
    {
        public PathPointObject()
        {

        }

        public PathPointObject(Bcsv.Entry entry)
        {
            PointArg0 = Convert.ToInt32(entry["point_arg0"]);
            PointArg1 = Convert.ToInt32(entry["point_arg1"]);
            PointArg2 = Convert.ToInt32(entry["point_arg2"]);
            PointArg3 = Convert.ToInt32(entry["point_arg3"]);
            PointArg4 = Convert.ToInt32(entry["point_arg4"]);
            PointArg5 = Convert.ToInt32(entry["point_arg5"]);
            PointArg6 = Convert.ToInt32(entry["point_arg6"]);
            PointArg7 = Convert.ToInt32(entry["point_arg7"]);

            Point0X = Convert.ToSingle(entry["pnt0_x"]);
            Point0Y = Convert.ToSingle(entry["pnt0_y"]);
            Point0Z = Convert.ToSingle(entry["pnt0_z"]);

            Point1X = Convert.ToSingle(entry["pnt1_x"]);
            Point1Y = Convert.ToSingle(entry["pnt1_y"]);
            Point1Z = Convert.ToSingle(entry["pnt1_z"]);

            Point2X = Convert.ToSingle(entry["pnt2_x"]);
            Point2Y = Convert.ToSingle(entry["pnt2_y"]);
            Point2Z = Convert.ToSingle(entry["pnt2_z"]);
        }

        int PointArg0, PointArg1, PointArg2, PointArg3, PointArg4, PointArg5, PointArg6, PointArg7;
        float Point0X, Point0Y, Point0Z;
        float Point1X, Point1Y, Point1Z;
        float Point2X, Point2Y, Point2Z;
    }
}
