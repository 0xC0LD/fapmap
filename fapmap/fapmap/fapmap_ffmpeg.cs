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
using System.Diagnostics;
using System.IO;

namespace fapmap
{
    public partial class fapmap_ffmpeg : Form
    {
        public fapmap_ffmpeg()
        {
            InitializeComponent();

            txt_output_RMB.Renderer = new fapmap_res.FapMapColors.FapMapToolStripRenderer(Color.FromArgb(128, 128, 255));
        }
        
        public string pass_path = string.Empty;
        private void fapmap_ffmpeg_Load(object sender, EventArgs e)
        {
            if (!fapmap.checkForApp(fapmap.GlobalVariables.Path.File.Exe.FFMPEG, "https://ffmpeg.zeranoe.com/builds/"))
            { this.Close(); return; }
            
            if (!string.IsNullOrEmpty(pass_path))
            {
                txt_file.Text = pass_path;
                txt_file.SelectionStart = txt_file.Text.Length;
                txt_file.ScrollToCaret();
            }
        }

        #region window and fx

        private void fapmap_ffmpeg_FormClosing(object sender, FormClosingEventArgs e)
        {
            ffmpeg_die();
        }

        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
        

        #endregion
        
        private string gl_file = "";
        private string gl_fileNew = "";
        private string gl_options = "";
        
        private Process ffmpegProcess = null;
        private void ffmpeg_die()
        {
            try
            {
                if (ffmpegProcess != null && !ffmpegProcess.HasExited) { ffmpegProcess.Kill(); }
            }
            catch (Exception) { }
        }
        private bool ffmpeg_busy = false;
        private void ffmpeg()
        {
            if (ffmpeg_busy) { ffmpeg_die(); return; }

            ffmpeg_busy = true;

            if (!fapmap.checkForApp(fapmap.GlobalVariables.Path.File.Exe.FFMPEG, "https://ffmpeg.zeranoe.com/builds/"))
            { this.Close(); return; }

            this.ActiveControl = txt_output;

            //set
            gl_file = txt_file.Text;
            gl_fileNew = txt_fileNew.Text;
            gl_options = txt_options.Text;

            new Thread(() =>
            {
                try
                {
                    if (string.IsNullOrEmpty(gl_file))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            label_status.Text = "No input...";
                        });
                        ffmpeg_busy = false;
                        return;
                    }

                    if (!File.Exists(gl_file))
                    {
                        fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, gl_file);
                        this.Invoke((MethodInvoker)delegate
                        {
                            label_status.Text = "File not found...";
                        });
                        ffmpeg_busy = false;
                        return;
                    }

                    //more_opts for replace
                    string more_opts = "";

                    //if file exists
                    if (File.Exists(gl_fileNew))
                    {
                        DialogResult dialogResult = fapmap.OpenFileExistsDialog(this, gl_fileNew);

                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                label_status.Text = "Replacing...";
                            });

