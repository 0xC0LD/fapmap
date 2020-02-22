namespace fapmap
{
    partial class fapmap_info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_info));
            this.count_files = new System.Windows.Forms.RichTextBox();
            this.fileSizeText = new System.Windows.Forms.TextBox();
            this.cb_count = new System.Windows.Forms.CheckBox();
            this.count_files_panel = new System.Windows.Forms.Panel();
            this.path_txt = new System.Windows.Forms.Label();
            this.getAll = new System.Windows.Forms.Button();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.count_files_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // count_files
            // 
            this.count_files.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.count_files.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.count_files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.count_files.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.count_files.ForeColor = System.Drawing.Color.SlateBlue;
            this.count_files.Location = new System.Drawing.Point(0, 0);
            this.count_files.Name = "count_files";
            this.count_files.ReadOnly = true;
            this.count_files.Size = new System.Drawing.Size(338, 0);
            this.count_files.TabIndex = 215;
            this.count_files.Text = "...";
            // 
            // fileSizeText
            // 
            this.fileSizeText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileSizeText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.fileSizeText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileSizeText.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fileSizeText.ForeColor = System.Drawing.Color.SlateBlue;
            this.fileSizeText.Location = new System.Drawing.Point(12, 12);
            this.fileSizeText.Name = "fileSizeText";
            this.fileSizeText.ReadOnly = true;
            this.fileSizeText.Size = new System.Drawing.Size(304, 30);
            this.fileSizeText.TabIndex = 213;
            this.fileSizeText.Text = "...";
            // 
            // cb_count
            // 
            this.cb_count.AutoSize = true;
            this.cb_count.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cb_count.Checked = true;
            this.cb_count.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_count.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_count.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.cb_count.FlatAppearance.CheckedBackColor = System.Drawing.Color.SlateBlue;
            this.cb_count.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_count.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_count.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_count.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_count.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.cb_count.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_count.Location = new System.Drawing.Point(12, 47);
            this.cb_count.Name = "cb_count";
            this.cb_count.Size = new System.Drawing.Size(12, 11);
            this.cb_count.TabIndex = 216;
            this.HelpBalloon.SetToolTip(this.cb_count, "Don\'t output file types that have a 0 count...");
            this.cb_count.UseVisualStyleBackColor = false;
            // 
            // count_files_panel
            // 
            this.count_files_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.count_files_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.count_files_panel.Controls.Add(this.count_files);
            this.count_files_panel.Location = new System.Drawing.Point(12, 70);
            this.count_files_panel.Name = "count_files_panel";
            this.count_files_panel.Size = new System.Drawing.Size(340, 0);
            this.count_files_panel.TabIndex = 217;
            // 
            // path_txt
            // 
            this.path_txt.AutoSize = true;
            this.path_txt.BackColor = System.Drawing.Color.Transparent;
            this.path_txt.ForeColor = System.Drawing.Color.SlateBlue;
            this.path_txt.Location = new System.Drawing.Point(30, 52);
            this.path_txt.Name = "path_txt";
            this.path_txt.Size = new System.Drawing.Size(25, 13);
            this.path_txt.TabIndex = 218;
            this.path_txt.Text = "...";
            // 
            // getAll
            // 
            this.getAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.getAll.BackColor = System.Drawing.Color.Transparent;
            this.getAll.BackgroundImage = global::fapmap.Properties.Resources.arrow_left;
            this.getAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.getAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.getAll.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.getAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.getAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.getAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.getAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.getAll.Location = new System.Drawing.Point(322, 12);
            this.getAll.Name = "getAll";
            this.getAll.Size = new System.Drawing.Size(30, 30);
            this.getAll.TabIndex = 219;
            this.HelpBalloon.SetToolTip(this.getAll, "Get Info About File/Dir");
            this.getAll.UseVisualStyleBackColor = false;
            this.getAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.getAll_MouseClick);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.SlateBlue;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // fapmap_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.ClientSize = new System.Drawing.Size(364, 72);
            this.Controls.Add(this.getAll);
            this.Controls.Add(this.path_txt);
            this.Controls.Add(this.cb_count);
            this.Controls.Add(this.count_files_panel);
            this.Controls.Add(this.fileSizeText);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(380, 110);
            this.Name = "fapmap_info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - Info";
            this.Load += new System.EventHandler(this.fapmap_info_Load);
            this.count_files_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox count_files;
        private System.Windows.Forms.TextBox fileSizeText;
        private System.Windows.Forms.CheckBox cb_count;
        private System.Windows.Forms.Panel count_files_panel;
        private System.Windows.Forms.Label path_txt;
        private System.Windows.Forms.Button getAll;
        private System.Windows.Forms.ToolTip HelpBalloon;
    }
}