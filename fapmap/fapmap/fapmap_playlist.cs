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

        // options
        private void cb_keyword_CheckedChanged(object sender, EventArgs e)
        {
            keyword = txt_keyword.Enabled = cb_keyword.Checked;
        }
        private void tb_keyword_TextChanged(object sender, EventArgs e) { if (keyword) { keyword_str = txt_keyword.Text; } }
        private void cb_rmlogs_CheckedChanged(object sender, EventArgs e)  { rmlogs  = cb_rmlogs.Checked  ? true : false; }
        private void cb_random_CheckedChanged(object sender, EventArgs e)  { random  = cb_random.Checked  ? true : false; }
        private void cb_reverse_CheckedChanged(object sender, EventArgs e) { reverse = cb_reverse.Checked ? true : false; }
        private void tb_path_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(txt_path.Text)) { txt_path.ForeColor = Color.Red;       }
            else                                 { txt_path.ForeColor = Color.SlateBlue; }

            path = this.txt_path.Text;
        }

        // make buttons
        private void btn_make_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {

                if (!Directory.Exists(txt_path.Text))
                {
                    MessageBox.Show("Please specify a valid directory path.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void btn_cancel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { this.DialogResult = DialogResult.Cancel; this.Close(); }
        }
    }
}
