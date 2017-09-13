namespace MilkyEditor
{
    partial class HashGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HashGenerator));
            this.inputStringLbl = new System.Windows.Forms.Label();
            this.stringInput = new System.Windows.Forms.TextBox();
            this.hashLbl = new System.Windows.Forms.Label();
            this.hashOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inputStringLbl
            // 
            this.inputStringLbl.AutoSize = true;
            this.inputStringLbl.Location = new System.Drawing.Point(3, 6);
            this.inputStringLbl.Name = "inputStringLbl";
            this.inputStringLbl.Size = new System.Drawing.Size(64, 13);
            this.inputStringLbl.TabIndex = 0;
            this.inputStringLbl.Text = "Input String:";
            // 
            // stringInput
            // 
            this.stringInput.Location = new System.Drawing.Point(73, 6);
            this.stringInput.Name = "stringInput";
            this.stringInput.Size = new System.Drawing.Size(199, 20);
            this.stringInput.TabIndex = 1;
            this.stringInput.TextChanged += new System.EventHandler(this.stringInput_TextChanged);
            // 
            // hashLbl
            // 
            this.hashLbl.AutoSize = true;
            this.hashLbl.Location = new System.Drawing.Point(3, 30);
            this.hashLbl.Name = "hashLbl";
            this.hashLbl.Size = new System.Drawing.Size(35, 13);
            this.hashLbl.TabIndex = 2;
            this.hashLbl.Text = "Hash:";
            // 
            // hashOutput
            // 
            this.hashOutput.Location = new System.Drawing.Point(73, 30);
            this.hashOutput.Name = "hashOutput";
            this.hashOutput.ReadOnly = true;
            this.hashOutput.Size = new System.Drawing.Size(112, 20);
            this.hashOutput.TabIndex = 3;
            // 
            // HashGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 62);
            this.Controls.Add(this.hashOutput);
            this.Controls.Add(this.hashLbl);
            this.Controls.Add(this.stringInput);
            this.Controls.Add(this.inputStringLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HashGenerator";
            this.Text = "Hash Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inputStringLbl;
        private System.Windows.Forms.TextBox stringInput;
        private System.Windows.Forms.Label hashLbl;
        private System.Windows.Forms.TextBox hashOutput;
    }
}