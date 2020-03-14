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
            board_load();
        }

        private void board_load()
        {
            //IF BOARD.DLL DOESN'T EXIST
            fapmap.nestFiles();
            
            Directory.CreateDirectory(fapmap.GlobalVariables.Path.Dir.FavIcons);

            //get rid
            board.Items.Clear();
            favicons.Images.Clear();
            
            List<string> lines = File.ReadAllLines(fapmap.GlobalVariables.Path.File.Board).ToList();
            List<ListViewItem> items = new List<ListViewItem>();

            bool noIcons = false;
            List<string> icons = new List<string>();
            if (Directory.Exists(fapmap.GlobalVariables.Path.Dir.FavIcons))
            { icons.AddRange(Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.FavIcons)); }
            if (icons.Count == 0) { noIcons = true; }

            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];
                
                if (string.IsNullOrEmpty(line) || line.StartsWith(fapmap.GlobalVariables.Settings.Common.Comment)) { continue; }

                string[] BoardIndex = line.Split(fapmap.GlobalVariables.Settings.Common.Split);

                if (BoardIndex.Length != 3)
                {
                    fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.LOAD, fapmap.GlobalVariables.Path.File.Board + " (line: " + i+1 + ")");
                    MessageBox.Show("Something is wrong with the " + fapmap.GlobalVariables.Path.File.Board + " file on line: " + i+1, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                
                string number = (i + 1).ToString();
                string type = BoardIndex[0];
                string name = BoardIndex[1];
                string url = BoardIndex[2];

                ListViewItem lvi = new ListViewItem(new string[] { number, name, url })
                {
                    Name = url,
                    ImageKey = i.ToString()
                };

                switch (type)
                {
                    default:
                    case "SITE": lvi.ForeColor = System.Drawing.Color.SlateBlue; break;
                    case "NLIO": lvi.ForeColor = System.Drawing.Color.Teal; break;
                    case "DOWN": lvi.ForeColor = System.Drawing.Color.ForestGreen; break;
                    case "USER": lvi.ForeColor = System.Drawing.Color.MediumPurple; break;
                    case "BLOG": lvi.ForeColor = System.Drawing.Color.SteelBlue; break;
                    case "STAR": lvi.ForeColor = System.Drawing.Color.RoyalBlue; break;
                }
                
                if (!noIcons)
                {

                    favicons.Images.Add(i.ToString(), ((Func<Image>)(() => {

                        foreach (string icon in icons)
                        {
                            if (url.Contains(Path.GetFileNameWithoutExtension(icon)))
                                return Image.FromFile(icon);
                        }

                        foreach (string icon in icons)
                        {
                            if (new System.Globalization.CultureInfo("").CompareInfo.IndexOf(url, Path.GetFileNameWithoutExtension(icon), System.Globalization.CompareOptions.IgnoreCase) >= 0)
                                return Image.FromFile(icon);
                        }
                        
                        return new Bitmap(16, 16);
                    }))());
                    
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

        private void board_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:  board_open(true); break;
                case Keys.F5:     board_load();     break;
                case Keys.Escape: this.Close();     break;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R: board_load();      break;
                    case Keys.Q: board_open(false); break;
                    case Keys.W: board_open(true);  break;
                    case Keys.C: board_copy();      break;
                    case Keys.E: board_edit();      break;
                }
            }
            
            if (!e.Control && !e.Shift)
            {
                board.SelectedItems.Clear();
                foreach (ListViewItem lvi in board.Items)
                {
                    if (lvi.SubItems[1].Text.StartsWith(new KeysConverter().ConvertToString(e.KeyCode))
                     || lvi.SubItems[1].Text.StartsWith(new KeysConverter().ConvertToString(e.KeyCode).ToLower()))
                    {
                        board.Items[lvi.Index].Selected = true;
                        board.Select();
                    }
                }
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }
        private void board_DragOver(object sender, DragEventArgs e)
        {
            if (board.SelectedItems.Count == 0) { return; }
            e.Effect = DragDropEffects.Copy;
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
