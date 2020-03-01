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
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_find = new System.Windows.Forms.Button();
            this.txt_options = new System.Windows.Forms.TextBox();
            this.label_status = new System.Windows.Forms.Label();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.cb_scroll = new System.Windows.Forms.CheckBox();
            this.btn_openPathSelector = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_path
            // 
            this.txt_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_path.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txt_path.ForeColor = System.Drawing.Color.Teal;
            this.txt_path.Location = new System.Drawing.Point(168, 12);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(653, 20);
            this.txt_path.TabIndex = 151;
            this.txt_path.TextChanged += new System.EventHandler(this.txt_path_TextChanged);
            this.txt_path.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btn_find
            // 
            this.btn_find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_find.BackColor = System.Drawing.Color.Transparent;
            this.btn_find.BackgroundImage = global::fapmap.Properties.Resources.find;
            this.btn_find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_find.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_find.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_find.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_find.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_find.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_find.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_find.Location = new System.Drawing.Point(827, 12);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(20, 20);
            this.btn_find.TabIndex = 152;
            this.HelpBalloon.SetToolTip(this.btn_find, "Start/Stop fscan.exe");
            this.btn_find.UseVisualStyleBackColor = false;
            this.btn_find.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_find_MouseClick);
            // 
            // txt_options
            // 
            this.txt_options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_options.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_options.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txt_options.ForeColor = System.Drawing.Color.Teal;
            this.txt_options.Location = new System.Drawing.Point(12, 12);
            this.txt_options.Name = "txt_options";
            this.txt_options.Size = new System.Drawing.Size(149, 20);
            this.txt_options.TabIndex = 153;
            this.txt_options.Text = "pic all v";
            this.txt_options.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // label_status
            // 
            this.label_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_status.AutoSize = true;
            this.label_status.BackColor = System.Drawing.Color.Transparent;
            this.label_status.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.ForeColor = System.Drawing.Color.SlateBlue;
            this.label_status.Location = new System.Drawing.Point(12, 339);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(25, 13);
            this.label_status.TabIndex = 157;
            this.label_status.Text = "...";
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.SlateBlue;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // cb_scroll
            // 
            this.cb_scroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_scroll.AutoSize = true;
            this.cb_scroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cb_scroll.Checked = true;
            this.cb_scroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_scroll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_scroll.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.cb_scroll.FlatAppearance.CheckedBackColor = System.Drawing.Color.SlateBlue;
            this.cb_scroll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_scroll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_scroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_scroll.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_scroll.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.cb_scroll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_scroll.Location = new System.Drawing.Point(860, 342);
            this.cb_scroll.Name = "cb_scroll";
            this.cb_scroll.Size = new System.Drawing.Size(12, 11);
            this.cb_scroll.TabIndex = 215;
            this.HelpBalloon.SetToolTip(this.cb_scroll, "Scroll with output");
            this.cb_scroll.UseVisualStyleBackColor = false;
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
            this.btn_openPathSelector.Location = new System.Drawing.Point(852, 12);
            this.btn_openPathSelector.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_openPathSelector.Name = "btn_openPathSelector";
            this.btn_openPathSelector.Size = new System.Drawing.Size(20, 20);
            this.btn_openPathSelector.TabIndex = 216;
            this.HelpBalloon.SetToolTip(this.btn_openPathSelector, "Select Folder");
            this.btn_openPathSelector.UseVisualStyleBackColor = false;
            this.btn_openPathSelector.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_openPathSelector_MouseClick);
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
            this.output.Location = new System.Drawing.Point(12, 38);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.output.Size = new System.Drawing.Size(860, 298);
            this.output.TabIndex = 159;
            this.output.TextChanged += new System.EventHandler(this.output_TextChanged);
            // 
            // fapmap_fscan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.ClientSize = new System.Drawing.Size(884, 361);
            this.Controls.Add(this.btn_openPathSelector);
            this.Controls.Add(this.cb_scroll);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.txt_options);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.txt_path);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(420, 240);
            this.Name = "fapmap_fscan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - File (dupe) searcher (fscan.exe)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fapmap_fscan_FormClosing);
            this.Load += new System.EventHandler(this.fapmap_fscan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_options;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.CheckBox cb_scroll;
        private System.Windows.Forms.Button btn_openPathSelector;
    }
}