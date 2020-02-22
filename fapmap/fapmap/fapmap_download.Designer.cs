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
            this.cb_auto = new System.Windows.Forms.CheckBox();
            this.rb_shutdown = new System.Windows.Forms.RadioButton();
            this.rb_exit = new System.Windows.Forms.RadioButton();
            this.rb_close = new System.Windows.Forms.RadioButton();
            this.rb_null = new System.Windows.Forms.RadioButton();
            this.label_linksCount = new System.Windows.Forms.Label();
            this.cb_webgrab = new System.Windows.Forms.CheckBox();
            this.cb_nonFile = new System.Windows.Forms.CheckBox();
            this.cb_conflict_replace = new System.Windows.Forms.CheckBox();
            this.cb_conflict_rename = new System.Windows.Forms.CheckBox();
            this.cb_conflict_skip = new System.Windows.Forms.CheckBox();
            this.txt_dir = new System.Windows.Forms.TextBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_dl = new System.Windows.Forms.Button();
            this.this_trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.btn_addURL = new System.Windows.Forms.Button();
            this.btn_webgrabStart = new System.Windows.Forms.Button();
            this.btn_openPathSelector = new System.Windows.Forms.Button();
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
            this.txt_url = new System.Windows.Forms.TextBox();
            this.txt_dledURL = new System.Windows.Forms.TextBox();
            this.txt_webgrabOptions = new System.Windows.Forms.TextBox();
            this.txt_webgrabURL = new System.Windows.Forms.TextBox();
            this.sc_webgrab = new System.Windows.Forms.SplitContainer();
            this.txt_dledPATH = new System.Windows.Forms.TextBox();
            this.txt_filename = new System.Windows.Forms.TextBox();
            this.links = new System.Windows.Forms.ListView();
            this.links_clm_num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.links_clm_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.links_clm_url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.auto = new System.Windows.Forms.Timer(this.components);
            this.cb_panel.SuspendLayout();
            this.links_RMB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_webgrab)).BeginInit();
            this.sc_webgrab.Panel1.SuspendLayout();
            this.sc_webgrab.Panel2.SuspendLayout();
            this.sc_webgrab.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_panel
            // 
            this.cb_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_panel.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.cb_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cb_panel.Controls.Add(this.cb_auto);
            this.cb_panel.Controls.Add(this.rb_shutdown);
            this.cb_panel.Controls.Add(this.rb_exit);
            this.cb_panel.Controls.Add(this.rb_close);
            this.cb_panel.Controls.Add(this.rb_null);
            this.cb_panel.Controls.Add(this.label_linksCount);
            this.cb_panel.Controls.Add(this.cb_webgrab);
            this.cb_panel.Controls.Add(this.cb_nonFile);
            this.cb_panel.Controls.Add(this.cb_conflict_replace);
            this.cb_panel.Controls.Add(this.cb_conflict_rename);
            this.cb_panel.Controls.Add(this.cb_conflict_skip);
            this.cb_panel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cb_panel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_panel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_panel.Location = new System.Drawing.Point(4, 236);
            this.cb_panel.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_panel.Name = "cb_panel";
            this.cb_panel.Size = new System.Drawing.Size(115, 78);
            this.cb_panel.TabIndex = 23;
            // 
            // cb_auto
            // 
            this.cb_auto.AutoSize = true;
            this.cb_auto.BackColor = System.Drawing.Color.Transparent;
            this.cb_auto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_auto.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_auto.ForeColor = System.Drawing.Color.Teal;
            this.cb_auto.Location = new System.Drawing.Point(4, 6);
            this.cb_auto.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_auto.Name = "cb_auto";
            this.cb_auto.Size = new System.Drawing.Size(50, 17);
            this.cb_auto.TabIndex = 55;
            this.cb_auto.Text = "Auto";
            this.HelpBalloon.SetToolTip(this.cb_auto, "Automatically download files in listbox");
            this.cb_auto.UseVisualStyleBackColor = false;
            this.cb_auto.CheckedChanged += new System.EventHandler(this.cb_auto_CheckedChanged);
            // 
            // rb_shutdown
            // 
            this.rb_shutdown.AutoSize = true;
            this.rb_shutdown.BackColor = System.Drawing.Color.Transparent;
            this.rb_shutdown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_shutdown.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rb_shutdown.ForeColor = System.Drawing.Color.Teal;
            this.rb_shutdown.Location = new System.Drawing.Point(58, 52);
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
            this.rb_exit.Location = new System.Drawing.Point(58, 36);
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
            this.rb_close.Location = new System.Drawing.Point(58, 19);
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
            this.rb_null.Location = new System.Drawing.Point(58, 3);
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
            // label_linksCount
            // 
            this.label_linksCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_linksCount.AutoSize = true;
            this.label_linksCount.BackColor = System.Drawing.Color.Transparent;
            this.label_linksCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_linksCount.ForeColor = System.Drawing.Color.Teal;
            this.label_linksCount.Location = new System.Drawing.Point(1, 61);
            this.label_linksCount.Name = "label_linksCount";
            this.label_linksCount.Size = new System.Drawing.Size(14, 14);
            this.label_linksCount.TabIndex = 39;
            this.label_linksCount.Text = "0";
            // 
            // cb_webgrab
            // 
            this.cb_webgrab.AutoSize = true;
            this.cb_webgrab.BackColor = System.Drawing.Color.Transparent;
            this.cb_webgrab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_webgrab.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_webgrab.ForeColor = System.Drawing.Color.Teal;
            this.cb_webgrab.Location = new System.Drawing.Point(4, 42);
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
            this.cb_nonFile.Location = new System.Drawing.Point(4, 24);
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
            this.cb_conflict_replace.Location = new System.Drawing.Point(106, 62);
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
            this.cb_conflict_rename.Location = new System.Drawing.Point(106, 69);
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
            this.cb_conflict_skip.Location = new System.Drawing.Point(106, 55);
            this.cb_conflict_skip.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_conflict_skip.Name = "cb_conflict_skip";
            this.cb_conflict_skip.Size = new System.Drawing.Size(6, 6);
            this.cb_conflict_skip.TabIndex = 41;
            this.HelpBalloon.SetToolTip(this.cb_conflict_skip, "Automatically skip URL, if file exists...");
            this.cb_conflict_skip.UseVisualStyleBackColor = false;
            this.cb_conflict_skip.CheckedChanged += new System.EventHandler(this.cb_skip_CheckedChanged);
            // 
            // txt_dir
            // 
            this.txt_dir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_dir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_dir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dir.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_dir.ForeColor = System.Drawing.Color.SlateBlue;
            this.txt_dir.Location = new System.Drawing.Point(4, 192);
            this.txt_dir.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_dir.Name = "txt_dir";
            this.txt_dir.Size = new System.Drawing.Size(553, 20);
            this.txt_dir.TabIndex = 21;
            this.txt_dir.TextChanged += new System.EventHandler(this.txt_dir_TextChanged);
            this.txt_dir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_dir_KeyDown);
            // 
            // btn_open
            // 
            this.btn_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_open.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_open.BackgroundImage = global::fapmap.Properties.Resources.open;
            this.btn_open.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_open.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_open.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_open.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_open.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_open.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_open.ForeColor = System.Drawing.Color.DimGray;
            this.btn_open.Location = new System.Drawing.Point(559, 214);
            this.btn_open.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(20, 20);
            this.btn_open.TabIndex = 25;
            this.HelpBalloon.SetToolTip(this.btn_open, "Open last downloaded file");
            this.btn_open.UseVisualStyleBackColor = false;
            this.btn_open.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_open_MouseClick);
            // 
            // btn_dl
            // 
            this.btn_dl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_dl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_dl.BackgroundImage = global::fapmap.Properties.Resources.download;
            this.btn_dl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_dl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dl.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_dl.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_dl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_dl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_dl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dl.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_dl.ForeColor = System.Drawing.Color.DimGray;
            this.btn_dl.Location = new System.Drawing.Point(537, 214);
            this.btn_dl.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_dl.Name = "btn_dl";
            this.btn_dl.Size = new System.Drawing.Size(20, 20);
            this.btn_dl.TabIndex = 24;
            this.HelpBalloon.SetToolTip(this.btn_dl, "Download/Cancel download");
            this.btn_dl.UseVisualStyleBackColor = false;
            this.btn_dl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_dl_MouseClick);
            // 
            // this_trayicon
            // 
            this.this_trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("this_trayicon.Icon")));
            this.this_trayicon.Visible = true;
            this.this_trayicon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.this_trayicon_MouseClick);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.SlateBlue;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // btn_addURL
            // 
            this.btn_addURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_addURL.BackgroundImage = global::fapmap.Properties.Resources.arrow_down;
            this.btn_addURL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addURL.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_addURL.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_addURL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_addURL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_addURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_addURL.ForeColor = System.Drawing.Color.DimGray;
            this.btn_addURL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_addURL.Location = new System.Drawing.Point(559, 4);
            this.btn_addURL.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_addURL.Name = "btn_addURL";
            this.btn_addURL.Size = new System.Drawing.Size(20, 20);
            this.btn_addURL.TabIndex = 152;
            this.HelpBalloon.SetToolTip(this.btn_addURL, "Add file url to download list");
            this.btn_addURL.UseVisualStyleBackColor = false;
            this.btn_addURL.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_addURL_MouseClick);
            // 
            // btn_webgrabStart
            // 
            this.btn_webgrabStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_webgrabStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_webgrabStart.BackgroundImage = global::fapmap.Properties.Resources.arrow_left;
            this.btn_webgrabStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_webgrabStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_webgrabStart.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_webgrabStart.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_webgrabStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_webgrabStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_webgrabStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_webgrabStart.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_webgrabStart.ForeColor = System.Drawing.Color.DimGray;
            this.btn_webgrabStart.Location = new System.Drawing.Point(559, 4);
            this.btn_webgrabStart.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_webgrabStart.Name = "btn_webgrabStart";
            this.btn_webgrabStart.Size = new System.Drawing.Size(20, 20);
            this.btn_webgrabStart.TabIndex = 153;
            this.HelpBalloon.SetToolTip(this.btn_webgrabStart, "Start/Stop webgrab.exe");
            this.btn_webgrabStart.UseVisualStyleBackColor = false;
            this.btn_webgrabStart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_webgrabStart_MouseClick);
            // 
            // btn_openPathSelector
            // 
            this.btn_openPathSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openPathSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_openPathSelector.BackgroundImage = global::fapmap.Properties.Resources.folder;
            this.btn_openPathSelector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_openPathSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_openPathSelector.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_openPathSelector.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_openPathSelector.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_openPathSelector.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_openPathSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openPathSelector.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_openPathSelector.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_openPathSelector.Location = new System.Drawing.Point(559, 192);
            this.btn_openPathSelector.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openPathSelector.Name = "btn_openPathSelector";
            this.btn_openPathSelector.Size = new System.Drawing.Size(20, 20);
            this.btn_openPathSelector.TabIndex = 160;
            this.HelpBalloon.SetToolTip(this.btn_openPathSelector, "Select Folder");
            this.btn_openPathSelector.UseVisualStyleBackColor = false;
            this.btn_openPathSelector.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_openPathSelector_MouseClick);
            // 
            // info
            // 
            this.info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.info.ForeColor = System.Drawing.Color.Teal;
            this.info.Location = new System.Drawing.Point(121, 236);
            this.info.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.info.Multiline = true;
            this.info.Name = "info";
            this.info.ReadOnly = true;
            this.info.Size = new System.Drawing.Size(458, 78);
            this.info.TabIndex = 31;
            this.info.Text = "...";
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
            this.links_RMB_refresh.Click += new System.EventHandler(this.links_RMB_refresh_Click);
            // 
            // links_RMB_incognito
            // 
            this.links_RMB_incognito.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_incognito.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_incognito.Image = global::fapmap.Properties.Resources.incognito;
            this.links_RMB_incognito.Name = "links_RMB_incognito";
            this.links_RMB_incognito.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_incognito.Text = "Incognito (CTRL+U)";
            this.links_RMB_incognito.Click += new System.EventHandler(this.links_RMB_incognito_Click);
            // 
            // links_RMB_copy
            // 
            this.links_RMB_copy.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_copy.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_copy.Image = global::fapmap.Properties.Resources.copy;
            this.links_RMB_copy.Name = "links_RMB_copy";
            this.links_RMB_copy.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_copy.Text = "Copy URL (CTRL+C)";
            this.links_RMB_copy.Click += new System.EventHandler(this.links_RMB_copy_Click);
            // 
            // links_RMB_cut
            // 
            this.links_RMB_cut.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_cut.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_cut.Image = global::fapmap.Properties.Resources.cut;
            this.links_RMB_cut.Name = "links_RMB_cut";
            this.links_RMB_cut.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_cut.Text = "Cut URL (CTRL+X)";
            this.links_RMB_cut.Click += new System.EventHandler(this.links_RMB_cut_Click);
            // 
            // links_RMB_paste
            // 
            this.links_RMB_paste.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_paste.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_paste.Image = global::fapmap.Properties.Resources.paste;
            this.links_RMB_paste.Name = "links_RMB_paste";
            this.links_RMB_paste.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_paste.Text = "Paste URL (CTRL+V)";
            this.links_RMB_paste.Click += new System.EventHandler(this.links_RMB_paste_Click);
            // 
            // links_RMB_delete
            // 
            this.links_RMB_delete.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_delete.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_delete.Image = global::fapmap.Properties.Resources.delete;
            this.links_RMB_delete.Name = "links_RMB_delete";
            this.links_RMB_delete.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_delete.Text = "Remove URL (DEL)";
            this.links_RMB_delete.Click += new System.EventHandler(this.links_RMB_delete_Click);
            // 
            // links_RMB_deleteAll
            // 
            this.links_RMB_deleteAll.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_deleteAll.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_deleteAll.Image = global::fapmap.Properties.Resources.delete;
            this.links_RMB_deleteAll.Name = "links_RMB_deleteAll";
            this.links_RMB_deleteAll.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_deleteAll.Text = "Remove All URLs (CTRL+DEL)";
            this.links_RMB_deleteAll.Click += new System.EventHandler(this.links_RMB_deleteAll_Click);
            // 
            // links_RMB_deleteSome
            // 
            this.links_RMB_deleteSome.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.links_RMB_deleteSome.ForeColor = System.Drawing.Color.SlateBlue;
            this.links_RMB_deleteSome.Image = global::fapmap.Properties.Resources.delete;
            this.links_RMB_deleteSome.Name = "links_RMB_deleteSome";
            this.links_RMB_deleteSome.Size = new System.Drawing.Size(229, 22);
            this.links_RMB_deleteSome.Text = "Remove Only (SHIFT+DEL)";
            this.links_RMB_deleteSome.Click += new System.EventHandler(this.links_RMB_deleteSome_Click);
            // 
            // txt_url
            // 
            this.txt_url.AllowDrop = true;
            this.txt_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_url.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txt_url.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.txt_url.Location = new System.Drawing.Point(4, 4);
            this.txt_url.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(553, 20);
            this.txt_url.TabIndex = 151;
            this.txt_url.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_url_DragDrop);
            this.txt_url.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_url_DragEnter);
            this.txt_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_url_KeyDown);
            // 
            // txt_dledURL
            // 
            this.txt_dledURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_dledURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dledURL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_dledURL.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_dledURL.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.txt_dledURL.Location = new System.Drawing.Point(0, 319);
            this.txt_dledURL.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_dledURL.Name = "txt_dledURL";
            this.txt_dledURL.ReadOnly = true;
            this.txt_dledURL.Size = new System.Drawing.Size(583, 20);
            this.txt_dledURL.TabIndex = 153;
            this.txt_dledURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_dledURL_KeyDown);
            // 
            // txt_webgrabOptions
            // 
            this.txt_webgrabOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_webgrabOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_webgrabOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_webgrabOptions.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txt_webgrabOptions.ForeColor = System.Drawing.Color.Teal;
            this.txt_webgrabOptions.Location = new System.Drawing.Point(261, 4);
            this.txt_webgrabOptions.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_webgrabOptions.Name = "txt_webgrabOptions";
            this.txt_webgrabOptions.Size = new System.Drawing.Size(296, 20);
            this.txt_webgrabOptions.TabIndex = 157;
            this.txt_webgrabOptions.Text = "@agent,@valid,@media,@nodupes";
            this.txt_webgrabOptions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_webgrabOptions_KeyDown);
            // 
            // txt_webgrabURL
            // 
            this.txt_webgrabURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_webgrabURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_webgrabURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_webgrabURL.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txt_webgrabURL.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txt_webgrabURL.Location = new System.Drawing.Point(4, 4);
            this.txt_webgrabURL.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_webgrabURL.Name = "txt_webgrabURL";
            this.txt_webgrabURL.Size = new System.Drawing.Size(255, 20);
            this.txt_webgrabURL.TabIndex = 152;
            this.txt_webgrabURL.TextChanged += new System.EventHandler(this.txt_webgrabURL_TextChanged);
            this.txt_webgrabURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_webgrabURL_KeyDown);
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
            this.sc_webgrab.Panel1.Controls.Add(this.btn_webgrabStart);
            this.sc_webgrab.Panel1.Controls.Add(this.txt_webgrabOptions);
            this.sc_webgrab.Panel1.Controls.Add(this.txt_webgrabURL);
            // 
            // sc_webgrab.Panel2
            // 
            this.sc_webgrab.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.sc_webgrab.Panel2.Controls.Add(this.txt_dledURL);
            this.sc_webgrab.Panel2.Controls.Add(this.info);
            this.sc_webgrab.Panel2.Controls.Add(this.txt_dledPATH);
            this.sc_webgrab.Panel2.Controls.Add(this.btn_openPathSelector);
            this.sc_webgrab.Panel2.Controls.Add(this.btn_dl);
            this.sc_webgrab.Panel2.Controls.Add(this.txt_url);
            this.sc_webgrab.Panel2.Controls.Add(this.btn_open);
            this.sc_webgrab.Panel2.Controls.Add(this.btn_addURL);
            this.sc_webgrab.Panel2.Controls.Add(this.cb_panel);
            this.sc_webgrab.Panel2.Controls.Add(this.txt_dir);
            this.sc_webgrab.Panel2.Controls.Add(this.txt_filename);
            this.sc_webgrab.Panel2.Controls.Add(this.links);
            this.sc_webgrab.Size = new System.Drawing.Size(583, 390);
            this.sc_webgrab.SplitterDistance = 30;
            this.sc_webgrab.SplitterWidth = 1;
            this.sc_webgrab.TabIndex = 155;
            // 
            // txt_dledPATH
            // 
            this.txt_dledPATH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_dledPATH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dledPATH.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_dledPATH.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_dledPATH.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.txt_dledPATH.Location = new System.Drawing.Point(0, 339);
            this.txt_dledPATH.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_dledPATH.Name = "txt_dledPATH";
            this.txt_dledPATH.ReadOnly = true;
            this.txt_dledPATH.Size = new System.Drawing.Size(583, 20);
            this.txt_dledPATH.TabIndex = 159;
            this.txt_dledPATH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_dledPATH_KeyDown);
            // 
            // txt_filename
            // 
            this.txt_filename.AllowDrop = true;
            this.txt_filename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_filename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_filename.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_filename.ForeColor = System.Drawing.Color.SlateBlue;
            this.txt_filename.Location = new System.Drawing.Point(4, 214);
            this.txt_filename.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_filename.Name = "txt_filename";
            this.txt_filename.ReadOnly = true;
            this.txt_filename.Size = new System.Drawing.Size(531, 20);
            this.txt_filename.TabIndex = 158;
            this.txt_filename.TextChanged += new System.EventHandler(this.txt_filename_TextChanged);
            this.txt_filename.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_filename_DragDrop);
            this.txt_filename.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_filename_DragEnter);
            this.txt_filename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_filename_KeyDown);
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
            this.links.Location = new System.Drawing.Point(4, 26);
            this.links.MultiSelect = false;
            this.links.Name = "links";
            this.links.Size = new System.Drawing.Size(575, 164);
            this.links.TabIndex = 155;
            this.links.UseCompatibleStateImageBehavior = false;
            this.links.View = System.Windows.Forms.View.Details;
            this.links.SelectedIndexChanged += new System.EventHandler(this.links_SelectedIndexChanged);
            this.links.DragDrop += new System.Windows.Forms.DragEventHandler(this.links_DragDrop);
            this.links.DragEnter += new System.Windows.Forms.DragEventHandler(this.links_DragEnter);
            this.links.KeyDown += new System.Windows.Forms.KeyEventHandler(this.links_KeyDown);
            this.links.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.links_MouseDoubleClick);
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
            this.auto.Tick += new System.EventHandler(this.auto_Tick);
            // 
            // fapmap_download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(583, 390);
            this.Controls.Add(this.sc_webgrab);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MinimumSize = new System.Drawing.Size(390, 320);
            this.Name = "fapmap_download";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - Downloader (+webgrab.exe)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fapmap_download_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fapmap_download_FormClosed);
            this.Load += new System.EventHandler(this.fapmap_download_Load);
            this.cb_panel.ResumeLayout(false);
            this.cb_panel.PerformLayout();
            this.links_RMB.ResumeLayout(false);
            this.sc_webgrab.Panel1.ResumeLayout(false);
            this.sc_webgrab.Panel1.PerformLayout();
            this.sc_webgrab.Panel2.ResumeLayout(false);
            this.sc_webgrab.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_webgrab)).EndInit();
            this.sc_webgrab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel cb_panel;
        private System.Windows.Forms.TextBox txt_dir;
        private System.Windows.Forms.Button btn_open;
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
        private System.Windows.Forms.SplitContainer sc_webgrab;
        private System.Windows.Forms.CheckBox cb_webgrab;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_deleteAll;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_deleteSome;
        private System.Windows.Forms.Label label_linksCount;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_refresh;
        private System.Windows.Forms.ToolStripMenuItem links_RMB_incognito;
        private System.Windows.Forms.TextBox txt_webgrabOptions;
        private System.Windows.Forms.ListView links;
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
    }
}