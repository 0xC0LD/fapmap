namespace fapmap
{
    partial class fapmap_playlist
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
            this.cb_random = new System.Windows.Forms.CheckBox();
            this.cb_rmlogs = new System.Windows.Forms.CheckBox();
            this.cb_keyword = new System.Windows.Forms.CheckBox();
            this.tb_keyword = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_make = new System.Windows.Forms.Button();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.label_path = new System.Windows.Forms.Label();
            this.cb_reverse = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cb_random
            // 
            this.cb_random.AutoSize = true;
            this.cb_random.BackColor = System.Drawing.Color.Black;
            this.cb_random.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_random.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_random.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_random.ForeColor = System.Drawing.Color.Silver;
            this.cb_random.Location = new System.Drawing.Point(11, 83);
            this.cb_random.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_random.Name = "cb_random";
            this.cb_random.Size = new System.Drawing.Size(67, 17);
            this.cb_random.TabIndex = 32;
            this.cb_random.Text = "Shuffled";
            this.cb_random.UseVisualStyleBackColor = false;
            this.cb_random.CheckedChanged += new System.EventHandler(this.cb_random_CheckedChanged);
            // 
            // cb_rmlogs
            // 
            this.cb_rmlogs.AutoSize = true;
            this.cb_rmlogs.BackColor = System.Drawing.Color.Black;
            this.cb_rmlogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_rmlogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_rmlogs.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_rmlogs.ForeColor = System.Drawing.Color.Silver;
            this.cb_rmlogs.Location = new System.Drawing.Point(11, 52);
            this.cb_rmlogs.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_rmlogs.Name = "cb_rmlogs";
            this.cb_rmlogs.Size = new System.Drawing.Size(172, 30);
            this.cb_rmlogs.TabIndex = 33;
            this.cb_rmlogs.Text = "Remove Already Played Files\r\n(from logs)";
            this.cb_rmlogs.UseVisualStyleBackColor = false;
            this.cb_rmlogs.CheckedChanged += new System.EventHandler(this.cb_rmlogs_CheckedChanged);
            // 
            // cb_keyword
            // 
            this.cb_keyword.AutoSize = true;
            this.cb_keyword.BackColor = System.Drawing.Color.Black;
            this.cb_keyword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_keyword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_keyword.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_keyword.ForeColor = System.Drawing.Color.Silver;
            this.cb_keyword.Location = new System.Drawing.Point(11, 34);
            this.cb_keyword.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_keyword.Name = "cb_keyword";
            this.cb_keyword.Size = new System.Drawing.Size(184, 17);
            this.cb_keyword.TabIndex = 34;
            this.cb_keyword.Text = "Must Have In File Path (string):";
            this.cb_keyword.UseVisualStyleBackColor = false;
            this.cb_keyword.CheckedChanged += new System.EventHandler(this.cb_keyword_CheckedChanged);
            // 
            // tb_keyword
            // 
            this.tb_keyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_keyword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tb_keyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_keyword.Enabled = false;
            this.tb_keyword.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb_keyword.ForeColor = System.Drawing.Color.Silver;
            this.tb_keyword.Location = new System.Drawing.Point(199, 34);
            this.tb_keyword.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tb_keyword.Name = "tb_keyword";
            this.tb_keyword.Size = new System.Drawing.Size(174, 20);
            this.tb_keyword.TabIndex = 159;
            this.tb_keyword.TextChanged += new System.EventHandler(this.tb_keyword_TextChanged);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_cancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_cancel.ForeColor = System.Drawing.Color.DimGray;
            this.btn_cancel.Location = new System.Drawing.Point(312, 89);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(61, 29);
            this.btn_cancel.TabIndex = 160;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_make
            // 
            this.btn_make.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_make.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_make.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_make.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_make.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_make.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_make.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_make.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_make.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_make.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_make.ForeColor = System.Drawing.Color.DimGray;
            this.btn_make.Location = new System.Drawing.Point(247, 89);
            this.btn_make.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_make.Name = "btn_make";
            this.btn_make.Size = new System.Drawing.Size(61, 29);
            this.btn_make.TabIndex = 161;
            this.btn_make.Text = "Create";
            this.btn_make.UseVisualStyleBackColor = false;
            this.btn_make.Click += new System.EventHandler(this.btn_make_Click);
            // 
            // tb_path
            // 
            this.tb_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tb_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_path.Enabled = false;
            this.tb_path.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb_path.ForeColor = System.Drawing.Color.Silver;
            this.tb_path.Location = new System.Drawing.Point(51, 6);
            this.tb_path.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(322, 20);
            this.tb_path.TabIndex = 162;
            this.tb_path.TextChanged += new System.EventHandler(this.tb_path_TextChanged);
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.label_path.Location = new System.Drawing.Point(12, 9);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(34, 13);
            this.label_path.TabIndex = 163;
            this.label_path.Text = "Path:";
            // 
            // cb_reverse
            // 
            this.cb_reverse.AutoSize = true;
            this.cb_reverse.BackColor = System.Drawing.Color.Black;
            this.cb_reverse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_reverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_reverse.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_reverse.ForeColor = System.Drawing.Color.Silver;
            this.cb_reverse.Location = new System.Drawing.Point(11, 101);
            this.cb_reverse.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_reverse.Name = "cb_reverse";
            this.cb_reverse.Size = new System.Drawing.Size(95, 17);
            this.cb_reverse.TabIndex = 164;
            this.cb_reverse.Text = "Reverse Order";
            this.cb_reverse.UseVisualStyleBackColor = false;
            this.cb_reverse.CheckedChanged += new System.EventHandler(this.cb_reverse_CheckedChanged);
            // 
            // fapmap_playlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(384, 131);
            this.Controls.Add(this.cb_reverse);
            this.Controls.Add(this.label_path);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.btn_make);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.tb_keyword);
            this.Controls.Add(this.cb_keyword);
            this.Controls.Add(this.cb_rmlogs);
            this.Controls.Add(this.cb_random);
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.Silver;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 170);
            this.Name = "fapmap_playlist";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Playlist";
            this.Load += new System.EventHandler(this.fapmap_playlist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_random;
        private System.Windows.Forms.CheckBox cb_rmlogs;
        private System.Windows.Forms.CheckBox cb_keyword;
        private System.Windows.Forms.TextBox tb_keyword;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_make;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.CheckBox cb_reverse;
    }
}