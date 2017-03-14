using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkyEditor
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            if (Properties.Settings.Default.baseFolder == "")
                setupFolders();

            setupTree();
        }

        public void setupTree()
        {
            galaxyList.Nodes.Clear();

            Program.GameArchive = new ExternalFilesystem(Properties.Settings.Default.baseFolder);

            if (Program.GameArchive.GetFiles("/StageData").Length == 0)
                Program.GameVersion = SMGVersion.SMG2;
            else
                Program.GameVersion = SMGVersion.SMG1;

            string[] leveldirs = Program.GameArchive.GetDirectories("/StageData");
            if (Program.GameVersion == SMGVersion.SMG1)
            {
                foreach (string level in leveldirs)
                {
                    TreeNode levelNode = new TreeNode(level);

                    galaxyList.Nodes.Add(levelNode);

                    string scenario_filename = string.Format("/StageData/{0}/{0}Scenario.arc", level);
                    RarcFilesystem scenario_arc = new RarcFilesystem(Program.GameArchive.OpenFile(scenario_filename));
                    Bcsv zonelist = new Bcsv(scenario_arc.OpenFile("/" + level + "Scenario/ZoneList.bcsv"));

                    // TODO: remove that
                    foreach (Bcsv.Entry entry in zonelist.Entries)
                    {
                        string zonename = (string)entry["ZoneName"];
                        levelNode.Nodes.Add(zonename).Tag = "Z|" + zonename;

                        Bcsv.AddHash(zonename);
                    }

                    galaxyList.Nodes.Add(level);

                    zonelist.Close();
                    scenario_arc.Close();
                }
            }
            else
            {
                foreach (string level in leveldirs)
                {
                    if (level.EndsWith("Zone") || level.Contains("E3") || level.Contains("Test"))
                        continue;

                    try
                    {
                        string scenario_filename = string.Format("/StageData/{0}/{0}Scenario.arc", level);
                        RarcFilesystem scenario_arc = new RarcFilesystem(Program.GameArchive.OpenFile(scenario_filename));
                        Bcsv zonelist = new Bcsv(scenario_arc.OpenFile("/" + level + "Scenario/ZoneList.bcsv"));

                        TreeNode levelNode = new TreeNode(level);

                        galaxyList.Nodes.Add(levelNode);

                        foreach (Bcsv.Entry entry in zonelist.Entries)
                        {
                            string zonename = (string)entry["ZoneName"];
                            levelNode.Nodes.Add(zonename).Tag = "Z|" + zonename;

                            Bcsv.AddHash(zonename);
                        }

                        zonelist.Close();
                        scenario_arc.Close();
                    }
                    catch
                    {
                    }
                }
            }
        }

        public void setupFolders()
        {
            FolderBrowserDialog fldrDialog = new FolderBrowserDialog();

            if (fldrDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.baseFolder = fldrDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }

            galaxyList.Nodes.Clear();
            setupTree();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            setupFolders();
        }

        private void galaxyList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // so the node up top doesn't open galaxies
            if (galaxyList.SelectedNode.Parent != null)
            {
                EditorWindow window = new EditorWindow();
                window.Show();

                window.loadGalaxy(galaxyList.SelectedNode.Text, "LayerA", false);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            BCSVEditorForm form = new BCSVEditorForm();
            form.Show();
        }
    }
}
