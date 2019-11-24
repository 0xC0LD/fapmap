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
    public partial class fapmap_board : Form
    {
        public fapmap_board()
        {
            InitializeComponent();

            board_RMB.Renderer = new fapmap_res.color.fToolStripProfessionalRenderer();
        }

        private void fapmap_board_Load(object sender, EventArgs e)
        {
            fapmap.fapmap_cd();
            board_load();
        }

        private void board_load()
        {
            //IF BOARD.DLL DOESN'T EXIST
            fapmap.file_export_all();
            
            Directory.CreateDirectory(fapmap.GlobalVariables.Path.Dir.FavIcons);

            //get rid
            board.Items.Clear();
            favicons.Images.Clear();

            //REMOVE NULL LINES
            using (FileStream fs = new FileStream(fapmap.GlobalVariables.Path.File.Board, FileMode.Open))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    foreach (string line in fapmap.SafeReadLines(fapmap.GlobalVariables.Path.File.Board))
                    {
                        if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line) && line != "")
                        {
                            tw.WriteLine(line);
                        }
                    }
            
                    tw.Flush();                // Flush the writer in order to get a correct stream position for truncating
                    fs.SetLength(fs.Position); // Set the stream length to the current position in order to truncate leftover text
                }
            }

            List<string> lines = File.ReadAllLines(fapmap.GlobalVariables.Path.File.Board).ToList();
            List<ListViewItem> items = new List<ListViewItem>();
            int index = -1;
            int countLine = 0;
            foreach (var line in lines)
            {
                countLine++;
                if (!(string.IsNullOrEmpty(line) || line.StartsWith(fapmap.GlobalVariables.Settings.Common.Comment))) //IGNORE COMMENTS
                {
                    string[] BoardIndex = line.Split(fapmap.GlobalVariables.Settings.Common.Split);
                    switch (BoardIndex.Length)
                    {
                        case 3:
                            {
                                index++;
                                string number = (index + 1).ToString();
                                string type = BoardIndex[0];
                                string name = BoardIndex[1];
                                string url = BoardIndex[2];

                                ListViewItem lvi = new ListViewItem(new string[] { number, name, url }) { Tag = url };

                                switch (type)
                                {
                                    case "SITE": lvi.ForeColor = System.Drawing.Color.SlateBlue; break;
                                    case "NLIO": lvi.ForeColor = System.Drawing.Color.Teal; break;
                                    case "DOWN": lvi.ForeColor = System.Drawing.Color.ForestGreen; break;
                                    case "USER": lvi.ForeColor = System.Drawing.Color.MediumPurple; break;
                                    case "BLOG": lvi.ForeColor = System.Drawing.Color.SteelBlue; break;
                                    case "STAR": lvi.ForeColor = System.Drawing.Color.RoyalBlue; break;

                                    default: lvi.ForeColor = System.Drawing.Color.Silver; break; //default = SITE
                                }
                                
                                lvi.ImageIndex = index;
                                try
                                {
                                    string[] icons = Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.FavIcons);
                                
                                    if (icons.Length > 0)
                                    {
                                        bool added = false;
                                        foreach (string icon in icons)
                                        {
                                            FileInfo fi = new FileInfo(icon);
                                
                                            if (url.Contains(fi.Name.Replace(fi.Extension, "")))
                                            {
                                                favicons.Images.Add(index.ToString(), Image.FromFile(fi.FullName));
                                                added = true;
                                                break;
                                            }
                                        }
                                
                                        //LASTLY TRY THE URL
                                        if (!added)
                                        {
                                            foreach (string file in icons)
                                            {
                                                FileInfo fi = new FileInfo(file);
                                                if (new System.Globalization.CultureInfo("").CompareInfo.IndexOf(url, fi.Name.Replace(fi.Extension, ""), System.Globalization.CompareOptions.IgnoreCase) >= 0)
                                                {
                                                    favicons.Images.Add(index.ToString(), Image.FromFile(fi.FullName));
                                                    added = true;
                                                    break;
                                                }
                                            }
                                        }

                                        //if all fails add null icon
                                        if (!added)
                                        {
                                            favicons.Images.Add(index.ToString(), new Bitmap(16, 16));
                                        }
                                    }
                                }
                                catch (Exception) { }

                                //ADD ITEM
                                items.Add(lvi);

                                break;
                            }

                        default:
                            {
                                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.LOAD, fapmap.GlobalVariables.Path.File.Board + " (line: " + countLine + ")");
                                MessageBox.Show("Something is wrong with the " + fapmap.GlobalVariables.Path.File.Board + " file on line: " + countLine, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                                //break;
                            }
                    }
                }
            }

            board.Items.AddRange(items.ToArray());

            //auto resize
            foreach (ColumnHeader column in board.Columns) { column.Width = -2; }
        }

        private void board_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); return;  }
            
            if (e.Control && e.KeyCode == Keys.R || e.KeyCode == Keys.F5)
            {
                board_load();
            }
            else if (e.Control && e.KeyCode == Keys.Q)
            {
                open(false);
            }
            else if(e.KeyCode == Keys.Enter || e.Control && e.KeyCode == Keys.W)
            {
                open(true);
            }
            else if(e.Control && e.KeyCode == Keys.C)
            {
                copy();
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                edit();
            }
            else if (e.Control != true && e.Shift != true)
            {
                board.SelectedItems.Clear();
                foreach (ListViewItem lvi in board.Items)
                {
                    if (lvi.SubItems[1].Text.StartsWith(new KeysConverter().ConvertToString(e.KeyCode)) //check for UPPER KEYS
                     || lvi.SubItems[1].Text.StartsWith(new KeysConverter().ConvertToString(e.KeyCode).ToLower())) //check for lower keys
                    {
                        board.Items[lvi.Index].Selected = true;
                        board.Select();
                    }
                }
            }

            e.SuppressKeyPress = true;
        }
        private void open(bool close)
        {
            if (board.SelectedItems != null)
            {
                foreach (ListViewItem item in board.SelectedItems)
                {
                    fapmap.Incognito(item.Tag.ToString());
                }
            }

            if (close) { this.Close(); }
        }
        private void copy()
        {
            if (board.SelectedItems != null)
            {
                foreach (ListViewItem item in board.SelectedItems)
                {
                    System.Windows.Forms.Clipboard.SetText(item.Tag.ToString());
                }
            }

            this.Close();
        }
        private void edit()
        {
            Process.Start("notepad.exe", fapmap.GlobalVariables.Path.File.Board);
        }

        #region fx

        int gListView1LostFocusItem = -1;
        private void board_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // If this item is the selected item
            if (e.Item.Selected)
            {
                // If the selected item just lost the focus
                if (gListView1LostFocusItem == e.Item.Index)
                {
                    // Set the colors to whatever you want (I would suggest
                    // something less intense than the colors used for the
                    // selected item when it has focus)
                    e.Item.ForeColor = Color.Purple;
                    e.Item.BackColor = Color.FromArgb(20, 20, 20);

                    // Indicate that this action does not need to be performed
                    // again (until the next time the selected item loses focus)
                    gListView1LostFocusItem = -1;
                }
                else if (board.Focused)  // If the selected item has focus
                {
                    // Set the colors to the normal colors for a selected item
                    e.Item.ForeColor = Color.Purple;
                    e.Item.BackColor = Color.FromArgb(20, 20, 20);
                }
            }
            else
            {
                // Set the normal colors for items that are not selected
                e.Item.ForeColor = board.ForeColor;
                e.Item.BackColor = board.BackColor;
            }

            e.DrawBackground();
            e.DrawText();
        }
        private void board_Leave(object sender, EventArgs e)
        {
            // Set the global int variable (gListView1LostFocusItem) to
            // the index of the selected item that just lost focus
            gListView1LostFocusItem = board.FocusedItem.Index;
        }

        #endregion

        private void board_DragOver(object sender, DragEventArgs e)
        {
            if (board.SelectedItems.Count != 0)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void board_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { return; }

            if (board.SelectedItems.Count > 0)
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left) { open(false); return; }
                else if (e.Button == MouseButtons.Middle) { open(true); return; }

                foreach (ListViewItem lvi in board.SelectedItems)
                {
                    string text = lvi.Tag.ToString();

                    if (!string.IsNullOrEmpty(text))
                    {
                        this.board.DoDragDrop(new System.Windows.Forms.DataObject(System.Windows.Forms.DataFormats.StringFormat, text), DragDropEffects.Copy);
                    }
                }
            }
        }
        private void board_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (board.SelectedItems.Count > 0)
            {
                this.Text = board.SelectedItems.Count >= 2 ?
                    "Selected " + board.SelectedItems.Count.ToString() + " item(s)"
                    : board.SelectedItems[0].Tag.ToString();
            }
            else
            {
                this.Text = "FAPMAP - URL BOARD";
            }
        }

        private void board_RMB_refresh_Click(object sender, EventArgs e)
        {
            board_load();
        }
        private void board_RMB_openAndExit_Click(object sender, EventArgs e)
        {
            open(true);
        }
        private void board_RMB_open_Click(object sender, EventArgs e)
        {
            open(false);
        }
        private void board_RMB_copy_Click(object sender, EventArgs e)
        {
            copy();
        }
        private void board_RMB_edit_Click(object sender, EventArgs e)
        {
            edit();
        }
    }
}
