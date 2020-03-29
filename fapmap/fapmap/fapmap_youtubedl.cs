using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace fapmap
{
    public partial class fapmap_youtubedl : Form
    {
        public fapmap_youtubedl()
        {
            InitializeComponent();

            txt_output_RMB.Renderer = new fapmap_res.FapmapColors.fToolStripProfessionalRenderer();
        }

        public string pass_path = string.Empty;
        public string pass_url = string.Empty;
        private void fapmap_youtubedl_Load(object sender, EventArgs e)
        {
            if (!fapmap.checkForApp(fapmap.GlobalVariables.Path.File.Exe.YOUTUBEDL, "https://youtube-dl.org/"))
            { this.Close(); return; }

            txt_path.Text = fapmap.GlobalVariables.Path.Dir.MainFolder;
            if (!string.IsNullOrEmpty(pass_path) && Directory.Exists(pass_path)) { txt_path.Text = new DirectoryInfo(pass_path).FullName; }

            if (!string.IsNullOrEmpty(pass_url)) { txt_url.Text = pass_url; }
            
            this.ActiveControl = txt_url;
        }
        
        #region window

        private void fapmap_youtubedl_FormClosing(object sender, FormClosingEventArgs e) { Quit(); }
        private void Quit()
        {
            youtubedl_die();
        }

        private void this_hide()
        {
            if (this.Visible)
            {
                this.Hide();
                updateIcon(youtubedl_busy);
            }
            else
            {
                this.Show();
                updateIcon(youtubedl_busy);
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
                this.Icon = busy ? Properties.Resources.icon_download : Properties.Resources.icon_downloadIdle;
                this.this_trayicon.Icon = busy ? Properties.Resources.icon_download : Properties.Resources.icon_downloadIdle;
            }
            else
            {
                this.Icon = busy ? Properties.Resources.icon_downloadHidden : Properties.Resources.icon_downloadHiddenIdle;
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

        #region YOUTUBE-DL

        private Process youtubedlProcess = null;
        private void youtubedl_die()
        {
            try
            {
                if (youtubedlProcess != null && !youtubedlProcess.HasExited) { youtubedlProcess.Kill(); }
            }
            catch (Exception) { }
        }
        private bool youtubedl_busy = false;
        private void youtubedl()
        {
            if (youtubedl_busy) { youtubedl_die(); return; }
            youtubedl_busy = true;

            if (!fapmap.checkForApp(fapmap.GlobalVariables.Path.File.Exe.YOUTUBEDL, "https://youtube-dl.org/"))
            { this.Close(); return; }

            string url = txt_url.Text;
            string path = txt_path.Text;
            string options = txt_options.Text;

            new Thread(() => {

                try
                {
                    if (string.IsNullOrEmpty(url))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            label_status.Text = "No input...";
                        });
                        youtubedl_busy = false;
                        return;
                    }

                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, fapmap.GlobalVariables.Path.File.Exe.YOUTUBEDL + " \"" + url + "\" -o \"%(title)s.%(ext)s\"");

                    this.Invoke((MethodInvoker)delegate
                    {
                        label_status.Text = "Downloading...";
                        txt_output.Text = "";
                        btn_start.BackgroundImage = Properties.Resources.close;
                        updateIcon(true);
                    });

                    youtubedlProcess = new Process();
                    youtubedlProcess.StartInfo.FileName = fapmap.GlobalVariables.Path.File.Exe.YOUTUBEDL;
                    youtubedlProcess.StartInfo.Arguments = "\"" + url + "\" " + options;
                    youtubedlProcess.StartInfo.WorkingDirectory = Directory.Exists(path) ? path : fapmap.GlobalVariables.Path.Dir.MainFolder;
                    youtubedlProcess.StartInfo.UseShellExecute = false;
                    youtubedlProcess.StartInfo.CreateNoWindow = true;
                    youtubedlProcess.StartInfo.RedirectStandardOutput = true;
                    youtubedlProcess.StartInfo.RedirectStandardError = true;
                    youtubedlProcess.OutputDataReceived += new DataReceivedEventHandler(youtubedl_output);
                    youtubedlProcess.ErrorDataReceived += new DataReceivedEventHandler(youtubedl_output);
                    youtubedlProcess.Start();
                    youtubedlProcess.BeginOutputReadLine();
                    youtubedlProcess.BeginErrorReadLine();
                    youtubedlProcess.WaitForExit();
                    youtubedlProcess.Close();

                    this.Invoke((MethodInvoker)delegate
                    {
                        label_status.Text = "Done!";
                        btn_start.BackgroundImage = Properties.Resources.download;
                        updateIcon(false);
                    });

                    youtubedl_busy = false;
                }
                catch (Exception) { youtubedl_busy = false; return; }
            })
            { IsBackground = true }.Start();
        }
        private void youtubedl_output(object sender, DataReceivedEventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    txt_output.Text += e.Data + Environment.NewLine;
                });
            }
            catch (ObjectDisposedException) { }
            catch (Exception) { }
        }

        #endregion
        
        #region ui events

        private void txt_path_TextChanged(object sender, EventArgs e)
        {
            txt_path.ForeColor = Directory.Exists(txt_path.Text) ? Color.SkyBlue : Color.PaleVioletRed;
        }
        private void txt_output_TextChanged(object sender, EventArgs e)
        {
            txt_output.SelectionStart = txt_output.Text.Length;
            txt_output.ScrollToCaret();
        }

        private void txt_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                youtubedl();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                txt_url.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_url_TextChanged(object sender, EventArgs e)
        {
            txt_url.Text = txt_url.Text
                .Replace("\n", String.Empty)
                .Replace("\r", String.Empty)
                .Replace("\t", String.Empty);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            youtubedl();
        }
        private void btn_openPathSelector_Click(object sender, EventArgs e)
        {
            fapmap.OpenPathSelectorTXT(this, txt_path, false, txt_path.Text);
        }
        private void btn_explorer_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txt_path.Text)) { fapmap.OpenInExplorer(txt_path.Text); }
        }

        private void txt_output_RMB_copy_Click(object sender, EventArgs e)
        {
            string text = txt_output.SelectedText;
            if (!string.IsNullOrEmpty(text)) { Clipboard.SetText(text); }
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

        #endregion

        
    }
}
