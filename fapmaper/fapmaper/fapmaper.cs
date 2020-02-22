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
//using IWshRuntimeLibrary;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace fapmaper
{
    public partial class fapmaper : Form
    {
        public fapmaper()
        {
            InitializeComponent();
        }

        private void fapmaper_Load(object sender, EventArgs e)
        {
            txt_output.Text = ""; //clear output

            txt_path.Focus();
            txt_path.SelectionLength = 1;
            this.ActiveControl = txt_path;
        }

        private bool ran = false;
        private void btn_install_Click(object sender, EventArgs e)
        {
            if (ran) { return; }
            ran = true;
            new Thread(SetUp) { IsBackground = true }.Start();
        }
        
        private void SetUp()
        {
            string path = txt_path.Text;
            Directory.CreateDirectory(path);
            DirectoryInfo di = new DirectoryInfo(path);
            
            //COPY ALL FILES
            foreach (string file_in_data in Directory.GetFiles(".\\data"))
            {
                if (File.Exists(file_in_data))
                {
                    FileInfo fid = new FileInfo(file_in_data);

                    string target = di.FullName + "\\" + fid.Name;

                    if (File.Exists(target)) { File.Delete(target); }
                    File.Copy(fid.FullName, target);
                    txt_output.Text += "COPIED: " + fid.FullName + " -> " + target + Environment.NewLine;
                }
            }
            
            // create shortcut
            string name = "LockedFolder.lnk";
            string targ = di.FullName + "\\LockedFolder.exe";
            string work = di.FullName;
            string icon = di.FullName + "\\lock.ico";
            CreateShortcut(name, targ, work, icon);
            txt_output.Text += "CREATED: " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "LockedFolder.lnk" + Environment.NewLine;
            
            // hide folder
            if (cb_hideFolder.Checked == true)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    FileName = "attrib.exe",
                    Arguments = "+s +h " + txt_path.Text
                };
                process.StartInfo = startInfo;
                process.Start();

                txt_output.Text += "HIDDEN: " + txt_path.Text + Environment.NewLine;
            }
            
            txt_output.Text += "Done!" + Environment.NewLine;

            label_status.Text = "Exiting Application in 10...";
            Thread.Sleep(1000);
            label_status.Text = "Exiting Application in 9...";
            Thread.Sleep(1000);
            label_status.Text = "Exiting Application in 8...";
            Thread.Sleep(1000);
            label_status.Text = "Exiting Application in 7...";
            Thread.Sleep(1000);
            label_status.Text = "Exiting Application in 6...";
            Thread.Sleep(1000);
            label_status.Text = "Exiting Application in 5...";
            Thread.Sleep(1000);
            label_status.Text = "Exiting Application in 4...";
            Thread.Sleep(1000);
            label_status.Text = "Exiting Application in 3...";
            Thread.Sleep(1000);
            label_status.Text = "Exiting Application in 2...";
            Thread.Sleep(1000);
            label_status.Text = "Exiting Application in 1...";
            Thread.Sleep(1000);
            label_status.Text = "Exiting Application...";
            this.Close();
        }

        private void CreateShortcut(string name, string target, string workingdir, string ico)
        {
            IWshRuntimeLibrary.WshShell wsh = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + name) as IWshRuntimeLibrary.IWshShortcut;
            shortcut.Arguments = "";
            shortcut.TargetPath = target;
            // not sure about what this is for
            shortcut.WindowStyle = 1;
            shortcut.Description = "";
            shortcut.WorkingDirectory = workingdir;
            shortcut.IconLocation = ico;
            shortcut.Save();
        }
    }
}
