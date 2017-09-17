namespace MilkyEditor
{
    partial class LevelEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditorForm));
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Map");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Light");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Sound");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Cameras");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Demo");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Debug");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("GeneralPos");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.introCameraEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addObjectDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.deleteObjectButton = new System.Windows.Forms.ToolStripButton();
            this.duplicateObjectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.levelLoadingProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.bottomStatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.leftTabPanel = new System.Windows.Forms.Panel();
            this.galaxyControl = new System.Windows.Forms.TabControl();
            this.scenarioPage = new System.Windows.Forms.TabPage();
            this.scenarioEditorPanel = new System.Windows.Forms.Panel();
            this.scenarioEditingToolbar = new System.Windows.Forms.ToolStrip();
            this.addScenarioButton = new System.Windows.Forms.ToolStripButton();
            this.deleteScenarioButton = new System.Windows.Forms.ToolStripButton();
            this.duplicateScenarioButton = new System.Windows.Forms.ToolStripButton();
            this.clearScenariosButton = new System.Windows.Forms.ToolStripButton();
            this.scenarioTreeView = new System.Windows.Forms.TreeView();
            this.lightPage = new System.Windows.Forms.TabPage();
            this.lightViewPanel = new System.Windows.Forms.Panel();
            this.lightDataTree = new System.Windows.Forms.TreeView();
            this.objectsPage = new System.Windows.Forms.TabPage();
            this.objectsTreeView = new System.Windows.Forms.TreeView();
            this.areasPage = new System.Windows.Forms.TabPage();
            this.areasTreeView = new System.Windows.Forms.TreeView();
            this.gravityPage = new System.Windows.Forms.TabPage();
            this.startingPointsPage = new System.Windows.Forms.TabPage();
            this.startingPointsTree = new System.Windows.Forms.TreeView();
            this.mappartsPage = new System.Windows.Forms.TabPage();
            this.cameraPage = new System.Windows.Forms.TabPage();
            this.camerasTree = new System.Windows.Forms.TreeView();
            this.pathsPage = new System.Windows.Forms.TabPage();
            this.pathsTree = new System.Windows.Forms.TreeView();
            this.miscPage = new System.Windows.Forms.TabPage();
            this.miscTree = new System.Windows.Forms.TreeView();
            this.glViewPanel = new System.Windows.Forms.Panel();
            this.layersComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.leftTabPanel.SuspendLayout();
            this.galaxyControl.SuspendLayout();
            this.scenarioPage.SuspendLayout();
            this.scenarioEditingToolbar.SuspendLayout();
            this.lightPage.SuspendLayout();
            this.objectsPage.SuspendLayout();
            this.areasPage.SuspendLayout();
            this.startingPointsPage.SuspendLayout();
            this.cameraPage.SuspendLayout();
            this.pathsPage.SuspendLayout();
            this.miscPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(823, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.introCameraEditorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // introCameraEditorToolStripMenuItem
            // 
            this.introCameraEditorToolStripMenuItem.Name = "introCameraEditorToolStripMenuItem";
            this.introCameraEditorToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.introCameraEditorToolStripMenuItem.Text = "Intro Camera Editor";
            this.introCameraEditorToolStripMenuItem.Click += new System.EventHandler(this.introCameraEditorToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addObjectDropDown,
            this.deleteObjectButton,
            this.duplicateObjectButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.layersComboBox});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(823, 23);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addObjectDropDown
            // 
            this.addObjectDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addObjectDropDown.Image = ((System.Drawing.Image)(resources.GetObject("addObjectDropDown.Image")));
            this.addObjectDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addObjectDropDown.Name = "addObjectDropDown";
            this.addObjectDropDown.Size = new System.Drawing.Size(89, 19);
            this.addObjectDropDown.Text = "Add Object...";
            // 
            // deleteObjectButton
            // 
            this.deleteObjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteObjectButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteObjectButton.Image")));
            this.deleteObjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteObjectButton.Name = "deleteObjectButton";
            this.deleteObjectButton.Size = new System.Drawing.Size(44, 19);
            this.deleteObjectButton.Text = "Delete";
            // 
            // duplicateObjectButton
            // 
            this.duplicateObjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.duplicateObjectButton.Image = ((System.Drawing.Image)(resources.GetObject("duplicateObjectButton.Image")));
            this.duplicateObjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.duplicateObjectButton.Name = "duplicateObjectButton";
            this.duplicateObjectButton.Size = new System.Drawing.Size(61, 19);
            this.duplicateObjectButton.Text = "Duplicate";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelLoadingProgress,
            this.bottomStatusStripLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(823, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // levelLoadingProgress
            // 
            this.levelLoadingProgress.Name = "levelLoadingProgress";
            this.levelLoadingProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // bottomStatusStripLabel
            // 
            this.bottomStatusStripLabel.Name = "bottomStatusStripLabel";
            this.bottomStatusStripLabel.Size = new System.Drawing.Size(42, 17);
            this.bottomStatusStripLabel.Text = "Ready.";
            // 
            // leftTabPanel
            // 
            this.leftTabPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leftTabPanel.AutoScroll = true;
            this.leftTabPanel.BackColor = System.Drawing.SystemColors.Control;
            this.leftTabPanel.Controls.Add(this.galaxyControl);
            this.leftTabPanel.Location = new System.Drawing.Point(0, 52);
            this.leftTabPanel.Name = "leftTabPanel";
            this.leftTabPanel.Size = new System.Drawing.Size(301, 310);
            this.leftTabPanel.TabIndex = 3;
            // 
            // galaxyControl
            // 
            this.galaxyControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.galaxyControl.Controls.Add(this.scenarioPage);
            this.galaxyControl.Controls.Add(this.lightPage);
            this.galaxyControl.Controls.Add(this.objectsPage);
            this.galaxyControl.Controls.Add(this.areasPage);
            this.galaxyControl.Controls.Add(this.gravityPage);
            this.galaxyControl.Controls.Add(this.startingPointsPage);
            this.galaxyControl.Controls.Add(this.mappartsPage);
            this.galaxyControl.Controls.Add(this.cameraPage);
            this.galaxyControl.Controls.Add(this.pathsPage);
            this.galaxyControl.Controls.Add(this.miscPage);
            this.galaxyControl.Location = new System.Drawing.Point(0, 0);
            this.galaxyControl.Name = "galaxyControl";
            this.galaxyControl.SelectedIndex = 0;
            this.galaxyControl.Size = new System.Drawing.Size(298, 310);
            this.galaxyControl.TabIndex = 0;
            // 
            // scenarioPage
            // 
            this.scenarioPage.Controls.Add(this.scenarioEditorPanel);
            this.scenarioPage.Controls.Add(this.scenarioEditingToolbar);
            this.scenarioPage.Controls.Add(this.scenarioTreeView);
            this.scenarioPage.Location = new System.Drawing.Point(4, 22);
            this.scenarioPage.Name = "scenarioPage";
            this.scenarioPage.Padding = new System.Windows.Forms.Padding(3);
            this.scenarioPage.Size = new System.Drawing.Size(290, 284);
            this.scenarioPage.TabIndex = 0;
            this.scenarioPage.Text = "Scenario";
            this.scenarioPage.UseVisualStyleBackColor = true;
            // 
            // scenarioEditorPanel
            // 
            this.scenarioEditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.scenarioEditorPanel.AutoScroll = true;
            this.scenarioEditorPanel.BackColor = System.Drawing.Color.Transparent;
            this.scenarioEditorPanel.Location = new System.Drawing.Point(0, 190);
            this.scenarioEditorPanel.Name = "scenarioEditorPanel";
            this.scenarioEditorPanel.Size = new System.Drawing.Size(287, 91);
            this.scenarioEditorPanel.TabIndex = 2;
            // 
            // scenarioEditingToolbar
            // 
            this.scenarioEditingToolbar.Enabled = false;
            this.scenarioEditingToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addScenarioButton,
            this.deleteScenarioButton,
            this.duplicateScenarioButton,
            this.clearScenariosButton});
            this.scenarioEditingToolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.scenarioEditingToolbar.Location = new System.Drawing.Point(3, 3);
            this.scenarioEditingToolbar.Name = "scenarioEditingToolbar";
            this.scenarioEditingToolbar.Size = new System.Drawing.Size(284, 22);
            this.scenarioEditingToolbar.TabIndex = 1;
            this.scenarioEditingToolbar.Text = "toolStrip2";
            // 
            // addScenarioButton
            // 
            this.addScenarioButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addScenarioButton.Image = ((System.Drawing.Image)(resources.GetObject("addScenarioButton.Image")));
            this.addScenarioButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addScenarioButton.Name = "addScenarioButton";
            this.addScenarioButton.Size = new System.Drawing.Size(33, 19);
            this.addScenarioButton.Text = "Add";
            // 
            // deleteScenarioButton
            // 
            this.deleteScenarioButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteScenarioButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteScenarioButton.Image")));
            this.deleteScenarioButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteScenarioButton.Name = "deleteScenarioButton";
            this.deleteScenarioButton.Size = new System.Drawing.Size(44, 19);
            this.deleteScenarioButton.Text = "Delete";
            // 
            // duplicateScenarioButton
            // 
            this.duplicateScenarioButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.duplicateScenarioButton.Image = ((System.Drawing.Image)(resources.GetObject("duplicateScenarioButton.Image")));
            this.duplicateScenarioButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.duplicateScenarioButton.Name = "duplicateScenarioButton";
            this.duplicateScenarioButton.Size = new System.Drawing.Size(61, 19);
            this.duplicateScenarioButton.Text = "Duplicate";
            // 
            // clearScenariosButton
            // 
            this.clearScenariosButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearScenariosButton.Image = ((System.Drawing.Image)(resources.GetObject("clearScenariosButton.Image")));
            this.clearScenariosButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearScenariosButton.Name = "clearScenariosButton";
            this.clearScenariosButton.Size = new System.Drawing.Size(38, 19);
            this.clearScenariosButton.Text = "Clear";
            // 
            // scenarioTreeView
            // 
            this.scenarioTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scenarioTreeView.Enabled = false;
            this.scenarioTreeView.Location = new System.Drawing.Point(0, 31);
            this.scenarioTreeView.Name = "scenarioTreeView";
            this.scenarioTreeView.Size = new System.Drawing.Size(287, 153);
            this.scenarioTreeView.TabIndex = 0;
            this.scenarioTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ScenarioTreeView_AfterSelect);
            // 
            // lightPage
            // 
            this.lightPage.Controls.Add(this.lightViewPanel);
            this.lightPage.Controls.Add(this.lightDataTree);
            this.lightPage.Location = new System.Drawing.Point(4, 22);
            this.lightPage.Name = "lightPage";
            this.lightPage.Padding = new System.Windows.Forms.Padding(3);
            this.lightPage.Size = new System.Drawing.Size(290, 284);
            this.lightPage.TabIndex = 1;
            this.lightPage.Text = "Light";
            this.lightPage.UseVisualStyleBackColor = true;
            // 
            // lightViewPanel
            // 
            this.lightViewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lightViewPanel.Location = new System.Drawing.Point(0, 130);
            this.lightViewPanel.Name = "lightViewPanel";
            this.lightViewPanel.Size = new System.Drawing.Size(290, 151);
            this.lightViewPanel.TabIndex = 1;
            // 
            // lightDataTree
            // 
            this.lightDataTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lightDataTree.Location = new System.Drawing.Point(0, 0);
            this.lightDataTree.Name = "lightDataTree";
            this.lightDataTree.Size = new System.Drawing.Size(290, 124);
            this.lightDataTree.TabIndex = 0;
            this.lightDataTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.LightDataTree_AfterSelect);
            // 
            // objectsPage
            // 
            this.objectsPage.Controls.Add(this.objectsTreeView);
            this.objectsPage.Location = new System.Drawing.Point(4, 22);
            this.objectsPage.Name = "objectsPage";
            this.objectsPage.Padding = new System.Windows.Forms.Padding(3);
            this.objectsPage.Size = new System.Drawing.Size(290, 284);
            this.objectsPage.TabIndex = 2;
            this.objectsPage.Text = "Objects";
            this.objectsPage.UseVisualStyleBackColor = true;
            // 
            // objectsTreeView
            // 
            this.objectsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectsTreeView.Location = new System.Drawing.Point(3, 3);
            this.objectsTreeView.Name = "objectsTreeView";
            this.objectsTreeView.Size = new System.Drawing.Size(284, 278);
            this.objectsTreeView.TabIndex = 0;
            // 
            // areasPage
            // 
            this.areasPage.Controls.Add(this.areasTreeView);
            this.areasPage.Location = new System.Drawing.Point(4, 22);
            this.areasPage.Name = "areasPage";
            this.areasPage.Padding = new System.Windows.Forms.Padding(3);
            this.areasPage.Size = new System.Drawing.Size(290, 284);
            this.areasPage.TabIndex = 3;
            this.areasPage.Text = "Areas";
            this.areasPage.UseVisualStyleBackColor = true;
            // 
            // areasTreeView
            // 
            this.areasTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.areasTreeView.Location = new System.Drawing.Point(3, 3);
            this.areasTreeView.Name = "areasTreeView";
            treeNode29.Name = "MapNode";
            treeNode29.Text = "Map";
            treeNode30.Name = "LightNode";
            treeNode30.Text = "Light";
            treeNode31.Name = "SoundNode";
            treeNode31.Text = "Sound";
            treeNode32.Name = "cameraNode";
            treeNode32.Text = "Cameras";
            this.areasTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32});
            this.areasTreeView.Size = new System.Drawing.Size(284, 278);
            this.areasTreeView.TabIndex = 0;
            // 
            // gravityPage
            // 
            this.gravityPage.Location = new System.Drawing.Point(4, 22);
            this.gravityPage.Name = "gravityPage";
            this.gravityPage.Padding = new System.Windows.Forms.Padding(3);
            this.gravityPage.Size = new System.Drawing.Size(290, 284);
            this.gravityPage.TabIndex = 9;
            this.gravityPage.Text = "Gravity";
            this.gravityPage.UseVisualStyleBackColor = true;
            // 
            // startingPointsPage
            // 
            this.startingPointsPage.Controls.Add(this.startingPointsTree);
            this.startingPointsPage.Location = new System.Drawing.Point(4, 22);
            this.startingPointsPage.Name = "startingPointsPage";
            this.startingPointsPage.Padding = new System.Windows.Forms.Padding(3);
            this.startingPointsPage.Size = new System.Drawing.Size(290, 284);
            this.startingPointsPage.TabIndex = 4;
            this.startingPointsPage.Text = "Start";
            this.startingPointsPage.UseVisualStyleBackColor = true;
            // 
            // startingPointsTree
            // 
            this.startingPointsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startingPointsTree.Location = new System.Drawing.Point(3, 3);
            this.startingPointsTree.Name = "startingPointsTree";
            this.startingPointsTree.Size = new System.Drawing.Size(284, 278);
            this.startingPointsTree.TabIndex = 0;
            // 
            // mappartsPage
            // 
            this.mappartsPage.Location = new System.Drawing.Point(4, 22);
            this.mappartsPage.Name = "mappartsPage";
            this.mappartsPage.Padding = new System.Windows.Forms.Padding(3);
            this.mappartsPage.Size = new System.Drawing.Size(290, 284);
            this.mappartsPage.TabIndex = 5;
            this.mappartsPage.Text = "Map Parts";
            this.mappartsPage.UseVisualStyleBackColor = true;
            // 
            // cameraPage
            // 
            this.cameraPage.Controls.Add(this.camerasTree);
            this.cameraPage.Location = new System.Drawing.Point(4, 22);
            this.cameraPage.Name = "cameraPage";
            this.cameraPage.Size = new System.Drawing.Size(290, 284);
            this.cameraPage.TabIndex = 7;
            this.cameraPage.Text = "Cameras";
            this.cameraPage.UseVisualStyleBackColor = true;
            // 
            // camerasTree
            // 
            this.camerasTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.camerasTree.Location = new System.Drawing.Point(0, 0);
            this.camerasTree.Name = "camerasTree";
            this.camerasTree.Size = new System.Drawing.Size(290, 284);
            this.camerasTree.TabIndex = 0;
            // 
            // pathsPage
            // 
            this.pathsPage.Controls.Add(this.pathsTree);
            this.pathsPage.Location = new System.Drawing.Point(4, 22);
            this.pathsPage.Name = "pathsPage";
            this.pathsPage.Padding = new System.Windows.Forms.Padding(3);
            this.pathsPage.Size = new System.Drawing.Size(290, 284);
            this.pathsPage.TabIndex = 8;
            this.pathsPage.Text = "Paths";
            this.pathsPage.UseVisualStyleBackColor = true;
            this.pathsPage.Click += new System.EventHandler(this.pathsPage_Click);
            // 
            // pathsTree
            // 
            this.pathsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathsTree.Location = new System.Drawing.Point(3, 3);
            this.pathsTree.Name = "pathsTree";
            this.pathsTree.Size = new System.Drawing.Size(284, 278);
            this.pathsTree.TabIndex = 0;
            // 
            // miscPage
            // 
            this.miscPage.Controls.Add(this.miscTree);
            this.miscPage.Location = new System.Drawing.Point(4, 22);
            this.miscPage.Name = "miscPage";
            this.miscPage.Padding = new System.Windows.Forms.Padding(3);
            this.miscPage.Size = new System.Drawing.Size(290, 284);
            this.miscPage.TabIndex = 6;
            this.miscPage.Text = "Misc";
            this.miscPage.UseVisualStyleBackColor = true;
            // 
            // miscTree
            // 
            this.miscTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscTree.Location = new System.Drawing.Point(3, 3);
            this.miscTree.Name = "miscTree";
            treeNode33.Name = "demoNode";
            treeNode33.Text = "Demo";
            treeNode34.Name = "debugNode";
            treeNode34.Text = "Debug";
            treeNode35.Name = "genPosNode";
            treeNode35.Text = "GeneralPos";
            this.miscTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode33,
            treeNode34,
            treeNode35});
            this.miscTree.Size = new System.Drawing.Size(284, 278);
            this.miscTree.TabIndex = 0;
            // 
            // glViewPanel
            // 
            this.glViewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glViewPanel.BackColor = System.Drawing.SystemColors.Control;
            this.glViewPanel.Location = new System.Drawing.Point(307, 52);
            this.glViewPanel.Name = "glViewPanel";
            this.glViewPanel.Size = new System.Drawing.Size(516, 310);
            this.glViewPanel.TabIndex = 4;
            // 
            // layersComboBox
            // 
            this.layersComboBox.Enabled = false;
            this.layersComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.layersComboBox.Name = "layersComboBox";
            this.layersComboBox.Size = new System.Drawing.Size(121, 23);
            this.layersComboBox.SelectedIndexChanged += new System.EventHandler(this.layersComboBox_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(81, 15);
            this.toolStripLabel1.Text = "Current Layer:";
            // 
            // LevelEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 386);
            this.Controls.Add(this.glViewPanel);
            this.Controls.Add(this.leftTabPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LevelEditorForm";
            this.Text = "oh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.leftTabPanel.ResumeLayout(false);
            this.galaxyControl.ResumeLayout(false);
            this.scenarioPage.ResumeLayout(false);
            this.scenarioPage.PerformLayout();
            this.scenarioEditingToolbar.ResumeLayout(false);
            this.scenarioEditingToolbar.PerformLayout();
            this.lightPage.ResumeLayout(false);
            this.objectsPage.ResumeLayout(false);
            this.areasPage.ResumeLayout(false);
            this.startingPointsPage.ResumeLayout(false);
            this.cameraPage.ResumeLayout(false);
            this.pathsPage.ResumeLayout(false);
            this.miscPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton addObjectDropDown;
        private System.Windows.Forms.ToolStripButton deleteObjectButton;
        private System.Windows.Forms.ToolStripButton duplicateObjectButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel leftTabPanel;
        private System.Windows.Forms.Panel glViewPanel;
        private System.Windows.Forms.TabControl galaxyControl;
        private System.Windows.Forms.TabPage scenarioPage;
        private System.Windows.Forms.TabPage lightPage;
        private System.Windows.Forms.TreeView scenarioTreeView;
        private System.Windows.Forms.ToolStrip scenarioEditingToolbar;
        private System.Windows.Forms.ToolStripButton addScenarioButton;
        private System.Windows.Forms.ToolStripButton deleteScenarioButton;
        private System.Windows.Forms.ToolStripButton duplicateScenarioButton;
        private System.Windows.Forms.ToolStripButton clearScenariosButton;
        private System.Windows.Forms.Panel scenarioEditorPanel;
        private System.Windows.Forms.Panel lightViewPanel;
        private System.Windows.Forms.TreeView lightDataTree;
        private System.Windows.Forms.TabPage objectsPage;
        private System.Windows.Forms.TreeView objectsTreeView;
        private System.Windows.Forms.TabPage areasPage;
        private System.Windows.Forms.TreeView areasTreeView;
        private System.Windows.Forms.TabPage startingPointsPage;
        private System.Windows.Forms.TreeView startingPointsTree;
        private System.Windows.Forms.TabPage mappartsPage;
        private System.Windows.Forms.TabPage cameraPage;
        private System.Windows.Forms.TabPage miscPage;
        private System.Windows.Forms.TabPage pathsPage;
        private System.Windows.Forms.TreeView pathsTree;
        private System.Windows.Forms.TabPage gravityPage;
        private System.Windows.Forms.TreeView miscTree;
        private System.Windows.Forms.TreeView camerasTree;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem introCameraEditorToolStripMenuItem;
        public System.Windows.Forms.ToolStripProgressBar levelLoadingProgress;
        public System.Windows.Forms.ToolStripStatusLabel bottomStatusStripLabel;
        private System.Windows.Forms.ToolStripComboBox layersComboBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}