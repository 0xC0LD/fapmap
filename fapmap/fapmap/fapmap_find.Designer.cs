namespace fapmap
{
    partial class fapmap_find
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_find));
            this.showImage = new System.Windows.Forms.PictureBox();
            this.output_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.output_RMB_reload = new System.Windows.Forms.ToolStripMenuItem();
            this.output_RMB_open = new System.Windows.Forms.ToolStripMenuItem();
            this.output_RMB_explorer = new System.Windows.Forms.ToolStripMenuItem();
            this.output_RMB_explorer2 = new System.Windows.Forms.ToolStripMenuItem();
            this.output_RMB_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.output_RMB_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.findButton = new System.Windows.Forms.Button();
            this.txt_searchBox = new System.Windows.Forms.TextBox();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.cb_showImage = new System.Windows.Forms.CheckBox();
            this.cb_case = new System.Windows.Forms.CheckBox();
            this.cb_fileNameOnly = new System.Windows.Forms.CheckBox();
            this.resultNum = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.output = new fapmap_res.FapMapListView();
            this.output_clm_num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.output_clm_path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.output_icons = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.showImage)).BeginInit();
            this.output_RMB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // showImage
            // 
            this.showImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.showImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.showImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showImage.Image = global::fapmap.Properties.Resources.image;
            this.showImage.Location = new System.Drawing.Point(0, 0);
            this.showImage.Name = "showImage";
            this.showImage.Size = new System.Drawing.Size(483, 489);
            this.showImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showImage.TabIndex = 155;
            this.showImage.TabStop = false;
            // 
            // output_RMB
            // 
            this.output_RMB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.output_RMB.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.output_RMB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.output_RMB_reload,
            this.output_RMB_open,
            this.output_RMB_explorer,
            this.output_RMB_explorer2,
            this.output_RMB_copy,
            this.output_RMB_delete});
            this.output_RMB.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.output_RMB.Name = "contextMenuStrip1";
            this.output_RMB.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.output_RMB.ShowItemToolTips = false;
            this.output_RMB.Size = new System.Drawing.Size(240, 136);
            // 
            // output_RMB_reload
            // 
            this.output_RMB_reload.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB_reload.ForeColor = System.Drawing.Color.SlateBlue;
            this.output_RMB_reload.Image = global::fapmap.Properties.Resources.restart;
            this.output_RMB_reload.Name = "output_RMB_reload";
            this.output_RMB_reload.Size = new System.Drawing.Size(239, 22);
            this.output_RMB_reload.Text = "Reload (CTRL+R/F5)";
            this.output_RMB_reload.Click += new System.EventHandler(this.output_RMB_reload_Click);
            // 
            // output_RMB_open
            // 
            this.output_RMB_open.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB_open.ForeColor = System.Drawing.Color.SlateBlue;
            this.output_RMB_open.Image = global::fapmap.Properties.Resources.open;
            this.output_RMB_open.Name = "output_RMB_open";
            this.output_RMB_open.Size = new System.Drawing.Size(239, 22);
            this.output_RMB_open.Text = "Open Selected (ENTER/CTRL+W)";
            this.output_RMB_open.Click += new System.EventHandler(this.output_RMB_open_Click);
            // 
            // output_RMB_explorer
            // 
            this.output_RMB_explorer.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB_explorer.ForeColor = System.Drawing.Color.SlateBlue;
            this.output_RMB_explorer.Image = global::fapmap.Properties.Resources.folder;
            this.output_RMB_explorer.Name = "output_RMB_explorer";
            this.output_RMB_explorer.Size = new System.Drawing.Size(239, 22);
            this.output_RMB_explorer.Text = "Open in Explorer (CTRL+E)";
            this.output_RMB_explorer.Click += new System.EventHandler(this.output_RMB_explorer_Click);
            // 
            // output_RMB_explorer2
            // 
            this.output_RMB_explorer2.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB_explorer2.ForeColor = System.Drawing.Color.SlateBlue;
            this.output_RMB_explorer2.Image = global::fapmap.Properties.Resources.selectFolder;
            this.output_RMB_explorer2.Name = "output_RMB_explorer2";
            this.output_RMB_explorer2.Size = new System.Drawing.Size(239, 22);
            this.output_RMB_explorer2.Text = "Select in Explorer (CTRL+S)";
            this.output_RMB_explorer2.Click += new System.EventHandler(this.output_RMB_explorer2_Click);
            // 
            // output_RMB_copy
            // 
            this.output_RMB_copy.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB_copy.ForeColor = System.Drawing.Color.SlateBlue;
            this.output_RMB_copy.Image = global::fapmap.Properties.Resources.copy;
            this.output_RMB_copy.Name = "output_RMB_copy";
            this.output_RMB_copy.Size = new System.Drawing.Size(239, 22);
            this.output_RMB_copy.Text = "Copy Location (CTRL+C)";
            this.output_RMB_copy.Click += new System.EventHandler(this.output_RMB_copy_Click);
            // 
            // output_RMB_delete
            // 
            this.output_RMB_delete.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB_delete.ForeColor = System.Drawing.Color.SlateBlue;
            this.output_RMB_delete.Image = global::fapmap.Properties.Resources.delete;
            this.output_RMB_delete.Name = "output_RMB_delete";
            this.output_RMB_delete.Size = new System.Drawing.Size(239, 22);
            this.output_RMB_delete.Text = "Delete (DEL)";
            this.output_RMB_delete.Click += new System.EventHandler(this.output_RMB_delete_Click);
            // 
            // findButton
            // 
            this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.findButton.BackgroundImage = global::fapmap.Properties.Resources.find;
            this.findButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.findButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.findButton.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.findButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.findButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.findButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.findButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.findButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.findButton.Location = new System.Drawing.Point(947, 12);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(25, 25);
            this.findButton.TabIndex = 2;
            this.HelpBalloon.SetToolTip(this.findButton, "Start Searching...");
            this.findButton.UseVisualStyleBackColor = false;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // txt_searchBox
            // 
            this.txt_searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_searchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_searchBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchBox.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.txt_searchBox.Location = new System.Drawing.Point(12, 12);
            this.txt_searchBox.Name = "txt_searchBox";
            this.txt_searchBox.Size = new System.Drawing.Size(929, 25);
            this.txt_searchBox.TabIndex = 1;
            this.txt_searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_searchBox_KeyDown);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.MediumPurple;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // cb_showImage
            // 
            this.cb_showImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_showImage.AutoSize = true;
            this.cb_showImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cb_showImage.Checked = true;
            this.cb_showImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_showImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_showImage.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.cb_showImage.FlatAppearance.CheckedBackColor = System.Drawing.Color.SlateBlue;
            this.cb_showImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_showImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_showImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_showImage.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_showImage.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.cb_showImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_showImage.Location = new System.Drawing.Point(930, 538);
            this.cb_showImage.Name = "cb_showImage";
            this.cb_showImage.Size = new System.Drawing.Size(12, 11);
            this.cb_showImage.TabIndex = 4;
            this.HelpBalloon.SetToolTip(this.cb_showImage, "Show Image Preview (CTRL+W - in searchbox/list)");
            this.cb_showImage.UseVisualStyleBackColor = false;
            this.cb_showImage.CheckedChanged += new System.EventHandler(this.cb_showImage_CheckedChanged);
            // 
            // cb_case
            // 
            this.cb_case.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_case.AutoSize = true;
            this.cb_case.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cb_case.Checked = true;
            this.cb_case.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_case.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_case.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.cb_case.FlatAppearance.CheckedBackColor = System.Drawing.Color.SlateBlue;
            this.cb_case.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_case.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_case.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_case.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_case.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.cb_case.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_case.Location = new System.Drawing.Point(945, 538);
            this.cb_case.Name = "cb_case";
            this.cb_case.Size = new System.Drawing.Size(12, 11);
            this.cb_case.TabIndex = 5;
            this.HelpBalloon.SetToolTip(this.cb_case, "Case Sensitive Search (CTRL+E - in searchbox)");
            this.cb_case.UseVisualStyleBackColor = false;
            // 
            // cb_fileNameOnly
            // 
            this.cb_fileNameOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_fileNameOnly.AutoSize = true;
            this.cb_fileNameOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cb_fileNameOnly.Checked = true;
            this.cb_fileNameOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_fileNameOnly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_fileNameOnly.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.cb_fileNameOnly.FlatAppearance.CheckedBackColor = System.Drawing.Color.SlateBlue;
            this.cb_fileNameOnly.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_fileNameOnly.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_fileNameOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_fileNameOnly.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_fileNameOnly.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.cb_fileNameOnly.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_fileNameOnly.Location = new System.Drawing.Point(960, 538);
            this.cb_fileNameOnly.Name = "cb_fileNameOnly";
            this.cb_fileNameOnly.Size = new System.Drawing.Size(12, 11);
            this.cb_fileNameOnly.TabIndex = 6;
            this.HelpBalloon.SetToolTip(this.cb_fileNameOnly, "Just Print Filename And Dir (CTRL+D - in searchbox)");
            this.cb_fileNameOnly.UseVisualStyleBackColor = false;
            // 
            // resultNum
            // 
            this.resultNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resultNum.AutoSize = true;
            this.resultNum.BackColor = System.Drawing.Color.Transparent;
            this.resultNum.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resultNum.ForeColor = System.Drawing.Color.SlateBlue;
            this.resultNum.Location = new System.Drawing.Point(12, 539);
            this.resultNum.Name = "resultNum";
            this.resultNum.Size = new System.Drawing.Size(25, 13);
            this.resultNum.TabIndex = 0;
            this.resultNum.Text = "...";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 43);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.output);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.showImage);
            this.splitContainer.Size = new System.Drawing.Size(960, 489);
            this.splitContainer.SplitterDistance = 473;
            this.splitContainer.TabIndex = 232;
            // 
            // output
            // 
            this.output.AllowDrop = true;
            this.output.AutoArrange = false;
            this.output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.output.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.output.BackgroundImageTiled = true;
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.output.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.output_clm_num,
            this.output_clm_path});
            this.output.ContextMenuStrip = this.output_RMB;
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.output.ForeColor = System.Drawing.Color.SlateBlue;
            this.output.FullRowSelect = true;
            this.output.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.output.HideSelection = false;
            this.output.Location = new System.Drawing.Point(0, 0);
            this.output.MultiSelect = false;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(473, 489);
            this.output.SmallImageList = this.output_icons;
            this.output.TabIndex = 3;
            this.output.UseCompatibleStateImageBehavior = false;
            this.output.View = System.Windows.Forms.View.Details;
            this.output.SelectedIndexChanged += new System.EventHandler(this.output_SelectedIndexChanged);
            this.output.DragOver += new System.Windows.Forms.DragEventHandler(this.output_DragOver);
            this.output.KeyDown += new System.Windows.Forms.KeyEventHandler(this.output_KeyDown);
            this.output.KeyUp += new System.Windows.Forms.KeyEventHandler(this.output_KeyUp);
            this.output.LostFocus += new System.EventHandler(this.output_LostFocus);
            this.output.MouseDown += new System.Windows.Forms.MouseEventHandler(this.output_MouseDown);
            this.output.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.output_MouseWheel);
            // 
            // output_clm_num
            // 
            this.output_clm_num.Text = "#";
            this.output_clm_num.Width = 2;
            // 
            // output_clm_path
            // 
            this.output_clm_path.Text = "PATH";
            this.output_clm_path.Width = 92;
            // 
            // output_icons
            // 
            this.output_icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("output_icons.ImageStream")));
            this.output_icons.TransparentColor = System.Drawing.Color.Transparent;
            this.output_icons.Images.SetKeyName(0, "dir.ico");
            // 
            // fapmap_find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.cb_fileNameOnly);
            this.Controls.Add(this.cb_case);
            this.Controls.Add(this.cb_showImage);
            this.Controls.Add(this.txt_searchBox);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.resultNum);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(365, 200);
            this.Name = "fapmap_find";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - Find File/Folder";
            this.Load += new System.EventHandler(this.fapmap_find_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showImage)).EndInit();
            this.output_RMB.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        



        #endregion
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.TextBox txt_searchBox;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.Label resultNum;
        private System.Windows.Forms.ContextMenuStrip output_RMB;
        private System.Windows.Forms.ToolStripMenuItem output_RMB_copy;
        private System.Windows.Forms.ToolStripMenuItem output_RMB_open;
        private System.Windows.Forms.ToolStripMenuItem output_RMB_delete;
        private System.Windows.Forms.ToolStripMenuItem output_RMB_reload;
        private System.Windows.Forms.ToolStripMenuItem output_RMB_explorer;
        private System.Windows.Forms.PictureBox showImage;
        private fapmap_res.FapMapListView output;
        private System.Windows.Forms.ColumnHeader output_clm_num;
        private System.Windows.Forms.ColumnHeader output_clm_path;
        private System.Windows.Forms.ToolStripMenuItem output_RMB_explorer2;
        private System.Windows.Forms.CheckBox cb_showImage;
        private System.Windows.Forms.CheckBox cb_case;
        private System.Windows.Forms.CheckBox cb_fileNameOnly;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ImageList output_icons;
    }
}