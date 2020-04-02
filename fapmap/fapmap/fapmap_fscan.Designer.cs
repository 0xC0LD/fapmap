namespace fapmap
{
    partial class fapmap_fscan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_fscan));
            this.btn_find = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.btn_openPathSelector = new System.Windows.Forms.Button();
            this.txt_output_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txt_output_RMB_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_path_border = new fapmap_res.FapMapPanel();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.txt_options_border = new fapmap_res.FapMapPanel();
            this.txt_options = new System.Windows.Forms.TextBox();
            this.txt_output_border = new fapmap_res.FapMapPanel();
            this.txt_output = new fapmap_res.FixedRichTextBox();
            this.cb_scroll = new System.Windows.Forms.CheckBox();
            this.txt_output_RMB.SuspendLayout();
            this.txt_path_border.SuspendLayout();
            this.txt_options_border.SuspendLayout();
            this.txt_output_border.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_find
            // 
            this.btn_find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_find.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_find.BackgroundImage = global::fapmap.Properties.Resources.find;
            this.btn_find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_find.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_find.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_find.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_find.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_find.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_find.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_find.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_find.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_find.Location = new System.Drawing.Point(690, 13);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(21, 21);
            this.btn_find.TabIndex = 3;
            this.HelpBalloon.SetToolTip(this.btn_find, "Start/Stop fscan.exe");
            this.btn_find.UseVisualStyleBackColor = false;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // label_status
            // 
            this.label_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_status.AutoSize = true;
            this.label_status.BackColor = System.Drawing.Color.Transparent;
            this.label_status.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.ForeColor = System.Drawing.Color.MediumPurple;
            this.label_status.Location = new System.Drawing.Point(12, 404);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(25, 13);
            this.label_status.TabIndex = 0;
            this.label_status.Text = "...";
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
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
            this.btn_openPathSelector.Location = new System.Drawing.Point(712, 13);
            this.btn_openPathSelector.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openPathSelector.Name = "btn_openPathSelector";
            this.btn_openPathSelector.Size = new System.Drawing.Size(21, 21);
            this.btn_openPathSelector.TabIndex = 4;
            this.HelpBalloon.SetToolTip(this.btn_openPathSelector, "Select Folder");
            this.btn_openPathSelector.UseVisualStyleBackColor = false;
            this.btn_openPathSelector.Click += new System.EventHandler(this.btn_openPathSelector_Click);
            // 
            // txt_output_RMB
            // 
            this.txt_output_RMB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.txt_output_RMB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_output_RMB.BackgroundImage")));
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
            this.txt_output_RMB_copy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_output_RMB_copy.BackgroundImage")));
            this.txt_output_RMB_copy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(141)))), ((int)(((byte)(235)))));
            this.txt_output_RMB_copy.Image = global::fapmap.Properties.Resources.copy;
            this.txt_output_RMB_copy.Name = "txt_output_RMB_copy";
            this.txt_output_RMB_copy.Size = new System.Drawing.Size(149, 22);
            this.txt_output_RMB_copy.Text = "Copy (CTRL+C)";
            this.txt_output_RMB_copy.Click += new System.EventHandler(this.txt_output_RMB_copy_Click);
            // 
            // txt_path_border
            // 
            this.txt_path_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_path_border.Controls.Add(this.txt_path);
            this.txt_path_border.Location = new System.Drawing.Point(180, 13);
            this.txt_path_border.Name = "txt_path_border";
            this.txt_path_border.Size = new System.Drawing.Size(504, 21);
            this.txt_path_border.TabIndex = 11;
            // 
            // txt_path
            // 
            this.txt_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_path.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_path.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.txt_path.ForeColor = System.Drawing.Color.SkyBlue;
            this.txt_path.Location = new System.Drawing.Point(1, 1);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(502, 16);
            this.txt_path.TabIndex = 2;
            this.txt_path.TextChanged += new System.EventHandler(this.txt_path_TextChanged);
            this.txt_path.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txt_options_border
            // 
            this.txt_options_border.Controls.Add(this.txt_options);
            this.txt_options_border.Location = new System.Drawing.Point(12, 13);
            this.txt_options_border.Name = "txt_options_border";
            this.txt_options_border.Size = new System.Drawing.Size(162, 21);
            this.txt_options_border.TabIndex = 10;
            // 
            // txt_options
            // 
            this.txt_options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_options.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_options.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.txt_options.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txt_options.Location = new System.Drawing.Point(1, 1);
            this.txt_options.Name = "txt_options";
            this.txt_options.Size = new System.Drawing.Size(160, 16);
            this.txt_options.TabIndex = 1;
            this.txt_options.Text = "pic all v";
            this.txt_options.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txt_output_border
            // 
            this.txt_output_border.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_output_border.Controls.Add(this.txt_output);
            this.txt_output_border.Location = new System.Drawing.Point(12, 41);
            this.txt_output_border.Name = "txt_output_border";
            this.txt_output_border.Size = new System.Drawing.Size(721, 355);
            this.txt_output_border.TabIndex = 9;
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
            this.txt_output.Size = new System.Drawing.Size(719, 353);
            this.txt_output.TabIndex = 6;
            this.txt_output.Text = "...";
            this.txt_output.WordWrap = false;
            this.txt_output.TextChanged += new System.EventHandler(this.txt_output_TextChanged);
            // 
            // cb_scroll
            // 
            this.cb_scroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_scroll.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_scroll.BackColor = System.Drawing.Color.Black;
            this.cb_scroll.Checked = true;
            this.cb_scroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_scroll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_scroll.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.cb_scroll.FlatAppearance.CheckedBackColor = System.Drawing.Color.Purple;
            this.cb_scroll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.cb_scroll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.cb_scroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_scroll.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_scroll.ForeColor = System.Drawing.Color.SlateBlue;
            this.cb_scroll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_scroll.Location = new System.Drawing.Point(720, 402);
            this.cb_scroll.Name = "cb_scroll";
            this.cb_scroll.Size = new System.Drawing.Size(12, 12);
            this.cb_scroll.TabIndex = 239;
            this.HelpBalloon.SetToolTip(this.cb_scroll, "Scroll with output");
            this.cb_scroll.UseVisualStyleBackColor = false;
            // 
            // fapmap_fscan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(744, 426);
            this.Controls.Add(this.cb_scroll);
            this.Controls.Add(this.txt_path_border);
            this.Controls.Add(this.txt_options_border);
            this.Controls.Add(this.txt_output_border);
            this.Controls.Add(this.btn_openPathSelector);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.btn_find);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.MediumPurple;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(420, 240);
            this.Name = "fapmap_fscan";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - File (dupe) searcher (fscan.exe)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fapmap_fscan_FormClosing);
            this.Load += new System.EventHandler(this.fapmap_fscan_Load);
            this.txt_output_RMB.ResumeLayout(false);
            this.txt_path_border.ResumeLayout(false);
            this.txt_path_border.PerformLayout();
            this.txt_options_border.ResumeLayout(false);
            this.txt_options_border.PerformLayout();
            this.txt_output_border.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_options;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.Button btn_openPathSelector;
        private System.Windows.Forms.ContextMenuStrip txt_output_RMB;
        private System.Windows.Forms.ToolStripMenuItem txt_output_RMB_copy;
        private fapmap_res.FapMapPanel txt_output_border;
        private fapmap_res.FixedRichTextBox txt_output;
        private fapmap_res.FapMapPanel txt_options_border;
        private fapmap_res.FapMapPanel txt_path_border;
        private System.Windows.Forms.CheckBox cb_scroll;
    }
}