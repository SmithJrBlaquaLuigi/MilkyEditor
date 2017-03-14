using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkyEditor
{

    public enum SMGVersion
    {
        SMG1 = 1,
        SMG2
    }


    static class Program
    {

        public static FilesystemBase GameArchive = null;

        public static SMGVersion GameVersion;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Bcsv.PopulateHashtable();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
