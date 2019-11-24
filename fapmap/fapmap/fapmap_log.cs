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
        }

        private void fapmap_log_Load(object sender, EventArgs e)
        {
            fapmap.fapmap_cd();
            get_logs();
        }


        #region Logs

        private bool GetLogsFromFile(string log)
        {
            if (File.Exists(log))
            {
                logs.SelectedItems.Clear(); //CLEAR SELECTION
                logs.Items.Clear(); //CLEAR LOGS

                //VARS
                int count = 0;

                foreach (string line in File.ReadAllLines(log))
                {
                    string[] index = line.Split(new string[] { "|||" }, StringSplitOptions.None);

                    if (index.Length == 3)
                    {
                        count++; //count
                        string time = index[0];
                        string action = index[1];
                        string text = index[2];

                        ListViewItem lvi = new ListViewItem(new string[] { count.ToString(), time, action, text }) { Tag = text };
                        switch (action)
                        {
                            case "OPEN": lvi.ForeColor = Color.Yellow; break;
                            case "PLAY": lvi.ForeColor = Color.SkyBlue; break;
                            case "EXEC": lvi.ForeColor = Color.Orange; break;
                            case "MOVE": lvi.ForeColor = Color.Yellow; break;
                            case "RMVD": lvi.ForeColor = Color.IndianRed; break;
                            case "MDIR": lvi.ForeColor = Color.SteelBlue; break;
                            case "RENM": lvi.ForeColor = Color.DarkSeaGreen; break;

                            case "404E": lvi.ForeColor = Color.Red; break;
                            case "LOAD": lvi.ForeColor = Color.OrangeRed; break;
                        
                            case "UDEL": lvi.ForeColor = Color.PaleVioletRed; break;
                            case "FMWB": lvi.ForeColor = Color.MediumSlateBlue; break;
                        
                            case "DING": lvi.ForeColor = Color.DarkGreen; break;
                            case "DLED": lvi.ForeColor = Color.Lime; break;

                            default: lvi.ForeColor = Color.Silver; break;
                        }
                        
                        logs.Items.Add(lvi); //add
                    }
                }

                this.Text = "lines: " + logs.Items.Count;

                return true;
            }
            else
            {
                MessageBox.Show("File not found: " + log, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }
        
        private void get_logs()
        {
            //DISABLE ALL
            this.Text = "Loading...";

            logs.BeginUpdate();

            string file = fapmap.GlobalVariables.Path.File.Log;
            
            if (!GetLogsFromFile(file))
            {
                this.Text = "File not found...";
            }

            logs.EndUpdate();
            
            //scroll down
            if (logs.Items.Count > 0) { logs.EnsureVisible(logs.Items.Count - 1); }

            //auto resize
            foreach (ColumnHeader column in logs.Columns)
            {
                column.Width = -2;
            }
        }

        private void Logs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (logs.SelectedItems != null)
                {
                    string clip = string.Empty;
                    foreach(ListViewItem item in logs.SelectedItems)
                    {
                        clip = clip + item.Tag.ToString() + Environment.NewLine;
                    }
                    System.Windows.Forms.Clipboard.SetText(clip);
                }
            }

            if (e.Control && e.KeyCode == Keys.E)
            {
                Process.Start("notepad.exe", fapmap.GlobalVariables.Path.File.Log);
            }
        }
        
        #endregion
        
        private void logs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach(ListViewItem lvi in logs.SelectedItems)
                {
                    string text = lvi.Tag.ToString();

                    if (File.Exists(text))
                    {
                        fapmap.Open(text);
                    }
                    else if (Uri.IsWellFormedUriString(text, UriKind.Absolute))
                    {
                        fapmap.Incognito(text);
                    }
                }
            }
        }
    }
}
