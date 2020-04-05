namespace fapmap
{
    partial class fapmap_dirSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_dirSelect));
            this.treeView = new fapmap_res.FapMapTreeView();
            this.treeView_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.treeView_RMB_reload = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_RMB_select = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_RMB_collapseTree = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_RMB_expandTree = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_icons = new System.Windows.Forms.ImageList(this.components);
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.treeView_border = new fapmap_res.FapMapPanel();
            this.txt_path_border = new fapmap_res.FapMapPanel();
            this.treeView_RMB.SuspendLayout();
            this.treeView_border.SuspendLayout();
            this.txt_path_border.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.ContextMenuStrip = this.treeView_RMB;
            this.treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treeView.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeView.ForeColor = System.Drawing.Color.HotPink;
            this.treeView.FullRowSelect = true;
            this.treeView.HideSelection = false;
            this.treeView.HotTracking = true;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.treeView_icons;
            this.treeView.Indent = 16;
            this.treeView.ItemHeight = 16;
            this.treeView.LineColor = System.Drawing.Color.HotPink;
            this.treeView.Location = new System.Drawing.Point(1, 1);
            this.treeView.Margin = new System.Windows.Forms.Padding(4);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(699, 366);
            this.treeView.TabIndex = 2;
            this.treeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView_DrawNode);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyDown);
            // 
            // treeView_RMB
            // 
            this.treeView_RMB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.treeView_RMB.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.treeView_RMB.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.treeView_RMB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treeView_RMB_reload,
            this.treeView_RMB_select,
            this.treeView_RMB_collapseTree,
            this.treeView_RMB_expandTree});
            this.treeView_RMB.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.treeView_RMB.Name = "contextMenuStrip2";
            this.treeView_RMB.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.treeView_RMB.ShowItemToolTips = false;
            this.treeView_RMB.Size = new System.Drawing.Size(229, 92);
            // 
            // treeView_RMB_reload
            // 
            this.treeView_RMB_reload.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.treeView_RMB_reload.ForeColor = System.Drawing.Color.HotPink;
            this.treeView_RMB_reload.Image = global::fapmap.Properties.Resources.restart_hotpink;
            this.treeView_RMB_reload.Name = "treeView_RMB_reload";
            this.treeView_RMB_reload.Size = new System.Drawing.Size(228, 22);
            this.treeView_RMB_reload.Text = "Reload (CTRL+R/F5)";
            this.treeView_RMB_reload.Click += new System.EventHandler(this.treeView_RMB_reload_Click);
            // 
            // treeView_RMB_select
            // 
            this.treeView_RMB_select.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.treeView_RMB_select.ForeColor = System.Drawing.Color.HotPink;
            this.treeView_RMB_select.Image = global::fapmap.Properties.Resources.explorer_hotpink;
            this.treeView_RMB_select.Name = "treeView_RMB_select";
            this.treeView_RMB_select.Size = new System.Drawing.Size(228, 22);
            this.treeView_RMB_select.Text = "Select Folder (CTRL+W/SPACE)";
            this.treeView_RMB_select.Click += new System.EventHandler(this.faftv_RMB_select_Click);
            // 
            // treeView_RMB_collapseTree
            // 
            this.treeView_RMB_collapseTree.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.treeView_RMB_collapseTree.ForeColor = System.Drawing.Color.HotPink;
            this.treeView_RMB_collapseTree.Image = global::fapmap.Properties.Resources.arrow_up_hotpink;
            this.treeView_RMB_collapseTree.Name = "treeView_RMB_collapseTree";
            this.treeView_RMB_collapseTree.Size = new System.Drawing.Size(228, 22);
            this.treeView_RMB_collapseTree.Text = "Collapse Tree (CTRL+Q)";
            this.treeView_RMB_collapseTree.Click += new System.EventHandler(this.treeView_RMB_collapseTree_Click);
            // 
            // treeView_RMB_expandTree
            // 
            this.treeView_RMB_expandTree.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.treeView_RMB_expandTree.ForeColor = System.Drawing.Color.HotPink;
            this.treeView_RMB_expandTree.Image = global::fapmap.Properties.Resources.arrow_down_hotpink;
            this.treeView_RMB_expandTree.Name = "treeView_RMB_expandTree";
            this.treeView_RMB_expandTree.Size = new System.Drawing.Size(228, 22);
            this.treeView_RMB_expandTree.Text = "Expand Tree (CTRL+E)";
            this.treeView_RMB_expandTree.Click += new System.EventHandler(this.treeView_RMB_expandTree_Click);
            // 
            // treeView_icons
            // 
            this.treeView_icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeView_icons.ImageStream")));
            this.treeView_icons.TransparentColor = System.Drawing.Color.Transparent;
            this.treeView_icons.Images.SetKeyName(0, "dir_hotpink.ico");
            // 
            // txt_path
            // 
            this.txt_path.AllowDrop = true;
            this.txt_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.txt_path.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_path.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_path.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.txt_path.ForeColor = System.Drawing.Color.HotPink;
            this.txt_path.Location = new System.Drawing.Point(1, 1);
            this.txt_path.Margin = new System.Windows.Forms.Padding(4);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(699, 16);
            this.txt_path.TabIndex = 1;
            this.txt_path.TextChanged += new System.EventHandler(this.txt_path_TextChanged);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.btn_ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ok.FlatAppearance.BorderColor = System.Drawing.Color.HotPink;
            this.btn_ok.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.btn_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.btn_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_ok.ForeColor = System.Drawing.Color.HotPink;
            this.btn_ok.Location = new System.Drawing.Point(543, 416);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(84, 39);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.FlatAppearance.BorderColor = System.Drawing.Color.HotPink;
            this.btn_cancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_cancel.ForeColor = System.Drawing.Color.HotPink;
            this.btn_cancel.Location = new System.Drawing.Point(629, 416);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(84, 39);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // treeView_border
            // 
            this.treeView_border.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView_border.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.treeView_border.Controls.Add(this.treeView);
            this.treeView_border.ForeColor = System.Drawing.Color.HotPink;
            this.treeView_border.Location = new System.Drawing.Point(12, 40);
            this.treeView_border.Name = "treeView_border";
            this.treeView_border.Size = new System.Drawing.Size(701, 368);
            this.treeView_border.TabIndex = 5;
            // 
            // txt_path_border
            // 
            this.txt_path_border.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_path_border.Controls.Add(this.txt_path);
            this.txt_path_border.ForeColor = System.Drawing.Color.HotPink;
            this.txt_path_border.Location = new System.Drawing.Point(12, 12);
            this.txt_path_border.Name = "txt_path_border";
            this.txt_path_border.Size = new System.Drawing.Size(701, 22);
            this.txt_path_border.TabIndex = 6;
            // 
            // fapmap_dirSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(725, 469);
            this.Controls.Add(this.txt_path_border);
            this.Controls.Add(this.treeView_border);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(417, 248);
            this.Name = "fapmap_dirSelect";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FapMap - Select Path:";
            this.Load += new System.EventHandler(this.fapmap_downloadPathSelect_Load);
            this.treeView_RMB.ResumeLayout(false);
            this.treeView_border.ResumeLayout(false);
            this.txt_path_border.ResumeLayout(false);
            this.txt_path_border.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private fapmap_res.FapMapTreeView treeView;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.ImageList treeView_icons;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ContextMenuStrip treeView_RMB;
        private System.Windows.Forms.ToolStripMenuItem treeView_RMB_reload;
        private System.Windows.Forms.ToolStripMenuItem treeView_RMB_collapseTree;
        private System.Windows.Forms.ToolStripMenuItem treeView_RMB_expandTree;
        private System.Windows.Forms.ToolStripMenuItem treeView_RMB_select;
        private fapmap_res.FapMapPanel treeView_border;
        private fapmap_res.FapMapPanel txt_path_border;
    }
}