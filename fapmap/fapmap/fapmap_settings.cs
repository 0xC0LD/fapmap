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
using System.Diagnostics;
using System.Globalization;

namespace fapmap
{
    public partial class fapmap_settings : Form
    {
        public fapmap_settings()
        {
            InitializeComponent();

            txt_output_RMB.Renderer = new fapmap_res.FapMapColors.FapMapToolStripRenderer(Color.SkyBlue);
        }
        
        private void fapmap_settings_Load(object sender, EventArgs e)
        {
            fapmap.nestFiles();
            
            fapmap.settings_load();
            switch (fapmap.GlobalVariables.Settings.WebBrowser.Browser)
            {
                case "firefox.exe": rb_firefox.Checked = true; break;
                case "chrome.exe":  rb_chrome.Checked = true;  break;
                case "opera.exe":   rb_opera.Checked = true;   break;
            }

            //===
            disableChangeSetting = true;

            cb_hideOnX.Checked   = fapmap.GlobalVariables.Settings.CheckBoxes.HideOnX;
            cb_focusHide.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.FocusHide;

            cb_logs.Checked        = fapmap.GlobalVariables.Settings.CheckBoxes.EnableLogs;
            cb_media.Checked       = fapmap.GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers;
            cb_trackbar.Checked    = fapmap.GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer;
            cb_fileDisplay.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.EnableFileDisplay;
            cb_faftv.Checked       = fapmap.GlobalVariables.Settings.CheckBoxes.EnableFaftv;
            cb_openOutside.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap;

            cb_autoHideMedia.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers;
            cb_autoPlay.Checked      = fapmap.GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer;
            cb_autoPause.Checked     = fapmap.GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer;

            cb_tvSortByDate.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.TreeViewSortByCreationDate;
            cb_tvIndex.Checked      = fapmap.GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex;

            cb_fdSortByDate.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.FileDisplaySortByCreationDate;
            cb_fdThumb.Checked      = fapmap.GlobalVariables.Settings.CheckBoxes.FileDisplayShowThumbnails;

            cb_urlTitle.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.LinksGetSiteTitle;

            cb_dlAutoClose.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.DownloaderAutoClose;
            
            txt_wbURL.Text = fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL;
            txt_gifDelay.Text = fapmap.GlobalVariables.Settings.Media.GifDelay.ToString();

            string videoTypes = "";
            foreach (string type in fapmap.GlobalVariables.Settings.Media.FileTypes.Video)
            { videoTypes += type == fapmap.GlobalVariables.Settings.Media.FileTypes.Video.Last() ? type : type + ","; }
            txt_videoTypes.Text = videoTypes;

            string imageTypes = "";
            foreach (string type in fapmap.GlobalVariables.Settings.Media.FileTypes.Image)
            { imageTypes += type == fapmap.GlobalVariables.Settings.Media.FileTypes.Image.Last() ? type : type + ","; }
            txt_imageTypes.Text = imageTypes;

            disableChangeSetting = false;
            //===

            passwords_load();

            txt_size.Text = "...";
            txt_output.Text = "...";
            label_outputThumb.Text = "...";

            //getInfo();
            //getThumbInfo();
            //getCacheSize();

            this.ActiveControl = btn_getinfo;
        }

        #region Graphics
        
        private void passwordsList_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    e = new DrawItemEventArgs(e.Graphics,
                                              e.Font,
                                              e.Bounds,
                                              e.Index,
                                              e.State ^ DrawItemState.Selected,
                                              Color.MediumPurple,
                                              Color.Indigo); //Choose the color

                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(txt_passwds.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
            catch
            {
            }
        }
        private void passwordsList_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(txt_passwds.Items[e.Index].ToString(), txt_passwds.Font, txt_passwds.Width).Height;
        }

        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        #endregion

        #region Get Info

        private void btn_getinfo_Click(object sender, EventArgs e)
        {
            getInfo();
        }
        
