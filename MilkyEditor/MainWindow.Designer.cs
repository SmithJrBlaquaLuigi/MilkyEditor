namespace MilkyEditor
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.selectFolderButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openGalaxyButton = new System.Windows.Forms.ToolStripButton();
            this.bcsvEditorButton = new System.Windows.Forms.ToolStripButton();
            this.galaxyListTree = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFolderButton,
            this.toolStripSeparator1,
            this.openGalaxyButton,
            this.bcsvEditorButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(493, 23);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("selectFolderButton.Image")));
            this.selectFolderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(112, 19);
            this.selectFolderButton.Text = "Select Game Folder";
            this.selectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // openGalaxyButton
            // 
            this.openGalaxyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openGalaxyButton.Enabled = false;
            this.openGalaxyButton.Image = ((System.Drawing.Image)(resources.GetObject("openGalaxyButton.Image")));
            this.openGalaxyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openGalaxyButton.Name = "openGalaxyButton";
            this.openGalaxyButton.Size = new System.Drawing.Size(77, 22);
            this.openGalaxyButton.Text = "Open Galaxy";
            this.openGalaxyButton.Click += new System.EventHandler(this.openGalaxyButton_Click);
            // 
            // bcsvEditorButton
            // 
            this.bcsvEditorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bcsvEditorButton.Enabled = false;
            this.bcsvEditorButton.Image = ((System.Drawing.Image)(resources.GetObject("bcsvEditorButton.Image")));
            this.bcsvEditorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bcsvEditorButton.Name = "bcsvEditorButton";
            this.bcsvEditorButton.Size = new System.Drawing.Size(73, 22);
            this.bcsvEditorButton.Text = "BCSV Editor";
            // 
            // galaxyListTree
            // 
            this.galaxyListTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.galaxyListTree.Location = new System.Drawing.Point(0, 23);
            this.galaxyListTree.Name = "galaxyListTree";
            this.galaxyListTree.Size = new System.Drawing.Size(493, 264);
            this.galaxyListTree.TabIndex = 1;
            this.galaxyListTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.galaxyListTree_NodeMouseClick);
            this.galaxyListTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.galaxyListTree_NodeMouseDoubleClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 287);
            this.Controls.Add(this.galaxyListTree);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Milky Editor v0.1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton selectFolderButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bcsvEditorButton;
        private System.Windows.Forms.TreeView galaxyListTree;
        private System.Windows.Forms.ToolStripButton openGalaxyButton;
    }
}

