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
using System.Threading;
using System.Diagnostics;

namespace fapmap
{
    public partial class fapmap_log : Form
    {
        
        public fapmap_log()
        {
            InitializeComponent();

            logs_RMB.Renderer = new fapmap_res.color.fToolStripProfessionalRenderer();
        }

        private void fapmap_log_Load(object sender, EventArgs e)
        {
            logs_refresh();
        }
        
        private bool readLogs(string logPath)
        {
            if (!File.Exists(logPath)) {
                MessageBox.Show("File not found: " + logPath, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            logs.SelectedItems.Clear();
            logs.Items.Clear();
            
            int count = 0;
            List<ListViewItem> items = new List<ListViewItem>();

            foreach (string line in File.ReadAllLines(logPath))
            {
                string[] index = line.Split(new string[] { "|||" }, StringSplitOptions.None);

                if (index.Length == 3)
                {
                    count++;
                    string time = index[0];
                    string action = index[1];
                    string text = index[2].Replace("\n", String.Empty);

                    ListViewItem lvi = new ListViewItem(new string[] { count.ToString(), time, action, text }) { Tag = text };
                    switch (action)
                    {
                        case fapmap.GlobalVariables.LOG_TYPE.OPEN: lvi.ForeColor = Color.Yellow; break;
                        case fapmap.GlobalVariables.LOG_TYPE.PLAY: lvi.ForeColor = Color.SkyBlue; break;
                        case fapmap.GlobalVariables.LOG_TYPE.EXEC: lvi.ForeColor = Color.Orange; break;
                        case fapmap.GlobalVariables.LOG_TYPE.MOVE: lvi.ForeColor = Color.Yellow; break;
                        case fapmap.GlobalVariables.LOG_TYPE.LOAD: lvi.ForeColor = Color.OrangeRed; break;
                        case fapmap.GlobalVariables.LOG_TYPE.NTFD: lvi.ForeColor = Color.Red; break;
                        case fapmap.GlobalVariables.LOG_TYPE.DING: lvi.ForeColor = Color.DarkGreen; break;
                        case fapmap.GlobalVariables.LOG_TYPE.DLED: lvi.ForeColor = Color.Lime; break;
                        case fapmap.GlobalVariables.LOG_TYPE.RENM: lvi.ForeColor = Color.DarkSeaGreen; break;
                        case fapmap.GlobalVariables.LOG_TYPE.MKDR: lvi.ForeColor = Color.SteelBlue; break;
                        case fapmap.GlobalVariables.LOG_TYPE.RMVD: lvi.ForeColor = Color.IndianRed; break;
                        case fapmap.GlobalVariables.LOG_TYPE.UDEL: lvi.ForeColor = Color.PaleVioletRed; break;
                        case fapmap.GlobalVariables.LOG_TYPE.PASS: lvi.ForeColor = Color.Crimson; break;
                        case fapmap.GlobalVariables.LOG_TYPE.FAIL: lvi.ForeColor = Color.DarkOrchid; break;
                        default: lvi.ForeColor = Color.Silver; break;
                    }
                    items.Add(lvi);
                }
            }

            logs.Items.AddRange(items.ToArray());
            lable_status.Text = "lines: " + logs.Items.Count;

            return true;
        }
        
        private void logs_refresh()
        {
            lable_status.Text = "Loading...";

            logs.BeginUpdate();
            if (!readLogs(fapmap.GlobalVariables.Path.File.Log)) { lable_status.Text = "File not found..."; }
            logs.EndUpdate();

            if (logs.Items.Count > 0) { logs.EnsureVisible(logs.Items.Count - 1); }
            foreach (ColumnHeader column in logs.Columns) { column.Width = -2; }
        }
        private void logs_open()
        {
            foreach (ListViewItem lvi in logs.SelectedItems)
            {
                if (lvi.Tag == null) { continue; }
                string text = lvi.Tag.ToString();
                if (string.IsNullOrEmpty(text)) { continue; }
                if (File.Exists(text)) { fapmap.Open(text); }
                else if (Uri.IsWellFormedUriString(text, UriKind.Absolute)) { fapmap.Incognito(text); }
            }
        }
        private void logs_copy()
        {
            if (logs.SelectedItems != null)
            {
                string clip = string.Empty;
                foreach (ListViewItem item in logs.SelectedItems) { clip = clip + item.Tag.ToString() + Environment.NewLine; }
                System.Windows.Forms.Clipboard.SetText(clip);
            }
        }
        private void logs_edit()
        {
            fapmap.Open(fapmap.GlobalVariables.Path.File.Log);
        }

        private void logs_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter: logs_open(); e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.F5: logs_refresh(); break;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.W: logs_open(); break;
                    case Keys.R: logs_refresh(); break;
                    case Keys.C: logs_copy(); break;
                    case Keys.E: logs_edit(); break;
                }
            }
        }
        private void logs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                logs_open();
            }
        }
        
        private void logs_RMB_refresh_Click(object sender, EventArgs e) { logs_refresh(); }
        private void logs_RMB_open_Click(object sender, EventArgs e) { logs_open(); }
        private void logs_RMB_copy_Click(object sender, EventArgs e) { logs_copy(); }
        private void logs_RMB_edit_Click(object sender, EventArgs e) { logs_edit(); }
    }
}
