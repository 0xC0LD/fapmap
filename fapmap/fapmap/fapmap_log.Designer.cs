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
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.logs = new System.Windows.Forms.ListView();
            this.logs_clm_num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logs_clm_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logs_clm_action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logs_clm_text = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.HelpBalloon.ForeColor = System.Drawing.Color.MediumPurple;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.HelpBalloon_Draw);
            // 
            // logs
            // 
            this.logs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logs.AutoArrange = false;
            this.logs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.logs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.logs_clm_num,
            this.logs_clm_time,
            this.logs_clm_action,
            this.logs_clm_text});
            this.logs.ForeColor = System.Drawing.Color.Silver;
            this.logs.FullRowSelect = true;
            this.logs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.logs.HideSelection = false;
            this.logs.Location = new System.Drawing.Point(12, 12);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(790, 238);
            this.logs.TabIndex = 217;
            this.logs.UseCompatibleStateImageBehavior = false;
            this.logs.View = System.Windows.Forms.View.Details;
            this.logs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Logs_KeyDown);
            this.logs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.logs_MouseDoubleClick);
            // 
            // logs_clm_num
            // 
            this.logs_clm_num.Text = "#";
            this.logs_clm_num.Width = 31;
            // 
            // logs_clm_time
            // 
            this.logs_clm_time.Text = "TIME";
            this.logs_clm_time.Width = 139;
            // 
            // logs_clm_action
            // 
            this.logs_clm_action.Text = "ACTION";
            this.logs_clm_action.Width = 76;
            // 
            // logs_clm_text
            // 
            this.logs_clm_text.Text = "TEXT";
            this.logs_clm_text.Width = 375;
            // 
            // fapmap_log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(814, 262);
            this.Controls.Add(this.logs);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.Silver;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 220);
            this.Name = "fapmap_log";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAPMAP  - LOGS";
            this.Load += new System.EventHandler(this.fapmap_log_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip HelpBalloon;
        private System.Windows.Forms.ListView logs;
        private System.Windows.Forms.ColumnHeader logs_clm_num;
        private System.Windows.Forms.ColumnHeader logs_clm_action;
        private System.Windows.Forms.ColumnHeader logs_clm_text;
        private System.Windows.Forms.ColumnHeader logs_clm_time;
    }
}