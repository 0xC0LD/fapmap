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

            logs_RMB.Renderer = new fapmap_res.FapMapColors.FapMapToolStripRenderer(Color.FromArgb(128, 128, 255));
        }

        private void fapmap_log_Load(object sender, EventArgs e)
        {
            logs_reload();
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

                    ListViewItem lvi = new ListViewItem(new string[] { count.ToString(), time, action, text }) { Name = text };
                    switch (action)
                    {
                        case fapmap.GlobalVariables.LOG_TYPE.OPEN: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.OPEN_; break;
                        case fapmap.GlobalVariables.LOG_TYPE.PLAY: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.PLAY_; break;
                        case fapmap.GlobalVariables.LOG_TYPE.EXEC: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.EXEC_; break;

                        case fapmap.GlobalVariables.LOG_TYPE.MOVE: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.MOVE_; break;
                        case fapmap.GlobalVariables.LOG_TYPE.COPY: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.COPY_; break;
                        case fapmap.GlobalVariables.LOG_TYPE.RENM: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.RENM_; break;
                        case fapmap.GlobalVariables.LOG_TYPE.MKDR: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.MKDR_; break;
                        case fapmap.GlobalVariables.LOG_TYPE.MKFL: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.MKFL_; break;
                        case fapmap.GlobalVariables.LOG_TYPE.RMVD: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.RMVD_; break;

                        case fapmap.GlobalVariables.LOG_TYPE.DING: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.DING_; break;
                        case fapmap.GlobalVariables.LOG_TYPE.DLED: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.DLED_; break;

                        case fapmap.GlobalVariables.LOG_TYPE.NTFD: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.NTFD_; break;
                        case fapmap.GlobalVariables.LOG_TYPE.FAIL: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.FAIL_; break;
                        case fapmap.GlobalVariables.LOG_TYPE.UDEL: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.UDEL_; break;
                        case fapmap.GlobalVariables.LOG_TYPE.PASS: lvi.ForeColor = fapmap.GlobalVariables.LOG_TYPE.PASS_; break;
                        
                        default: lvi.ForeColor = Color.Silver; break;
                    }
                    items.Add(lvi);
                }
            }

            logs.Items.AddRange(items.ToArray());
            lable_status.Text = "lines: " + logs.Items.Count;

            return true;
        }
        
        private void logs_reload()
        {
            lable_status.Text = "Loading...";

            logs.BeginUpdate();
            if (!readLogs(fapmap.GlobalVariables.Path.File.Log)) { lable_status.Text = "File not found..."; }
            logs.EndUpdate();

            if (logs.Items.Count > 0) { logs.EnsureVisible(logs.Items.Count - 1); }
            logs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private void logs_open()
        {
            foreach (ListViewItem lvi in logs.SelectedItems)
            {
                if (lvi.Name == null) { continue; }
                string text = lvi.Name;
                if (string.IsNullOrEmpty(text)) { continue; }
                if (File.Exists(text)) { fapmap.Open(text); }
                else if (Uri.IsWellFormedUriString(text, UriKind.Absolute)) { fapmap.Incognito(text); }
            }
        }
        private void logs_copy()
        {
            if (logs.SelectedItems == null) { return; }
            if (logs.SelectedItems.Count == 0) { return; }

            string clip = string.Empty;
            foreach (ListViewItem item in logs.SelectedItems)
            {
                clip += item == logs.SelectedItems[logs.SelectedItems.Count - 1] ? item.Name : item.Name + Environment.NewLine;
            }
            if (!string.IsNullOrEmpty(clip)) { System.Windows.Forms.Clipboard.SetText(clip); }
        }
        private void logs_edit()
        {
            fapmap.Open(fapmap.GlobalVariables.Path.File.Log);
        }

        private bool logs_ctrl = false;
        private bool logs_shift = false;
        private void logs_KeyDown(object sender, KeyEventArgs e)
        {
            logs_ctrl = e.Control;
            logs_shift = e.Shift;

            switch(e.KeyCode)
            {
                case Keys.Escape: this.Close();  e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Enter:  logs_open();   e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.F5:     logs_reload(); e.Handled = true; e.SuppressKeyPress = true; break;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.W: logs_open();   e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.R: logs_reload(); e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.C: logs_copy();   e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.E: logs_edit();   e.Handled = true; e.SuppressKeyPress = true; break;
                }
            }
        }
        private void logs_KeyUp(object sender, KeyEventArgs e)
        {
            logs_ctrl = false;
            logs_shift = false;
        }
        private void logs_LostFocus(object sender, System.EventArgs e)
        {
            logs_ctrl = false;
            logs_shift = false;
        }

        private int links_fontSize_min = 4;
        private int links_fontSize_max = 30;
        private int links_fontSize = 8;
        private void logs_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!logs_ctrl) { return; }

            int last = links_fontSize;
            if (e.Delta > 0) { links_fontSize += (logs_shift ? 6 : 2); }
            else             { links_fontSize -= (logs_shift ? 6 : 2); }

            if      (links_fontSize < links_fontSize_min) { links_fontSize = links_fontSize_min; }
            else if (links_fontSize > links_fontSize_max) { links_fontSize = links_fontSize_max; }
            if (links_fontSize == last) { return; }
            
            logs.Font = new Font(logs.Font.FontFamily, links_fontSize, logs.Font.Style);
            logs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        
        private void logs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { logs_open(); }
        }
        
        private void logs_RMB_reload_Click(object sender, EventArgs e) { logs_reload(); }
        private void logs_RMB_open_Click(object sender, EventArgs e) { logs_open(); }
        private void logs_RMB_copy_Click(object sender, EventArgs e) { logs_copy(); }
        private void logs_RMB_edit_Click(object sender, EventArgs e) { logs_edit(); }
    }
}
