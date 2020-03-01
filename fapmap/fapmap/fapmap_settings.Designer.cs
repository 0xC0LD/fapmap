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
            this.btn_getinfo = new System.Windows.Forms.Button();
            this.label_info = new System.Windows.Forms.Label();
            this.cb_noZero = new System.Windows.Forms.CheckBox();
            this.txt_countBorder = new System.Windows.Forms.Panel();
            this.txt_count = new System.Windows.Forms.RichTextBox();
            this.label_gallery = new System.Windows.Forms.Label();
            this.btn_editINI = new System.Windows.Forms.Button();
            this.panel_browser = new System.Windows.Forms.Panel();
            this.rb_chrome = new System.Windows.Forms.RadioButton();
            this.rb_firefox = new System.Windows.Forms.RadioButton();
            this.rb_opera = new System.Windows.Forms.RadioButton();
            this.pb_opera = new System.Windows.Forms.PictureBox();
            this.pb_firefox = new System.Windows.Forms.PictureBox();
            this.pb_chrome = new System.Windows.Forms.PictureBox();
            this.label_browser = new System.Windows.Forms.Label();
            this.txt_newPasswd = new System.Windows.Forms.TextBox();
            this.txt_passwds = new System.Windows.Forms.ListBox();
            this.txt_passwdsBorder = new System.Windows.Forms.Panel();
            this.btn_addPasswd = new System.Windows.Forms.Button();
            this.label_passwd = new System.Windows.Forms.Label();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.txt_wbURL = new System.Windows.Forms.TextBox();
            this.label_wb = new System.Windows.Forms.Label();
            this.panel_wb = new System.Windows.Forms.Panel();
            this.panel_passwd = new System.Windows.Forms.Panel();
            this.panel_cb = new System.Windows.Forms.Panel();
            this.cb_openOutside = new System.Windows.Forms.CheckBox();
            this.cb_fileDisplay = new System.Windows.Forms.CheckBox();
            this.cb_trackbar = new System.Windows.Forms.CheckBox();
            this.cb_autoPause = new System.Windows.Forms.CheckBox();
            this.cb_autoPlay = new System.Windows.Forms.CheckBox();
            this.cb_autoHideMedia = new System.Windows.Forms.CheckBox();
            this.cb_media = new System.Windows.Forms.CheckBox();
            this.cb_focusHide = new System.Windows.Forms.CheckBox();
            this.cb_label = new System.Windows.Forms.Label();
            this.cb_hideOnX = new System.Windows.Forms.CheckBox();
            this.label_note = new System.Windows.Forms.Label();
            this.panel_info.SuspendLayout();
            this.txt_countBorder.SuspendLayout();
            this.panel_browser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_opera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_firefox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_chrome)).BeginInit();
            this.txt_passwdsBorder.SuspendLayout();
            this.panel_wb.SuspendLayout();
            this.panel_passwd.SuspendLayout();
            this.panel_cb.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_size
            // 
            this.txt_size.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_size.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_size.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_size.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txt_size.Location = new System.Drawing.Point(3, 60);
            this.txt_size.Name = "txt_size";
            this.txt_size.ReadOnly = true;
            this.txt_size.Size = new System.Drawing.Size(326, 26);
            this.txt_size.TabIndex = 133;
            this.txt_size.Text = "00,00 GB (000000000000 bytes)";
            this.txt_size.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gallerySize_KeyDown);
            // 
            // panel_info
            // 
            this.panel_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel_info.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.panel_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_info.Controls.Add(this.btn_getinfo);
            this.panel_info.Controls.Add(this.label_info);
            this.panel_info.Controls.Add(this.cb_noZero);
            this.panel_info.Controls.Add(this.txt_countBorder);
            this.panel_info.Controls.Add(this.txt_size);
            this.panel_info.Controls.Add(this.label_gallery);
            this.panel_info.Location = new System.Drawing.Point(422, 72);
            this.panel_info.Name = "panel_info";
            this.panel_info.Size = new System.Drawing.Size(334, 462);
            this.panel_info.TabIndex = 192;
            // 
            // btn_getinfo
            // 
            this.btn_getinfo.BackColor = System.Drawing.Color.Transparent;
            this.btn_getinfo.BackgroundImage = global::fapmap.Properties.Resources.arrow_down;
            this.btn_getinfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_getinfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_getinfo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_getinfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_getinfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_getinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_getinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_getinfo.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_getinfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_getinfo.Location = new System.Drawing.Point(3, 28);
            this.btn_getinfo.Name = "btn_getinfo";
            this.btn_getinfo.Size = new System.Drawing.Size(30, 30);
            this.btn_getinfo.TabIndex = 217;
            this.HelpBalloon.SetToolTip(this.btn_getinfo, "Add A Password");
            this.btn_getinfo.UseVisualStyleBackColor = false;
            this.btn_getinfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.count_button_MouseClick);
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
            this.cb_noZero.TabIndex = 214;
            this.HelpBalloon.SetToolTip(this.cb_noZero, "Don\'t output file types that have a 0 count...");
            this.cb_noZero.UseVisualStyleBackColor = false;
            // 
            // txt_countBorder
            // 
            this.txt_countBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_countBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_countBorder.Controls.Add(this.txt_count);
            this.txt_countBorder.Location = new System.Drawing.Point(3, 88);
            this.txt_countBorder.Name = "txt_countBorder";
            this.txt_countBorder.Size = new System.Drawing.Size(326, 369);
            this.txt_countBorder.TabIndex = 213;
            // 
            // txt_count
            // 
            this.txt_count.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_count.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_count.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_count.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_count.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txt_count.Location = new System.Drawing.Point(0, 0);
            this.txt_count.Name = "txt_count";
            this.txt_count.ReadOnly = true;
            this.txt_count.Size = new System.Drawing.Size(324, 367);
            this.txt_count.TabIndex = 212;
            this.txt_count.Text = "";
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
            this.label_gallery.TabIndex = 211;
            this.label_gallery.Text = "GALLERY:";
            // 
            // btn_editINI
            // 
            this.btn_editINI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editINI.BackColor = System.Drawing.Color.Transparent;
            this.btn_editINI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_editINI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_editINI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_editINI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_editINI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editINI.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_editINI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_editINI.Location = new System.Drawing.Point(200, 434);
            this.btn_editINI.Name = "btn_editINI";
            this.btn_editINI.Size = new System.Drawing.Size(36, 23);
            this.btn_editINI.TabIndex = 216;
            this.btn_editINI.Text = ".ini";
            this.HelpBalloon.SetToolTip(this.btn_editINI, "Edit Settings File");
            this.btn_editINI.UseVisualStyleBackColor = false;
            this.btn_editINI.MouseClick += new System.Windows.Forms.MouseEventHandler(this.edit_MouseClick);
            // 
            // panel_browser
            // 
            this.panel_browser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel_browser.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.panel_browser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_browser.Controls.Add(this.rb_chrome);
            this.panel_browser.Controls.Add(this.rb_firefox);
            this.panel_browser.Controls.Add(this.rb_opera);
            this.panel_browser.Controls.Add(this.pb_opera);
            this.panel_browser.Controls.Add(this.pb_firefox);
            this.panel_browser.Controls.Add(this.pb_chrome);
            this.panel_browser.Controls.Add(this.label_browser);
            this.panel_browser.Location = new System.Drawing.Point(15, 72);
            this.panel_browser.Name = "panel_browser";
            this.panel_browser.Size = new System.Drawing.Size(154, 137);
            this.panel_browser.TabIndex = 196;
            // 
            // rb_chrome
            // 
            this.rb_chrome.AutoSize = true;
            this.rb_chrome.BackColor = System.Drawing.Color.Transparent;
            this.rb_chrome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_chrome.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_chrome.Location = new System.Drawing.Point(41, 30);
            this.rb_chrome.Name = "rb_chrome";
            this.rb_chrome.Size = new System.Drawing.Size(88, 26);
            this.rb_chrome.TabIndex = 215;
            this.rb_chrome.TabStop = true;
            this.rb_chrome.Text = "CHROME";
            this.rb_chrome.UseVisualStyleBackColor = false;
            this.rb_chrome.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rb_MouseClick);
            // 
            // rb_firefox
            // 
            this.rb_firefox.AutoSize = true;
            this.rb_firefox.BackColor = System.Drawing.Color.Transparent;
            this.rb_firefox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_firefox.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_firefox.Location = new System.Drawing.Point(41, 64);
            this.rb_firefox.Name = "rb_firefox";
            this.rb_firefox.Size = new System.Drawing.Size(98, 26);
            this.rb_firefox.TabIndex = 214;
            this.rb_firefox.TabStop = true;
            this.rb_firefox.Text = "FIREFOX";
            this.rb_firefox.UseVisualStyleBackColor = false;
            this.rb_firefox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rb_MouseClick);
            // 
            // rb_opera
            // 
            this.rb_opera.AutoSize = true;
            this.rb_opera.BackColor = System.Drawing.Color.Transparent;
            this.rb_opera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_opera.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_opera.Location = new System.Drawing.Point(41, 98);
            this.rb_opera.Name = "rb_opera";
            this.rb_opera.Size = new System.Drawing.Size(78, 26);
            this.rb_opera.TabIndex = 213;
            this.rb_opera.TabStop = true;
            this.rb_opera.Text = "OPERA";
            this.rb_opera.UseVisualStyleBackColor = false;
            this.rb_opera.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rb_MouseClick);
            // 
            // pb_opera
            // 
            this.pb_opera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pb_opera.Image = global::fapmap.Properties.Resources.browser_opera;
            this.pb_opera.Location = new System.Drawing.Point(3, 98);
            this.pb_opera.Name = "pb_opera";
            this.pb_opera.Size = new System.Drawing.Size(32, 32);
            this.pb_opera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_opera.TabIndex = 199;
            this.pb_opera.TabStop = false;
            // 
            // pb_firefox
            // 
            this.pb_firefox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pb_firefox.Image = global::fapmap.Properties.Resources.browser_firefox;
            this.pb_firefox.Location = new System.Drawing.Point(3, 62);
            this.pb_firefox.Name = "pb_firefox";
            this.pb_firefox.Size = new System.Drawing.Size(32, 32);
            this.pb_firefox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_firefox.TabIndex = 198;
            this.pb_firefox.TabStop = false;
            // 
            // pb_chrome
            // 
            this.pb_chrome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pb_chrome.Image = global::fapmap.Properties.Resources.browser_chrome;
            this.pb_chrome.Location = new System.Drawing.Point(3, 26);
            this.pb_chrome.Name = "pb_chrome";
            this.pb_chrome.Size = new System.Drawing.Size(32, 32);
            this.pb_chrome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_chrome.TabIndex = 197;
            this.pb_chrome.TabStop = false;
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
            this.label_browser.TabIndex = 212;
            this.label_browser.Text = "BROWSERS:";
            // 
            // txt_newPasswd
            // 
            this.txt_newPasswd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_newPasswd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_newPasswd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_newPasswd.ForeColor = System.Drawing.Color.Teal;
            this.txt_newPasswd.Location = new System.Drawing.Point(3, 30);
            this.txt_newPasswd.Name = "txt_newPasswd";
            this.txt_newPasswd.Size = new System.Drawing.Size(124, 21);
            this.txt_newPasswd.TabIndex = 198;
            this.txt_newPasswd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.newPassword_KeyDown);
            // 
            // txt_passwds
            // 
            this.txt_passwds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_passwds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_passwds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_passwds.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.txt_passwds.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_passwds.ForeColor = System.Drawing.Color.Teal;
            this.txt_passwds.FormattingEnabled = true;
            this.txt_passwds.ItemHeight = 22;
            this.txt_passwds.Location = new System.Drawing.Point(0, 0);
            this.txt_passwds.Name = "txt_passwds";
            this.txt_passwds.Size = new System.Drawing.Size(144, 259);
            this.txt_passwds.TabIndex = 199;
            this.HelpBalloon.SetToolTip(this.txt_passwds, "Double Click To Remove Selected Password");
            this.txt_passwds.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.passwordsList_DrawItem);
            this.txt_passwds.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.passwordsList_MeasureItem);
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
            this.txt_passwdsBorder.Size = new System.Drawing.Size(146, 261);
            this.txt_passwdsBorder.TabIndex = 200;
            // 
            // btn_addPasswd
            // 
            this.btn_addPasswd.BackColor = System.Drawing.Color.Transparent;
            this.btn_addPasswd.BackgroundImage = global::fapmap.Properties.Resources.arrow_down;
            this.btn_addPasswd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addPasswd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addPasswd.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_addPasswd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_addPasswd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_addPasswd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addPasswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_addPasswd.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_addPasswd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_addPasswd.Location = new System.Drawing.Point(129, 30);
            this.btn_addPasswd.Name = "btn_addPasswd";
            this.btn_addPasswd.Size = new System.Drawing.Size(20, 21);
            this.btn_addPasswd.TabIndex = 201;
            this.HelpBalloon.SetToolTip(this.btn_addPasswd, "Add A Password");
            this.btn_addPasswd.UseVisualStyleBackColor = false;
            this.btn_addPasswd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pass_add_MouseClick);
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
            this.label_passwd.TabIndex = 202;
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
            this.txt_wbURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_wbURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_wbURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_wbURL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_wbURL.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.txt_wbURL.Location = new System.Drawing.Point(7, 31);
            this.txt_wbURL.Name = "txt_wbURL";
            this.txt_wbURL.Size = new System.Drawing.Size(581, 21);
            this.txt_wbURL.TabIndex = 207;
            this.txt_wbURL.Text = "https://www.google.com";
            this.txt_wbURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.wb_url_KeyDown);
            // 
            // label_wb
            // 
            this.label_wb.AutoSize = true;
            this.label_wb.BackColor = System.Drawing.Color.Transparent;
            this.label_wb.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_wb.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label_wb.Location = new System.Drawing.Point(3, 5);
            this.label_wb.Name = "label_wb";
            this.label_wb.Size = new System.Drawing.Size(193, 23);
            this.label_wb.TabIndex = 209;
            this.label_wb.Text = "START WEBSITE:";
            // 
            // panel_wb
            // 
            this.panel_wb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_wb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel_wb.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.panel_wb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_wb.Controls.Add(this.txt_wbURL);
            this.panel_wb.Controls.Add(this.label_wb);
            this.panel_wb.Location = new System.Drawing.Point(15, 8);
            this.panel_wb.Name = "panel_wb";
            this.panel_wb.Size = new System.Drawing.Size(593, 58);
            this.panel_wb.TabIndex = 213;
            // 
            // panel_passwd
            // 
            this.panel_passwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_passwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel_passwd.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.panel_passwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_passwd.Controls.Add(this.label_passwd);
            this.panel_passwd.Controls.Add(this.txt_newPasswd);
            this.panel_passwd.Controls.Add(this.txt_passwdsBorder);
            this.panel_passwd.Controls.Add(this.btn_addPasswd);
            this.panel_passwd.Location = new System.Drawing.Point(15, 215);
            this.panel_passwd.Name = "panel_passwd";
            this.panel_passwd.Size = new System.Drawing.Size(154, 319);
            this.panel_passwd.TabIndex = 215;
            // 
            // panel_cb
            // 
            this.panel_cb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_cb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel_cb.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.panel_cb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_cb.Controls.Add(this.cb_openOutside);
            this.panel_cb.Controls.Add(this.btn_editINI);
            this.panel_cb.Controls.Add(this.cb_fileDisplay);
            this.panel_cb.Controls.Add(this.cb_trackbar);
            this.panel_cb.Controls.Add(this.cb_autoPause);
            this.panel_cb.Controls.Add(this.cb_autoPlay);
            this.panel_cb.Controls.Add(this.cb_autoHideMedia);
            this.panel_cb.Controls.Add(this.cb_media);
            this.panel_cb.Controls.Add(this.cb_focusHide);
            this.panel_cb.Controls.Add(this.cb_label);
            this.panel_cb.Controls.Add(this.cb_hideOnX);
            this.panel_cb.Location = new System.Drawing.Point(175, 72);
            this.panel_cb.Name = "panel_cb";
            this.panel_cb.Size = new System.Drawing.Size(241, 462);
            this.panel_cb.TabIndex = 216;
            // 
            // cb_openOutside
            // 
            this.cb_openOutside.AutoSize = true;
            this.cb_openOutside.BackColor = System.Drawing.Color.Transparent;
            this.cb_openOutside.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_openOutside.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_openOutside.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_openOutside.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_openOutside.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_openOutside.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_openOutside.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_openOutside.Location = new System.Drawing.Point(9, 233);
            this.cb_openOutside.Name = "cb_openOutside";
            this.cb_openOutside.Size = new System.Drawing.Size(176, 17);
            this.cb_openOutside.TabIndex = 220;
            this.cb_openOutside.Tag = "ENABLEOUTSIDE";
            this.cb_openOutside.Text = "Open files outside fapmap";
            this.cb_openOutside.UseVisualStyleBackColor = false;
            this.cb_openOutside.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_fileDisplay
            // 
            this.cb_fileDisplay.AutoSize = true;
            this.cb_fileDisplay.BackColor = System.Drawing.Color.Transparent;
            this.cb_fileDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_fileDisplay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_fileDisplay.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_fileDisplay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_fileDisplay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_fileDisplay.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_fileDisplay.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_fileDisplay.Location = new System.Drawing.Point(9, 210);
            this.cb_fileDisplay.Name = "cb_fileDisplay";
            this.cb_fileDisplay.Size = new System.Drawing.Size(140, 17);
            this.cb_fileDisplay.TabIndex = 219;
            this.cb_fileDisplay.Tag = "ENABLEFILEDISPLAY";
            this.cb_fileDisplay.Text = "Enable file display";
            this.cb_fileDisplay.UseVisualStyleBackColor = false;
            this.cb_fileDisplay.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_trackbar
            // 
            this.cb_trackbar.AutoSize = true;
            this.cb_trackbar.BackColor = System.Drawing.Color.Transparent;
            this.cb_trackbar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_trackbar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_trackbar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_trackbar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_trackbar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_trackbar.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_trackbar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_trackbar.Location = new System.Drawing.Point(9, 187);
            this.cb_trackbar.Name = "cb_trackbar";
            this.cb_trackbar.Size = new System.Drawing.Size(206, 17);
            this.cb_trackbar.TabIndex = 218;
            this.cb_trackbar.Tag = "ENABLETRACKBAR";
            this.cb_trackbar.Text = "Enable trackbar for gif viewer";
            this.cb_trackbar.UseVisualStyleBackColor = false;
            this.cb_trackbar.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_autoPause
            // 
            this.cb_autoPause.AutoSize = true;
            this.cb_autoPause.BackColor = System.Drawing.Color.Transparent;
            this.cb_autoPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_autoPause.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPause.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPause.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_autoPause.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_autoPause.Location = new System.Drawing.Point(9, 164);
            this.cb_autoPause.Name = "cb_autoPause";
            this.cb_autoPause.Size = new System.Drawing.Size(164, 17);
            this.cb_autoPause.TabIndex = 217;
            this.cb_autoPause.Tag = "AUTOPAUSE";
            this.cb_autoPause.Text = "Auto pause video player";
            this.cb_autoPause.UseVisualStyleBackColor = false;
            this.cb_autoPause.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_autoPlay
            // 
            this.cb_autoPlay.AutoSize = true;
            this.cb_autoPlay.BackColor = System.Drawing.Color.Transparent;
            this.cb_autoPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_autoPlay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPlay.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPlay.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_autoPlay.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_autoPlay.Location = new System.Drawing.Point(9, 141);
            this.cb_autoPlay.Name = "cb_autoPlay";
            this.cb_autoPlay.Size = new System.Drawing.Size(158, 17);
            this.cb_autoPlay.TabIndex = 216;
            this.cb_autoPlay.Tag = "AUTOPLAY";
            this.cb_autoPlay.Text = "Auto play video player";
            this.cb_autoPlay.UseVisualStyleBackColor = false;
            this.cb_autoPlay.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_autoHideMedia
            // 
            this.cb_autoHideMedia.AutoSize = true;
            this.cb_autoHideMedia.BackColor = System.Drawing.Color.Transparent;
            this.cb_autoHideMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_autoHideMedia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoHideMedia.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoHideMedia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoHideMedia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoHideMedia.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_autoHideMedia.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_autoHideMedia.Location = new System.Drawing.Point(9, 118);
            this.cb_autoHideMedia.Name = "cb_autoHideMedia";
            this.cb_autoHideMedia.Size = new System.Drawing.Size(164, 17);
            this.cb_autoHideMedia.TabIndex = 215;
            this.cb_autoHideMedia.Tag = "AUTOHIDE";
            this.cb_autoHideMedia.Text = "Auto hide media players";
            this.cb_autoHideMedia.UseVisualStyleBackColor = false;
            this.cb_autoHideMedia.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_media
            // 
            this.cb_media.AutoSize = true;
            this.cb_media.BackColor = System.Drawing.Color.Transparent;
            this.cb_media.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_media.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_media.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_media.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_media.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_media.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_media.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_media.Location = new System.Drawing.Point(9, 95);
            this.cb_media.Name = "cb_media";
            this.cb_media.Size = new System.Drawing.Size(146, 17);
            this.cb_media.TabIndex = 214;
            this.cb_media.Tag = "ENABLEPLAYERS";
            this.cb_media.Text = "Enable media players";
            this.cb_media.UseVisualStyleBackColor = false;
            this.cb_media.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_focusHide
            // 
            this.cb_focusHide.AutoSize = true;
            this.cb_focusHide.BackColor = System.Drawing.Color.Transparent;
            this.cb_focusHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_focusHide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_focusHide.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_focusHide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_focusHide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_focusHide.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_focusHide.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_focusHide.Location = new System.Drawing.Point(9, 72);
            this.cb_focusHide.Name = "cb_focusHide";
            this.cb_focusHide.Size = new System.Drawing.Size(134, 17);
            this.cb_focusHide.TabIndex = 213;
            this.cb_focusHide.Tag = "FOCUSHIDE";
            this.cb_focusHide.Text = "Hide on lost focus";
            this.cb_focusHide.UseVisualStyleBackColor = false;
            this.cb_focusHide.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // cb_label
            // 
            this.cb_label.AutoSize = true;
            this.cb_label.BackColor = System.Drawing.Color.Transparent;
            this.cb_label.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_label.Location = new System.Drawing.Point(3, 6);
            this.cb_label.Name = "cb_label";
            this.cb_label.Size = new System.Drawing.Size(219, 32);
            this.cb_label.TabIndex = 212;
            this.cb_label.Text = "CHECKBOXES";
            // 
            // cb_hideOnX
            // 
            this.cb_hideOnX.AutoSize = true;
            this.cb_hideOnX.BackColor = System.Drawing.Color.Transparent;
            this.cb_hideOnX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_hideOnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_hideOnX.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_hideOnX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_hideOnX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_hideOnX.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_hideOnX.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cb_hideOnX.Location = new System.Drawing.Point(9, 49);
            this.cb_hideOnX.Name = "cb_hideOnX";
            this.cb_hideOnX.Size = new System.Drawing.Size(92, 17);
            this.cb_hideOnX.TabIndex = 10;
            this.cb_hideOnX.Tag = "HIDEONX";
            this.cb_hideOnX.Text = "Hide on [X]";
            this.cb_hideOnX.UseVisualStyleBackColor = false;
            this.cb_hideOnX.CheckedChanged += new System.EventHandler(this.cb_checkChanged);
            // 
            // label_note
            // 
            this.label_note.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_note.AutoSize = true;
            this.label_note.BackColor = System.Drawing.Color.Transparent;
            this.label_note.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_note.ForeColor = System.Drawing.Color.Turquoise;
            this.label_note.Location = new System.Drawing.Point(614, 9);
            this.label_note.Name = "label_note";
            this.label_note.Size = new System.Drawing.Size(139, 39);
            this.label_note.TabIndex = 217;
            this.label_note.Text = "You must restart\r\nfapmap for the changes\r\nto take effect";
            // 
            // fapmap_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg1;
            this.ClientSize = new System.Drawing.Size(765, 546);
            this.Controls.Add(this.label_note);
            this.Controls.Add(this.panel_cb);
            this.Controls.Add(this.panel_browser);
            this.Controls.Add(this.panel_passwd);
            this.Controls.Add(this.panel_info);
            this.Controls.Add(this.panel_wb);
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
            this.txt_countBorder.ResumeLayout(false);
            this.panel_browser.ResumeLayout(false);
            this.panel_browser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_opera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_firefox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_chrome)).EndInit();
            this.txt_passwdsBorder.ResumeLayout(false);
            this.panel_wb.ResumeLayout(false);
            this.panel_wb.PerformLayout();
            this.panel_passwd.ResumeLayout(false);
            this.panel_passwd.PerformLayout();
            this.panel_cb.ResumeLayout(false);
            this.panel_cb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_size;
        private System.Windows.Forms.Panel panel_info;
        private System.Windows.Forms.Panel panel_browser;
        private System.Windows.Forms.PictureBox pb_opera;
        private System.Windows.Forms.PictureBox pb_firefox;
        private System.Windows.Forms.PictureBox pb_chrome;
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
        private System.Windows.Forms.Panel panel_wb;
        private System.Windows.Forms.Panel panel_passwd;
        private System.Windows.Forms.Panel txt_countBorder;
        private System.Windows.Forms.RichTextBox txt_count;
        private System.Windows.Forms.CheckBox cb_noZero;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Button btn_editINI;
        private System.Windows.Forms.Button btn_getinfo;
        private System.Windows.Forms.Panel panel_cb;
        private System.Windows.Forms.Label cb_label;
        private System.Windows.Forms.CheckBox cb_hideOnX;
        private System.Windows.Forms.CheckBox cb_media;
        private System.Windows.Forms.CheckBox cb_focusHide;
        private System.Windows.Forms.CheckBox cb_autoHideMedia;
        private System.Windows.Forms.CheckBox cb_autoPlay;
        private System.Windows.Forms.CheckBox cb_autoPause;
        private System.Windows.Forms.CheckBox cb_trackbar;
        private System.Windows.Forms.CheckBox cb_fileDisplay;
        private System.Windows.Forms.CheckBox cb_openOutside;
        private System.Windows.Forms.Label label_note;
        private System.Windows.Forms.RadioButton rb_opera;
        private System.Windows.Forms.RadioButton rb_chrome;
        private System.Windows.Forms.RadioButton rb_firefox;
    }
}