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

namespace fapmap
{
    public partial class fapmap_download : Form
    {
        //OUR DOWNLOADER
        private WebClient client = new WebClient();
        private bool client_busy = false;
        
        public List<string> links_pass_download = new List<string>();
        public string links_pass_webgrab = string.Empty;
        public string links_pass_youtubedl = string.Empty;

        public fapmap_download()
        {
            InitializeComponent();
            
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit); //cancel
            links_RMB.Renderer = new fapmap_res.color.fToolStripProfessionalRenderer();

            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);
            client.Headers.Add("user-agent", "fapmap.exe");
        }

        private void fapmap_download_Load(object sender, EventArgs e)
        {
            fapmap.fapmap_cd();
            file_location.Text = fapmap.GlobalVariables.Path.Dir.MainFolder + "\\";

            //hide ext
            webgrab_sw();
            youtubedl_sw();

            links.Focus();
            this.ActiveControl = links;

            //download passed links
            if (links_pass_download.Count > 0)
            {
                foreach (string item in links_pass_download)
                {
                    links_add(item);
                }
                
                cb_auto.Checked = true;
                cb_auto_dl.Checked = true;
                //rb_close.Checked = true;

                links_pass_download.Clear();
            }

            if (!string.IsNullOrEmpty(links_pass_webgrab))
            {
                string link = links_pass_webgrab;

                //SET LINK
                webgrab_url.Text = link;
                
                cb_webgrab.Checked = true; //show panel
                WEBGRAB_thread(); //start scanning...

                links_pass_webgrab = string.Empty; //clear passed links
            }

            if (!string.IsNullOrEmpty(links_pass_youtubedl))
            {
                string link = links_pass_youtubedl;

                //SET LINK
                youtubedl_url.Text = link;
                
                cb_youtubedl.Checked = true; //show panel
                YOUTUBEDL_thread();

                links_pass_youtubedl = string.Empty; //clear passed links
            }
        }
        
        #region Notify Icon / Hide Window

        //THE FUNCTION
        private void this_hide()
        {
            if (this.Visible)
            {
                if (client.IsBusy)
                {
                    // //REPLACED WITH DRAW ICON
                    // this.Icon = Properties.Resources.image_icon_download_hidden_busy;
                    // this.SystemTrayIcon.Icon = Properties.Resources.image_icon_download_hidden_busy;
                }
                else
                {
                    this.Icon = Properties.Resources.download_hidden;
                    this.SystemTrayIcon.Icon = Properties.Resources.download_hidden;
                }

                this.Hide();
            }
            else
            {
                this.Show();

                if (client.IsBusy)
                {
                    // //REPLACED WITH DRAW ICON
                    // this.Icon = Properties.Resources.image_icon_download_visible_busy;
                    // this.SystemTrayIcon.Icon = Properties.Resources.image_icon_download_visible_busy;
                }
                else
                {
                    this.Icon = Properties.Resources.download_visible;
                    this.SystemTrayIcon.Icon = Properties.Resources.download_visible;
                }
            }
        }

        #endregion

        #region Graphics And Settings
        
        private void OnProcessExit(object sender, EventArgs e)
        {
            Exitapp();
        }

        private void fapmap_download_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exitapp();
        }
        private void fapmap_download_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exitapp();
        }

        private void Exitapp()
        {
            cb_auto.Checked = false;
            auto.Enabled = false;
            links.Items.Clear();
            client_busy = false;
            SystemTrayIcon.Dispose();
            client.CancelAsync();
            client.Dispose();
            GC.Collect();
        }


        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
        
        #endregion

        #region DOWNLOADER
        
        //DOWNLOAD BUTTON
        private void download_Click(object sender, EventArgs e)
        {
            if (!client_busy)
            {
                wc_download(null);
            }
            else
            {
                client.CancelAsync();
            }
        }

        //DOWNLOAD SELECTED
        private void Links_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                wc_dl_selected();
            }
        }

        private void wc_dl_selected()
        {
            if (!client_busy)
            {
                ListViewItem selected_item = null;
                foreach (ListViewItem item in links.SelectedItems)
                {
                    selected_item = item;
                }
                
                if (selected_item != null)
                {
                    wc_download(selected_item);
                }
            }
        }

        private void update_count(int num)
        {
            links_count.Text = num.ToString();
        }

        //CLEAR INFO
        private void info_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                info.Text = "...";
                info.ForeColor = Color.Teal;
            }
        }

        //CTRL + A on downloading url
        private void DownloadingLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                process_url.Select(0, process_url.TextLength);
            }
        }
        
        
        private void wc_download(ListViewItem listItem)
        {
            if (!client_busy)
            {
                client_busy = true;
                
                info.ForeColor = System.Drawing.Color.Yellow;
                info.Text = "Checking URL...";
                
                if (links.Items.Count > 0)
                {
                    string name = "";
                    string link = "";
                    if (listItem == null)
                    {
                        name = links.Items[0].SubItems[1].Text;
                        link = links.Items[0].SubItems[2].Text;
                    }
                    else
                    {
                        name = listItem.SubItems[1].Text;
                        link = listItem.SubItems[2].Text;
                    }

                    string path = file_location.Text + name;

                    //url == empty
                    if (!string.IsNullOrEmpty(link))
                    {
                        //url == valid
                        if (Uri.IsWellFormedUriString(link, UriKind.Absolute))
                        {
                            //path == empty
                            if (!string.IsNullOrEmpty(path))
                            {
                                bool invalidPath = false;
                                foreach (char ch in System.IO.Path.GetInvalidPathChars())
                                {
                                    if (path.Contains(ch))
                                    {
                                        invalidPath = true;
                                    }
                                }

                                //path == valid
                                if (invalidPath != true)
                                {
                                    int file_manage_mode = 2; //def = new name

                                    if (cb_conflict_replace.Checked == false && cb_conflict_rename.Checked == false && cb_conflict_skip.Checked == false)
                                    {
                                        if (File.Exists(path))
                                        {
                                            DialogResult dialogResult = MessageBox.Show(
                                                "A file with the name " + name + " already exists." + Environment.NewLine
                                                + Environment.NewLine + "YES          = REPLACE"
                                                + Environment.NewLine + "NO          = NEW NAME"
                                                + Environment.NewLine + "CANCEL = SKIP THIS URL",
                                                this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                                                );

                                            if (dialogResult == DialogResult.Yes)
                                            {
                                                file_manage_mode = 1; //REPLACE
                                            }
                                            else if (dialogResult == DialogResult.No)
                                            {
                                                file_manage_mode = 2; //NEW NAME
                                            }
                                            else if (dialogResult == DialogResult.Cancel)
                                            {
                                                file_manage_mode = 3; //CANCEL
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (cb_conflict_replace.Checked)
                                        {
                                            file_manage_mode = 1; //REPLACE
                                        }
                                        else if (cb_conflict_rename.Checked)
                                        {
                                            file_manage_mode = 2; //NEW NAME
                                        }
                                        else if (cb_conflict_skip.Checked)
                                        {
                                            file_manage_mode = 3; //CANCEL
                                        }
                                    }

                                    if (File.Exists(path)) // IF FILE EXISTS
                                    {
                                        if (file_manage_mode == 1)
                                        {
                                            //ECHO EXISTS
                                            info.ForeColor = System.Drawing.Color.Yellow;
                                            info.Text += "File Exists: " + path + Environment.NewLine;

                                            //DELETE FILE
                                            File.Delete(path);

                                            //ECHO REPLACING
                                            info.ForeColor = System.Drawing.Color.Yellow;
                                            info.Text += "Replacing...";
                                        }
                                        else if (file_manage_mode == 2)
                                        {
                                            //ECHO EXISTS
                                            info.ForeColor = System.Drawing.Color.Yellow;
                                            info.Text += "File Exists: " + path + Environment.NewLine;

                                            FileInfo fi = new FileInfo(path);

                                            int c = 1;
                                            path = fi.FullName.Replace(fi.Name, "") + fi.Name.Replace(fi.Extension, "") + " [" + c + "]" + fi.Extension;

                                            while (File.Exists(path))
                                            {
                                                c++;
                                                path = fi.FullName.Replace(fi.Name, "") + fi.Name.Replace(fi.Extension, "") + " [" + c + "]" + fi.Extension;
                                            }

                                            //ECHO NEW NAME
                                            info.ForeColor = System.Drawing.Color.Yellow;
                                            info.Text += "New name: " + path;
                                        }
                                        else if (file_manage_mode == 3)
                                        {
                                            //REMOVE
                                            foreach (ListViewItem item in links.Items)
                                            {
                                                if (item.Tag.ToString() == link)
                                                {
                                                    links.Items.Remove(item);
                                                }
                                            }
                                            links_recount_and_resize(); //recount index

                                            //COUNT
                                            update_count(links.Items.Count);;

                                            //canceld replace
                                            info.ForeColor = System.Drawing.Color.DarkOrchid;
                                            info.Text = "Replacement canceled...";

                                            //cancel
                                            client_busy = false;
                                            links_dl.BackgroundImage = Properties.Resources.close;
                                            return;
                                        }
                                    }

                                    info.ForeColor = System.Drawing.Color.SlateBlue;
                                    info.Text = "Downloading... ";

                                    // //CHANGE ICON
                                    // if (this.Visible)
                                    // {
                                    //     //REPLACED WITH DRAW ICON
                                    //     this.Icon = Properties.Resources.image_icon_download_visible_busy;
                                    //     this.SystemTrayIcon.Icon = Properties.Resources.image_icon_download_visible_busy;
                                    // }
                                    // else
                                    // {
                                    //     //REPLACED WITH DRAW ICON
                                    //     this.Icon = Properties.Resources.image_icon_download_hidden_busy;
                                    //     this.SystemTrayIcon.Icon = Properties.Resources.image_icon_download_hidden_busy;
                                    // }
                                    
                                    //REMOVE
                                    foreach (ListViewItem item in links.Items)
                                    {
                                        if (item.Tag.ToString() == link)
                                        {
                                            links.Items.Remove(item);
                                        }
                                    }
                                    links_recount_and_resize(); //recount index

                                    //COUNT
                                    update_count(links.Items.Count);;
                                    
                                    if (!string.IsNullOrEmpty(file_location.Text))
                                    {
                                        //CREATE ALL FOLDERS
                                        Directory.CreateDirectory(Directory.GetParent(file_location.Text).ToString());
                                        file_location_TextChanged(null, null); //change color of created folder
                                    }

                                    //show speed
                                    speed.Enabled = true;

                                    //CHANGE BUTTON TO CANCL
                                    links_dl.BackgroundImage = Properties.Resources.close; //button change

                                    //UPDATE DOWNLOADING...
                                    process_url.Text = link;
                                    process_location.Text = path;

                                    //LOG IT
                                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.DING, link + " -> " + path);

                                    try
                                    {
                                        //DOWNLOAD
                                        client.DownloadFileAsync(new Uri(link), path);
                                    }
                                    catch (ArgumentException) { info.ForeColor = System.Drawing.Color.DarkOrchid; info.Text = "Argument Exception"; }
                                    catch (WebException e) { info.ForeColor = System.Drawing.Color.DarkOrchid; info.Text = e.Message; }
                                    catch (InvalidOperationException) { info.ForeColor = System.Drawing.Color.DarkOrchid; info.Text = "Invalid Operation Exception"; }
                                    catch (Exception) { info.ForeColor = System.Drawing.Color.DarkOrchid; info.Text = "Unknown Error Occurred"; }

                                    return;
                                }
                                else
                                {
                                    //path not valid
                                    info.ForeColor = System.Drawing.Color.DarkOrchid;
                                    info.Text = "Path not valid!";
                                }
                            }
                            else
                            {
                                //path empty
                                info.ForeColor = System.Drawing.Color.DarkOrchid;
                                info.Text = "Path is empty!";
                            }
                        }
                        else
                        {
                            //url not valid
                            info.ForeColor = System.Drawing.Color.DarkOrchid;
                            info.Text = "URL not valid!";
                        }
                    }
                    else
                    {
                        //url empty
                        info.ForeColor = System.Drawing.Color.DarkOrchid;
                        info.Text = "URL is empty!";
                    }
                }
                else
                {
                    //url empty
                    info.ForeColor = System.Drawing.Color.Yellow;
                    info.Text = "List: empty";
                }

                //failed
                client_busy = false;
                links_dl.BackgroundImage = Properties.Resources.arrow_down;
                return;
            }
        }

        

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //main
            double now = e.BytesReceived;
            double max = e.TotalBytesToReceive;
            int progress = 0;

            speed_bytes = now;
            
            if (max != 0 && now != 0)
            {
                progress = (int)((now / max) * 100);
            }

            string bytesIn_CONVERTED_STRING = fapmap.ROund(now);
            string totalBytes_CONVERTED_STRING = fapmap.ROund(max);
            
            fapmap.draw_progressBar(progress, info_progress, Color.DarkSlateBlue);
            fapmap.draw_progressBar_icon(SystemTrayIcon, progress, this.Visible ? Brushes.MediumSlateBlue : Brushes.RoyalBlue);

            info.ForeColor = System.Drawing.Color.SlateBlue;
            info.Text = progress + "% = " + bytesIn_CONVERTED_STRING + " (" + now + " bytes)" + Environment.NewLine + "100% = " + totalBytes_CONVERTED_STRING + " (" + max + " bytes)";
            SystemTrayIcon.Text = (links.Items.Count + 1).ToString() + ": " + progress.ToString() + "%";
        }

        private double speed_bytes = 0; //passed num from progress
        private double last_bytes = 0;

        private void speed_Tick(object sender, EventArgs e)
        {
            if (!client_busy) //disable if downloader isn't busy...
            {
                speed.Enabled = false;

                speed_bytes = 0;
                last_bytes = 0;
                speed_echo.Text = "";
                return;
            }

            double cur = speed_bytes - last_bytes;

            if (cur > 0)
            {
                speed_echo.Text = fapmap.ROund(cur) + "/sec";
            }

            last_bytes = speed_bytes;
        }
        
        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!client_busy)
            {
                return;
            }
            
            if (!e.Cancelled)
            {
                //LOG IT
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.DLED, process_url.Text + " -> " + process_location.Text);
                
                //SET OPEN BUTTON PATH TOOLTIP
                file_open_location = process_location.Text;
                HelpBalloon.SetToolTip(file_open, process_location.Text);

                info.ForeColor = System.Drawing.Color.Teal;
            }
            else
            {
                info.ForeColor = System.Drawing.Color.DarkOrchid;
                info.Text = "Download Canceled...";
            }
            
            //COUNT
            update_count(links.Items.Count);;
            
            //CHANGE ICON TO NORMAL
            if (this.Visible)
            {
                this.Icon = Properties.Resources.download_visible;
                this.SystemTrayIcon.Icon = Properties.Resources.download_visible;
            }
            else
            {
                this.Icon = Properties.Resources.download_hidden;
                this.SystemTrayIcon.Icon = Properties.Resources.download_hidden;
            }

            fapmap.draw_progressBar(0, info_progress, Color.Transparent); //clear progressbar

            if (links.Items.Count == 0)
            {
                if (cb_uncheckAuto.Checked) { cb_auto.Checked = false; }
            
                if (rb_shutdown.Checked) { shutdown_pc(); System.Environment.Exit(0); }
                if (rb_exit.Checked) { System.Environment.Exit(0); }
                else if (rb_close.Checked) { this.Close(); }
                
            }

            links_dl.BackgroundImage = Properties.Resources.arrow_down;
            client_busy = false;
        }

        private void shutdown_pc()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "shutdown.exe";
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.Arguments = "/s";
            cmd.Start();
        }
        
        private bool IsValidPath(string path)
        {
            System.Text.RegularExpressions.Regex driveCheck = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]:\\$");
            if (!driveCheck.IsMatch(path.Substring(0, 3))) return false;
            string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
            strTheseAreInvalidFileNameChars += @":/?*" + "\"";
            System.Text.RegularExpressions.Regex containsABadCharacter = new System.Text.RegularExpressions.Regex("[" + System.Text.RegularExpressions.Regex.Escape(strTheseAreInvalidFileNameChars) + "]");
            if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
                return false;

            DirectoryInfo dir = new DirectoryInfo(Path.GetFullPath(path));
            if (!dir.Exists)
                dir.Create();
            return true;
        }



        #endregion

        #region CHECK BOXES
        
        #region REPLACE / RENAME / CANCEL

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

        #endregion

        #region Other

        //OPEN BUTTON

        private string file_open_location = string.Empty;
        private void open_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(file_open_location))
            {
                if (File.Exists(file_open_location))
                {
                    Process.Start(file_open_location);
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, file_open_location);
                    return;
                }
            }

            info.ForeColor = System.Drawing.Color.DarkOrchid;
            info.Text = "File Not Found!";
            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file_open_location);
        }
        
        //AUTO DOWNLOADER CHECKBOX
        private void auto_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_auto.Checked)
            {
                auto.Enabled = true;
            }
            else
            {
                auto.Enabled = false;
            }
        }
        
        //new clipboard
        ClipboardAsync clip = new ClipboardAsync();
        string lastdown = "";

        private void auto_Tick(object sender, EventArgs e)
        {
            if (!cb_auto.Checked) { auto.Enabled = false; }
            
            if (cb_auto_clip.Checked)
            {
                if (lastdown != clip.GetText())
                {
                    string clipbrd = clip.GetText(); //get and set clipboard
                    links_url.Text = clipbrd;         //set link from cliboard to textbox
                    links_add(links_url.Text);          //append link if valid
                    lastdown = clipbrd;              //mark as las download
                }
            }

            if (cb_auto_dl.Checked)
            {
                if (!client.IsBusy)
                {
                    wc_download(null); //download
                }
            }
        }


        #endregion

        #region NewClipBoard

        private class ClipboardAsync
        {

            private string _GetText;
            private void _thGetText(object format)
            {
                try
                {
                    if (format == null)
                    {
                        _GetText = Clipboard.GetText();
                    }
                    else
                    {
                        _GetText = Clipboard.GetText((TextDataFormat)format);

                    }
                }
                catch (Exception)
                {
                    //Throw ex 
                    _GetText = string.Empty;
                }
            }
            public string GetText()
            {
                ClipboardAsync instance = new ClipboardAsync();
                Thread staThread = new Thread(instance._thGetText);
                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start();
                staThread.Join();
                return instance._GetText;
            }
            public string GetText(TextDataFormat format)
            {
                ClipboardAsync instance = new ClipboardAsync();
                Thread staThread = new Thread(instance._thGetText);
                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start(format);
                staThread.Join();
                return instance._GetText;
            }

            private bool _ContainsText;
            private void _thContainsText(object format)
            {
                try
                {
                    if (format == null)
                    {
                        _ContainsText = Clipboard.ContainsText();
                    }
                    else
                    {
                        _ContainsText = Clipboard.ContainsText((TextDataFormat)format);
                    }
                }
                catch (Exception)
                {
                    //Throw ex 
                    _ContainsText = false;
                }
            }
            public bool ContainsText()
            {
                ClipboardAsync instance = new ClipboardAsync();
                Thread staThread = new Thread(instance._thContainsFileDropList);
                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start();
                staThread.Join();
                return instance._ContainsText;
            }
            public bool ContainsText(object format)
            {
                ClipboardAsync instance = new ClipboardAsync();
                Thread staThread = new Thread(instance._thContainsFileDropList);
                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start(format);
                staThread.Join();
                return instance._ContainsText;
            }

            private bool _ContainsFileDropList;
            private void _thContainsFileDropList(object format)
            {
                try
                {
                    _ContainsFileDropList = Clipboard.ContainsFileDropList();
                }
                catch (Exception)
                {
                    //Throw ex 
                    _ContainsFileDropList = false;
                }
            }
            public bool ContainsFileDropList()
            {
                ClipboardAsync instance = new ClipboardAsync();
                Thread staThread = new Thread(instance._thContainsFileDropList);
                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start();
                staThread.Join();
                return instance._ContainsFileDropList;
            }

            private System.Collections.Specialized.StringCollection _GetFileDropList;
            private void _thGetFileDropList()
            {
                try
                {
                    _GetFileDropList = Clipboard.GetFileDropList();
                }
                catch (Exception)
                {
                    //Throw ex 
                    _GetFileDropList = null;
                }
            }
            public System.Collections.Specialized.StringCollection GetFileDropList()
            {
                ClipboardAsync instance = new ClipboardAsync();
                Thread staThread = new Thread(instance._thGetFileDropList);
                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start();
                staThread.Join();
                return instance._GetFileDropList;
            }
        }





        #endregion

        #region Link Queue

        private void appendLink_Click(object sender, EventArgs e)
        {
            links_add(links_url.Text);
        }

        private void links_reload()
        {
            List<ListViewItem> items = new List<ListViewItem>();
            foreach (ListViewItem lvi in links.Items)
            {
                items.Add(lvi);
            }
            links.Items.Clear();
            foreach (ListViewItem item in items)
            {
                links.Items.Add(item);
            }
            links_recount_and_resize();
        }

        private void links_recount_and_resize()
        {
            int count = 0;
            foreach (ListViewItem lvi in links.Items)
            {
                count++;
                lvi.SubItems[0].Text = count.ToString();
            }

            //auto resize
            foreach (ColumnHeader column in links.Columns)
            {
                column.Width = -2;
            }
        }

        private void links_add(string link)
        {
            bool dupe = false;

            if (!string.IsNullOrEmpty(link))
            {
                if (Uri.IsWellFormedUriString(link, UriKind.Absolute))
                {
                    bool isFile = false;
                    foreach (string type in fapmap.GlobalVariables.FileTypes.Video)
                    {
                        if (link.Contains(type)) { isFile = true; }
                        if (isFile) { break; }
                    }
                    foreach (string type in fapmap.GlobalVariables.FileTypes.Image)
                    {
                        if (link.Contains(type)) { isFile = true; }
                        if (isFile) { break; }
                    }
                    foreach (string type in fapmap.GlobalVariables.FileTypes.Other)
                    {
                        if (link.Contains(type)) { isFile = true; }
                        if (isFile) { break; }
                    }

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
                    
                    //CHECK IF DUPE
                    foreach (ListViewItem url in links.Items)
                    {
                        if (link == url.Tag.ToString())
                        {
                            dupe = true;
                        }
                    }

                    if (!dupe)
                    {
                        string set_name = fapmap.get_epoch() + ".html";
                        set_name = System.IO.Path.GetFileName(new Uri(link).LocalPath);
                        if (string.IsNullOrEmpty(set_name)) { set_name = fapmap.get_epoch() + ".html"; }

                        ListViewItem lvi = new ListViewItem(new string[] { (links.Items.Count + 1).ToString(), set_name, link }) { Tag = link };
                        links.Items.Add(lvi);

                        //auto resize
                        foreach (ColumnHeader column in links.Columns)
                        {
                            column.Width = -2;
                        }

                        // //SCROLL LISTBOX
                        // int visibleItems = links.ClientSize.Height / links.ItemHeight;
                        // links.TopIndex = Math.Max(links.Items.Count - visibleItems + 1, 0);

                        //SCROOL LISTVIEW
                        links.EnsureVisible(links.Items.Count - 1);

                        //COUNT
                        update_count(links.Items.Count);;
                    }
                    else
                    {
                        info.ForeColor = System.Drawing.Color.DarkOrchid;
                        info.Text = "DUPE: " + link;
                    }
                }
                else
                {
                    info.ForeColor = System.Drawing.Color.DarkOrchid;
                    info.Text = link;
                }
            }
        }

        public class ColoredItemInListbox
        {
            public ColoredItemInListbox(Color c, string m)
            {
                ItemColor = c;
                Message = m;
            }
            public Color ItemColor { get; set; }
            public string Message { get; set; }
        }

        private void linkText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                links_add(links_url.Text);
            }

            //DEL TEXT
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;

                links_url.Text = "";
            }
        }

        private void Links_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 || e.Control && e.KeyCode == Keys.R) { links_reload(); }
            if ((e.KeyCode == Keys.Enter) || (e.Control && e.KeyCode == Keys.W)) { e.SuppressKeyPress = true; wc_dl_selected(); }//ENTER    
            if (e.Control && e.KeyCode == Keys.U) { Incgonitoo(); }
                           
            //DELETE
            if (e.Control && e.KeyCode == Keys.Delete) { rm_all(); }
            else if (e.Shift && e.KeyCode == Keys.Delete) { rm_only(); }
            else if(e.KeyCode == Keys.Delete) { DeleteLink(); }

            if (e.Control && e.KeyCode == Keys.C) { CopySelected(); }               //COPY
            if (e.Control && e.KeyCode == Keys.X) { CopySelected(); DeleteLink(); } //CUT
            if (e.Control && e.KeyCode == Keys.V) { PasteFromClipBoard(); }         //PASTE
        }
        

        private void CopySelected()
        {
            string selected_item = string.Empty;
            foreach (ListViewItem item in links.SelectedItems)
            {
                selected_item = item.Tag.ToString();
            }

            if (!string.IsNullOrEmpty(selected_item))
            {
                System.Windows.Forms.Clipboard.SetText(selected_item);
            }
        }

        private void Incgonitoo()
        {
            string selected_item = string.Empty;
            foreach (ListViewItem item in links.SelectedItems)
            {
                selected_item = item.Tag.ToString();
            }

            if (!string.IsNullOrEmpty(selected_item))
            {
                fapmap.Incognito(selected_item);
            }
        }

        private void PasteFromClipBoard()
        {
            string text = System.Windows.Clipboard.GetText();
            string[] lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            if (lines.Length > 1)
            {
                foreach(string line in lines)
                {
                    links_add(line);
                }
            }
            else
            {
                links_add(text);
            }
        }

        private void DeleteLink()
        {
            foreach (ListViewItem selected_item in links.SelectedItems)
            {
                if (selected_item != null)
                {
                    links.Items.Remove(selected_item);
                    links_recount_and_resize();
                    
                    //COUNT
                    update_count(links.Items.Count);;
                }
            }

            
        }

        private void rm_all()
        {
            DialogResult dr = MessageBox.Show("Remove all (" + links.Items.Count + ") URLs?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            
            if (dr == DialogResult.Yes)
            {
                links.Items.Clear();
            }

            //COUNT
            update_count(links.Items.Count);;
        }

        private void rm_only()
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Remove URLs that contain:", "Remove URLs", "thumb.jpg", -1, -1);

            if (!string.IsNullOrEmpty(input))
            {
                List<ListViewItem> items_for_rming = new List<ListViewItem>();
                foreach (ListViewItem item in links.Items)
                {
                    if (item.Tag.ToString().Contains(input))
                    {
                        items_for_rming.Add(item);
                    }
                }

                if (items_for_rming.Count == 0)
                {
                    MessageBox.Show("No files found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Remove " + items_for_rming.Count + " URLs?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (dr == DialogResult.Yes)
                    {
                        foreach (ListViewItem item in items_for_rming)
                        {
                            links.Items.Remove(item);
                        }
                        links_recount_and_resize();
                    }
                }
            }
            
            //COUNT
            update_count(links.Items.Count);;
        }
        
        private void links_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (links.SelectedItems.Count == 0)
            {
                //UNSELECT
                filename_changeBox.ReadOnly = true;
                filename_changeBox.ForeColor = Color.DarkSlateBlue;
            }
            else
            {
                //SELECT
                filename_changeBox.ReadOnly = false;
                filename_changeBox.ForeColor = Color.SlateBlue;

                foreach (ListViewItem item in links.SelectedItems)
                {
                    links_selected = item;
                    filename_changeBox.Text = item.SubItems[1].Text;
                    break;
                }            }
        }

        private void Links_DragDrop(object sender, DragEventArgs e)
        {
            string stringData = e.Data.GetData(typeof(string)) as string;
            links_add(stringData);
        }

        private void Links_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            links_reload();
        }
        private void copyLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySelected();
        }
        private void cutLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySelected();
            DeleteLink();
        }
        private void pasteFromClipBoardCTRLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteFromClipBoard();
        }
        private void incognitoENTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Incgonitoo();
        }
        private void deleteSelectedLinkDELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteLink();
        }

        private void deleteAllURLsCTRLADELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rm_all();
        }

        private void removeOnlySHIFTDELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rm_only();
        }

        #endregion

        #region WEBGRAB

        private void webgrab_start_Click(object sender, EventArgs e)
        {
            WEBGRAB_thread();
        }
        private void webgrab_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                webgrab_start_Click(null, null);
            }

            //DEL TEXT
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;

                webgrab_url.Text = "";
            }
        }

        private bool WEBGRAB_busy = false;
        private void WEBGRAB_thread()
        {
            if (!WEBGRAB_busy)
            {
                new Thread(WEBGRAB) { IsBackground = true }.Start();
            }
        }
        private void WEBGRAB()
        {
            string this_url = webgrab_url.Text;
            string this_options = webgrab_options.Text;

            if (!WEBGRAB_busy)
            {
                //check shit
                if (string.IsNullOrEmpty(this_url)) { info.ForeColor = System.Drawing.Color.DarkOrchid; info.Text = "No input...";  return; }
                if (!File.Exists(fapmap.GlobalVariables.Path.File.Exe.Webgrab)) { info.ForeColor = System.Drawing.Color.DarkOrchid; info.Text = "webgrab.exe not found..."; fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, fapmap.GlobalVariables.Path.File.Exe.Webgrab); return; }

                WEBGRAB_busy = true;

                info.ForeColor = System.Drawing.Color.Yellow;
                info.Text = "Scanning web page for URLs...";

                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, fapmap.GlobalVariables.Path.File.Exe.Webgrab + " --out \"" + this_url + "\" \"" + this_options + "\"");

                links.BeginUpdate();

                //settings
                Process webgrab = new Process();
                webgrab.StartInfo.FileName = fapmap.GlobalVariables.Path.File.Exe.Webgrab;
                webgrab.StartInfo.Arguments = "--out \"" + this_url + "\" \"" + this_options + "\"";
                if (Directory.Exists(file_location.Text)) { webgrab.StartInfo.WorkingDirectory = file_location.Text; }
                else                                      { webgrab.StartInfo.WorkingDirectory = fapmap.GlobalVariables.Path.Dir.MainFolder; }
                webgrab.StartInfo.UseShellExecute = false;
                webgrab.StartInfo.CreateNoWindow = true;
                webgrab.StartInfo.RedirectStandardOutput = true;
                webgrab.StartInfo.RedirectStandardError = true;
                //output and error (asynchronous) handlers
                webgrab.OutputDataReceived += new DataReceivedEventHandler(WEBGRAB_output);
                webgrab.ErrorDataReceived += new DataReceivedEventHandler(WEBGRAB_output);
                //start and wait
                webgrab.Start();
                webgrab.BeginOutputReadLine();
                webgrab.BeginErrorReadLine();
                webgrab.WaitForExit();
                
                //if application is closed during a scan ... exit
                if (this.IsDisposed)
                {
                    webgrab.Close();
                    WEBGRAB_busy = false;
                    return;
                }

                links.EndUpdate();
                
                info.ForeColor = System.Drawing.Color.Teal;
                info.Text = "...";

                WEBGRAB_busy = false;
            }
        }
        private void WEBGRAB_output(object sendingProcess, DataReceivedEventArgs outLine)
        {
            try
            {
                links_add(outLine.Data);
            }
            catch (Exception) { }
        }

        private void webgrab_options_KeyDown(object sender, KeyEventArgs e)
        {
            //DEL TEXT
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;

                webgrab_options.Text = "";
            }
        }
        
        //HIDE WEBGRAB
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
        private void cb_webgrab_CheckedChanged(object sender, EventArgs e)
        {
            webgrab_sw();
        }

        #endregion

        #region YOUTUBE-DL

        private void youtubedl_start_Click(object sender, EventArgs e)
        {
            YOUTUBEDL_thread();
        }
        private void youtubedl_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                youtubedl_start_Click(null, null);
            }

            //DEL TEXT
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;

                youtubedl_url.Text = "";
            }
        }

        private bool YOUTUBEDL_busy = false;
        private void YOUTUBEDL_thread()
        {
            if (!YOUTUBEDL_busy)
            {
                new Thread(YOUTUBEDL) { IsBackground = true }.Start();
            }
        }
        private void YOUTUBEDL()
        {
            string this_url = youtubedl_url.Text;

            if (!YOUTUBEDL_busy)
            {
                //check shit
                if (string.IsNullOrEmpty(this_url)) { info.ForeColor = System.Drawing.Color.DarkOrchid; info.Text = "No input..."; return; }
                if (!File.Exists(fapmap.GlobalVariables.Path.File.Exe.Youtubedl)) { info.ForeColor = System.Drawing.Color.DarkOrchid; info.Text = "youtube-dl.exe not found..."; fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, fapmap.GlobalVariables.Path.File.Exe.Youtubedl); return; }


                YOUTUBEDL_busy = true;

                info.ForeColor = System.Drawing.Color.Yellow;
                info.Text = "Starting youtube-dl...";
                
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, fapmap.GlobalVariables.Path.File.Exe.Youtubedl + " \"" + this_url + "\" -o \"%(title)s.%(ext)s\"");
                
                //settings
                Process youtubedl = new Process();
                youtubedl.StartInfo.FileName = fapmap.GlobalVariables.Path.File.Exe.Youtubedl;
                youtubedl.StartInfo.Arguments = "\"" + this_url + "\" -o \"%(title)s.%(ext)s\"";
                if (Directory.Exists(file_location.Text)) { youtubedl.StartInfo.WorkingDirectory = file_location.Text; }
                else { youtubedl.StartInfo.WorkingDirectory = fapmap.GlobalVariables.Path.Dir.MainFolder; }
                youtubedl.StartInfo.UseShellExecute = false;
                youtubedl.StartInfo.CreateNoWindow = true;
                youtubedl.StartInfo.RedirectStandardOutput = true;
                youtubedl.StartInfo.RedirectStandardError = true;
                //output and error (asynchronous) handlers
                youtubedl.OutputDataReceived += new DataReceivedEventHandler(YOUTUBEDL_output);
                youtubedl.ErrorDataReceived += new DataReceivedEventHandler(YOUTUBEDL_output);
                //start and wait
                youtubedl.Start();
                youtubedl.BeginOutputReadLine();
                youtubedl.BeginErrorReadLine();
                youtubedl.WaitForExit();

                //if application is closed during a scan ... exit
                if (this.IsDisposed)
                {
                    youtubedl.Close();
                    YOUTUBEDL_busy = false;
                    return;
                }

                //end
                info.ForeColor = System.Drawing.Color.Teal;
                info.Text += Environment.NewLine + this_url;

                //CHANGE ICON TO NORMAL
                if (this.Visible)
                {
                    this.Icon = Properties.Resources.download_visible;
                    this.SystemTrayIcon.Icon = Properties.Resources.download_visible;
                }
                else
                {
                    this.Icon = Properties.Resources.download_hidden;
                    this.SystemTrayIcon.Icon = Properties.Resources.download_hidden;
                }

                fapmap.draw_progressBar(0, info_progress, Color.Transparent); //clear progressbar

                //exit rb
                if (rb_shutdown.Checked) { shutdown_pc(); System.Environment.Exit(0); }
                if (rb_exit.Checked) { System.Environment.Exit(0); }
                else if (rb_close.Checked) { this.Close(); }

                YOUTUBEDL_busy = false;
            }
        }
        private void YOUTUBEDL_output(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (e.Data.Contains("[download]"))
                {
                    info.ForeColor = System.Drawing.Color.SlateBlue;
                    info.Text = e.Data;
                    SystemTrayIcon.Text = e.Data;

                    string str = fapmap.get_string_in_between("[download]", "of", e.Data, false, false).Replace(" ", "").Replace("%", "");
                    if (str.Contains('.')) { str = str.Split('.')[0]; }
                    
                    if (int.TryParse(str, out int progress))
                    {
                        fapmap.draw_progressBar((int)progress, info_progress, Color.DarkSlateBlue);
                        fapmap.draw_progressBar_icon(SystemTrayIcon, (int)progress, this.Visible ? Brushes.MediumSlateBlue : Brushes.RoyalBlue);
                    }
                }
            }
            catch (Exception) { }
        }
        
        //HIDE YOUTUBEDL
        private void youtubedl_sw()
        {
            if (!cb_youtubedl.Checked)
            {
                sc_youtubedl.Panel1.Hide();
                sc_youtubedl.Panel1Collapsed = true;
            }
            else
            {
                sc_youtubedl.Panel1.Show();
                sc_youtubedl.Panel1Collapsed = false;
            }
        }
        private void cb_youtubedl_CheckedChanged(object sender, EventArgs e)
        {
            youtubedl_sw();
        }

        #endregion


        private void file_location_KeyDown(object sender, KeyEventArgs e)
        {
            //DEL TEXT
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            //DEL TEXT
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;

                file_location.Text = fapmap.GlobalVariables.Path.Dir.MainFolder + "\\";
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (string.IsNullOrEmpty(file_location.Text))
                {
                    e.SuppressKeyPress = true;

                    file_location.Text = fapmap.GlobalVariables.Path.Dir.MainFolder + "\\";

                    //select end
                    file_location.SelectionStart = file_location.Text.Length;
                    file_location.SelectionLength = 0;
                }
            }
        }

        private void filename_changeBox_KeyDown(object sender, KeyEventArgs e)
        {
            //DEL TEXT
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                filename_changeBox.ReadOnly = true;
                filename_changeBox.ForeColor = Color.DimGray;
            }

            //DEL TEXT
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;

                filename_changeBox.Text = "";
            }
        }

        private void links_url_DragDrop(object sender, DragEventArgs e)
        {
            string stringData = e.Data.GetData(typeof(string)) as string;
            links_url.Text = stringData;
        }

        private void links_url_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }
        
        private void SystemTrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this_hide();
            }
            else
            {
                this.Close();
            }
        }

        private void file_location_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(file_location.Text))
            {
                file_location.ForeColor = Color.Red;
            }
            else
            {
                file_location.ForeColor = Color.SlateBlue;
            }
        }

        //RENAMING!!!
        ListViewItem links_selected = null;
        private void filename_changeBox_TextChanged(object sender, EventArgs e)
        {
            if (links_selected == null)
            {
                filename_changeBox.ReadOnly = true;
                filename_changeBox.ForeColor = Color.DimGray;
            }
            else
            {
                if (string.IsNullOrEmpty(filename_changeBox.Text))
                {
                    filename_changeBox.Text = System.IO.Path.GetFileName(new Uri(links_selected.Tag.ToString()).LocalPath);
                }
                else
                {
                    links_selected.SubItems[1].Text = filename_changeBox.Text;
                }
            }
        }

        private void process_location_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                process_location.Select(0, process_location.TextLength);
            }
        }

        private void webgrab_url_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("");
            foreach (var line in fapmap.GlobalVariables.Settings.Other.WebGrabTableLines)
            {
                string[] index = line.Split('|');

                if (index.Length == 2)
                {
                    if (ci.CompareInfo.IndexOf(webgrab_url.Text, index[0], System.Globalization.CompareOptions.IgnoreCase) >= 0)
                    {
                        webgrab_options.Text = index[1];
                        break;
                    }
                }
            }
        }
    }
}
