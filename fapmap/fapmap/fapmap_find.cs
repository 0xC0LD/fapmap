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

            output_RMB.Renderer = new fapmap_res.color.fToolStripProfessionalRenderer();
        }

        private void fapmap_find_Load(object sender, EventArgs e)
        {

        }

        #region fx
        
        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
        
        #endregion

        #region functions

        private void find()
        {
            //result
            resultNum.Text = "Searching...";
            
            output.Items.Clear();

            List<string> all = new List<string>();
            all.AddRange(Directory.GetDirectories(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.AllDirectories));
            all.AddRange(Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.MainFolder, "*.*", SearchOption.AllDirectories));

            List<string> keywords = new List<string>();

            if (txt_searchBox.Text.Contains(' ')) { keywords.AddRange(txt_searchBox.Text.Split(' ')); }
            else { keywords.Add(txt_searchBox.Text); }

            List<ListViewItem> itemsToAdd = new List<ListViewItem>();

            foreach (string f in all)
            {
                bool addIt = true;
                foreach (string key in keywords)
                {
                    string file = f.Remove(0, (fapmap.GlobalVariables.Path.Dir.MainFolder + "\\").Length);

                    if ((cb_case.Checked ? !file.Contains(key) : !(new CultureInfo("").CompareInfo.IndexOf(file, key, CompareOptions.IgnoreCase) >= 0)))
                    { addIt = false; break; }
                }

                if (addIt)
                {
                    itemsToAdd.Add(new ListViewItem(new string[] { (itemsToAdd.Count +1).ToString(), f }) { Name = f });
                }
            }

            output.Items.AddRange(itemsToAdd.ToArray());

            // resize
            output.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            //show result
            resultNum.Text = output.Items.Count + " result(s) found!";
        }
        private void output_open()
        {
            foreach(ListViewItem lvi in output.SelectedItems)
            {
                if (lvi.Name == null) { continue; }
                string text = lvi.Name;
                if (string.IsNullOrEmpty(text)) { continue; }

                fapmap.Open(text);
            }
        }
        private void output_explorer()
        {
            foreach (ListViewItem lvi in output.SelectedItems)
            {
                if (lvi.Name == null) { continue; }
                string text = lvi.Name;
                if (string.IsNullOrEmpty(text)) { continue; }

                fapmap.OpenInExplorer(text);
            }
        }
        private void output_explorer2()
        {
            foreach (ListViewItem lvi in output.SelectedItems)
            {
                if (lvi.Name == null) { continue; }
                string text = lvi.Name;
                if (string.IsNullOrEmpty(text)) { continue; }

                fapmap.OpenAndSelectInExplorer(text);
            }
        }
        private void output_copy()
        {
            string clip = string.Empty;
            foreach (ListViewItem item in output.SelectedItems)
            {
                clip += item == output.SelectedItems[output.SelectedItems.Count - 1] ? item.Name : item.Name + Environment.NewLine;
            }
            if (!string.IsNullOrEmpty(clip)) { System.Windows.Forms.Clipboard.SetText(clip); }
        }
        private void output_delete()
        {
            showImage_dispose();

            foreach (ListViewItem lvi in output.SelectedItems)
            {
                if (lvi.Name == null) { continue; }
                string text = lvi.Name;
                if (string.IsNullOrEmpty(text)) { continue; }

                if      (File.Exists(text))      { if (fapmap.TrashFile(text)) { lvi.Remove(); } }
                else if (Directory.Exists(text)) { if (fapmap.TrashDir(text))  { lvi.Remove(); } }
            }
        }

        #endregion

        #region ui events

        private void findButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { find(); }
        }

        private void txt_searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter: find(); e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Escape: this.Close(); break;
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                txt_searchBox.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        
        private void output_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: find(); break;
                case Keys.Enter: output_open(); e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Escape: this.Close(); break;
                case Keys.Delete: output_delete(); break;
            }

            if (e.Control)
            {
                e.Handled = true; e.SuppressKeyPress = true;
                switch (e.KeyCode)
                {
                    case Keys.R: find();             break;
                    case Keys.W: output_open();      break;
                    case Keys.E: output_explorer();  break;
                    case Keys.S: output_explorer2(); break;
                    case Keys.C: output_copy();      break;
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
            foreach (ListViewItem item in output.SelectedItems) { text += item.Name + Environment.NewLine; }
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
            foreach (ListViewItem lvi in output.SelectedItems)
            {
                if (lvi.Name == null) { continue; }
                string item = lvi.Name;
                if (string.IsNullOrEmpty(item)) { continue; }

                if (!File.Exists(item) && !Directory.Exists(item)) { lvi.Remove(); return; }

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

        private void output_RMB_reload_Click  (object sender, EventArgs e)  { find();              }
        private void output_RMB_open_Click    (object sender, EventArgs e)  { output_open();       }
        private void output_RMB_explorer_Click(object sender, EventArgs e)  { output_explorer();   }
        private void output_RMB_explorer2_Click(object sender, EventArgs e) { output_explorer2(); }
        private void output_RMB_copy_Click    (object sender, EventArgs e)  { output_copy();       }
        private void output_RMB_delete_Click  (object sender, EventArgs e)  { output_delete(); }
        
        #endregion

        
    }
}