                            more_opts = "-y ";
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                label_status.Text = "Converting (renamed)...";
                            });

                            FileInfo fi = new FileInfo(gl_fileNew);

                            int c = 1;
                            string newFilename = fi.FullName.Replace(fi.Name, "") + fi.Name.Replace(fi.Extension, "") + " [" + c + "]" + fi.Extension;

                            while (File.Exists(newFilename))
                            {
                                c++;
                                newFilename = fi.FullName.Replace(fi.Name, "") + fi.Name.Replace(fi.Extension, "") + " [" + c + "]" + fi.Extension;
                            }

                            //new filename
                            gl_fileNew = newFilename;
                        }
                        else if (dialogResult == DialogResult.Cancel)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                label_status.Text = "Aborted.";
                            });
                            ffmpeg_busy = false;
                            return;
                        }
                    }

                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, fapmap.GlobalVariables.Path.File.Exe.FFMPEG + " " + more_opts + gl_options + " \"" + gl_file + "\" \"" + gl_fileNew + "\"");

                    this.Invoke((MethodInvoker)delegate
                    {
                        label_status.Text = "Converting...";
                        txt_output.Text = "";
                        btn_convert.BackgroundImage = Properties.Resources.close;
                    });

                    // ffmpeg
                    ffmpegProcess = new Process();
                    ffmpegProcess.StartInfo.FileName = fapmap.GlobalVariables.Path.File.Exe.FFMPEG;
                    ffmpegProcess.StartInfo.Arguments = more_opts + gl_options + " \"" + gl_file + "\" \"" + gl_fileNew + "\"";
                    ffmpegProcess.StartInfo.UseShellExecute = false;
                    ffmpegProcess.StartInfo.CreateNoWindow = true;
                    ffmpegProcess.StartInfo.RedirectStandardOutput = true;
                    ffmpegProcess.StartInfo.RedirectStandardError = true;
                    ffmpegProcess.OutputDataReceived += ffmpeg_output;
                    ffmpegProcess.ErrorDataReceived += ffmpeg_output;
                    ffmpegProcess.Start();
                    ffmpegProcess.BeginOutputReadLine();
                    ffmpegProcess.BeginErrorReadLine();
                    ffmpegProcess.WaitForExit();
                    ffmpegProcess.Close();

                    this.Invoke((MethodInvoker)delegate
                    {
                        label_status.Text = "Done!";
                        btn_convert.BackgroundImage = Properties.Resources.ffmpeg;
                    });
                    
                    ffmpeg_busy = false;
                }
                catch (Exception) { ffmpeg_busy = false; return; }
            })
            { IsBackground = true }.Start();
        }

        private void ffmpeg_output(object sender, DataReceivedEventArgs e)
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
        
        private void btn_convert_Click(object sender, EventArgs e)
        {
            ffmpeg();
        }
        private void btn_openFile_Click(object sender, EventArgs e)
        {
            label_status.Text = fapmap.Open(gl_file) ? "Opened file." : "Failed to open file.";
        }
        private void btn_delFile_Click(object sender, EventArgs e)
        {
            label_status.Text = fapmap.TrashFile(gl_file) ? "Deleted file." : "Failed to delete file.";
        }
        private void btn_openFileNew_Click(object sender, EventArgs e)
        {
            label_status.Text = fapmap.Open(gl_fileNew) ? "Opened file." : "Failed to open file.";
        }
        private void btn_delFileNew_Click(object sender, EventArgs e)
        {
            label_status.Text = fapmap.TrashFile(gl_fileNew) ? "Deleted file." : "Failed to delete file.";
        }

        private void txt_output_RMB_copy_Click(object sender, EventArgs e)
        {
            string text = txt_output.SelectedText;
            if (!string.IsNullOrEmpty(text)) { Clipboard.SetText(text); }
        }

        private void txt_file_TextChanged(object sender, EventArgs e)
        {
            if (txt_file.Text.Contains("\n")) { txt_file.Text = txt_file.Text.Replace("\n", String.Empty); }
            if (txt_file.Text.Contains("\r")) { txt_file.Text = txt_file.Text.Replace("\r", String.Empty); }
            if (txt_file.Text.Contains("\t")) { txt_file.Text = txt_file.Text.Replace("\t", String.Empty); }

            if (string.IsNullOrEmpty(txt_file.Text)) { return; }

            txt_file.ForeColor = File.Exists(txt_file.Text) ? Color.Turquoise : Color.PaleVioletRed;
            
            HelpBalloon.SetToolTip(btn_openFile, "Open File: " + txt_file.Text);

            if (File.Exists(txt_file.Text))
            {
                FileInfo fi = new FileInfo(txt_file.Text);

                switch (fi.Extension)
                {
                    case ".webm": txt_fileNew.Text = fi.Directory.FullName + "\\" + Path.GetFileNameWithoutExtension(txt_file.Text) + ".mp4"; break;
                    case ".mp4":  txt_fileNew.Text = fi.Directory.FullName + "\\" + Path.GetFileNameWithoutExtension(txt_file.Text) + ".webm"; break;
                    case ".jpg":  txt_fileNew.Text = fi.Directory.FullName + "\\" + Path.GetFileNameWithoutExtension(txt_file.Text) + ".png"; break;
                    case ".png":  txt_fileNew.Text = fi.Directory.FullName + "\\" + Path.GetFileNameWithoutExtension(txt_file.Text) + ".jpg"; break;

                    default: txt_fileNew.Text = txt_file.Text; break;
                }

                txt_fileNew.SelectionStart = txt_fileNew.Text.Length;
                txt_fileNew.ScrollToCaret();
            }
        }
        private void txt_fileNew_TextChanged(object sender, EventArgs e)
        {
            if (txt_fileNew.Text.Contains("\n")) { txt_fileNew.Text = txt_fileNew.Text.Replace("\n", String.Empty); }
            if (txt_fileNew.Text.Contains("\r")) { txt_fileNew.Text = txt_fileNew.Text.Replace("\r", String.Empty); }
            if (txt_fileNew.Text.Contains("\t")) { txt_fileNew.Text = txt_fileNew.Text.Replace("\t", String.Empty); }
        }

        private void txt_output_TextChanged(object sender, EventArgs e)
        {
            txt_output.SelectionStart = txt_output.Text.Length;
            txt_output.ScrollToCaret();
        }

        private void txt_file_KeyDown(object sender, KeyEventArgs e)
        {
            HelpBalloon.SetToolTip(btn_openFile, "Open File: " + txt_file.Text);

            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = txt_fileNew;
                txt_fileNew.Focus();
                if (txt_fileNew.Text.Length > 5)
                {
                    txt_fileNew.Select(txt_fileNew.Text.Length - new FileInfo(txt_fileNew.Text).Extension.Length+1, txt_fileNew.Text.Length);
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                txt_file.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_fileNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ffmpeg();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                txt_fileNew.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void options_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                txt_options.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // drag out buttons
        private void btn_fileDragOut_DragOver(object sender, DragEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_file.Text)) { return; }
            e.Effect = DragDropEffects.Copy;
        }
        private void btn_fileDragOut_MouseDown(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_file.Text)) { return; }
            this.txt_file.DoDragDrop(new DataObject(DataFormats.StringFormat, txt_file.Text), DragDropEffects.Copy);
        }
        private void btn_fileNewDragOut_DragOver(object sender, DragEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_fileNew.Text)) { return; }
            e.Effect = DragDropEffects.Copy;
        }
        private void btn_fileNewDragOut_MouseDown(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_fileNew.Text)) { return; }
            this.txt_fileNew.DoDragDrop(new DataObject(DataFormats.StringFormat, txt_fileNew.Text), DragDropEffects.Copy);
        }
    }
}
