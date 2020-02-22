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

            cb_hideOnX.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.HideOnX;
            cb_focusHide.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.FocusHide;
            cb_media.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers;
            cb_autoHideMedia.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers;
            cb_autoPlay.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer;
            cb_autoPause.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer;
            cb_trackbar.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer;
            cb_fileDisplay.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.EnableFileDisplay;
            cb_openOutside.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap;
            
            passwords_load(txt_passwds, fapmap.GlobalVariables.Path.File.Password);
            
            //getAll_Click(null, null);
            
            txt_wbURL.Text = fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL;
            
            txt_size.Text = "...";
            txt_count.Text = "...";
            
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

        #region Buttons
        
        private void count_button_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { getInfo(); }
        }
        
        private bool getInfo_busy = false;
        private void getInfo()
        {
            new Thread(getInfo_thread) { IsBackground = true }.Start();
        }
        private void getInfo_thread()
        {
            if (!getInfo_busy)
            {
                btn_getinfo.Enabled = false;
                getInfo_busy = true;
                panel_info.Focus();
                this.ActiveControl = panel_info;

                txt_size.Text = "...";
                txt_count.Text = "...";

                label_info.Text = "Scanning...";
                GetSize();
                CountAll();
                label_info.Text = "Done!";

                getInfo_busy = false;
                btn_getinfo.Enabled = true;
            }
        }

        private void edit_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { fapmap.Open(fapmap.GlobalVariables.Path.File.Settings); }
        }

        #endregion

        #region Gallery Size On Disk

        private static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }
        private void GetSize()
        {
            //GET SIZE
            double SIZE_BYTES = unchecked((double)DirSize(new DirectoryInfo(fapmap.GlobalVariables.Path.Dir.MainFolder)));

            string FULLSIZE = fapmap.ROund(SIZE_BYTES) + " (" + SIZE_BYTES + " bytes" + ")";

            txt_size.Text = FULLSIZE;
            txt_size.SelectionStart = 0;
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
        private void threadGetSize()
        {
            new Thread(GetSize) { IsBackground = true }.Start();
        }

        #endregion

        #region Count Files (Types)

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
                int i = Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.MainFolder, "*" + type, SearchOption.AllDirectories).Length;
                total += i;
                lfc.Add(new FileCount(type, i));
            }

            if (total > 0)
            {
                txt_count.Text += title + "....: " + total  + Environment.NewLine;
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

                    if (cb_noZero.Checked) { if (fc.Count > 0) { txt_count.Text += "> " + fc.Type.Replace(".", "") + dot + ": " + fc.Count + Environment.NewLine; } }
                    else { txt_count.Text += "> " + fc.Type.Replace(".", "") + dot + ": " + fc.Count + Environment.NewLine; }
                }
            }
            txt_count.Text += Environment.NewLine;
        }
        private void CountAll()
        {
            //CLEAR
            txt_count.Text = "";

            txt_count.Text += "TOTAL:" + Environment.NewLine;
            txt_count.Text += "> .\\*....: " + Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.TopDirectoryOnly).Length + Environment.NewLine;
            txt_count.Text += "> *.*....: " + Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.AllDirectories).Length + Environment.NewLine;
            txt_count.Text += "> topdir.: " + System.IO.Directory.GetDirectories(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.TopDirectoryOnly).Length + Environment.NewLine;
            txt_count.Text += "> alldir.: " + System.IO.Directory.GetDirectories(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.AllDirectories).Length + Environment.NewLine;
            txt_count.Text += Environment.NewLine;
            
            CountAll_print("VIDEO", fapmap.GlobalVariables.FileTypes.Video);
            CountAll_print("IMAGE", fapmap.GlobalVariables.FileTypes.Image);
            CountAll_print("OTHER", fapmap.GlobalVariables.FileTypes.Other);
        }

        #endregion

        #region Browsers

        private void rb_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if      (rb_firefox.Checked) { fapmap.settings_edit_browser(0); }
                else if (rb_chrome.Checked)  { fapmap.settings_edit_browser(1); }
                else if (rb_opera.Checked)   { fapmap.settings_edit_browser(2); }
            }
        }

        #endregion

        #region Edit passwords

        private void passwords_load(ListBox listBox, string File)
        {
            fapmap.nestFiles();

            //CLEAR SELECTION
            listBox.SelectedItem = null;

            //CLEAR PASSWORDS
            listBox.Items.Clear();

            //VARS
            int count = 0;
            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(File);
            while ((line = file.ReadLine()) != null)
            {
                if (!line.Contains("#"))
                {
                    listBox.Items.Add(line);
                }

                count++;
            }

            file.Close();
            file.Dispose();

            System.IO.StreamReader checkifnull = new System.IO.StreamReader(File);

            if ((line = checkifnull.ReadLine()) == null)
            {
                listBox.Items.Clear();
            }

            checkifnull.Close();
            checkifnull.Dispose();
        }
        private void passwords_append(string str)
        {
            txt_newPasswd.Text = "";

            if (!string.IsNullOrEmpty(str))
            {
                using (TextWriter tw = new StreamWriter(fapmap.GlobalVariables.Path.File.Password, true))
                {
                    tw.WriteLine(str);
                }
            }

            //REFRESH
            passwords_load(txt_passwds, fapmap.GlobalVariables.Path.File.Password);

            int visibleItems = txt_passwds.ClientSize.Height / txt_passwds.ItemHeight;
            txt_passwds.TopIndex = Math.Max(txt_passwds.Items.Count - visibleItems + 1, 0);
        }
        private void passwords_delete(ListBox lst)
        {
            if (lst.SelectedItem != null)
            {
                string line = null;
                string line_to_delete = lst.SelectedItem.ToString();

                using (StreamReader reader = new StreamReader(fapmap.GlobalVariables.Path.File.Password))
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
                
                File.Replace(fapmap.GlobalVariables.Path.Dir.Main + "\\passwords_inuse.dll", fapmap.GlobalVariables.Path.File.Password, null);

                passwords_load(txt_passwds, fapmap.GlobalVariables.Path.File.Password);
            }
        }
        private void passwordsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txt_passwds.SelectedItem.ToString() != null)
            {
                passwords_delete(txt_passwds);
            }
        }

        private void pass_add_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { passwords_append(txt_newPasswd.Text); }
        }
        private void newPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                passwords_append(txt_newPasswd.Text);
            }

            if (e.Control && e.KeyCode == Keys.Back) { e.Handled = true; e.SuppressKeyPress = true; }
        }
        
        #endregion

        #region Main Website
        
        private void wb_url_KeyDown(object sender, KeyEventArgs e)
        {
            txt_wbURL.ForeColor = Color.Red;

            if (e.KeyCode == Keys.Enter)
            {
                if (!Uri.IsWellFormedUriString(txt_wbURL.Text, UriKind.Absolute))
                {
                    txt_wbURL.Text = "https://duckduckgo.com/?q=" + txt_wbURL.Text.Replace(" ", "+");
                }

                fapmap.settings_edit(
                    fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL_,
                    txt_wbURL.Text
                );

                this.ActiveControl = panel_wb;
                panel_wb.Focus();

                txt_wbURL.ForeColor = Color.MediumSlateBlue;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
            }
        }

        #endregion

        #region Checkboxes

        private void cb_checkChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            switch (cb.Tag.ToString())
            {
                case "HIDEONX":           fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.HideOnX_,                    fapmap.bool_to_string(cb.Checked)); break;
                case "FOCUSHIDE":         fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.FocusHide_,                  fapmap.bool_to_string(cb.Checked)); break;
                case "ENABLEPLAYERS":     fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers_,         fapmap.bool_to_string(cb.Checked)); break;
                case "AUTOHIDE":          fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers_,       fapmap.bool_to_string(cb.Checked)); break;
                case "AUTOPLAY":          fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer_,        fapmap.bool_to_string(cb.Checked)); break;
                case "AUTOPAUSE":         fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer_,       fapmap.bool_to_string(cb.Checked)); break;
                case "ENABLETRACKBAR":    fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer_, fapmap.bool_to_string(cb.Checked)); break;
                case "ENABLEFILEDISPLAY": fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableFileDisplay_,          fapmap.bool_to_string(cb.Checked)); break;
                case "ENABLEOUTSIDE":     fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap_,    fapmap.bool_to_string(cb.Checked)); break;
            }
        }



        #endregion

        
    }
}
