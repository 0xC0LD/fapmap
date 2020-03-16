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

namespace fapmap
{
    public partial class fapmap_dirSelect : Form
    {
        public fapmap_dirSelect()
        {
            InitializeComponent();

            treeView_RMB.Renderer = new fapmap_res.FapmapColors.fToolStripProfessionalRenderer();
        }
        
        public string outPath = string.Empty;
        public string preSelectedPath = string.Empty;
        private void fapmap_downloadPathSelect_Load(object sender, EventArgs e)
        {
            load();

            if (treeView.Nodes.Count >= 1)
            {
                treeView.Nodes[0].Expand();
            }

            if (!string.IsNullOrEmpty(preSelectedPath) && Directory.Exists(preSelectedPath))
            {
                string path = new DirectoryInfo(preSelectedPath).FullName;
                
                TreeNode[] nodes = treeView.Nodes.Find(path, true);
                if (nodes.Length > 0)
                {
                    treeView.SelectedNode = nodes[0];
                }
            }

            this.ActiveControl = treeView;
        }

        private void load()
        {
            treeView.Nodes.Clear();
            treeView.Nodes.Add(createDirNode(new DirectoryInfo(fapmap.GlobalVariables.Path.Dir.MainFolder)));
        }
        private TreeNode createDirNode(DirectoryInfo di)
        {
            TreeNode node_dir = new TreeNode() { Text = di.Name, Name = di.FullName, ImageIndex = 0, SelectedImageIndex = 0 };
            foreach (DirectoryInfo directory in di.GetDirectories()) { node_dir.Nodes.Add(createDirNode(directory)); }
            return node_dir;
        }
        
        private void confirm()
        {
            if (!string.IsNullOrEmpty(txt_path.Text) && Directory.Exists(txt_path.Text))
            {
                outPath = txt_path.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView.SelectedNode.Name == null) { return; }
            string text = treeView.SelectedNode.Name;
            if (string.IsNullOrEmpty(text)) { return; }
            txt_path.Text = text;
        }
        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:     load();    e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Space:  confirm(); e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Escape: cancel();  e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Enter:
                    {
                        try
                        {
                            if (treeView.SelectedNode.IsExpanded)
                            { treeView.SelectedNode.Collapse(); }
                            else
                            { treeView.SelectedNode.Expand(); }
                        }
                        catch (Exception) { }

                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        break;
                    }
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R: load(); e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.W: confirm();              e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.Q: treeView.CollapseAll(); e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.E: treeView.ExpandAll();   e.Handled = true; e.SuppressKeyPress = true; break;
                }
            }
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            confirm();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cancel();
        }

        // RMB
        private void treeView_RMB_reload_Click(object sender, EventArgs e)
        {
            load();
        }
        private void faftv_RMB_select_Click(object sender, EventArgs e)
        {
            confirm();
        }
        private void treeView_RMB_collapseTree_Click(object sender, EventArgs e)
        {
            treeView.CollapseAll();
        }
        private void treeView_RMB_expandTree_Click(object sender, EventArgs e)
        {
            treeView.ExpandAll();
        }

        private void txt_path_TextChanged(object sender, EventArgs e)
        {
            txt_path.ForeColor = Directory.Exists(txt_path.Text) ? Color.SlateBlue : Color.DarkOrchid;
        }

        
    }
}
