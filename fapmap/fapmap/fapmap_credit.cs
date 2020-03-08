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
                pb0.LoadAsync(web_img_url_0);
                pb3.LoadAsync(web_img_url_1);
                pb2.LoadAsync(web_img_url_2);
                pb1.LoadAsync(web_img_url_3);
            }
            catch (Exception) { }
        }
        private void control_MouseEnter(object sender, EventArgs e)
        {
            Control pb = sender as Control;
            if (pb.Tag == null) { return; }
            if (pb.Tag.ToString() == "NULL") { return; }
            label_status.Text = pb.Tag.ToString();
        }
        private void control_MouseLeave(object sender, EventArgs e)
        {
            label_status.Text = "...";
        }
        
        private void link_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control pb = sender as Control;
                if (pb.Tag == null) { return; }
                string text = pb.Tag.ToString();
                if (string.IsNullOrEmpty(text)) { return; }
                if (pb.Tag.ToString() == "NULL") { return; }
                fapmap.Incognito(text);
            }
        }
    }
}
