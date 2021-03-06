﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.WindowsAPICodePack;

namespace fapmap
{
    public partial class fapmap_download : Form
    {
        public string pass_path = string.Empty;
        public string[] pass_URLs = { };
        public string pass_webgrabURL = string.Empty;
        
        private WebClient client = new WebClient();
        public fapmap_download()
        {
            InitializeComponent();
            
            links_RMB.Renderer = new fapmap_res.FapMapColors.FapMapToolStripRenderer(Color.Turquoise);

            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.Headers.Add("user-agent", "fapmap.exe");
        }
        
        private void fapmap_download_Load(object sender, EventArgs e)
        {
            // path
            txt_dir.Text = fapmap.GlobalVariables.Path.Dir.MainFolder + "\\";
            if (Directory.Exists(pass_path)) { txt_dir.Text = pass_path + "\\"; }
            else if (File.Exists(pass_path)) { txt_dir.Text = Path.GetDirectoryName(pass_path) + "\\"; }
            
            links.Focus();
            this.ActiveControl = links;

            // add passed links
            if (pass_URLs.Length > 0)
            {
                links_addRange(pass_URLs);
                if (links.Items.Count > 0) { links.Items[0].Selected = true; }
                rb_close.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.DownloaderAutoClose;
            }

            // webgrab
            if (!string.IsNullOrEmpty(pass_webgrabURL))
            {
                txt_webgrabURL.Text = pass_webgrabURL;
                webgrab();
                rb_close.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.DownloaderAutoClose;
            }
        }
        
        #region Window and FX
        
        private void fapmap_download_FormClosing(object sender, FormClosingEventArgs e) { Quit(); }
        private void Quit()
        {
            webgrab_die();
            auto.Enabled = false;
            client.CancelAsync();
            this_trayicon.Dispose();
            GC.Collect();
        }
        private void QuitFapmap()
        {
            Quit();
            fapmap.CrashHandler_stop();
            Environment.Exit(0);
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
        
        private bool this_trayicon_IsDisposed = false;
        private void this_trayicon_Disposed(object sender, EventArgs e)
        {
            this_trayicon_IsDisposed = true;
        }
        private void updateIcon(bool busy)
        {
            if (this_trayicon_IsDisposed) { return; }

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

        private void this_trayicon_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left: this_hide(); break;
                case MouseButtons.Right: this.Close(); break;
            }
        }

        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        #endregion

        #region functions

        #region links

        private void links_add(string link)
        {
            if (string.IsNullOrEmpty(link)) { return; }

            if (!Uri.IsWellFormedUriString(link, UriKind.Absolute))
            {
                info.ForeColor = Color.PaleVioletRed;
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
                    info.ForeColor = Color.PaleVioletRed;
                    info.Text = "WARNING: " + link;
                    isFile = true;
                }
                else
                {
                    info.ForeColor = Color.PaleVioletRed;
                    info.Text = link;
                    return;
                }
            }

            // check for dupes
            bool dupe = false;
            foreach (ListViewItem url in links.Items) { if (link == url.Name) { dupe = true; break; } }

            if (dupe)
            {
                info.ForeColor = Color.PaleVioletRed;
                info.Text = "DUPE: " + link;
                return;
            }
            
            string filename = System.IO.Path.GetFileName(new Uri(link).LocalPath);
            if (string.IsNullOrEmpty(filename)) { filename = fapmap.get_utc() + ".html"; }
            
            links.Items.Add(new ListViewItem(new string[] { (links.Items.Count + 1).ToString(), filename, link }) { Name = link, Selected = true });
            links_updateCount(links.Items.Count);

