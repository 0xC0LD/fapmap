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
            this.treeView = new System.Windows.Forms.TreeView();
            this.treeView_RMB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.treeView_RMB_reload = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_RMB_select = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_RMB_collapseTree = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_RMB_expandTree = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_icons = new System.Windows.Forms.ImageList(this.components);
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.treeView_RMB.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView.ContextMenuStrip = this.treeView_RMB;
            this.treeView.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeView.ForeColor = System.Drawing.Color.SlateBlue;
            this.treeView.FullRowSelect = true;
            this.treeView.HideSelection = false;
            this.treeView.HotTracking = true;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.treeView_icons;
            this.treeView.Indent = 16;
            this.treeView.ItemHeight = 16;
            this.treeView.LineColor = System.Drawing.Color.SlateBlue;
            this.treeView.Location = new System.Drawing.Point(12, 38);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(580, 274);
            this.treeView.TabIndex = 142;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyDown);
            // 
            // treeView_RMB
            // 
            this.treeView_RMB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(6)))), ((int)(((byte)(15)))));
            this.treeView_RMB.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.treeView_RMB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treeView_RMB_reload,
            this.treeView_RMB_select,
            this.treeView_RMB_collapseTree,
            this.treeView_RMB_expandTree});
            this.treeView_RMB.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.treeView_RMB.Name = "contextMenuStrip2";
            this.treeView_RMB.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.treeView_RMB.ShowItemToolTips = false;
            this.treeView_RMB.Size = new System.Drawing.Size(238, 92);
            // 
            // treeView_RMB_reload
            // 
            this.treeView_RMB_reload.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.treeView_RMB_reload.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.treeView_RMB_reload.ForeColor = System.Drawing.Color.SlateBlue;
            this.treeView_RMB_reload.Image = global::fapmap.Properties.Resources.restart;
            this.treeView_RMB_reload.Name = "treeView_RMB_reload";
            this.treeView_RMB_reload.Size = new System.Drawing.Size(237, 22);
            this.treeView_RMB_reload.Text = "Reload (CTRL+R/F5)";
            this.treeView_RMB_reload.Click += new System.EventHandler(this.treeView_RMB_reload_Click);
            // 
            // treeView_RMB_select
            // 
            this.treeView_RMB_select.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.treeView_RMB_select.ForeColor = System.Drawing.Color.SlateBlue;
            this.treeView_RMB_select.Image = global::fapmap.Properties.Resources.folder;
            this.treeView_RMB_select.Name = "treeView_RMB_select";
            this.treeView_RMB_select.Size = new System.Drawing.Size(237, 22);
            this.treeView_RMB_select.Text = "Select Folder (CTRL+W/SPACE)";
            this.treeView_RMB_select.Click += new System.EventHandler(this.faftv_RMB_select_Click);
            // 
            // treeView_RMB_collapseTree
            // 
            this.treeView_RMB_collapseTree.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.treeView_RMB_collapseTree.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.treeView_RMB_collapseTree.ForeColor = System.Drawing.Color.SlateBlue;
            this.treeView_RMB_collapseTree.Image = global::fapmap.Properties.Resources.arrow_up;
            this.treeView_RMB_collapseTree.Name = "treeView_RMB_collapseTree";
            this.treeView_RMB_collapseTree.Size = new System.Drawing.Size(237, 22);
            this.treeView_RMB_collapseTree.Text = "Collapse Tree (CTRL+Q)";
            this.treeView_RMB_collapseTree.Click += new System.EventHandler(this.treeView_RMB_collapseTree_Click);
            // 
            // treeView_RMB_expandTree
            // 
            this.treeView_RMB_expandTree.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.treeView_RMB_expandTree.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.treeView_RMB_expandTree.ForeColor = System.Drawing.Color.SlateBlue;
            this.treeView_RMB_expandTree.Image = global::fapmap.Properties.Resources.arrow_down;
            this.treeView_RMB_expandTree.Name = "treeView_RMB_expandTree";
            this.treeView_RMB_expandTree.Size = new System.Drawing.Size(237, 22);
            this.treeView_RMB_expandTree.Text = "Expand Tree (CTRL+E)";
            this.treeView_RMB_expandTree.Click += new System.EventHandler(this.treeView_RMB_expandTree_Click);
            // 
            // treeView_icons
            // 
            this.treeView_icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeView_icons.ImageStream")));
            this.treeView_icons.TransparentColor = System.Drawing.Color.Transparent;
            this.treeView_icons.Images.SetKeyName(0, "dir.ico");
            // 
            // txt_path
            // 
            this.txt_path.AllowDrop = true;
            this.txt_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txt_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_path.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_path.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txt_path.ForeColor = System.Drawing.Color.SlateBlue;
            this.txt_path.Location = new System.Drawing.Point(12, 11);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(580, 21);
            this.txt_path.TabIndex = 143;
            this.txt_path.TextChanged += new System.EventHandler(this.txt_path_TextChanged);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.BackColor = System.Drawing.Color.Transparent;
            this.btn_ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ok.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_ok.Location = new System.Drawing.Point(466, 319);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(61, 29);
            this.btn_ok.TabIndex = 163;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_ok_MouseUp);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_cancel.Location = new System.Drawing.Point(531, 319);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(61, 29);
            this.btn_cancel.TabIndex = 162;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_cancel_MouseUp);
            // 
            // fapmap_dirSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 10F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BackgroundImage = global::fapmap.Properties.Resources.bg4;
            this.ClientSize = new System.Drawing.Size(604, 361);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.treeView);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "fapmap_dirSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FapMap - Select Path:";
            this.Load += new System.EventHandler(this.fapmap_downloadPathSelect_Load);
            this.treeView_RMB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.ImageList treeView_icons;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ContextMenuStrip treeView_RMB;
        private System.Windows.Forms.ToolStripMenuItem treeView_RMB_reload;
        private System.Windows.Forms.ToolStripMenuItem treeView_RMB_collapseTree;
        private System.Windows.Forms.ToolStripMenuItem treeView_RMB_expandTree;
        private System.Windows.Forms.ToolStripMenuItem treeView_RMB_select;
    }
}