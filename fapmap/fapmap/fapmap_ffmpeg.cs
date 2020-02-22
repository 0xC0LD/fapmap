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
using System.Diagnostics;
using System.IO;

namespace fapmap
{
    public partial class fapmap_ffmpeg : Form
    {
        public fapmap_ffmpeg()
        {
            InitializeComponent();
        }

        public string pass_path = string.Empty;
        private void fapmap_ffmpeg_Load(object sender, EventArgs e)
        {
            if (!fapmap.checkForApp(fapmap.GlobalVariables.Path.File.Exe.FFMPEG, "https://ffmpeg.zeranoe.com/builds/"))
            { this.Close(); return; }
            
            if (!string.IsNullOrEmpty(pass_path)) { txt_file.Text = pass_path; }
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

       
        private Process fscanProcess = null;
        private void ffmpeg_die()
        {
            try
            {
                if (fscanProcess != null && !fscanProcess.HasExited) { fscanProcess.Kill(); }
            }
            catch (Exception) { }
        }
        private bool ffmpeg_busy = false;
        private void ffmpeg()
        {
            if (ffmpeg_busy) { ffmpeg_die(); return; }

            ffmpeg_busy = true;
            
            new Thread(() =>
            {
                //focus on output
                this.ActiveControl = output;
                output.Focus();

                if (!fapmap.checkForApp(fapmap.GlobalVariables.Path.File.Exe.FFMPEG, "https://ffmpeg.zeranoe.com/builds/"))
                { this.Close(); return; }

                //set
                gl_file = txt_file.Text;
                gl_fileNew = txt_fileNew.Text;
                gl_options = txt_options.Text;

                if (string.IsNullOrEmpty(gl_file)) { label_status.Text = "No input..."; ffmpeg_busy = false; return; }

                if (!File.Exists(gl_file))
                {
                    label_status.Text = "File not found...";
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, gl_file);
                    ffmpeg_busy = false;
                    return;
                }

                //setup
                label_status.Text = "Converting...";
                output.Text = ""; //clear output
                
                //more_opts for replace
                string more_opts = "";

                //if file exists
                if (File.Exists(gl_fileNew))
                {
                    DialogResult dialogResult = MessageBox.Show(
                        "A file with the name " + gl_fileNew + " already exists." + Environment.NewLine
                        + Environment.NewLine + "YES          = REPLACE"
                        + Environment.NewLine + "NO          = NEW NAME"
                        + Environment.NewLine + "CANCEL = ABORT",
                        "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                    );

                    if (dialogResult == DialogResult.Yes)
                    {
                        label_status.Text = "Replacing...";

                        more_opts = "-y ";
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //ECHO
                        label_status.Text = "Converting (renamed)...";

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
                        //ECHO
                        label_status.Text = "Aborted.";
                        ffmpeg_busy = false;
                        return;
                    }
                }

                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, fapmap.GlobalVariables.Path.File.Exe.FFMPEG + " " + more_opts + gl_options + " \"" + gl_file + "\" \"" + gl_fileNew + "\"");

                btn_convert.BackgroundImage = Properties.Resources.close;

                // ffmpeg
                fscanProcess = new Process();
                fscanProcess.StartInfo.FileName = fapmap.GlobalVariables.Path.File.Exe.FFMPEG;
                fscanProcess.StartInfo.Arguments = more_opts + gl_options + " \"" + gl_file + "\" \"" + gl_fileNew + "\"";
                fscanProcess.StartInfo.UseShellExecute = false;
                fscanProcess.StartInfo.CreateNoWindow = true;
                fscanProcess.StartInfo.RedirectStandardOutput = true;
                fscanProcess.StartInfo.RedirectStandardError = true;
                fscanProcess.OutputDataReceived += ffmpeg_output;
                fscanProcess.ErrorDataReceived += ffmpeg_output;
                fscanProcess.Start();
                fscanProcess.BeginOutputReadLine();
                fscanProcess.BeginErrorReadLine();
                fscanProcess.WaitForExit();
                fscanProcess.Close();

                btn_convert.BackgroundImage = Properties.Resources.ffmpeg;

                // end
                label_status.Text = "Done!";

                ffmpeg_busy = false;
            })
            { IsBackground = true }.Start();
        }

        private void ffmpeg_output(object sender, DataReceivedEventArgs e)
        {
            try
            {
                output.Text += e.Data + Environment.NewLine;
            }
            catch (Exception) { }
        }
        
        private void btn_convert_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { ffmpeg(); }
        }
        private void btn_openFile_MouseClick(object sender, MouseEventArgs e)
        {
            label_status.Text = fapmap.Open(gl_file) ? "Opened file." : "Failed to open file.";
        }
        private void btn_openFileNew_MouseClick(object sender, MouseEventArgs e)
        {
            label_status.Text = fapmap.Open(gl_fileNew) ? "Opened file." : "Failed to open file.";
        }
        private void btn_delFile_MouseClick(object sender, MouseEventArgs e)
        {
            label_status.Text = fapmap.TrashFile(gl_file) ? "Deleted file." : "Failed to delete file.";
        }
        private void btn_delFileNew_MouseClick(object sender, MouseEventArgs e)
        {
            label_status.Text = fapmap.TrashFile(gl_fileNew) ? "Deleted file." : "Failed to delete file.";
        }
        
        private void txt_file_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_file.Text)) { return; }

            txt_file.ForeColor = File.Exists(txt_file.Text) ? Color.FromArgb(0, 120, 200) : Color.DarkOrchid;
            
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
            }
        }
        private void output_TextChanged(object sender, EventArgs e)
        {
            output.SelectionStart = output.Text.Length;
            output.ScrollToCaret();
        }
        
        private void txt_file_KeyDown(object sender, KeyEventArgs e)
        {
            //update tool tip
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
        }

        // drag n drop
        private void dnd_file_DragOver(object sender, DragEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_file.Text)) { return; }
            e.Effect = DragDropEffects.Copy;
        }
        private void dnd_file_MouseDown(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_file.Text)) { return; }
            this.txt_file.DoDragDrop(new System.Windows.Forms.DataObject(System.Windows.Forms.DataFormats.StringFormat, txt_file.Text), DragDropEffects.Copy);
        }
        private void dnd_fileNew_DragOver(object sender, DragEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_fileNew.Text)) { return; }
            e.Effect = DragDropEffects.Copy;
        }
        private void dnd_fileNew_MouseDown(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_fileNew.Text)) { return; }
            this.txt_fileNew.DoDragDrop(new System.Windows.Forms.DataObject(System.Windows.Forms.DataFormats.StringFormat, txt_fileNew.Text), DragDropEffects.Copy);
        }

        
    }
}
