using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fapmap
{
    public partial class fapmap_md5 : Form
    {
        public fapmap_md5()
        {
            InitializeComponent();
        }

        public string pass_path = string.Empty;

        private void fapmap_md5_Load(object sender, EventArgs e)
        {
            if (File.Exists(pass_path)) { txt_md5.Text = fapmap.CalculateMD5(pass_path); }

            txt_md5.Focus();
            this.ActiveControl = txt_md5;
        }

        #region fx

        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        #endregion

        private void btn_booru_api_Click(object sender, EventArgs e)
        {
            fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.API + txt_md5.Text);
        }
        private void btn_booru_rule34xxx_Click(object sender, EventArgs e)
        {
            fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.rule34xxx + txt_md5.Text);
        }
        private void btn_booru_gelbooru_Click(object sender, EventArgs e)
        {
            fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.gelbooru + txt_md5.Text);
        }
        private void btn_booru_danbooru_Click(object sender, EventArgs e)
        {
            fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.danbooru + txt_md5.Text);
        }
        private void btn_booru_yandere_Click(object sender, EventArgs e)
        {
            fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.yandere + txt_md5.Text);
        }
        private void btn_booru_xbooru_Click(object sender, EventArgs e)
        {
            fapmap.Incognito(fapmap.GlobalVariables.BooruSearchMD5.xbooru + txt_md5.Text);
        }

        // DRAG N DROP
        private void txt_md5_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }
        private void txt_md5_DragDrop(object sender, DragEventArgs e)
        {
            txt_md5.Text = (e.Data.GetData(typeof(string)) as string);
        }
    }
}
