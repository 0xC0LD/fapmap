using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace fapmap
{
    public partial class fapmap_download : Form
    {
        public string pass_path = string.Empty;
        public List<string> pass_URLs = new List<string>();
        public string pass_webgrabURL = string.Empty;
        
        private WebClient client = new WebClient();
        public fapmap_download()
        {
            InitializeComponent();
            
            links_RMB.Renderer = new fapmap_res.color.fToolStripProfessionalRenderer();

            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.Headers.Add("user-agent", "fapmap.exe");
        }

        private void fapmap_download_Load(object sender, EventArgs e)
        {
            // path
            txt_dir.Text = fapmap.GlobalVariables.Path.Dir.MainFolder + "\\";
            if (!string.IsNullOrEmpty(pass_path) && Directory.Exists(pass_path)) { txt_dir.Text = new DirectoryInfo(pass_path).FullName + "\\"; }

            //hide ext
            webgrab_sw();

            links.Focus();
            this.ActiveControl = links;

            //download passed links
            if (pass_URLs.Count > 0)
            {
                foreach (string item in pass_URLs) { links_add(item); }
            }

            // webgrab
            if (!string.IsNullOrEmpty(pass_webgrabURL))
            {
                txt_webgrabURL.Text = pass_webgrabURL;
                cb_webgrab.Checked = true;
                webgrab();
            }
        }
        
        #region Window and FX
        
        private void fapmap_download_FormClosing(object sender, FormClosingEventArgs e) { Quit(); }
        private void fapmap_download_FormClosed(object sender, FormClosedEventArgs e) { /* Quit(); */ }

        private void Quit()
        {
            webgrab_die();
            auto.Enabled = false;
            client.CancelAsync();
            this_trayicon.Dispose();
            GC.Collect();
        }
        
        private void this_hide()
        {
            if (this.Visible)
            {
                this.Hide();
                updateIcon(download_busy);
            }
            else
            {
                this.Show();
                updateIcon(download_busy);
            }
        }
        
        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void updateIcon(bool busy)
        {
            if (this.Visible)
            {
                this.Icon               = busy ? Properties.Resources.icon_download : Properties.Resources.icon_downloadIdle;
                this.this_trayicon.Icon = busy ? Properties.Resources.icon_download : Properties.Resources.icon_downloadIdle;
            }
            else
            {
                this.Icon               = busy ? Properties.Resources.icon_downloadHidden : Properties.Resources.icon_downloadHiddenIdle;
                this.this_trayicon.Icon = busy ? Properties.Resources.icon_downloadHidden : Properties.Resources.icon_downloadHiddenIdle;
            }
        }


        #endregion
        
        #region functions

        #region links

        private void links_add(string link)
        {
            if (string.IsNullOrEmpty(link)) { return; }

            if (!Uri.IsWellFormedUriString(link, UriKind.Absolute))
            {
                info.ForeColor = System.Drawing.Color.DarkOrchid;
                info.Text = link;
                return;
            }

            bool isFile = false;
            foreach (string type in fapmap.GlobalVariables.FileTypes.Video) { if (isFile) { break; } if (link.Contains(type)) { isFile = true; break; } }
            foreach (string type in fapmap.GlobalVariables.FileTypes.Image) { if (isFile) { break; } if (link.Contains(type)) { isFile = true; break; } }
            foreach (string type in fapmap.GlobalVariables.FileTypes.Other) { if (isFile) { break; } if (link.Contains(type)) { isFile = true; break; } }

            if (!isFile)
            {
                if (cb_nonFile.Checked)
                {
                    info.ForeColor = System.Drawing.Color.DarkOrchid;
                    info.Text = "WARNING: " + link;
                    isFile = true;
                }
                else
                {
                    info.ForeColor = System.Drawing.Color.DarkOrchid;
                    info.Text = link;
                    return;
                }
            }

            // check for dupes
            bool dupe = false;
            foreach (ListViewItem url in links.Items) { if (link == url.Name) { dupe = true; break; } }

            if (dupe)
            {
                info.ForeColor = System.Drawing.Color.DarkOrchid;
                info.Text = "DUPE: " + link;
                return;
            }
            
            string filename = System.IO.Path.GetFileName(new Uri(link).LocalPath);
            if (string.IsNullOrEmpty(filename)) { filename = fapmap.get_utc() + ".html"; }
            
            links.Items.Add(new ListViewItem(new string[] { (links.Items.Count + 1).ToString(), filename, link }) { Name = link });
            links_updateCount(links.Items.Count);

            // resize and scroll
            foreach (ColumnHeader column in links.Columns) { column.Width = -2; }
            links.EnsureVisible(links.Items.Count - 1);
        }
        private void links_reload()
        {
            links_recountAndResize();
        }
        private void links_copy()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string text = item.Name;
                if (string.IsNullOrEmpty(text)) { continue; }
                System.Windows.Forms.Clipboard.SetText(text);
            }
        }
        private void links_paste()
        {
            string text = Clipboard.GetText();
            string[] links = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            if (links.Length > 1) { foreach (string line in links) { links_add(line); } }
            else { links_add(text); }
        }
        private void links_incognito()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string text = item.Name;
                if (string.IsNullOrEmpty(text)) { continue; }
                fapmap.Incognito(text);
            }
        }
        private void links_delete()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                links.Items.Remove(item);
                links_recountAndResize();
            }
        }
        private void links_deleteAll()
        {
            if (
                MessageBox.Show("Remove all (" + links.Items.Count + ") URLs?",
                "Are you sure?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation
            ) == DialogResult.Yes) { links.Items.Clear(); }

            //COUNT
            links_recountAndResize();
        }
        private void links_deleteSome()
        {
            string input = fapmap.OpenInputBox(this, "Remove URLs that contain:", "thumb.jpg", 0, "thumb.jpg".Length);
            if (!string.IsNullOrEmpty(input))
            {
                List<ListViewItem> itemsToDel = new List<ListViewItem>();
                foreach (ListViewItem item in links.Items)
                {
                    if (item.Name == null) { continue; }
                    string text = item.Name;
                    if (string.IsNullOrEmpty(text)) { continue; }
                    if (text.Contains(input)) { itemsToDel.Add(item); }
                }

                if (itemsToDel.Count == 0)
                {
                    MessageBox.Show("No files found.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Remove " + itemsToDel.Count + " URLs?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (dr == DialogResult.Yes)
                    {
                        foreach (ListViewItem item in itemsToDel)
                        {
                            links.Items.Remove(item);
                        }
                        links_recountAndResize();
                    }
                }
            }

            //COUNT
            links_updateCount(links.Items.Count);
        }
        private void links_download()
        {
            if (client.IsBusy) { client.CancelAsync(); return; }
            download(null);
        }
        private void links_downloadSelected()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                download(item);
            }
        }
        private void links_updateCount(int num)
        {
            label_linksCount.Text = num.ToString();
        }
        private void links_recountAndResize()
        {
            // update count label
            links_updateCount(links.Items.Count);

            // recount
            int count = 0;
            foreach (ListViewItem lvi in links.Items)
            {
                count++;
                lvi.SubItems[0].Text = count.ToString();
            }

            // resize
            foreach (ColumnHeader column in links.Columns) { column.Width = -2; }
        }

        #endregion

        #region download

        private bool download_busy = false;
        private void download(ListViewItem listItem)
        {
            if (!dl(listItem)) { download_busy = false; }
        }
        private bool dl(ListViewItem listItem)
        {
            if (download_busy) { return true; }
            download_busy = true;
            
            info.ForeColor = System.Drawing.Color.Yellow;
            info.Text = "Checking URL...";

            if (links.Items.Count == 0)
            {
                info.ForeColor = System.Drawing.Color.Yellow;
                info.Text = "No items in listbox...";
                return false;
            }

            if (listItem == null) { listItem = links.Items[0]; }
            string name = listItem.SubItems[1].Text;
            string link = listItem.SubItems[2].Text;
            links.Items.Remove(listItem);
            links_recountAndResize();

            string path = txt_dir.Text + name;

            if (string.IsNullOrEmpty(link) || !Uri.IsWellFormedUriString(link, UriKind.Absolute))
            {
                //url not valid
                info.ForeColor = System.Drawing.Color.DarkOrchid;
                info.Text = "URL not valid!";
                return false;
            }

            bool invalidPath = false;
            foreach (char ch in System.IO.Path.GetInvalidPathChars())
            { if (path.Contains(ch)) { invalidPath = true; break; } }

            if (invalidPath)
            {
                info.ForeColor = System.Drawing.Color.DarkOrchid;
                info.Text = "Path not valid!";
                return false;
            }

            int downloadMode = 0;
            if (!cb_conflict_replace.Checked && !cb_conflict_rename.Checked && !cb_conflict_skip.Checked)
            {
                if (File.Exists(path))
                {
                    DialogResult dialogResult = MessageBox.Show(
                        "A file with the name " + name + " already exists." + Environment.NewLine
                        + Environment.NewLine + "YES          = REPLACE"
                        + Environment.NewLine + "NO          = NEW NAME"
                        + Environment.NewLine + "CANCEL = SKIP THIS URL",
                        "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                        );
                    
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:    downloadMode = 1; break;
                        case DialogResult.No:     downloadMode = 2; break;
                        case DialogResult.Cancel: downloadMode = 3; break;
                    }
                }
            }
            else
            {
                if      (cb_conflict_replace.Checked) { downloadMode = 1; }
                else if (cb_conflict_rename.Checked)  { downloadMode = 2; }
                else if (cb_conflict_skip.Checked)    { downloadMode = 3; }
            }
            
            if (File.Exists(path)) // IF FILE EXISTS
            {
                switch (downloadMode)
                {
                    case 1: /* File.Delete(path); */ break;
                    case 2:
                        {
                            FileInfo fi = new FileInfo(path);

                            int c = 1;
                            path = fi.FullName.Replace(fi.Name, "") + fi.Name.Replace(fi.Extension, "") + " [" + c + "]" + fi.Extension;

                            while (File.Exists(path))
                            {
                                c++;
                                path = fi.FullName.Replace(fi.Name, "") + fi.Name.Replace(fi.Extension, "") + " [" + c + "]" + fi.Extension;
                            }
                            break;
                        }
                    case 3: return false; //break;
                }
            }

            if (!string.IsNullOrEmpty(txt_dir.Text))
            {
                //CREATE ALL FOLDERS
                Directory.CreateDirectory(Directory.GetParent(txt_dir.Text).FullName);
                txt_dir_TextChanged(null, null); //change color of created folder
            }

            txt_dledURL.Text = link;
            txt_dledPATH.Text = path;

            info.ForeColor = System.Drawing.Color.SlateBlue;
            info.Text = "Downloading... ";

            updateIcon(true);

            btn_dl.BackgroundImage = Properties.Resources.close;
            
            //LOG IT
            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.DING, link + " -> " + path);

            try
            {
                //DOWNLOAD
                client.DownloadFileAsync(new Uri(link), path);
            }
            catch (ArgumentException e) { info.ForeColor = System.Drawing.Color.DarkOrchid; info.Text = e.Message; return false; }
            catch (WebException e) { info.ForeColor = System.Drawing.Color.DarkOrchid; info.Text = e.Message; return false; }
            catch (InvalidOperationException e) { info.ForeColor = System.Drawing.Color.DarkOrchid; info.Text = e.Message; return false; }
            catch (Exception e) { info.ForeColor = System.Drawing.Color.DarkOrchid; info.Text = e.Message; return false; }
            return true;
        }
        
        private void auto_Tick(object sender, EventArgs e)
        {
            if (!cb_auto.Checked) { auto.Enabled = false; }
            download(null);
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //main
            double now = e.BytesReceived;
            double max = e.TotalBytesToReceive;

            string bytesIn_CONVERTED_STRING = fapmap.ROund(now);
            string totalBytes_CONVERTED_STRING = fapmap.ROund(max);
            
            info.ForeColor = System.Drawing.Color.SlateBlue;
            info.Text = e.ProgressPercentage + "% = " + bytesIn_CONVERTED_STRING + " (" + now + " bytes)" + Environment.NewLine + "100% = " + totalBytes_CONVERTED_STRING + " (" + max + " bytes)";
            this_trayicon.Text = (links.Items.Count + 1).ToString() + ": " + e.ProgressPercentage.ToString() + "%";
        }
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled) { download_busy = false; return; }
            
            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.DLED, txt_dledURL.Text + " -> " + txt_dledPATH.Text);
            
            // update UI
            dledLocation = txt_dledPATH.Text;
            HelpBalloon.SetToolTip(btn_open, dledLocation);
            info.ForeColor = System.Drawing.Color.Teal;
            links_updateCount(links.Items.Count);
            updateIcon(false);
            btn_dl.BackgroundImage = Properties.Resources.download;

            if (links.Items.Count == 0)
            {
                     if (rb_shutdown.Checked) { shutdownPC(); System.Environment.Exit(0); }
                else if (rb_exit.Checked)     { System.Environment.Exit(0); }
                else if (rb_close.Checked)    { this.Close(); }
            }

            
            download_busy = false;
        }
        
        #endregion

        #region other
        
        private string dledLocation = string.Empty;
        private void openDownloadedFile()
        {
            if (!string.IsNullOrEmpty(dledLocation))
            {
                if (File.Exists(dledLocation))
                {
                    Process.Start(dledLocation);
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, dledLocation);
                    return;
                }
            }

            info.ForeColor = System.Drawing.Color.DarkOrchid;
            info.Text = "File Not Found!";
            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, dledLocation);
        }

        private bool IsPathValid(string path)
        {
            Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
            if (!driveCheck.IsMatch(path.Substring(0, 3))) return false;
            string invalidChars = new string(Path.GetInvalidPathChars());
            invalidChars += @":/?*" + "\"";
            Regex hasBadChar = new Regex("[" + Regex.Escape(invalidChars) + "]");
            if (hasBadChar.IsMatch(path.Substring(3, path.Length - 3))) { return false; }

            DirectoryInfo dir = new DirectoryInfo(Path.GetFullPath(path));
            if (!dir.Exists) { dir.Create(); }
            return true;
        }

        private void shutdownPC()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "shutdown.exe";
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.Arguments = "/s";
            cmd.Start();
        }

        #endregion

        #region WEBGRAB

        private Process webgrabProcess = null;
        private void webgrab_die()
        {
            try
            {
                if (webgrabProcess != null && !webgrabProcess.HasExited) { webgrabProcess.Kill(); }
            }
            catch (Exception) { }
        }
        private bool webgrab_busy = false;
        private void webgrab()
        {
            if (webgrab_busy) { webgrab_die(); return; }
            webgrab_busy = true;

            new Thread(() => {
                string this_url = txt_webgrabURL.Text;
                string this_options = txt_webgrabOptions.Text;
                string path = txt_dir.Text;

                if (string.IsNullOrEmpty(this_url))
                {
                    info.ForeColor = System.Drawing.Color.DarkOrchid;
                    info.Text = "No input...";
                    webgrab_busy = false;
                    return;
                }
                if (!File.Exists(fapmap.GlobalVariables.Path.File.Exe.WEBGRAB))
                {
                    info.ForeColor = System.Drawing.Color.DarkOrchid;
                    info.Text = "webgrab.exe not found...";
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, fapmap.GlobalVariables.Path.File.Exe.WEBGRAB);
                    webgrab_busy = false;
                    return;
                }

                info.ForeColor = System.Drawing.Color.Yellow;
                info.Text = "Scanning web page for URLs...";

                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, fapmap.GlobalVariables.Path.File.Exe.WEBGRAB + " --out \"" + this_url + "\" \"" + this_options + "\"");

                btn_webgrabStart.BackgroundImage = Properties.Resources.close;
                
                //settings
                webgrabProcess = new Process();
                webgrabProcess.StartInfo.FileName = fapmap.GlobalVariables.Path.File.Exe.WEBGRAB;
                webgrabProcess.StartInfo.Arguments = "--out \"" + this_url + "\" \"" + this_options + "\"";
                webgrabProcess.StartInfo.WorkingDirectory = Directory.Exists(path) ? path : fapmap.GlobalVariables.Path.Dir.MainFolder;
                webgrabProcess.StartInfo.UseShellExecute = false;
                webgrabProcess.StartInfo.CreateNoWindow = true;
                webgrabProcess.StartInfo.RedirectStandardOutput = true;
                webgrabProcess.StartInfo.RedirectStandardError = true;
                webgrabProcess.OutputDataReceived += webgrab_output;
                webgrabProcess.ErrorDataReceived += webgrab_output;
                webgrabProcess.Start();
                webgrabProcess.BeginOutputReadLine();
                webgrabProcess.BeginErrorReadLine();
                webgrabProcess.WaitForExit();
                webgrabProcess.Close();
                
                btn_webgrabStart.BackgroundImage = Properties.Resources.arrow_left;

                info.ForeColor = System.Drawing.Color.Teal;
                info.Text = "Done!";

                webgrab_busy = false;

            }) { IsBackground = true }.Start();
        }
        private void webgrab_output(object sender, DataReceivedEventArgs e)
        {
            try { links_add(e.Data); }
            catch (Exception) { }
        }
        private void webgrab_sw()
        {
            if (!cb_webgrab.Checked)
            {
                sc_webgrab.Panel1.Hide();
                sc_webgrab.Panel1Collapsed = true;
            }
            else
            {
                sc_webgrab.Panel1.Show();
                sc_webgrab.Panel1Collapsed = false;
            }
        }

        #endregion

        #endregion

        #region UI EVENTS

        #region buttons

        private void btn_dl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { links_download(); }
        }
        private void btn_openPathSelector_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { fapmap.OpenPathSelector(this, txt_dir, true); }
        }
        private void btn_open_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { openDownloadedFile(); }
        }
        private void btn_addURL_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { links_add(txt_url.Text); }
        }
        private void btn_webgrabStart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { webgrab(); }
        }
        
        private void this_trayicon_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left: this_hide(); break;
                case MouseButtons.Right: this.Close(); break;
            }
        }

        #endregion

        #region check boxes

        private void cb_auto_CheckedChanged(object sender, EventArgs e)
        {
            auto.Enabled = cb_auto.Checked;
        }
        
        private void cb_webgrab_CheckedChanged(object sender, EventArgs e)
        {
            webgrab_sw();
        }

        private void cb_replace_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_conflict_replace.Checked)
            {
                cb_conflict_rename.Checked = false;
                cb_conflict_skip.Checked = false;
            }
        }
        private void cb_rename_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_conflict_rename.Checked)
            {
                cb_conflict_replace.Checked = false;
                cb_conflict_skip.Checked = false;
            }
        }
        private void cb_skip_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_conflict_skip.Checked)
            {
                cb_conflict_replace.Checked = false;
                cb_conflict_rename.Checked = false;
            }
        }

        #endregion

        #region text boxes

        private void txt_dir_KeyDown(object sender, KeyEventArgs e)
        {
            //DEL TEXT
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            //DEL TEXT
            if (e.Control && e.KeyCode == Keys.Back)
            {
                txt_dir.Text = fapmap.GlobalVariables.Path.Dir.MainFolder + "\\";

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_filename_KeyDown(object sender, KeyEventArgs e)
        {
            //DEL TEXT
            if (e.KeyCode == Keys.Enter)
            {
                txt_filename.ReadOnly = true;
                txt_filename.ForeColor = Color.DimGray;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            //DEL TEXT
            if (e.Control && e.KeyCode == Keys.Back)
            {
                txt_filename.Text = "";

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                links_add(txt_url.Text);
            }

            //DEL TEXT
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;

                txt_url.Text = "";
            }
        }
        private void txt_dledPATH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                txt_dledPATH.Select(0, txt_dledPATH.TextLength);
            }
        }
        private void txt_dledURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A) { txt_dledURL.Select(0, txt_dledURL.TextLength); }
        }
        private void txt_webgrabURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webgrab();
                e.SuppressKeyPress = true;
            }

            //DEL TEXT
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;

                txt_webgrabURL.Text = "";
            }
        }
        private void txt_webgrabOptions_KeyDown(object sender, KeyEventArgs e)
        {
            //DEL TEXT
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;

                txt_webgrabOptions.Text = "";
            }
        }


        private void txt_dir_TextChanged(object sender, EventArgs e)
        {
            txt_dir.ForeColor = Directory.Exists(txt_dir.Text) ? Color.SlateBlue : Color.Red;
        }
        ListViewItem links_selected = null;
        private void txt_filename_TextChanged(object sender, EventArgs e)
        {
            if (links_selected == null)
            {
                txt_filename.ReadOnly = true;
                txt_filename.ForeColor = Color.DimGray;
            }
            else
            {
                if (string.IsNullOrEmpty(txt_filename.Text))
                {
                    txt_filename.Text = System.IO.Path.GetFileName(new Uri(links_selected.Name).LocalPath);
                }
                else
                {
                    links_selected.SubItems[1].Text = txt_filename.Text;
                }
            }
        }
        private void txt_webgrabURL_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("");
            foreach (var line in fapmap.GlobalVariables.Settings.Other.WebGrabTableLines)
            {
                string[] index = line.Split('|');

                if (index.Length == 2)
                {
                    if (ci.CompareInfo.IndexOf(txt_webgrabURL.Text, index[0], System.Globalization.CompareOptions.IgnoreCase) >= 0)
                    {
                        txt_webgrabOptions.Text = index[1];
                        break;
                    }
                }
            }
        }

        private void txt_url_DragDrop(object sender, DragEventArgs e)
        {
            txt_url.Text = (e.Data.GetData(typeof(string)) as string);
        }
        private void txt_url_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }

        private void txt_filename_DragDrop(object sender, DragEventArgs e)
        {
            if (!txt_filename.ReadOnly)
            {
                txt_filename.Text = (e.Data.GetData(typeof(string)) as string);
            }
        }
        private void txt_filename_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }

        #endregion

        #region links

        private void links_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { links_downloadSelected(); }
        }
        private void links_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 || e.Control && e.KeyCode == Keys.R) { links_reload(); }
            if ((e.KeyCode == Keys.Enter) || (e.Control && e.KeyCode == Keys.W)) { e.SuppressKeyPress = true; links_downloadSelected(); }//ENTER    
            if (e.Control && e.KeyCode == Keys.U) { links_incognito(); }

            //DELETE
            if (e.Control && e.KeyCode == Keys.Delete) { links_deleteAll(); }
            else if (e.Shift && e.KeyCode == Keys.Delete) { links_deleteSome(); }
            else if (e.KeyCode == Keys.Delete) { links_delete(); }

            if (e.Control && e.KeyCode == Keys.C) { links_copy(); }               //COPY
            if (e.Control && e.KeyCode == Keys.X) { links_copy(); links_delete(); } //CUT
            if (e.Control && e.KeyCode == Keys.V) { links_paste(); }         //PASTE
        }
        private void links_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (links.SelectedItems.Count == 0)
            {
                //UNSELECT
                txt_filename.ReadOnly = true;
                txt_filename.ForeColor = Color.DarkSlateBlue;
            }
            else
            {
                //SELECT
                txt_filename.ReadOnly = false;
                txt_filename.ForeColor = Color.SlateBlue;

                foreach (ListViewItem item in links.SelectedItems)
                {
                    links_selected = item;
                    txt_filename.Text = item.SubItems[1].Text;
                    break;
                }
            }
        }

        private void links_DragDrop(object sender, DragEventArgs e)
        {
            string stringData = e.Data.GetData(typeof(string)) as string;
            links_add(stringData);
        }
        private void links_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }

        #endregion
        
        #region RMB

        private void links_RMB_refresh_Click(object sender, EventArgs e)
        {
            links_reload();
        }
        private void links_RMB_copy_Click(object sender, EventArgs e)
        {
            links_copy();
        }
        private void links_RMB_cut_Click(object sender, EventArgs e)
        {
            links_copy();
            links_delete();
        }
        private void links_RMB_paste_Click(object sender, EventArgs e)
        {
            links_paste();
        }
        private void links_RMB_incognito_Click(object sender, EventArgs e)
        {
            links_incognito();
        }
        private void links_RMB_delete_Click(object sender, EventArgs e)
        {
            links_delete();
        }
        private void links_RMB_deleteAll_Click(object sender, EventArgs e)
        {
            links_deleteAll();
        }
        private void links_RMB_deleteSome_Click(object sender, EventArgs e)
        {
            links_deleteSome();
        }

        #endregion

        #endregion

        
    }
}
