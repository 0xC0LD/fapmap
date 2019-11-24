namespace fapmap
{
    partial class fapmap_ffmpeg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_ffmpeg));
            this.file = new System.Windows.Forms.TextBox();
            this.file_new = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.RichTextBox();
            this.output_panel = new System.Windows.Forms.Panel();
            this.convert = new System.Windows.Forms.Button();
            this.options = new System.Windows.Forms.TextBox();
            this.info = new System.Windows.Forms.Label();
            this.open_file_new = new System.Windows.Forms.Button();
            this.open_file = new System.Windows.Forms.Button();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.del_file = new System.Windows.Forms.Button();
            this.del_file_new = new System.Windows.Forms.Button();
            this.file_dragOut = new System.Windows.Forms.Panel();
            this.file_new_dragOut = new System.Windows.Forms.Panel();
            this.output_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // file
            // 
            this.file.AllowDrop = true;
            this.file.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.file.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.file.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.file.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.file.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.file.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.file.Location = new System.Drawing.Point(38, 12);
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(474, 20);
            this.file.TabIndex = 143;
            this.file.TextChanged += new System.EventHandler(this.file_TextChanged);
            this.file.KeyDown += new System.Windows.Forms.KeyEventHandler(this.file_KeyDown);
            // 
            // file_new
            // 
            this.file_new.AllowDrop = true;
            this.file_new.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.file_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.file_new.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.file_new.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.file_new.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.file_new.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.file_new.Location = new System.Drawing.Point(38, 37);
            this.file_new.Name = "file_new";
            this.file_new.Size = new System.Drawing.Size(499, 20);
            this.file_new.TabIndex = 144;
            this.file_new.KeyDown += new System.Windows.Forms.KeyEventHandler(this.file_new_KeyDown);
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.output.Location = new System.Drawing.Point(0, 0);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(574, 97);
            this.output.TabIndex = 145;
            this.output.Text = "";
            this.output.TextChanged += new System.EventHandler(this.output_TextChanged);
            // 
            // output_panel
            // 
            this.output_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.output_panel.Controls.Add(this.output);
            this.output_panel.Location = new System.Drawing.Point(12, 63);
            this.output_panel.Name = "output_panel";
            this.output_panel.Size = new System.Drawing.Size(576, 99);
            this.output_panel.TabIndex = 146;
            // 
            // convert
            // 
            this.convert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.convert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.convert.BackgroundImage = global::fapmap.Properties.Resources.ffmpeg;
            this.convert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.convert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.convert.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.convert.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.convert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.convert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.convert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.convert.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.convert.ForeColor = System.Drawing.Color.DimGray;
            this.convert.Location = new System.Drawing.Point(517, 12);
            this.convert.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.convert.Name = "convert";
            this.convert.Size = new System.Drawing.Size(20, 20);
            this.convert.TabIndex = 154;
            this.HelpBalloon.SetToolTip(this.convert, "Convert");
            this.convert.UseVisualStyleBackColor = false;
            this.convert.Click += new System.EventHandler(this.convert_Click);
            // 
            // options
            // 
            this.options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.options.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.options.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.options.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.options.ForeColor = System.Drawing.Color.SlateBlue;
            this.options.Location = new System.Drawing.Point(245, 168);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(343, 20);
            this.options.TabIndex = 155;
            this.options.Text = "-i";
            this.options.KeyDown += new System.Windows.Forms.KeyEventHandler(this.options_KeyDown);
            // 
            // info
            // 
            this.info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.info.AutoSize = true;
            this.info.BackColor = System.Drawing.Color.Transparent;
            this.info.ForeColor = System.Drawing.Color.SlateBlue;
            this.info.Location = new System.Drawing.Point(12, 178);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(25, 13);
            this.info.TabIndex = 156;
            this.info.Text = "...";
            // 
            // open_file_new
            // 
            this.open_file_new.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.open_file_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.open_file_new.BackgroundImage = global::fapmap.Properties.Resources.open;
            this.open_file_new.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.open_file_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.open_file_new.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.open_file_new.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.open_file_new.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.open_file_new.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.open_file_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open_file_new.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.open_file_new.ForeColor = System.Drawing.Color.DimGray;
            this.open_file_new.Location = new System.Drawing.Point(542, 37);
            this.open_file_new.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.open_file_new.Name = "open_file_new";
            this.open_file_new.Size = new System.Drawing.Size(20, 20);
            this.open_file_new.TabIndex = 157;
            this.HelpBalloon.SetToolTip(this.open_file_new, "Open File");
            this.open_file_new.UseVisualStyleBackColor = false;
            this.open_file_new.Click += new System.EventHandler(this.open_file_new_Click);
            // 
            // open_file
            // 
            this.open_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.open_file.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.open_file.BackgroundImage = global::fapmap.Properties.Resources.open;
            this.open_file.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.open_file.Cursor = System.Windows.Forms.Cursors.Hand;
            this.open_file.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.open_file.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.open_file.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.open_file.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.open_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open_file.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.open_file.ForeColor = System.Drawing.Color.DimGray;
            this.open_file.Location = new System.Drawing.Point(542, 12);
            this.open_file.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.open_file.Name = "open_file";
            this.open_file.Size = new System.Drawing.Size(20, 20);
            this.open_file.TabIndex = 158;
            this.HelpBalloon.SetToolTip(this.open_file, "Open File");
            this.open_file.UseVisualStyleBackColor = false;
            this.open_file.Click += new System.EventHandler(this.open_file_Click);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.MediumPurple;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // del_file
            // 
            this.del_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.del_file.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.del_file.BackgroundImage = global::fapmap.Properties.Resources.delete;
            this.del_file.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.del_file.Cursor = System.Windows.Forms.Cursors.Hand;
            this.del_file.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.del_file.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.del_file.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.del_file.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.del_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.del_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.del_file.ForeColor = System.Drawing.Color.DimGray;
            this.del_file.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.del_file.Location = new System.Drawing.Point(567, 12);
            this.del_file.Name = "del_file";
            this.del_file.Size = new System.Drawing.Size(20, 20);
            this.del_file.TabIndex = 169;
            this.HelpBalloon.SetToolTip(this.del_file, "Trash File (File Only)");
            this.del_file.UseVisualStyleBackColor = false;
            this.del_file.Click += new System.EventHandler(this.del_file_Click);
            // 
            // del_file_new
            // 
            this.del_file_new.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.del_file_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.del_file_new.BackgroundImage = global::fapmap.Properties.Resources.delete;
            this.del_file_new.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.del_file_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.del_file_new.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.del_file_new.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.del_file_new.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.del_file_new.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.del_file_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.del_file_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.del_file_new.ForeColor = System.Drawing.Color.DimGray;
            this.del_file_new.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.del_file_new.Location = new System.Drawing.Point(567, 37);
            this.del_file_new.Name = "del_file_new";
            this.del_file_new.Size = new System.Drawing.Size(20, 20);
            this.del_file_new.TabIndex = 170;
            this.HelpBalloon.SetToolTip(this.del_file_new, "Trash File (File Only)");
            this.del_file_new.UseVisualStyleBackColor = false;
            this.del_file_new.Click += new System.EventHandler(this.del_file_new_Click);
            // 
            // file_dragOut
            // 
            this.file_dragOut.AllowDrop = true;
            this.file_dragOut.BackgroundImage = global::fapmap.Properties.Resources.image;
            this.file_dragOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.file_dragOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.file_dragOut.Location = new System.Drawing.Point(12, 12);
            this.file_dragOut.Name = "file_dragOut";
            this.file_dragOut.Size = new System.Drawing.Size(20, 20);
            this.file_dragOut.TabIndex = 159;
            this.file_dragOut.DragOver += new System.Windows.Forms.DragEventHandler(this.file_dragOut_DragOver);
            this.file_dragOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.file_dragOut_MouseDown);
            // 
            // file_new_dragOut
            // 
            this.file_new_dragOut.AllowDrop = true;
            this.file_new_dragOut.BackgroundImage = global::fapmap.Properties.Resources.image;
            this.file_new_dragOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.file_new_dragOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.file_new_dragOut.Location = new System.Drawing.Point(12, 37);
            this.file_new_dragOut.Name = "file_new_dragOut";
            this.file_new_dragOut.Size = new System.Drawing.Size(20, 20);
            this.file_new_dragOut.TabIndex = 160;
            this.file_new_dragOut.DragOver += new System.Windows.Forms.DragEventHandler(this.file_new_dragOut_DragOver);
            this.file_new_dragOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.file_new_dragOut_MouseDown);
            // 
            // fapmap_ffmpeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(600, 200);
            this.Controls.Add(this.file_dragOut);
            this.Controls.Add(this.file);
            this.Controls.Add(this.del_file_new);
            this.Controls.Add(this.open_file_new);
            this.Controls.Add(this.file_new);
            this.Controls.Add(this.info);
            this.Controls.Add(this.del_file);
            this.Controls.Add(this.open_file);
            this.Controls.Add(this.output_panel);
            this.Controls.Add(this.options);
            this.Controls.Add(this.file_new_dragOut);
            this.Controls.Add(this.convert);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(320, 150);
            this.Name = "fapmap_ffmpeg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAPMAP - MEDIA CONVERTER (ffmpeg.exe)";
            this.Load += new System.EventHandler(this.fapmap_ffmpeg_Load);
            this.output_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox file;
        private System.Windows.Forms.TextBox file_new;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Panel output_panel;
        private System.Windows.Forms.Button convert;
        private System.Windows.Forms.TextBox options;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button open_file_new;
        private System.Windows.Forms.Button open_file;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.Panel file_dragOut;
        private System.Windows.Forms.Panel file_new_dragOut;
        private System.Windows.Forms.Button del_file;
        private System.Windows.Forms.Button del_file_new;
    }
}