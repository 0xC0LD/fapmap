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

            txt_output_RMB.Renderer = new fapmap_res.FapMapColors.FapMapToolStripRenderer(Color.FromArgb(128, 128, 255));
        }

        public string pass_path = string.Empty;

        private void fapmap_info_Load(object sender, EventArgs e)
        {
            txt_path.Text = pass_path;
            // scroll to the end
            txt_path.SelectionStart = txt_path.Text.Length;
            txt_path.ScrollToCaret();

            // get info
            getInfo();
            
            this.ActiveControl = btn_getInfo;
        }
        
        private void txt_path_TextChanged(object sender, EventArgs e)
        {
            txt_path.ForeColor = (Directory.Exists(txt_path.Text) || File.Exists(txt_path.Text)) ? Color.CornflowerBlue : Color.PaleVioletRed;
        }
        private void txt_path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getInfo();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private string gl_fileMD5_;
        private string gl_fileMD5
        {
            get { return gl_fileMD5_; }
            set
            {
                bool val = !string.IsNullOrEmpty(value);

                this.Invoke((MethodInvoker)delegate
                {
                    btn_booru_api.Visible       = val;
                    btn_booru_rule34xxx.Visible = val;
                    btn_booru_gelbooru.Visible  = val;
                    btn_booru_danbooru.Visible  = val;
                    btn_booru_yandere.Visible   = val;
                    btn_booru_xbooru.Visible    = val;
                });
                

                gl_fileMD5_ = value;
            }
        }

        private bool getInfo_busy = false;
        private void getInfo()
        {
            if (getInfo_busy) { return; }

            string path = txt_path.Text;

            new Thread(() =>
            {
                getInfo_busy = true;

                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        txt_size.Text = "";
                        txt_output.Text = "";
                        label_info.Text = "Scanning...";
                        gl_fileMD5 = string.Empty;
                    });

                    if (Directory.Exists(path))
                    {
                        DirectoryInfo path_di = new DirectoryInfo(path);

                        this.Invoke((MethodInvoker)delegate
                        {
                            label_path.Text = path_di.Name;
                            showImage.Image = Properties.Resources.folder;
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

                        foreach (var tuple in
                            new List<Tuple<string, IList<string>>> {
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
                            "File Name: " + fi.Name              + Environment.NewLine +
                            "Extension: " + fi.Extension         + Environment.NewLine +
                            "Directory: " + fi.Directory.Name    + Environment.NewLine +
                            "Attribute: " + fi.Attributes        + Environment.NewLine +
                            "Size.....: " + fi.Length            + Environment.NewLine +
                            "Creation.: " + fi.CreationTime      + Environment.NewLine +
                            "Accessed.: " + fi.LastAccessTime    + Environment.NewLine +
                            "Written..: " + fi.LastWriteTime     + Environment.NewLine;
                            
                            showImage.Image = Icon.ExtractAssociatedIcon(fi.FullName).ToBitmap();
                        });

                        string id = fapmap.getFileId(fi).ToString();
                        this.Invoke((MethodInvoker)delegate
                        {
                            txt_output.Text += "File ID..: " + id + Environment.NewLine;
                        });

                        gl_fileMD5 = fapmap.CalculateMD5(fi.FullName);
                        this.Invoke((MethodInvoker)delegate
                        {
                            txt_output.Text += "MD5 Hash.: " + gl_fileMD5 + Environment.NewLine;
                        });
                        
                        if (fapmap.GlobalVariables.FileTypes.Image.Contains(fi.Extension.ToLower()))
                        {
                            Image img = Image.FromFile(fi.FullName);
                            Bitmap bmp = new Bitmap(img);
                            img.Dispose();

                            this.Invoke((MethodInvoker)delegate
                            {
                                showImage.Image = bmp;
                                txt_output.Text += "Image WxH: " + bmp.Width + "x" + bmp.Height + Environment.NewLine;
                            });
                        }
                        else if (fapmap.GlobalVariables.FileTypes.Video.Contains(fi.Extension.ToLower()))
                        {
                            string dest = fapmap.GlobalVariables.Path.Dir.Cache + "\\" + fapmap.getFileId(fi).ToString() + ".tmp";

                            if (File.Exists(dest))
                            {
                                Image img = Image.FromFile(dest);
                                Bitmap bmp = new Bitmap(img);
                                img.Dispose();

                                this.Invoke((MethodInvoker)delegate
                                {
                                    showImage.Image = bmp;
                                    txt_output.Text += "Image WxH: " + bmp.Width + "x" + bmp.Height + Environment.NewLine;
                                });
                            }

                            Tuple<string, string, string> VideoInfo = fapmap.getVideoInfo(fi.FullName);
                            if (!string.IsNullOrEmpty(VideoInfo.Item1)) { this.Invoke((MethodInvoker)delegate { txt_output.Text += "Duration.: " + VideoInfo.Item1 + Environment.NewLine; }); }
                            if (!string.IsNullOrEmpty(VideoInfo.Item2)) { this.Invoke((MethodInvoker)delegate { txt_output.Text += "Title....: " + VideoInfo.Item2 + Environment.NewLine; }); }
                            if (!string.IsNullOrEmpty(VideoInfo.Item3)) { this.Invoke((MethodInvoker)delegate { txt_output.Text += "Encoder..: " + VideoInfo.Item3 + Environment.NewLine; }); }
                        }
                    }
                    else
                    {
                        label_path.Text = "Nothing found...";
                        txt_size.Text = "N/A";
                        txt_output.Text = "N/A";
                        label_info.Text = "Nothing found...";
                        showImage.Image = Properties.Resources.error;
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        label_info.Text = "Done!";
                    });
                }
                catch (Exception) { }

                getInfo_busy = false;
            })
            { IsBackground = true }.Start();
        }
        
        // RMB
        private void txt_output_RMB_copy_Click(object sender, EventArgs e)
        {
            string text = txt_output.SelectedText;
            if (!string.IsNullOrEmpty(text)) { Clipboard.SetText(text); }
        }

        // buttons
        private void btn_getInfo_Click(object sender, EventArgs e)
        {
            getInfo();
        }
        private void btn_openFile_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txt_path.Text)) { fapmap.Open(txt_path.Text); }
            else if (File.Exists(txt_path.Text)) { fapmap.Open(txt_path.Text); }
        }
        private void btn_browser_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txt_path.Text)) { fapmap.OpenInBrowser(txt_path.Text); }
            else if (File.Exists(txt_path.Text)) { fapmap.OpenInBrowser(txt_path.Text); }
        }
        private void btn_selectFileInExplorer_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txt_path.Text)) { fapmap.OpenAndSelectInExplorer(txt_path.Text); }
            else if (File.Exists(txt_path.Text)) { fapmap.OpenAndSelectInExplorer(txt_path.Text); }
        }
        private void btn_incognito_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txt_path.Text)) { fapmap.Incognito(new DirectoryInfo(txt_path.Text).Name);           }
            else if (File.Exists(txt_path.Text)) { fapmap.Incognito(Path.GetFileNameWithoutExtension(txt_path.Text)); }
        }
        private void btn_move_Click(object sender, EventArgs e)
        {
            string path = txt_path.Text;
            if (Directory.Exists(path))
            {
                if (path == fapmap.GlobalVariables.Path.Dir.MainFolder)
                {
                    MessageBox.Show("You can't move \"Main Folder\"", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                DirectoryInfo di = new DirectoryInfo(path);
                string dir = fapmap.OpenPathSelector(this, di.Parent.FullName);
                if (!string.IsNullOrEmpty(dir) && Directory.Exists(path) && Directory.Exists(dir))
                {
                    string dest = new DirectoryInfo(dir).FullName + "\\" + di.Name;
                    if (fapmap.MoveDir(path, dest))
                    {
                        txt_path.Text = dest;
                        getInfo();
                    }
                }
            }
            else if (File.Exists(path))
            {
                FileInfo fi = new FileInfo(path);
                string dir = fapmap.OpenPathSelector(this, fi.Directory.FullName);
                if (!string.IsNullOrEmpty(dir) && Directory.Exists(dir))
                {
                    string dest = new DirectoryInfo(dir).FullName + "\\" + fi.Name;
                    if (fapmap.MoveFile(path, dest))
                    {
                        txt_path.Text = dest;
                        getInfo();
                    }
                }
            }
        }
        private void btn_rename_Click(object sender, EventArgs e)
        {
            string path = txt_path.Text;
            if (Directory.Exists(path))
            {
                if (path == fapmap.GlobalVariables.Path.Dir.MainFolder)
                {
                    MessageBox.Show("You can't rename \"Main Folder\"", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                DirectoryInfo di_src = new DirectoryInfo(path);
                string input = fapmap.OpenInputBox(this, "Rename folder?", di_src.Name, 0, di_src.Name.Length);
                if (!string.IsNullOrEmpty(input))
                {
                    string dest = di_src.Parent.FullName + "\\" + input;
                    if (fapmap.MoveDir(di_src.FullName, dest))
                    {
                        txt_path.Text = dest;
                        getInfo();
                    }
                }
            }
            else if (File.Exists(path))
            {
                FileInfo fi_src = new FileInfo(path);
                string input = fapmap.OpenInputBox(this, "Rename file?", fi_src.Name, 0, fi_src.Name.Length - fi_src.Extension.Length);
                if (!string.IsNullOrEmpty(input))
                {
                    string dest = fi_src.Directory.FullName + "\\" + input;
                    if (fapmap.MoveFile(fi_src.FullName, dest))
                    {
                        txt_path.Text = dest;
                        getInfo();
                    }
                }
            }
        }
        private void btn_delFile_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txt_path.Text)) { fapmap.TrashDir(txt_path.Text);  getInfo(); txt_path_TextChanged(null, null); }
            else if (File.Exists(txt_path.Text)) { fapmap.TrashFile(txt_path.Text); getInfo(); txt_path_TextChanged(null, null); }
        }

        // md5 booru search
        private void btn_booru_api_Click(object sender, EventArgs e)
        {
            if (File.Exists(txt_path.Text)) { fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.API + gl_fileMD5); }
        }
        private void btn_booru_rule34xxx_Click(object sender, EventArgs e)
        {
            if (File.Exists(txt_path.Text)) { fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.rule34xxx + gl_fileMD5); }
        }
        private void btn_booru_gelbooru_Click(object sender, EventArgs e)
        {
            if (File.Exists(txt_path.Text)) { fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.gelbooru + gl_fileMD5); }
        }
        private void btn_booru_danbooru_Click(object sender, EventArgs e)
        {
            if (File.Exists(txt_path.Text)) { fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.danbooru + gl_fileMD5); }
        }
        private void btn_booru_yandere_Click(object sender, EventArgs e)
        {
            if (File.Exists(txt_path.Text)) { fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.yandere + gl_fileMD5); }
        }
        private void btn_booru_xbooru_Click(object sender, EventArgs e)
        {
            if (File.Exists(txt_path.Text)) { fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.xbooru + gl_fileMD5); }
        }

        private void btn_dragOutFilePath_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = string.IsNullOrEmpty(txt_path.Text) ? DragDropEffects.None : DragDropEffects.Copy;
        }
        private void btn_dragOutFilePath_MouseDown(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_path.Text))
            { this.txt_path.DoDragDrop(new DataObject(DataFormats.StringFormat, txt_path.Text), DragDropEffects.Copy); }
        }
    }
}
