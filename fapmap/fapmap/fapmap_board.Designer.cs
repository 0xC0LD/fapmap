namespace fapmap
{
    partial class fapmap_board
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_board));
            this.board_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.board_RMB_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.board_RMB_openAndExit = new System.Windows.Forms.ToolStripMenuItem();
            this.board_RMB_open = new System.Windows.Forms.ToolStripMenuItem();
            this.board_RMB_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.board_RMB_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.favicons = new System.Windows.Forms.ImageList(this.components);
            this.board = new fapmap_res.FapMapListView();
            this.board_clm_num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.board_clm_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.board_clm_url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.board_RMB.SuspendLayout();
            this.SuspendLayout();
            // 
            // board_RMB
            // 
            this.board_RMB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.board_RMB.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.board_RMB.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.board_RMB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.board_RMB_refresh,
            this.board_RMB_openAndExit,
            this.board_RMB_open,
            this.board_RMB_copy,
            this.board_RMB_edit});
            this.board_RMB.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.board_RMB.Name = "contextMenuStrip1";
            this.board_RMB.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.board_RMB.ShowItemToolTips = false;
            this.board_RMB.Size = new System.Drawing.Size(269, 136);
            // 
            // board_RMB_refresh
            // 
            this.board_RMB_refresh.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.board_RMB_refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.board_RMB_refresh.Image = global::fapmap.Properties.Resources.restart;
            this.board_RMB_refresh.Name = "board_RMB_refresh";
            this.board_RMB_refresh.Size = new System.Drawing.Size(268, 22);
            this.board_RMB_refresh.Text = "Refresh (CTRL+R/F5)";
            this.board_RMB_refresh.Click += new System.EventHandler(this.board_RMB_refresh_Click);
            // 
            // board_RMB_openAndExit
            // 
            this.board_RMB_openAndExit.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.board_RMB_openAndExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.board_RMB_openAndExit.Image = global::fapmap.Properties.Resources.incognito;
            this.board_RMB_openAndExit.Name = "board_RMB_openAndExit";
            this.board_RMB_openAndExit.Size = new System.Drawing.Size(268, 22);
            this.board_RMB_openAndExit.Text = "Open And Exit (ENTER/CTRL+W/MMB)";
            this.board_RMB_openAndExit.Click += new System.EventHandler(this.board_RMB_openAndExit_Click);
            // 
            // board_RMB_open
            // 
            this.board_RMB_open.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.board_RMB_open.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.board_RMB_open.Image = global::fapmap.Properties.Resources.incognito;
            this.board_RMB_open.Name = "board_RMB_open";
            this.board_RMB_open.Size = new System.Drawing.Size(268, 22);
            this.board_RMB_open.Text = "Open (CTRL+Q/2LMB)";
            this.board_RMB_open.Click += new System.EventHandler(this.board_RMB_open_Click);
            // 
            // board_RMB_copy
            // 
            this.board_RMB_copy.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.board_RMB_copy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.board_RMB_copy.Image = global::fapmap.Properties.Resources.copy;
            this.board_RMB_copy.Name = "board_RMB_copy";
            this.board_RMB_copy.Size = new System.Drawing.Size(268, 22);
            this.board_RMB_copy.Text = "Copy URL And Exit (CTRL+C)";
            this.board_RMB_copy.Click += new System.EventHandler(this.board_RMB_copy_Click);
            // 
            // board_RMB_edit
            // 
            this.board_RMB_edit.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.board_RMB_edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.board_RMB_edit.Image = global::fapmap.Properties.Resources.edit;
            this.board_RMB_edit.Name = "board_RMB_edit";
            this.board_RMB_edit.Size = new System.Drawing.Size(268, 22);
            this.board_RMB_edit.Text = "Edit Board (CTRL+E)";
            this.board_RMB_edit.Click += new System.EventHandler(this.board_RMB_edit_Click);
            // 
            // favicons
            // 
            this.favicons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.favicons.ImageSize = new System.Drawing.Size(16, 16);
            this.favicons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // board
            // 
            this.board.AllowDrop = true;
            this.board.AutoArrange = false;
            this.board.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.board.BackgroundImage = global::fapmap.Properties.Resources.bg3;
            this.board.BackgroundImageTiled = true;
            this.board.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.board.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.board_clm_num,
            this.board_clm_name,
            this.board_clm_url});
            this.board.ContextMenuStrip = this.board_RMB;
            this.board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.board.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.board.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.board.FullRowSelect = true;
            this.board.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.board.HideSelection = false;
            this.board.LargeImageList = this.favicons;
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.MultiSelect = false;
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(764, 761);
            this.board.SmallImageList = this.favicons;
            this.board.TabIndex = 1;
            this.board.UseCompatibleStateImageBehavior = false;
            this.board.View = System.Windows.Forms.View.Details;
            this.board.SelectedIndexChanged += new System.EventHandler(this.board_SelectedIndexChanged);
            this.board.DragOver += new System.Windows.Forms.DragEventHandler(this.board_DragOver);
            this.board.KeyDown += new System.Windows.Forms.KeyEventHandler(this.board_KeyDown);
            this.board.KeyUp += new System.Windows.Forms.KeyEventHandler(this.board_KeyUp);
            this.board.LostFocus += new System.EventHandler(this.board_LostFocus);
            this.board.MouseDown += new System.Windows.Forms.MouseEventHandler(this.board_MouseDown);
            this.board.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.board_MouseWheel);
            // 
            // board_clm_num
            // 
            this.board_clm_num.Text = "";
            this.board_clm_num.Width = 1;
            // 
            // board_clm_name
            // 
            this.board_clm_name.Text = "NAME";
            this.board_clm_name.Width = 1;
            // 
            // board_clm_url
            // 
            this.board_clm_url.Text = "URL";
            this.board_clm_url.Width = 1;
            // 
            // fapmap_board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(764, 761);
            this.Controls.Add(this.board);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 190);
            this.Name = "fapmap_board";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap - URL Board";
            this.Load += new System.EventHandler(this.fapmap_board_Load);
            this.board_RMB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        



        #endregion

        private fapmap_res.FapMapListView board;
        private System.Windows.Forms.ColumnHeader board_clm_name;
        private System.Windows.Forms.ColumnHeader board_clm_url;
        private System.Windows.Forms.ColumnHeader board_clm_num;
        private System.Windows.Forms.ImageList favicons;
        private System.Windows.Forms.ContextMenuStrip board_RMB;
        private System.Windows.Forms.ToolStripMenuItem board_RMB_refresh;
        private System.Windows.Forms.ToolStripMenuItem board_RMB_open;
        private System.Windows.Forms.ToolStripMenuItem board_RMB_openAndExit;
        private System.Windows.Forms.ToolStripMenuItem board_RMB_copy;
        private System.Windows.Forms.ToolStripMenuItem board_RMB_edit;
    }
}