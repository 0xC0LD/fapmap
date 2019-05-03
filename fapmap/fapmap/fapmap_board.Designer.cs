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
            this.board = new System.Windows.Forms.ListView();
            this.board_num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.board_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.board_url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.favicons = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.AllowDrop = true;
            this.board.AutoArrange = false;
            this.board.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.board.BackgroundImageTiled = true;
            this.board.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.board.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.board_num,
            this.board_name,
            this.board_url});
            this.board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.board.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.board.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.board.FullRowSelect = true;
            this.board.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.board.HideSelection = false;
            this.board.LargeImageList = this.favicons;
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(855, 654);
            this.board.SmallImageList = this.favicons;
            this.board.TabIndex = 0;
            this.board.UseCompatibleStateImageBehavior = false;
            this.board.View = System.Windows.Forms.View.Details;
            this.board.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.board_DrawItem);
            this.board.SelectedIndexChanged += new System.EventHandler(this.board_SelectedIndexChanged);
            this.board.DragOver += new System.Windows.Forms.DragEventHandler(this.board_DragOver);
            this.board.KeyDown += new System.Windows.Forms.KeyEventHandler(this.board_KeyDown);
            this.board.Leave += new System.EventHandler(this.board_Leave);
            this.board.MouseDown += new System.Windows.Forms.MouseEventHandler(this.board_MouseDown);
            this.board.MouseUp += new System.Windows.Forms.MouseEventHandler(this.board_MouseUp);
            // 
            // board_num
            // 
            this.board_num.Text = "";
            this.board_num.Width = 2;
            // 
            // board_name
            // 
            this.board_name.Text = "NAME";
            this.board_name.Width = 92;
            // 
            // board_url
            // 
            this.board_url.Text = "URL";
            this.board_url.Width = 268;
            // 
            // favicons
            // 
            this.favicons.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.favicons.ImageSize = new System.Drawing.Size(16, 16);
            this.favicons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // fapmap_board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(855, 654);
            this.Controls.Add(this.board);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.Silver;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 190);
            this.Name = "fapmap_board";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAPMAP - URL BOARD";
            this.Load += new System.EventHandler(this.fapmap_board_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView board;
        private System.Windows.Forms.ColumnHeader board_name;
        private System.Windows.Forms.ColumnHeader board_url;
        private System.Windows.Forms.ColumnHeader board_num;
        private System.Windows.Forms.ImageList favicons;
    }
}