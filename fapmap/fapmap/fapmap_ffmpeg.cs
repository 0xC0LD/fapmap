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

            //BOARDLESS FORM
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public static string passed_location = string.Empty; 

        private void fapmap_ffmpeg_Load(object sender, EventArgs e)
        {
            //SET CURRENT WORKING DIRECTORY
            Directory.SetCurrentDirectory(fapmap.GlobalVariables.Path.Dir.MainFolder);
            
            if (!File.Exists(fapmap.GlobalVariables.Path.File.Exe.Ffmpeg))
            {
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, fapmap.GlobalVariables.Path.File.Exe.Ffmpeg);
                DialogResult di = MessageBox.Show(
                    "Unable to find ffmpeg.exe" + Environment.NewLine + Environment.NewLine + "Do you want to download ffmpeg? Click [Yes] to open URL: https://ffmpeg.zeranoe.com/builds/",
                    fapmap.GlobalVariables.Path.File.Exe.Ffmpeg,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error
                    );

                if (di == DialogResult.Yes) { fapmap.Incognito("https://ffmpeg.zeranoe.com/builds/"); }
                this.Close();
            }

            if (!string.IsNullOrEmpty(passed_location))
            {
                file.Text = passed_location;
                
                //clear
                passed_location = string.Empty;
            }
        }

        //TOOLTIP COLOR FIX
        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        //VARS
        private static string this_file = "";
        private static string new_file = "";

        //BTNS
        private void convert_Click(object sender, EventArgs e)
        {
            conv_thread();
        }
        private void open_file_Click(object sender, EventArgs e)
        {
            if (File.Exists(file.Text))
            {
                Process.Start(file.Text);
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, file.Text);
            }
            else
            {
                info.Text = "File not found!";
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file.Text);
            }
        }
        private void open_file_new_Click(object sender, EventArgs e)
        {
            if (File.Exists(new_file))
            {
                Process.Start(new_file);
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, new_file);
            }
            else
            {
                if (File.Exists(file_new.Text))
                {
                    Process.Start(file_new.Text);
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, new_file);
                }
                else
                {
                    info.Text = "File not found!";
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, new_file);
                }
            }
        }
        
        private bool conv_busy = false;
        private void conv_thread()
        {
            if (!conv_busy)
            {
                if (File.Exists(fapmap.GlobalVariables.Path.File.Exe.Ffmpeg))
                {
                    if (!string.IsNullOrEmpty(file.Text))
                    {
                        if (File.Exists(file.Text))
                        {
                            Thread th = new Thread(conv);
                            th.IsBackground = true;
                            th.Start();
                        }
                        else
                        {
                            info.Text = "File not found...";
                            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file.Text);
                        }
                    }
                    else
                    {
                        info.Text = "No input...";
                    }
                }
                else
                {
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, fapmap.GlobalVariables.Path.File.Exe.Ffmpeg);
                    DialogResult di = MessageBox.Show(
                        "Unable to find ffmpeg.exe" + Environment.NewLine + Environment.NewLine + "Do you want to download ffmpeg? Click [Yes] to open URL: https://ffmpeg.zeranoe.com/builds/",
                        fapmap.GlobalVariables.Path.File.Exe.Ffmpeg,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error
                        );

                    if (di == DialogResult.Yes) { fapmap.Incognito("https://ffmpeg.zeranoe.com/builds/"); }
                    this.Close();
                }
            }
        }
        private void conv()
        {
            if (!conv_busy)
            {
                conv_busy = true;

                //focus on output
                this.ActiveControl = output;
                output.Focus();

                //disable controls
                file_new.Enabled = false;
                file.Enabled = false;
                convert.Enabled = false;
                options.Enabled = false;

                //setup
                info.Text = "Converting...";
                output.Text = ""; //clear output

                //set
                this_file = file.Text;
                new_file = file_new.Text;

                //more_opts for replace
                string more_opts = "";

                //if file exists
                if (File.Exists(new_file))
                {
                    DialogResult dialogResult = MessageBox.Show(
                        "A file with the name " + file_new.Text + " already exists." + Environment.NewLine
                        + Environment.NewLine + "YES          = REPLACE"
                        + Environment.NewLine + "NO          = NEW NAME"
                        + Environment.NewLine + "CANCEL = ABORT",
                        this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                    );

                    if (dialogResult == DialogResult.Yes)
                    {
                        //ECHO
                        info.Text = "Replacing...";

                        more_opts = "-y ";
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //ECHO
                        info.Text = "Converting (renamed)...";

                        FileInfo fi = new FileInfo(new_file);

                        int c = 1;
                        string newFilename = fi.FullName.Replace(fi.Name, "") + fi.Name.Replace(fi.Extension, "") + " [" + c + "]" + fi.Extension;

                        while (File.Exists(newFilename))
                        {
                            c++;
                            newFilename = fi.FullName.Replace(fi.Name, "") + fi.Name.Replace(fi.Extension, "") + " [" + c + "]" + fi.Extension;
                        }

                        //new filename
                        new_file = newFilename;
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        //enable controls
                        file_new.Enabled = true;
                        file.Enabled = true;
                        convert.Enabled = true;
                        options.Enabled = true;

                        //ECHO
                        info.Text = "Aborted.";

                        conv_busy = false;
                        return;
                    }
                }

                //set tool tip for new file
                HelpBalloon.SetToolTip(open_file_new, "Open File: " + new_file);

                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, fapmap.GlobalVariables.Path.File.Exe.Ffmpeg + " " + more_opts + options.Text + " \"" + this_file + "\" \"" + new_file + "\"");

                //FFMPEG
                Process ffmpeg = new Process();
                ffmpeg.StartInfo.FileName = fapmap.GlobalVariables.Path.File.Exe.Ffmpeg;
                ffmpeg.StartInfo.Arguments = more_opts + options.Text + " \"" + this_file + "\" \"" + new_file + "\"";
                ffmpeg.StartInfo.UseShellExecute = false;
                ffmpeg.StartInfo.CreateNoWindow = true;
                ffmpeg.StartInfo.RedirectStandardOutput = true;
                ffmpeg.StartInfo.RedirectStandardError = true;
                //output and error (asynchronous) handlers
                ffmpeg.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
                ffmpeg.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
                //start and wait
                ffmpeg.Start();
                ffmpeg.BeginOutputReadLine();
                ffmpeg.BeginErrorReadLine();
                ffmpeg.WaitForExit();

                //enable controls
                file_new.Enabled = true;
                file.Enabled = true;
                convert.Enabled = true;
                options.Enabled = true;

                //ECHO
                info.Text = "Done!";

                conv_busy = false;
            }
        }
        
        //output
        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            output.Text += outLine.Data + Environment.NewLine;
        }

        //auto fill
        private void file_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(file.Text))
            {
                //update tool tip
                HelpBalloon.SetToolTip(open_file, "Open File: " + this_file);

                if (File.Exists(file.Text))
                {
                    FileInfo fi = new FileInfo(file.Text);
                    switch (fi.Extension)
                    {
                        case ".webm": file_new.Text = fi.FullName.Replace(fi.Extension, ".mp4"); break;
                        case ".mp4": file_new.Text = fi.FullName.Replace(fi.Extension, ".webm"); break;

                        case ".gif": file_new.Text = fi.FullName.Replace(fi.Extension, ".jpg"); break;
                        case ".jpg": file_new.Text = fi.FullName.Replace(fi.Extension, ".png"); break;


                        default: file_new.Text = fi.FullName; break;
                    }
                    
                }
            }

            if (File.Exists(file.Text))
            {
                file.ForeColor = Color.FromArgb(0, 120, 200);
            }
            else
            {
                file.ForeColor = Color.Red;
            }
        }

        //scroll output
        private void output_TextChanged(object sender, EventArgs e)
        {
            output.SelectionStart = output.Text.Length;
            output.ScrollToCaret();
        }

        //jump to file_new
        private void file_KeyDown(object sender, KeyEventArgs e)
        {
            //update tool tip
            HelpBalloon.SetToolTip(open_file, "Open File: " + this_file);

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                this.ActiveControl = file_new;
                file_new.Focus();
                if (file_new.Text.Length > 5)
                {
                    file_new.Select(file_new.Text.Length - 3, file_new.Text.Length);
                }
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void options_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void file_new_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                convert_Click(null, null);
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void file_dragOut_DragOver(object sender, DragEventArgs e)
        {
            if (!string.IsNullOrEmpty(file.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void file_dragOut_MouseDown(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(file.Text))
            {
                this.file.DoDragDrop(new System.Windows.Forms.DataObject(System.Windows.Forms.DataFormats.StringFormat, file.Text), DragDropEffects.Copy);
            }
        }

        private void file_new_dragOut_DragOver(object sender, DragEventArgs e)
        {
            if (!string.IsNullOrEmpty(file_new.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void file_new_dragOut_MouseDown(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(file_new.Text))
            {
                this.file_new.DoDragDrop(new System.Windows.Forms.DataObject(System.Windows.Forms.DataFormats.StringFormat, file_new.Text), DragDropEffects.Copy);
            }
        }

        private void del_file_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(file.Text))
            {
                if (File.Exists(file.Text))
                {
                    FileInfo fi = new FileInfo(file.Text);
                    
                    try
                    {
                        // txt_path.Text = Directory.GetParent(fi.FullName).ToString();
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(fi.FullName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                    }
                    catch (System.OperationCanceledException) { return; }
                    catch (IOException) { return; }
                    catch (UnauthorizedAccessException) { return; }

                    //DISPLAY
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.RMVD, fi.FullName);
                    this.Text = "FAPMAP: REMOVED: " + fi.FullName;
                }
                else
                {
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file.Text);
                    this.Text = "FAPMAP: File not found: " + file.Text;
                }
            }
        }

        private void del_file_new_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(file_new.Text))
            {
                if (File.Exists(file_new.Text))
                {
                    FileInfo fi = new FileInfo(file_new.Text);

                    try
                    {
                        // txt_path.Text = Directory.GetParent(fi.FullName).ToString();
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(fi.FullName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                    }
                    catch (System.OperationCanceledException) { return; }
                    catch (IOException) { return; }
                    catch (UnauthorizedAccessException) { return; }

                    //DISPLAY
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.RMVD, fi.FullName);
                    this.Text = "FAPMAP: REMOVED: " + fi.FullName;
                }
                else
                {
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file_new.Text);
                    this.Text = "FAPMAP: File not found: " + file_new.Text;
                }
            }
        }
        
    }
}
