using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace fapmap
{
    public partial class fapmap_credit : Form
    {
        public fapmap_credit()
        {
            InitializeComponent();
        }

        private void fapmap_credit_Load(object sender, EventArgs e)
        {
            fapmap.fapmap_cd();
            new Thread(load_images) { IsBackground = true }.Start();
        }

        //thumbnails
        private string web_img_url_0 = "https://yt3.ggpht.com/-MpInHIQi5kQ/AAAAAAAAAAI/AAAAAAAAAOo/uMD40-lPnJk/s288-mo-c-c0xffffffff-rj-k-no/photo.jpg";
        private string web_img_url_1 = "https://yt3.ggpht.com/-wmTdd-ozcCw/AAAAAAAAAAI/AAAAAAAAAAA/Jab5AL6CxZ4/s288-mo-c-c0xffffffff-rj-k-no/photo.jpg";
        private string web_img_url_2 = "https://yt3.ggpht.com/-Cz0f2loHk5E/AAAAAAAAAAI/AAAAAAAAAAA/j6ZFt-9xPiA/s288-mo-c-c0xffffffff-rj-k-no/photo.jpg";
        private string web_img_url_3 = "https://yt3.ggpht.com/-iAD_RVsx1I0/AAAAAAAAAAI/AAAAAAAAAAA/aEojIbiyYlA/s288-mo-c-c0xffffffff-rj-k-no/photo.jpg";
        
        private void load_images()
        {
            try
            {
                pb_0.LoadAsync(web_img_url_0);
                pb_1.LoadAsync(web_img_url_1);
                pb_2.LoadAsync(web_img_url_2);
                pb_3.LoadAsync(web_img_url_3);
            }
            catch (Exception) { }
        }
        
        private void picture_click(object sender, EventArgs e)
        {
            try
            {
                Control pb = sender as Control;

                if (pb.Tag.ToString() != "NULL")
                {
                    fapmap.Incognito(pb.Tag.ToString());
                }
            }
            catch (Exception) { }
        }
        private void picture_click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fapmap.Incognito(((Control)sender).Text);
        }

        // private int expand = 5;

        private void picture_MouseEnter(object sender, EventArgs e)
        {
            // //expand
            // Control btn = (Control)sender;
            // btn.Size = new Size(btn.Size.Width + expand, btn.Size.Height + expand);

            this.Text = ((Control)sender).Tag.ToString();
        }
        private void picture_MouseLeave(object sender, EventArgs e)
        {
            // //change back to the size
            // Control btn = (Control)sender;
            // btn.Size = new Size(100, 100);

            this.Text = "FAPMAP - CREDITS";
        }
        
        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
    }
}
