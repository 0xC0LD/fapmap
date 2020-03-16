namespace LockedFolder
{
    partial class Lock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lock));
            this.txt_passwd = new System.Windows.Forms.TextBox();
            this.cb_show = new System.Windows.Forms.CheckBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_passwd
            // 
            this.txt_passwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_passwd.BackColor = System.Drawing.Color.Black;
            this.txt_passwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_passwd.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_passwd.ForeColor = System.Drawing.Color.SlateBlue;
            this.txt_passwd.Location = new System.Drawing.Point(12, 12);
            this.txt_passwd.Name = "txt_passwd";
            this.txt_passwd.PasswordChar = '•';
            this.txt_passwd.Size = new System.Drawing.Size(317, 36);
            this.txt_passwd.TabIndex = 1;
            this.txt_passwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_passwd_KeyDown);
            this.txt_passwd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_passwd_MouseDown);
            // 
            // cb_show
            // 
            this.cb_show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_show.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_show.AutoSize = true;
            this.cb_show.BackColor = System.Drawing.Color.Transparent;
            this.cb_show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_show.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.cb_show.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_show.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_show.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.cb_show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_show.ForeColor = System.Drawing.Color.SlateBlue;
            this.cb_show.Location = new System.Drawing.Point(12, 56);
            this.cb_show.Name = "cb_show";
            this.cb_show.Size = new System.Drawing.Size(143, 23);
            this.cb_show.TabIndex = 4;
            this.cb_show.Text = "Show Password (CTRL+S)";
            this.cb_show.UseVisualStyleBackColor = false;
            this.cb_show.CheckedChanged += new System.EventHandler(this.cb_show_CheckedChanged);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.BackColor = System.Drawing.Color.Transparent;
            this.btn_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_ok.Location = new System.Drawing.Point(175, 52);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 30);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_cancel.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_cancel.Location = new System.Drawing.Point(254, 52);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 30);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "CANCEL";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Lock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BackgroundImage = global::LockedFolder.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(339, 91);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.cb_show);
            this.Controls.Add(this.txt_passwd);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 130);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(355, 130);
            this.Name = "Lock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locked Folder";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Lock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_passwd;
        private System.Windows.Forms.CheckBox cb_show;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
    }
}

