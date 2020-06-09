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
    public partial class fapmap_fileExistsDialog : Form
    {
        public fapmap_fileExistsDialog()
        {
            InitializeComponent();
        }
        
        public string filePath = string.Empty;
        private void fapmap_fileExistsDialog_Load(object sender, EventArgs e)
        {
            if (!File.Exists(filePath)) { return; }
            
            FileInfo fi = new FileInfo(filePath);
            info.Text =
                fi.Name                                                     + Environment.NewLine +
                fi.Extension                                                + Environment.NewLine +
                fi.Directory.Name                                           + Environment.NewLine +
                fapmap.ROund(fi.Length) + " (" + fi.Length + " bytes" + ")" + Environment.NewLine +
                fi.CreationTime                                             + Environment.NewLine;
                ;

            if (fapmap.GlobalVariables.FileTypes.Image.Contains(fi.Extension.ToLower()))
            {
                Image img = fapmap_res.ImageFast.FromFile(fi.FullName);
                Bitmap bmp = new Bitmap(img);
                img.Dispose();
                showImage.Image = bmp;
                return;
            }

            if (fapmap.GlobalVariables.FileTypes.Video.Contains(fi.Extension.ToLower()))
            {
                string dest = fapmap.GlobalVariables.Path.Dir.Cache + "\\" + fapmap.getFileId(fi).ToString() + ".tmp";

                if (File.Exists(dest))
                {
                    Image img = fapmap_res.ImageFast.FromFile(dest);
                    Bitmap bmp = new Bitmap(img);
                    img.Dispose();
                    showImage.Image = bmp;
                    return;
                }
            }

            showImage.Image = Icon.ExtractAssociatedIcon(fi.FullName).ToBitmap();
        }

        #region fx

        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        #endregion

        private void replace()
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        private void newName()
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private void cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void btn_replace_Click(object sender, EventArgs e)
        {
            replace();
        }
        private void btn_newName_Click(object sender, EventArgs e)
        {
            newName();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cancel();
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath)) { fapmap.Open(filePath); }
        }
        private void btn_selectFileInExplorer_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath)) { fapmap.OpenAndSelectInExplorer(filePath); }
        }
        private void btn_openInInfo_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath)) { fapmap.OpenProperties(filePath); }
        }
        private void btn_delFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath)) { fapmap.TrashFile(filePath); }
        }
    }
}
