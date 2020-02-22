using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace fapmap
{
    public partial class fapmap_info : Form
    {
        public fapmap_info()
        {
            InitializeComponent();
        }

        public string path = string.Empty;

        private void fapmap_info_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path)) { this.Close(); }
            getInfo();
        }

        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
        
        private bool getInfo_busy = false;
        private void getInfo()
        {
            new Thread(getInfo_thread) { IsBackground = true }.Start();

            count_files_panel.Focus();
            this.ActiveControl = count_files_panel;
        }
        private void getInfo_thread()
        {
            if (!getInfo_busy)
            {
                getInfo_busy = true;
                getAll.Enabled = false;
                
                fileSizeText.Text = "...";
                count_files.Text = "...";
                
                path_txt.Text = path;
                path_txt.ForeColor = Color.DarkSlateBlue;

                try
                {
                    //CALCULATE
                    get_size(path);
                    if (Directory.Exists(path)) //file count
                    {
                        if (this.Size.Height < 400)
                        {
                            // this.Location = new Point(this.Location.X, this.Location.Y - (400 / 2));
                            this.Size = new Size(this.Size.Width, this.Height + 400);
                            this.CenterToScreen();
                        }

                        CountAll();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong... :/" + Environment.NewLine + Environment.NewLine + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                
                path_txt.ForeColor = Color.SlateBlue;

                getAll.Enabled = true;
                getInfo_busy = false;
            }
        }
        
        private void get_size(string path)
        {
            double SIZE_BYTES = 0;

            if (Directory.Exists(path))
            {
                foreach (string name in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
                {
                    SIZE_BYTES += new FileInfo(name).Length;
                }
            }
            else if (File.Exists(path))
            {
                SIZE_BYTES = new FileInfo(path).Length;
            }
            else
            {
                return;
            }

            string FULLSIZE = fapmap.ROund(SIZE_BYTES) + " (" + SIZE_BYTES + " bytes" + ")";

            fileSizeText.Text = FULLSIZE;
        }

        private class FileCount
        {
            public string Type;
            public int Count;

            public FileCount(string type, int count)
            {
                Type = type;
                Count = count;
            }
        }

        private void CountAll_print(string title, List<string> types)
        {
            List<FileCount> lfc = new List<FileCount>(); int total = 0;
            foreach (string type in types)
            {
                int i = Directory.GetFiles(path, "*" + type, SearchOption.AllDirectories).Length;
                total += i;
                lfc.Add(new FileCount(type, i));
            }

            if (total > 0)
            {
                count_files.Text += title + "....: " + total + Environment.NewLine;
                foreach (FileCount fc in lfc)
                {
                    string dot = "";
                    switch (fc.Type.Length)
                    {
                        case 4: dot = "...."; break;
                        case 5: dot = "..."; break;
                        case 6: dot = ".."; break;
                        case 7: dot = "."; break;
                    }

                    if (cb_count.Checked) { if (fc.Count > 0) { count_files.Text += "> " + fc.Type.Replace(".", "") + dot + ": " + fc.Count + Environment.NewLine; } }
                    else { count_files.Text += "> " + fc.Type.Replace(".", "") + dot + ": " + fc.Count + Environment.NewLine; }
                }
            }
            count_files.Text += Environment.NewLine;
        }
        private void CountAll()
        {
            //CLEAR
            count_files.Text = "";

            count_files.Text += "TOTAL:" + Environment.NewLine;
            count_files.Text += "> .\\*....: " + Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Length + Environment.NewLine;
            count_files.Text += "> *.*....: " + Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length + Environment.NewLine;
            count_files.Text += "> topdir.: " + System.IO.Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly).Length + Environment.NewLine;
            count_files.Text += "> alldir.: " + System.IO.Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories).Length + Environment.NewLine;
            count_files.Text += Environment.NewLine;

            CountAll_print("VIDEO", fapmap.GlobalVariables.FileTypes.Video);
            CountAll_print("IMAGE", fapmap.GlobalVariables.FileTypes.Image);
            CountAll_print("OTHER", fapmap.GlobalVariables.FileTypes.Other);
        }

        private void getAll_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { getInfo(); }
        }
    }
}
