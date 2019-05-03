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
            this.count_size = new System.Windows.Forms.TextBox();
            this.gallery_panel = new System.Windows.Forms.Panel();
            this.count_button = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Label();
            this.cb_count = new System.Windows.Forms.CheckBox();
            this.count_files_panel = new System.Windows.Forms.Panel();
            this.count_files = new System.Windows.Forms.RichTextBox();
            this.gallery_label = new System.Windows.Forms.Label();
            this.edit = new System.Windows.Forms.Button();
            this.browser_panel = new System.Windows.Forms.Panel();
            this.pictureBox_opera = new System.Windows.Forms.PictureBox();
            this.pictureBox_firefox = new System.Windows.Forms.PictureBox();
            this.pictureBox_chrome = new System.Windows.Forms.PictureBox();
            this.browser_opera = new System.Windows.Forms.CheckBox();
            this.browser_label = new System.Windows.Forms.Label();
            this.browser_firefox = new System.Windows.Forms.CheckBox();
            this.browser_chrome = new System.Windows.Forms.CheckBox();
            this.pass_new = new System.Windows.Forms.TextBox();
            this.pass_list = new System.Windows.Forms.ListBox();
            this.pass_list_panel = new System.Windows.Forms.Panel();
            this.pass_add = new System.Windows.Forms.Button();
            this.pass_label = new System.Windows.Forms.Label();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.wb_url = new System.Windows.Forms.TextBox();
            this.wb_label = new System.Windows.Forms.Label();
            this.wb_panel = new System.Windows.Forms.Panel();
            this.pass_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_openOutside = new System.Windows.Forms.CheckBox();
            this.cb_fileDisplay = new System.Windows.Forms.CheckBox();
            this.cb_trackbar = new System.Windows.Forms.CheckBox();
            this.cb_autoPause = new System.Windows.Forms.CheckBox();
            this.cb_autoPlay = new System.Windows.Forms.CheckBox();
            this.cb_autoHideMedia = new System.Windows.Forms.CheckBox();
            this.cb_media = new System.Windows.Forms.CheckBox();
            this.cb_focusHide = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_hideOnX = new System.Windows.Forms.CheckBox();
            this.restartNote = new System.Windows.Forms.Label();
            this.gallery_panel.SuspendLayout();
            this.count_files_panel.SuspendLayout();
            this.browser_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_opera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_firefox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_chrome)).BeginInit();
            this.pass_list_panel.SuspendLayout();
            this.wb_panel.SuspendLayout();
            this.pass_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // count_size
            // 
            this.count_size.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.count_size.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.count_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.count_size.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count_size.ForeColor = System.Drawing.Color.Silver;
            this.count_size.Location = new System.Drawing.Point(3, 60);
            this.count_size.Name = "count_size";
            this.count_size.ReadOnly = true;
            this.count_size.Size = new System.Drawing.Size(326, 26);
            this.count_size.TabIndex = 133;
            this.count_size.Text = "00,00 GB (000000000000 bytes)";
            this.count_size.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // gallery_panel
            // 
            this.gallery_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gallery_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gallery_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gallery_panel.Controls.Add(this.count_button);
            this.gallery_panel.Controls.Add(this.info);
            this.gallery_panel.Controls.Add(this.cb_count);
            this.gallery_panel.Controls.Add(this.count_files_panel);
            this.gallery_panel.Controls.Add(this.count_size);
            this.gallery_panel.Controls.Add(this.gallery_label);
            this.gallery_panel.Location = new System.Drawing.Point(172, 12);
            this.gallery_panel.Name = "gallery_panel";
            this.gallery_panel.Size = new System.Drawing.Size(334, 459);
            this.gallery_panel.TabIndex = 192;
            // 
            // count_button
            // 
            this.count_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.count_button.BackgroundImage = global::fapmap.Properties.Resources.image_button_arrow_down;
            this.count_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.count_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.count_button.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.count_button.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.count_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.count_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.count_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.count_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.count_button.ForeColor = System.Drawing.Color.DimGray;
            this.count_button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.count_button.Location = new System.Drawing.Point(3, 28);
            this.count_button.Name = "count_button";
            this.count_button.Size = new System.Drawing.Size(30, 30);
            this.count_button.TabIndex = 217;
            this.HelpBalloon.SetToolTip(this.count_button, "Add A Password");
            this.count_button.UseVisualStyleBackColor = false;
            this.count_button.Click += new System.EventHandler(this.getAll_Click);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.info.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.info.ForeColor = System.Drawing.Color.Silver;
            this.info.Location = new System.Drawing.Point(237, 40);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(25, 13);
            this.info.TabIndex = 215;
            this.info.Text = "...";
            // 
            // cb_count
            // 
            this.cb_count.AutoSize = true;
            this.cb_count.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_count.Checked = true;
            this.cb_count.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_count.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_count.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cb_count.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.cb_count.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_count.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_count.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_count.ForeColor = System.Drawing.Color.Snow;
            this.cb_count.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_count.Location = new System.Drawing.Point(1, 1);
            this.cb_count.Name = "cb_count";
            this.cb_count.Size = new System.Drawing.Size(15, 14);
            this.cb_count.TabIndex = 214;
            this.HelpBalloon.SetToolTip(this.cb_count, "Don\'t output files that have a 0 count...");
            this.cb_count.UseVisualStyleBackColor = false;
            // 
            // count_files_panel
            // 
            this.count_files_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.count_files_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.count_files_panel.Controls.Add(this.count_files);
            this.count_files_panel.Location = new System.Drawing.Point(3, 88);
            this.count_files_panel.Name = "count_files_panel";
            this.count_files_panel.Size = new System.Drawing.Size(326, 366);
            this.count_files_panel.TabIndex = 213;
            // 
            // count_files
            // 
            this.count_files.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.count_files.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.count_files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.count_files.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.count_files.ForeColor = System.Drawing.Color.Silver;
            this.count_files.Location = new System.Drawing.Point(0, 0);
            this.count_files.Name = "count_files";
            this.count_files.ReadOnly = true;
            this.count_files.Size = new System.Drawing.Size(324, 364);
            this.count_files.TabIndex = 212;
            this.count_files.Text = "";
            // 
            // gallery_label
            // 
            this.gallery_label.AutoSize = true;
            this.gallery_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.gallery_label.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gallery_label.ForeColor = System.Drawing.Color.Silver;
            this.gallery_label.Location = new System.Drawing.Point(39, 14);
            this.gallery_label.Name = "gallery_label";
            this.gallery_label.Size = new System.Drawing.Size(208, 42);
            this.gallery_label.TabIndex = 211;
            this.gallery_label.Text = "GALLERY:";
            // 
            // edit
            // 
            this.edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.edit.ForeColor = System.Drawing.Color.Silver;
            this.edit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.edit.Location = new System.Drawing.Point(200, 431);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(36, 23);
            this.edit.TabIndex = 216;
            this.edit.Text = ".ini";
            this.HelpBalloon.SetToolTip(this.edit, "Edit Settings File");
            this.edit.UseVisualStyleBackColor = false;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // browser_panel
            // 
            this.browser_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.browser_panel.Controls.Add(this.pictureBox_opera);
            this.browser_panel.Controls.Add(this.pictureBox_firefox);
            this.browser_panel.Controls.Add(this.pictureBox_chrome);
            this.browser_panel.Controls.Add(this.browser_opera);
            this.browser_panel.Controls.Add(this.browser_label);
            this.browser_panel.Controls.Add(this.browser_firefox);
            this.browser_panel.Controls.Add(this.browser_chrome);
            this.browser_panel.Location = new System.Drawing.Point(12, 12);
            this.browser_panel.Name = "browser_panel";
            this.browser_panel.Size = new System.Drawing.Size(154, 137);
            this.browser_panel.TabIndex = 196;
            // 
            // pictureBox_opera
            // 
            this.pictureBox_opera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pictureBox_opera.Image = global::fapmap.Properties.Resources.image_browser_opera;
            this.pictureBox_opera.Location = new System.Drawing.Point(3, 98);
            this.pictureBox_opera.Name = "pictureBox_opera";
            this.pictureBox_opera.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_opera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_opera.TabIndex = 199;
            this.pictureBox_opera.TabStop = false;
            // 
            // pictureBox_firefox
            // 
            this.pictureBox_firefox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pictureBox_firefox.Image = global::fapmap.Properties.Resources.image_browser_firefox;
            this.pictureBox_firefox.Location = new System.Drawing.Point(3, 62);
            this.pictureBox_firefox.Name = "pictureBox_firefox";
            this.pictureBox_firefox.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_firefox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_firefox.TabIndex = 198;
            this.pictureBox_firefox.TabStop = false;
            // 
            // pictureBox_chrome
            // 
            this.pictureBox_chrome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pictureBox_chrome.Image = global::fapmap.Properties.Resources.image_browser_chrome;
            this.pictureBox_chrome.Location = new System.Drawing.Point(3, 26);
            this.pictureBox_chrome.Name = "pictureBox_chrome";
            this.pictureBox_chrome.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_chrome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_chrome.TabIndex = 197;
            this.pictureBox_chrome.TabStop = false;
            // 
            // browser_opera
            // 
            this.browser_opera.AutoSize = true;
            this.browser_opera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_opera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browser_opera.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_opera.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_opera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_opera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_opera.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.browser_opera.ForeColor = System.Drawing.Color.Snow;
            this.browser_opera.Location = new System.Drawing.Point(39, 101);
            this.browser_opera.Name = "browser_opera";
            this.browser_opera.Size = new System.Drawing.Size(79, 26);
            this.browser_opera.TabIndex = 196;
            this.browser_opera.Text = "Opera";
            this.browser_opera.UseVisualStyleBackColor = false;
            this.browser_opera.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // browser_label
            // 
            this.browser_label.AutoSize = true;
            this.browser_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.browser_label.ForeColor = System.Drawing.Color.Silver;
            this.browser_label.Location = new System.Drawing.Point(3, 0);
            this.browser_label.Name = "browser_label";
            this.browser_label.Size = new System.Drawing.Size(140, 23);
            this.browser_label.TabIndex = 212;
            this.browser_label.Text = "BROWSERS:";
            // 
            // browser_firefox
            // 
            this.browser_firefox.AutoSize = true;
            this.browser_firefox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_firefox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browser_firefox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_firefox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_firefox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_firefox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_firefox.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.browser_firefox.ForeColor = System.Drawing.Color.Snow;
            this.browser_firefox.Location = new System.Drawing.Point(39, 65);
            this.browser_firefox.Name = "browser_firefox";
            this.browser_firefox.Size = new System.Drawing.Size(99, 26);
            this.browser_firefox.TabIndex = 195;
            this.browser_firefox.Text = "Firefox";
            this.browser_firefox.UseVisualStyleBackColor = false;
            this.browser_firefox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // browser_chrome
            // 
            this.browser_chrome.AutoSize = true;
            this.browser_chrome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_chrome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browser_chrome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_chrome.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_chrome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_chrome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.browser_chrome.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.browser_chrome.ForeColor = System.Drawing.Color.Snow;
            this.browser_chrome.Location = new System.Drawing.Point(39, 29);
            this.browser_chrome.Name = "browser_chrome";
            this.browser_chrome.Size = new System.Drawing.Size(89, 26);
            this.browser_chrome.TabIndex = 10;
            this.browser_chrome.Text = "Chrome";
            this.browser_chrome.UseVisualStyleBackColor = false;
            this.browser_chrome.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pass_new
            // 
            this.pass_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pass_new.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pass_new.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pass_new.ForeColor = System.Drawing.Color.Silver;
            this.pass_new.Location = new System.Drawing.Point(3, 30);
            this.pass_new.Name = "pass_new";
            this.pass_new.Size = new System.Drawing.Size(124, 21);
            this.pass_new.TabIndex = 198;
            this.pass_new.KeyDown += new System.Windows.Forms.KeyEventHandler(this.newPassword_KeyDown);
            // 
            // pass_list
            // 
            this.pass_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pass_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pass_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pass_list.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.pass_list.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pass_list.ForeColor = System.Drawing.Color.Silver;
            this.pass_list.FormattingEnabled = true;
            this.pass_list.ItemHeight = 22;
            this.pass_list.Location = new System.Drawing.Point(0, 0);
            this.pass_list.Name = "pass_list";
            this.pass_list.Size = new System.Drawing.Size(144, 256);
            this.pass_list.TabIndex = 199;
            this.HelpBalloon.SetToolTip(this.pass_list, "Double Click To Remove Selected Password");
            this.pass_list.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.passwordsList_DrawItem);
            this.pass_list.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.passwordsList_MeasureItem);
            this.pass_list.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.passwordsList_MouseDoubleClick);
            // 
            // pass_list_panel
            // 
            this.pass_list_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pass_list_panel.BackColor = System.Drawing.Color.DimGray;
            this.pass_list_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pass_list_panel.Controls.Add(this.pass_list);
            this.pass_list_panel.Location = new System.Drawing.Point(3, 53);
            this.pass_list_panel.Name = "pass_list_panel";
            this.pass_list_panel.Size = new System.Drawing.Size(146, 258);
            this.pass_list_panel.TabIndex = 200;
            // 
            // pass_add
            // 
            this.pass_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pass_add.BackgroundImage = global::fapmap.Properties.Resources.image_button_arrow_down;
            this.pass_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pass_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pass_add.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.pass_add.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pass_add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pass_add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pass_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pass_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pass_add.ForeColor = System.Drawing.Color.DimGray;
            this.pass_add.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pass_add.Location = new System.Drawing.Point(129, 30);
            this.pass_add.Name = "pass_add";
            this.pass_add.Size = new System.Drawing.Size(20, 21);
            this.pass_add.TabIndex = 201;
            this.HelpBalloon.SetToolTip(this.pass_add, "Add A Password");
            this.pass_add.UseVisualStyleBackColor = false;
            this.pass_add.Click += new System.EventHandler(this.addPassword_Click);
            // 
            // pass_label
            // 
            this.pass_label.AutoSize = true;
            this.pass_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pass_label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pass_label.ForeColor = System.Drawing.Color.Silver;
            this.pass_label.Location = new System.Drawing.Point(-1, 0);
            this.pass_label.Name = "pass_label";
            this.pass_label.Size = new System.Drawing.Size(157, 23);
            this.pass_label.TabIndex = 202;
            this.pass_label.Text = "PASSWORDS:";
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.HelpBalloon.ForeColor = System.Drawing.Color.Silver;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // wb_url
            // 
            this.wb_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wb_url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.wb_url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wb_url.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wb_url.ForeColor = System.Drawing.Color.Silver;
            this.wb_url.Location = new System.Drawing.Point(7, 31);
            this.wb_url.Name = "wb_url";
            this.wb_url.Size = new System.Drawing.Size(569, 21);
            this.wb_url.TabIndex = 207;
            this.wb_url.Text = "https://www.google.com";
            this.wb_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.wb_url_KeyDown);
            // 
            // wb_label
            // 
            this.wb_label.AutoSize = true;
            this.wb_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.wb_label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wb_label.ForeColor = System.Drawing.Color.Silver;
            this.wb_label.Location = new System.Drawing.Point(3, 5);
            this.wb_label.Name = "wb_label";
            this.wb_label.Size = new System.Drawing.Size(193, 23);
            this.wb_label.TabIndex = 209;
            this.wb_label.Text = "START WEBSITE:";
            // 
            // wb_panel
            // 
            this.wb_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wb_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.wb_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wb_panel.Controls.Add(this.wb_url);
            this.wb_panel.Controls.Add(this.wb_label);
            this.wb_panel.Location = new System.Drawing.Point(172, 476);
            this.wb_panel.Name = "wb_panel";
            this.wb_panel.Size = new System.Drawing.Size(581, 58);
            this.wb_panel.TabIndex = 213;
            // 
            // pass_panel
            // 
            this.pass_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pass_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pass_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pass_panel.Controls.Add(this.pass_label);
            this.pass_panel.Controls.Add(this.pass_new);
            this.pass_panel.Controls.Add(this.pass_list_panel);
            this.pass_panel.Controls.Add(this.pass_add);
            this.pass_panel.Location = new System.Drawing.Point(12, 155);
            this.pass_panel.Name = "pass_panel";
            this.pass_panel.Size = new System.Drawing.Size(154, 316);
            this.pass_panel.TabIndex = 215;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cb_openOutside);
            this.panel1.Controls.Add(this.edit);
            this.panel1.Controls.Add(this.cb_fileDisplay);
            this.panel1.Controls.Add(this.cb_trackbar);
            this.panel1.Controls.Add(this.cb_autoPause);
            this.panel1.Controls.Add(this.cb_autoPlay);
            this.panel1.Controls.Add(this.cb_autoHideMedia);
            this.panel1.Controls.Add(this.cb_media);
            this.panel1.Controls.Add(this.cb_focusHide);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cb_hideOnX);
            this.panel1.Location = new System.Drawing.Point(512, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 459);
            this.panel1.TabIndex = 216;
            // 
            // cb_openOutside
            // 
            this.cb_openOutside.AutoSize = true;
            this.cb_openOutside.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_openOutside.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_openOutside.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_openOutside.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_openOutside.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_openOutside.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_openOutside.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_openOutside.ForeColor = System.Drawing.Color.Snow;
            this.cb_openOutside.Location = new System.Drawing.Point(14, 219);
            this.cb_openOutside.Name = "cb_openOutside";
            this.cb_openOutside.Size = new System.Drawing.Size(176, 17);
            this.cb_openOutside.TabIndex = 220;
            this.cb_openOutside.Text = "Open files outside fapmap";
            this.cb_openOutside.UseVisualStyleBackColor = false;
            this.cb_openOutside.CheckedChanged += new System.EventHandler(this.cb_openOutside_CheckedChanged);
            // 
            // cb_fileDisplay
            // 
            this.cb_fileDisplay.AutoSize = true;
            this.cb_fileDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_fileDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_fileDisplay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_fileDisplay.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_fileDisplay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_fileDisplay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_fileDisplay.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_fileDisplay.ForeColor = System.Drawing.Color.Snow;
            this.cb_fileDisplay.Location = new System.Drawing.Point(14, 196);
            this.cb_fileDisplay.Name = "cb_fileDisplay";
            this.cb_fileDisplay.Size = new System.Drawing.Size(140, 17);
            this.cb_fileDisplay.TabIndex = 219;
            this.cb_fileDisplay.Text = "Enable file display";
            this.cb_fileDisplay.UseVisualStyleBackColor = false;
            this.cb_fileDisplay.CheckedChanged += new System.EventHandler(this.cb_fileDisplay_CheckedChanged);
            // 
            // cb_trackbar
            // 
            this.cb_trackbar.AutoSize = true;
            this.cb_trackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_trackbar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_trackbar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_trackbar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_trackbar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_trackbar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_trackbar.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_trackbar.ForeColor = System.Drawing.Color.Snow;
            this.cb_trackbar.Location = new System.Drawing.Point(14, 173);
            this.cb_trackbar.Name = "cb_trackbar";
            this.cb_trackbar.Size = new System.Drawing.Size(206, 17);
            this.cb_trackbar.TabIndex = 218;
            this.cb_trackbar.Text = "Enable trackbar for gif viewer";
            this.cb_trackbar.UseVisualStyleBackColor = false;
            this.cb_trackbar.CheckedChanged += new System.EventHandler(this.cb_trackbar_CheckedChanged);
            // 
            // cb_autoPause
            // 
            this.cb_autoPause.AutoSize = true;
            this.cb_autoPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_autoPause.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPause.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPause.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_autoPause.ForeColor = System.Drawing.Color.Snow;
            this.cb_autoPause.Location = new System.Drawing.Point(14, 150);
            this.cb_autoPause.Name = "cb_autoPause";
            this.cb_autoPause.Size = new System.Drawing.Size(164, 17);
            this.cb_autoPause.TabIndex = 217;
            this.cb_autoPause.Text = "Auto pause video player";
            this.cb_autoPause.UseVisualStyleBackColor = false;
            this.cb_autoPause.CheckedChanged += new System.EventHandler(this.cb_autoPause_CheckedChanged);
            // 
            // cb_autoPlay
            // 
            this.cb_autoPlay.AutoSize = true;
            this.cb_autoPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_autoPlay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPlay.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoPlay.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_autoPlay.ForeColor = System.Drawing.Color.Snow;
            this.cb_autoPlay.Location = new System.Drawing.Point(14, 127);
            this.cb_autoPlay.Name = "cb_autoPlay";
            this.cb_autoPlay.Size = new System.Drawing.Size(158, 17);
            this.cb_autoPlay.TabIndex = 216;
            this.cb_autoPlay.Text = "Auto play video player";
            this.cb_autoPlay.UseVisualStyleBackColor = false;
            this.cb_autoPlay.CheckedChanged += new System.EventHandler(this.cb_autoPlay_CheckedChanged);
            // 
            // cb_autoHideMedia
            // 
            this.cb_autoHideMedia.AutoSize = true;
            this.cb_autoHideMedia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoHideMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_autoHideMedia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoHideMedia.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoHideMedia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoHideMedia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_autoHideMedia.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_autoHideMedia.ForeColor = System.Drawing.Color.Snow;
            this.cb_autoHideMedia.Location = new System.Drawing.Point(14, 104);
            this.cb_autoHideMedia.Name = "cb_autoHideMedia";
            this.cb_autoHideMedia.Size = new System.Drawing.Size(164, 17);
            this.cb_autoHideMedia.TabIndex = 215;
            this.cb_autoHideMedia.Text = "Auto hide media players";
            this.cb_autoHideMedia.UseVisualStyleBackColor = false;
            this.cb_autoHideMedia.CheckedChanged += new System.EventHandler(this.cb_autoHideMedia_CheckedChanged);
            // 
            // cb_media
            // 
            this.cb_media.AutoSize = true;
            this.cb_media.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_media.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_media.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_media.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_media.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_media.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_media.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_media.ForeColor = System.Drawing.Color.Snow;
            this.cb_media.Location = new System.Drawing.Point(14, 81);
            this.cb_media.Name = "cb_media";
            this.cb_media.Size = new System.Drawing.Size(146, 17);
            this.cb_media.TabIndex = 214;
            this.cb_media.Text = "Enable media players";
            this.cb_media.UseVisualStyleBackColor = false;
            this.cb_media.CheckedChanged += new System.EventHandler(this.cb_media_CheckedChanged);
            // 
            // cb_focusHide
            // 
            this.cb_focusHide.AutoSize = true;
            this.cb_focusHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_focusHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_focusHide.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_focusHide.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_focusHide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_focusHide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_focusHide.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_focusHide.ForeColor = System.Drawing.Color.Snow;
            this.cb_focusHide.Location = new System.Drawing.Point(14, 58);
            this.cb_focusHide.Name = "cb_focusHide";
            this.cb_focusHide.Size = new System.Drawing.Size(134, 17);
            this.cb_focusHide.TabIndex = 213;
            this.cb_focusHide.Text = "Hide on lost focus";
            this.cb_focusHide.UseVisualStyleBackColor = false;
            this.cb_focusHide.CheckedChanged += new System.EventHandler(this.cb_focusHide_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(29, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 23);
            this.label1.TabIndex = 212;
            this.label1.Text = "CHECKBOXES";
            // 
            // cb_hideOnX
            // 
            this.cb_hideOnX.AutoSize = true;
            this.cb_hideOnX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_hideOnX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_hideOnX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_hideOnX.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_hideOnX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_hideOnX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_hideOnX.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_hideOnX.ForeColor = System.Drawing.Color.Snow;
            this.cb_hideOnX.Location = new System.Drawing.Point(14, 35);
            this.cb_hideOnX.Name = "cb_hideOnX";
            this.cb_hideOnX.Size = new System.Drawing.Size(92, 17);
            this.cb_hideOnX.TabIndex = 10;
            this.cb_hideOnX.Text = "Hide on [X]";
            this.cb_hideOnX.UseVisualStyleBackColor = false;
            this.cb_hideOnX.CheckedChanged += new System.EventHandler(this.cb_hideOnX_CheckedChanged);
            // 
            // restartNote
            // 
            this.restartNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.restartNote.AutoSize = true;
            this.restartNote.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartNote.Location = new System.Drawing.Point(12, 498);
            this.restartNote.Name = "restartNote";
            this.restartNote.Size = new System.Drawing.Size(139, 39);
            this.restartNote.TabIndex = 217;
            this.restartNote.Text = "You must restart\r\nfapmap for the changes\r\nto take effect";
            // 
            // fapmap_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(765, 546);
            this.Controls.Add(this.restartNote);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.browser_panel);
            this.Controls.Add(this.pass_panel);
            this.Controls.Add(this.gallery_panel);
            this.Controls.Add(this.wb_panel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.Silver;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 400);
            this.Name = "fapmap_settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAPMAP - SETTINGS";
            this.Load += new System.EventHandler(this.GalleryInfo_Load);
            this.gallery_panel.ResumeLayout(false);
            this.gallery_panel.PerformLayout();
            this.count_files_panel.ResumeLayout(false);
            this.browser_panel.ResumeLayout(false);
            this.browser_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_opera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_firefox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_chrome)).EndInit();
            this.pass_list_panel.ResumeLayout(false);
            this.wb_panel.ResumeLayout(false);
            this.wb_panel.PerformLayout();
            this.pass_panel.ResumeLayout(false);
            this.pass_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox count_size;
        private System.Windows.Forms.Panel gallery_panel;
        private System.Windows.Forms.Panel browser_panel;
        private System.Windows.Forms.CheckBox browser_opera;
        private System.Windows.Forms.CheckBox browser_firefox;
        private System.Windows.Forms.CheckBox browser_chrome;
        private System.Windows.Forms.PictureBox pictureBox_opera;
        private System.Windows.Forms.PictureBox pictureBox_firefox;
        private System.Windows.Forms.PictureBox pictureBox_chrome;
        private System.Windows.Forms.TextBox pass_new;
        private System.Windows.Forms.ListBox pass_list;
        private System.Windows.Forms.Panel pass_list_panel;
        private System.Windows.Forms.Button pass_add;
        private System.Windows.Forms.Label pass_label;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.TextBox wb_url;
        private System.Windows.Forms.Label wb_label;
        private System.Windows.Forms.Label gallery_label;
        private System.Windows.Forms.Label browser_label;
        private System.Windows.Forms.Panel wb_panel;
        private System.Windows.Forms.Panel pass_panel;
        private System.Windows.Forms.Panel count_files_panel;
        private System.Windows.Forms.RichTextBox count_files;
        private System.Windows.Forms.CheckBox cb_count;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button count_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_hideOnX;
        private System.Windows.Forms.CheckBox cb_media;
        private System.Windows.Forms.CheckBox cb_focusHide;
        private System.Windows.Forms.CheckBox cb_autoHideMedia;
        private System.Windows.Forms.CheckBox cb_autoPlay;
        private System.Windows.Forms.CheckBox cb_autoPause;
        private System.Windows.Forms.CheckBox cb_trackbar;
        private System.Windows.Forms.CheckBox cb_fileDisplay;
        private System.Windows.Forms.CheckBox cb_openOutside;
        private System.Windows.Forms.Label restartNote;
    }
}