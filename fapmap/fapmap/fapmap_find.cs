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
using System.Globalization;
using System.Diagnostics;
using System.Threading;

namespace fapmap
{
    public partial class fapmap_find : Form
    {
        public fapmap_find()
        {
            InitializeComponent();

            //BOARDLESS FORM
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            RMB_output.Renderer = new fapmap_res.color.fToolStripProfessionalRenderer();
        }

        private void Find_Load(object sender, EventArgs e)
        {
            //SET CURRENT WORKING DIRECTORY
            Directory.SetCurrentDirectory(fapmap.GlobalVariables.Path.Dir.MainFolder);
        }

        #region Graphics

        //must enable DrawMode = OwnerDrawVariable
        private void Output_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                if (e.Index < 0) { return; }

                //if the item state is selected them change the back color 
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e = new DrawItemEventArgs
                    (
                        e.Graphics,
                        e.Font,
                        e.Bounds,
                        e.Index,
                        e.State ^ DrawItemState.Selected,
                        Color.White,
                        Color.FromArgb(35, 35, 35)
                    );
                }

                e.DrawBackground(); // Draw the background of the ListBox control for each item.


                e.Graphics.DrawString(Output.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault); // Draw the current item text


                e.DrawFocusRectangle(); // If the ListBox has focus, draw a focus rectangle around the selected item.
            }
            catch (Exception) { }
        }

        //LISTBOX 1 CHANGE COLOR
        private void Output_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // //word wrap
            // e.ItemHeight = (int)e.Graphics.MeasureString(Output.Items[e.Index].ToString(), Output.Font, Output.Width).Height;
        }
        
        //TOOLTIP
        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
        
        #endregion

        #region Main Functions
        
        private string get_splited_path(string path)
        {
            string splited_path = "";

            //REMOVE EVERYTHING BEFORE THE END OF "Main Folder\"
            string[] things = path.Split(new string[] { "Main Folder" }, StringSplitOptions.None);
            for (int i = 1; i <= things.Length - 1; i++)
            {
                splited_path = splited_path + things[i];
            }
            splited_path = splited_path.Remove(0, 1); //remove first slash

            return splited_path;
        }

        private void find()
        {
            //result
            resultNum.Text = "Searching...";
            this.Text = "FAPMAP - FIND: Searching...";

            //CLEAR
            Output.SelectedItem = null;
            Output.Items.Clear();

            
            string[] dirs = Directory.GetDirectories(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.AllDirectories);
            string[] files = Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.AllDirectories);

            List<string> all = new List<string>();

            foreach (string dir in dirs) { all.Add(dir); }
            foreach (string file in files) { all.Add(file); }
            
            if (searchBox.Text.Contains(' '))
            {
                string[] index = searchBox.Text.Split(' ');
                
                foreach (string file in all)
                {
                    bool dispose = false;

                    foreach (string item in index)
                    {
                        if (cb_case.Checked)
                        {
                            if (!get_splited_path(file).Contains(item))
                            {
                                dispose = true;
                            }
                        }
                        else
                        {
                            if (new CultureInfo("").CompareInfo.IndexOf(get_splited_path(file), item, CompareOptions.IgnoreCase) >= 0) { } else
                            {
                                dispose = true;
                            }
                        }
                    }

                    if (!dispose)
                    {
                        Output.Items.Add(file);
                        Application.DoEvents();
                    }
                }
            }
            else
            {
                string text = searchBox.Text;

                foreach (string file in all)
                {
                    if (cb_case.Checked)
                    {
                        if (get_splited_path(file).Contains(text))
                        {
                            Output.Items.Add(file);
                            Application.DoEvents();
                        }
                    }
                    else
                    {
                        if (new CultureInfo("").CompareInfo.IndexOf(get_splited_path(file), text, CompareOptions.IgnoreCase) >= 0)
                        {
                            Output.Items.Add(file);
                            Application.DoEvents();
                        }
                    }
                }
            }
            

            //show result
            resultNum.Text = Output.Items.Count + " result(s) found!";
            this.Text = "FAPMAP - FIND: " + Output.Items.Count + " result(s) found!";
        }
        
        //OPEN FUNCTION
        private void OpenFileInOuput()
        {
            if (Output.SelectedItem != null)
            {
                string file = Output.SelectedItem.ToString();

                if (Directory.Exists(file))
                {
                    Process.Start("explorer.exe", file);
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, file);
                }
                else
                {
                    if (File.Exists(file))
                    {
                        Process.Start(file);
                        fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, file);
                    }
                    else
                    {
                        this.Text = "FAPMAP - FIND: File not found: " + file;
                        fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file);
                    }
                }
            }
        }

        private void open_file_explorer_output()
        {
            if (Output.SelectedItem != null)
            {
                fapmap.open_in_explorer(Output.SelectedItem.ToString());
            }
        }

        //COPY FUNCTION
        private void CopySlected()
        {
            if (Output.SelectedItem != null)
            {
                System.Windows.Forms.Clipboard.SetText(Output.SelectedItem.ToString());
            }
        }

        private void showImage_remove()
        {
            showImage.Image = null;
            showImage.Visible = false;
        }

        //DELETE FILE
        private void DeleteFile()
        {
            showImage_remove();

            if (Output.SelectedItem != null)
            {
                string file = Output.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(file))
                {
                    if (File.Exists(file))
                    {
                        FileInfo fi = new FileInfo(file);
                        
                        try
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(fi.FullName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);

                            Output.Items.Remove(Output.SelectedItem.ToString());
                        }
                        catch (System.OperationCanceledException) { }
                        catch (IOException) { }
                        catch (UnauthorizedAccessException) { }

                        //DISPLAY
                        this.Text = "FAPMAP: REMOVED: " + fi.FullName;
                    }
                }
            }
        }

        #endregion

        //SEARCH BUTTON
        private void findStart_Click(object sender, EventArgs e)
        {
            find();
        }
        //SEAERCH ENTER
        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter: e.SuppressKeyPress = true; find(); break;
                case Keys.Back: if (e.Control) { e.SuppressKeyPress = true; } break;
                case Keys.Escape: this.Close(); break;
            }
        }

        private void Output_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 || e.Control && e.KeyCode == Keys.R)
            {
                find();
            }

            if (e.KeyCode == Keys.Enter || e.Control && e.KeyCode == Keys.W)
            {
                e.SuppressKeyPress = true;

                OpenFileInOuput();
            }

            if (e.Control && e.KeyCode == Keys.U)
            {
                open_file_explorer_output();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                CopySlected();
            }
            
            if (e.KeyCode == Keys.Delete)
            {
                DeleteFile();
            }
        }

        #region RMB

        private void refreshCTRLRF5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            find();
        }

        private void openOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileInOuput();
        }

        private void openInExplorerCTRLUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_file_explorer_output();
        }

        private void copyOuputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySlected();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFile();
        }

        #endregion

        private void Output_DragOver(object sender, DragEventArgs e)
        {
            if (Output.SelectedItems.Count != 0)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Output_MouseDown(object sender, MouseEventArgs e)
        {
            //select
            Output_SelectedIndexChanged(null, null);

            if (e.Button != MouseButtons.Right)
            {
                if (Output.SelectedItems.Count != 0)
                {
                    if (e.Clicks == 2)
                    {
                        OpenFileInOuput();

                        return;
                    }

                    string text = string.Empty;
                    foreach (string item in Output.SelectedItems) { text = item; } //get items

                    this.Output.DoDragDrop(new System.Windows.Forms.DataObject(System.Windows.Forms.DataFormats.StringFormat, text), DragDropEffects.Copy);
                }
            }
        }

        private void Output_SelectedIndexChanged(object sender, EventArgs e)
        {
            //hide
            showImage_remove();

            if (cb_showImage.Checked)
            {
                if (Output.SelectedItem != null)
                {
                    string file = Output.SelectedItem.ToString();

                    //CHECK IF IMAGE FILE
                    foreach (string type in fapmap.GlobalVariables.FileTypes.Image)
                    {
                        if (file.EndsWith(type))
                        {
                            if (type == ".gif")
                            {
                                showImage.Image = Image.FromFile(file);
                                showImage.Visible = true;
                            }
                            else
                            {
                                showImage.Image = fapmap.GetImage(file);
                                showImage.Visible = true;
                            }
                            
                        }
                    }
                }
            }
        }

        
        private static bool zoomed = false;
        private void showImage_Click(object sender, EventArgs e)
        {
            int resize = 300;

            if (!zoomed) //zoom
            {
                showImage.Location = new Point(showImage.Location.X - resize, showImage.Location.Y - resize);
                showImage.Size = new Size(showImage.Size.Width + resize, showImage.Size.Height + resize);
            }
            else //unzoom
            {
                showImage.Location = new Point(showImage.Location.X + resize, showImage.Location.Y + resize);
                showImage.Size = new Size(showImage.Size.Width - resize, showImage.Size.Height - resize);
            }

            zoomed = !zoomed;
        }
        
    }
}
