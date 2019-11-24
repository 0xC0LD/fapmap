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
            this.cb_panel = new System.Windows.Forms.Panel();
            this.cb_youtubedl = new System.Windows.Forms.CheckBox();
            this.rb_shutdown = new System.Windows.Forms.RadioButton();
            this.rb_exit = new System.Windows.Forms.RadioButton();
            this.rb_close = new System.Windows.Forms.RadioButton();
            this.rb_null = new System.Windows.Forms.RadioButton();
            this.links_count = new System.Windows.Forms.Label();
            this.cb_webgrab = new System.Windows.Forms.CheckBox();
            this.cb_nonFile = new System.Windows.Forms.CheckBox();
            this.cb_conflict_replace = new System.Windows.Forms.CheckBox();
            this.cb_conflict_rename = new System.Windows.Forms.CheckBox();
            this.cb_conflict_skip = new System.Windows.Forms.CheckBox();
            this.cb_uncheckAuto = new System.Windows.Forms.CheckBox();
            this.cb_auto_dl = new System.Windows.Forms.CheckBox();
            this.cb_auto_clip = new System.Windows.Forms.CheckBox();
            this.cb_auto = new System.Windows.Forms.CheckBox();
            this.file_location = new System.Windows.Forms.TextBox();
            this.file_open = new System.Windows.Forms.Button();
            this.links_dl = new System.Windows.Forms.Button();
            this.SystemTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.links_append = new System.Windows.Forms.Button();
            this.webgrab_start = new System.Windows.Forms.Button();
            this.youtubedl_start = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.TextBox();
            this.links_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.links_RMB_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_incognito = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_cut = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_paste = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_deleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.links_RMB_deleteSome = new System.Windows.Forms.ToolStripMenuItem();
            this.links_url = new System.Windows.Forms.TextBox();
            this.process_url = new System.Windows.Forms.TextBox();
            this.webgrab_panel = new System.Windows.Forms.Panel();
            this.webgrab_options = new System.Windows.Forms.TextBox();
            this.webgrab_url = new System.Windows.Forms.TextBox();
            this.sc_webgrab = new System.Windows.Forms.SplitContainer();
            this.sc_youtubedl = new System.Windows.Forms.SplitContainer();
            this.youtubedl_url = new System.Windows.Forms.TextBox();
            this.info_panel = new System.Windows.Forms.Panel();
            this.speed_echo = new System.Windows.Forms.Label();
            this.info_progress = new System.Windows.Forms.PictureBox();
            this.filename_changeBox = new System.Windows.Forms.TextBox();
            this.process_location = new System.Windows.Forms.TextBox();
            this.links = new System.Windows.Forms.ListView();
            this.links_clm_num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.links_clm_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.links_clm_url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.auto = new System.Windows.Forms.Timer(this.components);
            this.speed = new System.Windows.Forms.Timer(this.components);
            this.cb_panel.SuspendLayout();
            this.links_RMB.SuspendLayout();
            this.webgrab_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_webgrab)).BeginInit();
            this.sc_webgrab.Panel1.SuspendLayout();
            this.sc_webgrab.Panel2.SuspendLayout();
            this.sc_webgrab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_youtubedl)).BeginInit();
            this.sc_youtubedl.Panel1.SuspendLayout();
            this.sc_youtubedl.Panel2.SuspendLayout();
            this.sc_youtubedl.SuspendLayout();
            this.info_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.info_progress)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_panel
            // 
            this.cb_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_panel.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.cb_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cb_panel.Controls.Add(this.cb_youtubedl);
            this.cb_panel.Controls.Add(this.rb_shutdown);
            this.cb_panel.Controls.Add(this.rb_exit);
            this.cb_panel.Controls.Add(this.rb_close);
            this.cb_panel.Controls.Add(this.rb_null);
            this.cb_panel.Controls.Add(this.links_count);
            this.cb_panel.Controls.Add(this.cb_webgrab);
            this.cb_panel.Controls.Add(this.cb_nonFile);
            this.cb_panel.Controls.Add(this.cb_conflict_replace);
            this.cb_panel.Controls.Add(this.cb_conflict_rename);
            this.cb_panel.Controls.Add(this.cb_conflict_skip);
            this.cb_panel.Controls.Add(this.cb_uncheckAuto);
            this.cb_panel.Controls.Add(this.cb_auto_dl);
            this.cb_panel.Controls.Add(this.cb_auto_clip);
            this.cb_panel.Controls.Add(this.cb_auto);
            this.cb_panel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cb_panel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_panel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_panel.Location = new System.Drawing.Point(2, 174);
            this.cb_panel.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_panel.Name = "cb_panel";
            this.cb_panel.Size = new System.Drawing.Size(165, 72);
            this.cb_panel.TabIndex = 23;
            // 
            // cb_youtubedl
            // 
            this.cb_youtubedl.AutoSize = true;
            this.cb_youtubedl.BackColor = System.Drawing.Color.Transparent;
            this.cb_youtubedl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_youtubedl.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_youtubedl.ForeColor = System.Drawing.Color.Teal;
            this.cb_youtubedl.Location = new System.Drawing.Point(4, 38);
            this.cb_youtubedl.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_youtubedl.Name = "cb_youtubedl";
            this.cb_youtubedl.Size = new System.Drawing.Size(50, 17);
            this.cb_youtubedl.TabIndex = 54;
            this.cb_youtubedl.Text = "SPYD";
            this.HelpBalloon.SetToolTip(this.cb_youtubedl, "Show panel: youtube-dl.exe");
            this.cb_youtubedl.UseVisualStyleBackColor = false;
            this.cb_youtubedl.CheckedChanged += new System.EventHandler(this.cb_youtubedl_CheckedChanged);
            // 
            // rb_shutdown
            // 
            this.rb_shutdown.AutoSize = true;
            this.rb_shutdown.BackColor = System.Drawing.Color.Transparent;
            this.rb_shutdown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_shutdown.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb_shutdown.ForeColor = System.Drawing.Color.Teal;
            this.rb_shutdown.Location = new System.Drawing.Point(106, 49);
            this.rb_shutdown.Name = "rb_shutdown";
            this.rb_shutdown.Size = new System.Drawing.Size(41, 19);
            this.rb_shutdown.TabIndex = 52;
            this.rb_shutdown.Text = "Off";
            this.HelpBalloon.SetToolTip(this.rb_shutdown, "Shutdown PC... After all downloads have finished / After yotube-dl.exe has finish" +
        "ed");
            this.rb_shutdown.UseCompatibleTextRendering = true;
            this.rb_shutdown.UseVisualStyleBackColor = false;
            // 
            // rb_exit
            // 
            this.rb_exit.AutoSize = true;
            this.rb_exit.BackColor = System.Drawing.Color.Transparent;
            this.rb_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_exit.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb_exit.ForeColor = System.Drawing.Color.Teal;
            this.rb_exit.Location = new System.Drawing.Point(106, 33);
            this.rb_exit.Name = "rb_exit";
            this.rb_exit.Size = new System.Drawing.Size(47, 19);
            this.rb_exit.TabIndex = 51;
            this.rb_exit.Text = "Exit";
            this.HelpBalloon.SetToolTip(this.rb_exit, "Exit FapMap... After all downloads have finished / After yotube-dl.exe has finish" +
        "ed");
            this.rb_exit.UseCompatibleTextRendering = true;
            this.rb_exit.UseVisualStyleBackColor = false;
            // 
            // rb_close
            // 
            this.rb_close.AutoSize = true;
            this.rb_close.BackColor = System.Drawing.Color.Transparent;
            this.rb_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_close.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb_close.ForeColor = System.Drawing.Color.Teal;
            this.rb_close.Location = new System.Drawing.Point(106, 16);
            this.rb_close.Name = "rb_close";
            this.rb_close.Size = new System.Drawing.Size(53, 19);
            this.rb_close.TabIndex = 50;
            this.rb_close.Text = "Close";
            this.HelpBalloon.SetToolTip(this.rb_close, "Close downloader... After all downloads have finished / After yotube-dl.exe has f" +
        "inished");
            this.rb_close.UseCompatibleTextRendering = true;
            this.rb_close.UseVisualStyleBackColor = false;
            // 
            // rb_null
            // 
            this.rb_null.AutoSize = true;
            this.rb_null.BackColor = System.Drawing.Color.Transparent;
            this.rb_null.Checked = true;
            this.rb_null.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_null.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb_null.ForeColor = System.Drawing.Color.Teal;
            this.rb_null.Location = new System.Drawing.Point(106, 0);
            this.rb_null.Name = "rb_null";
            this.rb_null.Size = new System.Drawing.Size(41, 19);
            this.rb_null.TabIndex = 53;
            this.rb_null.TabStop = true;
            this.rb_null.Text = "...";
            this.HelpBalloon.SetToolTip(this.rb_null, "Do nothing... After all downloads have finished / After yotube-dl.exe has finishe" +
        "d");
            this.rb_null.UseCompatibleTextRendering = true;
            this.rb_null.UseVisualStyleBackColor = false;
            // 
            // links_count
            // 
            this.links_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.links_count.AutoSize = true;
            this.links_count.BackColor = System.Drawing.Color.Transparent;
            this.links_count.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.links_count.ForeColor = System.Drawing.Color.Teal;
            this.links_count.Location = new System.Drawing.Point(1, 55);
            this.links_count.Name = "links_count";
            this.links_count.Size = new System.Drawing.Size(14, 14);
            this.links_count.TabIndex = 39;
            this.links_count.Text = "0";
            // 
            // cb_webgrab
            // 
            this.cb_webgrab.AutoSize = true;
            this.cb_webgrab.BackColor = System.Drawing.Color.Transparent;
            this.cb_webgrab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_webgrab.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_webgrab.ForeColor = System.Drawing.Color.Teal;
            this.cb_webgrab.Location = new System.Drawing.Point(4, 21);
            this.cb_webgrab.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_webgrab.Name = "cb_webgrab";
            this.cb_webgrab.Size = new System.Drawing.Size(50, 17);
            this.cb_webgrab.TabIndex = 45;
            this.cb_webgrab.Text = "SPWG";
            this.HelpBalloon.SetToolTip(this.cb_webgrab, "Show panel: webgrab.exe");
            this.cb_webgrab.UseVisualStyleBackColor = false;
            this.cb_webgrab.CheckedChanged += new System.EventHandler(this.cb_webgrab_CheckedChanged);
            // 
            // cb_nonFile
            // 
            this.cb_nonFile.AutoSize = true;
            this.cb_nonFile.BackColor = System.Drawing.Color.Transparent;
            this.cb_nonFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_nonFile.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_nonFile.ForeColor = System.Drawing.Color.Teal;
            this.cb_nonFile.Location = new System.Drawing.Point(55, 21);
            this.cb_nonFile.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_nonFile.Name = "cb_nonFile";
            this.cb_nonFile.Size = new System.Drawing.Size(50, 17);
            this.cb_nonFile.TabIndex = 44;
            this.cb_nonFile.Text = "ANFU";
            this.HelpBalloon.SetToolTip(this.cb_nonFile, "Add non-file urls (may crash application)");
            this.cb_nonFile.UseVisualStyleBackColor = false;
            // 
            // cb_conflict_replace
            // 
            this.cb_conflict_replace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_conflict_replace.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_conflict_replace.AutoSize = true;
            this.cb_conflict_replace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_conflict_replace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_conflict_replace.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.cb_conflict_replace.FlatAppearance.CheckedBackColor = System.Drawing.Color.SlateBlue;
            this.cb_conflict_replace.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.cb_conflict_replace.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SlateBlue;
            this.cb_conflict_replace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_conflict_replace.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_conflict_replace.ForeColor = System.Drawing.Color.YellowGreen;
            this.cb_conflict_replace.Location = new System.Drawing.Point(156, 56);
            this.cb_conflict_replace.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_conflict_replace.Name = "cb_conflict_replace";
            this.cb_conflict_replace.Size = new System.Drawing.Size(6, 6);
            this.cb_conflict_replace.TabIndex = 43;
            this.HelpBalloon.SetToolTip(this.cb_conflict_replace, "Automatically replace file, if file exists...");
            this.cb_conflict_replace.UseVisualStyleBackColor = false;
            this.cb_conflict_replace.CheckedChanged += new System.EventHandler(this.cb_replace_CheckedChanged);
            // 
            // cb_conflict_rename
            // 
            this.cb_conflict_rename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_conflict_rename.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_conflict_rename.AutoSize = true;
            this.cb_conflict_rename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_conflict_rename.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_conflict_rename.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.cb_conflict_rename.FlatAppearance.CheckedBackColor = System.Drawing.Color.SlateBlue;
            this.cb_conflict_rename.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.cb_conflict_rename.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SlateBlue;
            this.cb_conflict_rename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_conflict_rename.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_conflict_rename.ForeColor = System.Drawing.Color.YellowGreen;
            this.cb_conflict_rename.Location = new System.Drawing.Point(156, 63);
            this.cb_conflict_rename.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_conflict_rename.Name = "cb_conflict_rename";
            this.cb_conflict_rename.Size = new System.Drawing.Size(6, 6);
            this.cb_conflict_rename.TabIndex = 42;
            this.HelpBalloon.SetToolTip(this.cb_conflict_rename, "Automatically rename file, if file exists...");
            this.cb_conflict_rename.UseVisualStyleBackColor = false;
            this.cb_conflict_rename.CheckedChanged += new System.EventHandler(this.cb_rename_CheckedChanged);
            // 
            // cb_conflict_skip
            // 
            this.cb_conflict_skip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_conflict_skip.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_conflict_skip.AutoSize = true;
            this.cb_conflict_skip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_conflict_skip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_conflict_skip.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.cb_conflict_skip.FlatAppearance.CheckedBackColor = System.Drawing.Color.SlateBlue;
            this.cb_conflict_skip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
            this.cb_conflict_skip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SlateBlue;
            this.cb_conflict_skip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_conflict_skip.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_conflict_skip.ForeColor = System.Drawing.Color.YellowGreen;
            this.cb_conflict_skip.Location = new System.Drawing.Point(156, 49);
            this.cb_conflict_skip.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_conflict_skip.Name = "cb_conflict_skip";
            this.cb_conflict_skip.Size = new System.Drawing.Size(6, 6);
            this.cb_conflict_skip.TabIndex = 41;
            this.HelpBalloon.SetToolTip(this.cb_conflict_skip, "Automatically skip URL, if file exists...");
            this.cb_conflict_skip.UseVisualStyleBackColor = false;
            this.cb_conflict_skip.CheckedChanged += new System.EventHandler(this.cb_skip_CheckedChanged);
            // 
            // cb_uncheckAuto
            // 
            this.cb_uncheckAuto.AutoSize = true;
            this.cb_uncheckAuto.BackColor = System.Drawing.Color.Transparent;
            this.cb_uncheckAuto.Checked = true;
            this.cb_uncheckAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_uncheckAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_uncheckAuto.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_uncheckAuto.ForeColor = System.Drawing.Color.Teal;
            this.cb_uncheckAuto.Location = new System.Drawing.Point(87, 4);
            this.cb_uncheckAuto.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_uncheckAuto.Name = "cb_uncheckAuto";
            this.cb_uncheckAuto.Size = new System.Drawing.Size(15, 14);
            this.cb_uncheckAuto.TabIndex = 40;
            this.HelpBalloon.SetToolTip(this.cb_uncheckAuto, "After all downloads have finished, uncheck auto");
            this.cb_uncheckAuto.UseVisualStyleBackColor = false;
            // 
            // cb_auto_dl
            // 
            this.cb_auto_dl.AutoSize = true;
            this.cb_auto_dl.BackColor = System.Drawing.Color.Transparent;
            this.cb_auto_dl.Checked = true;
            this.cb_auto_dl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_auto_dl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_auto_dl.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_auto_dl.ForeColor = System.Drawing.Color.Teal;
            this.cb_auto_dl.Location = new System.Drawing.Point(55, 4);
            this.cb_auto_dl.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_auto_dl.Name = "cb_auto_dl";
            this.cb_auto_dl.Size = new System.Drawing.Size(15, 14);
            this.cb_auto_dl.TabIndex = 36;
            this.HelpBalloon.SetToolTip(this.cb_auto_dl, "Download every link from download list");
            this.cb_auto_dl.UseVisualStyleBackColor = false;
            // 
            // cb_auto_clip
            // 
            this.cb_auto_clip.AutoSize = true;
            this.cb_auto_clip.BackColor = System.Drawing.Color.Transparent;
            this.cb_auto_clip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_auto_clip.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_auto_clip.ForeColor = System.Drawing.Color.Teal;
            this.cb_auto_clip.Location = new System.Drawing.Point(71, 4);
            this.cb_auto_clip.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_auto_clip.Name = "cb_auto_clip";
            this.cb_auto_clip.Size = new System.Drawing.Size(15, 14);
            this.cb_auto_clip.TabIndex = 34;
            this.HelpBalloon.SetToolTip(this.cb_auto_clip, "Add every link that is copied to download list");
            this.cb_auto_clip.UseVisualStyleBackColor = false;
            // 
            // cb_auto
            // 
            this.cb_auto.AutoSize = true;
            this.cb_auto.BackColor = System.Drawing.Color.Transparent;
            this.cb_auto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_auto.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_auto.ForeColor = System.Drawing.Color.Teal;
            this.cb_auto.Location = new System.Drawing.Point(4, 4);
            this.cb_auto.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_auto.Name = "cb_auto";
            this.cb_auto.Size = new System.Drawing.Size(56, 17);
            this.cb_auto.TabIndex = 31;
            this.cb_auto.Text = "Auto:";
            this.HelpBalloon.SetToolTip(this.cb_auto, "Automatically...");
            this.cb_auto.UseVisualStyleBackColor = false;
            this.cb_auto.CheckedChanged += new System.EventHandler(this.auto_CheckedChanged);
            // 
            // file_location
            // 
            this.file_location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.file_location.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.file_location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.file_location.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.file_location.ForeColor = System.Drawing.Color.SlateBlue;
            this.file_location.Location = new System.Drawing.Point(2, 130);
            this.file_location.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.file_location.Name = "file_location";
            this.file_location.Size = new System.Drawing.Size(480, 20);
            this.file_location.TabIndex = 21;
            this.file_location.TextChanged += new System.EventHandler(this.file_location_TextChanged);
            this.file_location.KeyDown += new System.Windows.Forms.KeyEventHandler(this.file_location_KeyDown);
            // 
            // file_open
            // 
            this.file_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.file_open.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.file_open.BackgroundImage = global::fapmap.Properties.Resources.open;
            this.file_open.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.file_open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.file_open.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.file_open.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.file_open.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.file_open.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.file_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.file_open.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.file_open.ForeColor = System.Drawing.Color.DimGray;
            this.file_open.Location = new System.Drawing.Point(462, 152);
            this.file_open.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.file_open.Name = "file_open";
            this.file_open.Size = new System.Drawing.Size(20, 20);
            this.file_open.TabIndex = 25;
            this.HelpBalloon.SetToolTip(this.file_open, "Open last downloaded file");
            this.file_open.UseVisualStyleBackColor = false;
            this.file_open.Click += new System.EventHandler(this.open_Click);
            // 
            // links_dl
            // 
            this.links_dl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.links_dl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.links_dl.BackgroundImage = global::fapmap.Properties.Resources.download;
            this.links_dl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.links_dl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.links_dl.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.links_dl.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.links_dl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.links_dl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.links_dl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.links_dl.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.links_dl.ForeColor = System.Drawing.Color.DimGray;
            this.links_dl.Location = new System.Drawing.Point(440, 152);
            this.links_dl.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.links_dl.Name = "links_dl";
            this.links_dl.Size = new System.Drawing.Size(20, 20);
            this.links_dl.TabIndex = 24;
            this.HelpBalloon.SetToolTip(this.links_dl, "Download/Cancel download");
            this.links_dl.UseVisualStyleBackColor = false;
            this.links_dl.Click += new System.EventHandler(this.download_Click);
            // 
            // SystemTrayIcon
            // 
            this.SystemTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("SystemTrayIcon.Icon")));
            this.SystemTrayIcon.Visible = true;
            this.SystemTrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SystemTrayIcon_MouseClick);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.SlateBlue;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_Draw);
            // 
            // links_append
            // 
            this.links_append.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.links_append.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.links_append.BackgroundImage = global::fapmap.Properties.Resources.arrow_down;
            this.links_append.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.links_append.Cursor = System.Windows.Forms.Cursors.Hand;
            this.links_append.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.links_append.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.links_append.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.links_append.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.links_append.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.links_append.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.links_append.ForeColor = System.Drawing.Color.DimGray;
            this.links_append.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.links_append.Location = new System.Drawing.Point(462, 2);
            this.links_append.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.links_append.Name = "links_append";
            this.links_append.Size = new System.Drawing.Size(20, 20);
            this.links_append.TabIndex = 152;
            this.HelpBalloon.SetToolTip(this.links_append, "Add file url to download list");
            this.links_append.UseVisualStyleBackColor = false;
            this.links_append.Click += new System.EventHandler(this.appendLink_Click);
            // 
            // webgrab_start
            // 
            this.webgrab_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.webgrab_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.webgrab_start.BackgroundImage = global::fapmap.Properties.Resources.arrow_left;
            this.webgrab_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.webgrab_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.webgrab_start.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.webgrab_start.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.webgrab_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.webgrab_start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.webgrab_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.webgrab_start.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.webgrab_start.ForeColor = System.Drawing.Color.DimGray;
            this.webgrab_start.Location = new System.Drawing.Point(462, 2);
            this.webgrab_start.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.webgrab_start.Name = "webgrab_start";
            this.webgrab_start.Size = new System.Drawing.Size(20, 20);
            this.webgrab_start.TabIndex = 153;
            this.HelpBalloon.SetToolTip(this.webgrab_start, "Scan webpage with webgrab.exe");
            this.webgrab_start.UseVisualStyleBackColor = false;
            this.webgrab_start.Click += new System.EventHandler(this.webgrab_start_Click);
            // 
            // youtubedl_start
            // 
            this.youtubedl_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.youtubedl_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.youtubedl_start.BackgroundImage = global::fapmap.Properties.Resources.arrow_left;
            this.youtubedl_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.youtubedl_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.youtubedl_start.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.youtubedl_start.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.youtubedl_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.youtubedl_start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.youtubedl_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.youtubedl_start.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.youtubedl_start.ForeColor = System.Drawing.Color.DimGray;
            this.youtubedl_start.Location = new System.Drawing.Point(462, 2);
            this.youtubedl_start.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.youtubedl_start.Name = "youtubedl_start";
            this.youtubedl_start.Size = new System.Drawing.Size(20, 20);
            this.youtubedl_start.TabIndex = 159;
            this.HelpBalloon.SetToolTip(this.youtubedl_start, "Download video with youtube-dl.exe");
            this.youtubedl_start.UseVisualStyleBackColor = false;
            this.youtubedl_start.Click += new System.EventHandler(this.youtubedl_start_Click);
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.info.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.info.ForeColor = System.Drawing.Color.Teal;
            this.info.Location = new System.Drawing.Point(0, 0);
            this.info.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.info.Multiline = true;
            this.info.Name = "info";
            this.info.ReadOnly = true;
            this.info.Size = new System.Drawing.Size(310, 58);
            this.info.TabIndex = 31;
            this.info.Text = "...";
            this.info.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.info_MouseDoubleClick);
            // 
            // links_RMB
            // 
            this.links_RMB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.links_RMB.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.links_RMB_refresh,
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
            this.links_RMB.Size = new System.Drawing.Size(230, 180);
            // 
            // links_RMB_refresh
            // 
            this.links_RMB_refresh.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_refresh.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_refresh.Image = global::fapmap.Properties.Resources.restart;
            this.links_RMB_refresh.Name = "links_RMB_refresh";
            this.links_RMB_refresh.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_refresh.Text = "Refresh (CTRL+R/F5)";
            this.links_RMB_refresh.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // links_RMB_incognito
            // 
            this.links_RMB_incognito.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_incognito.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_incognito.Image = global::fapmap.Properties.Resources.incognito;
            this.links_RMB_incognito.Name = "links_RMB_incognito";
            this.links_RMB_incognito.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_incognito.Text = "Incognito (CTRL+U)";
            this.links_RMB_incognito.Click += new System.EventHandler(this.incognitoENTERToolStripMenuItem_Click);
            // 
            // links_RMB_copy
            // 
            this.links_RMB_copy.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_copy.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_copy.Image = global::fapmap.Properties.Resources.copy;
            this.links_RMB_copy.Name = "links_RMB_copy";
            this.links_RMB_copy.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_copy.Text = "Copy URL (CTRL+C)";
            this.links_RMB_copy.Click += new System.EventHandler(this.copyLinksToolStripMenuItem_Click);
            // 
            // links_RMB_cut
            // 
            this.links_RMB_cut.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_cut.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_cut.Image = global::fapmap.Properties.Resources.cut;
            this.links_RMB_cut.Name = "links_RMB_cut";
            this.links_RMB_cut.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_cut.Text = "Cut URL (CTRL+X)";
            this.links_RMB_cut.Click += new System.EventHandler(this.cutLinksToolStripMenuItem_Click);
            // 
            // links_RMB_paste
            // 
            this.links_RMB_paste.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_paste.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_paste.Image = global::fapmap.Properties.Resources.paste;
            this.links_RMB_paste.Name = "links_RMB_paste";
            this.links_RMB_paste.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_paste.Text = "Paste URL (CTRL+V)";
            this.links_RMB_paste.Click += new System.EventHandler(this.pasteFromClipBoardCTRLVToolStripMenuItem_Click);
            // 
            // links_RMB_delete
            // 
            this.links_RMB_delete.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_delete.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_delete.Image = global::fapmap.Properties.Resources.delete;
            this.links_RMB_delete.Name = "links_RMB_delete";
            this.links_RMB_delete.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_delete.Text = "Remove URL (DEL)";
            this.links_RMB_delete.Click += new System.EventHandler(this.deleteSelectedLinkDELToolStripMenuItem_Click);
            // 
            // links_RMB_deleteAll
            // 
            this.links_RMB_deleteAll.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_deleteAll.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_deleteAll.Image = global::fapmap.Properties.Resources.delete;
            this.links_RMB_deleteAll.Name = "links_RMB_deleteAll";
            this.links_RMB_deleteAll.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_deleteAll.Text = "Remove All URLs (CTRL+DEL)";
            this.links_RMB_deleteAll.Click += new System.EventHandler(this.deleteAllURLsCTRLADELToolStripMenuItem_Click);
            // 
            // links_RMB_deleteSome
            // 
            this.links_RMB_deleteSome.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_deleteSome.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_deleteSome.Image = global::fapmap.Properties.Resources.delete;
            this.links_RMB_deleteSome.Name = "links_RMB_deleteSome";
            this.links_RMB_deleteSome.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_deleteSome.Text = "Remove Only (SHIFT+DEL)";
            this.links_RMB_deleteSome.Click += new System.EventHandler(this.removeOnlySHIFTDELToolStripMenuItem_Click);
            // 
            // links_url
            // 
            this.links_url.AllowDrop = true;
            this.links_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.links_url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.links_url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.links_url.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.links_url.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.links_url.Location = new System.Drawing.Point(2, 2);
            this.links_url.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.links_url.Name = "links_url";
            this.links_url.Size = new System.Drawing.Size(458, 20);
            this.links_url.TabIndex = 151;
            this.links_url.DragDrop += new System.Windows.Forms.DragEventHandler(this.links_url_DragDrop);
            this.links_url.DragEnter += new System.Windows.Forms.DragEventHandler(this.links_url_DragEnter);
            this.links_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.linkText_KeyDown);
            // 
            // process_url
            // 
            this.process_url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.process_url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.process_url.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.process_url.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.process_url.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.process_url.Location = new System.Drawing.Point(0, 250);
            this.process_url.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.process_url.Name = "process_url";
            this.process_url.ReadOnly = true;
            this.process_url.Size = new System.Drawing.Size(484, 20);
            this.process_url.TabIndex = 153;
            this.process_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DownloadingLink_KeyDown);
            // 
            // webgrab_panel
            // 
            this.webgrab_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.webgrab_panel.Controls.Add(this.webgrab_options);
            this.webgrab_panel.Controls.Add(this.webgrab_start);
            this.webgrab_panel.Controls.Add(this.webgrab_url);
            this.webgrab_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webgrab_panel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.webgrab_panel.Location = new System.Drawing.Point(0, 0);
            this.webgrab_panel.Name = "webgrab_panel";
            this.webgrab_panel.Size = new System.Drawing.Size(484, 25);
            this.webgrab_panel.TabIndex = 154;
            // 
            // webgrab_options
            // 
            this.webgrab_options.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.webgrab_options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.webgrab_options.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webgrab_options.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.webgrab_options.ForeColor = System.Drawing.Color.Teal;
            this.webgrab_options.Location = new System.Drawing.Point(151, 2);
            this.webgrab_options.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.webgrab_options.Name = "webgrab_options";
            this.webgrab_options.Size = new System.Drawing.Size(309, 20);
            this.webgrab_options.TabIndex = 157;
            this.webgrab_options.Text = "@agent,@valid,@media,@nodupes";
            this.webgrab_options.KeyDown += new System.Windows.Forms.KeyEventHandler(this.webgrab_options_KeyDown);
            // 
            // webgrab_url
            // 
            this.webgrab_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webgrab_url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.webgrab_url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webgrab_url.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.webgrab_url.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.webgrab_url.Location = new System.Drawing.Point(2, 2);
            this.webgrab_url.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.webgrab_url.Name = "webgrab_url";
            this.webgrab_url.Size = new System.Drawing.Size(145, 20);
            this.webgrab_url.TabIndex = 152;
            this.webgrab_url.TextChanged += new System.EventHandler(this.webgrab_url_TextChanged);
            this.webgrab_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.webgrab_url_KeyDown);
            // 
            // sc_webgrab
            // 
            this.sc_webgrab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.sc_webgrab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_webgrab.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sc_webgrab.IsSplitterFixed = true;
            this.sc_webgrab.Location = new System.Drawing.Point(0, 0);
            this.sc_webgrab.Name = "sc_webgrab";
            this.sc_webgrab.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc_webgrab.Panel1
            // 
            this.sc_webgrab.Panel1.Controls.Add(this.webgrab_panel);
            // 
            // sc_webgrab.Panel2
            // 
            this.sc_webgrab.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.sc_webgrab.Panel2.Controls.Add(this.sc_youtubedl);
            this.sc_webgrab.Size = new System.Drawing.Size(484, 342);
            this.sc_webgrab.SplitterDistance = 25;
            this.sc_webgrab.SplitterWidth = 1;
            this.sc_webgrab.TabIndex = 155;
            // 
            // sc_youtubedl
            // 
            this.sc_youtubedl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_youtubedl.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sc_youtubedl.IsSplitterFixed = true;
            this.sc_youtubedl.Location = new System.Drawing.Point(0, 0);
            this.sc_youtubedl.Name = "sc_youtubedl";
            this.sc_youtubedl.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc_youtubedl.Panel1
            // 
            this.sc_youtubedl.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.sc_youtubedl.Panel1.Controls.Add(this.youtubedl_start);
            this.sc_youtubedl.Panel1.Controls.Add(this.youtubedl_url);
            // 
            // sc_youtubedl.Panel2
            // 
            this.sc_youtubedl.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.sc_youtubedl.Panel2.Controls.Add(this.info_panel);
            this.sc_youtubedl.Panel2.Controls.Add(this.cb_panel);
            this.sc_youtubedl.Panel2.Controls.Add(this.process_url);
            this.sc_youtubedl.Panel2.Controls.Add(this.filename_changeBox);
            this.sc_youtubedl.Panel2.Controls.Add(this.process_location);
            this.sc_youtubedl.Panel2.Controls.Add(this.links_url);
            this.sc_youtubedl.Panel2.Controls.Add(this.links_dl);
            this.sc_youtubedl.Panel2.Controls.Add(this.links);
            this.sc_youtubedl.Panel2.Controls.Add(this.links_append);
            this.sc_youtubedl.Panel2.Controls.Add(this.file_open);
            this.sc_youtubedl.Panel2.Controls.Add(this.file_location);
            this.sc_youtubedl.Size = new System.Drawing.Size(484, 316);
            this.sc_youtubedl.SplitterDistance = 25;
            this.sc_youtubedl.SplitterWidth = 1;
            this.sc_youtubedl.TabIndex = 156;
            // 
            // youtubedl_url
            // 
            this.youtubedl_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.youtubedl_url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.youtubedl_url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.youtubedl_url.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.youtubedl_url.ForeColor = System.Drawing.Color.SteelBlue;
            this.youtubedl_url.Location = new System.Drawing.Point(2, 2);
            this.youtubedl_url.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.youtubedl_url.Name = "youtubedl_url";
            this.youtubedl_url.Size = new System.Drawing.Size(458, 20);
            this.youtubedl_url.TabIndex = 158;
            this.youtubedl_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.youtubedl_url_KeyDown);
            // 
            // info_panel
            // 
            this.info_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.info_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_panel.Controls.Add(this.speed_echo);
            this.info_panel.Controls.Add(this.info);
            this.info_panel.Controls.Add(this.info_progress);
            this.info_panel.Location = new System.Drawing.Point(170, 174);
            this.info_panel.Name = "info_panel";
            this.info_panel.Size = new System.Drawing.Size(312, 72);
            this.info_panel.TabIndex = 154;
            // 
            // speed_echo
            // 
            this.speed_echo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speed_echo.AutoSize = true;
            this.speed_echo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.speed_echo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.speed_echo.ForeColor = System.Drawing.Color.SlateBlue;
            this.speed_echo.Location = new System.Drawing.Point(5, 40);
            this.speed_echo.Name = "speed_echo";
            this.speed_echo.Size = new System.Drawing.Size(0, 15);
            this.speed_echo.TabIndex = 38;
            // 
            // info_progress
            // 
            this.info_progress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.info_progress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.info_progress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.info_progress.Location = new System.Drawing.Point(0, 58);
            this.info_progress.Name = "info_progress";
            this.info_progress.Size = new System.Drawing.Size(310, 12);
            this.info_progress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.info_progress.TabIndex = 32;
            this.info_progress.TabStop = false;
            // 
            // filename_changeBox
            // 
            this.filename_changeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filename_changeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.filename_changeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filename_changeBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.filename_changeBox.ForeColor = System.Drawing.Color.SlateBlue;
            this.filename_changeBox.Location = new System.Drawing.Point(2, 152);
            this.filename_changeBox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filename_changeBox.Name = "filename_changeBox";
            this.filename_changeBox.ReadOnly = true;
            this.filename_changeBox.Size = new System.Drawing.Size(436, 20);
            this.filename_changeBox.TabIndex = 158;
            this.filename_changeBox.TextChanged += new System.EventHandler(this.filename_changeBox_TextChanged);
            this.filename_changeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filename_changeBox_KeyDown);
            // 
            // process_location
            // 
            this.process_location.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.process_location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.process_location.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.process_location.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.process_location.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.process_location.Location = new System.Drawing.Point(0, 270);
            this.process_location.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.process_location.Name = "process_location";
            this.process_location.ReadOnly = true;
            this.process_location.Size = new System.Drawing.Size(484, 20);
            this.process_location.TabIndex = 159;
            this.process_location.KeyDown += new System.Windows.Forms.KeyEventHandler(this.process_location_KeyDown);
            // 
            // links
            // 
            this.links.AllowDrop = true;
            this.links.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.links.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.links.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.links.BackgroundImageTiled = true;
            this.links.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.links.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.links_clm_num,
            this.links_clm_name,
            this.links_clm_url});
            this.links.ContextMenuStrip = this.links_RMB;
            this.links.ForeColor = System.Drawing.Color.SlateBlue;
            this.links.FullRowSelect = true;
            this.links.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.links.HideSelection = false;
            this.links.Location = new System.Drawing.Point(2, 24);
            this.links.MultiSelect = false;
            this.links.Name = "links";
            this.links.Size = new System.Drawing.Size(480, 104);
            this.links.TabIndex = 155;
            this.links.UseCompatibleStateImageBehavior = false;
            this.links.View = System.Windows.Forms.View.Details;
            this.links.SelectedIndexChanged += new System.EventHandler(this.links_SelectedIndexChanged);
            this.links.DragDrop += new System.Windows.Forms.DragEventHandler(this.Links_DragDrop);
            this.links.DragEnter += new System.Windows.Forms.DragEventHandler(this.Links_DragEnter);
            this.links.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Links_KeyDown);
            this.links.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Links_MouseDoubleClick);
            // 
            // links_clm_num
            // 
            this.links_clm_num.Text = "#";
            // 
            // links_clm_name
            // 
            this.links_clm_name.Text = "File Name";
            // 
            // links_clm_url
            // 
            this.links_clm_url.Text = "URL";
            // 
            // auto
            // 
            this.auto.Interval = 50;
            this.auto.Tick += new System.EventHandler(this.auto_Tick);
            // 
            // speed
            // 
            this.speed.Interval = 1000;
            this.speed.Tick += new System.EventHandler(this.speed_Tick);
            // 
            // fapmap_download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(484, 342);
            this.Controls.Add(this.sc_webgrab);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MinimumSize = new System.Drawing.Size(390, 320);
            this.Name = "fapmap_download";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAPMAP - DOWNLOADER";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fapmap_download_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fapmap_download_FormClosed);
            this.Load += new System.EventHandler(this.fapmap_download_Load);
            this.cb_panel.ResumeLayout(false);
            this.cb_panel.PerformLayout();
            this.links_RMB.ResumeLayout(false);
            this.webgrab_panel.ResumeLayout(false);
            this.webgrab_panel.PerformLayout();
            this.sc_webgrab.Panel1.ResumeLayout(false);
            this.sc_webgrab.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc_webgrab)).EndInit();
            this.sc_webgrab.ResumeLayout(false);
            this.sc_youtubedl.Panel1.ResumeLayout(false);
            this.sc_youtubedl.Panel1.PerformLayout();
            this.sc_youtubedl.Panel2.ResumeLayout(false);
            this.sc_youtubedl.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_youtubedl)).EndInit();
            this.sc_youtubedl.ResumeLayout(false);
            this.info_panel.ResumeLayout(false);
            this.info_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.info_progress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel cb_panel;
        private System.Windows.Forms.TextBox file_location;
        private System.Windows.Forms.Button file_open;
        private System.Windows.Forms.Button links_dl;
        private System.Windows.Forms.NotifyIcon SystemTrayIcon;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.TextBox info;
        private System.Windows.Forms.TextBox links_url;
        private System.Windows.Forms.Button links_append;
        private System.Windows.Forms.TextBox process_url;
        private System.Windows.Forms.ContextMenuStrip links_RMB;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_copy;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_paste;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_delete;
        private System.Windows.Forms.CheckBox cb_auto_clip;
        private System.Windows.Forms.CheckBox cb_auto_dl;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_cut;
        private System.Windows.Forms.CheckBox cb_uncheckAuto;
        private System.Windows.Forms.Panel webgrab_panel;
        private System.Windows.Forms.Button webgrab_start;
        private System.Windows.Forms.TextBox webgrab_url;
        private System.Windows.Forms.CheckBox cb_conflict_skip;
        private System.Windows.Forms.CheckBox cb_conflict_replace;
        private System.Windows.Forms.CheckBox cb_conflict_rename;
        private System.Windows.Forms.CheckBox cb_nonFile;
        private System.Windows.Forms.SplitContainer sc_webgrab;
        private System.Windows.Forms.Panel info_panel;
        private System.Windows.Forms.CheckBox cb_webgrab;
        private System.Windows.Forms.Timer auto;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_deleteAll;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_deleteSome;
        private System.Windows.Forms.Label speed_echo;
        private System.Windows.Forms.Label links_count;
        private System.Windows.Forms.Timer speed;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_refresh;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_incognito;
        private System.Windows.Forms.TextBox webgrab_options;
        private System.Windows.Forms.ListView links;
        private System.Windows.Forms.TextBox filename_changeBox;
        private System.Windows.Forms.TextBox process_location;
        private System.Windows.Forms.RadioButton rb_shutdown;
        private System.Windows.Forms.RadioButton rb_exit;
        private System.Windows.Forms.RadioButton rb_close;
        private System.Windows.Forms.ColumnHeader links_clm_name;
        private System.Windows.Forms.ColumnHeader links_clm_num;
        private System.Windows.Forms.ColumnHeader links_clm_url;
        private System.Windows.Forms.PictureBox info_progress;
        private System.Windows.Forms.RadioButton rb_null;
        private System.Windows.Forms.SplitContainer sc_youtubedl;
        private System.Windows.Forms.TextBox youtubedl_url;
        private System.Windows.Forms.Button youtubedl_start;
        private System.Windows.Forms.CheckBox cb_youtubedl;
        private System.Windows.Forms.CheckBox cb_auto;
    }
}