using MilkyEditor.Filesystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor
{
    class UseResource
    {
        public UseResource()
        {
            fields = null;
        }

        // we load the entire BCSV because of a list we are creating
        public UseResource(Bcsv resource)
        {
            fields = new List<string>();

            foreach (Bcsv.Entry entry in resource.Entries)
                fields.Add(Convert.ToString(entry["ResourceName"]));
        }

        public void AddResource(string path) { fields.Add(path); }

        List<string> fields;
    }
}
