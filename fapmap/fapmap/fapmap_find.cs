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

            RMB_output.Renderer = new fapmap_res.color.fToolStripProfessionalRenderer();
        }

        private void fapmap_find_Load(object sender, EventArgs e)
        {

        }

        #region fx

        // DrawMode = OwnerDrawVariable
        private void output_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                if (e.Index < 0) { return; }
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e = new DrawItemEventArgs
                    (
                        e.Graphics,
                        e.Font,
                        e.Bounds,
                        e.Index,
                        e.State ^ DrawItemState.Selected,
                        Color.MediumSlateBlue,
                        Color.FromArgb(25, 25, 25)
                    );
                }

                e.DrawBackground();
                e.Graphics.DrawString(output.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
            catch (Exception) { }
        }

        private void output_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // word wrap
            //e.ItemHeight = (int)e.Graphics.MeasureString(Output.Items[e.Index].ToString(), Output.Font, Output.Width).Height;
        }

        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void output_SizeChanged(object sender, EventArgs e)
        {
            output.Update();
            output.Refresh();
        }

        #endregion

        #region functions

        private void find()
        {
            //result
            resultNum.Text = "Searching...";

            //CLEAR
            output.SelectedItem = null;
            output.Items.Clear();

            List<string> all = new List<string>();
            all.AddRange(Directory.GetDirectories(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.AllDirectories));
            all.AddRange(Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.AllDirectories));

            List<string> keywords = new List<string>();

            if (searchBox.Text.Contains(' ')) { keywords.AddRange(searchBox.Text.Split(' ')); }
            else { keywords.Add(searchBox.Text); }

            List<string> itemsToAdd = new List<string>();

            foreach (string f in all)
            {
                bool addIt = true;
                foreach (string key in keywords)
                {
                    string file = f.Remove(0, (fapmap.GlobalVariables.Path.Dir.MainFolder + "\\").Length);

                    if ((cb_case.Checked ? !file.Contains(key) : !(new CultureInfo("").CompareInfo.IndexOf(file, key, CompareOptions.IgnoreCase) >= 0)))
                    { addIt = false; break; }
                }

                if (addIt) { itemsToAdd.Add(f); }
            }

            output.Items.AddRange(itemsToAdd.ToArray());

            //show result
            resultNum.Text = output.Items.Count + " result(s) found!";
        }
        private void output_open()
        {
            if (output.SelectedItem != null)
            {
                fapmap.Open(output.SelectedItem.ToString());
            }
        }
        private void output_explorer()
        {
            if (output.SelectedItem != null)
            {
                fapmap.OpenInExplorer(output.SelectedItem.ToString());
            }
        }
        private void output_copy()
        {
            if (output.SelectedItem != null)
            {
                Clipboard.SetText(output.SelectedItem.ToString());
            }
        }
        private void output_deleteFile()
        {
            showImage_dispose();

            if (output.SelectedItem != null)
            {
                string file = output.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(file))
                {
                    if (File.Exists(file))
                    {
                        FileInfo fi = new FileInfo(file);

                        try
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(fi.FullName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);

                            output.Items.Remove(output.SelectedItem.ToString());
                        }
                        catch (System.OperationCanceledException) { }
                        catch (IOException) { }
                        catch (UnauthorizedAccessException) { }
                    }
                }
            }
        }

        #endregion

        #region ui events

        private void findButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { find(); }
        }
        
        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter: find(); e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Back: if (e.Control) { e.SuppressKeyPress = true; } break;
                case Keys.Escape: this.Close(); break;
            }
        }
        
        private void output_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: find(); break;
                case Keys.Enter: output_open(); e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Escape: this.Close(); break;
                case Keys.Delete: output_deleteFile(); break;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R: find(); break;
                    case Keys.W: output_open(); e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.U: output_explorer(); break;
                    case Keys.C: output_copy(); break;
                }
            }
        }

        // drag n drop from output
        private void output_DragOver(object sender, DragEventArgs e)
        {
            if (output.SelectedItems.Count != 0) { e.Effect = DragDropEffects.Copy; }
        }
        private void output_MouseDown(object sender, MouseEventArgs e)
        {
            output_SelectedIndexChanged(null, null);

            if (e.Button != MouseButtons.Left) { return; }
            if (output.SelectedItems.Count == 0) { return; }
            if (e.Clicks == 2) { output_open(); return; }

            string text = string.Empty;
            foreach (string item in output.SelectedItems) { text += item + Environment.NewLine; }
            this.output.DoDragDrop(new System.Windows.Forms.DataObject(System.Windows.Forms.DataFormats.StringFormat, text), DragDropEffects.Copy);
        }
        
        private void showImage_dispose()
        {
            showImage.Image = Properties.Resources.image;
            showImage.Visible = false;
            GC.Collect();
        }
        private void output_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (output.SelectedItem == null) { return; }
            string item = output.SelectedItem.ToString();
            if (string.IsNullOrEmpty(item)) { return; }
            if (!File.Exists(item) && !Directory.Exists(item)) { output.Items.Remove(output.SelectedItem); return; }

            if (!cb_showImage.Checked) { return; }
            showImage_dispose();
            if (File.Exists(item))
            {
                if (fapmap.GlobalVariables.FileTypes.Image.Contains(new FileInfo(item).Extension))
                {
                    showImage.Image = Image.FromFile(item);
                    showImage.Visible = true;
                }
            }
        }
        
        private Point showImage_startDraggingPoint;
        private Size showImage_startSize;
        private Rectangle showImage_rectProposedSize = Rectangle.Empty;

        private void showImage_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right: showImage.Size = showImage.MinimumSize; break;
                case MouseButtons.Left:
                    {
                        // starting size
                        showImage_startSize = new System.Drawing.Size(e.X, e.Y);

                        // get the location of the picture box
                        showImage_rectProposedSize = new Rectangle(this.PointToScreen(showImage.Location), showImage_startSize);

                        // start point location
                        showImage_startDraggingPoint = e.Location;

                        break;
                    }
            }
        }
        private void showImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            // calculate rect new size
            showImage_rectProposedSize.Width = e.X - this.showImage_startDraggingPoint.X + this.showImage_startSize.Width;
            showImage_rectProposedSize.Height = e.Y - this.showImage_startDraggingPoint.Y + this.showImage_startSize.Height;
            showImage.Size = showImage_rectProposedSize.Size;
        }

        #endregion

        #region RMB

        private void RMB_output_refresh_Click (object sender, EventArgs e) { find();              }
        private void RMB_output_open_Click    (object sender, EventArgs e) { output_open();       }
        private void RMB_output_explorer_Click(object sender, EventArgs e) { output_explorer();   }
        private void RMB_output_copy_Click    (object sender, EventArgs e) { output_copy();       }
        private void RMB_output_delete_Click  (object sender, EventArgs e) { output_deleteFile(); }

        #endregion
        
    }
}
