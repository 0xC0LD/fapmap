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
        }

        public string path { get; set; }

        private void fapmap_downloadPathSelect_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            treeView.Nodes.Add(createDirNode(new DirectoryInfo(fapmap.GlobalVariables.Path.Dir.MainFolder)));
        }
        private TreeNode createDirNode(DirectoryInfo di)
        {
            TreeNode node_dir = new TreeNode() { Text = di.Name, Name = di.FullName, ImageIndex = 0, SelectedImageIndex = 0 };
            
            foreach (DirectoryInfo directory in di.GetDirectories())
            {
                node_dir.Nodes.Add(createDirNode(directory));
            }

            return node_dir;
        }
        
        private void confirm()
        {
            if (treeView.SelectedNode.Name == null) { return; }
            string text = treeView.SelectedNode.Name;
            if (string.IsNullOrEmpty(text)) { return; }
            path = text;
            this.DialogResult = DialogResult.OK;
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
                case Keys.Space: confirm(); e.Handled = true; e.SuppressKeyPress = true; break;
            }
        }
        private void btn_ok_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { confirm(); }
        }
        private void btn_cancel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { this.DialogResult = DialogResult.Cancel; this.Close(); }
        }
    }
}
