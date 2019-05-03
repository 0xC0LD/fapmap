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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lock));
            this.passwordEntered = new System.Windows.Forms.TextBox();
            this.showPasswordCB = new System.Windows.Forms.CheckBox();
            this.HelpBalloon = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // passwordEntered
            // 
            this.passwordEntered.BackColor = System.Drawing.Color.Black;
            this.passwordEntered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordEntered.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordEntered.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passwordEntered.ForeColor = System.Drawing.Color.DimGray;
            this.passwordEntered.Location = new System.Drawing.Point(0, 0);
            this.passwordEntered.Name = "passwordEntered";
            this.passwordEntered.PasswordChar = '•';
            this.passwordEntered.Size = new System.Drawing.Size(185, 39);
            this.passwordEntered.TabIndex = 2;
            this.passwordEntered.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordEntered_KeyDown);
            this.passwordEntered.MouseDown += new System.Windows.Forms.MouseEventHandler(this.passwordEntered_MouseDown);
            // 
            // showPasswordCB
            // 
            this.showPasswordCB.Appearance = System.Windows.Forms.Appearance.Button;
            this.showPasswordCB.AutoSize = true;
            this.showPasswordCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.showPasswordCB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPasswordCB.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.showPasswordCB.FlatAppearance.CheckedBackColor = System.Drawing.Color.DimGray;
            this.showPasswordCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPasswordCB.ForeColor = System.Drawing.Color.DimGray;
            this.showPasswordCB.Location = new System.Drawing.Point(179, 0);
            this.showPasswordCB.Name = "showPasswordCB";
            this.showPasswordCB.Size = new System.Drawing.Size(6, 6);
            this.showPasswordCB.TabIndex = 4;
            this.HelpBalloon.SetToolTip(this.showPasswordCB, "Show Password (CTRL + S)");
            this.showPasswordCB.UseVisualStyleBackColor = false;
            this.showPasswordCB.CheckedChanged += new System.EventHandler(this.showPasswordCB_CheckedChanged);
            // 
            // HelpBalloon
            // 
            this.HelpBalloon.BackColor = System.Drawing.Color.Black;
            this.HelpBalloon.ForeColor = System.Drawing.Color.DimGray;
            this.HelpBalloon.OwnerDraw = true;
            this.HelpBalloon.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_Draw);
            // 
            // Lock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(185, 39);
            this.Controls.Add(this.showPasswordCB);
            this.Controls.Add(this.passwordEntered);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(185, 39);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(185, 39);
            this.Name = "Lock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locked Folder";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox passwordEntered;
        private System.Windows.Forms.CheckBox showPasswordCB;
        private System.Windows.Forms.ToolTip HelpBalloon;
    }
}

