namespace fapmaper
{
    partial class fapmaper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmaper));
            this.Install = new System.Windows.Forms.Button();
            this.pathToInstall = new System.Windows.Forms.TextBox();
            this.hideFolderCB = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusOutput = new System.Windows.Forms.TextBox();
            this.exitLabel = new System.Windows.Forms.Label();
            this.openFapmap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Install
            // 
            this.Install.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Install.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.Install.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Install.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.Install.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Install.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Install.ForeColor = System.Drawing.Color.SlateBlue;
            this.Install.Location = new System.Drawing.Point(505, 12);
            this.Install.Name = "Install";
            this.Install.Size = new System.Drawing.Size(106, 24);
            this.Install.TabIndex = 0;
            this.Install.Text = "Install / Update";
            this.Install.UseVisualStyleBackColor = true;
            this.Install.Click += new System.EventHandler(this.Install_Click);
            // 
            // pathToInstall
            // 
            this.pathToInstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathToInstall.BackColor = System.Drawing.Color.Black;
            this.pathToInstall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pathToInstall.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pathToInstall.ForeColor = System.Drawing.Color.SlateBlue;
            this.pathToInstall.Location = new System.Drawing.Point(12, 12);
            this.pathToInstall.Name = "pathToInstall";
            this.pathToInstall.Size = new System.Drawing.Size(487, 25);
            this.pathToInstall.TabIndex = 1;
            this.pathToInstall.Text = "C:\\{H321-2314-JH34-H43J}";
            // 
            // hideFolderCB
            // 
            this.hideFolderCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hideFolderCB.AutoSize = true;
            this.hideFolderCB.BackColor = System.Drawing.Color.Black;
            this.hideFolderCB.Checked = true;
            this.hideFolderCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideFolderCB.ForeColor = System.Drawing.Color.SlateBlue;
            this.hideFolderCB.Location = new System.Drawing.Point(515, 42);
            this.hideFolderCB.Name = "hideFolderCB";
            this.hideFolderCB.Size = new System.Drawing.Size(80, 17);
            this.hideFolderCB.TabIndex = 2;
            this.hideFolderCB.Text = "Hide Folder";
            this.hideFolderCB.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.SlateBlue;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Output:";
            // 
            // statusOutput
            // 
            this.statusOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusOutput.BackColor = System.Drawing.Color.Black;
            this.statusOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusOutput.ForeColor = System.Drawing.Color.SlateBlue;
            this.statusOutput.Location = new System.Drawing.Point(12, 85);
            this.statusOutput.Multiline = true;
            this.statusOutput.Name = "statusOutput";
            this.statusOutput.ReadOnly = true;
            this.statusOutput.Size = new System.Drawing.Size(599, 136);
            this.statusOutput.TabIndex = 19;
            this.statusOutput.Text = resources.GetString("statusOutput.Text");
            // 
            // exitLabel
            // 
            this.exitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitLabel.AutoSize = true;
            this.exitLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exitLabel.ForeColor = System.Drawing.Color.Red;
            this.exitLabel.Location = new System.Drawing.Point(12, 243);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(25, 13);
            this.exitLabel.TabIndex = 20;
            this.exitLabel.Text = "...";
            // 
            // openFapmap
            // 
            this.openFapmap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openFapmap.Enabled = false;
            this.openFapmap.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.openFapmap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.openFapmap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.openFapmap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFapmap.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.openFapmap.ForeColor = System.Drawing.Color.SlateBlue;
            this.openFapmap.Location = new System.Drawing.Point(515, 227);
            this.openFapmap.Name = "openFapmap";
            this.openFapmap.Size = new System.Drawing.Size(96, 26);
            this.openFapmap.TabIndex = 21;
            this.openFapmap.Text = "Open FapMap";
            this.openFapmap.UseVisualStyleBackColor = true;
            this.openFapmap.Click += new System.EventHandler(this.openFapmap_Click);
            // 
            // fapmaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(623, 265);
            this.Controls.Add(this.openFapmap);
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.statusOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hideFolderCB);
            this.Controls.Add(this.pathToInstall);
            this.Controls.Add(this.Install);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 260);
            this.Name = "fapmaper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap Installer / Updater";
            this.Load += new System.EventHandler(this.fapmaper_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Install;
        private System.Windows.Forms.TextBox pathToInstall;
        private System.Windows.Forms.CheckBox hideFolderCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox statusOutput;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Button openFapmap;
    }
}

