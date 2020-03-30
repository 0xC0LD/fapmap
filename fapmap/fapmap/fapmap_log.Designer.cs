namespace fapmap
{
    partial class fapmap_log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_log));
            this.logs = new fapmap_res.FapMapListView();
            this.logs_clm_num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logs_clm_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logs_clm_action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logs_clm_text = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logs_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.logs_RMB_reload = new System.Windows.Forms.ToolStripMenuItem();
            this.logs_RMB_open = new System.Windows.Forms.ToolStripMenuItem();
            this.logs_RMB_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.logs_RMB_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.lable_status = new System.Windows.Forms.Label();
            this.logs_border = new fapmap_res.FapMapPanel();
            this.logs_RMB.SuspendLayout();
            this.logs_border.SuspendLayout();
            this.SuspendLayout();
            // 
            // logs
            // 
            this.logs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logs.AutoArrange = false;
            this.logs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.logs.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.logs.BackgroundImageTiled = true;
            this.logs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.logs_clm_num,
            this.logs_clm_time,
            this.logs_clm_action,
            this.logs_clm_text});
            this.logs.ContextMenuStrip = this.logs_RMB;
            this.logs.ForeColor = System.Drawing.Color.MediumPurple;
            this.logs.FullRowSelect = true;
            this.logs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.logs.HideSelection = false;
            this.logs.Location = new System.Drawing.Point(1, 1);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(858, 421);
            this.logs.TabIndex = 1;
            this.logs.UseCompatibleStateImageBehavior = false;
            this.logs.View = System.Windows.Forms.View.Details;
            this.logs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.logs_KeyDown);
            this.logs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.logs_KeyUp);
            this.logs.LostFocus += new System.EventHandler(this.logs_LostFocus);
            this.logs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.logs_MouseDoubleClick);
            this.logs.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.logs_MouseWheel);
            // 
            // logs_clm_num
            // 
            this.logs_clm_num.Text = "#";
            this.logs_clm_num.Width = 20;
            // 
            // logs_clm_time
            // 
            this.logs_clm_time.Text = "TIME";
            this.logs_clm_time.Width = 40;
            // 
            // logs_clm_action
            // 
            this.logs_clm_action.Text = "ACTION";
            this.logs_clm_action.Width = 50;
            // 
            // logs_clm_text
            // 
            this.logs_clm_text.Text = "TEXT";
            this.logs_clm_text.Width = 45;
            // 
            // logs_RMB
            // 
            this.logs_RMB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.logs_RMB.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.logs_RMB.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.logs_RMB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logs_RMB_reload,
            this.logs_RMB_open,
            this.logs_RMB_copy,
            this.logs_RMB_edit});
            this.logs_RMB.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.logs_RMB.Name = "contextMenuStrip1";
            this.logs_RMB.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.logs_RMB.ShowItemToolTips = false;
            this.logs_RMB.Size = new System.Drawing.Size(194, 92);
            // 
            // logs_RMB_reload
            // 
            this.logs_RMB_reload.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.logs_RMB_reload.ForeColor = System.Drawing.Color.MediumPurple;
            this.logs_RMB_reload.Image = global::fapmap.Properties.Resources.restart;
            this.logs_RMB_reload.Name = "logs_RMB_reload";
            this.logs_RMB_reload.Size = new System.Drawing.Size(193, 22);
            this.logs_RMB_reload.Text = "Reload (CTRL+R/F5)";
            this.logs_RMB_reload.Click += new System.EventHandler(this.logs_RMB_reload_Click);
            // 
            // logs_RMB_open
            // 
            this.logs_RMB_open.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.logs_RMB_open.ForeColor = System.Drawing.Color.MediumPurple;
            this.logs_RMB_open.Image = global::fapmap.Properties.Resources.incognito;
            this.logs_RMB_open.Name = "logs_RMB_open";
            this.logs_RMB_open.Size = new System.Drawing.Size(193, 22);
            this.logs_RMB_open.Text = "Open (ENTER/CTRL+W)";
            this.logs_RMB_open.Click += new System.EventHandler(this.logs_RMB_open_Click);
            // 
            // logs_RMB_copy
            // 
            this.logs_RMB_copy.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.logs_RMB_copy.ForeColor = System.Drawing.Color.MediumPurple;
            this.logs_RMB_copy.Image = global::fapmap.Properties.Resources.copy;
            this.logs_RMB_copy.Name = "logs_RMB_copy";
            this.logs_RMB_copy.Size = new System.Drawing.Size(193, 22);
            this.logs_RMB_copy.Text = "Copy (CTRL+C)";
            this.logs_RMB_copy.Click += new System.EventHandler(this.logs_RMB_copy_Click);
            // 
            // logs_RMB_edit
            // 
            this.logs_RMB_edit.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.logs_RMB_edit.ForeColor = System.Drawing.Color.MediumPurple;
            this.logs_RMB_edit.Image = global::fapmap.Properties.Resources.edit;
            this.logs_RMB_edit.Name = "logs_RMB_edit";
            this.logs_RMB_edit.Size = new System.Drawing.Size(193, 22);
            this.logs_RMB_edit.Text = "Edit Logs (CTRL+E)";
            this.logs_RMB_edit.Click += new System.EventHandler(this.logs_RMB_edit_Click);
            // 
            // lable_status
            // 
            this.lable_status.AutoSize = true;
            this.lable_status.BackColor = System.Drawing.Color.Transparent;
            this.lable_status.ForeColor = System.Drawing.Color.YellowGreen;
            this.lable_status.Location = new System.Drawing.Point(12, 10);
            this.lable_status.Name = "lable_status";
            this.lable_status.Size = new System.Drawing.Size(25, 13);
            this.lable_status.TabIndex = 0;
            this.lable_status.Text = "...";
            // 
            // logs_border
            // 
            this.logs_border.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logs_border.Controls.Add(this.logs);
            this.logs_border.Location = new System.Drawing.Point(12, 26);
            this.logs_border.Name = "logs_border";
            this.logs_border.Size = new System.Drawing.Size(860, 423);
            this.logs_border.TabIndex = 2;
            // 
            // fapmap_log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.logs_border);
            this.Controls.Add(this.lable_status);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.MediumPurple;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 220);
            this.Name = "fapmap_log";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - Logs";
            this.Load += new System.EventHandler(this.fapmap_log_Load);
            this.logs_RMB.ResumeLayout(false);
            this.logs_border.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion
        private fapmap_res.FapMapListView logs;
        private System.Windows.Forms.ColumnHeader logs_clm_num;
        private System.Windows.Forms.ColumnHeader logs_clm_action;
        private System.Windows.Forms.ColumnHeader logs_clm_text;
        private System.Windows.Forms.ColumnHeader logs_clm_time;
        private System.Windows.Forms.ContextMenuStrip logs_RMB;
        private System.Windows.Forms.ToolStripMenuItem logs_RMB_reload;
        private System.Windows.Forms.ToolStripMenuItem logs_RMB_open;
        private System.Windows.Forms.ToolStripMenuItem logs_RMB_copy;
        private System.Windows.Forms.ToolStripMenuItem logs_RMB_edit;
        private System.Windows.Forms.Label lable_status;
        private fapmap_res.FapMapPanel logs_border;
    }
}