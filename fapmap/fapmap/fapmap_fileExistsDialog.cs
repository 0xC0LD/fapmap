using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fapmap
{
    public partial class fapmap_fileExistsDialog : Form
    {
        public fapmap_fileExistsDialog()
        {
            InitializeComponent();
        }

        public string print = string.Empty;

        private void fapmap_fileExistsDialog_Load(object sender, EventArgs e)
        {
            info.Text = print;
        }

        private void replace()
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        private void newName()
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private void cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void btn_replace_Click(object sender, EventArgs e)
        {
            replace();
        }
        private void btn_newName_Click(object sender, EventArgs e)
        {
            newName();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cancel();
        }
    }
}
