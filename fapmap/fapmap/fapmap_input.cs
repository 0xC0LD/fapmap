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
    public partial class fapmap_input : Form
    {
        public fapmap_input()
        {
            InitializeComponent();
        }

        public string prompt = string.Empty;
        public string defaultInput = string.Empty;
        public int selectFrom = 0;
        public int selectCount = 0;

        public string input = string.Empty;

        private void fapmap_input_Load(object sender, EventArgs e)
        {
            label_prompt.Text = prompt;
            txt_input.Text = defaultInput;
            txt_input.Select(selectFrom, selectCount);
            this.ActiveControl = txt_input;
        }

        private void confirm()
        {
            input = txt_input.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txt_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A) { txt_input.SelectAll(); }

            switch (e.KeyCode)
            {
                case Keys.Enter: confirm(); break;
                case Keys.Escape: cancel(); break;
            }
        }
        private void btn_ok_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { confirm(); }
        }
        private void btn_cancel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { cancel(); }
        }


    }
}