            // resize and scroll
            links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            links.EnsureVisible(links.Items.Count - 1);
        }
        private void links_addRange(string[] list)
        {
            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach(string link in list)
            {
                if (string.IsNullOrEmpty(link)) { continue; }

                if (!Uri.IsWellFormedUriString(link, UriKind.Absolute))
                {
                    info.ForeColor = Color.PaleVioletRed;
                    info.Text = link;
                    continue;
                }

                bool isFile = false;
                foreach (string type in fapmap.GlobalVariables.FileTypes.Video) { if (isFile) { break; } if (link.Contains(type)) { isFile = true; break; } }
                foreach (string type in fapmap.GlobalVariables.FileTypes.Image) { if (isFile) { break; } if (link.Contains(type)) { isFile = true; break; } }
                foreach (string type in fapmap.GlobalVariables.FileTypes.Other) { if (isFile) { break; } if (link.Contains(type)) { isFile = true; break; } }

                if (!isFile)
                {
                    if (cb_nonFile.Checked)
                    {
                        info.ForeColor = Color.PaleVioletRed;
                        info.Text = "WARNING: " + link;
                        isFile = true;
                    }
                    else
                    {
                        info.ForeColor = Color.PaleVioletRed;
                        info.Text = link;
                        continue;
                    }
                }

                // check for dupes
                bool dupe = false;
                foreach (ListViewItem url in links.Items) { if (link == url.Name) { dupe = true; break; } }

                if (dupe)
                {
                    info.ForeColor = Color.PaleVioletRed;
                    info.Text = "DUPE: " + link;
                    continue;
                }

                string filename = System.IO.Path.GetFileName(new Uri(link).LocalPath);
                if (string.IsNullOrEmpty(filename)) { filename = fapmap.get_utc() + ".html"; }
                
                lvis.Add(new ListViewItem(new string[] { (lvis.Count + 1).ToString(), filename, link }) { Name = link });
            }

            
            if (lvis.Count > 0)
            {
                links.Items.AddRange(lvis.ToArray());
                links_updateCount(links.Items.Count);

                // resize and scroll
                links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                links.EnsureVisible(links.Items.Count - 1);
            }
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
            string[] links = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

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
            links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        #endregion

        #region download

        private bool download_busy = false;
        private void download(ListViewItem listItem)
        {
            if (!dl(listItem)) { download_busy = false; }
        }
        private ListViewItem currentDownloadItem = null;
        private bool dl(ListViewItem listItem)
        {
            if (download_busy) { return true; }
            download_busy = true;

            if (links.Items.Count == 0)
            {
                // info.ForeColor = Color.Turquoise;
                // info.Text = "No items in listbox...";
                return false;
            }

            info.ForeColor = Color.Turquoise;
            info.Text = "Checking URL...";

            if (listItem == null) { listItem = links.Items[0]; }
            string name = listItem.SubItems[1].Text;
            string link = listItem.SubItems[2].Text;
            currentDownloadItem = listItem;
            if (links.Items.Contains(listItem))
            {
                links.Items.Remove(listItem);
                links_recountAndResize();
            }
            
            // replace invalid file chars in filename
            foreach (char c in Path.GetInvalidFileNameChars())
            { name = name.Replace(c, '_'); }

            string path = txt_dir.Text + name;

            if (string.IsNullOrEmpty(link) || !Uri.IsWellFormedUriString(link, UriKind.Absolute))
            {
                //url not valid
                info.ForeColor = Color.PaleVioletRed;
                info.Text = "URL not valid!";
                return false;
            }
            
            info.ForeColor = Color.Turquoise;
            info.Text = "Checking if file already exists...";

            int downloadMode = 0;

            if (File.Exists(path))
            {
                if      (cb_conflict_replace.Checked) { downloadMode = 1; }
                else if (cb_conflict_rename.Checked)  { downloadMode = 2; }
                else if (cb_conflict_skip.Checked)    { downloadMode = 3; }
                else
                {
                    DialogResult dialogResult = fapmap.OpenFileExistsDialog(this, path);

                    switch (dialogResult)
                    {
                        case DialogResult.Yes:    downloadMode = 1; break; // replace
                        case DialogResult.No:     downloadMode = 2; break; // new name
                        case DialogResult.Cancel: downloadMode = 3; break; // skip
                    }
                }
            }
           

            switch (downloadMode)
            {
                case 1: if (File.Exists(path)) { File.Delete(path); }  break;
                case 2:
                    {
                        if (File.Exists(path))
                        {
                            FileInfo fi = new FileInfo(path);

                            int c = 1;
                            path = fi.FullName.Replace(fi.Name, "") + fi.Name.Replace(fi.Extension, "") + " [" + c + "]" + fi.Extension;

                            while (File.Exists(path))
                            {
                                c++;
                                path = fi.FullName.Replace(fi.Name, "") + fi.Name.Replace(fi.Extension, "") + " [" + c + "]" + fi.Extension;
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        info.ForeColor = Color.Turquoise;
                        info.Text = "Skipped!";
                        return false; //break;
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

            info.ForeColor = Color.Turquoise;
            info.Text = "Downloading... ";

            // last setup
            pbar.Visible = true;
            updateIcon(true);
            btn_dl.BackgroundImage = Properties.Resources.close_turquoise;
            
            //LOG IT
            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.DING, link + " -> " + path);

            try
            {
                //DOWNLOAD
                client.DownloadFileAsync(new Uri(link), path);
            }
            catch (ArgumentException e)         { info.ForeColor = Color.PaleVioletRed; info.Text = e.Message; return false; }
            catch (WebException e)              { info.ForeColor = Color.PaleVioletRed; info.Text = e.Message; return false; }
            catch (InvalidOperationException e) { info.ForeColor = Color.PaleVioletRed; info.Text = e.Message; return false; }
            catch (Exception e)                 { info.ForeColor = Color.PaleVioletRed; info.Text = e.Message; return false; }
            return true;
        }
        
        private void auto_Tick(object sender, EventArgs e)
        {
            if (!cb_auto.Checked) { auto.Enabled = false; }
            download(null);
        }

        DateTime lastUpdate;
        long lastBytes = 0;
        long bytes_current = 0;
        long bytes_total   = 0;
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //main
            bytes_current = e.BytesReceived;
            bytes_total   = e.TotalBytesToReceive;
            
            // speed
            if (lastBytes == 0)
            {
                lastUpdate = DateTime.Now;
                lastBytes = bytes_current;
                return;
            }
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = now - lastUpdate;
            long bytesChange = bytes_current - lastBytes;
            int sec = timeSpan.Seconds;
            long bytesPerSecond = bytesChange / (sec > 0 ? sec : 1);
            lastBytes = bytes_current;
            lastUpdate = now;

            pbar.Value = e.ProgressPercentage;


            info.ForeColor = Color.Turquoise;
            info.Text = e.ProgressPercentage + "% = " + fapmap.ROund(bytes_current) + " (" + bytes_current + " bytes)" + Environment.NewLine +
                                            "100% = " + fapmap.ROund(bytes_total) + " (" + bytes_total + " bytes)" + Environment.NewLine + 
                                            "speed: " + fapmap.ROund(bytesPerSecond) + " (" + bytesPerSecond + " bytes)" + " per sec";


            Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, 100, Handle);
            this_trayicon.Text = (links.Items.Count + 1).ToString() + ": " + e.ProgressPercentage.ToString() + "%";
        }
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            bool failed = false;
            if (e.Cancelled || bytes_current != bytes_total) { failed = true; }

            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.DLED, txt_dledURL.Text + " -> " + txt_dledPATH.Text);

            if (failed)
            {
                info.ForeColor = Color.PaleVioletRed;

                // delete
                if (cb_delFail.Checked && File.Exists(txt_dledPATH.Text)) { File.Delete(txt_dledPATH.Text); }

                if (!e.Cancelled
                 && currentDownloadItem != null
                 && (
                        cb_autoRetry.Checked
                     || MessageBox.Show
                        (
                         "Retry download?",
                         "Download Failed",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Error
                        ) == DialogResult.Yes
                    )
                )
                {
                    download_busy = false;
                    links.Items.Add(currentDownloadItem);
                    download(currentDownloadItem);
                    return;
                }
            }
            else
            {
                info.ForeColor = Color.Lime;

                // hide and reset bar
                pbar.Visible = false;
                pbar.Value = 0;
            }
            
            links_updateCount(links.Items.Count);
            updateIcon(false);
            btn_dl.BackgroundImage = Properties.Resources.downloadFile_turquoise;
            
            if (!failed && links.Items.Count == 0)
            {
                if (rb_shutdown.Checked) { shutdownPC(); QuitFapmap(); }
                else if (rb_exit.Checked) { QuitFapmap(); }
                else if (rb_close.Checked) { this.Close(); }
            }

            download_busy = false;
        }
        
