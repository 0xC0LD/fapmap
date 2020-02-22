namespace fapmaper
{
    partial class fapmaper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fapmaper));
            this.btn_install = new System.Windows.Forms.Button();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.cb_hideFolder = new System.Windows.Forms.CheckBox();
            this.label_output = new System.Windows.Forms.Label();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.label_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_install
            // 
            this.btn_install.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_install.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btn_install.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btn_install.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_install.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_install.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_install.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_install.Location = new System.Drawing.Point(866, 12);
            this.btn_install.Name = "btn_install";
            this.btn_install.Size = new System.Drawing.Size(106, 24);
            this.btn_install.TabIndex = 0;
            this.btn_install.Text = "Install / Update";
            this.btn_install.UseVisualStyleBackColor = true;
            this.btn_install.Click += new System.EventHandler(this.btn_install_Click);
            // 
            // txt_path
            // 
            this.txt_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_path.BackColor = System.Drawing.Color.Black;
            this.txt_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_path.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_path.ForeColor = System.Drawing.Color.SlateBlue;
            this.txt_path.Location = new System.Drawing.Point(12, 12);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(848, 25);
            this.txt_path.TabIndex = 1;
            this.txt_path.Text = "C:\\{H321-2314-JH34-H43J}";
            // 
            // cb_hideFolder
            // 
            this.cb_hideFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_hideFolder.AutoSize = true;
            this.cb_hideFolder.BackColor = System.Drawing.Color.Black;
            this.cb_hideFolder.Checked = true;
            this.cb_hideFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_hideFolder.ForeColor = System.Drawing.Color.SlateBlue;
            this.cb_hideFolder.Location = new System.Drawing.Point(876, 42);
            this.cb_hideFolder.Name = "cb_hideFolder";
            this.cb_hideFolder.Size = new System.Drawing.Size(80, 17);
            this.cb_hideFolder.TabIndex = 2;
            this.cb_hideFolder.Text = "Hide Folder";
            this.cb_hideFolder.UseVisualStyleBackColor = false;
            // 
            // label_output
            // 
            this.label_output.AutoSize = true;
            this.label_output.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.label_output.ForeColor = System.Drawing.Color.SlateBlue;
            this.label_output.Location = new System.Drawing.Point(12, 64);
            this.label_output.Name = "label_output";
            this.label_output.Size = new System.Drawing.Size(64, 18);
            this.label_output.TabIndex = 18;
            this.label_output.Text = "Output:";
            // 
            // txt_output
            // 
            this.txt_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_output.BackColor = System.Drawing.Color.Black;
            this.txt_output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_output.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_output.ForeColor = System.Drawing.Color.SlateBlue;
            this.txt_output.Location = new System.Drawing.Point(12, 85);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.ReadOnly = true;
            this.txt_output.Size = new System.Drawing.Size(960, 232);
            this.txt_output.TabIndex = 19;
            this.txt_output.Text = resources.GetString("txt_output.Text");
            // 
            // label_status
            // 
            this.label_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_status.ForeColor = System.Drawing.Color.Red;
            this.label_status.Location = new System.Drawing.Point(12, 339);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(25, 13);
            this.label_status.TabIndex = 20;
            this.label_status.Text = "...";
            // 
            // fapmaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(984, 361);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.txt_output);
            this.Controls.Add(this.label_output);
            this.Controls.Add(this.cb_hideFolder);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.btn_install);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 260);
            this.Name = "fapmaper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FapMap Installer / Updater";
            this.Load += new System.EventHandler(this.fapmaper_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_install;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.CheckBox cb_hideFolder;
        private System.Windows.Forms.Label label_output;
        private System.Windows.Forms.TextBox txt_output;
        private System.Windows.Forms.Label label_status;
    }
}

