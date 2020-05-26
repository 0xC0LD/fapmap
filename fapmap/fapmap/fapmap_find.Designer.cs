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
            this.output_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.output_RMB_reload = new System.Windows.Forms.ToolStripMenuItem();
            this.output_RMB_open = new System.Windows.Forms.ToolStripMenuItem();
            this.output_RMB_explorer = new System.Windows.Forms.ToolStripMenuItem();
            this.output_RMB_explorer2 = new System.Windows.Forms.ToolStripMenuItem();
            this.output_RMB_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.output_RMB_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.output_RMB_properties = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_find = new System.Windows.Forms.Button();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.cb_showMedia = new System.Windows.Forms.CheckBox();
            this.cb_case = new System.Windows.Forms.CheckBox();
            this.cb_nameOnly = new System.Windows.Forms.CheckBox();
            this.cb_sort = new System.Windows.Forms.CheckBox();
            this.btn_help = new System.Windows.Forms.Button();
            this.cb_ignoreFolders = new System.Windows.Forms.CheckBox();
            this.output_btn_priv = new System.Windows.Forms.Button();
            this.output_btn_next = new System.Windows.Forms.Button();
            this.resultNum = new System.Windows.Forms.Label();
            this.output_icons = new System.Windows.Forms.ImageList(this.components);
            this.output_border = new fapmap_res.FapMapPanel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.output = new fapmap_res.FapMapListView();
            this.output_clm_num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.output_clm_path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.showMedia_image = new System.Windows.Forms.PictureBox();
            this.showMedia_video = new AxWMPLib.AxWindowsMediaPlayer();
            this.txt_searchBox_border = new fapmap_res.FapMapPanel();
            this.txt_searchBox = new System.Windows.Forms.TextBox();
            this.output_RMB.SuspendLayout();
            this.output_border.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showMedia_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showMedia_video)).BeginInit();
            this.txt_searchBox_border.SuspendLayout();
            this.SuspendLayout();
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
            this.output_RMB_delete,
            this.output_RMB_properties});
            this.output_RMB.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.output_RMB.Name = "contextMenuStrip1";
            this.output_RMB.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.output_RMB.ShowItemToolTips = false;
            this.output_RMB.Size = new System.Drawing.Size(240, 158);
            // 
            // output_RMB_reload
            // 
            this.output_RMB_reload.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB_reload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.output_RMB_reload.Image = global::fapmap.Properties.Resources.restart;
            this.output_RMB_reload.Name = "output_RMB_reload";
            this.output_RMB_reload.Size = new System.Drawing.Size(239, 22);
            this.output_RMB_reload.Text = "Reload (CTRL+R/F5)";
            this.output_RMB_reload.Click += new System.EventHandler(this.output_RMB_reload_Click);
            // 
            // output_RMB_open
            // 
            this.output_RMB_open.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB_open.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.output_RMB_open.Image = global::fapmap.Properties.Resources.open;
            this.output_RMB_open.Name = "output_RMB_open";
            this.output_RMB_open.Size = new System.Drawing.Size(239, 22);
            this.output_RMB_open.Text = "Open Selected (ENTER/CTRL+W)";
            this.output_RMB_open.Click += new System.EventHandler(this.output_RMB_open_Click);
            // 
            // output_RMB_explorer
            // 
            this.output_RMB_explorer.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB_explorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.output_RMB_explorer.Image = global::fapmap.Properties.Resources.folder;
            this.output_RMB_explorer.Name = "output_RMB_explorer";
            this.output_RMB_explorer.Size = new System.Drawing.Size(239, 22);
            this.output_RMB_explorer.Text = "Open in Explorer (CTRL+E)";
            this.output_RMB_explorer.Click += new System.EventHandler(this.output_RMB_explorer_Click);
            // 
            // output_RMB_explorer2
            // 
            this.output_RMB_explorer2.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB_explorer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.output_RMB_explorer2.Image = global::fapmap.Properties.Resources.selectFolder;
            this.output_RMB_explorer2.Name = "output_RMB_explorer2";
            this.output_RMB_explorer2.Size = new System.Drawing.Size(239, 22);
            this.output_RMB_explorer2.Text = "Select in Explorer (CTRL+S)";
            this.output_RMB_explorer2.Click += new System.EventHandler(this.output_RMB_explorer2_Click);
            // 
            // output_RMB_copy
            // 
            this.output_RMB_copy.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB_copy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.output_RMB_copy.Image = global::fapmap.Properties.Resources.copy;
            this.output_RMB_copy.Name = "output_RMB_copy";
            this.output_RMB_copy.Size = new System.Drawing.Size(239, 22);
            this.output_RMB_copy.Text = "Copy Location (CTRL+C)";
            this.output_RMB_copy.Click += new System.EventHandler(this.output_RMB_copy_Click);
            // 
            // output_RMB_delete
            // 
            this.output_RMB_delete.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.output_RMB_delete.Image = global::fapmap.Properties.Resources.delete;
            this.output_RMB_delete.Name = "output_RMB_delete";
            this.output_RMB_delete.Size = new System.Drawing.Size(239, 22);
            this.output_RMB_delete.Text = "Delete (DEL)";
            this.output_RMB_delete.Click += new System.EventHandler(this.output_RMB_delete_Click);
            // 
            // output_RMB_properties
            // 
            this.output_RMB_properties.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.output_RMB_properties.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.output_RMB_properties.Image = global::fapmap.Properties.Resources.settings;
            this.output_RMB_properties.Name = "output_RMB_properties";
            this.output_RMB_properties.Size = new System.Drawing.Size(239, 22);
            this.output_RMB_properties.Text = "Properties (CTRL+D)";
            this.output_RMB_properties.Click += new System.EventHandler(this.output_RMB_properties_Click);
            // 
            // btn_find
            // 
            this.btn_find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_find.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.btn_find.BackgroundImage = global::fapmap.Properties.Resources.find_hotpink;
            this.btn_find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_find.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_find.FlatAppearance.BorderColor = System.Drawing.Color.HotPink;
            this.btn_find.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_find.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.btn_find.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.btn_find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_find.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_find.ForeColor = System.Drawing.Color.HotPink;
            this.btn_find.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_find.Location = new System.Drawing.Point(947, 12);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(25, 25);
            this.btn_find.TabIndex = 2;
            this.HelpBalloon.SetToolTip(this.btn_find, "Start Searching...");
            this.btn_find.UseVisualStyleBackColor = false;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.HelpBalloon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // cb_showMedia
            // 
            this.cb_showMedia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_showMedia.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_showMedia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.cb_showMedia.Checked = true;
            this.cb_showMedia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_showMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_showMedia.FlatAppearance.BorderColor = System.Drawing.Color.HotPink;
            this.cb_showMedia.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_showMedia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_showMedia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_showMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_showMedia.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_showMedia.ForeColor = System.Drawing.Color.HotPink;
            this.cb_showMedia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_showMedia.Location = new System.Drawing.Point(904, 537);
            this.cb_showMedia.Name = "cb_showMedia";
            this.cb_showMedia.Size = new System.Drawing.Size(12, 12);
            this.cb_showMedia.TabIndex = 4;
            this.HelpBalloon.SetToolTip(this.cb_showMedia, "Show Media Preview (CTRL+Q - in searchbox/list)");
            this.cb_showMedia.UseVisualStyleBackColor = false;
            this.cb_showMedia.CheckedChanged += new System.EventHandler(this.cb_showImage_CheckedChanged);
            // 
            // cb_case
            // 
            this.cb_case.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_case.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_case.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.cb_case.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_case.FlatAppearance.BorderColor = System.Drawing.Color.HotPink;
            this.cb_case.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_case.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_case.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_case.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_case.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_case.ForeColor = System.Drawing.Color.HotPink;
            this.cb_case.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_case.Location = new System.Drawing.Point(918, 537);
            this.cb_case.Name = "cb_case";
            this.cb_case.Size = new System.Drawing.Size(12, 12);
            this.cb_case.TabIndex = 5;
            this.HelpBalloon.SetToolTip(this.cb_case, "Case Sensitive Search (CTRL+E - in searchbox)");
            this.cb_case.UseVisualStyleBackColor = false;
            // 
            // cb_nameOnly
            // 
            this.cb_nameOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_nameOnly.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_nameOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.cb_nameOnly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_nameOnly.FlatAppearance.BorderColor = System.Drawing.Color.HotPink;
            this.cb_nameOnly.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_nameOnly.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_nameOnly.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_nameOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_nameOnly.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_nameOnly.ForeColor = System.Drawing.Color.HotPink;
            this.cb_nameOnly.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_nameOnly.Location = new System.Drawing.Point(946, 537);
            this.cb_nameOnly.Name = "cb_nameOnly";
            this.cb_nameOnly.Size = new System.Drawing.Size(12, 12);
            this.cb_nameOnly.TabIndex = 6;
            this.HelpBalloon.SetToolTip(this.cb_nameOnly, "Just Print Folder/File Name and Parent Folder (CTRL+F - in searchbox)");
            this.cb_nameOnly.UseVisualStyleBackColor = false;
            // 
            // cb_sort
            // 
            this.cb_sort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_sort.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_sort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.cb_sort.Checked = true;
            this.cb_sort.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_sort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_sort.FlatAppearance.BorderColor = System.Drawing.Color.HotPink;
            this.cb_sort.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_sort.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_sort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_sort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_sort.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_sort.ForeColor = System.Drawing.Color.HotPink;
            this.cb_sort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_sort.Location = new System.Drawing.Point(932, 537);
            this.cb_sort.Name = "cb_sort";
            this.cb_sort.Size = new System.Drawing.Size(12, 12);
            this.cb_sort.TabIndex = 233;
            this.HelpBalloon.SetToolTip(this.cb_sort, "Sort Items by Creation DateTime (Newest Files Go Up in the List) (CTRL+D - in sea" +
        "rchbox))");
            this.cb_sort.UseVisualStyleBackColor = false;
            // 
            // btn_help
            // 
            this.btn_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_help.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.btn_help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_help.FlatAppearance.BorderColor = System.Drawing.Color.HotPink;
            this.btn_help.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_help.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_help.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_help.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_help.ForeColor = System.Drawing.Color.HotPink;
            this.btn_help.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_help.Location = new System.Drawing.Point(890, 537);
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(12, 12);
            this.btn_help.TabIndex = 234;
            this.HelpBalloon.SetToolTip(this.btn_help, "Search Help");
            this.btn_help.UseVisualStyleBackColor = false;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // cb_ignoreFolders
            // 
            this.cb_ignoreFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_ignoreFolders.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_ignoreFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.cb_ignoreFolders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_ignoreFolders.FlatAppearance.BorderColor = System.Drawing.Color.HotPink;
            this.cb_ignoreFolders.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_ignoreFolders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_ignoreFolders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cb_ignoreFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_ignoreFolders.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_ignoreFolders.ForeColor = System.Drawing.Color.HotPink;
            this.cb_ignoreFolders.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_ignoreFolders.Location = new System.Drawing.Point(960, 537);
            this.cb_ignoreFolders.Name = "cb_ignoreFolders";
            this.cb_ignoreFolders.Size = new System.Drawing.Size(12, 12);
            this.cb_ignoreFolders.TabIndex = 238;
            this.HelpBalloon.SetToolTip(this.cb_ignoreFolders, "Ignore Folders");
            this.cb_ignoreFolders.UseVisualStyleBackColor = false;
            // 
            // output_btn_priv
            // 
            this.output_btn_priv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.output_btn_priv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.output_btn_priv.BackgroundImage = global::fapmap.Properties.Resources.arrow_left_hotpink;
            this.output_btn_priv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.output_btn_priv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.output_btn_priv.FlatAppearance.BorderColor = System.Drawing.Color.HotPink;
            this.output_btn_priv.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.output_btn_priv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.output_btn_priv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.output_btn_priv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.output_btn_priv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.output_btn_priv.ForeColor = System.Drawing.Color.HotPink;
            this.output_btn_priv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.output_btn_priv.Location = new System.Drawing.Point(862, 537);
            this.output_btn_priv.Name = "output_btn_priv";
            this.output_btn_priv.Size = new System.Drawing.Size(12, 12);
            this.output_btn_priv.TabIndex = 240;
            this.HelpBalloon.SetToolTip(this.output_btn_priv, "Previous Item");
            this.output_btn_priv.UseVisualStyleBackColor = false;
            this.output_btn_priv.Click += new System.EventHandler(this.output_btn_priv_Click);
            // 
            // output_btn_next
            // 
            this.output_btn_next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.output_btn_next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.output_btn_next.BackgroundImage = global::fapmap.Properties.Resources.arrow_right_hotpink;
            this.output_btn_next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.output_btn_next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.output_btn_next.FlatAppearance.BorderColor = System.Drawing.Color.HotPink;
            this.output_btn_next.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.output_btn_next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.output_btn_next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.output_btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.output_btn_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.output_btn_next.ForeColor = System.Drawing.Color.HotPink;
            this.output_btn_next.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.output_btn_next.Location = new System.Drawing.Point(876, 537);
            this.output_btn_next.Name = "output_btn_next";
            this.output_btn_next.Size = new System.Drawing.Size(12, 12);
            this.output_btn_next.TabIndex = 239;
            this.HelpBalloon.SetToolTip(this.output_btn_next, "Next Item");
            this.output_btn_next.UseVisualStyleBackColor = false;
            this.output_btn_next.Click += new System.EventHandler(this.output_btn_next_Click);
            // 
            // resultNum
            // 
            this.resultNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resultNum.AutoSize = true;
            this.resultNum.BackColor = System.Drawing.Color.Transparent;
            this.resultNum.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resultNum.ForeColor = System.Drawing.Color.HotPink;
            this.resultNum.Location = new System.Drawing.Point(12, 539);
            this.resultNum.Name = "resultNum";
            this.resultNum.Size = new System.Drawing.Size(25, 13);
            this.resultNum.TabIndex = 0;
            this.resultNum.Text = "...";
            // 
            // output_icons
            // 
            this.output_icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("output_icons.ImageStream")));
            this.output_icons.TransparentColor = System.Drawing.Color.Transparent;
            this.output_icons.Images.SetKeyName(0, "dir.ico");
            // 
            // output_border
            // 
            this.output_border.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output_border.Controls.Add(this.splitContainer);
            this.output_border.ForeColor = System.Drawing.Color.HotPink;
            this.output_border.Location = new System.Drawing.Point(12, 43);
            this.output_border.Name = "output_border";
            this.output_border.Size = new System.Drawing.Size(960, 489);
            this.output_border.TabIndex = 236;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.splitContainer.Location = new System.Drawing.Point(1, 1);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.output);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.Controls.Add(this.showMedia_image);
            this.splitContainer.Panel2.Controls.Add(this.showMedia_video);
            this.splitContainer.Size = new System.Drawing.Size(958, 487);
            this.splitContainer.SplitterDistance = 471;
            this.splitContainer.SplitterWidth = 7;
            this.splitContainer.TabIndex = 232;
            this.splitContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitContainer_MouseDown);
            this.splitContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitContainer_MouseMove);
            this.splitContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitContainer_MouseUp);
            // 
            // output
            // 
            this.output.AllowDrop = true;
            this.output.AutoArrange = false;
            this.output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.output.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.output.BackgroundImageTiled = true;
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.output.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.output_clm_num,
            this.output_clm_path});
            this.output.ContextMenuStrip = this.output_RMB;
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.output.ForeColor = System.Drawing.Color.HotPink;
            this.output.FullRowSelect = true;
            this.output.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.output.HideSelection = false;
            this.output.Location = new System.Drawing.Point(0, 0);
            this.output.MultiSelect = false;
            this.output.Name = "output";
            this.output.ShowItemToolTips = true;
            this.output.Size = new System.Drawing.Size(471, 487);
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
            // showMedia_image
            // 
            this.showMedia_image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.showMedia_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showMedia_image.ContextMenuStrip = this.output_RMB;
            this.showMedia_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showMedia_image.Image = global::fapmap.Properties.Resources.image;
            this.showMedia_image.Location = new System.Drawing.Point(0, 0);
            this.showMedia_image.Name = "showMedia_image";
            this.showMedia_image.Size = new System.Drawing.Size(480, 487);
            this.showMedia_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showMedia_image.TabIndex = 155;
            this.showMedia_image.TabStop = false;
            this.showMedia_image.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showMedia_image_MouseUp);
            // 
            // showMedia_video
            // 
            this.showMedia_video.ContextMenuStrip = this.output_RMB;
            this.showMedia_video.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showMedia_video.Enabled = true;
            this.showMedia_video.Location = new System.Drawing.Point(0, 0);
            this.showMedia_video.Name = "showMedia_video";
            this.showMedia_video.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("showMedia_video.OcxState")));
            this.showMedia_video.Size = new System.Drawing.Size(480, 487);
            this.showMedia_video.TabIndex = 157;
            this.showMedia_video.MouseUpEvent += new AxWMPLib._WMPOCXEvents_MouseUpEventHandler(this.showMedia_video_MouseUpEvent);
            // 
            // txt_searchBox_border
            // 
            this.txt_searchBox_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_searchBox_border.Controls.Add(this.txt_searchBox);
            this.txt_searchBox_border.ForeColor = System.Drawing.Color.HotPink;
            this.txt_searchBox_border.Location = new System.Drawing.Point(12, 12);
            this.txt_searchBox_border.Name = "txt_searchBox_border";
            this.txt_searchBox_border.Size = new System.Drawing.Size(929, 25);
            this.txt_searchBox_border.TabIndex = 235;
            // 
            // txt_searchBox
            // 
            this.txt_searchBox.AllowDrop = true;
            this.txt_searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_searchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.txt_searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_searchBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchBox.ForeColor = System.Drawing.Color.HotPink;
            this.txt_searchBox.Location = new System.Drawing.Point(1, 1);
            this.txt_searchBox.Name = "txt_searchBox";
            this.txt_searchBox.Size = new System.Drawing.Size(927, 19);
            this.txt_searchBox.TabIndex = 1;
            this.txt_searchBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_searchBox_DragDrop);
            this.txt_searchBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_searchBox_DragEnter);
            this.txt_searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_searchBox_KeyDown);
            // 
            // fapmap_find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.output_btn_priv);
            this.Controls.Add(this.output_btn_next);
            this.Controls.Add(this.cb_ignoreFolders);
            this.Controls.Add(this.output_border);
            this.Controls.Add(this.txt_searchBox_border);
            this.Controls.Add(this.btn_help);
            this.Controls.Add(this.cb_sort);
            this.Controls.Add(this.cb_nameOnly);
            this.Controls.Add(this.cb_case);
            this.Controls.Add(this.cb_showMedia);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.resultNum);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(365, 200);
            this.Name = "fapmap_find";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - Find File/Folder";
            this.Load += new System.EventHandler(this.fapmap_find_Load);
            this.output_RMB.ResumeLayout(false);
            this.output_border.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showMedia_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showMedia_video)).EndInit();
            this.txt_searchBox_border.ResumeLayout(false);
            this.txt_searchBox_border.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        



        #endregion
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_searchBox;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.Label resultNum;
        private System.Windows.Forms.ContextMenuStrip output_RMB;
        private System.Windows.Forms.ToolStripMenuItem output_RMB_copy;
        private System.Windows.Forms.ToolStripMenuItem output_RMB_open;
        private System.Windows.Forms.ToolStripMenuItem output_RMB_delete;
        private System.Windows.Forms.ToolStripMenuItem output_RMB_reload;
        private System.Windows.Forms.ToolStripMenuItem output_RMB_explorer;
        private System.Windows.Forms.PictureBox showMedia_image;
        private fapmap_res.FapMapListView output;
        private System.Windows.Forms.ColumnHeader output_clm_num;
        private System.Windows.Forms.ColumnHeader output_clm_path;
        private System.Windows.Forms.ToolStripMenuItem output_RMB_explorer2;
        private System.Windows.Forms.CheckBox cb_showMedia;
        private System.Windows.Forms.CheckBox cb_case;
        private System.Windows.Forms.CheckBox cb_nameOnly;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ImageList output_icons;
        private System.Windows.Forms.CheckBox cb_sort;
        private System.Windows.Forms.Button btn_help;
        private fapmap_res.FapMapPanel txt_searchBox_border;
        private fapmap_res.FapMapPanel output_border;
        private System.Windows.Forms.ToolStripMenuItem output_RMB_properties;
        private System.Windows.Forms.CheckBox cb_ignoreFolders;
        public AxWMPLib.AxWindowsMediaPlayer showMedia_video;
        private System.Windows.Forms.Button output_btn_priv;
        private System.Windows.Forms.Button output_btn_next;
    }
}