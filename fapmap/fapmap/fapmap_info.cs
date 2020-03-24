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

            txt_output_RMB.Renderer = new fapmap_res.FapmapColors.fToolStripProfessionalRenderer();
        }

        public string pass_path = string.Empty;

        private void fapmap_info_Load(object sender, EventArgs e)
        {
            getInfo(pass_path);

            btn_getInfo.Focus();
            this.ActiveControl = btn_getInfo;

            if (File.Exists(pass_path))
            {
                FileInfo fi = new FileInfo(pass_path);
                if (fapmap.GlobalVariables.FileTypes.Image.Contains(fi.Extension.ToLower()))
                {
                    Image img = Image.FromFile(fi.FullName);
                    Bitmap bmp = new Bitmap(img);
                    img.Dispose();
                    showImage.Image = bmp;
                    return;
                }

                if (fapmap.GlobalVariables.FileTypes.Video.Contains(fi.Extension.ToLower()))
                {
                    string dest = fapmap.GlobalVariables.Path.Dir.Thumbnails + "\\" + fi.Name + ".tmp";

                    if (File.Exists(dest))
                    {
                        Image img = Image.FromFile(dest);
                        Bitmap bmp = new Bitmap(img);
                        img.Dispose();
                        showImage.Image = bmp;
                        return;
                    }
                }

                showImage.Image = Icon.ExtractAssociatedIcon(fi.FullName).ToBitmap();
            }
            else if (Directory.Exists(pass_path))
            {
                showImage.Image = Properties.Resources.folder;
            }
            else
            {
                this.Close();
            }
        }

        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private bool getInfo_busy = false;
        private void getInfo(string path)
        {
            new Thread(() =>
            {
                if (!getInfo_busy)
                {
                    getInfo_busy = true;

                    this.Invoke((MethodInvoker)delegate
                    {
                        txt_size.Text = "";
                        txt_output.Text = "";
                        label_info.Text = "Scanning...";
                    });

                    if (Directory.Exists(path))
                    {
                        DirectoryInfo path_di = new DirectoryInfo(path);

                        this.Invoke((MethodInvoker)delegate
                        {
                            label_path.Text = path_di.Name;
                        });

                        /*
                        ** GET GALLERY SIZE
                        */
                        double SIZE_BYTES = unchecked((double)fapmap.DirSize(path_di));
                        string FULLSIZE = fapmap.ROund(SIZE_BYTES) + " (" + SIZE_BYTES + " bytes" + ")";

                        this.Invoke((MethodInvoker)delegate
                        {
                            txt_size.Text = FULLSIZE;
                            txt_size.SelectionStart = 0;
                        });

                        /*
                        ** GET FILE COUNT
                        */
                        FileInfo[] TopFiles = path_di.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                        FileInfo[] AllFiles = path_di.GetFiles("*.*", SearchOption.AllDirectories);
                        DirectoryInfo[] TopDirs = path_di.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
                        DirectoryInfo[] AllDirs = path_di.GetDirectories("*.*", SearchOption.AllDirectories);

                        int total = AllDirs.Length + AllFiles.Length;
                        this.Invoke((MethodInvoker)delegate
                        {
                            txt_output.Text += "TOTAL......: " + total + Environment.NewLine;
                            txt_output.Text += "> top dir..: " + TopDirs.Length + Environment.NewLine;
                            txt_output.Text += "> all dirs.: " + AllDirs.Length + Environment.NewLine;
                            txt_output.Text += "> top files: " + TopFiles.Length + Environment.NewLine;
                            txt_output.Text += "> all files: " + AllFiles.Length + Environment.NewLine;
                            txt_output.Text += Environment.NewLine;

                            Tuple<int, int, int> tuple = fapmap.getFileCount_VisibleNormalFull(AllDirs, AllFiles);
                            txt_output.Text += "> visible..: " + tuple.Item1 + Environment.NewLine;
                            txt_output.Text += "> normal...: " + tuple.Item2 + Environment.NewLine;
                            txt_output.Text += "> full.....: " + tuple.Item3 + Environment.NewLine;
                            txt_output.Text += Environment.NewLine;
                        });

                        foreach (Tuple<string, List<string>> tuple in
                            new List<Tuple<string, List<string>>> {
                            Tuple.Create("VIDEO", fapmap.GlobalVariables.FileTypes.Video),
                            Tuple.Create("IMAGE", fapmap.GlobalVariables.FileTypes.Image),
                            Tuple.Create("OTHER", fapmap.GlobalVariables.FileTypes.Other)
                            }
                        )
                        {
                            int t = 0;
                            List<Tuple<string, int>> lfc = new List<Tuple<string, int>>();

                            foreach (string type in tuple.Item2)
                            {
                                int count = AllFiles.AsQueryable().Where(s => s.Extension.ToLower().EndsWith(type)).Count();
                                t += count;
                                lfc.Add(Tuple.Create(type, count));
                            }

                            if (cb_noZero.Checked && t <= 0) { continue; }

                            int pad = 9;
                            this.Invoke((MethodInvoker)delegate
                            {
                                txt_output.Text += tuple.Item1.PadRight(pad + 2, '.') + ": " + t + Environment.NewLine;
                            });
                            foreach (var fc in lfc)
                            {
                                if (cb_noZero.Checked && fc.Item2 <= 0) { continue; }
                                this.Invoke((MethodInvoker)delegate
                                {
                                    txt_output.Text += "> " + fc.Item1.Remove(0, 1).PadRight(pad, '.') + ": " + fc.Item2 + Environment.NewLine;
                                });
                            }
                            this.Invoke((MethodInvoker)delegate
                            {
                                txt_output.Text += Environment.NewLine;
                            });
                        }
                    }
                    else if (File.Exists(path))
                    {
                        FileInfo fi = new FileInfo(path);
                        label_path.Text = fi.Name;
                        this.Invoke((MethodInvoker)delegate
                        {
                            txt_size.Text = fapmap.ROund(fi.Length) + " (" + fi.Length + " bytes" + ")";

                            txt_output.Text +=
                            "Name..................: " + fi.Name              + Environment.NewLine +
                            "Extension.............: " + fi.Extension         + Environment.NewLine +
                            "Directory.............: " + fi.Directory.Name    + Environment.NewLine +
                            "File Attributes.......: " + fi.Attributes        + Environment.NewLine +
                            "IsReadOnly............: " + fi.IsReadOnly        + Environment.NewLine +
                            "Size..................: " + fi.Length            + Environment.NewLine +
                            "Creation Time.........: " + fi.CreationTime      + Environment.NewLine +
                            "Creation Time (Utc)...: " + fi.CreationTimeUtc   + Environment.NewLine +
                            "Last Access Time......: " + fi.LastAccessTime    + Environment.NewLine +
                            "Last Access Time (Utc): " + fi.LastAccessTimeUtc + Environment.NewLine +
                            "Last Write Time.......: " + fi.LastWriteTime     + Environment.NewLine +
                            "Last Write Time (Utc).: " + fi.LastWriteTimeUtc  + Environment.NewLine;
                        });
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        label_info.Text = "Done!";
                    });

                    getInfo_busy = false;
                }
            })
            { IsBackground = true }.Start();
        }
        
        private void btn_getInfo_Click(object sender, EventArgs e)
        {
            getInfo(pass_path);
        }
        
        private void txt_output_RMB_copy_Click(object sender, EventArgs e)
        {
            string text = txt_output.SelectedText;
            if (!string.IsNullOrEmpty(text)) { Clipboard.SetText(text); }
        }
    }
}
