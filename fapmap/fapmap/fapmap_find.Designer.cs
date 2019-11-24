namespace fapmap
{
    partial class fapmap_find
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_find));
            this.OutputBorder = new System.Windows.Forms.Panel();
            this.showImage = new System.Windows.Forms.PictureBox();
            this.Output = new System.Windows.Forms.ListBox();
            this.RMB_output = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RMB_output_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.RMB_output_open = new System.Windows.Forms.ToolStripMenuItem();
            this.RMB_output_explorer = new System.Windows.Forms.ToolStripMenuItem();
            this.RMB_output_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.RMB_output_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.findStart = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.cb_case = new System.Windows.Forms.CheckBox();
            this.cb_showImage = new System.Windows.Forms.CheckBox();
            this.resultNum = new System.Windows.Forms.Label();
            this.OutputBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showImage)).BeginInit();
            this.RMB_output.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputBorder
            // 
            this.OutputBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputBorder.Controls.Add(this.showImage);
            this.OutputBorder.Controls.Add(this.Output);
            this.OutputBorder.Location = new System.Drawing.Point(12, 38);
            this.OutputBorder.Name = "OutputBorder";
            this.OutputBorder.Size = new System.Drawing.Size(444, 156);
            this.OutputBorder.TabIndex = 152;
            // 
            // showImage
            // 
            this.showImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.showImage.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.showImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.showImage.Location = new System.Drawing.Point(379, 91);
            this.showImage.Name = "showImage";
            this.showImage.Size = new System.Drawing.Size(64, 64);
            this.showImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showImage.TabIndex = 155;
            this.showImage.TabStop = false;
            this.showImage.Visible = false;
            this.showImage.Click += new System.EventHandler(this.showImage_Click);
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Output.ContextMenuStrip = this.RMB_output;
            this.Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Output.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Output.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Output.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.Output.FormattingEnabled = true;
            this.Output.Location = new System.Drawing.Point(0, 0);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(442, 154);
            this.Output.TabIndex = 145;
            this.Output.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Output_DrawItem);
            this.Output.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.Output_MeasureItem);
            this.Output.SelectedIndexChanged += new System.EventHandler(this.Output_SelectedIndexChanged);
            this.Output.DragOver += new System.Windows.Forms.DragEventHandler(this.Output_DragOver);
            this.Output.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Output_KeyDown);
            this.Output.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Output_MouseDown);
            // 
            // RMB_output
            // 
            this.RMB_output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.RMB_output.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.RMB_output.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RMB_output_refresh,
            this.RMB_output_open,
            this.RMB_output_explorer,
            this.RMB_output_copy,
            this.RMB_output_delete});
            this.RMB_output.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.RMB_output.Name = "contextMenuStrip1";
            this.RMB_output.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.RMB_output.ShowItemToolTips = false;
            this.RMB_output.Size = new System.Drawing.Size(247, 114);
            // 
            // RMB_output_refresh
            // 
            this.RMB_output_refresh.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.RMB_output_refresh.ForeColor = System.Drawing.Color.SlateBlue;
            this.RMB_output_refresh.Image = global::fapmap.Properties.Resources.restart;
            this.RMB_output_refresh.Name = "RMB_output_refresh";
            this.RMB_output_refresh.Size = new System.Drawing.Size(246, 22);
            this.RMB_output_refresh.Text = "Refresh (CTRL+R/F5)";
            this.RMB_output_refresh.Click += new System.EventHandler(this.refreshCTRLRF5ToolStripMenuItem_Click);
            // 
            // RMB_output_open
            // 
            this.RMB_output_open.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.RMB_output_open.ForeColor = System.Drawing.Color.SlateBlue;
            this.RMB_output_open.Image = global::fapmap.Properties.Resources.open;
            this.RMB_output_open.Name = "RMB_output_open";
            this.RMB_output_open.Size = new System.Drawing.Size(246, 22);
            this.RMB_output_open.Text = "Open Selected (ENTER/CTRL+W)";
            this.RMB_output_open.Click += new System.EventHandler(this.openOutputToolStripMenuItem_Click);
            // 
            // RMB_output_explorer
            // 
            this.RMB_output_explorer.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.RMB_output_explorer.ForeColor = System.Drawing.Color.SlateBlue;
            this.RMB_output_explorer.Image = global::fapmap.Properties.Resources.folder;
            this.RMB_output_explorer.Name = "RMB_output_explorer";
            this.RMB_output_explorer.Size = new System.Drawing.Size(246, 22);
            this.RMB_output_explorer.Text = "Open in Explorer (CTRL+U)";
            this.RMB_output_explorer.Click += new System.EventHandler(this.openInExplorerCTRLUToolStripMenuItem_Click);
            // 
            // RMB_output_copy
            // 
            this.RMB_output_copy.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.RMB_output_copy.ForeColor = System.Drawing.Color.SlateBlue;
            this.RMB_output_copy.Image = global::fapmap.Properties.Resources.copy;
            this.RMB_output_copy.Name = "RMB_output_copy";
            this.RMB_output_copy.Size = new System.Drawing.Size(246, 22);
            this.RMB_output_copy.Text = "Copy Location (CTRL+C)";
            this.RMB_output_copy.Click += new System.EventHandler(this.copyOuputToolStripMenuItem_Click);
            // 
            // RMB_output_delete
            // 
            this.RMB_output_delete.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.RMB_output_delete.ForeColor = System.Drawing.Color.SlateBlue;
            this.RMB_output_delete.Image = global::fapmap.Properties.Resources.delete;
            this.RMB_output_delete.Name = "RMB_output_delete";
            this.RMB_output_delete.Size = new System.Drawing.Size(246, 22);
            this.RMB_output_delete.Text = "Delete File (DEL)";
            this.RMB_output_delete.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // findStart
            // 
            this.findStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.findStart.BackgroundImage = global::fapmap.Properties.Resources.find;
            this.findStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.findStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.findStart.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.findStart.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.findStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.findStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.findStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.findStart.ForeColor = System.Drawing.Color.DimGray;
            this.findStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.findStart.Location = new System.Drawing.Point(436, 12);
            this.findStart.Name = "findStart";
            this.findStart.Size = new System.Drawing.Size(20, 20);
            this.findStart.TabIndex = 151;
            this.HelpBalloon.SetToolTip(this.findStart, "Start Searching...");
            this.findStart.UseVisualStyleBackColor = false;
            this.findStart.Click += new System.EventHandler(this.findStart_Click);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBox.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.searchBox.ForeColor = System.Drawing.Color.Teal;
            this.searchBox.Location = new System.Drawing.Point(12, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(418, 20);
            this.searchBox.TabIndex = 150;
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyDown);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.MediumPurple;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // cb_case
            // 
            this.cb_case.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_case.AutoSize = true;
            this.cb_case.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.cb_case.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_case.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_case.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_case.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.cb_case.Location = new System.Drawing.Point(445, 201);
            this.cb_case.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_case.Name = "cb_case";
            this.cb_case.Size = new System.Drawing.Size(12, 11);
            this.cb_case.TabIndex = 154;
            this.HelpBalloon.SetToolTip(this.cb_case, "Match Case");
            this.cb_case.UseVisualStyleBackColor = false;
            // 
            // cb_showImage
            // 
            this.cb_showImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_showImage.AutoSize = true;
            this.cb_showImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.cb_showImage.Checked = true;
            this.cb_showImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_showImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_showImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_showImage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cb_showImage.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.cb_showImage.Location = new System.Drawing.Point(429, 201);
            this.cb_showImage.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cb_showImage.Name = "cb_showImage";
            this.cb_showImage.Size = new System.Drawing.Size(12, 11);
            this.cb_showImage.TabIndex = 155;
            this.HelpBalloon.SetToolTip(this.cb_showImage, "Show Image Preview");
            this.cb_showImage.UseVisualStyleBackColor = false;
            // 
            // resultNum
            // 
            this.resultNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resultNum.AutoSize = true;
            this.resultNum.BackColor = System.Drawing.Color.Transparent;
            this.resultNum.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resultNum.ForeColor = System.Drawing.Color.SlateBlue;
            this.resultNum.Location = new System.Drawing.Point(12, 203);
            this.resultNum.Name = "resultNum";
            this.resultNum.Size = new System.Drawing.Size(25, 13);
            this.resultNum.TabIndex = 153;
            this.resultNum.Text = "...";
            // 
            // fapmap_find
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.ClientSize = new System.Drawing.Size(468, 225);
            this.Controls.Add(this.cb_showImage);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.cb_case);
            this.Controls.Add(this.findStart);
            this.Controls.Add(this.OutputBorder);
            this.Controls.Add(this.resultNum);
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(365, 200);
            this.Name = "fapmap_find";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAPMAP - FOLDER/FILE FINDER";
            this.Load += new System.EventHandler(this.Find_Load);
            this.OutputBorder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showImage)).EndInit();
            this.RMB_output.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel OutputBorder;
        private System.Windows.Forms.ListBox Output;
        private System.Windows.Forms.Button findStart;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.Label resultNum;
        private System.Windows.Forms.ContextMenuStrip RMB_output;
        private System.Windows.Forms.ToolStripMenuItem RMB_output_copy;
        private System.Windows.Forms.ToolStripMenuItem RMB_output_open;
        private System.Windows.Forms.ToolStripMenuItem RMB_output_delete;
        private System.Windows.Forms.ToolStripMenuItem RMB_output_refresh;
        private System.Windows.Forms.ToolStripMenuItem RMB_output_explorer;
        private System.Windows.Forms.CheckBox cb_case;
        private System.Windows.Forms.PictureBox showImage;
        private System.Windows.Forms.CheckBox cb_showImage;
    }
}