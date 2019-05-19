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

            //BOARDLESS FORM
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        
        private void GalleryInfo_Load(object sender, EventArgs e)
        {
            fapmap.fapmap_cd();

            fapmap.file_export_all();

            //LOAD SETTINGS
            fapmap.settings_load();
            switch (fapmap.GlobalVariables.Settings.WebBrowser.Browser)
            {
                case "firefox.exe": browser_firefox.Checked = true; break;
                case "chrome.exe": browser_chrome.Checked = true; break;
                case "opera.exe": browser_opera.Checked = true; break;
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
            
            load_passwords(pass_list, fapmap.GlobalVariables.Path.File.Password);

            // //GET FILE COUNT/SIZE
            // getAll_Click(null, null);
            
            //SET START WEBSITE
            wb_url.Text = fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL;

            //CLEAR
            count_size.Text = "...";
            count_files.Text = "...";

            //REMOVE TEXTBOX FOCUS
            this.ActiveControl = count_button;
        }

        #region Graphics

        private void hidegallery_rm_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Text = string.Empty;
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            if (btn.Enabled)
            {
                TextRenderer.DrawText(e.Graphics, "UNHIDE", btn.Font, e.ClipRectangle, /*btn.ForeColor*/ Color.Silver, flags);
            }
            else
            {
                TextRenderer.DrawText(e.Graphics, "UNHIDE", btn.Font, e.ClipRectangle, /*btn.ForeColor*/ Color.DimGray, flags);
            }
        }
        
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
                e.Graphics.DrawString(pass_list.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
            catch
            {
            }
        }

        private void passwordsList_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(pass_list.Items[e.Index].ToString(), pass_list.Font, pass_list.Width).Height;
        }

        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
        
        #endregion

        #region Buttons

        //REFRESH
        private void getAll_Click(object sender, EventArgs e)
        {
            new Thread(RefreshThread) {IsBackground = true }.Start();
        }

        private static bool RefreshThread_busy = false;
        private void RefreshThread()
        {
            if (!RefreshThread_busy)
            {
                RefreshThread_busy = true;
                count_button.Enabled = false;
                gallery_panel.Focus();
                this.ActiveControl = gallery_panel;

                count_size.Text = "...";
                count_files.Text = "...";

                info.Text = "Scanning...";
                GetSize();
                CountAll();
                info.Text = "Done!";

                count_button.Enabled = true;
                RefreshThread_busy = false;
            }
        }

        private void credits_Click(object sender, EventArgs e)
        {
            fapmap_credit fc = new fapmap_credit();
            fc.Show();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (File.Exists(fapmap.GlobalVariables.Path.File.Settings))
            {
                Process.Start("notepad.exe", fapmap.GlobalVariables.Path.File.Settings);
            }
        }
        
        #endregion

        #region Gallery Size On Disk

        //SIZE
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

            count_size.Text = FULLSIZE;
            count_size.SelectionStart = 0;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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

        //THREAD
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
                count_files.Text += title + "....: " + total  + Environment.NewLine;
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
            count_files.Text += "> .\\*....: " + Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.TopDirectoryOnly).Length + Environment.NewLine;
            count_files.Text += "> *.*....: " + Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.AllDirectories).Length + Environment.NewLine;
            count_files.Text += "> topdir.: " + System.IO.Directory.GetDirectories(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.TopDirectoryOnly).Length + Environment.NewLine;
            count_files.Text += "> alldir.: " + System.IO.Directory.GetDirectories(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.AllDirectories).Length + Environment.NewLine;
            count_files.Text += Environment.NewLine;
            
            CountAll_print("VIDEO", fapmap.GlobalVariables.FileTypes.Video);
            CountAll_print("IMAGE", fapmap.GlobalVariables.FileTypes.Image);
            CountAll_print("OTHER", fapmap.GlobalVariables.FileTypes.Other);
        }

        #endregion

        #region Browsers
        
        //CHROME
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (browser_chrome.Checked)
            {
                browser_firefox.Checked = false;
                browser_opera.Checked = false;

                //LOAD
                fapmap.ImportBrowser(1);
            }
        }

        //FIREFOX
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (browser_firefox.Checked)
            {
                browser_chrome.Checked = false;
                browser_opera.Checked = false;

                //LOAD
                fapmap.ImportBrowser(2);
            }
        }

        //OPERA
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (browser_opera.Checked)
            {
                browser_chrome.Checked = false;
                browser_firefox.Checked = false;

                //LOAD
                fapmap.ImportBrowser(3);
            }
        }
        
        #endregion

        #region Edit passwords
        
        private void load_passwords(ListBox listBox, string File)
        {
            fapmap.file_export_all();

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

        private void AppendPassword(string str)
        {
            pass_new.Text = "";

            if (!string.IsNullOrEmpty(str))
            {
                using (TextWriter tw = new StreamWriter(fapmap.GlobalVariables.Path.File.Password, true))
                {
                    tw.WriteLine(str);
                }
            }

            //REFRESH
            load_passwords(pass_list, fapmap.GlobalVariables.Path.File.Password);

            int visibleItems = pass_list.ClientSize.Height / pass_list.ItemHeight;
            pass_list.TopIndex = Math.Max(pass_list.Items.Count - visibleItems + 1, 0);
        }

        private void DeletePassword(ListBox lst)
        {
            if (lst.SelectedItem != null)
            {
                string line = null;
                string line_to_delete = lst.SelectedItem.ToString();

                using (StreamReader reader = new StreamReader(fapmap.GlobalVariables.Path.File.Password))
                {
                    using (StreamWriter writer = new StreamWriter(fapmap.GlobalVariables.Path.Dir.Main + "passwords_inuse.dll"))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (String.Compare(line, line_to_delete) == 0)
                                continue;

                            writer.WriteLine(line);
                        }
                    }
                }
                
                File.Replace(fapmap.GlobalVariables.Path.Dir.Main + "passwords_inuse.dll", fapmap.GlobalVariables.Path.File.Password, null);

                load_passwords(pass_list, fapmap.GlobalVariables.Path.File.Password);
            }
        }

        //DELETE PASSWORD
        private void passwordsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (pass_list.SelectedItem.ToString() != null)
            {
                DeletePassword(pass_list);
            }
        }

        //ADD PASSWORD
        private void addPassword_Click(object sender, EventArgs e)
        {
            AppendPassword(pass_new.Text);
        }
        private void newPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                AppendPassword(pass_new.Text);
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
            }
        }


        #endregion

        #region Main Website
        
        private void wb_url_KeyDown(object sender, KeyEventArgs e)
        {
            wb_url.ForeColor = Color.Red;

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                
                if (!Uri.IsWellFormedUriString(wb_url.Text, UriKind.Absolute))
                {
                    wb_url.Text = "https://www.google.com/search?q=" + wb_url.Text.Replace(" ", "+");
                }

                fapmap.settings_edit(
                    fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL_,
                    wb_url.Text
                );

                this.ActiveControl = wb_panel;
                wb_panel.Focus();

                wb_url.ForeColor = Color.Silver;
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
            }
        }
        
        #endregion

        private void cb_hideOnX_CheckedChanged(object sender, EventArgs e)
        { fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.HideOnX_, fapmap.bool_to_string(((CheckBox)sender).Checked)); }
        private void cb_focusHide_CheckedChanged(object sender, EventArgs e)
        { fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.FocusHide_, fapmap.bool_to_string(((CheckBox)sender).Checked)); }
        private void cb_media_CheckedChanged(object sender, EventArgs e)
        { fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers_, fapmap.bool_to_string(((CheckBox)sender).Checked)); }
        private void cb_autoHideMedia_CheckedChanged(object sender, EventArgs e)
        { fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers_, fapmap.bool_to_string(((CheckBox)sender).Checked)); }
        private void cb_autoPlay_CheckedChanged(object sender, EventArgs e)
        { fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer_, fapmap.bool_to_string(((CheckBox)sender).Checked)); }
        private void cb_autoPause_CheckedChanged(object sender, EventArgs e)
        { fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer_, fapmap.bool_to_string(((CheckBox)sender).Checked)); }
        private void cb_trackbar_CheckedChanged(object sender, EventArgs e)
        { fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer_, fapmap.bool_to_string(((CheckBox)sender).Checked)); }
        private void cb_fileDisplay_CheckedChanged(object sender, EventArgs e)
        { fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableFileDisplay_, fapmap.bool_to_string(((CheckBox)sender).Checked)); }
        private void cb_openOutside_CheckedChanged(object sender, EventArgs e)
        { fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap_, fapmap.bool_to_string(((CheckBox)sender).Checked)); }
    }
}
