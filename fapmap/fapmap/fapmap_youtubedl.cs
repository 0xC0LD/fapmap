﻿using System;
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

        private void fapmap_youtubedl_FormClosing(object sender, FormClosingEventArgs e)
        {
            youtubedl_die();
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
            txt_path.ForeColor = Directory.Exists(txt_path.Text) ? Color.SteelBlue : Color.DarkOrchid;
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
        }

        private void btn_start_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { youtubedl(); }
        }
        private void btn_openPathSelector_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { fapmap.OpenPathSelectorTXT(this, txt_path, false); }
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