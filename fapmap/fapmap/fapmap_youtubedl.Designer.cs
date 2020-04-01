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
            this.txt_options = new System.Windows.Forms.TextBox();
            this.btn_openPathSelector = new System.Windows.Forms.Button();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.btn_explorer = new System.Windows.Forms.Button();
            this.txt_output = new fapmap_res.FixedRichTextBox();
            this.txt_output_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txt_output_RMB_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.this_trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.txt_output_border = new fapmap_res.FapMapPanel();
            this.txt_path_border = new fapmap_res.FapMapPanel();
            this.txt_url_border = new fapmap_res.FapMapPanel();
            this.txt_options_border = new fapmap_res.FapMapPanel();
            this.txt_output_RMB.SuspendLayout();
            this.txt_output_border.SuspendLayout();
            this.txt_path_border.SuspendLayout();
            this.txt_url_border.SuspendLayout();
            this.txt_options_border.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_path
            // 
            this.txt_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_path.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_path.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.txt_path.ForeColor = System.Drawing.Color.SkyBlue;
            this.txt_path.Location = new System.Drawing.Point(1, 1);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(508, 19);
            this.txt_path.TabIndex = 3;
            this.txt_path.TextChanged += new System.EventHandler(this.txt_path_TextChanged);
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_start.BackgroundImage = global::fapmap.Properties.Resources.downloadVideo;
            this.btn_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_start.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_start.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_start.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_start.Location = new System.Drawing.Point(552, 12);
            this.btn_start.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(21, 21);
            this.btn_start.TabIndex = 2;
            this.HelpBalloon.SetToolTip(this.btn_start, "Start/Stop youtube-dl.exe");
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // txt_url
            // 
            this.txt_url.AllowDrop = true;
            this.txt_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_url.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_url.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_url.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.txt_url.ForeColor = System.Drawing.Color.Turquoise;
            this.txt_url.Location = new System.Drawing.Point(1, 1);
            this.txt_url.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(534, 19);
            this.txt_url.TabIndex = 1;
            this.txt_url.TextChanged += new System.EventHandler(this.txt_url_TextChanged);
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
            this.label_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.label_status.Location = new System.Drawing.Point(12, 239);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(25, 13);
            this.label_status.TabIndex = 0;
            this.label_status.Text = "...";
            // 
            // txt_options
            // 
            this.txt_options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_options.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_options.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txt_options.ForeColor = System.Drawing.Color.SlateBlue;
            this.txt_options.Location = new System.Drawing.Point(1, 1);
            this.txt_options.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txt_options.Name = "txt_options";
            this.txt_options.Size = new System.Drawing.Size(352, 13);
            this.txt_options.TabIndex = 7;
            this.txt_options.Text = "-o %(title)s.%(ext)s";
            // 
            // btn_openPathSelector
            // 
            this.btn_openPathSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_openPathSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openPathSelector.BackgroundImage = global::fapmap.Properties.Resources.treeView;
            this.btn_openPathSelector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_openPathSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_openPathSelector.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_openPathSelector.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openPathSelector.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openPathSelector.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_openPathSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openPathSelector.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_openPathSelector.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_openPathSelector.Location = new System.Drawing.Point(527, 39);
            this.btn_openPathSelector.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openPathSelector.Name = "btn_openPathSelector";
            this.btn_openPathSelector.Size = new System.Drawing.Size(21, 21);
            this.btn_openPathSelector.TabIndex = 4;
            this.HelpBalloon.SetToolTip(this.btn_openPathSelector, "Select Folder");
            this.btn_openPathSelector.UseVisualStyleBackColor = false;
            this.btn_openPathSelector.Click += new System.EventHandler(this.btn_openPathSelector_Click);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // btn_explorer
            // 
            this.btn_explorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_explorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_explorer.BackgroundImage = global::fapmap.Properties.Resources.folder;
            this.btn_explorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_explorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_explorer.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_explorer.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_explorer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_explorer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_explorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_explorer.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_explorer.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_explorer.Location = new System.Drawing.Point(552, 39);
            this.btn_explorer.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_explorer.Name = "btn_explorer";
            this.btn_explorer.Size = new System.Drawing.Size(21, 21);
            this.btn_explorer.TabIndex = 5;
            this.HelpBalloon.SetToolTip(this.btn_explorer, "Open Path in Explorer");
            this.btn_explorer.UseVisualStyleBackColor = false;
            this.btn_explorer.Click += new System.EventHandler(this.btn_explorer_Click);
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
            this.txt_output.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_output.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txt_output.Location = new System.Drawing.Point(1, 1);
            this.txt_output.Name = "txt_output";
            this.txt_output.ReadOnly = true;
            this.txt_output.Size = new System.Drawing.Size(559, 160);
            this.txt_output.TabIndex = 6;
            this.txt_output.Text = "...";
            this.txt_output.WordWrap = false;
            this.txt_output.TextChanged += new System.EventHandler(this.txt_output_TextChanged);
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
            // this_trayicon
            // 
            this.this_trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("this_trayicon.Icon")));
            this.this_trayicon.Visible = true;
            this.this_trayicon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.this_trayicon_MouseUp);
            this.this_trayicon.Disposed += new System.EventHandler(this.this_trayicon_Disposed);
            // 
            // txt_output_border
            // 
            this.txt_output_border.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_output_border.Controls.Add(this.txt_output);
            this.txt_output_border.Location = new System.Drawing.Point(12, 66);
            this.txt_output_border.Name = "txt_output_border";
            this.txt_output_border.Size = new System.Drawing.Size(561, 162);
            this.txt_output_border.TabIndex = 8;
            // 
            // txt_path_border
            // 
            this.txt_path_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_path_border.Controls.Add(this.txt_path);
            this.txt_path_border.Location = new System.Drawing.Point(12, 39);
            this.txt_path_border.Name = "txt_path_border";
            this.txt_path_border.Size = new System.Drawing.Size(510, 21);
            this.txt_path_border.TabIndex = 9;
            // 
            // txt_url_border
            // 
            this.txt_url_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_url_border.Controls.Add(this.txt_url);
            this.txt_url_border.Location = new System.Drawing.Point(12, 12);
            this.txt_url_border.Name = "txt_url_border";
            this.txt_url_border.Size = new System.Drawing.Size(536, 21);
            this.txt_url_border.TabIndex = 10;
            // 
            // txt_options_border
            // 
            this.txt_options_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_options_border.Controls.Add(this.txt_options);
            this.txt_options_border.Location = new System.Drawing.Point(218, 234);
            this.txt_options_border.Name = "txt_options_border";
            this.txt_options_border.Size = new System.Drawing.Size(354, 15);
            this.txt_options_border.TabIndex = 11;
            // 
            // fapmap_youtubedl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.txt_options_border);
            this.Controls.Add(this.txt_url_border);
            this.Controls.Add(this.txt_path_border);
            this.Controls.Add(this.txt_output_border);
            this.Controls.Add(this.btn_explorer);
            this.Controls.Add(this.btn_openPathSelector);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.btn_start);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.MediumPurple;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "fapmap_youtubedl";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - Video Downloader (youtube-dl.exe)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fapmap_youtubedl_FormClosing);
            this.Load += new System.EventHandler(this.fapmap_youtubedl_Load);
            this.txt_output_RMB.ResumeLayout(false);
            this.txt_output_border.ResumeLayout(false);
            this.txt_path_border.ResumeLayout(false);
            this.txt_path_border.PerformLayout();
            this.txt_url_border.ResumeLayout(false);
            this.txt_url_border.PerformLayout();
            this.txt_options_border.ResumeLayout(false);
            this.txt_options_border.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.TextBox txt_options;
        private System.Windows.Forms.Button btn_openPathSelector;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private fapmap_res.FixedRichTextBox txt_output;
        private System.Windows.Forms.Button btn_explorer;
        private System.Windows.Forms.NotifyIcon this_trayicon;
        private System.Windows.Forms.ContextMenuStrip txt_output_RMB;
        private System.Windows.Forms.ToolStripMenuItem txt_output_RMB_copy;
        private fapmap_res.FapMapPanel txt_output_border;
        private fapmap_res.FapMapPanel txt_path_border;
        private fapmap_res.FapMapPanel txt_url_border;
        private fapmap_res.FapMapPanel txt_options_border;
    }
}