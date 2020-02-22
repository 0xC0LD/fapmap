namespace fapmap
{
    partial class fapmap_ffmpeg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_ffmpeg));
            this.txt_file = new System.Windows.Forms.TextBox();
            this.txt_fileNew = new System.Windows.Forms.TextBox();
            this.btn_convert = new System.Windows.Forms.Button();
            this.txt_options = new System.Windows.Forms.TextBox();
            this.label_status = new System.Windows.Forms.Label();
            this.btn_openFileNew = new System.Windows.Forms.Button();
            this.btn_openFile = new System.Windows.Forms.Button();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.btn_delFile = new System.Windows.Forms.Button();
            this.btn_delFileNew = new System.Windows.Forms.Button();
            this.dnd_file = new System.Windows.Forms.Panel();
            this.dnd_fileNew = new System.Windows.Forms.Panel();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.output = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_file
            // 
            this.txt_file.AllowDrop = true;
            this.txt_file.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_file.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_file.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_file.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_file.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_file.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.txt_file.Location = new System.Drawing.Point(38, 12);
            this.txt_file.Name = "txt_file";
            this.txt_file.Size = new System.Drawing.Size(658, 20);
            this.txt_file.TabIndex = 143;
            this.txt_file.TextChanged += new System.EventHandler(this.txt_file_TextChanged);
            this.txt_file.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_file_KeyDown);
            // 
            // txt_fileNew
            // 
            this.txt_fileNew.AllowDrop = true;
            this.txt_fileNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_fileNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_fileNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_fileNew.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_fileNew.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_fileNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.txt_fileNew.Location = new System.Drawing.Point(38, 37);
            this.txt_fileNew.Name = "txt_fileNew";
            this.txt_fileNew.Size = new System.Drawing.Size(683, 20);
            this.txt_fileNew.TabIndex = 144;
            this.txt_fileNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_fileNew_KeyDown);
            // 
            // btn_convert
            // 
            this.btn_convert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_convert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_convert.BackgroundImage = global::fapmap.Properties.Resources.ffmpeg;
            this.btn_convert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_convert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_convert.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_convert.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_convert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_convert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_convert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_convert.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_convert.ForeColor = System.Drawing.Color.DimGray;
            this.btn_convert.Location = new System.Drawing.Point(701, 12);
            this.btn_convert.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(20, 20);
            this.btn_convert.TabIndex = 154;
            this.HelpBalloon.SetToolTip(this.btn_convert, "Convert");
            this.btn_convert.UseVisualStyleBackColor = false;
            this.btn_convert.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_convert_MouseClick);
            // 
            // txt_options
            // 
            this.txt_options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_options.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_options.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_options.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_options.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.txt_options.Location = new System.Drawing.Point(321, 229);
            this.txt_options.Name = "txt_options";
            this.txt_options.Size = new System.Drawing.Size(451, 20);
            this.txt_options.TabIndex = 155;
            this.txt_options.Text = "-i";
            this.txt_options.KeyDown += new System.Windows.Forms.KeyEventHandler(this.options_KeyDown);
            // 
            // label_status
            // 
            this.label_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_status.AutoSize = true;
            this.label_status.BackColor = System.Drawing.Color.Transparent;
            this.label_status.ForeColor = System.Drawing.Color.SlateBlue;
            this.label_status.Location = new System.Drawing.Point(12, 239);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(25, 13);
            this.label_status.TabIndex = 156;
            this.label_status.Text = "...";
            // 
            // btn_openFileNew
            // 
            this.btn_openFileNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openFileNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_openFileNew.BackgroundImage = global::fapmap.Properties.Resources.open;
            this.btn_openFileNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_openFileNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_openFileNew.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_openFileNew.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_openFileNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_openFileNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_openFileNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openFileNew.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_openFileNew.ForeColor = System.Drawing.Color.DimGray;
            this.btn_openFileNew.Location = new System.Drawing.Point(726, 37);
            this.btn_openFileNew.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openFileNew.Name = "btn_openFileNew";
            this.btn_openFileNew.Size = new System.Drawing.Size(20, 20);
            this.btn_openFileNew.TabIndex = 157;
            this.HelpBalloon.SetToolTip(this.btn_openFileNew, "Open File");
            this.btn_openFileNew.UseVisualStyleBackColor = false;
            this.btn_openFileNew.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_openFileNew_MouseClick);
            // 
            // btn_openFile
            // 
            this.btn_openFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_openFile.BackgroundImage = global::fapmap.Properties.Resources.open;
            this.btn_openFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_openFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_openFile.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_openFile.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_openFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_openFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_openFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openFile.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_openFile.ForeColor = System.Drawing.Color.DimGray;
            this.btn_openFile.Location = new System.Drawing.Point(726, 12);
            this.btn_openFile.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(20, 20);
            this.btn_openFile.TabIndex = 158;
            this.HelpBalloon.SetToolTip(this.btn_openFile, "Open File");
            this.btn_openFile.UseVisualStyleBackColor = false;
            this.btn_openFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_openFile_MouseClick);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.MediumPurple;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // btn_delFile
            // 
            this.btn_delFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_delFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_delFile.BackgroundImage = global::fapmap.Properties.Resources.delete;
            this.btn_delFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_delFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delFile.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_delFile.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_delFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_delFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_delFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_delFile.ForeColor = System.Drawing.Color.DimGray;
            this.btn_delFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_delFile.Location = new System.Drawing.Point(751, 12);
            this.btn_delFile.Name = "btn_delFile";
            this.btn_delFile.Size = new System.Drawing.Size(20, 20);
            this.btn_delFile.TabIndex = 169;
            this.HelpBalloon.SetToolTip(this.btn_delFile, "Trash File (File Only)");
            this.btn_delFile.UseVisualStyleBackColor = false;
            this.btn_delFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_delFile_MouseClick);
            // 
            // btn_delFileNew
            // 
            this.btn_delFileNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_delFileNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_delFileNew.BackgroundImage = global::fapmap.Properties.Resources.delete;
            this.btn_delFileNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_delFileNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delFileNew.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_delFileNew.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_delFileNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_delFileNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_delFileNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delFileNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_delFileNew.ForeColor = System.Drawing.Color.DimGray;
            this.btn_delFileNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_delFileNew.Location = new System.Drawing.Point(751, 37);
            this.btn_delFileNew.Name = "btn_delFileNew";
            this.btn_delFileNew.Size = new System.Drawing.Size(20, 20);
            this.btn_delFileNew.TabIndex = 170;
            this.HelpBalloon.SetToolTip(this.btn_delFileNew, "Trash File (File Only)");
            this.btn_delFileNew.UseVisualStyleBackColor = false;
            this.btn_delFileNew.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_delFileNew_MouseClick);
            // 
            // dnd_file
            // 
            this.dnd_file.AllowDrop = true;
            this.dnd_file.BackgroundImage = global::fapmap.Properties.Resources.image;
            this.dnd_file.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dnd_file.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dnd_file.Location = new System.Drawing.Point(12, 12);
            this.dnd_file.Name = "dnd_file";
            this.dnd_file.Size = new System.Drawing.Size(20, 20);
            this.dnd_file.TabIndex = 159;
            this.dnd_file.DragOver += new System.Windows.Forms.DragEventHandler(this.dnd_file_DragOver);
            this.dnd_file.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dnd_file_MouseDown);
            // 
            // dnd_fileNew
            // 
            this.dnd_fileNew.AllowDrop = true;
            this.dnd_fileNew.BackgroundImage = global::fapmap.Properties.Resources.image;
            this.dnd_fileNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dnd_fileNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dnd_fileNew.Location = new System.Drawing.Point(12, 37);
            this.dnd_fileNew.Name = "dnd_fileNew";
            this.dnd_fileNew.Size = new System.Drawing.Size(20, 20);
            this.dnd_fileNew.TabIndex = 160;
            this.dnd_fileNew.DragOver += new System.Windows.Forms.DragEventHandler(this.dnd_fileNew_DragOver);
            this.dnd_fileNew.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dnd_fileNew_MouseDown);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.output.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.output.ForeColor = System.Drawing.Color.Teal;
            this.output.Location = new System.Drawing.Point(12, 64);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.output.Size = new System.Drawing.Size(760, 159);
            this.output.TabIndex = 171;
            this.output.TextChanged += new System.EventHandler(this.output_TextChanged);
            // 
            // fapmap_ffmpeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(784, 261);
            this.Controls.Add(this.output);
            this.Controls.Add(this.dnd_file);
            this.Controls.Add(this.txt_file);
            this.Controls.Add(this.btn_delFileNew);
            this.Controls.Add(this.btn_openFileNew);
            this.Controls.Add(this.txt_fileNew);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.btn_delFile);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.txt_options);
            this.Controls.Add(this.dnd_fileNew);
            this.Controls.Add(this.btn_convert);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "fapmap_ffmpeg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - Media Converter (ffmpeg.exe)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fapmap_ffmpeg_FormClosing);
            this.Load += new System.EventHandler(this.fapmap_ffmpeg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_file;
        private System.Windows.Forms.TextBox txt_fileNew;
        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.TextBox txt_options;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button btn_openFileNew;
        private System.Windows.Forms.Button btn_openFile;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.Panel dnd_file;
        private System.Windows.Forms.Panel dnd_fileNew;
        private System.Windows.Forms.Button btn_delFile;
        private System.Windows.Forms.Button btn_delFileNew;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TextBox output;
    }
}