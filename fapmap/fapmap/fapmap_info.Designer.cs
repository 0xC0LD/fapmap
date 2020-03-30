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
            this.cb_noZero = new System.Windows.Forms.CheckBox();
            this.label_path = new System.Windows.Forms.Label();
            this.btn_getInfo = new System.Windows.Forms.Button();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.label_info = new System.Windows.Forms.Label();
            this.txt_output = new System.Windows.Forms.RichTextBox();
            this.txt_output_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txt_output_RMB_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_size = new System.Windows.Forms.TextBox();
            this.showImage = new System.Windows.Forms.PictureBox();
            this.txt_output_border = new fapmap_res.FapMapPanel();
            this.txt_size_border = new fapmap_res.FapMapPanel();
            this.txt_output_RMB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showImage)).BeginInit();
            this.txt_output_border.SuspendLayout();
            this.txt_size_border.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_noZero
            // 
            this.cb_noZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_noZero.AutoSize = true;
            this.cb_noZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cb_noZero.Checked = true;
            this.cb_noZero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_noZero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_noZero.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.cb_noZero.FlatAppearance.CheckedBackColor = System.Drawing.Color.MediumPurple;
            this.cb_noZero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_noZero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cb_noZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_noZero.Font = new System.Drawing.Font("Segoe Print", 24F);
            this.cb_noZero.ForeColor = System.Drawing.Color.SlateBlue;
            this.cb_noZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_noZero.Location = new System.Drawing.Point(620, 401);
            this.cb_noZero.Name = "cb_noZero";
            this.cb_noZero.Size = new System.Drawing.Size(12, 11);
            this.cb_noZero.TabIndex = 3;
            this.HelpBalloon.SetToolTip(this.cb_noZero, "Don\'t output file types that have a 0 count...");
            this.cb_noZero.UseVisualStyleBackColor = false;
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.BackColor = System.Drawing.Color.Transparent;
            this.label_path.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_path.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label_path.Location = new System.Drawing.Point(145, 78);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(40, 22);
            this.label_path.TabIndex = 0;
            this.label_path.Text = "...";
            // 
            // btn_getInfo
            // 
            this.btn_getInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_getInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_getInfo.BackgroundImage = global::fapmap.Properties.Resources.arrow_left;
            this.btn_getInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_getInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_getInfo.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_getInfo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_getInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_getInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btn_getInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_getInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_getInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_getInfo.Location = new System.Drawing.Point(607, 111);
            this.btn_getInfo.Name = "btn_getInfo";
            this.btn_getInfo.Size = new System.Drawing.Size(25, 25);
            this.btn_getInfo.TabIndex = 2;
            this.HelpBalloon.SetToolTip(this.btn_getInfo, "Get Info About File/Dir");
            this.btn_getInfo.UseVisualStyleBackColor = false;
            this.btn_getInfo.Click += new System.EventHandler(this.btn_getInfo_Click);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.MediumPurple;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // label_info
            // 
            this.label_info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_info.AutoSize = true;
            this.label_info.BackColor = System.Drawing.Color.Transparent;
            this.label_info.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label_info.Location = new System.Drawing.Point(12, 397);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(28, 15);
            this.label_info.TabIndex = 221;
            this.label_info.Text = "...";
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
            this.txt_output.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_output.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txt_output.Location = new System.Drawing.Point(1, 1);
            this.txt_output.Name = "txt_output";
            this.txt_output.ReadOnly = true;
            this.txt_output.Size = new System.Drawing.Size(618, 250);
            this.txt_output.TabIndex = 4;
            this.txt_output.Text = "...";
            this.txt_output.WordWrap = false;
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
            // txt_size
            // 
            this.txt_size.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_size.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txt_size.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_size.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_size.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txt_size.Location = new System.Drawing.Point(1, 1);
            this.txt_size.Name = "txt_size";
            this.txt_size.ReadOnly = true;
            this.txt_size.Size = new System.Drawing.Size(457, 23);
            this.txt_size.TabIndex = 1;
            this.txt_size.Text = "...";
            // 
            // showImage
            // 
            this.showImage.BackColor = System.Drawing.Color.Transparent;
            this.showImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showImage.Image = global::fapmap.Properties.Resources.image;
            this.showImage.Location = new System.Drawing.Point(12, 12);
            this.showImage.Name = "showImage";
            this.showImage.Size = new System.Drawing.Size(124, 124);
            this.showImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showImage.TabIndex = 225;
            this.showImage.TabStop = false;
            // 
            // txt_output_border
            // 
            this.txt_output_border.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_output_border.Controls.Add(this.txt_output);
            this.txt_output_border.Location = new System.Drawing.Point(12, 142);
            this.txt_output_border.Name = "txt_output_border";
            this.txt_output_border.Size = new System.Drawing.Size(620, 252);
            this.txt_output_border.TabIndex = 226;
            // 
            // txt_size_border
            // 
            this.txt_size_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_size_border.Controls.Add(this.txt_size);
            this.txt_size_border.Location = new System.Drawing.Point(142, 111);
            this.txt_size_border.Name = "txt_size_border";
            this.txt_size_border.Size = new System.Drawing.Size(459, 25);
            this.txt_size_border.TabIndex = 227;
            // 
            // fapmap_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(644, 421);
            this.Controls.Add(this.txt_size_border);
            this.Controls.Add(this.txt_output_border);
            this.Controls.Add(this.showImage);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.btn_getInfo);
            this.Controls.Add(this.label_path);
            this.Controls.Add(this.cb_noZero);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.MediumPurple;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(320, 270);
            this.Name = "fapmap_info";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - Info";
            this.Load += new System.EventHandler(this.fapmap_info_Load);
            this.txt_output_RMB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showImage)).EndInit();
            this.txt_output_border.ResumeLayout(false);
            this.txt_size_border.ResumeLayout(false);
            this.txt_size_border.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cb_noZero;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Button btn_getInfo;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.RichTextBox txt_output;
        private System.Windows.Forms.TextBox txt_size;
        private System.Windows.Forms.PictureBox showImage;
        private System.Windows.Forms.ContextMenuStrip txt_output_RMB;
        private System.Windows.Forms.ToolStripMenuItem txt_output_RMB_copy;
        private fapmap_res.FapMapPanel txt_output_border;
        private fapmap_res.FapMapPanel txt_size_border;
    }
}