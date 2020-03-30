namespace fapmap
{
    partial class fapmap_download
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_download));
            this.cb_auto = new System.Windows.Forms.CheckBox();
            this.rb_shutdown = new System.Windows.Forms.RadioButton();
            this.rb_exit = new System.Windows.Forms.RadioButton();
            this.rb_close = new System.Windows.Forms.RadioButton();
            this.rb_null = new System.Windows.Forms.RadioButton();
            this.label_linksCount = new System.Windows.Forms.Label();
            this.cb_nonFile = new System.Windows.Forms.CheckBox();
            this.cb_conflict_replace = new System.Windows.Forms.CheckBox();
            this.cb_conflict_rename = new System.Windows.Forms.CheckBox();
            this.cb_conflict_skip = new System.Windows.Forms.CheckBox();
            this.txt_dir = new System.Windows.Forms.TextBox();
            this.btn_openFile = new System.Windows.Forms.Button();
            this.btn_dl = new System.Windows.Forms.Button();
            this.this_trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.btn_addURL = new System.Windows.Forms.Button();
            this.btn_webgrabStart = new System.Windows.Forms.Button();
            this.btn_openPathSelector = new System.Windows.Forms.Button();
            this.btn_openURL = new System.Windows.Forms.Button();
            this.btn_selectFileInExplorer = new System.Windows.Forms.Button();
            this.btn_dragOutURL = new System.Windows.Forms.Button();
            this.btn_dragOutFilePath = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.TextBox();
            this.links_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.links_RMB_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_download = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_incognito = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_cut = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_paste = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_deleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_deleteSome = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.txt_dledURL = new System.Windows.Forms.TextBox();
            this.txt_webgrabOptions = new System.Windows.Forms.TextBox();
            this.txt_webgrabURL = new System.Windows.Forms.TextBox();
            this.panel_info = new System.Windows.Forms.Panel();
            this.pbar = new fapmap_res.FapMapProgressBar();
            this.txt_dledPATH = new System.Windows.Forms.TextBox();
            this.txt_filename = new System.Windows.Forms.TextBox();
            this.auto = new System.Windows.Forms.Timer(this.components);
            this.links = new fapmap_res.FapMapListView();
            this.links_clm_num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.links_clm_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.links_clm_url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txt_webgrabURL_border = new fapmap_res.FapMapPanel();
            this.txt_webgrabOptions_border = new fapmap_res.FapMapPanel();
            this.txt_url_border = new fapmap_res.FapMapPanel();
            this.links_border = new fapmap_res.FapMapPanel();
            this.txt_dir_border = new fapmap_res.FapMapPanel();
            this.txt_filename_border = new fapmap_res.FapMapPanel();
            this.panel_info_border = new fapmap_res.FapMapPanel();
            this.fapMapPanel1 = new fapmap_res.FapMapPanel();
            this.txt_dledURL_border = new fapmap_res.FapMapPanel();
            this.txt_dledPATH_border = new fapmap_res.FapMapPanel();
            this.links_RMB.SuspendLayout();
            this.panel_info.SuspendLayout();
            this.txt_webgrabURL_border.SuspendLayout();
            this.txt_webgrabOptions_border.SuspendLayout();
            this.txt_url_border.SuspendLayout();
            this.links_border.SuspendLayout();
            this.txt_dir_border.SuspendLayout();
            this.txt_filename_border.SuspendLayout();
            this.panel_info_border.SuspendLayout();
            this.fapMapPanel1.SuspendLayout();
            this.txt_dledURL_border.SuspendLayout();
            this.txt_dledPATH_border.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_auto
            // 
            this.cb_auto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_auto.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_auto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.cb_auto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_auto.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_auto.FlatAppearance.CheckedBackColor = System.Drawing.Color.RoyalBlue;
            this.cb_auto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.cb_auto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.cb_auto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_auto.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_auto.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_auto.Location = new System.Drawing.Point(83, 2);
            this.cb_auto.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_auto.Name = "cb_auto";
            this.cb_auto.Size = new System.Drawing.Size(15, 15);
            this.cb_auto.TabIndex = 18;
            this.HelpBalloon.SetToolTip(this.cb_auto, "Automatically download files in listbox");
            this.cb_auto.UseVisualStyleBackColor = false;
            this.cb_auto.CheckedChanged += new System.EventHandler(this.cb_auto_CheckedChanged);
            // 
            // rb_shutdown
            // 
            this.rb_shutdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_shutdown.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_shutdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.rb_shutdown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_shutdown.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrchid;
            this.rb_shutdown.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkOrchid;
            this.rb_shutdown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrchid;
            this.rb_shutdown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.rb_shutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_shutdown.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb_shutdown.ForeColor = System.Drawing.Color.DarkOrchid;
            this.rb_shutdown.Location = new System.Drawing.Point(3, 48);
            this.rb_shutdown.Name = "rb_shutdown";
            this.rb_shutdown.Size = new System.Drawing.Size(10, 10);
            this.rb_shutdown.TabIndex = 13;
            this.HelpBalloon.SetToolTip(this.rb_shutdown, "Shutdown PC... After all downloads have finished");
            this.rb_shutdown.UseCompatibleTextRendering = true;
            this.rb_shutdown.UseVisualStyleBackColor = false;
            // 
            // rb_exit
            // 
            this.rb_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_exit.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.rb_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_exit.FlatAppearance.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rb_exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleVioletRed;
            this.rb_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleVioletRed;
            this.rb_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleVioletRed;
            this.rb_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_exit.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb_exit.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.rb_exit.Location = new System.Drawing.Point(3, 37);
            this.rb_exit.Name = "rb_exit";
            this.rb_exit.Size = new System.Drawing.Size(10, 10);
            this.rb_exit.TabIndex = 14;
            this.HelpBalloon.SetToolTip(this.rb_exit, "Exit FapMap... After all downloads have finished");
            this.rb_exit.UseCompatibleTextRendering = true;
            this.rb_exit.UseVisualStyleBackColor = false;
            // 
            // rb_close
            // 
            this.rb_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_close.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.rb_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_close.FlatAppearance.BorderColor = System.Drawing.Color.DeepPink;
            this.rb_close.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepPink;
            this.rb_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepPink;
            this.rb_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepPink;
            this.rb_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_close.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb_close.ForeColor = System.Drawing.Color.DeepPink;
            this.rb_close.Location = new System.Drawing.Point(3, 26);
            this.rb_close.Name = "rb_close";
            this.rb_close.Size = new System.Drawing.Size(10, 10);
            this.rb_close.TabIndex = 12;
            this.HelpBalloon.SetToolTip(this.rb_close, "Close downloader... After all downloads have finished");
            this.rb_close.UseCompatibleTextRendering = true;
            this.rb_close.UseVisualStyleBackColor = false;
            // 
            // rb_null
            // 
            this.rb_null.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_null.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_null.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.rb_null.Checked = true;
            this.rb_null.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_null.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.rb_null.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.rb_null.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.rb_null.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.rb_null.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_null.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb_null.ForeColor = System.Drawing.Color.Teal;
            this.rb_null.Location = new System.Drawing.Point(3, 15);
            this.rb_null.Name = "rb_null";
            this.rb_null.Size = new System.Drawing.Size(10, 10);
            this.rb_null.TabIndex = 11;
            this.rb_null.TabStop = true;
            this.HelpBalloon.SetToolTip(this.rb_null, "Do nothing... After all downloads have finished");
            this.rb_null.UseCompatibleTextRendering = true;
            this.rb_null.UseVisualStyleBackColor = false;
            // 
            // label_linksCount
            // 
            this.label_linksCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_linksCount.AutoSize = true;
            this.label_linksCount.BackColor = System.Drawing.Color.Transparent;
            this.label_linksCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_linksCount.ForeColor = System.Drawing.Color.Teal;
            this.label_linksCount.Location = new System.Drawing.Point(17, 41);
            this.label_linksCount.Name = "label_linksCount";
            this.label_linksCount.Size = new System.Drawing.Size(14, 14);
            this.label_linksCount.TabIndex = 0;
            this.label_linksCount.Text = "0";
            // 
            // cb_nonFile
            // 
            this.cb_nonFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_nonFile.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_nonFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.cb_nonFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_nonFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.cb_nonFile.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.cb_nonFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.cb_nonFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.cb_nonFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_nonFile.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_nonFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.cb_nonFile.Location = new System.Drawing.Point(67, 2);
            this.cb_nonFile.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_nonFile.Name = "cb_nonFile";
            this.cb_nonFile.Size = new System.Drawing.Size(15, 15);
            this.cb_nonFile.TabIndex = 19;
            this.HelpBalloon.SetToolTip(this.cb_nonFile, "Allow non-file urls (may crash application)");
            this.cb_nonFile.UseVisualStyleBackColor = false;
            // 
            // cb_conflict_replace
            // 
            this.cb_conflict_replace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_conflict_replace.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_conflict_replace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.cb_conflict_replace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_conflict_replace.FlatAppearance.BorderColor = System.Drawing.Color.Magenta;
            this.cb_conflict_replace.FlatAppearance.CheckedBackColor = System.Drawing.Color.Magenta;
            this.cb_conflict_replace.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta;
            this.cb_conflict_replace.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Magenta;
            this.cb_conflict_replace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_conflict_replace.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_conflict_replace.ForeColor = System.Drawing.Color.Magenta;
            this.cb_conflict_replace.Location = new System.Drawing.Point(35, 2);
            this.cb_conflict_replace.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_conflict_replace.Name = "cb_conflict_replace";
            this.cb_conflict_replace.Size = new System.Drawing.Size(15, 15);
            this.cb_conflict_replace.TabIndex = 16;
            this.HelpBalloon.SetToolTip(this.cb_conflict_replace, "Automatically replace file, if file exists...");
            this.cb_conflict_replace.UseVisualStyleBackColor = false;
            this.cb_conflict_replace.CheckedChanged += new System.EventHandler(this.cb_replace_CheckedChanged);
            // 
            // cb_conflict_rename
            // 
            this.cb_conflict_rename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_conflict_rename.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_conflict_rename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.cb_conflict_rename.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_conflict_rename.FlatAppearance.BorderColor = System.Drawing.Color.LightBlue;
            this.cb_conflict_rename.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightBlue;
            this.cb_conflict_rename.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            this.cb_conflict_rename.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.cb_conflict_rename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_conflict_rename.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_conflict_rename.ForeColor = System.Drawing.Color.LightBlue;
            this.cb_conflict_rename.Location = new System.Drawing.Point(19, 2);
            this.cb_conflict_rename.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_conflict_rename.Name = "cb_conflict_rename";
            this.cb_conflict_rename.Size = new System.Drawing.Size(15, 15);
            this.cb_conflict_rename.TabIndex = 17;
            this.HelpBalloon.SetToolTip(this.cb_conflict_rename, "Automatically rename file, if file exists...");
            this.cb_conflict_rename.UseVisualStyleBackColor = false;
            this.cb_conflict_rename.CheckedChanged += new System.EventHandler(this.cb_rename_CheckedChanged);
            // 
            // cb_conflict_skip
            // 
            this.cb_conflict_skip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_conflict_skip.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_conflict_skip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.cb_conflict_skip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_conflict_skip.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.cb_conflict_skip.FlatAppearance.CheckedBackColor = System.Drawing.Color.YellowGreen;
            this.cb_conflict_skip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.YellowGreen;
            this.cb_conflict_skip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen;
            this.cb_conflict_skip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_conflict_skip.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_conflict_skip.ForeColor = System.Drawing.Color.YellowGreen;
            this.cb_conflict_skip.Location = new System.Drawing.Point(51, 2);
            this.cb_conflict_skip.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_conflict_skip.Name = "cb_conflict_skip";
            this.cb_conflict_skip.Size = new System.Drawing.Size(15, 15);
            this.cb_conflict_skip.TabIndex = 15;
            this.HelpBalloon.SetToolTip(this.cb_conflict_skip, "Automatically skip URL, if file exists...");
            this.cb_conflict_skip.UseVisualStyleBackColor = false;
            this.cb_conflict_skip.CheckedChanged += new System.EventHandler(this.cb_skip_CheckedChanged);
            // 
            // txt_dir
            // 
            this.txt_dir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_dir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(7)))), ((int)(((byte)(15)))));
            this.txt_dir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dir.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.txt_dir.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txt_dir.Location = new System.Drawing.Point(1, 1);
            this.txt_dir.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_dir.Name = "txt_dir";
            this.txt_dir.Size = new System.Drawing.Size(800, 16);
            this.txt_dir.TabIndex = 7;
            this.txt_dir.TextChanged += new System.EventHandler(this.txt_dir_TextChanged);
            this.txt_dir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_dir_KeyDown);
            // 
            // btn_openFile
            // 
            this.btn_openFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFile.BackgroundImage = global::fapmap.Properties.Resources.open;
            this.btn_openFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_openFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_openFile.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_openFile.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openFile.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_openFile.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_openFile.Location = new System.Drawing.Point(815, 390);
            this.btn_openFile.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(18, 18);
            this.btn_openFile.TabIndex = 26;
            this.HelpBalloon.SetToolTip(this.btn_openFile, "Open Last Downloaded File");
            this.btn_openFile.UseVisualStyleBackColor = false;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // btn_dl
            // 
            this.btn_dl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_dl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_dl.BackgroundImage = global::fapmap.Properties.Resources.downloadFile;
            this.btn_dl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_dl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dl.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_dl.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_dl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_dl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_dl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dl.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_dl.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_dl.Location = new System.Drawing.Point(815, 288);
            this.btn_dl.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_dl.Name = "btn_dl";
            this.btn_dl.Size = new System.Drawing.Size(18, 18);
            this.btn_dl.TabIndex = 10;
            this.HelpBalloon.SetToolTip(this.btn_dl, "Download/Cancel download");
            this.btn_dl.UseVisualStyleBackColor = false;
            this.btn_dl.Click += new System.EventHandler(this.btn_dl_Click);
            // 
            // this_trayicon
            // 
            this.this_trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("this_trayicon.Icon")));
            this.this_trayicon.Visible = true;
            this.this_trayicon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.this_trayicon_MouseUp);
            this.this_trayicon.Disposed += new System.EventHandler(this.this_trayicon_Disposed);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // btn_addURL
            // 
            this.btn_addURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_addURL.BackgroundImage = global::fapmap.Properties.Resources.arrow_down;
            this.btn_addURL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addURL.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_addURL.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_addURL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_addURL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_addURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_addURL.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_addURL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_addURL.Location = new System.Drawing.Point(815, 33);
            this.btn_addURL.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_addURL.Name = "btn_addURL";
            this.btn_addURL.Size = new System.Drawing.Size(18, 18);
            this.btn_addURL.TabIndex = 5;
            this.HelpBalloon.SetToolTip(this.btn_addURL, "Add file url to download list");
            this.btn_addURL.UseVisualStyleBackColor = false;
            this.btn_addURL.Click += new System.EventHandler(this.btn_addURL_Click);
            // 
            // btn_webgrabStart
            // 
            this.btn_webgrabStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_webgrabStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_webgrabStart.BackgroundImage = global::fapmap.Properties.Resources.scanPage;
            this.btn_webgrabStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_webgrabStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_webgrabStart.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_webgrabStart.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_webgrabStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_webgrabStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_webgrabStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_webgrabStart.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_webgrabStart.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_webgrabStart.Location = new System.Drawing.Point(815, 12);
            this.btn_webgrabStart.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_webgrabStart.Name = "btn_webgrabStart";
            this.btn_webgrabStart.Size = new System.Drawing.Size(18, 18);
            this.btn_webgrabStart.TabIndex = 3;
            this.HelpBalloon.SetToolTip(this.btn_webgrabStart, "Start/Stop webgrab.exe");
            this.btn_webgrabStart.UseVisualStyleBackColor = false;
            this.btn_webgrabStart.Click += new System.EventHandler(this.btn_webgrabStart_Click);
            // 
            // btn_openPathSelector
            // 
            this.btn_openPathSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openPathSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openPathSelector.BackgroundImage = global::fapmap.Properties.Resources.treeView;
            this.btn_openPathSelector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_openPathSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_openPathSelector.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_openPathSelector.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openPathSelector.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openPathSelector.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openPathSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openPathSelector.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_openPathSelector.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_openPathSelector.Location = new System.Drawing.Point(815, 268);
            this.btn_openPathSelector.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openPathSelector.Name = "btn_openPathSelector";
            this.btn_openPathSelector.Size = new System.Drawing.Size(18, 18);
            this.btn_openPathSelector.TabIndex = 8;
            this.HelpBalloon.SetToolTip(this.btn_openPathSelector, "Select Folder");
            this.btn_openPathSelector.UseVisualStyleBackColor = false;
            this.btn_openPathSelector.Click += new System.EventHandler(this.btn_openPathSelector_Click);
            // 
            // btn_openURL
            // 
            this.btn_openURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openURL.BackgroundImage = global::fapmap.Properties.Resources.incognito;
            this.btn_openURL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_openURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_openURL.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_openURL.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openURL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openURL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openURL.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_openURL.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_openURL.Location = new System.Drawing.Point(815, 370);
            this.btn_openURL.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openURL.Name = "btn_openURL";
            this.btn_openURL.Size = new System.Drawing.Size(18, 18);
            this.btn_openURL.TabIndex = 22;
            this.HelpBalloon.SetToolTip(this.btn_openURL, "Open Last Downloaded URL");
            this.btn_openURL.UseVisualStyleBackColor = false;
            this.btn_openURL.Click += new System.EventHandler(this.btn_openURL_Click);
            // 
            // btn_selectFileInExplorer
            // 
            this.btn_selectFileInExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_selectFileInExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_selectFileInExplorer.BackgroundImage = global::fapmap.Properties.Resources.selectFolder;
            this.btn_selectFileInExplorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_selectFileInExplorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selectFileInExplorer.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_selectFileInExplorer.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_selectFileInExplorer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_selectFileInExplorer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_selectFileInExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selectFileInExplorer.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_selectFileInExplorer.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_selectFileInExplorer.Location = new System.Drawing.Point(795, 390);
            this.btn_selectFileInExplorer.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_selectFileInExplorer.Name = "btn_selectFileInExplorer";
            this.btn_selectFileInExplorer.Size = new System.Drawing.Size(18, 18);
            this.btn_selectFileInExplorer.TabIndex = 25;
            this.HelpBalloon.SetToolTip(this.btn_selectFileInExplorer, "Open Explorer and Select the File");
            this.btn_selectFileInExplorer.UseVisualStyleBackColor = false;
            this.btn_selectFileInExplorer.Click += new System.EventHandler(this.btn_selectFileInExplorer_Click);
            // 
            // btn_dragOutURL
            // 
            this.btn_dragOutURL.AllowDrop = true;
            this.btn_dragOutURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_dragOutURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_dragOutURL.BackgroundImage = global::fapmap.Properties.Resources.dragNdrop;
            this.btn_dragOutURL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_dragOutURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dragOutURL.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_dragOutURL.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_dragOutURL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_dragOutURL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_dragOutURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dragOutURL.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold);
            this.btn_dragOutURL.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_dragOutURL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_dragOutURL.Location = new System.Drawing.Point(11, 370);
            this.btn_dragOutURL.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_dragOutURL.Name = "btn_dragOutURL";
            this.btn_dragOutURL.Size = new System.Drawing.Size(18, 18);
            this.btn_dragOutURL.TabIndex = 20;
            this.HelpBalloon.SetToolTip(this.btn_dragOutURL, "Hold This Button to Drag Out the URL");
            this.btn_dragOutURL.UseVisualStyleBackColor = false;
            this.btn_dragOutURL.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_dragOutURL_DragOver);
            this.btn_dragOutURL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_dragOutURL_MouseDown);
            // 
            // btn_dragOutFilePath
            // 
            this.btn_dragOutFilePath.AllowDrop = true;
            this.btn_dragOutFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_dragOutFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_dragOutFilePath.BackgroundImage = global::fapmap.Properties.Resources.dragNdrop;
            this.btn_dragOutFilePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_dragOutFilePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dragOutFilePath.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_dragOutFilePath.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_dragOutFilePath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_dragOutFilePath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_dragOutFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dragOutFilePath.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold);
            this.btn_dragOutFilePath.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_dragOutFilePath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_dragOutFilePath.Location = new System.Drawing.Point(11, 390);
            this.btn_dragOutFilePath.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_dragOutFilePath.Name = "btn_dragOutFilePath";
            this.btn_dragOutFilePath.Size = new System.Drawing.Size(18, 18);
            this.btn_dragOutFilePath.TabIndex = 23;
            this.HelpBalloon.SetToolTip(this.btn_dragOutFilePath, "Hold This Button to Drag Out the File Path");
            this.btn_dragOutFilePath.UseVisualStyleBackColor = false;
            this.btn_dragOutFilePath.DragOver += new System.Windows.Forms.DragEventHandler(this.btn_dragOutFilePath_DragOver);
            this.btn_dragOutFilePath.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_dragOutFilePath_MouseDown);
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(7)))), ((int)(((byte)(15)))));
            this.info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.info.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.info.ForeColor = System.Drawing.Color.SpringGreen;
            this.info.Location = new System.Drawing.Point(0, 0);
            this.info.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.info.Multiline = true;
            this.info.Name = "info";
            this.info.ReadOnly = true;
            this.info.Size = new System.Drawing.Size(718, 48);
            this.info.TabIndex = 0;
            this.info.Text = "...";
            // 
            // links_RMB
            // 
            this.links_RMB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.links_RMB.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.links_RMB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.links_RMB_refresh,
            this.links_RMB_download,
            this.links_RMB_incognito,
            this.links_RMB_copy,
            this.links_RMB_cut,
            this.links_RMB_paste,
            this.links_RMB_delete,
            this.links_RMB_deleteAll,
            this.links_RMB_deleteSome});
            this.links_RMB.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.links_RMB.Name = "contextMenuStrip1";
            this.links_RMB.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.links_RMB.ShowItemToolTips = false;
            this.links_RMB.Size = new System.Drawing.Size(220, 202);
            // 
            // links_RMB_refresh
            // 
            this.links_RMB_refresh.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.links_RMB_refresh.Image = global::fapmap.Properties.Resources.refresh;
            this.links_RMB_refresh.Name = "links_RMB_refresh";
            this.links_RMB_refresh.Size = new System.Drawing.Size(219, 22);
            this.links_RMB_refresh.Text = "Refresh (CTRL+R/F5)";
            this.links_RMB_refresh.Click += new System.EventHandler(this.links_RMB_refresh_Click);
            // 
            // links_RMB_download
            // 
            this.links_RMB_download.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_download.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.links_RMB_download.Image = global::fapmap.Properties.Resources.downloadFile;
            this.links_RMB_download.Name = "links_RMB_download";
            this.links_RMB_download.Size = new System.Drawing.Size(219, 22);
            this.links_RMB_download.Text = "Download (ENTER)";
            this.links_RMB_download.Click += new System.EventHandler(this.links_RMB_download_Click);
            // 
            // links_RMB_incognito
            // 
            this.links_RMB_incognito.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_incognito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.links_RMB_incognito.Image = global::fapmap.Properties.Resources.incognito;
            this.links_RMB_incognito.Name = "links_RMB_incognito";
            this.links_RMB_incognito.Size = new System.Drawing.Size(219, 22);
            this.links_RMB_incognito.Text = "Incognito (CTRL+W)";
            this.links_RMB_incognito.Click += new System.EventHandler(this.links_RMB_incognito_Click);
            // 
            // links_RMB_copy
            // 
            this.links_RMB_copy.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_copy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.links_RMB_copy.Image = global::fapmap.Properties.Resources.copy;
            this.links_RMB_copy.Name = "links_RMB_copy";
            this.links_RMB_copy.Size = new System.Drawing.Size(219, 22);
            this.links_RMB_copy.Text = "Copy URL (CTRL+C)";
            this.links_RMB_copy.Click += new System.EventHandler(this.links_RMB_copy_Click);
            // 
            // links_RMB_cut
            // 
            this.links_RMB_cut.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_cut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.links_RMB_cut.Image = global::fapmap.Properties.Resources.cut;
            this.links_RMB_cut.Name = "links_RMB_cut";
            this.links_RMB_cut.Size = new System.Drawing.Size(219, 22);
            this.links_RMB_cut.Text = "Cut URL (CTRL+X)";
            this.links_RMB_cut.Click += new System.EventHandler(this.links_RMB_cut_Click);
            // 
            // links_RMB_paste
            // 
            this.links_RMB_paste.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_paste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.links_RMB_paste.Image = global::fapmap.Properties.Resources.paste;
            this.links_RMB_paste.Name = "links_RMB_paste";
            this.links_RMB_paste.Size = new System.Drawing.Size(219, 22);
            this.links_RMB_paste.Text = "Paste URL (CTRL+V)";
            this.links_RMB_paste.Click += new System.EventHandler(this.links_RMB_paste_Click);
            // 
            // links_RMB_delete
            // 
            this.links_RMB_delete.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.links_RMB_delete.Image = global::fapmap.Properties.Resources.delete;
            this.links_RMB_delete.Name = "links_RMB_delete";
            this.links_RMB_delete.Size = new System.Drawing.Size(219, 22);
            this.links_RMB_delete.Text = "Remove URL (DEL)";
            this.links_RMB_delete.Click += new System.EventHandler(this.links_RMB_delete_Click);
            // 
            // links_RMB_deleteAll
            // 
            this.links_RMB_deleteAll.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_deleteAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.links_RMB_deleteAll.Image = global::fapmap.Properties.Resources.delete;
            this.links_RMB_deleteAll.Name = "links_RMB_deleteAll";
            this.links_RMB_deleteAll.Size = new System.Drawing.Size(219, 22);
            this.links_RMB_deleteAll.Text = "Remove All URLs (CTRL+DEL)";
            this.links_RMB_deleteAll.Click += new System.EventHandler(this.links_RMB_deleteAll_Click);
            // 
            // links_RMB_deleteSome
            // 
            this.links_RMB_deleteSome.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_deleteSome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.links_RMB_deleteSome.Image = global::fapmap.Properties.Resources.delete;
            this.links_RMB_deleteSome.Name = "links_RMB_deleteSome";
            this.links_RMB_deleteSome.Size = new System.Drawing.Size(219, 22);
            this.links_RMB_deleteSome.Text = "Remove Only (SHIFT+DEL)";
            this.links_RMB_deleteSome.Click += new System.EventHandler(this.links_RMB_deleteSome_Click);
            // 
            // txt_url
            // 
            this.txt_url.AllowDrop = true;
            this.txt_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(7)))), ((int)(((byte)(15)))));
            this.txt_url.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_url.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.txt_url.ForeColor = System.Drawing.Color.SkyBlue;
            this.txt_url.Location = new System.Drawing.Point(1, 1);
            this.txt_url.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(800, 16);
            this.txt_url.TabIndex = 4;
            this.txt_url.TextChanged += new System.EventHandler(this.txt_url_TextChanged);
            this.txt_url.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_url_DragDrop);
            this.txt_url.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_url_DragEnter);
            this.txt_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_url_KeyDown);
            // 
            // txt_dledURL
            // 
            this.txt_dledURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_dledURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(7)))), ((int)(((byte)(15)))));
            this.txt_dledURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dledURL.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.txt_dledURL.ForeColor = System.Drawing.Color.SlateBlue;
            this.txt_dledURL.Location = new System.Drawing.Point(1, 1);
            this.txt_dledURL.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_dledURL.Name = "txt_dledURL";
            this.txt_dledURL.ReadOnly = true;
            this.txt_dledURL.Size = new System.Drawing.Size(780, 16);
            this.txt_dledURL.TabIndex = 21;
            this.txt_dledURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_dledURL_KeyDown);
            // 
            // txt_webgrabOptions
            // 
            this.txt_webgrabOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_webgrabOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(7)))), ((int)(((byte)(15)))));
            this.txt_webgrabOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_webgrabOptions.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.txt_webgrabOptions.ForeColor = System.Drawing.Color.Turquoise;
            this.txt_webgrabOptions.Location = new System.Drawing.Point(1, 1);
            this.txt_webgrabOptions.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_webgrabOptions.Name = "txt_webgrabOptions";
            this.txt_webgrabOptions.Size = new System.Drawing.Size(274, 16);
            this.txt_webgrabOptions.TabIndex = 2;
            this.txt_webgrabOptions.Text = "@agent,@valid,@media,@nodupes";
            this.txt_webgrabOptions.TextChanged += new System.EventHandler(this.txt_webgrabOptions_TextChanged);
            this.txt_webgrabOptions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_webgrabOptions_KeyDown);
            // 
            // txt_webgrabURL
            // 
            this.txt_webgrabURL.AllowDrop = true;
            this.txt_webgrabURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_webgrabURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(7)))), ((int)(((byte)(15)))));
            this.txt_webgrabURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_webgrabURL.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.txt_webgrabURL.ForeColor = System.Drawing.Color.SkyBlue;
            this.txt_webgrabURL.Location = new System.Drawing.Point(1, 1);
            this.txt_webgrabURL.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_webgrabURL.Name = "txt_webgrabURL";
            this.txt_webgrabURL.Size = new System.Drawing.Size(521, 16);
            this.txt_webgrabURL.TabIndex = 1;
            this.txt_webgrabURL.TextChanged += new System.EventHandler(this.txt_webgrabURL_TextChanged);
            this.txt_webgrabURL.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_webgrabURL_DragDrop);
            this.txt_webgrabURL.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_webgrabURL_DragEnter);
            this.txt_webgrabURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_webgrabURL_KeyDown);
            // 
            // panel_info
            // 
            this.panel_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_info.Controls.Add(this.info);
            this.panel_info.Controls.Add(this.pbar);
            this.panel_info.Location = new System.Drawing.Point(1, 1);
            this.panel_info.Name = "panel_info";
            this.panel_info.Size = new System.Drawing.Size(718, 58);
            this.panel_info.TabIndex = 163;
            // 
            // pbar
            // 
            this.pbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbar.ForeColor = System.Drawing.Color.SteelBlue;
            this.pbar.Location = new System.Drawing.Point(0, 48);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(718, 10);
            this.pbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbar.TabIndex = 0;
            this.pbar.Visible = false;
            // 
            // txt_dledPATH
            // 
            this.txt_dledPATH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_dledPATH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(7)))), ((int)(((byte)(15)))));
            this.txt_dledPATH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dledPATH.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.txt_dledPATH.ForeColor = System.Drawing.Color.SlateBlue;
            this.txt_dledPATH.Location = new System.Drawing.Point(1, 1);
            this.txt_dledPATH.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_dledPATH.Name = "txt_dledPATH";
            this.txt_dledPATH.ReadOnly = true;
            this.txt_dledPATH.Size = new System.Drawing.Size(760, 16);
            this.txt_dledPATH.TabIndex = 24;
            this.txt_dledPATH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_dledPATH_KeyDown);
            // 
            // txt_filename
            // 
            this.txt_filename.AllowDrop = true;
            this.txt_filename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_filename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(7)))), ((int)(((byte)(15)))));
            this.txt_filename.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_filename.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.txt_filename.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.txt_filename.Location = new System.Drawing.Point(1, 1);
            this.txt_filename.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_filename.Name = "txt_filename";
            this.txt_filename.ReadOnly = true;
            this.txt_filename.Size = new System.Drawing.Size(800, 16);
            this.txt_filename.TabIndex = 9;
            this.txt_filename.TextChanged += new System.EventHandler(this.txt_filename_TextChanged);
            this.txt_filename.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_filename_DragDrop);
            this.txt_filename.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_filename_DragEnter);
            this.txt_filename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_filename_KeyDown);
            // 
            // auto
            // 
            this.auto.Tick += new System.EventHandler(this.auto_Tick);
            // 
            // links
            // 
            this.links.AllowDrop = true;
            this.links.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.links.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(7)))), ((int)(((byte)(15)))));
            this.links.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.links.BackgroundImageTiled = true;
            this.links.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.links.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.links_clm_num,
            this.links_clm_name,
            this.links_clm_url});
            this.links.ContextMenuStrip = this.links_RMB;
            this.links.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.links.FullRowSelect = true;
            this.links.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.links.HideSelection = false;
            this.links.Location = new System.Drawing.Point(1, 1);
            this.links.MultiSelect = false;
            this.links.Name = "links";
            this.links.Size = new System.Drawing.Size(820, 210);
            this.links.TabIndex = 6;
            this.links.UseCompatibleStateImageBehavior = false;
            this.links.View = System.Windows.Forms.View.Details;
            this.links.SelectedIndexChanged += new System.EventHandler(this.links_SelectedIndexChanged);
            this.links.DragDrop += new System.Windows.Forms.DragEventHandler(this.links_DragDrop);
            this.links.DragEnter += new System.Windows.Forms.DragEventHandler(this.links_DragEnter);
            this.links.KeyDown += new System.Windows.Forms.KeyEventHandler(this.links_KeyDown);
            this.links.KeyUp += new System.Windows.Forms.KeyEventHandler(this.links_KeyUp);
            this.links.LostFocus += new System.EventHandler(this.links_LostFocus);
            this.links.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.links_MouseDoubleClick);
            this.links.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.links_MouseWheel);
            // 
            // links_clm_num
            // 
            this.links_clm_num.Text = "#";
            this.links_clm_num.Width = 18;
            // 
            // links_clm_name
            // 
            this.links_clm_name.Text = "NAME";
            this.links_clm_name.Width = 39;
            // 
            // links_clm_url
            // 
            this.links_clm_url.Text = "URL";
            this.links_clm_url.Width = 33;
            // 
            // txt_webgrabURL_border
            // 
            this.txt_webgrabURL_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_webgrabURL_border.Controls.Add(this.txt_webgrabURL);
            this.txt_webgrabURL_border.Location = new System.Drawing.Point(11, 12);
            this.txt_webgrabURL_border.Name = "txt_webgrabURL_border";
            this.txt_webgrabURL_border.Size = new System.Drawing.Size(523, 18);
            this.txt_webgrabURL_border.TabIndex = 164;
            // 
            // txt_webgrabOptions_border
            // 
            this.txt_webgrabOptions_border.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_webgrabOptions_border.Controls.Add(this.txt_webgrabOptions);
            this.txt_webgrabOptions_border.Location = new System.Drawing.Point(537, 12);
            this.txt_webgrabOptions_border.Name = "txt_webgrabOptions_border";
            this.txt_webgrabOptions_border.Size = new System.Drawing.Size(276, 18);
            this.txt_webgrabOptions_border.TabIndex = 165;
            // 
            // txt_url_border
            // 
            this.txt_url_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_url_border.Controls.Add(this.txt_url);
            this.txt_url_border.Location = new System.Drawing.Point(11, 33);
            this.txt_url_border.Name = "txt_url_border";
            this.txt_url_border.Size = new System.Drawing.Size(802, 18);
            this.txt_url_border.TabIndex = 166;
            // 
            // links_border
            // 
            this.links_border.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.links_border.Controls.Add(this.links);
            this.links_border.Location = new System.Drawing.Point(11, 54);
            this.links_border.Name = "links_border";
            this.links_border.Size = new System.Drawing.Size(822, 212);
            this.links_border.TabIndex = 167;
            // 
            // txt_dir_border
            // 
            this.txt_dir_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_dir_border.Controls.Add(this.txt_dir);
            this.txt_dir_border.Location = new System.Drawing.Point(11, 268);
            this.txt_dir_border.Name = "txt_dir_border";
            this.txt_dir_border.Size = new System.Drawing.Size(802, 18);
            this.txt_dir_border.TabIndex = 168;
            // 
            // txt_filename_border
            // 
            this.txt_filename_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_filename_border.Controls.Add(this.txt_filename);
            this.txt_filename_border.Location = new System.Drawing.Point(11, 288);
            this.txt_filename_border.Name = "txt_filename_border";
            this.txt_filename_border.Size = new System.Drawing.Size(802, 18);
            this.txt_filename_border.TabIndex = 169;
            // 
            // panel_info_border
            // 
            this.panel_info_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_info_border.Controls.Add(this.panel_info);
            this.panel_info_border.Location = new System.Drawing.Point(113, 308);
            this.panel_info_border.Name = "panel_info_border";
            this.panel_info_border.Size = new System.Drawing.Size(720, 60);
            this.panel_info_border.TabIndex = 170;
            // 
            // fapMapPanel1
            // 
            this.fapMapPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fapMapPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(7)))), ((int)(((byte)(15)))));
            this.fapMapPanel1.Controls.Add(this.cb_auto);
            this.fapMapPanel1.Controls.Add(this.rb_null);
            this.fapMapPanel1.Controls.Add(this.rb_shutdown);
            this.fapMapPanel1.Controls.Add(this.cb_conflict_skip);
            this.fapMapPanel1.Controls.Add(this.rb_exit);
            this.fapMapPanel1.Controls.Add(this.cb_conflict_rename);
            this.fapMapPanel1.Controls.Add(this.rb_close);
            this.fapMapPanel1.Controls.Add(this.cb_conflict_replace);
            this.fapMapPanel1.Controls.Add(this.cb_nonFile);
            this.fapMapPanel1.Controls.Add(this.label_linksCount);
            this.fapMapPanel1.Location = new System.Drawing.Point(11, 308);
            this.fapMapPanel1.Name = "fapMapPanel1";
            this.fapMapPanel1.Size = new System.Drawing.Size(100, 60);
            this.fapMapPanel1.TabIndex = 171;
            // 
            // txt_dledURL_border
            // 
            this.txt_dledURL_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_dledURL_border.Controls.Add(this.txt_dledURL);
            this.txt_dledURL_border.Location = new System.Drawing.Point(31, 370);
            this.txt_dledURL_border.Name = "txt_dledURL_border";
            this.txt_dledURL_border.Size = new System.Drawing.Size(782, 18);
            this.txt_dledURL_border.TabIndex = 172;
            // 
            // txt_dledPATH_border
            // 
            this.txt_dledPATH_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_dledPATH_border.Controls.Add(this.txt_dledPATH);
            this.txt_dledPATH_border.Location = new System.Drawing.Point(31, 390);
            this.txt_dledPATH_border.Name = "txt_dledPATH_border";
            this.txt_dledPATH_border.Size = new System.Drawing.Size(762, 18);
            this.txt_dledPATH_border.TabIndex = 173;
            // 
            // fapmap_download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(7)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(844, 421);
            this.Controls.Add(this.txt_dledPATH_border);
            this.Controls.Add(this.txt_dledURL_border);
            this.Controls.Add(this.fapMapPanel1);
            this.Controls.Add(this.panel_info_border);
            this.Controls.Add(this.txt_filename_border);
            this.Controls.Add(this.txt_dir_border);
            this.Controls.Add(this.links_border);
            this.Controls.Add(this.txt_url_border);
            this.Controls.Add(this.txt_webgrabOptions_border);
            this.Controls.Add(this.txt_webgrabURL_border);
            this.Controls.Add(this.btn_dragOutFilePath);
            this.Controls.Add(this.btn_dragOutURL);
            this.Controls.Add(this.btn_selectFileInExplorer);
            this.Controls.Add(this.btn_webgrabStart);
            this.Controls.Add(this.btn_openURL);
            this.Controls.Add(this.btn_openPathSelector);
            this.Controls.Add(this.btn_dl);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.btn_addURL);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.MediumPurple;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MinimumSize = new System.Drawing.Size(390, 320);
            this.Name = "fapmap_download";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - Downloader (+webgrab.exe)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fapmap_download_FormClosing);
            this.Load += new System.EventHandler(this.fapmap_download_Load);
            this.links_RMB.ResumeLayout(false);
            this.panel_info.ResumeLayout(false);
            this.panel_info.PerformLayout();
            this.txt_webgrabURL_border.ResumeLayout(false);
            this.txt_webgrabURL_border.PerformLayout();
            this.txt_webgrabOptions_border.ResumeLayout(false);
            this.txt_webgrabOptions_border.PerformLayout();
            this.txt_url_border.ResumeLayout(false);
            this.txt_url_border.PerformLayout();
            this.links_border.ResumeLayout(false);
            this.txt_dir_border.ResumeLayout(false);
            this.txt_dir_border.PerformLayout();
            this.txt_filename_border.ResumeLayout(false);
            this.txt_filename_border.PerformLayout();
            this.panel_info_border.ResumeLayout(false);
            this.fapMapPanel1.ResumeLayout(false);
            this.fapMapPanel1.PerformLayout();
            this.txt_dledURL_border.ResumeLayout(false);
            this.txt_dledURL_border.PerformLayout();
            this.txt_dledPATH_border.ResumeLayout(false);
            this.txt_dledPATH_border.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        private System.Windows.Forms.TextBox txt_dir;
        private System.Windows.Forms.Button btn_openFile;
        private System.Windows.Forms.Button btn_dl;
        private System.Windows.Forms.NotifyIcon this_trayicon;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.TextBox info;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Button btn_addURL;
        private System.Windows.Forms.TextBox txt_dledURL;
        private System.Windows.Forms.ContextMenuStrip links_RMB;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_copy;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_paste;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_delete;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_cut;
        private System.Windows.Forms.Button btn_webgrabStart;
        private System.Windows.Forms.TextBox txt_webgrabURL;
        private System.Windows.Forms.CheckBox cb_conflict_skip;
        private System.Windows.Forms.CheckBox cb_conflict_replace;
        private System.Windows.Forms.CheckBox cb_conflict_rename;
        private System.Windows.Forms.CheckBox cb_nonFile;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_deleteAll;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_deleteSome;
        private System.Windows.Forms.Label label_linksCount;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_refresh;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_incognito;
        private System.Windows.Forms.TextBox txt_webgrabOptions;
        private fapmap_res.FapMapListView links;
        private System.Windows.Forms.TextBox txt_filename;
        private System.Windows.Forms.TextBox txt_dledPATH;
        private System.Windows.Forms.RadioButton rb_shutdown;
        private System.Windows.Forms.RadioButton rb_exit;
        private System.Windows.Forms.RadioButton rb_close;
        private System.Windows.Forms.ColumnHeader links_clm_name;
        private System.Windows.Forms.ColumnHeader links_clm_num;
        private System.Windows.Forms.ColumnHeader links_clm_url;
        private System.Windows.Forms.RadioButton rb_null;
        private System.Windows.Forms.Button btn_openPathSelector;
        private System.Windows.Forms.Timer auto;
        private System.Windows.Forms.CheckBox cb_auto;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_download;
        private fapmap_res.FapMapProgressBar pbar;
        private System.Windows.Forms.Button btn_openURL;
        private System.Windows.Forms.Panel panel_info;
        private System.Windows.Forms.Button btn_selectFileInExplorer;
        private System.Windows.Forms.Button btn_dragOutURL;
        private System.Windows.Forms.Button btn_dragOutFilePath;
        private fapmap_res.FapMapPanel txt_webgrabURL_border;
        private fapmap_res.FapMapPanel txt_webgrabOptions_border;
        private fapmap_res.FapMapPanel txt_url_border;
        private fapmap_res.FapMapPanel links_border;
        private fapmap_res.FapMapPanel txt_dir_border;
        private fapmap_res.FapMapPanel txt_filename_border;
        private fapmap_res.FapMapPanel panel_info_border;
        private fapmap_res.FapMapPanel fapMapPanel1;
        private fapmap_res.FapMapPanel txt_dledURL_border;
        private fapmap_res.FapMapPanel txt_dledPATH_border;
    }
}