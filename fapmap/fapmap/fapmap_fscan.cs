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
using System.Threading;
using System.Diagnostics;

namespace fapmap
{
    public partial class fapmap_fscan : Form
    {
        public fapmap_fscan()
        {
            InitializeComponent();
        }

        public string pass_path = string.Empty;

        private void fapmap_fscan_Load(object sender, EventArgs e)
        {
            if (!fapmap.checkForApp(fapmap.GlobalVariables.Path.File.Exe.FSCAN, "https://github.com/0xC0LD/fscan/releases"))
            { this.Close(); return; }

            txt_path.Text = fapmap.GlobalVariables.Path.Dir.MainFolder;
            if (!string.IsNullOrEmpty(pass_path) && Directory.Exists(pass_path)) { txt_path.Text = new DirectoryInfo(pass_path).FullName; }

            this.ActiveControl = txt_options;
        }

        #region window and fx

        private void fapmap_fscan_FormClosing(object sender, FormClosingEventArgs e)
        {
            fscan_die();
        }

        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        #endregion
        
        #region fscan
        
        private Process fscanProcess = null;
        private void fscan_die()
        {
            try
            {
                if (fscanProcess != null && !fscanProcess.HasExited) { fscanProcess.Kill(); }
            }
            catch (Exception) { }
        }
        private bool fscan_busy = false;
        private void fscan()
        {
            if (fscan_busy) { fscan_die(); return; }
            fscan_busy = true;

            if (!fapmap.checkForApp(fapmap.GlobalVariables.Path.File.Exe.FSCAN, "https://github.com/0xC0LD/fscan/releases"))
            { this.Close(); return; }

            new Thread(() =>
            {
                try
                {
                    string workingDir = txt_path.Text;
                    string args = txt_options.Text;

                    if (string.IsNullOrEmpty(workingDir)) { workingDir = fapmap.GlobalVariables.Path.Dir.MainFolder; }

                    if (!Directory.Exists(workingDir))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            label_status.Text = "Dir not found...";
                        });
                        fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, workingDir);
                        fscan_busy = false;
                        return;
                    }

                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, fapmap.GlobalVariables.Path.File.Exe.FSCAN + " " + args);
                    
                    this.Invoke((MethodInvoker)delegate
                    {
                        label_status.Text = "Searching...";
                        txt_output.Text = "";
                        btn_find.BackgroundImage = Properties.Resources.close;
                    });

                    // ffmpeg
                    fscanProcess = new Process();
                    fscanProcess.StartInfo.FileName = fapmap.GlobalVariables.Path.File.Exe.FSCAN;
                    fscanProcess.StartInfo.Arguments = args;
                    fscanProcess.StartInfo.WorkingDirectory = workingDir;
                    fscanProcess.StartInfo.UseShellExecute = false;
                    fscanProcess.StartInfo.CreateNoWindow = true;
                    fscanProcess.StartInfo.RedirectStandardOutput = true;
                    fscanProcess.StartInfo.RedirectStandardError = true;
                    fscanProcess.OutputDataReceived += fscan_output;
                    fscanProcess.ErrorDataReceived += fscan_output;
                    fscanProcess.Start();
                    fscanProcess.BeginOutputReadLine();
                    fscanProcess.BeginErrorReadLine();
                    fscanProcess.WaitForExit();
                    fscanProcess.Close();

                    this.Invoke((MethodInvoker)delegate
                    {
                        label_status.Text = "Done!";
                        btn_find.BackgroundImage = Properties.Resources.find;
                    });
                    

                    fscan_busy = false;
                }
                catch (Exception) { fscan_busy = false; return; }
            })
            { IsBackground = true }.Start();
        }
        private void fscan_output(object sender, DataReceivedEventArgs e)
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
        
        private void btn_find_Click(object sender, EventArgs e)
        {
            fscan();
        }
        private void btn_openPathSelector_Click(object sender, EventArgs e)
        {
            fapmap.OpenPathSelectorTXT(this, txt_path, false, txt_path.Text);
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter: fscan(); e.Handled = true; e.SuppressKeyPress = true; break;
            }
        }
        private void txt_path_TextChanged(object sender, EventArgs e)
        {
            txt_path.ForeColor = Directory.Exists(txt_path.Text) ? Color.CornflowerBlue : Color.PaleVioletRed;
        }

        private void txt_output_TextChanged(object sender, EventArgs e)
        {
            if (cb_scroll.Checked)
            {
                txt_output.SelectionStart = txt_output.Text.Length;
                txt_output.ScrollToCaret();
            }
        }


        #endregion

        
    }
}
