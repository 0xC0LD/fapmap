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
        
        private void load_images()
        {
            try
            {
                pb0.LoadAsync(fapmap.GlobalVariables.CreditsImageUrls.web_img_url_0);
                pb3.LoadAsync(fapmap.GlobalVariables.CreditsImageUrls.web_img_url_1);
                pb2.LoadAsync(fapmap.GlobalVariables.CreditsImageUrls.web_img_url_2);
                pb1.LoadAsync(fapmap.GlobalVariables.CreditsImageUrls.web_img_url_3);
            }
            catch (Exception) { }
        }

        private void FocusEnter(object sender)
        {
            Control pb = sender as Control;
            if (pb.Tag == null) { return; }
            if (pb.Tag.ToString() == "NULL") { return; }
            label_status.Text = pb.Tag.ToString();
        }
        private void FocusLeave()
        {
            label_status.Text = "...";
        }
        private void control_Enter(object sender, EventArgs e)
        {
            FocusEnter(sender);
        }
        private void control_Leave(object sender, EventArgs e)
        {
            FocusLeave();
        }
        private void control_MouseEnter(object sender, EventArgs e)
        {
            FocusEnter(sender);
        }
        private void control_MouseLeave(object sender, EventArgs e)
        {
            FocusLeave();
        }
        
        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
