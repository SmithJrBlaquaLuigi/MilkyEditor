﻿namespace MilkyEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addObjectDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.deleteObjectButton = new System.Windows.Forms.ToolStripButton();
            this.duplicateObjectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.bottomStatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.leftTabPanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
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
            this.glViewPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.leftTabPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.scenarioPage.SuspendLayout();
            this.scenarioEditingToolbar.SuspendLayout();
            this.lightPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addObjectDropDown,
            this.deleteObjectButton,
            this.duplicateObjectButton,
            this.toolStripSeparator1});
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
            this.toolStripProgressBar1,
            this.bottomStatusStripLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(823, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
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
            this.leftTabPanel.Controls.Add(this.tabControl1);
            this.leftTabPanel.Location = new System.Drawing.Point(0, 52);
            this.leftTabPanel.Name = "leftTabPanel";
            this.leftTabPanel.Size = new System.Drawing.Size(301, 310);
            this.leftTabPanel.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.scenarioPage);
            this.tabControl1.Controls.Add(this.lightPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(301, 310);
            this.tabControl1.TabIndex = 0;
            // 
            // scenarioPage
            // 
            this.scenarioPage.Controls.Add(this.scenarioEditorPanel);
            this.scenarioPage.Controls.Add(this.scenarioEditingToolbar);
            this.scenarioPage.Controls.Add(this.scenarioTreeView);
            this.scenarioPage.Location = new System.Drawing.Point(4, 22);
            this.scenarioPage.Name = "scenarioPage";
            this.scenarioPage.Padding = new System.Windows.Forms.Padding(3);
            this.scenarioPage.Size = new System.Drawing.Size(293, 284);
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
            this.scenarioEditingToolbar.Size = new System.Drawing.Size(287, 22);
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
            this.lightPage.Size = new System.Drawing.Size(293, 284);
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
            this.tabControl1.ResumeLayout(false);
            this.scenarioPage.ResumeLayout(false);
            this.scenarioPage.PerformLayout();
            this.scenarioEditingToolbar.ResumeLayout(false);
            this.scenarioEditingToolbar.PerformLayout();
            this.lightPage.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel bottomStatusStripLabel;
        private System.Windows.Forms.Panel leftTabPanel;
        private System.Windows.Forms.Panel glViewPanel;
        private System.Windows.Forms.TabControl tabControl1;
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
    }
}