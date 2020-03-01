namespace fapmap
{
    partial class fapmap_youtubedl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_youtubedl));
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.label_status = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.TextBox();
            this.txt_options = new System.Windows.Forms.TextBox();
            this.btn_openPathSelector = new System.Windows.Forms.Button();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txt_path
            // 
            this.txt_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_path.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txt_path.ForeColor = System.Drawing.Color.SteelBlue;
            this.txt_path.Location = new System.Drawing.Point(11, 37);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(578, 20);
            this.txt_path.TabIndex = 152;
            this.txt_path.TextChanged += new System.EventHandler(this.txt_path_TextChanged);
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_start.BackgroundImage = global::fapmap.Properties.Resources.download;
            this.btn_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_start.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_start.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_start.ForeColor = System.Drawing.Color.DimGray;
            this.btn_start.Location = new System.Drawing.Point(593, 13);
            this.btn_start.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(20, 20);
            this.btn_start.TabIndex = 161;
            this.HelpBalloon.SetToolTip(this.btn_start, "Start/Stop youtube-dl.exe");
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_start_MouseClick);
            // 
            // txt_url
            // 
            this.txt_url.AllowDrop = true;
            this.txt_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_url.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txt_url.ForeColor = System.Drawing.Color.SteelBlue;
            this.txt_url.Location = new System.Drawing.Point(11, 13);
            this.txt_url.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(578, 20);
            this.txt_url.TabIndex = 160;
            this.txt_url.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_url_DragDrop);
            this.txt_url.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_url_DragEnter);
            this.txt_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_url_KeyDown);
            // 
            // label_status
            // 
            this.label_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_status.AutoSize = true;
            this.label_status.BackColor = System.Drawing.Color.Transparent;
            this.label_status.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.ForeColor = System.Drawing.Color.SlateBlue;
            this.label_status.Location = new System.Drawing.Point(12, 239);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(25, 13);
            this.label_status.TabIndex = 162;
            this.label_status.Text = "...";
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.output.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.output.ForeColor = System.Drawing.Color.Teal;
            this.output.Location = new System.Drawing.Point(11, 63);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.output.Size = new System.Drawing.Size(602, 158);
            this.output.TabIndex = 172;
            this.output.TextChanged += new System.EventHandler(this.output_TextChanged);
            // 
            // txt_options
            // 
            this.txt_options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_options.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_options.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txt_options.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.txt_options.Location = new System.Drawing.Point(231, 228);
            this.txt_options.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_options.Name = "txt_options";
            this.txt_options.Size = new System.Drawing.Size(382, 20);
            this.txt_options.TabIndex = 173;
            this.txt_options.Text = "-o %(title)s.%(ext)s";
            // 
            // btn_openPathSelector
            // 
            this.btn_openPathSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btn_openPathSelector.Location = new System.Drawing.Point(593, 37);
            this.btn_openPathSelector.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openPathSelector.Name = "btn_openPathSelector";
            this.btn_openPathSelector.Size = new System.Drawing.Size(20, 20);
            this.btn_openPathSelector.TabIndex = 217;
            this.HelpBalloon.SetToolTip(this.btn_openPathSelector, "Select Folder");
            this.btn_openPathSelector.UseVisualStyleBackColor = false;
            this.btn_openPathSelector.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_openPathSelector_MouseClick);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.SlateBlue;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // fapmap_youtubedl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.ClientSize = new System.Drawing.Size(624, 261);
            this.Controls.Add(this.btn_openPathSelector);
            this.Controls.Add(this.txt_options);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.txt_path);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "fapmap_youtubedl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - Video Downloader (youtube-dl.exe)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fapmap_youtubedl_FormClosing);
            this.Load += new System.EventHandler(this.fapmap_youtubedl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.TextBox txt_options;
        private System.Windows.Forms.Button btn_openPathSelector;
        private System.Windows.Forms.ToolTip HelpBalloon;
    }
}