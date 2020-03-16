using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace fapmap
{
    public partial class fapmap_playlist : Form
    {
        public fapmap_playlist() { InitializeComponent(); }

        public bool keyword { get; set; }
        public bool rmlogs { get; set; }
        public bool random { get; set; }
        public bool reverse { get; set; }
        public string keyword_str { get; set; }
        public string path { get; set; }

        private void fapmap_playlist_Load(object sender, EventArgs e)
        {
            if (File.Exists(path)) { this.txt_path.Text = path = Directory.GetParent(path).ToString(); }
            else                   { this.txt_path.Text = path; }
            
            btn_cancel.Focus();
            this.ActiveControl = btn_cancel;
        }
        
        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Tag == null || string.IsNullOrEmpty(cb.Tag.ToString())) { cb.Checked = false; return; }

            switch (cb.Tag.ToString())
            {
                case "KEYWORD": keyword = txt_keyword.Enabled = cb.Checked; break;
                case "RMLOGS":  rmlogs  = cb.Checked;                       break;
                case "RANDOM":  random  = cb.Checked;                       break;
                case "REVERSE": reverse = cb.Checked;                       break;
                default: cb.Checked = false; return;
            }
            
            cb.ForeColor = cb.Checked ? Color.SkyBlue : Color.RoyalBlue;
        }
        private void tb_keyword_TextChanged(object sender, EventArgs e) { if (keyword) { keyword_str = txt_keyword.Text; } }
        private void tb_path_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(txt_path.Text)) { txt_path.ForeColor = Color.Red;       }
            else                                  { txt_path.ForeColor = Color.SlateBlue; }

            path = this.txt_path.Text;
        }
        
        private void confirm()
        {
            if (!Directory.Exists(txt_path.Text))
            {
                MessageBox.Show("Please specify a valid directory path.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_make_Click(object sender, EventArgs e)
        {
            confirm();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cancel();
        }
        private void btn_openPathSelector_Click(object sender, EventArgs e)
        {
            fapmap.OpenPathSelectorTXT(this, txt_path, false, txt_path.Text);
        }
    }
}
