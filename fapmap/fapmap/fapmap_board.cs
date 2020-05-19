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

            board_RMB.Renderer = new fapmap_res.FapMapColors.FapMapToolStripRenderer(Color.FromArgb(128, 128, 255));
        }
        
        private void fapmap_board_Load(object sender, EventArgs e)
        {
            board_load();
        }

        private Mutex faviconDownloadMutex = new Mutex();
        private void board_load()
        {
            //IF BOARD.DLL DOESN'T EXIST
            fapmap.nestFiles();
            
            Directory.CreateDirectory(fapmap.GlobalVariables.Path.Dir.FavIcons);

            //get rid
            board.Items.Clear();
            favicons.Images.Clear();
            
            List<ListViewItem> items = new List<ListViewItem>();

            List<string> icons = new List<string>();
            if (Directory.Exists(fapmap.GlobalVariables.Path.Dir.FavIcons))
            { icons.AddRange(Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.FavIcons)); }

            int lineCount = 0;
            int itemCount = 0;
            foreach (string line in File.ReadAllLines(fapmap.GlobalVariables.Path.File.Board))
            {
                lineCount++;
                if (string.IsNullOrEmpty(line) || line.StartsWith(fapmap.GlobalVariables.Settings.Common.Comment2)) { continue; }

                string[] BoardIndex = line.Split(fapmap.GlobalVariables.Settings.Common.Split);

                if (BoardIndex.Length != 3)
                {
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, fapmap.GlobalVariables.Path.File.Board + " (line: " + lineCount + ")");
                    MessageBox.Show("Something is wrong with the " + fapmap.GlobalVariables.Path.File.Board + " file on line: " + lineCount, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                itemCount++;
                string number = itemCount.ToString();
                string type = BoardIndex[0];
                string name = BoardIndex[1];
                string url = BoardIndex[2];

                ListViewItem lvi = new ListViewItem(new string[] { number, name, url })
                {
                    Name = url,
                    ImageKey = url,
                    ForeColor = System.Drawing.ColorTranslator.FromHtml(type)
                };

                // get icon
                Image img = null;
                try
                {
                    foreach (string icon in icons)
                    {
                        if (url.Contains(Path.GetFileNameWithoutExtension(icon)))
                            img = Image.FromFile(icon);
                    }

                    if (img == null)
                    {
                        foreach (string icon in icons)
                        {
                            if (new System.Globalization.CultureInfo("").CompareInfo.IndexOf(url, Path.GetFileNameWithoutExtension(icon), System.Globalization.CompareOptions.IgnoreCase) >= 0)
                                img = Image.FromFile(icon);
                        }
                    }
                }
                catch (Exception) { }

                // download icon
                if (fapmap.GlobalVariables.Settings.CheckBoxes.LinksGetSiteFavicon && img == null)
                {
                    new Thread(() =>
                    {
                        faviconDownloadMutex.WaitOne();
                        try
                        {
                            if (fapmap.downloadFavicon(url, out string path))
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    lvi.ImageKey = url;
                                    Image img2 = Image.FromFile(path);
                                    favicons.Images.Add(url, img2);
                                    img2.Dispose();
                                });
                            }
                        }
                        catch (Exception) { }
                        faviconDownloadMutex.ReleaseMutex();
                    })
                    { IsBackground = true }.Start();
                }

                // set icon
                if (img != null)
                {
                    favicons.Images.Add(url, img);
                    img.Dispose();
                }

                //ADD ITEM
                items.Add(lvi);
            }

            board.Items.AddRange(items.ToArray());

            //auto resize
            board.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private void board_open(bool close)
        {
            if (board.SelectedItems == null) { return; }
            if (board.SelectedItems.Count == 0) { return; }

            foreach (ListViewItem item in board.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string text = item.Name;
                if (string.IsNullOrEmpty(text)) { continue; }
                fapmap.Incognito(text);
            }

            if (close) { this.Close(); }
        }
        private void board_copy()
        {
            string clip = string.Empty;
            foreach (ListViewItem item in board.SelectedItems)
            {
                clip += item == board.SelectedItems[board.SelectedItems.Count - 1] ? item.Name : item.Name + Environment.NewLine;
            }
            if (!string.IsNullOrEmpty(clip)) { System.Windows.Forms.Clipboard.SetText(clip); }

            this.Close();
        }
        private void board_edit()
        {
            fapmap.Open(fapmap.GlobalVariables.Path.File.Board);
        }

        private bool board_ctrl = false;
        private bool board_shift = false;
        private void board_KeyDown(object sender, KeyEventArgs e)
        {
            board_ctrl = e.Control;
            board_shift = e.Shift;

            switch (e.KeyCode)
            {
                case Keys.Enter:  board_open(true); e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.F5:     board_load();     e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Escape: this.Close();     e.Handled = true; e.SuppressKeyPress = true; break;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R: board_load();      e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.Q: board_open(false); e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.W: board_open(true);  e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.C: board_copy();      e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.E: board_edit();      e.Handled = true; e.SuppressKeyPress = true; break;
                }
            }

            bool isNavigationKey = false;

            switch (e.KeyCode)
            {
                case Keys.Up:       isNavigationKey = true; break;
                case Keys.Down:     isNavigationKey = true; break;
                case Keys.Left:     isNavigationKey = true; break;
                case Keys.Right:    isNavigationKey = true; break;
                case Keys.PageUp:   isNavigationKey = true; break;
                case Keys.PageDown: isNavigationKey = true; break;
            }

            if (!isNavigationKey && !e.Control && !e.Shift)
            {
                ListViewItem s = board.SelectedItems.Count > 0 ? board.SelectedItems[0] : null;
                
                foreach (ListViewItem lvi in board.Items)
                {
                    if (board.SelectedItems.Count > 0 && (lvi == board.SelectedItems[0] || lvi.Index < board.SelectedItems[0].Index)) { continue; }

                    if (lvi.SubItems[1].Text.ToLower().StartsWith(new KeysConverter().ConvertToString(e.KeyCode).ToLower()))
                    {
                        board.Items[lvi.Index].Selected = true;
                        board.Items[lvi.Index].Focused = true;
                        board.EnsureVisible(lvi.Index);
                        board.Select();
                        break;
                    }
                }
                
                if (board.SelectedItems.Count > 0 && s == board.SelectedItems[0]) { board.SelectedItems.Clear(); }
                e.Handled = true; e.SuppressKeyPress = true;
            }
        }
        private void board_KeyUp(object sender, KeyEventArgs e)
        {
            board_ctrl = false;
            board_shift = false;
        }
        private void board_LostFocus(object sender, System.EventArgs e)
        {
            board_ctrl = false;
            board_shift = false;
        }

        private int links_fontSize_min = 8;
        private int links_fontSize_max = 30;
        private int links_fontSize = 10;
        private void board_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!board_ctrl) { return; }
            
            int last = links_fontSize;
            if (e.Delta > 0) { links_fontSize += (board_shift ? 6 : 2); }
            else             { links_fontSize -= (board_shift ? 6 : 2); }

            if      (links_fontSize < links_fontSize_min) { links_fontSize = links_fontSize_min; }
            else if (links_fontSize > links_fontSize_max) { links_fontSize = links_fontSize_max; }
            if      (links_fontSize == last)              { return; }

            board.Font = new Font(board.Font.FontFamily, links_fontSize, board.Font.Style);
            board.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        
        private void board_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { return; }

            if (board.SelectedItems.Count > 0)
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left) { board_open(false); return; }
                else if (e.Button == MouseButtons.Middle) { board_open(true); return; }

                foreach (ListViewItem item in board.SelectedItems)
                {
                    if (item.Name == null) { continue; }
                    string text = item.Name;
                    if (string.IsNullOrEmpty(text)) { continue; }

                    if (!string.IsNullOrEmpty(text))
                    {
                        this.board.DoDragDrop(new System.Windows.Forms.DataObject(System.Windows.Forms.DataFormats.StringFormat, text), DragDropEffects.Copy);
                    }
                }
            }
        }
        private void board_DragOver(object sender, DragEventArgs e)
        {
            if (board.SelectedItems.Count == 0) { return; }
            e.Effect = DragDropEffects.Copy;
        }
        
        private void board_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void board_RMB_refresh_Click(object sender, EventArgs e)
        {
            board_load();
        }
        private void board_RMB_openAndExit_Click(object sender, EventArgs e)
        {
            board_open(true);
        }
        private void board_RMB_open_Click(object sender, EventArgs e)
        {
            board_open(false);
        }
        private void board_RMB_copy_Click(object sender, EventArgs e)
        {
            board_copy();
        }
        private void board_RMB_edit_Click(object sender, EventArgs e)
        {
            board_edit();
        }
        
    }
}
