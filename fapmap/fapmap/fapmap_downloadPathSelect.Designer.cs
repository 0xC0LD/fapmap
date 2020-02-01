namespace fapmap
{
    partial class fapmap_downloadPathSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmap_downloadPathSelect));
            this.listbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listbox
            // 
            this.listbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.listbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listbox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(82)))), ((int)(((byte)(189)))));
            this.listbox.FormattingEnabled = true;
            this.listbox.ItemHeight = 19;
            this.listbox.Location = new System.Drawing.Point(0, 0);
            this.listbox.Name = "listbox";
            this.listbox.Size = new System.Drawing.Size(667, 346);
            this.listbox.TabIndex = 0;
            this.listbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listbox_MouseDoubleClick);
            // 
            // fapmap_downloadPathSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 10F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(667, 346);
            this.Controls.Add(this.listbox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fapmap_downloadPathSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Path:";
            this.Load += new System.EventHandler(this.fapmap_downloadPathSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listbox;
    }
}