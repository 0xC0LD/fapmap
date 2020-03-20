namespace fapmap
{
    partial class fapmap_fileExistsDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_fileExistsDialog));
            this.info = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_replace = new System.Windows.Forms.Button();
            this.btn_newName = new System.Windows.Forms.Button();
            this.showImage = new System.Windows.Forms.PictureBox();
            this.btn_selectFileInExplorer = new System.Windows.Forms.Button();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.btn_openFile = new System.Windows.Forms.Button();
            this.btn_openInInfo = new System.Windows.Forms.Button();
            this.btn_delFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.showImage)).BeginInit();
            this.SuspendLayout();
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.BackColor = System.Drawing.Color.Transparent;
            this.info.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(142, 12);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(133, 70);
            this.info.TabIndex = 0;
            this.info.Text = "FILE NAME\r\nEXTENSION\r\nDIRECTORY NAME\r\nSIZE\r\nCREATION DATE/TIME";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btn_cancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_cancel.Location = new System.Drawing.Point(314, 143);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(147, 40);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "CANCEL";
            this.HelpBalloon.SetToolTip(this.btn_cancel, "Abort");
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_replace
            // 
            this.btn_replace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_replace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_replace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_replace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_replace.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btn_replace.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_replace.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_replace.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_replace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_replace.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_replace.Location = new System.Drawing.Point(12, 143);
            this.btn_replace.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_replace.Name = "btn_replace";
            this.btn_replace.Size = new System.Drawing.Size(147, 40);
            this.btn_replace.TabIndex = 1;
            this.btn_replace.Text = "REPLACE";
            this.HelpBalloon.SetToolTip(this.btn_replace, "Replace the File");
            this.btn_replace.UseVisualStyleBackColor = false;
            this.btn_replace.Click += new System.EventHandler(this.btn_replace_Click);
            // 
            // btn_newName
            // 
            this.btn_newName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_newName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_newName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_newName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_newName.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btn_newName.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_newName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_newName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_newName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_newName.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_newName.Location = new System.Drawing.Point(163, 143);
            this.btn_newName.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_newName.Name = "btn_newName";
            this.btn_newName.Size = new System.Drawing.Size(147, 40);
            this.btn_newName.TabIndex = 2;
            this.btn_newName.Text = "NEW NAME";
            this.HelpBalloon.SetToolTip(this.btn_newName, "Use a New Name (e.g. imageFile [1].jpg)");
            this.btn_newName.UseVisualStyleBackColor = false;
            this.btn_newName.Click += new System.EventHandler(this.btn_newName_Click);
            // 
            // showImage
            // 
            this.showImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.showImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.showImage.Image = global::fapmap.Properties.Resources.image;
            this.showImage.Location = new System.Drawing.Point(12, 12);
            this.showImage.Name = "showImage";
            this.showImage.Size = new System.Drawing.Size(124, 124);
            this.showImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showImage.TabIndex = 156;
            this.showImage.TabStop = false;
            // 
            // btn_selectFileInExplorer
            // 
            this.btn_selectFileInExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_selectFileInExplorer.BackgroundImage = global::fapmap.Properties.Resources.selectFolder;
            this.btn_selectFileInExplorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_selectFileInExplorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selectFileInExplorer.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btn_selectFileInExplorer.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_selectFileInExplorer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_selectFileInExplorer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_selectFileInExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selectFileInExplorer.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_selectFileInExplorer.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_selectFileInExplorer.Location = new System.Drawing.Point(160, 116);
            this.btn_selectFileInExplorer.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_selectFileInExplorer.Name = "btn_selectFileInExplorer";
            this.btn_selectFileInExplorer.Size = new System.Drawing.Size(20, 20);
            this.btn_selectFileInExplorer.TabIndex = 5;
            this.HelpBalloon.SetToolTip(this.btn_selectFileInExplorer, "Open Explorer and Select the File");
            this.btn_selectFileInExplorer.UseVisualStyleBackColor = false;
            this.btn_selectFileInExplorer.Click += new System.EventHandler(this.btn_selectFileInExplorer_Click);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.SlateBlue;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // btn_openFile
            // 
            this.btn_openFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFile.BackgroundImage = global::fapmap.Properties.Resources.open;
            this.btn_openFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_openFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_openFile.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btn_openFile.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openFile.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_openFile.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_openFile.Location = new System.Drawing.Point(138, 116);
            this.btn_openFile.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(20, 20);
            this.btn_openFile.TabIndex = 4;
            this.HelpBalloon.SetToolTip(this.btn_openFile, "Open File");
            this.btn_openFile.UseVisualStyleBackColor = false;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // btn_openInInfo
            // 
            this.btn_openInInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openInInfo.BackgroundImage = global::fapmap.Properties.Resources.settings;
            this.btn_openInInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_openInInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_openInInfo.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btn_openInInfo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openInInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openInInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openInInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openInInfo.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_openInInfo.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_openInInfo.Location = new System.Drawing.Point(204, 116);
            this.btn_openInInfo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openInInfo.Name = "btn_openInInfo";
            this.btn_openInInfo.Size = new System.Drawing.Size(20, 20);
            this.btn_openInInfo.TabIndex = 7;
            this.HelpBalloon.SetToolTip(this.btn_openInInfo, "Open File Properties");
            this.btn_openInInfo.UseVisualStyleBackColor = false;
            this.btn_openInInfo.Click += new System.EventHandler(this.btn_openInInfo_Click);
            // 
            // btn_delFile
            // 
            this.btn_delFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_delFile.BackgroundImage = global::fapmap.Properties.Resources.delete;
            this.btn_delFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_delFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delFile.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btn_delFile.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_delFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_delFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_delFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_delFile.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_delFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_delFile.Location = new System.Drawing.Point(182, 116);
            this.btn_delFile.Name = "btn_delFile";
            this.btn_delFile.Size = new System.Drawing.Size(20, 20);
            this.btn_delFile.TabIndex = 6;
            this.HelpBalloon.SetToolTip(this.btn_delFile, "Trash File");
            this.btn_delFile.UseVisualStyleBackColor = false;
            this.btn_delFile.Click += new System.EventHandler(this.btn_delFile_Click);
            // 
            // fapmap_fileExistsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.ClientSize = new System.Drawing.Size(469, 196);
            this.Controls.Add(this.btn_delFile);
            this.Controls.Add(this.btn_openInInfo);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.btn_selectFileInExplorer);
            this.Controls.Add(this.showImage);
            this.Controls.Add(this.btn_newName);
            this.Controls.Add(this.btn_replace);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.info);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 235);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(485, 235);
            this.Name = "fapmap_fileExistsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FapMap - File Already Exists";
            this.Load += new System.EventHandler(this.fapmap_fileExistsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_replace;
        private System.Windows.Forms.Button btn_newName;
        private System.Windows.Forms.PictureBox showImage;
        private System.Windows.Forms.Button btn_selectFileInExplorer;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.Button btn_openFile;
        private System.Windows.Forms.Button btn_openInInfo;
        private System.Windows.Forms.Button btn_delFile;
    }
}