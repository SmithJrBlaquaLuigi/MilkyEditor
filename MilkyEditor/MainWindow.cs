using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MilkyEditor.Filesystem;

namespace MilkyEditor
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            Bcsv.PopulateHashtable();

            nameToSimpleName = new Dictionary<string, string>();

            using (StreamReader sr = File.OpenText(Properties.Resources.SimpleGalaxyNames))
            {
                string[] splitLine = sr.ReadLine().Split('=');
                nameToSimpleName.Add(splitLine[0], splitLine[1]);
            }
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selectFolderDialog = new FolderBrowserDialog
            {
                Description = "Select the game folder containing your SMG files"
            };
            // storing the missing folders in a string
            string missingFolders = "";

            if (Properties.Settings.Default.PreviousFolder != "")
                selectFolderDialog.SelectedPath = Properties.Settings.Default.PreviousFolder;

            if (selectFolderDialog.ShowDialog() == DialogResult.OK)
            {
                // sanity checks
                if (!Directory.Exists(selectFolderDialog.SelectedPath + "/StageData"))
                    missingFolders += "/StageData\n";
                if (!Directory.Exists(selectFolderDialog.SelectedPath + "/ObjectData"))
                    missingFolders += "/ObjectData\n";

                // folders are missing, throw "error" and stop the process
                if (missingFolders != "")
                {
                    MessageBox.Show("The path you selected is missing the following folders: \n" + missingFolders);
                    return;
                }

                chosenFolderPath = selectFolderDialog.SelectedPath;
                Properties.Settings.Default.PreviousFolder = chosenFolderPath;
                Properties.Settings.Default.Save();

                FillTreeNodes();
            }
        }

        private void FillTreeNodes()
        {
            /*
             * Filling the tree nodes requires a few steps
             * Find the folders with ___Galaxy at the end
             * Open up the map file, and read the stage information
             * Get zones used, and then add them as child nodes
             */
            gameFilesystem = new ExternalFilesystem(chosenFolderPath);

            // now we get the directories
            string[] galaxyNames = gameFilesystem.GetDirectories("/StageData");

            foreach(string galaxyName in galaxyNames)
            {
                // now we need to check if it's a used galaxy (just check for a scenario file)
                string scenarioName = String.Format("/StageData/{0}/{1}Scenario.arc", galaxyName, galaxyName);

                // means it's a galaxy, let's open the map file
                if (gameFilesystem.FileExists(scenarioName))
                {
                    string nodeName = galaxyName;

                    if (nameToSimpleName.ContainsKey(galaxyName))
                        nodeName = nameToSimpleName[galaxyName];

                    // add the root node
                    TreeNode galaxyNode = new TreeNode(nodeName)
                    {
                        Tag = galaxyName
                    };
                    galaxyListTree.Nodes.Add(galaxyNode);

                    // now we open the scenario file
                    RarcFilesystem scenarioFile = new RarcFilesystem(gameFilesystem.OpenFile(scenarioName));

                    // build the path
                    string zoneListPath = String.Format("/{0}Scenario/ZoneList.bcsv", galaxyName);

                    // get ZoneList.bcsv from the galaxy
                    Bcsv zoneListInfoFile = new Bcsv(scenarioFile.OpenFile(zoneListPath));

                    // go through each entry in the bcsv, when each one represents the zones
                    foreach(Bcsv.Entry entry in zoneListInfoFile.Entries)
                    {
                        string zoneNodeName = Convert.ToString(entry["ZoneName"]);

                        if (nameToSimpleName.ContainsKey(zoneNodeName))
                            zoneNodeName = nameToSimpleName[zoneNodeName];

                        TreeNode stageNode = new TreeNode(zoneNodeName)
                        {
                            Tag = (string)entry["ZoneName"]
                        };

                        galaxyNode.Nodes.Add(stageNode);
                    }

                    // finshed with the file, close it
                    // also close the scenario file (will cause issues if not closed)
                    scenarioFile.Close();
                    zoneListInfoFile.Close();
                }
            }

            gameFilesystem.Close();
        }

        private void galaxyListTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (galaxyListTree.SelectedNode.Parent != null)
            {
                bool isZone = false;
                if (galaxyListTree.SelectedNode.Index == 0)
                    isZone = false;
                else
                    isZone = true;

                List<string> layers = new List<string>
                {
                    "Common"
                };

                LevelEditorForm editorForm = new LevelEditorForm(gameFilesystem, (string)galaxyListTree.SelectedNode.Tag, layers, isZone);
                editorForm.Show();
            }
        }

        private void openGalaxyButton_Click(object sender, EventArgs e)
        {
            if (galaxyListTree.SelectedNode.Parent != null)
            {
                bool isZone = false;
                if (galaxyListTree.SelectedNode.Index == 0)
                    isZone = false;
                else
                    isZone = true;

                List<string> layers = new List<string>
                {
                    "Common"
                };
                
                LevelEditorForm editorForm = new LevelEditorForm(gameFilesystem, (string)galaxyListTree.SelectedNode.Tag, layers, isZone);
                editorForm.Show();
            }
        }

        private void galaxyListTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            openGalaxyButton.Enabled = true;
        }

        ExternalFilesystem gameFilesystem;
        string chosenFolderPath;

        Dictionary<string, string> nameToSimpleName;

        private void hashGenButton_Click(object sender, EventArgs e)
        {
            HashGenerator hashGen = new HashGenerator();
            hashGen.Show();
        }
    }
}
