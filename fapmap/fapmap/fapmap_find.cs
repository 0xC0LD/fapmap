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

            output_RMB.Renderer = new fapmap_res.FapmapColors.fToolStripProfessionalRenderer();
        }

        private void fapmap_find_Load(object sender, EventArgs e)
        {
            showImage_dispose();
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

            DirectoryInfo mainDir = new DirectoryInfo(fapmap.GlobalVariables.Path.Dir.MainFolder);
            DirectoryInfo[] dirs = mainDir.GetDirectories("*.*", SearchOption.AllDirectories);
            FileInfo[] files = mainDir.GetFiles("*.*", SearchOption.AllDirectories);

            List<FileSystemInfo> dirsNfiles = new List<FileSystemInfo>(dirs.Length + files.Length);
            dirsNfiles.AddRange(dirs);
            dirsNfiles.AddRange(files);

            bool checkCase = cb_case.Checked;
            string input = txt_searchBox.Text;

            string[] allKeywords = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            List<string> only = new List<string>();
            List<string> can = new List<string>();
            List<string> ignore = new List<string>();
            foreach(string keyword in allKeywords)
            {
                if      (keyword.StartsWith("-")) { ignore.Add(keyword.Remove(0, 1)); }
                else if (keyword.StartsWith("~")) { can.Add(keyword.Remove(0, 1));    }
                else                              { only.Add(keyword);                }
            }

            List<ListViewItem> itemsToAdd = new List<ListViewItem>();

            CultureInfo ci = new CultureInfo("");
            foreach (FileSystemInfo item in dirsNfiles)
            {
                string i = item.FullName.Remove(0, (fapmap.GlobalVariables.Path.Dir.MainFolder + "\\").Length);

                bool addIt = true;
                
                if (can.Count > 0)
                {
                    bool add = false;
                    foreach (string key in can)
                    {
                        if ((checkCase ? i.Contains(key) : (ci.CompareInfo.IndexOf(i, key, CompareOptions.IgnoreCase) >= 0)))
                        { add = true; break; }
                    }
                    if (!add) { addIt = false; }
                }
                if (!addIt) { continue; }
                
                foreach (string key in only)
                {
                    if ((checkCase ? !i.Contains(key) : !(ci.CompareInfo.IndexOf(i, key, CompareOptions.IgnoreCase) >= 0)))
                    { addIt = false; break; }
                }
                if (!addIt) { continue; }

                foreach (string key in ignore)
                {
                    if ((checkCase ? i.Contains(key) : (ci.CompareInfo.IndexOf(i, key, CompareOptions.IgnoreCase) >= 0)))
                    { addIt = false; break; }
                }
                if (!addIt) { continue; }

                string text = item.FullName;
                int imageIndex = 0;

                Color fc = output.ForeColor;
                if (Directory.Exists(item.FullName))
                {
                    DirectoryInfo di = new DirectoryInfo(item.FullName);

                    // set name
                    if (cb_fileNameOnly.Checked) { text = di.Parent.Name + "\\" + di.Name; }

                    // set color
                    if      (di.Attributes.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { fc = Color.MediumPurple;  }
                    else if (di.Attributes.HasFlag(FileAttributes.Hidden))                         { fc = Color.SteelBlue;     }
                    else                                                                           { fc = Color.PaleVioletRed; }

                    // set image
                    imageIndex = 0;
                }
                else if (File.Exists(item.FullName))
                {
                    FileInfo fi = new FileInfo(item.FullName);

                    // set name
                    if (cb_fileNameOnly.Checked) { text = fi.Directory.Name + "\\" + fi.Name; }

                    // set color
                    if      (fi.Attributes.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { fc = Color.MediumPurple;  }
                    else if (fi.Attributes.HasFlag(FileAttributes.Hidden))                         { fc = Color.SteelBlue;     }
                    else                                                                           { fc = Color.PaleVioletRed; }

                    // set image
                    string ext = fi.Extension.ToLower();
                    if (output_icons.Images.ContainsKey(ext))
                    {
                        imageIndex = output_icons.Images.IndexOfKey(ext);
                    }
                    else
                    {
                        output_icons.Images.Add(ext, System.Drawing.Icon.ExtractAssociatedIcon(item.FullName));
                        imageIndex = output_icons.Images.Count - 1;
                    }
                }
                else { addIt = false; }

                if (addIt)
                {
                    itemsToAdd.Add(new ListViewItem(new string[] { (itemsToAdd.Count + 1).ToString(), text }) { Name = item.FullName, ForeColor = fc, ImageIndex = imageIndex });
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
        
        private void findButton_Click(object sender, EventArgs e)
        {
            find();
        }

        private void txt_searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter: find(); e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Escape: this.Close(); break;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Q: cb_showImage.Checked    = !cb_showImage.Checked;    e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.E: cb_case.Checked         = !cb_case.Checked;         e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.D: cb_fileNameOnly.Checked = !cb_fileNameOnly.Checked; e.Handled = true; e.SuppressKeyPress = true; break;
                }
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                txt_searchBox.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private bool output_ctrl = false;
        private bool output_shift = false;
        private void output_KeyDown(object sender, KeyEventArgs e)
        {
            output_ctrl = e.Control;
            output_shift = e.Shift;

            switch (e.KeyCode)
            {
                case Keys.F5:     find();          e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Enter:  output_open();   e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Escape: this.Close();    e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Delete: output_delete(); e.Handled = true; e.SuppressKeyPress = true; break;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R: find();                                       e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.W: output_open();                                e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.E: output_explorer();                            e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.S: output_explorer2();                           e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.C: output_copy();                                e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.Q: cb_showImage.Checked = !cb_showImage.Checked; e.Handled = true; e.SuppressKeyPress = true; break;
                }
            }
        }
        private void output_KeyUp(object sender, KeyEventArgs e)
        {
            output_ctrl = false;
            output_shift = false;
        }
        private void output_LostFocus(object sender, System.EventArgs e)
        {
            output_ctrl = false;
            output_shift = false;
        }

        private int links_fontSize_min = 6;
        private int links_fontSize_max = 30;
        private int links_fontSize = 8;
        private void output_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!output_ctrl) { return; }
            
            int last = links_fontSize;
            if (e.Delta > 0) { links_fontSize += (output_shift ? 6 : 2); }
            else             { links_fontSize -= (output_shift ? 6 : 2); }

            if      (links_fontSize < links_fontSize_min) { links_fontSize = links_fontSize_min; }
            else if (links_fontSize > links_fontSize_max) { links_fontSize = links_fontSize_max; }
            if      (links_fontSize == last)              { return; }

            output.Font = new Font(output.Font.FontFamily, links_fontSize, output.Font.Style);
            output.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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

        private void showMedia_Show(bool show)
        {
            if (show)
            {
                splitContainer.Panel2.Show();
                splitContainer.Panel2Collapsed = false;
            }
            else
            {
                splitContainer.Panel2.Hide();
                splitContainer.Panel2Collapsed = true;
            }
        }

        private bool showImage_disposed = false;
        private void showImage_dispose()
        {
            if (showImage_disposed) { return; }

            showImage.Image = Properties.Resources.image;
            showMedia_Show(false);
            GC.Collect();
            showImage_disposed = true;
        }
        private void output_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in output.SelectedItems)
            {
                if (lvi.Name == null) { continue; }
                string item = lvi.Name;
                if (string.IsNullOrEmpty(item)) { continue; }

                if (!File.Exists(item) && !Directory.Exists(item)) { lvi.Remove(); return; }

                if (cb_showImage.Checked)
                {
                    showImage_dispose();

                    if (File.Exists(item))
                    {
                        if (fapmap.GlobalVariables.FileTypes.Image.Contains(new FileInfo(item).Extension))
                        {
                            showImage.Image = Image.FromFile(item);
                            showMedia_Show(true);
                            showImage_disposed = false;
                        }
                    }
                }
            }
        }
        
        private void cb_showImage_CheckedChanged(object sender, EventArgs e)
        {
            if (!cb_showImage.Checked) { showImage_dispose(); }
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
