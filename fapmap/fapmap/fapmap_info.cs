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

            txt_output_RMB.Renderer = new fapmap_res.FapMapColors.fToolStripProfessionalRenderer();
        }

        public string pass_path = string.Empty;

        private void fapmap_info_Load(object sender, EventArgs e)
        {
            getInfo(pass_path);
            
            if (File.Exists(pass_path) && fapmap.IsMD5(Path.GetFileNameWithoutExtension(pass_path)))
            {
                btn_booru_api.Visible = true;
                btn_booru_rule34xxx.Visible = true;
                btn_booru_gelbooru.Visible = true;
                btn_booru_danbooru.Visible = true;
            }

            this.ActiveControl = btn_getInfo;
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
            if (getInfo_busy) { return; }

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
                            "Name..................: " + fi.Name + Environment.NewLine +
                            "Extension.............: " + fi.Extension + Environment.NewLine +
                            "Directory.............: " + fi.Directory.Name + Environment.NewLine +
                            "File Attributes.......: " + fi.Attributes + Environment.NewLine +
                            "IsReadOnly............: " + fi.IsReadOnly + Environment.NewLine +
                            "Size..................: " + fi.Length + Environment.NewLine +
                            "Creation Time.........: " + fi.CreationTime + Environment.NewLine +
                            "Creation Time (Utc)...: " + fi.CreationTimeUtc + Environment.NewLine +
                            "Last Access Time......: " + fi.LastAccessTime + Environment.NewLine +
                            "Last Access Time (Utc): " + fi.LastAccessTimeUtc + Environment.NewLine +
                            "Last Write Time.......: " + fi.LastWriteTime + Environment.NewLine +
                            "Last Write Time (Utc).: " + fi.LastWriteTimeUtc + Environment.NewLine;

                            showImage.Image = Icon.ExtractAssociatedIcon(fi.FullName).ToBitmap();
                        });

                        if (fapmap.GlobalVariables.FileTypes.Image.Contains(fi.Extension.ToLower()))
                        {
                            Image img = Image.FromFile(fi.FullName);
                            Bitmap bmp = new Bitmap(img);
                            img.Dispose();

                            this.Invoke((MethodInvoker)delegate
                            {
                                showImage.Image = bmp;
                            });
                        }
                        else if (fapmap.GlobalVariables.FileTypes.Video.Contains(fi.Extension.ToLower()))
                        {
                            string dest = fapmap.GlobalVariables.Path.Dir.Thumbnails + "\\" + fapmap.getFileId(fi).ToString() + ".tmp";

                            if (File.Exists(dest))
                            {
                                Image img = Image.FromFile(dest);
                                Bitmap bmp = new Bitmap(img);
                                img.Dispose();

                                this.Invoke((MethodInvoker)delegate
                                {
                                    showImage.Image = bmp;
                                });
                            }
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
            getInfo(pass_path);
        }
        private void btn_openFile_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(pass_path)) { fapmap.Open(pass_path); }
            else if (File.Exists(pass_path)) { fapmap.Open(pass_path); }
        }
        private void btn_selectFileInExplorer_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(pass_path)) { fapmap.OpenAndSelectInExplorer(pass_path); }
            else if (File.Exists(pass_path)) { fapmap.OpenAndSelectInExplorer(pass_path); }
        }
        private void btn_incognito_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(pass_path)) { fapmap.Incognito(new DirectoryInfo(pass_path).Name);           }
            else if (File.Exists(pass_path)) { fapmap.Incognito(Path.GetFileNameWithoutExtension(pass_path)); }
        }
        private void btn_move_Click(object sender, EventArgs e)
        {
            string path = pass_path;
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
                    fapmap.MoveDir(path, dest);
                    pass_path = dest;
                }
            }
            else if (File.Exists(path))
            {
                FileInfo fi = new FileInfo(path);
                string dir = fapmap.OpenPathSelector(this, fi.Directory.FullName);
                if (!string.IsNullOrEmpty(dir) && Directory.Exists(dir))
                {
                    string dest = new DirectoryInfo(dir).FullName + "\\" + fi.Name;
                    fapmap.MoveFile(path, dest);
                    pass_path = dest;
                }
            }
        }
        private void btn_rename_Click(object sender, EventArgs e)
        {
            string path = pass_path;
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
                    fapmap.MoveDir(di_src.FullName, dest);
                    pass_path = dest;
                }
            }
            else if (File.Exists(path))
            {
                FileInfo fi_src = new FileInfo(path);
                string input = fapmap.OpenInputBox(this, "Rename file?", fi_src.Name, 0, fi_src.Name.Length - fi_src.Extension.Length);
                if (!string.IsNullOrEmpty(input))
                {
                    string dest = fi_src.Directory.FullName + "\\" + input;
                    fapmap.MoveFile(fi_src.FullName, dest);
                    pass_path = dest;
                }
            }
        }
        private void btn_delFile_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(pass_path)) { fapmap.TrashDir(pass_path);  }
            else if (File.Exists(pass_path)) { fapmap.TrashFile(pass_path); }
        }

        // md5 booru search
        private void btn_booru_api_Click(object sender, EventArgs e)
        {
            if (File.Exists(pass_path)) { fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.API + Path.GetFileNameWithoutExtension(pass_path)); }
        }
        private void btn_booru_rule34xxx_Click(object sender, EventArgs e)
        {
            if (File.Exists(pass_path)) { fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.rule34xxx + Path.GetFileNameWithoutExtension(pass_path)); }
        }
        private void btn_booru_gelbooru_Click(object sender, EventArgs e)
        {
            if (File.Exists(pass_path)) { fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.gelbooru + Path.GetFileNameWithoutExtension(pass_path)); }
        }
        private void btn_booru_danbooru_Click(object sender, EventArgs e)
        {
            if (File.Exists(pass_path)) { fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.danbooru + Path.GetFileNameWithoutExtension(pass_path)); }
        }
    }
}
