using MilkyEditor.Filesystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.GalaxyObject
{
    class PathObject
    {
        public PathObject()
        {

        }

        public PathObject(Bcsv.Entry entry)
        {
            name = Convert.ToString(entry["name"]);
            Type = Convert.ToString(entry["type"]);
            Closed = Convert.ToString(entry["closed"]);
            NumPoints = Convert.ToInt32(entry["num_pnt"]);
            ID = Convert.ToInt32(entry["l_id"]);

            PathArg0 = Convert.ToInt32(entry["path_arg0"]);
            PathArg1 = Convert.ToInt32(entry["path_arg1"]);
            PathArg2 = Convert.ToInt32(entry["path_arg2"]);
            PathArg3 = Convert.ToInt32(entry["path_arg3"]);
            PathArg4 = Convert.ToInt32(entry["path_arg4"]);
            PathArg5 = Convert.ToInt32(entry["path_arg5"]);
            PathArg6 = Convert.ToInt32(entry["path_arg6"]);
            PathArg7 = Convert.ToInt32(entry["path_arg7"]);

            Useage = Convert.ToString(entry["usage"]);
            FileID = Convert.ToInt16(entry["no"]);
            PathID = Convert.ToInt16(entry["Path_ID"]);
        }

        public void AssignPathNodes(RarcFilesystem mapArc)
        {
            string pathFileString = String.Format("/Stage/jmp/Path/CommonPathPointInfo.{0}", FileID);

            Bcsv pathFile = new Bcsv(mapArc.OpenFile(pathFileString));

            points = new List<PathPointObject>();

            foreach (Bcsv.Entry entry in pathFile.Entries)
                points.Add(new PathPointObject(entry));
        }

        public override string ToString() { return String.Format("[{0}] {1}", FileID, name); }

        string name, Type, Closed;
        int NumPoints, ID;
        int PathArg0, PathArg1, PathArg2, PathArg3, PathArg4, PathArg5, PathArg6, PathArg7;
        string Useage;
        short FileID, PathID;
        public List<PathPointObject> points;
    }
}