        #endregion

        #region other
        
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
        private List<string> webgrab_outputLinks = new List<string>();
        private void webgrab()
        {
            if (webgrab_busy) { webgrab_die(); return; }
            webgrab_busy = true;

            string this_url = txt_webgrabURL.Text;
            string this_options = txt_webgrabOptions.Text;
            string path = txt_dir.Text;

            new Thread(() => {

                try
                {
                    if (string.IsNullOrEmpty(this_url))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            info.ForeColor = Color.PaleVioletRed;
                            info.Text = "No input...";
                        });

                        webgrab_busy = false;
                        return;
                    }

                    if (!File.Exists(fapmap.GlobalVariables.Path.File.Exe.WEBGRAB))
                    {
                        fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, fapmap.GlobalVariables.Path.File.Exe.WEBGRAB);

                        this.Invoke((MethodInvoker)delegate
                        {
                            info.ForeColor = Color.PaleVioletRed;
                            info.Text = "webgrab.exe not found...";
                        });

                        webgrab_busy = false;
                        return;
                    }
                    
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, fapmap.GlobalVariables.Path.File.Exe.WEBGRAB + " --out \"" + this_url + "\" \"" + this_options + "\"");

                    this.Invoke((MethodInvoker)delegate
                    {
                        info.ForeColor = Color.Turquoise;
                        info.Text = "Scanning web page for URLs...";
                        btn_webgrabStart.BackgroundImage = Properties.Resources.close_turquoise;
                    });
                    
                    webgrab_outputLinks.Clear();

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

                    links_addRange(webgrab_outputLinks.ToArray());

                    this.Invoke((MethodInvoker)delegate
                    {
                        info.ForeColor = Color.Lime;
                        info.Text = "Done!";
                        btn_webgrabStart.BackgroundImage = Properties.Resources.scanPage_turquoise;
                    });
                    
                    webgrab_busy = false;
                }
                catch (Exception) { webgrab_busy = false; return; }

            }) { IsBackground = true }.Start();
        }
        private void webgrab_output(object sender, DataReceivedEventArgs e)
        {
            try { webgrab_outputLinks.Add(e.Data); }
            catch (Exception) { }
        }

        #endregion

        #endregion

        #region UI EVENTS

        #region buttons
        
        private void btn_webgrabStart_Click(object sender, EventArgs e)
        {
            webgrab();
        }
        private void btn_addURL_Click(object sender, EventArgs e)
        {
            links_add(txt_url.Text);
        }
        private void btn_openPathSelector_Click(object sender, EventArgs e)
        {
            fapmap.OpenPathSelectorTXT(this, txt_dir, true, txt_dir.Text);
        }
        private void btn_dl_Click(object sender, EventArgs e)
        {
            links_download();
        }
        private void btn_openURL_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_dledURL.Text))
            {
                fapmap.Incognito(txt_dledURL.Text);
            }
        }
        private void btn_openFile_Click(object sender, EventArgs e)
        {
            fapmap.OpenProperties(txt_dledPATH.Text);
        }

        #endregion

        #region check boxes

        private void cb_auto_CheckedChanged(object sender, EventArgs e)
        {
            auto.Enabled = cb_auto.Checked;
        }
        
        #endregion

        #region text boxes

        private void txt_dir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!Directory.Exists(txt_dir.Text)) { Directory.CreateDirectory(txt_dir.Text); }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            
            if (e.Control && e.KeyCode == Keys.Back)
            {
                txt_dir.Text = fapmap.GlobalVariables.Path.Dir.MainFolder + "\\";

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_filename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_filename.ReadOnly = true;
                txt_filename.ForeColor = Color.Teal;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

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
            
            if (e.Control && e.KeyCode == Keys.Back)
            {
                txt_url.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_dledPATH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A) { txt_dledPATH.Select(0, txt_dledPATH.TextLength); }
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

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                txt_webgrabURL.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_webgrabOptions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                txt_webgrabOptions.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        
        private void txt_dir_TextChanged(object sender, EventArgs e)
        {
            if (txt_dir.Text.Contains("\n")) { txt_dir.Text = txt_dir.Text.Replace("\n", String.Empty); }
            if (txt_dir.Text.Contains("\r")) { txt_dir.Text = txt_dir.Text.Replace("\r", String.Empty); }
            if (txt_dir.Text.Contains("\t")) { txt_dir.Text = txt_dir.Text.Replace("\t", String.Empty); }

            txt_dir.ForeColor = Directory.Exists(txt_dir.Text) ? Color.Turquoise : Color.PaleVioletRed;
        }

        private bool txt_filename_dontUpdate = false;
        private void txt_filename_TextChanged(object sender, EventArgs e)
        {
            if (txt_filename_dontUpdate) { return; }

            if (txt_filename.Text.Contains("\n")) { txt_filename.Text = txt_filename.Text.Replace("\n", String.Empty); }
            if (txt_filename.Text.Contains("\r")) { txt_filename.Text = txt_filename.Text.Replace("\r", String.Empty); }
            if (txt_filename.Text.Contains("\t")) { txt_filename.Text = txt_filename.Text.Replace("\t", String.Empty); }

            if (links.SelectedItems.Count == 0)
            {
                txt_filename.ReadOnly = true;
                txt_filename.ForeColor = Color.Teal;
            }
            else
            {
                if (string.IsNullOrEmpty(txt_filename.Text))
                {
                    txt_filename.Text = System.IO.Path.GetFileName(new Uri(links.SelectedItems[0].Name).LocalPath);
                }
                else
                {
                    links.SelectedItems[0].SubItems[1].Text = txt_filename.Text;
                }

                links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }
        private void txt_webgrabURL_TextChanged(object sender, EventArgs e)
        {
            if (txt_webgrabURL.Text.Contains("\n")) { txt_webgrabURL.Text = txt_webgrabURL.Text.Replace("\n", String.Empty); }
            if (txt_webgrabURL.Text.Contains("\r")) { txt_webgrabURL.Text = txt_webgrabURL.Text.Replace("\r", String.Empty); }
            if (txt_webgrabURL.Text.Contains("\t")) { txt_webgrabURL.Text = txt_webgrabURL.Text.Replace("\t", String.Empty); }

            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("");
            foreach (var line in fapmap.GlobalVariables.Settings.Other.WebGrabTableLines)
            {
                string[] index = line.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

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
        private void txt_url_TextChanged(object sender, EventArgs e)
        {
            if (txt_url.Text.Contains("\n")) { txt_url.Text = txt_url.Text.Replace("\n", String.Empty); }
            if (txt_url.Text.Contains("\r")) { txt_url.Text = txt_url.Text.Replace("\r", String.Empty); }
            if (txt_url.Text.Contains("\t")) { txt_url.Text = txt_url.Text.Replace("\t", String.Empty); }
        }
        private void txt_webgrabOptions_TextChanged(object sender, EventArgs e)
        {
            if (txt_webgrabOptions.Text.Contains("\n")) { txt_webgrabOptions.Text = txt_webgrabOptions.Text.Replace("\n", String.Empty); }
            if (txt_webgrabOptions.Text.Contains("\r")) { txt_webgrabOptions.Text = txt_webgrabOptions.Text.Replace("\r", String.Empty); }
            if (txt_webgrabOptions.Text.Contains("\t")) { txt_webgrabOptions.Text = txt_webgrabOptions.Text.Replace("\t", String.Empty); }
        }

        private void txt_url_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }
        private void txt_url_DragDrop(object sender, DragEventArgs e)
        {
            txt_url.Text = (e.Data.GetData(typeof(string)) as string);
        }

        private void txt_webgrabURL_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }
        private void txt_webgrabURL_DragDrop(object sender, DragEventArgs e)
        {
            txt_webgrabURL.Text = (e.Data.GetData(typeof(string)) as string);
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

        private bool links_ctrl = false;
        private bool links_shift = false;
        private void links_KeyDown(object sender, KeyEventArgs e)
        {
            links_ctrl = e.Control;
            links_shift = e.Control;

            switch (e.KeyCode)
            {
                case Keys.Escape: links.SelectedItems.Clear(); e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Enter: links_downloadSelected();     e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Delete:
                    {
                        if      (e.Control) { links_deleteAll(); }
                        else if (e.Shift)   { links_deleteSome(); }
                        else                { links_delete(); }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;
                    }
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R: links_reload();               e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.W: links_incognito();            e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.C: links_copy();                 e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.X: links_copy(); links_delete(); e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.V: links_paste();                e.Handled = true; e.SuppressKeyPress = true; break;
                }
            }
        }
        private void links_KeyUp(object sender, KeyEventArgs e)
        {
            links_ctrl = false;
            links_shift = false;
        }
        private void links_LostFocus(object sender, System.EventArgs e)
        {
            links_ctrl = false;
            links_shift = false;
        }

        private int links_fontSize_min = 6;
        private int links_fontSize_max = 30;
        private int links_fontSize = 8;
        private void links_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!links_ctrl) { return; }

            int last = links_fontSize;
            if (e.Delta > 0) { links_fontSize += (links_shift ? 6 : 1); }
            else             { links_fontSize -= (links_shift ? 6 : 1); }

            if      (links_fontSize < links_fontSize_min) { links_fontSize = links_fontSize_min; }
            else if (links_fontSize > links_fontSize_max) { links_fontSize = links_fontSize_max; }
            if (links_fontSize == last) { return; }
            
            links.Font = new Font(links.Font.FontFamily, links_fontSize, links.Font.Style);
            links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void links_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (links.SelectedItems.Count == 0)
            {
                txt_filename.ReadOnly = true;
                txt_filename.ForeColor = Color.Teal;
            }
            else
            {
                txt_filename.ReadOnly = false;
                txt_filename.ForeColor = Color.Turquoise;
            }
            
            if (links.SelectedItems.Count > 0)
            {
                txt_filename_dontUpdate = true;
                txt_filename.Text = links.SelectedItems[0].SubItems[1].Text;
                txt_filename_dontUpdate = false;
            }
        }
        
        private void links_DragDrop(object sender, DragEventArgs e)
        {
            string text = e.Data.GetData(typeof(string)) as string;
            string[] links = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (links.Length > 1) { foreach (string line in links) { links_add(line); } }
            else { links_add(text); }
        }
        private void links_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }

        private void btn_dragOutURL_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = string.IsNullOrEmpty(txt_dledURL.Text) ? DragDropEffects.None : DragDropEffects.Copy;
        }
        private void btn_dragOutURL_MouseDown(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_dledURL.Text))
            { this.txt_dledURL.DoDragDrop(new DataObject(DataFormats.StringFormat, txt_dledURL.Text), DragDropEffects.Copy); }
        }

        private void btn_dragOutFilePath_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = string.IsNullOrEmpty(txt_dledPATH.Text) ? DragDropEffects.None : DragDropEffects.Copy;
        }
        private void btn_dragOutFilePath_MouseDown(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_dledPATH.Text))
            { this.txt_dledPATH.DoDragDrop(new DataObject(DataFormats.StringFormat, txt_dledPATH.Text), DragDropEffects.Copy); }
        }

        #endregion

        #region RMB

        private void links_RMB_refresh_Click(object sender, EventArgs e)
        {
            links_reload();
        }
        private void links_RMB_download_Click(object sender, EventArgs e)
        {
            links_downloadSelected();

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