        private bool getInfo_busy = false;
        private void getInfo()
        {
            if (getInfo_busy) { return; }

            new Thread(() =>
            {
                getInfo_busy = true;

                try
                {
                    // check dir
                    if (!Directory.Exists(fapmap.GlobalVariables.Path.Dir.MainFolder))
                    { Directory.CreateDirectory(fapmap.GlobalVariables.Path.Dir.MainFolder); }
                    DirectoryInfo di = new DirectoryInfo(fapmap.GlobalVariables.Path.Dir.MainFolder);

                    this.Invoke((MethodInvoker)delegate
                    {
                        txt_size.Text = "";
                        txt_output.Text = "";
                        label_info_status.Text = "Scanning...";
                    });

                    /*
                    ** GET GALLERY SIZE
                    */
                    double SIZE_BYTES = unchecked((double)fapmap.DirSize(di));
                    string FULLSIZE = fapmap.ROund(SIZE_BYTES) + " (" + SIZE_BYTES + " bytes" + ")";

                    this.Invoke((MethodInvoker)delegate
                    {
                        txt_size.Text = FULLSIZE;
                        txt_size.SelectionStart = 0;
                    });

                    /*
                    ** GET FILE COUNT
                    */
                    FileInfo[] TopFiles = di.GetFiles("*.*", SearchOption.TopDirectoryOnly);
                    FileInfo[] AllFiles = di.GetFiles("*.*", SearchOption.AllDirectories);
                    DirectoryInfo[] TopDirs = di.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
                    DirectoryInfo[] AllDirs = di.GetDirectories("*.*", SearchOption.AllDirectories);

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

                    this.Invoke((MethodInvoker)delegate
                    {
                        label_info_status.Text = "Done!";
                    });
                }
                catch (Exception) { }

                getInfo_busy = false;
            })
            { IsBackground = true }.Start();
        }
        private void gallerySize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
            }

            if (e.KeyCode == Keys.Back && e.Control)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txt_output_RMB_copy_Click(object sender, EventArgs e)
        {
            string text = txt_output.SelectedText;
            if (!string.IsNullOrEmpty(text)) { Clipboard.SetText(text); }
        }

        #endregion

        #region Browsers

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton cb = (RadioButton)sender;
            cb.ForeColor = cb.Checked ? Color.LightSkyBlue : Color.MediumPurple;

            if       (rb_firefox.Checked) { fapmap.settings_edit_browser(0); }
            else if (rb_chrome.Checked)   { fapmap.settings_edit_browser(1); }
            else if (rb_opera.Checked)    { fapmap.settings_edit_browser(2); }
        }

        #endregion

        #region Edit passwords
        
        private void btn_addPasswd_Click(object sender, EventArgs e)
        {
            passwords_append(txt_newPasswd.Text);
        }

        private void passwords_load()
        {
            fapmap.nestFiles();

            //CLEAR SELECTION
            txt_passwds.SelectedItem = null;

            //CLEAR PASSWORDS
            txt_passwds.Items.Clear();

            //VARS
            int count = 0;
            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(fapmap.GlobalVariables.Path.File.Passwords);
            while ((line = file.ReadLine()) != null)
            {
                if (!line.Contains("#")) { txt_passwds.Items.Add(line); }
                count++;
            }

            file.Close();
            file.Dispose();

            System.IO.StreamReader checkifnull = new System.IO.StreamReader(fapmap.GlobalVariables.Path.File.Passwords);
            if ((line = checkifnull.ReadLine()) == null) { txt_passwds.Items.Clear(); }
            checkifnull.Close();
            checkifnull.Dispose();
        }
        private void passwords_append(string str)
        {
            txt_newPasswd.Text = "";

            if (!string.IsNullOrEmpty(str))
            {
                using (TextWriter tw = new StreamWriter(fapmap.GlobalVariables.Path.File.Passwords, true))
                {
                    tw.WriteLine(str);
                }
            }
            
            passwords_load();

            int visibleItems = txt_passwds.ClientSize.Height / txt_passwds.ItemHeight;
            txt_passwds.TopIndex = Math.Max(txt_passwds.Items.Count - visibleItems + 1, 0);
        }
        private void passwords_delete()
        {
            if (txt_passwds.SelectedItem == null) { return; }
            if (string.IsNullOrEmpty(txt_passwds.SelectedItem.ToString())) { return; }

            string line = null;
            string line_to_delete = txt_passwds.SelectedItem.ToString();

            using (StreamReader reader = new StreamReader(fapmap.GlobalVariables.Path.File.Passwords))
            {
                using (StreamWriter writer = new StreamWriter(fapmap.GlobalVariables.Path.Dir.Main + "\\passwords_inuse.dll"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (String.Compare(line, line_to_delete) == 0)
                            continue;

                        writer.WriteLine(line);
                    }
                }
            }

            File.Replace(fapmap.GlobalVariables.Path.Dir.Main + "\\passwords_inuse.dll", fapmap.GlobalVariables.Path.File.Passwords, null);

            passwords_load();
        }
        private void passwordsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            passwords_delete();
        }

        private void txt_passwds_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Space: passwords_delete(); e.Handled = true; e.SuppressKeyPress = true; break;
            }
        }

        private void newPassword_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter: passwords_append(txt_newPasswd.Text); e.Handled = true; e.SuppressKeyPress = true; break;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Back: e.Handled = true; e.SuppressKeyPress = true; break;
                }
            }
        }

        #endregion

        #region Text Settings


        private void settingApply_wbURL()
        {
            if (string.IsNullOrEmpty(txt_wbURL.Text)) { txt_wbURL.Text = fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL; }

            if (!Uri.IsWellFormedUriString(txt_wbURL.Text, UriKind.Absolute))
            {
                txt_wbURL.Text = "https://duckduckgo.com/?q=" + txt_wbURL.Text.Replace(" ", "+");
            }

            fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL = txt_wbURL.Text;
            fapmap.settings_edit(
                fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL_,
                txt_wbURL.Text
            );

            txt_wbURL.ForeColor = Color.DeepPink;
        }
        private void settingApply_gifDelay()
        {
            if (!int.TryParse(txt_gifDelay.Text, out int output)) { output = 50; }
            if (output < 5) { output = 5; }
            if (output > 1000) { output = 1000; }

            txt_gifDelay.Text = output.ToString();

            fapmap.GlobalVariables.Settings.Media.GifDelay = output;
            fapmap.settings_edit(
                fapmap.GlobalVariables.Settings.Media.GifDelay_,
                txt_gifDelay.Text
            );

            txt_gifDelay.ForeColor = Color.DeepPink;
        }
        private void settingApply_videoTypes()
        {
            string text = txt_videoTypes.Text.Replace("*", "");

            if (string.IsNullOrEmpty(text))
            {
                foreach (string type in fapmap.GlobalVariables.FileTypes.Video)
                {
                    text += type == fapmap.GlobalVariables.FileTypes.Video.Last() ? type : type + ",";
                }

                txt_videoTypes.Text = text;
            }

            string[] types = text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            fapmap.GlobalVariables.Settings.Media.FileTypes.Video = types.ToList();

            fapmap.settings_edit(
                fapmap.GlobalVariables.Settings.Media.FileTypes.Video_,
                text
            );

            txt_videoTypes.ForeColor = Color.DeepPink;
        }
        private void settingApply_imageTypes()
        {
            string text = txt_imageTypes.Text.Replace("*", "");

            if (string.IsNullOrEmpty(text))
            {
                foreach (string type in fapmap.GlobalVariables.FileTypes.Image)
                {
                    text += type == fapmap.GlobalVariables.FileTypes.Image.Last() ? type : type + ",";
                }

                txt_imageTypes.Text = text;
            }

            string[] types = text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            fapmap.GlobalVariables.Settings.Media.FileTypes.Image = types.ToList();

            fapmap.settings_edit(
                fapmap.GlobalVariables.Settings.Media.FileTypes.Image_,
                text
            );

            txt_imageTypes.ForeColor = Color.DeepPink;
        }

        private void label_wb_Click(object sender, EventArgs e)
        {
            settingApply_wbURL();
        }
        private void label_gifDelay_Click(object sender, EventArgs e)
        {
            settingApply_gifDelay();
        }
        private void label_videoTypes_Click(object sender, EventArgs e)
        {
            settingApply_videoTypes();
        }
        private void label_imageTypes_Click(object sender, EventArgs e)
        {
            settingApply_imageTypes();
        }

        private void txt_wbURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                settingApply_wbURL();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_gifDelay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                settingApply_gifDelay();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_videoTypes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                settingApply_videoTypes();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_imageTypes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                settingApply_imageTypes();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_wbURL_TextChanged(object sender, EventArgs e)
        {
            if (disableChangeSetting) { return; }
            txt_wbURL.ForeColor = Color.PaleVioletRed;
        }
        private void txt_gifDelay_TextChanged(object sender, EventArgs e)
        {
            if (disableChangeSetting) { return; }
            txt_gifDelay.ForeColor = Color.PaleVioletRed;
        }
        private void txt_videoTypes_TextChanged(object sender, EventArgs e)
        {
            if (disableChangeSetting) { return; }
            txt_videoTypes.ForeColor = Color.PaleVioletRed;
        }
        private void txt_imageTypes_TextChanged(object sender, EventArgs e)
        {
            if (disableChangeSetting) { return; }
            txt_imageTypes.ForeColor = Color.PaleVioletRed;
        }

        #endregion

        #region Checkboxes

        private bool disableChangeSetting = false;
        private void cb_checkChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            cb.ForeColor = cb.Checked ? Color.SkyBlue : Color.RoyalBlue;

            if (disableChangeSetting) { return; }

            switch (cb.Tag.ToString())
            {
                case "HIDEONX":   fapmap.GlobalVariables.Settings.CheckBoxes.HideOnX         = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.HideOnX_,         fapmap.bool_to_string(cb.Checked)); break;
                case "FOCUSHIDE": fapmap.GlobalVariables.Settings.CheckBoxes.FocusHide       = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.FocusHide_,       fapmap.bool_to_string(cb.Checked)); break;
                case "INVISIBLE": fapmap.GlobalVariables.Settings.CheckBoxes.InvisibleWindow = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.InvisibleWindow_, fapmap.bool_to_string(cb.Checked)); break;

                case "ENABLEPLAYERS":     fapmap.GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers         = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers_,         fapmap.bool_to_string(cb.Checked)); break;
                case "ENABLELOGS":        fapmap.GlobalVariables.Settings.CheckBoxes.EnableLogs                 = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableLogs_,                 fapmap.bool_to_string(cb.Checked)); break;
                case "ENABLETRACKBAR":    fapmap.GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer_, fapmap.bool_to_string(cb.Checked)); break;
                case "ENABLEFILEDISPLAY": fapmap.GlobalVariables.Settings.CheckBoxes.EnableFileDisplay          = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableFileDisplay_,          fapmap.bool_to_string(cb.Checked)); break;
                case "ENABLEFAFTV":       fapmap.GlobalVariables.Settings.CheckBoxes.EnableFaftv                = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableFaftv_,                fapmap.bool_to_string(cb.Checked)); break;
                case "ENABLEOUTSIDE":     fapmap.GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap    = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap_,    fapmap.bool_to_string(cb.Checked)); break;

                case "AUTOHIDE":  fapmap.GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers_, fapmap.bool_to_string(cb.Checked)); break;
                case "AUTOPLAY":  fapmap.GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer  = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer_,  fapmap.bool_to_string(cb.Checked)); break;
                case "AUTOPAUSE": fapmap.GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer_, fapmap.bool_to_string(cb.Checked)); break;

                case "TVSORT":  fapmap.GlobalVariables.Settings.CheckBoxes.TreeViewSortByCreationDate = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.TreeViewSortByCreationDate_, fapmap.bool_to_string(cb.Checked)); break;
                case "TVINDEX": fapmap.GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex      = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex_,      fapmap.bool_to_string(cb.Checked)); break;

                case "FDSORT":  fapmap.GlobalVariables.Settings.CheckBoxes.FileDisplaySortByCreationDate = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.FileDisplaySortByCreationDate_, fapmap.bool_to_string(cb.Checked)); break;
                case "FDTHUMB": fapmap.GlobalVariables.Settings.CheckBoxes.FileDisplayShowThumbnails     = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.FileDisplayShowThumbnails_,     fapmap.bool_to_string(cb.Checked)); break;

                case "URLTITLE": fapmap.GlobalVariables.Settings.CheckBoxes.LinksGetSiteTitle = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.LinksGetSiteTitle_, fapmap.bool_to_string(cb.Checked)); break;

                case "DLCLOSE": fapmap.GlobalVariables.Settings.CheckBoxes.DownloaderAutoClose           = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.DownloaderAutoClose_,           fapmap.bool_to_string(cb.Checked)); break;
            }
        }

        private void btn_editINI_Click(object sender, EventArgs e)
        {
            fapmap.Open(fapmap.GlobalVariables.Path.File.Settings);
        }

        #endregion

        #region hide files/dirs

        private bool gallery_hide_busy = false;
        private void gallery_hide(int mode, object sender)
        {
            if (gallery_hide_busy) { return; }

            string args = string.Empty;
            switch (mode)
            {
                case 0: args = "-s -h /d /s"; break;
                case 1: args = "-s +h /d /s"; break;
                case 2: args = "+s +h /d /s"; break;
            }

            if (!string.IsNullOrEmpty(args))
            {
                new Thread(() =>
                {
                    gallery_hide_busy = true;

                    Button btn = (Button)sender;
                    string backup = btn.Text;
                    btn.Text = "...";
                    fapmap.attrib(args);
                    btn.Text = backup;

                    gallery_hide_busy = false;
                })
                { IsBackground = true }.Start();
            }
        }

        private void hide_none_Click(object sender, EventArgs e)
        {
            gallery_hide(0, sender);
        }
        private void hide_normal_Click(object sender, EventArgs e)
        {
            gallery_hide(1, sender);
        }
        private void hide_full_Click(object sender, EventArgs e)
        {
            gallery_hide(2, sender);
        }

        #endregion

        #region cache

        private void btn_getCacheSize_Click(object sender, EventArgs e)
        {
            getCacheSize();
        }
        private void btn_delCache_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(fapmap.GlobalVariables.Path.Dir.Cache)) { return; }

            if (MessageBox.Show("Delete cache?", "FapMap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Directory.Delete(fapmap.GlobalVariables.Path.Dir.Cache, true);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                fapmap.nestFiles();
                getCacheSize();
                getThumbInfo();
            }
        }

        private bool getCacheSize_busy = false;
        private void getCacheSize()
        {
            if (getCacheSize_busy) { return; }

            // check dir
            if (!Directory.Exists(fapmap.GlobalVariables.Path.Dir.Cache))
            {
                label_cacheSize.Text = "SIZE:" + Environment.NewLine + "0";
                return;
            }

            label_cacheSize.Text = "...";

            new Thread(() =>
            {
                getThumbInfo_busy = true;

                try
                {
                    long size = fapmap.DirSize(new DirectoryInfo(fapmap.GlobalVariables.Path.Dir.Cache));

                    this.Invoke((MethodInvoker)delegate
                    {
                        label_cacheSize.Text = "SIZE:" + Environment.NewLine + fapmap.ROund(size) + " (" + size + " bytes" + ")";
                    });
                }
                catch (Exception) { }

                getThumbInfo_busy = false;
            })
            { IsBackground = true }.Start();
        }

        private bool getThumbInfo_busy = false;
        private void getThumbInfo()
        {
            if (getThumbInfo_busy) { return; }
            
            // check dir
            if (!Directory.Exists(fapmap.GlobalVariables.Path.Dir.Cache)) { return; }
            if (!Directory.Exists(fapmap.GlobalVariables.Path.Dir.MainFolder)) { return; }

            label_outputThumb.Text = "Loading...";

            new Thread(() =>
            {
                getThumbInfo_busy = true;

                try
                {
                    // get videos
                    FileInfo[] AllFiles = new DirectoryInfo(fapmap.GlobalVariables.Path.Dir.MainFolder)
                    .GetFiles("*.*", SearchOption.AllDirectories);
                    List<FileInfo> videos = new List<FileInfo>();
                    foreach (FileInfo file in AllFiles)
                    {
                        if (fapmap.GlobalVariables.FileTypes.Video.Contains
                        (file.Extension.ToLower()))
                        { videos.Add(file); }
                    }

                    int found = 0;
                    int missing = 0;
                    getThumbInfo_print(videos.Count, found, missing);
                    foreach (FileInfo video in videos)
                    {
                        string id = fapmap.getFileId(video).ToString();
                        string dest = fapmap.GlobalVariables.Path.Dir.Cache + "\\" + id + ".tmp";
                        if (File.Exists(dest)) { found++; } else { missing++; }
                        getThumbInfo_print(videos.Count, found, missing);
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        label_outputThumb.Text += "Done!";
                    });
                }
                catch (Exception) { }

                getThumbInfo_busy = false;
            })
            { IsBackground = true }.Start();
        }
        private void getThumbInfo_print(int vids, int found, int missing)
        {
            this.Invoke((MethodInvoker)delegate
            {
                label_outputThumb.Text = "Searching..." + Environment.NewLine +
                                         "Videos........: " + vids + Environment.NewLine +
                                         "Thumbs found..: " + found + Environment.NewLine +
                                         "Thumbs missing: " + missing + Environment.NewLine;

            });
        }
        private void btn_getThumbInfo_Click(object sender, EventArgs e)
        {
            getThumbInfo();
        }

        private bool getThumbs_busy = false;
        private void getThumbs()
        {
            if (getThumbs_busy) { return; }
            
            if (!fapmap.checkForApp(fapmap.GlobalVariables.Path.File.Exe.FFMPEG, "https://ffmpeg.zeranoe.com/builds/")) { return; }

            // check dir
            if (!Directory.Exists(fapmap.GlobalVariables.Path.Dir.Cache)) { return; }
            if (!Directory.Exists(fapmap.GlobalVariables.Path.Dir.MainFolder)) { return; }

            label_outputThumb.Text = "...";
            
            new Thread(() =>
            {
                getThumbs_busy = true;

                try
                {
                    label_outputThumb.Text = "Working..." + Environment.NewLine;

                    // get videos
                    FileInfo[] AllFiles = new DirectoryInfo(fapmap.GlobalVariables.Path.Dir.MainFolder)
                    .GetFiles("*.*", SearchOption.AllDirectories);
                    List<FileInfo> videos = new List<FileInfo>();
                    foreach (FileInfo file in AllFiles)
                    {
                        if (fapmap.GlobalVariables.FileTypes.Video.Contains
                        (file.Extension.ToLower()))
                        { videos.Add(file); }
                    }
                    
                    int count = 0;
                    int failed = 0;
                    int skipped = 0;
                    foreach (FileInfo video in videos)
                    {
                        string id = fapmap.getFileId(video).ToString();
                        string dest = fapmap.GlobalVariables.Path.Dir.Cache + "\\" + id + ".tmp";
                        if (File.Exists(dest)) { skipped++; }
                        else
                        {
                            if (fapmap.makeThumb(video.FullName, dest)) { count++; } else { failed++; }
                        }

                        this.Invoke((MethodInvoker)delegate
                        {
                            label_outputThumb.Text =
                            "Videos.....: " + videos.Count + Environment.NewLine +
                            "Made thumbs: " + count        + Environment.NewLine +
                            "Thumb found: " + skipped      + Environment.NewLine + 
                            "Failed.....: " + failed       + Environment.NewLine;

                        });
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        label_outputThumb.Text += "Done!";
                    });
                }
                catch (Exception) { }

                getCacheSize();

                getThumbs_busy = false;
            })
            { IsBackground = true }.Start();
        }
        private void btn_getThumbs_Click(object sender, EventArgs e)
        {
            getThumbs();
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "When you browse video files in the file display,"                        + Environment.NewLine +
            "fapmap creates thumbnails for them using ffmpeg..."                      + Environment.NewLine +
            "Thumbnails are used to preview video files in: properties, finder, etc." + Environment.NewLine
            , "Search Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        #endregion

        
    }
}
