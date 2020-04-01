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
            this.btn_convert = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.btn_openFileNew = new System.Windows.Forms.Button();
            this.btn_openFile = new System.Windows.Forms.Button();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.btn_delFile = new System.Windows.Forms.Button();
            this.btn_delFileNew = new System.Windows.Forms.Button();
            this.btn_fileNewDragOut = new System.Windows.Forms.Button();
            this.btn_fileDragOut = new System.Windows.Forms.Button();
            this.txt_output_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txt_output_RMB_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_fileNew_border = new fapmap_res.FapMapPanel();
            this.txt_fileNew = new System.Windows.Forms.TextBox();
            this.txt_file_border = new fapmap_res.FapMapPanel();
            this.txt_file = new System.Windows.Forms.TextBox();
            this.txt_options_border = new fapmap_res.FapMapPanel();
            this.txt_options = new System.Windows.Forms.TextBox();
            this.txt_output_border = new fapmap_res.FapMapPanel();
            this.txt_output = new fapmap_res.FixedRichTextBox();
            this.txt_output_RMB.SuspendLayout();
            this.txt_fileNew_border.SuspendLayout();
            this.txt_file_border.SuspendLayout();
            this.txt_options_border.SuspendLayout();
            this.txt_output_border.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_convert
            // 
            this.btn_convert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_convert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_convert.BackgroundImage = global::fapmap.Properties.Resources.ffmpeg;
            this.btn_convert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_convert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_convert.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_convert.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_convert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_convert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_convert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_convert.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_convert.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_convert.Location = new System.Drawing.Point(701, 12);
            this.btn_convert.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(21, 21);
            this.btn_convert.TabIndex = 3;
            this.HelpBalloon.SetToolTip(this.btn_convert, "Convert");
            this.btn_convert.UseVisualStyleBackColor = false;
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
            // 
            // label_status
            // 
            this.label_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_status.AutoSize = true;
            this.label_status.BackColor = System.Drawing.Color.Transparent;
            this.label_status.ForeColor = System.Drawing.Color.MediumPurple;
            this.label_status.Location = new System.Drawing.Point(12, 239);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(25, 13);
            this.label_status.TabIndex = 0;
            this.label_status.Text = "...";
            // 
            // btn_openFileNew
            // 
            this.btn_openFileNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openFileNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFileNew.BackgroundImage = global::fapmap.Properties.Resources.open;
            this.btn_openFileNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_openFileNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_openFileNew.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_openFileNew.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFileNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFileNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFileNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openFileNew.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_openFileNew.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_openFileNew.Location = new System.Drawing.Point(726, 37);
            this.btn_openFileNew.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openFileNew.Name = "btn_openFileNew";
            this.btn_openFileNew.Size = new System.Drawing.Size(21, 21);
            this.btn_openFileNew.TabIndex = 5;
            this.HelpBalloon.SetToolTip(this.btn_openFileNew, "Open File");
            this.btn_openFileNew.UseVisualStyleBackColor = false;
            this.btn_openFileNew.Click += new System.EventHandler(this.btn_openFileNew_Click);
            // 
            // btn_openFile
            // 
            this.btn_openFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFile.BackgroundImage = global::fapmap.Properties.Resources.open;
            this.btn_openFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_openFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_openFile.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_openFile.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openFile.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_openFile.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_openFile.Location = new System.Drawing.Point(726, 12);
            this.btn_openFile.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(21, 21);
            this.btn_openFile.TabIndex = 4;
            this.HelpBalloon.SetToolTip(this.btn_openFile, "Open File");
            this.btn_openFile.UseVisualStyleBackColor = false;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // btn_delFile
            // 
            this.btn_delFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_delFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_delFile.BackgroundImage = global::fapmap.Properties.Resources.delete;
            this.btn_delFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_delFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delFile.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_delFile.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_delFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_delFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_delFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_delFile.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_delFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_delFile.Location = new System.Drawing.Point(751, 12);
            this.btn_delFile.Name = "btn_delFile";
            this.btn_delFile.Size = new System.Drawing.Size(21, 21);
            this.btn_delFile.TabIndex = 6;
            this.HelpBalloon.SetToolTip(this.btn_delFile, "Trash File (File Only)");
            this.btn_delFile.UseVisualStyleBackColor = false;
            this.btn_delFile.Click += new System.EventHandler(this.btn_delFile_Click);
            // 
            // btn_delFileNew
            // 
            this.btn_delFileNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_delFileNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_delFileNew.BackgroundImage = global::fapmap.Properties.Resources.delete;
            this.btn_delFileNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_delFileNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delFileNew.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_delFileNew.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_delFileNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_delFileNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_delFileNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delFileNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_delFileNew.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_delFileNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_delFileNew.Location = new System.Drawing.Point(751, 37);
            this.btn_delFileNew.Name = "btn_delFileNew";
            this.btn_delFileNew.Size = new System.Drawing.Size(21, 21);
            this.btn_delFileNew.TabIndex = 7;
            this.HelpBalloon.SetToolTip(this.btn_delFileNew, "Trash File (File Only)");
            this.btn_delFileNew.UseVisualStyleBackColor = false;
            this.btn_delFileNew.Click += new System.EventHandler(this.btn_delFileNew_Click);
            // 
            // btn_fileNewDragOut
            // 
            this.btn_fileNewDragOut.AllowDrop = true;
            this.btn_fileNewDragOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_fileNewDragOut.BackgroundImage = global::fapmap.Properties.Resources.dragNdrop;
            this.btn_fileNewDragOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_fileNewDragOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_fileNewDragOut.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_fileNewDragOut.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_fileNewDragOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_fileNewDragOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_fileNewDragOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fileNewDragOut.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold);
            this.btn_fileNewDragOut.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_fileNewDragOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_fileNewDragOut.Location = new System.Drawing.Point(12, 37);
            this.btn_fileNewDragOut.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_fileNewDragOut.Name = "btn_fileNewDragOut";
            this.btn_fileNewDragOut.Size = new System.Drawing.Size(21, 21);
            this.btn_fileNewDragOut.TabIndex = 11;
            this.HelpBalloon.SetToolTip(this.btn_fileNewDragOut, "Hold This Button to Drag Out the File Path");
            this.btn_fileNewDragOut.UseVisualStyleBackColor = false;
            this.btn_fileNewDragOut.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_fileNewDragOut_DragOver);
            this.btn_fileNewDragOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_fileNewDragOut_MouseDown);
            // 
            // btn_fileDragOut
            // 
            this.btn_fileDragOut.AllowDrop = true;
            this.btn_fileDragOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_fileDragOut.BackgroundImage = global::fapmap.Properties.Resources.dragNdrop;
            this.btn_fileDragOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_fileDragOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_fileDragOut.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_fileDragOut.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_fileDragOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_fileDragOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_fileDragOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fileDragOut.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold);
            this.btn_fileDragOut.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_fileDragOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_fileDragOut.Location = new System.Drawing.Point(12, 12);
            this.btn_fileDragOut.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_fileDragOut.Name = "btn_fileDragOut";
            this.btn_fileDragOut.Size = new System.Drawing.Size(21, 21);
            this.btn_fileDragOut.TabIndex = 10;
            this.HelpBalloon.SetToolTip(this.btn_fileDragOut, "Hold This Button to Drag Out the File Path");
            this.btn_fileDragOut.UseVisualStyleBackColor = false;
            this.btn_fileDragOut.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_fileDragOut_DragOver);
            this.btn_fileDragOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_fileDragOut_MouseDown);
            // 
            // txt_output_RMB
            // 
            this.txt_output_RMB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.txt_output_RMB.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.txt_output_RMB.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txt_output_RMB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txt_output_RMB_copy});
            this.txt_output_RMB.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.txt_output_RMB.Name = "contextMenuStrip1";
            this.txt_output_RMB.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.txt_output_RMB.ShowItemToolTips = false;
            this.txt_output_RMB.Size = new System.Drawing.Size(150, 26);
            // 
            // txt_output_RMB_copy
            // 
            this.txt_output_RMB_copy.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.txt_output_RMB_copy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.txt_output_RMB_copy.Image = global::fapmap.Properties.Resources.copy;
            this.txt_output_RMB_copy.Name = "txt_output_RMB_copy";
            this.txt_output_RMB_copy.Size = new System.Drawing.Size(149, 22);
            this.txt_output_RMB_copy.Text = "Copy (CTRL+C)";
            this.txt_output_RMB_copy.Click += new System.EventHandler(this.txt_output_RMB_copy_Click);
            // 
            // txt_fileNew_border
            // 
            this.txt_fileNew_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_fileNew_border.Controls.Add(this.txt_fileNew);
            this.txt_fileNew_border.Location = new System.Drawing.Point(37, 37);
            this.txt_fileNew_border.Name = "txt_fileNew_border";
            this.txt_fileNew_border.Size = new System.Drawing.Size(685, 21);
            this.txt_fileNew_border.TabIndex = 15;
            // 
            // txt_fileNew
            // 
            this.txt_fileNew.AllowDrop = true;
            this.txt_fileNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_fileNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_fileNew.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_fileNew.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_fileNew.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fileNew.ForeColor = System.Drawing.Color.Turquoise;
            this.txt_fileNew.Location = new System.Drawing.Point(1, 1);
            this.txt_fileNew.Name = "txt_fileNew";
            this.txt_fileNew.Size = new System.Drawing.Size(683, 19);
            this.txt_fileNew.TabIndex = 1;
            this.txt_fileNew.TextChanged += new System.EventHandler(this.txt_fileNew_TextChanged);
            this.txt_fileNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_fileNew_KeyDown);
            // 
            // txt_file_border
            // 
            this.txt_file_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_file_border.Controls.Add(this.txt_file);
            this.txt_file_border.Location = new System.Drawing.Point(37, 12);
            this.txt_file_border.Name = "txt_file_border";
            this.txt_file_border.Size = new System.Drawing.Size(659, 21);
            this.txt_file_border.TabIndex = 14;
            // 
            // txt_file
            // 
            this.txt_file.AllowDrop = true;
            this.txt_file.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_file.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_file.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_file.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_file.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_file.ForeColor = System.Drawing.Color.Turquoise;
            this.txt_file.Location = new System.Drawing.Point(1, 1);
            this.txt_file.Name = "txt_file";
            this.txt_file.Size = new System.Drawing.Size(657, 19);
            this.txt_file.TabIndex = 1;
            this.txt_file.TextChanged += new System.EventHandler(this.txt_file_TextChanged);
            this.txt_file.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_file_KeyDown);
            // 
            // txt_options_border
            // 
            this.txt_options_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_options_border.Controls.Add(this.txt_options);
            this.txt_options_border.Location = new System.Drawing.Point(349, 234);
            this.txt_options_border.Name = "txt_options_border";
            this.txt_options_border.Size = new System.Drawing.Size(423, 15);
            this.txt_options_border.TabIndex = 13;
            // 
            // txt_options
            // 
            this.txt_options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_options.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_options.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_options.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_options.ForeColor = System.Drawing.Color.SlateBlue;
            this.txt_options.Location = new System.Drawing.Point(1, 1);
            this.txt_options.Name = "txt_options";
            this.txt_options.Size = new System.Drawing.Size(421, 13);
            this.txt_options.TabIndex = 9;
            this.txt_options.Text = "-i";
            this.txt_options.KeyDown += new System.Windows.Forms.KeyEventHandler(this.options_KeyDown);
            // 
            // txt_output_border
            // 
            this.txt_output_border.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_output_border.Controls.Add(this.txt_output);
            this.txt_output_border.Location = new System.Drawing.Point(12, 65);
            this.txt_output_border.Name = "txt_output_border";
            this.txt_output_border.Size = new System.Drawing.Size(760, 163);
            this.txt_output_border.TabIndex = 12;
            // 
            // txt_output
            // 
            this.txt_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_output.ContextMenuStrip = this.txt_output_RMB;
            this.txt_output.DetectUrls = false;
            this.txt_output.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_output.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txt_output.Location = new System.Drawing.Point(1, 1);
            this.txt_output.Name = "txt_output";
            this.txt_output.ReadOnly = true;
            this.txt_output.Size = new System.Drawing.Size(758, 161);
            this.txt_output.TabIndex = 6;
            this.txt_output.Text = "...";
            this.txt_output.WordWrap = false;
            this.txt_output.TextChanged += new System.EventHandler(this.txt_output_TextChanged);
            // 
            // fapmap_ffmpeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(784, 261);
            this.Controls.Add(this.txt_fileNew_border);
            this.Controls.Add(this.txt_file_border);
            this.Controls.Add(this.txt_options_border);
            this.Controls.Add(this.txt_output_border);
            this.Controls.Add(this.btn_fileNewDragOut);
            this.Controls.Add(this.btn_fileDragOut);
            this.Controls.Add(this.btn_delFileNew);
            this.Controls.Add(this.btn_openFileNew);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.btn_delFile);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.btn_convert);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.MediumPurple;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "fapmap_ffmpeg";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - Media Converter (ffmpeg.exe)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fapmap_ffmpeg_FormClosing);
            this.Load += new System.EventHandler(this.fapmap_ffmpeg_Load);
            this.txt_output_RMB.ResumeLayout(false);
            this.txt_fileNew_border.ResumeLayout(false);
            this.txt_fileNew_border.PerformLayout();
            this.txt_file_border.ResumeLayout(false);
            this.txt_file_border.PerformLayout();
            this.txt_options_border.ResumeLayout(false);
            this.txt_options_border.PerformLayout();
            this.txt_output_border.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_file;
        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.TextBox txt_options;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button btn_openFileNew;
        private System.Windows.Forms.Button btn_openFile;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.Button btn_delFile;
        private System.Windows.Forms.Button btn_delFileNew;
        private System.Windows.Forms.Button btn_fileNewDragOut;
        private System.Windows.Forms.Button btn_fileDragOut;
        private System.Windows.Forms.ContextMenuStrip txt_output_RMB;
        private System.Windows.Forms.ToolStripMenuItem txt_output_RMB_copy;
        private fapmap_res.FapMapPanel txt_output_border;
        private fapmap_res.FixedRichTextBox txt_output;
        private fapmap_res.FapMapPanel txt_options_border;
        private fapmap_res.FapMapPanel txt_file_border;
        private fapmap_res.FapMapPanel txt_fileNew_border;
        private System.Windows.Forms.TextBox txt_fileNew;
    }
}