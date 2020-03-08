﻿using System;
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

            cb_hideOnX.Checked   = fapmap.GlobalVariables.Settings.CheckBoxes.HideOnX;
            cb_focusHide.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.FocusHide;

            cb_logs.Checked        = fapmap.GlobalVariables.Settings.CheckBoxes.EnableLogs;
            cb_media.Checked       = fapmap.GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers;
            cb_trackbar.Checked    = fapmap.GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer;
            cb_fileDisplay.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.EnableFileDisplay;
            cb_openOutside.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap;

            cb_autoHideMedia.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers;
            cb_autoPlay.Checked      = fapmap.GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer;
            cb_autoPause.Checked     = fapmap.GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer;

            cb_tvSortByDate.Checked = fapmap.GlobalVariables.Settings.CheckBoxes.TreeViewSortByCreationDate;
            cb_tvIndex.Checked      = fapmap.GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex;

            passwords_load(txt_passwds, fapmap.GlobalVariables.Path.File.Password);
            
            txt_wbURL.Text = fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL;
            txt_wbURL.ForeColor = Color.MediumSlateBlue;

            txt_gifDelay.Text = fapmap.GlobalVariables.Settings.Media.GifDelay.ToString();
            txt_gifDelay.ForeColor = Color.MediumSlateBlue;

            txt_size.Text = "...";
            txt_output.Text = "...";
            
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

        private void btn_getinfo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { getInfo(); }
        }

        private bool getInfo_busy = false;
        private void getInfo()
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

                    // check dir
                    if (!Directory.Exists(fapmap.GlobalVariables.Path.Dir.MainFolder))
                    { Directory.CreateDirectory(fapmap.GlobalVariables.Path.Dir.MainFolder); }
                    DirectoryInfo di = new DirectoryInfo(fapmap.GlobalVariables.Path.Dir.MainFolder);

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

                    this.Invoke((MethodInvoker)delegate
                    {
                        label_info.Text = "Done!";
                    });

                    getInfo_busy = false;
                }
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
        
        #endregion

        #region Browsers
        
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton cb = (RadioButton)sender;
            cb.ForeColor = cb.Checked ? Color.MediumPurple : Color.SlateBlue;

            if       (rb_firefox.Checked) { fapmap.settings_edit_browser(0); }
            else if (rb_chrome.Checked)   { fapmap.settings_edit_browser(1); }
            else if (rb_opera.Checked)    { fapmap.settings_edit_browser(2); }
        }

        #endregion

        #region Edit passwords

        private void btn_addPasswd_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { passwords_append(txt_newPasswd.Text); }
        }

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

        #region Text Settings
        
        private void txt_wbURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!Uri.IsWellFormedUriString(txt_wbURL.Text, UriKind.Absolute))
                {
                    txt_wbURL.Text = "https://duckduckgo.com/?q=" + txt_wbURL.Text.Replace(" ", "+");
                }

                fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL = txt_wbURL.Text;
                fapmap.settings_edit(
                    fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL_,
                    txt_wbURL.Text
                );

                panel_txt.Focus();
                this.ActiveControl = panel_txt;
                
                txt_wbURL.ForeColor = Color.MediumSlateBlue;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_wbURL_TextChanged(object sender, EventArgs e)
        {
            txt_wbURL.ForeColor = Color.Red;
        }

        private void txt_gifDelay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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

                panel_txt.Focus();
                this.ActiveControl = panel_txt;

                txt_gifDelay.ForeColor = Color.MediumSlateBlue;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_gifDelay_TextChanged(object sender, EventArgs e)
        {
            txt_gifDelay.ForeColor = Color.Red;
        }

        #endregion

        #region Checkboxes

        private void cb_checkChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            cb.ForeColor = cb.Checked ? Color.SkyBlue : Color.RoyalBlue;
            switch (cb.Tag.ToString())
            {
                case "HIDEONX":   fapmap.GlobalVariables.Settings.CheckBoxes.HideOnX   = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.HideOnX_,   fapmap.bool_to_string(cb.Checked)); break;
                case "FOCUSHIDE": fapmap.GlobalVariables.Settings.CheckBoxes.FocusHide = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.FocusHide_, fapmap.bool_to_string(cb.Checked)); break;

                case "ENABLEPLAYERS":     fapmap.GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers         = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers_,         fapmap.bool_to_string(cb.Checked)); break;
                case "ENABLELOGS":        fapmap.GlobalVariables.Settings.CheckBoxes.EnableLogs                 = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableLogs_,                 fapmap.bool_to_string(cb.Checked)); break;
                case "ENABLETRACKBAR":    fapmap.GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer_, fapmap.bool_to_string(cb.Checked)); break;
                case "ENABLEFILEDISPLAY": fapmap.GlobalVariables.Settings.CheckBoxes.EnableFileDisplay          = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableFileDisplay_,          fapmap.bool_to_string(cb.Checked)); break;
                case "ENABLEOUTSIDE":     fapmap.GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap    = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap_,    fapmap.bool_to_string(cb.Checked)); break;

                case "AUTOHIDE":  fapmap.GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers_, fapmap.bool_to_string(cb.Checked)); break;
                case "AUTOPLAY":  fapmap.GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer  = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer_,  fapmap.bool_to_string(cb.Checked)); break;
                case "AUTOPAUSE": fapmap.GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer_, fapmap.bool_to_string(cb.Checked)); break;

                case "TVSORT":  fapmap.GlobalVariables.Settings.CheckBoxes.TreeViewSortByCreationDate = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.TreeViewSortByCreationDate_, fapmap.bool_to_string(cb.Checked)); break;
                case "TVINDEX": fapmap.GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex      = cb.Checked; fapmap.settings_edit(fapmap.GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex_,      fapmap.bool_to_string(cb.Checked)); break;
            }
        }

        #endregion

        #region settings

        private void btn_editINI_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { fapmap.Open(fapmap.GlobalVariables.Path.File.Settings); }
        }



        #endregion

        
    }
}
