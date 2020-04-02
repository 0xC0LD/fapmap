namespace fapmap
{
    partial class fapmap_info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_info));
            this.label_path = new System.Windows.Forms.Label();
            this.btn_getInfo = new System.Windows.Forms.Button();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.btn_delFile = new System.Windows.Forms.Button();
            this.btn_openFile = new System.Windows.Forms.Button();
            this.btn_selectFileInExplorer = new System.Windows.Forms.Button();
            this.btn_incognito = new System.Windows.Forms.Button();
            this.btn_booru_api = new System.Windows.Forms.Button();
            this.btn_booru_rule34xxx = new System.Windows.Forms.Button();
            this.btn_move = new System.Windows.Forms.Button();
            this.btn_rename = new System.Windows.Forms.Button();
            this.btn_booru_gelbooru = new System.Windows.Forms.Button();
            this.btn_booru_danbooru = new System.Windows.Forms.Button();
            this.cb_noZero = new System.Windows.Forms.CheckBox();
            this.label_info = new System.Windows.Forms.Label();
            this.txt_output_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txt_output_RMB_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.showImage = new System.Windows.Forms.PictureBox();
            this.txt_size_border = new fapmap_res.FapMapPanel();
            this.txt_size = new System.Windows.Forms.TextBox();
            this.txt_output_border = new fapmap_res.FapMapPanel();
            this.txt_output = new fapmap_res.FixedRichTextBox();
            this.txt_output_RMB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showImage)).BeginInit();
            this.txt_size_border.SuspendLayout();
            this.txt_output_border.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.BackColor = System.Drawing.Color.Transparent;
            this.label_path.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_path.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label_path.Location = new System.Drawing.Point(145, 85);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(40, 22);
            this.label_path.TabIndex = 0;
            this.label_path.Text = "...";
            // 
            // btn_getInfo
            // 
            this.btn_getInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_getInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_getInfo.BackgroundImage = global::fapmap.Properties.Resources.arrow_left;
            this.btn_getInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_getInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_getInfo.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_getInfo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_getInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_getInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_getInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_getInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_getInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_getInfo.Location = new System.Drawing.Point(607, 111);
            this.btn_getInfo.Name = "btn_getInfo";
            this.btn_getInfo.Size = new System.Drawing.Size(25, 25);
            this.btn_getInfo.TabIndex = 2;
            this.HelpBalloon.SetToolTip(this.btn_getInfo, "Get Info About File/Dir");
            this.btn_getInfo.UseVisualStyleBackColor = false;
            this.btn_getInfo.Click += new System.EventHandler(this.btn_getInfo_Click);
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
            this.btn_delFile.Location = new System.Drawing.Point(612, 12);
            this.btn_delFile.Name = "btn_delFile";
            this.btn_delFile.Size = new System.Drawing.Size(20, 20);
            this.btn_delFile.TabIndex = 230;
            this.HelpBalloon.SetToolTip(this.btn_delFile, "Trash Dir/File");
            this.btn_delFile.UseVisualStyleBackColor = false;
            this.btn_delFile.Click += new System.EventHandler(this.btn_delFile_Click);
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
            this.btn_openFile.Location = new System.Drawing.Point(502, 12);
            this.btn_openFile.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(20, 20);
            this.btn_openFile.TabIndex = 228;
            this.HelpBalloon.SetToolTip(this.btn_openFile, "Open");
            this.btn_openFile.UseVisualStyleBackColor = false;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // btn_selectFileInExplorer
            // 
            this.btn_selectFileInExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selectFileInExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_selectFileInExplorer.BackgroundImage = global::fapmap.Properties.Resources.selectFolder;
            this.btn_selectFileInExplorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_selectFileInExplorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selectFileInExplorer.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_selectFileInExplorer.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_selectFileInExplorer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_selectFileInExplorer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_selectFileInExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selectFileInExplorer.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_selectFileInExplorer.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_selectFileInExplorer.Location = new System.Drawing.Point(524, 12);
            this.btn_selectFileInExplorer.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_selectFileInExplorer.Name = "btn_selectFileInExplorer";
            this.btn_selectFileInExplorer.Size = new System.Drawing.Size(20, 20);
            this.btn_selectFileInExplorer.TabIndex = 229;
            this.HelpBalloon.SetToolTip(this.btn_selectFileInExplorer, "Open Explorer and Select");
            this.btn_selectFileInExplorer.UseVisualStyleBackColor = false;
            this.btn_selectFileInExplorer.Click += new System.EventHandler(this.btn_selectFileInExplorer_Click);
            // 
            // btn_incognito
            // 
            this.btn_incognito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_incognito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_incognito.BackgroundImage = global::fapmap.Properties.Resources.incognito;
            this.btn_incognito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_incognito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_incognito.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_incognito.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_incognito.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_incognito.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_incognito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_incognito.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_incognito.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_incognito.Location = new System.Drawing.Point(546, 12);
            this.btn_incognito.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_incognito.Name = "btn_incognito";
            this.btn_incognito.Size = new System.Drawing.Size(20, 20);
            this.btn_incognito.TabIndex = 231;
            this.HelpBalloon.SetToolTip(this.btn_incognito, "Search Dir/File Name in the Web Browser");
            this.btn_incognito.UseVisualStyleBackColor = false;
            this.btn_incognito.Click += new System.EventHandler(this.btn_incognito_Click);
            // 
            // btn_booru_api
            // 
            this.btn_booru_api.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_booru_api.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_api.BackgroundImage = global::fapmap.Properties.Resources.find;
            this.btn_booru_api.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_booru_api.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_booru_api.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_booru_api.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_api.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_api.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_api.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_booru_api.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_booru_api.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_booru_api.Location = new System.Drawing.Point(546, 34);
            this.btn_booru_api.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_booru_api.Name = "btn_booru_api";
            this.btn_booru_api.Size = new System.Drawing.Size(20, 20);
            this.btn_booru_api.TabIndex = 232;
            this.HelpBalloon.SetToolTip(this.btn_booru_api, "Search MD5 File Name on the Booru Search API (cure.ninja)");
            this.btn_booru_api.UseVisualStyleBackColor = false;
            this.btn_booru_api.Visible = false;
            this.btn_booru_api.Click += new System.EventHandler(this.btn_booru_api_Click);
            // 
            // btn_booru_rule34xxx
            // 
            this.btn_booru_rule34xxx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_booru_rule34xxx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_rule34xxx.BackgroundImage = global::fapmap.Properties.Resources.rule34_xxx;
            this.btn_booru_rule34xxx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_booru_rule34xxx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_booru_rule34xxx.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_booru_rule34xxx.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_rule34xxx.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_rule34xxx.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_rule34xxx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_booru_rule34xxx.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_booru_rule34xxx.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_booru_rule34xxx.Location = new System.Drawing.Point(568, 34);
            this.btn_booru_rule34xxx.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_booru_rule34xxx.Name = "btn_booru_rule34xxx";
            this.btn_booru_rule34xxx.Size = new System.Drawing.Size(20, 20);
            this.btn_booru_rule34xxx.TabIndex = 233;
            this.HelpBalloon.SetToolTip(this.btn_booru_rule34xxx, "Search MD5 File Name on rule34.xxx");
            this.btn_booru_rule34xxx.UseVisualStyleBackColor = false;
            this.btn_booru_rule34xxx.Visible = false;
            this.btn_booru_rule34xxx.Click += new System.EventHandler(this.btn_booru_rule34xxx_Click);
            // 
            // btn_move
            // 
            this.btn_move.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_move.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_move.BackgroundImage = global::fapmap.Properties.Resources.arrow_right;
            this.btn_move.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_move.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_move.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_move.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_move.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_move.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_move.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_move.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_move.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_move.Location = new System.Drawing.Point(568, 12);
            this.btn_move.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_move.Name = "btn_move";
            this.btn_move.Size = new System.Drawing.Size(20, 20);
            this.btn_move.TabIndex = 234;
            this.HelpBalloon.SetToolTip(this.btn_move, "Move Dir/File");
            this.btn_move.UseVisualStyleBackColor = false;
            this.btn_move.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_rename
            // 
            this.btn_rename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_rename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_rename.BackgroundImage = global::fapmap.Properties.Resources.rename;
            this.btn_rename.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_rename.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_rename.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_rename.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_rename.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_rename.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_rename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rename.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_rename.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_rename.Location = new System.Drawing.Point(590, 12);
            this.btn_rename.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_rename.Name = "btn_rename";
            this.btn_rename.Size = new System.Drawing.Size(20, 20);
            this.btn_rename.TabIndex = 235;
            this.HelpBalloon.SetToolTip(this.btn_rename, "Rename Dir/File");
            this.btn_rename.UseVisualStyleBackColor = false;
            this.btn_rename.Click += new System.EventHandler(this.btn_rename_Click);
            // 
            // btn_booru_gelbooru
            // 
            this.btn_booru_gelbooru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_booru_gelbooru.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_gelbooru.BackgroundImage = global::fapmap.Properties.Resources.gelbooru;
            this.btn_booru_gelbooru.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_booru_gelbooru.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_booru_gelbooru.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_booru_gelbooru.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_gelbooru.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_gelbooru.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_gelbooru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_booru_gelbooru.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_booru_gelbooru.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_booru_gelbooru.Location = new System.Drawing.Point(590, 34);
            this.btn_booru_gelbooru.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_booru_gelbooru.Name = "btn_booru_gelbooru";
            this.btn_booru_gelbooru.Size = new System.Drawing.Size(20, 20);
            this.btn_booru_gelbooru.TabIndex = 236;
            this.HelpBalloon.SetToolTip(this.btn_booru_gelbooru, "Search MD5 File Name on gelbooru.com");
            this.btn_booru_gelbooru.UseVisualStyleBackColor = false;
            this.btn_booru_gelbooru.Visible = false;
            this.btn_booru_gelbooru.Click += new System.EventHandler(this.btn_booru_gelbooru_Click);
            // 
            // btn_booru_danbooru
            // 
            this.btn_booru_danbooru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_booru_danbooru.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_danbooru.BackgroundImage = global::fapmap.Properties.Resources.danbooru;
            this.btn_booru_danbooru.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_booru_danbooru.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_booru_danbooru.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_booru_danbooru.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_danbooru.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_danbooru.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_booru_danbooru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_booru_danbooru.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_booru_danbooru.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_booru_danbooru.Location = new System.Drawing.Point(612, 34);
            this.btn_booru_danbooru.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_booru_danbooru.Name = "btn_booru_danbooru";
            this.btn_booru_danbooru.Size = new System.Drawing.Size(20, 20);
            this.btn_booru_danbooru.TabIndex = 237;
            this.HelpBalloon.SetToolTip(this.btn_booru_danbooru, "Search MD5 File Name on danbooru.donmai.us");
            this.btn_booru_danbooru.UseVisualStyleBackColor = false;
            this.btn_booru_danbooru.Visible = false;
            this.btn_booru_danbooru.Click += new System.EventHandler(this.btn_booru_danbooru_Click);
            // 
            // cb_noZero
            // 
            this.cb_noZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_noZero.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_noZero.BackColor = System.Drawing.Color.Black;
            this.cb_noZero.Checked = true;
            this.cb_noZero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_noZero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_noZero.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.cb_noZero.FlatAppearance.CheckedBackColor = System.Drawing.Color.Purple;
            this.cb_noZero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.cb_noZero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.cb_noZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_noZero.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_noZero.ForeColor = System.Drawing.Color.MediumPurple;
            this.cb_noZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_noZero.Location = new System.Drawing.Point(617, 594);
            this.cb_noZero.Name = "cb_noZero";
            this.cb_noZero.Size = new System.Drawing.Size(15, 15);
            this.cb_noZero.TabIndex = 238;
            this.HelpBalloon.SetToolTip(this.cb_noZero, "Don\'t ouput file types with 0 count");
            this.cb_noZero.UseVisualStyleBackColor = false;
            // 
            // label_info
            // 
            this.label_info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_info.AutoSize = true;
            this.label_info.BackColor = System.Drawing.Color.Transparent;
            this.label_info.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label_info.Location = new System.Drawing.Point(12, 597);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(28, 15);
            this.label_info.TabIndex = 221;
            this.label_info.Text = "...";
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
            this.txt_output_RMB_copy.ForeColor = System.Drawing.Color.MediumPurple;
            this.txt_output_RMB_copy.Image = global::fapmap.Properties.Resources.copy;
            this.txt_output_RMB_copy.Name = "txt_output_RMB_copy";
            this.txt_output_RMB_copy.Size = new System.Drawing.Size(149, 22);
            this.txt_output_RMB_copy.Text = "Copy (CTRL+C)";
            this.txt_output_RMB_copy.Click += new System.EventHandler(this.txt_output_RMB_copy_Click);
            // 
            // showImage
            // 
            this.showImage.BackColor = System.Drawing.Color.Transparent;
            this.showImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showImage.Image = global::fapmap.Properties.Resources.image;
            this.showImage.Location = new System.Drawing.Point(12, 12);
            this.showImage.Name = "showImage";
            this.showImage.Size = new System.Drawing.Size(124, 124);
            this.showImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showImage.TabIndex = 225;
            this.showImage.TabStop = false;
            // 
            // txt_size_border
            // 
            this.txt_size_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_size_border.Controls.Add(this.txt_size);
            this.txt_size_border.Location = new System.Drawing.Point(142, 111);
            this.txt_size_border.Name = "txt_size_border";
            this.txt_size_border.Size = new System.Drawing.Size(459, 25);
            this.txt_size_border.TabIndex = 227;
            // 
            // txt_size
            // 
            this.txt_size.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_size.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_size.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_size.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_size.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txt_size.Location = new System.Drawing.Point(1, 1);
            this.txt_size.Name = "txt_size";
            this.txt_size.ReadOnly = true;
            this.txt_size.Size = new System.Drawing.Size(457, 23);
            this.txt_size.TabIndex = 1;
            this.txt_size.Text = "...";
            // 
            // txt_output_border
            // 
            this.txt_output_border.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_output_border.Controls.Add(this.txt_output);
            this.txt_output_border.Location = new System.Drawing.Point(12, 142);
            this.txt_output_border.Name = "txt_output_border";
            this.txt_output_border.Size = new System.Drawing.Size(620, 446);
            this.txt_output_border.TabIndex = 226;
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
            this.txt_output.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_output.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txt_output.Location = new System.Drawing.Point(1, 1);
            this.txt_output.Name = "txt_output";
            this.txt_output.ReadOnly = true;
            this.txt_output.Size = new System.Drawing.Size(618, 444);
            this.txt_output.TabIndex = 4;
            this.txt_output.Text = "...";
            this.txt_output.WordWrap = false;
            // 
            // fapmap_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(644, 621);
            this.Controls.Add(this.cb_noZero);
            this.Controls.Add(this.btn_booru_danbooru);
            this.Controls.Add(this.btn_booru_gelbooru);
            this.Controls.Add(this.btn_rename);
            this.Controls.Add(this.btn_move);
            this.Controls.Add(this.btn_booru_rule34xxx);
            this.Controls.Add(this.btn_booru_api);
            this.Controls.Add(this.btn_incognito);
            this.Controls.Add(this.btn_delFile);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.btn_selectFileInExplorer);
            this.Controls.Add(this.txt_size_border);
            this.Controls.Add(this.txt_output_border);
            this.Controls.Add(this.showImage);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.btn_getInfo);
            this.Controls.Add(this.label_path);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.MediumPurple;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(320, 270);
            this.Name = "fapmap_info";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - Info";
            this.Load += new System.EventHandler(this.fapmap_info_Load);
            this.txt_output_RMB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showImage)).EndInit();
            this.txt_size_border.ResumeLayout(false);
            this.txt_size_border.PerformLayout();
            this.txt_output_border.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Button btn_getInfo;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.Label label_info;
        private fapmap_res.FixedRichTextBox txt_output;
        private System.Windows.Forms.TextBox txt_size;
        private System.Windows.Forms.PictureBox showImage;
        private System.Windows.Forms.ContextMenuStrip txt_output_RMB;
        private System.Windows.Forms.ToolStripMenuItem txt_output_RMB_copy;
        private fapmap_res.FapMapPanel txt_output_border;
        private fapmap_res.FapMapPanel txt_size_border;
        private System.Windows.Forms.Button btn_delFile;
        private System.Windows.Forms.Button btn_openFile;
        private System.Windows.Forms.Button btn_selectFileInExplorer;
        private System.Windows.Forms.Button btn_incognito;
        private System.Windows.Forms.Button btn_booru_api;
        private System.Windows.Forms.Button btn_booru_rule34xxx;
        private System.Windows.Forms.Button btn_move;
        private System.Windows.Forms.Button btn_rename;
        private System.Windows.Forms.Button btn_booru_gelbooru;
        private System.Windows.Forms.Button btn_booru_danbooru;
        private System.Windows.Forms.CheckBox cb_noZero;
    }
}