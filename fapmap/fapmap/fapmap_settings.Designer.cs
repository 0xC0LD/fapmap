namespace fapmap
{
    partial class fapmap_settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_settings));
            this.txt_size = new System.Windows.Forms.TextBox();
            this.panel_info = new System.Windows.Forms.Panel();
            this.txt_outputBorder = new System.Windows.Forms.Panel();
            this.txt_output = new System.Windows.Forms.RichTextBox();
            this.btn_getinfo = new System.Windows.Forms.Button();
            this.label_info = new System.Windows.Forms.Label();
            this.cb_noZero = new System.Windows.Forms.CheckBox();
            this.label_gallery = new System.Windows.Forms.Label();
            this.btn_editINI = new System.Windows.Forms.Button();
            this.panel_browser = new System.Windows.Forms.Panel();
            this.rb_chrome = new System.Windows.Forms.RadioButton();
            this.rb_firefox = new System.Windows.Forms.RadioButton();
            this.rb_opera = new System.Windows.Forms.RadioButton();
            this.label_browser = new System.Windows.Forms.Label();
            this.txt_newPasswd = new System.Windows.Forms.TextBox();
            this.txt_passwds = new System.Windows.Forms.ListBox();
            this.txt_passwdsBorder = new System.Windows.Forms.Panel();
            this.btn_addPasswd = new System.Windows.Forms.Button();
            this.label_passwd = new System.Windows.Forms.Label();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.txt_wbURL = new System.Windows.Forms.TextBox();
            this.label_wb = new System.Windows.Forms.Label();
            this.panel_txt = new System.Windows.Forms.Panel();
            this.label_gifDelay = new System.Windows.Forms.Label();
            this.txt_gifDelay = new System.Windows.Forms.TextBox();
            this.panel_passwd = new System.Windows.Forms.Panel();
            this.panel_cb = new System.Windows.Forms.Panel();
            this.cb_fdThumb = new System.Windows.Forms.CheckBox();
            this.cb_fdSortByDate = new System.Windows.Forms.CheckBox();
            this.label_cb_fileDisplay = new System.Windows.Forms.Label();
            this.cb_tvIndex = new System.Windows.Forms.CheckBox();
            this.cb_tvSortByDate = new System.Windows.Forms.CheckBox();
            this.label_cb_treeView = new System.Windows.Forms.Label();
            this.label_cb_enable = new System.Windows.Forms.Label();
            this.label_cb_auto = new System.Windows.Forms.Label();
            this.label_cb_hideWindow = new System.Windows.Forms.Label();
            this.cb_logs = new System.Windows.Forms.CheckBox();
            this.cb_openOutside = new System.Windows.Forms.CheckBox();
            this.cb_fileDisplay = new System.Windows.Forms.CheckBox();
            this.cb_trackbar = new System.Windows.Forms.CheckBox();
            this.cb_autoPause = new System.Windows.Forms.CheckBox();
            this.cb_autoPlay = new System.Windows.Forms.CheckBox();
            this.cb_autoHideMedia = new System.Windows.Forms.CheckBox();
            this.cb_media = new System.Windows.Forms.CheckBox();
            this.cb_focusHide = new System.Windows.Forms.CheckBox();
            this.label_cb = new System.Windows.Forms.Label();
            this.cb_hideOnX = new System.Windows.Forms.CheckBox();
            this.panel_info.SuspendLayout();
            this.txt_outputBorder.SuspendLayout();
            this.panel_browser.SuspendLayout();
            this.txt_passwdsBorder.SuspendLayout();
            this.panel_txt.SuspendLayout();
            this.panel_passwd.SuspendLayout();
            this.panel_cb.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_size
            // 
            this.txt_size.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_size.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_size.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_size.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txt_size.Location = new System.Drawing.Point(3, 60);
            this.txt_size.Name = "txt_size";
            this.txt_size.ReadOnly = true;
            this.txt_size.Size = new System.Drawing.Size(385, 26);
            this.txt_size.TabIndex = 0;
            this.txt_size.Text = "00,00 GB (000000000000 bytes)";
            this.txt_size.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gallerySize_KeyDown);
            // 
            // panel_info
            // 
            this.panel_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.panel_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_info.Controls.Add(this.txt_outputBorder);
            this.panel_info.Controls.Add(this.btn_getinfo);
            this.panel_info.Controls.Add(this.label_info);
            this.panel_info.Controls.Add(this.cb_noZero);
            this.panel_info.Controls.Add(this.txt_size);
            this.panel_info.Controls.Add(this.label_gallery);
            this.panel_info.Location = new System.Drawing.Point(422, 67);
            this.panel_info.Name = "panel_info";
            this.panel_info.Size = new System.Drawing.Size(393, 662);
            this.panel_info.TabIndex = 0;
            // 
            // txt_outputBorder
            // 
            this.txt_outputBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_outputBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_outputBorder.Controls.Add(this.txt_output);
            this.txt_outputBorder.Location = new System.Drawing.Point(3, 88);
            this.txt_outputBorder.Name = "txt_outputBorder";
            this.txt_outputBorder.Size = new System.Drawing.Size(385, 569);
            this.txt_outputBorder.TabIndex = 223;
            // 
            // txt_output
            // 
            this.txt_output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_output.DetectUrls = false;
            this.txt_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_output.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_output.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txt_output.Location = new System.Drawing.Point(0, 0);
            this.txt_output.Name = "txt_output";
            this.txt_output.ReadOnly = true;
            this.txt_output.Size = new System.Drawing.Size(383, 567);
            this.txt_output.TabIndex = 0;
            this.txt_output.Text = "...";
            this.txt_output.WordWrap = false;
            // 
            // btn_getinfo
            // 
            this.btn_getinfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_getinfo.BackgroundImage = global::fapmap.Properties.Resources.arrow_down;
            this.btn_getinfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_getinfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_getinfo.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btn_getinfo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_getinfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_getinfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_getinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_getinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_getinfo.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_getinfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_getinfo.Location = new System.Drawing.Point(3, 28);
            this.btn_getinfo.Name = "btn_getinfo";
            this.btn_getinfo.Size = new System.Drawing.Size(30, 30);
            this.btn_getinfo.TabIndex = 24;
            this.HelpBalloon.SetToolTip(this.btn_getinfo, "Get Gallery Info");
            this.btn_getinfo.UseVisualStyleBackColor = false;
            this.btn_getinfo.Click += new System.EventHandler(this.btn_getinfo_Click);
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.BackColor = System.Drawing.Color.Transparent;
            this.label_info.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_info.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label_info.Location = new System.Drawing.Point(237, 40);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(25, 13);
            this.label_info.TabIndex = 215;
            this.label_info.Text = "...";
            // 
            // cb_noZero
            // 
            this.cb_noZero.AutoSize = true;
            this.cb_noZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cb_noZero.Checked = true;
            this.cb_noZero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_noZero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_noZero.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.cb_noZero.FlatAppearance.CheckedBackColor = System.Drawing.Color.SlateBlue;
            this.cb_noZero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_noZero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_noZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_noZero.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_noZero.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.cb_noZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_noZero.Location = new System.Drawing.Point(1, 1);
            this.cb_noZero.Name = "cb_noZero";
            this.cb_noZero.Size = new System.Drawing.Size(12, 11);
            this.cb_noZero.TabIndex = 25;
            this.HelpBalloon.SetToolTip(this.cb_noZero, "Don\'t output file types that have a 0 count...");
            this.cb_noZero.UseVisualStyleBackColor = false;
            // 
            // label_gallery
            // 
            this.label_gallery.AutoSize = true;
            this.label_gallery.BackColor = System.Drawing.Color.Transparent;
            this.label_gallery.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_gallery.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label_gallery.Location = new System.Drawing.Point(39, 14);
            this.label_gallery.Name = "label_gallery";
            this.label_gallery.Size = new System.Drawing.Size(208, 42);
            this.label_gallery.TabIndex = 0;
            this.label_gallery.Text = "GALLERY:";
            // 
            // btn_editINI
            // 
            this.btn_editINI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editINI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_editINI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_editINI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_editINI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_editINI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_editINI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editINI.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_editINI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_editINI.Location = new System.Drawing.Point(200, 634);
            this.btn_editINI.Name = "btn_editINI";
            this.btn_editINI.Size = new System.Drawing.Size(36, 23);
            this.btn_editINI.TabIndex = 23;
            this.btn_editINI.Text = ".ini";
            this.HelpBalloon.SetToolTip(this.btn_editINI, "Edit Settings File");
            this.btn_editINI.UseVisualStyleBackColor = false;
            this.btn_editINI.Click += new System.EventHandler(this.btn_editINI_Click);
            // 
            // panel_browser
            // 
            this.panel_browser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.panel_browser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_browser.Controls.Add(this.rb_chrome);
            this.panel_browser.Controls.Add(this.rb_firefox);
            this.panel_browser.Controls.Add(this.rb_opera);
            this.panel_browser.Controls.Add(this.label_browser);
            this.panel_browser.Location = new System.Drawing.Point(15, 67);
            this.panel_browser.Name = "panel_browser";
            this.panel_browser.Size = new System.Drawing.Size(154, 155);
            this.panel_browser.TabIndex = 0;
            // 
            // rb_chrome
            // 
            this.rb_chrome.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_chrome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.rb_chrome.BackgroundImage = global::fapmap.Properties.Resources.browser_chrome;
            this.rb_chrome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rb_chrome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_chrome.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.rb_chrome.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.rb_chrome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.rb_chrome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.rb_chrome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_chrome.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_chrome.Location = new System.Drawing.Point(7, 67);
            this.rb_chrome.Name = "rb_chrome";
            this.rb_chrome.Size = new System.Drawing.Size(136, 35);
            this.rb_chrome.TabIndex = 4;
            this.rb_chrome.Tag = "CHROME";
            this.rb_chrome.Text = "CHROME";
            this.rb_chrome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_chrome.UseVisualStyleBackColor = false;
            this.rb_chrome.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_firefox
            // 
            this.rb_firefox.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_firefox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.rb_firefox.BackgroundImage = global::fapmap.Properties.Resources.browser_firefox;
            this.rb_firefox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rb_firefox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_firefox.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.rb_firefox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.rb_firefox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.rb_firefox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.rb_firefox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_firefox.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_firefox.ForeColor = System.Drawing.Color.SlateBlue;
            this.rb_firefox.Location = new System.Drawing.Point(7, 27);
            this.rb_firefox.Name = "rb_firefox";
            this.rb_firefox.Size = new System.Drawing.Size(136, 35);
            this.rb_firefox.TabIndex = 3;
            this.rb_firefox.Tag = "FIREFOX";
            this.rb_firefox.Text = "FIREFOX";
            this.rb_firefox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_firefox.UseVisualStyleBackColor = false;
            this.rb_firefox.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_opera
            // 
            this.rb_opera.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_opera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.rb_opera.BackgroundImage = global::fapmap.Properties.Resources.browser_opera;
            this.rb_opera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rb_opera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_opera.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.rb_opera.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.rb_opera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.rb_opera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.rb_opera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_opera.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_opera.Location = new System.Drawing.Point(7, 107);
            this.rb_opera.Name = "rb_opera";
            this.rb_opera.Size = new System.Drawing.Size(136, 35);
            this.rb_opera.TabIndex = 5;
            this.rb_opera.Tag = "OPERA";
            this.rb_opera.Text = "OPERA";
            this.rb_opera.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_opera.UseVisualStyleBackColor = false;
            this.rb_opera.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // label_browser
            // 
            this.label_browser.AutoSize = true;
            this.label_browser.BackColor = System.Drawing.Color.Transparent;
            this.label_browser.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_browser.ForeColor = System.Drawing.Color.SlateBlue;
            this.label_browser.Location = new System.Drawing.Point(3, 0);
            this.label_browser.Name = "label_browser";
            this.label_browser.Size = new System.Drawing.Size(140, 23);
            this.label_browser.TabIndex = 0;
            this.label_browser.Text = "BROWSERS:";
            // 
            // txt_newPasswd
            // 
            this.txt_newPasswd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_newPasswd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_newPasswd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_newPasswd.ForeColor = System.Drawing.Color.Teal;
            this.txt_newPasswd.Location = new System.Drawing.Point(3, 30);
            this.txt_newPasswd.Name = "txt_newPasswd";
            this.txt_newPasswd.Size = new System.Drawing.Size(124, 21);
            this.txt_newPasswd.TabIndex = 6;
            this.txt_newPasswd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.newPassword_KeyDown);
            // 
            // txt_passwds
            // 
            this.txt_passwds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_passwds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_passwds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_passwds.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.txt_passwds.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_passwds.ForeColor = System.Drawing.Color.Teal;
            this.txt_passwds.FormattingEnabled = true;
            this.txt_passwds.ItemHeight = 22;
            this.txt_passwds.Location = new System.Drawing.Point(0, 0);
            this.txt_passwds.Name = "txt_passwds";
            this.txt_passwds.Size = new System.Drawing.Size(144, 441);
            this.txt_passwds.TabIndex = 8;
            this.HelpBalloon.SetToolTip(this.txt_passwds, "Double Click To Remove Selected Password");
            this.txt_passwds.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.passwordsList_DrawItem);
            this.txt_passwds.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.passwordsList_MeasureItem);
            this.txt_passwds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_passwds_KeyDown);
            this.txt_passwds.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.passwordsList_MouseDoubleClick);
            // 
            // txt_passwdsBorder
            // 
            this.txt_passwdsBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_passwdsBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_passwdsBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_passwdsBorder.Controls.Add(this.txt_passwds);
            this.txt_passwdsBorder.Location = new System.Drawing.Point(3, 53);
            this.txt_passwdsBorder.Name = "txt_passwdsBorder";
            this.txt_passwdsBorder.Size = new System.Drawing.Size(146, 443);
            this.txt_passwdsBorder.TabIndex = 200;
            // 
            // btn_addPasswd
            // 
            this.btn_addPasswd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_addPasswd.BackgroundImage = global::fapmap.Properties.Resources.arrow_down;
            this.btn_addPasswd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addPasswd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addPasswd.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btn_addPasswd.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_addPasswd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_addPasswd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_addPasswd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addPasswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_addPasswd.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_addPasswd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_addPasswd.Location = new System.Drawing.Point(129, 30);
            this.btn_addPasswd.Name = "btn_addPasswd";
            this.btn_addPasswd.Size = new System.Drawing.Size(20, 21);
            this.btn_addPasswd.TabIndex = 7;
            this.HelpBalloon.SetToolTip(this.btn_addPasswd, "Add A Password");
            this.btn_addPasswd.UseVisualStyleBackColor = false;
            this.btn_addPasswd.Click += new System.EventHandler(this.btn_addPasswd_Click);
            // 
            // label_passwd
            // 
            this.label_passwd.AutoSize = true;
            this.label_passwd.BackColor = System.Drawing.Color.Transparent;
            this.label_passwd.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_passwd.ForeColor = System.Drawing.Color.Teal;
            this.label_passwd.Location = new System.Drawing.Point(-1, 0);
            this.label_passwd.Name = "label_passwd";
            this.label_passwd.Size = new System.Drawing.Size(157, 23);
            this.label_passwd.TabIndex = 0;
            this.label_passwd.Text = "PASSWORDS:";
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.SlateBlue;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // txt_wbURL
            // 
            this.txt_wbURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_wbURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_wbURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_wbURL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_wbURL.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.txt_wbURL.Location = new System.Drawing.Point(130, 2);
            this.txt_wbURL.Name = "txt_wbURL";
            this.txt_wbURL.Size = new System.Drawing.Size(666, 21);
            this.txt_wbURL.TabIndex = 1;
            this.txt_wbURL.Text = "https://www.google.com";
            this.txt_wbURL.TextChanged += new System.EventHandler(this.txt_wbURL_TextChanged);
            this.txt_wbURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_wbURL_KeyDown);
            // 
            // label_wb
            // 
            this.label_wb.AutoSize = true;
            this.label_wb.BackColor = System.Drawing.Color.Transparent;
            this.label_wb.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_wb.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label_wb.Location = new System.Drawing.Point(12, 5);
            this.label_wb.Name = "label_wb";
            this.label_wb.Size = new System.Drawing.Size(114, 13);
            this.label_wb.TabIndex = 0;
            this.label_wb.Text = "START WEBSITE:";
            // 
            // panel_txt
            // 
            this.panel_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.panel_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_txt.Controls.Add(this.label_gifDelay);
            this.panel_txt.Controls.Add(this.txt_gifDelay);
            this.panel_txt.Controls.Add(this.txt_wbURL);
            this.panel_txt.Controls.Add(this.label_wb);
            this.panel_txt.Location = new System.Drawing.Point(15, 8);
            this.panel_txt.Name = "panel_txt";
            this.panel_txt.Size = new System.Drawing.Size(800, 53);
            this.panel_txt.TabIndex = 0;
            // 
            // label_gifDelay
            // 
            this.label_gifDelay.AutoSize = true;
            this.label_gifDelay.BackColor = System.Drawing.Color.Transparent;
            this.label_gifDelay.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_gifDelay.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label_gifDelay.Location = new System.Drawing.Point(47, 30);
            this.label_gifDelay.Name = "label_gifDelay";
            this.label_gifDelay.Size = new System.Drawing.Size(79, 13);
            this.label_gifDelay.TabIndex = 0;
            this.label_gifDelay.Text = "GIF DELAY:";
            // 
            // txt_gifDelay
            // 
            this.txt_gifDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_gifDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_gifDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_gifDelay.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_gifDelay.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.txt_gifDelay.Location = new System.Drawing.Point(130, 27);
            this.txt_gifDelay.Name = "txt_gifDelay";
            this.txt_gifDelay.Size = new System.Drawing.Size(666, 21);
            this.txt_gifDelay.TabIndex = 2;
            this.txt_gifDelay.Text = "50";
            this.txt_gifDelay.TextChanged += new System.EventHandler(this.txt_gifDelay_TextChanged);
            this.txt_gifDelay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_gifDelay_KeyDown);
            // 
            // panel_passwd
            // 
            this.panel_passwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_passwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.panel_passwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_passwd.Controls.Add(this.label_passwd);
            this.panel_passwd.Controls.Add(this.txt_newPasswd);
            this.panel_passwd.Controls.Add(this.txt_passwdsBorder);
            this.panel_passwd.Controls.Add(this.btn_addPasswd);
            this.panel_passwd.Location = new System.Drawing.Point(15, 228);
            this.panel_passwd.Name = "panel_passwd";
            this.panel_passwd.Size = new System.Drawing.Size(154, 501);
            this.panel_passwd.TabIndex = 0;
            // 
            // panel_cb
            // 
            this.panel_cb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_cb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.panel_cb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_cb.Controls.Add(this.cb_fdThumb);
            this.panel_cb.Controls.Add(this.cb_fdSortByDate);
            this.panel_cb.Controls.Add(this.label_cb_fileDisplay);
            this.panel_cb.Controls.Add(this.cb_tvIndex);
            this.panel_cb.Controls.Add(this.cb_tvSortByDate);
            this.panel_cb.Controls.Add(this.label_cb_treeView);
            this.panel_cb.Controls.Add(this.label_cb_enable);
            this.panel_cb.Controls.Add(this.label_cb_auto);
            this.panel_cb.Controls.Add(this.label_cb_hideWindow);
            this.panel_cb.Controls.Add(this.cb_logs);
            this.panel_cb.Controls.Add(this.cb_openOutside);
            this.panel_cb.Controls.Add(this.btn_editINI);
            this.panel_cb.Controls.Add(this.cb_fileDisplay);
            this.panel_cb.Controls.Add(this.cb_trackbar);
            this.panel_cb.Controls.Add(this.cb_autoPause);
            this.panel_cb.Controls.Add(this.cb_autoPlay);
            this.panel_cb.Controls.Add(this.cb_autoHideMedia);
            this.panel_cb.Controls.Add(this.cb_media);
            this.panel_cb.Controls.Add(this.cb_focusHide);
            this.panel_cb.Controls.Add(this.label_cb);
            this.panel_cb.Controls.Add(this.cb_hideOnX);
            this.panel_cb.ForeColor = System.Drawing.Color.RoyalBlue;
            this.panel_cb.Location = new System.Drawing.Point(175, 67);
            this.panel_cb.Name = "panel_cb";
            this.panel_cb.Size = new System.Drawing.Size(241, 662);
            this.panel_cb.TabIndex = 0;
            // 
            // cb_fdThumb
            // 
            this.cb_fdThumb.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_fdThumb.AutoSize = true;
            this.cb_fdThumb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_fdThumb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_fdThumb.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_fdThumb.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_fdThumb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_fdThumb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_fdThumb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_fdThumb.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_fdThumb.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_fdThumb.Location = new System.Drawing.Point(6, 474);
            this.cb_fdThumb.Name = "cb_fdThumb";
            this.cb_fdThumb.Size = new System.Drawing.Size(107, 23);
            this.cb_fdThumb.TabIndex = 22;
            this.cb_fdThumb.Tag = "FDTHUMB";
            this.cb_fdThumb.Text = "Show Thumbnails";
            this.cb_fdThumb.UseVisualStyleBackColor = false;
            this.cb_fdThumb.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_fdSortByDate
            // 
            this.cb_fdSortByDate.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_fdSortByDate.AutoSize = true;
            this.cb_fdSortByDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_fdSortByDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_fdSortByDate.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_fdSortByDate.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_fdSortByDate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_fdSortByDate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_fdSortByDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_fdSortByDate.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_fdSortByDate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_fdSortByDate.Location = new System.Drawing.Point(6, 448);
            this.cb_fdSortByDate.Name = "cb_fdSortByDate";
            this.cb_fdSortByDate.Size = new System.Drawing.Size(203, 23);
            this.cb_fdSortByDate.TabIndex = 21;
            this.cb_fdSortByDate.Tag = "FDSORT";
            this.cb_fdSortByDate.Text = "Sort Items by Creation DateTime";
            this.cb_fdSortByDate.UseVisualStyleBackColor = false;
            this.cb_fdSortByDate.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // label_cb_fileDisplay
            // 
            this.label_cb_fileDisplay.AutoSize = true;
            this.label_cb_fileDisplay.BackColor = System.Drawing.Color.Transparent;
            this.label_cb_fileDisplay.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_cb_fileDisplay.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label_cb_fileDisplay.Location = new System.Drawing.Point(6, 429);
            this.label_cb_fileDisplay.Name = "label_cb_fileDisplay";
            this.label_cb_fileDisplay.Size = new System.Drawing.Size(96, 16);
            this.label_cb_fileDisplay.TabIndex = 0;
            this.label_cb_fileDisplay.Text = "File Display:";
            // 
            // cb_tvIndex
            // 
            this.cb_tvIndex.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_tvIndex.AutoSize = true;
            this.cb_tvIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_tvIndex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_tvIndex.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_tvIndex.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_tvIndex.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_tvIndex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_tvIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_tvIndex.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_tvIndex.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_tvIndex.Location = new System.Drawing.Point(6, 403);
            this.cb_tvIndex.Name = "cb_tvIndex";
            this.cb_tvIndex.Size = new System.Drawing.Size(107, 23);
            this.cb_tvIndex.TabIndex = 20;
            this.cb_tvIndex.Tag = "TVINDEX";
            this.cb_tvIndex.Text = "Show Item Index";
            this.cb_tvIndex.UseVisualStyleBackColor = false;
            this.cb_tvIndex.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_tvSortByDate
            // 
            this.cb_tvSortByDate.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_tvSortByDate.AutoSize = true;
            this.cb_tvSortByDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_tvSortByDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_tvSortByDate.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_tvSortByDate.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_tvSortByDate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_tvSortByDate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_tvSortByDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_tvSortByDate.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_tvSortByDate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_tvSortByDate.Location = new System.Drawing.Point(6, 377);
            this.cb_tvSortByDate.Name = "cb_tvSortByDate";
            this.cb_tvSortByDate.Size = new System.Drawing.Size(203, 23);
            this.cb_tvSortByDate.TabIndex = 19;
            this.cb_tvSortByDate.Tag = "TVSORT";
            this.cb_tvSortByDate.Text = "Sort Items by Creation DateTime";
            this.cb_tvSortByDate.UseVisualStyleBackColor = false;
            this.cb_tvSortByDate.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // label_cb_treeView
            // 
            this.label_cb_treeView.AutoSize = true;
            this.label_cb_treeView.BackColor = System.Drawing.Color.Transparent;
            this.label_cb_treeView.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_cb_treeView.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label_cb_treeView.Location = new System.Drawing.Point(6, 358);
            this.label_cb_treeView.Name = "label_cb_treeView";
            this.label_cb_treeView.Size = new System.Drawing.Size(80, 16);
            this.label_cb_treeView.TabIndex = 0;
            this.label_cb_treeView.Text = "TreeView:";
            // 
            // label_cb_enable
            // 
            this.label_cb_enable.AutoSize = true;
            this.label_cb_enable.BackColor = System.Drawing.Color.Transparent;
            this.label_cb_enable.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_cb_enable.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label_cb_enable.Location = new System.Drawing.Point(6, 112);
            this.label_cb_enable.Name = "label_cb_enable";
            this.label_cb_enable.Size = new System.Drawing.Size(62, 16);
            this.label_cb_enable.TabIndex = 0;
            this.label_cb_enable.Text = "Enable:";
            // 
            // label_cb_auto
            // 
            this.label_cb_auto.AutoSize = true;
            this.label_cb_auto.BackColor = System.Drawing.Color.Transparent;
            this.label_cb_auto.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_cb_auto.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label_cb_auto.Location = new System.Drawing.Point(6, 261);
            this.label_cb_auto.Name = "label_cb_auto";
            this.label_cb_auto.Size = new System.Drawing.Size(47, 16);
            this.label_cb_auto.TabIndex = 0;
            this.label_cb_auto.Text = "Auto:";
            // 
            // label_cb_hideWindow
            // 
            this.label_cb_hideWindow.AutoSize = true;
            this.label_cb_hideWindow.BackColor = System.Drawing.Color.Transparent;
            this.label_cb_hideWindow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_cb_hideWindow.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label_cb_hideWindow.Location = new System.Drawing.Point(6, 41);
            this.label_cb_hideWindow.Name = "label_cb_hideWindow";
            this.label_cb_hideWindow.Size = new System.Drawing.Size(204, 16);
            this.label_cb_hideWindow.TabIndex = 0;
            this.label_cb_hideWindow.Text = "Hide FapMap\'s Window On:";
            // 
            // cb_logs
            // 
            this.cb_logs.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_logs.AutoSize = true;
            this.cb_logs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_logs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_logs.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_logs.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_logs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_logs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_logs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_logs.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_logs.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_logs.Location = new System.Drawing.Point(6, 131);
            this.cb_logs.Name = "cb_logs";
            this.cb_logs.Size = new System.Drawing.Size(59, 23);
            this.cb_logs.TabIndex = 11;
            this.cb_logs.Tag = "ENABLELOGS";
            this.cb_logs.Text = "Logging";
            this.cb_logs.UseVisualStyleBackColor = false;
            this.cb_logs.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_openOutside
            // 
            this.cb_openOutside.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_openOutside.AutoSize = true;
            this.cb_openOutside.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_openOutside.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_openOutside.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_openOutside.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_openOutside.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_openOutside.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_openOutside.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_openOutside.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_openOutside.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_openOutside.Location = new System.Drawing.Point(6, 235);
            this.cb_openOutside.Name = "cb_openOutside";
            this.cb_openOutside.Size = new System.Drawing.Size(185, 23);
            this.cb_openOutside.TabIndex = 15;
            this.cb_openOutside.Tag = "ENABLEOUTSIDE";
            this.cb_openOutside.Text = "Opening Files Outside FapMap";
            this.cb_openOutside.UseVisualStyleBackColor = false;
            this.cb_openOutside.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_fileDisplay
            // 
            this.cb_fileDisplay.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_fileDisplay.AutoSize = true;
            this.cb_fileDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_fileDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_fileDisplay.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_fileDisplay.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_fileDisplay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_fileDisplay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_fileDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_fileDisplay.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_fileDisplay.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_fileDisplay.Location = new System.Drawing.Point(6, 209);
            this.cb_fileDisplay.Name = "cb_fileDisplay";
            this.cb_fileDisplay.Size = new System.Drawing.Size(89, 23);
            this.cb_fileDisplay.TabIndex = 14;
            this.cb_fileDisplay.Tag = "ENABLEFILEDISPLAY";
            this.cb_fileDisplay.Text = "File Display";
            this.cb_fileDisplay.UseVisualStyleBackColor = false;
            this.cb_fileDisplay.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_trackbar
            // 
            this.cb_trackbar.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_trackbar.AutoSize = true;
            this.cb_trackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_trackbar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_trackbar.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_trackbar.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_trackbar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_trackbar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_trackbar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_trackbar.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_trackbar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_trackbar.Location = new System.Drawing.Point(6, 183);
            this.cb_trackbar.Name = "cb_trackbar";
            this.cb_trackbar.Size = new System.Drawing.Size(155, 23);
            this.cb_trackbar.TabIndex = 13;
            this.cb_trackbar.Tag = "ENABLETRACKBAR";
            this.cb_trackbar.Text = "Trackbar for GIF Viewer";
            this.cb_trackbar.UseVisualStyleBackColor = false;
            this.cb_trackbar.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_autoPause
            // 
            this.cb_autoPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_autoPause.AutoSize = true;
            this.cb_autoPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_autoPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_autoPause.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_autoPause.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_autoPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_autoPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_autoPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_autoPause.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_autoPause.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_autoPause.Location = new System.Drawing.Point(6, 332);
            this.cb_autoPause.Name = "cb_autoPause";
            this.cb_autoPause.Size = new System.Drawing.Size(125, 23);
            this.cb_autoPause.TabIndex = 18;
            this.cb_autoPause.Tag = "AUTOPAUSE";
            this.cb_autoPause.Text = "Pause Video Player";
            this.cb_autoPause.UseVisualStyleBackColor = false;
            this.cb_autoPause.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_autoPlay
            // 
            this.cb_autoPlay.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_autoPlay.AutoSize = true;
            this.cb_autoPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_autoPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_autoPlay.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_autoPlay.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_autoPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_autoPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_autoPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_autoPlay.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_autoPlay.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_autoPlay.Location = new System.Drawing.Point(6, 306);
            this.cb_autoPlay.Name = "cb_autoPlay";
            this.cb_autoPlay.Size = new System.Drawing.Size(119, 23);
            this.cb_autoPlay.TabIndex = 17;
            this.cb_autoPlay.Tag = "AUTOPLAY";
            this.cb_autoPlay.Text = "Play Video Player";
            this.cb_autoPlay.UseVisualStyleBackColor = false;
            this.cb_autoPlay.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_autoHideMedia
            // 
            this.cb_autoHideMedia.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_autoHideMedia.AutoSize = true;
            this.cb_autoHideMedia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_autoHideMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_autoHideMedia.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_autoHideMedia.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_autoHideMedia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_autoHideMedia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_autoHideMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_autoHideMedia.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_autoHideMedia.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_autoHideMedia.Location = new System.Drawing.Point(6, 280);
            this.cb_autoHideMedia.Name = "cb_autoHideMedia";
            this.cb_autoHideMedia.Size = new System.Drawing.Size(125, 23);
            this.cb_autoHideMedia.TabIndex = 16;
            this.cb_autoHideMedia.Tag = "AUTOHIDE";
            this.cb_autoHideMedia.Text = "Hide Media Players";
            this.cb_autoHideMedia.UseVisualStyleBackColor = false;
            this.cb_autoHideMedia.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_media
            // 
            this.cb_media.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_media.AutoSize = true;
            this.cb_media.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_media.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_media.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_media.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_media.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_media.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_media.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_media.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_media.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_media.Location = new System.Drawing.Point(6, 157);
            this.cb_media.Name = "cb_media";
            this.cb_media.Size = new System.Drawing.Size(95, 23);
            this.cb_media.TabIndex = 12;
            this.cb_media.Tag = "ENABLEPLAYERS";
            this.cb_media.Text = "Media Players";
            this.cb_media.UseVisualStyleBackColor = false;
            this.cb_media.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_focusHide
            // 
            this.cb_focusHide.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_focusHide.AutoSize = true;
            this.cb_focusHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_focusHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_focusHide.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_focusHide.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_focusHide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_focusHide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_focusHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_focusHide.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_focusHide.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_focusHide.Location = new System.Drawing.Point(6, 86);
            this.cb_focusHide.Name = "cb_focusHide";
            this.cb_focusHide.Size = new System.Drawing.Size(77, 23);
            this.cb_focusHide.TabIndex = 10;
            this.cb_focusHide.Tag = "FOCUSHIDE";
            this.cb_focusHide.Text = "Lost Focus";
            this.cb_focusHide.UseVisualStyleBackColor = false;
            this.cb_focusHide.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // label_cb
            // 
            this.label_cb.AutoSize = true;
            this.label_cb.BackColor = System.Drawing.Color.Transparent;
            this.label_cb.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_cb.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label_cb.Location = new System.Drawing.Point(6, 6);
            this.label_cb.Name = "label_cb";
            this.label_cb.Size = new System.Drawing.Size(219, 32);
            this.label_cb.TabIndex = 0;
            this.label_cb.Text = "CHECKBOXES";
            // 
            // cb_hideOnX
            // 
            this.cb_hideOnX.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_hideOnX.AutoSize = true;
            this.cb_hideOnX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cb_hideOnX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_hideOnX.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.cb_hideOnX.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_hideOnX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_hideOnX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_hideOnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_hideOnX.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_hideOnX.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_hideOnX.Location = new System.Drawing.Point(6, 60);
            this.cb_hideOnX.Name = "cb_hideOnX";
            this.cb_hideOnX.Size = new System.Drawing.Size(35, 23);
            this.cb_hideOnX.TabIndex = 9;
            this.cb_hideOnX.Tag = "HIDEONX";
            this.cb_hideOnX.Text = "[X]";
            this.cb_hideOnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_hideOnX.UseVisualStyleBackColor = false;
            this.cb_hideOnX.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // fapmap_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg1;
            this.ClientSize = new System.Drawing.Size(824, 741);
            this.Controls.Add(this.panel_cb);
            this.Controls.Add(this.panel_browser);
            this.Controls.Add(this.panel_passwd);
            this.Controls.Add(this.panel_info);
            this.Controls.Add(this.panel_txt);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 400);
            this.Name = "fapmap_settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - Settings";
            this.Load += new System.EventHandler(this.fapmap_settings_Load);
            this.panel_info.ResumeLayout(false);
            this.panel_info.PerformLayout();
            this.txt_outputBorder.ResumeLayout(false);
            this.panel_browser.ResumeLayout(false);
            this.panel_browser.PerformLayout();
            this.txt_passwdsBorder.ResumeLayout(false);
            this.panel_txt.ResumeLayout(false);
            this.panel_txt.PerformLayout();
            this.panel_passwd.ResumeLayout(false);
            this.panel_passwd.PerformLayout();
            this.panel_cb.ResumeLayout(false);
            this.panel_cb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txt_size;
        private System.Windows.Forms.Panel panel_info;
        private System.Windows.Forms.Panel panel_browser;
        private System.Windows.Forms.TextBox txt_newPasswd;
        private System.Windows.Forms.ListBox txt_passwds;
        private System.Windows.Forms.Panel txt_passwdsBorder;
        private System.Windows.Forms.Button btn_addPasswd;
        private System.Windows.Forms.Label label_passwd;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.TextBox txt_wbURL;
        private System.Windows.Forms.Label label_wb;
        private System.Windows.Forms.Label label_gallery;
        private System.Windows.Forms.Label label_browser;
        private System.Windows.Forms.Panel panel_txt;
        private System.Windows.Forms.Panel panel_passwd;
        private System.Windows.Forms.CheckBox cb_noZero;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Button btn_editINI;
        private System.Windows.Forms.Button btn_getinfo;
        private System.Windows.Forms.Panel panel_cb;
        private System.Windows.Forms.Label label_cb;
        private System.Windows.Forms.CheckBox cb_hideOnX;
        private System.Windows.Forms.CheckBox cb_media;
        private System.Windows.Forms.CheckBox cb_focusHide;
        private System.Windows.Forms.CheckBox cb_autoHideMedia;
        private System.Windows.Forms.CheckBox cb_autoPlay;
        private System.Windows.Forms.CheckBox cb_autoPause;
        private System.Windows.Forms.CheckBox cb_trackbar;
        private System.Windows.Forms.CheckBox cb_fileDisplay;
        private System.Windows.Forms.CheckBox cb_openOutside;
        private System.Windows.Forms.RadioButton rb_opera;
        private System.Windows.Forms.RadioButton rb_chrome;
        private System.Windows.Forms.RadioButton rb_firefox;
        private System.Windows.Forms.CheckBox cb_logs;
        private System.Windows.Forms.Label label_cb_hideWindow;
        private System.Windows.Forms.Label label_cb_enable;
        private System.Windows.Forms.Label label_cb_auto;
        private System.Windows.Forms.Label label_cb_treeView;
        private System.Windows.Forms.CheckBox cb_tvSortByDate;
        private System.Windows.Forms.CheckBox cb_tvIndex;
        private System.Windows.Forms.RichTextBox txt_output;
        private System.Windows.Forms.TextBox txt_gifDelay;
        private System.Windows.Forms.Label label_gifDelay;
        private System.Windows.Forms.Panel txt_outputBorder;
        private System.Windows.Forms.CheckBox cb_fdThumb;
        private System.Windows.Forms.CheckBox cb_fdSortByDate;
        private System.Windows.Forms.Label label_cb_fileDisplay;
    }
}