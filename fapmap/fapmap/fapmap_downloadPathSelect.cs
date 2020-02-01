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
    public partial class fapmap_downloadPathSelect : Form
    {
        public fapmap_downloadPathSelect()
        {
            InitializeComponent();
        }

        public string path { get; set; }

        private void fapmap_downloadPathSelect_Load(object sender, EventArgs e)
        {
            fapmap.fapmap_cd();
            
            foreach (string dir in Directory.GetDirectories(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories))
            {
                listbox.Items.Add(dir);
            }
        }

        private void listbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                path = listbox.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
