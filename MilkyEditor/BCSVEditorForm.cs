using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MilkyEditor
{
    public partial class BCSVEditorForm : Form
    {
        public BCSVEditorForm()
        {
            InitializeComponent();
        }

        private void openBCSVhaxToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private RarcFilesystem archive = null;
        private Bcsv bcsv = null;

        private void button1_Click(object sender, EventArgs e)
        {
            RarcFilesystem arc;
            Bcsv file;

            Program.GameArchive = new ExternalFilesystem(Properties.Settings.Default.baseFolder);

            if (archive != null)
            {
                bcsv.Close();
                archive.Close();
            }

            try
            {
                arc = new RarcFilesystem(Program.GameArchive.OpenFile(textBox1.Text));
                file = new Bcsv(arc.OpenFile(textBox2.Text));
            }

            catch (Exception ex)
            {
                MessageBox.Show("An exception occured. Please report this." + ex.Message);
                arc = null;
                file = null;
            }

            archive = arc;
            bcsv = file;

            // no overlapping!
            bcsvView.Columns.Clear();
            bcsvView.Rows.Clear();


            foreach (Bcsv.Field field in bcsv.Fields.Values)
            {
                bcsvView.Columns.Add(field.NameHash.ToString("X8"), field.Name);
            }

            foreach (Bcsv.Entry entry in bcsv.Entries)
            {
                object[] row = new object[entry.Count];
                int i = 0;

                foreach (KeyValuePair<uint, object> _val in entry)
                {
                    object val = _val.Value;
                    row[i++] = val;
                }

                bcsvView.Rows.Add(row);
            }

            bcsv.Close();
        }

        private void productMapObjDataTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "/ObjectData/ProductMapObjDataTable.arc";
            textBox2.Text = "/ProductMapObjDataTable/ProductMapObjDataTable.bcsv";
        }

        private void planetMapDataTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "/ObjectData/PlanetMapDataTable.arc";
            textBox2.Text = "/PlanetMapDataTable/PlanetMapDataTable.bcsv";
        }
    }
}
