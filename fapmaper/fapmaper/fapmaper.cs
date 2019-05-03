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
using IWshRuntimeLibrary;
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
            openFapmap.Visible = false;

            //clear
            statusOutput.Text = "";

            pathToInstall.Focus();
            pathToInstall.SelectionLength = 1;
            this.ActiveControl = pathToInstall;
        }
        
        private void Install_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(SetUp);
            th.IsBackground = true;
            th.Start();
        }

        private void SetUp()
        {
            Install.Enabled = false;
            pathToInstall.ReadOnly = true;

            System.IO.Directory.CreateDirectory(pathToInstall.Text);

            //COPY ALL FILES
            foreach (string file_in_data in Directory.GetFiles(".\\data"))
            {
                if (System.IO.File.Exists(file_in_data))
                {
                    FileInfo fid = new FileInfo(file_in_data);

                    string target = pathToInstall.Text + "\\" + fid.Name;

                    if (System.IO.File.Exists(target) == true)
                    {
                        System.IO.File.Delete(target);
                    }

                    System.IO.File.Copy(fid.FullName, target);
                    statusOutput.Text += "COPIED: " + fid.FullName + " -> " + target + Environment.NewLine;
                }
            }
            
            string name = "LockedFolder.lnk";
            string targ = pathToInstall.Text + "\\LockedFolder.exe";
            string work = pathToInstall.Text;
            string icon = pathToInstall.Text + "\\lock.ico";

            CreateShortcut(name, targ, work, icon);
            statusOutput.Text += "CREATED: " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "LockedFolder.lnk" + Environment.NewLine;

            if (hideFolderCB.Checked == true)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "attrib.exe";
                startInfo.Arguments = "+s +h " + pathToInstall.Text;
                process.StartInfo = startInfo;
                process.Start();

                statusOutput.Text += "HIDDEN: " + pathToInstall.Text;
            }

            openFapmap.Visible = true;
            openFapmap.Enabled = true;

            Thread th = new Thread(Quit);
            th.IsBackground = true;
            th.Start();
        }

        private void CreateShortcut(string name, string target, string workingdir, string ico)
        {
            WshShell wsh = new WshShell();
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

        private void Quit()
        {
            exitLabel.Text = "Exiting Application in 10...";
            Thread.Sleep(1000);
            exitLabel.Text = "Exiting Application in 9...";
            Thread.Sleep(1000);
            exitLabel.Text = "Exiting Application in 8...";
            Thread.Sleep(1000);
            exitLabel.Text = "Exiting Application in 7...";
            Thread.Sleep(1000);
            exitLabel.Text = "Exiting Application in 6...";
            Thread.Sleep(1000);
            exitLabel.Text = "Exiting Application in 5...";
            Thread.Sleep(1000);
            exitLabel.Text = "Exiting Application in 4...";
            Thread.Sleep(1000);
            exitLabel.Text = "Exiting Application in 3...";
            Thread.Sleep(1000);
            exitLabel.Text = "Exiting Application in 2...";
            Thread.Sleep(1000);
            exitLabel.Text = "Exiting Application in 1...";
            Thread.Sleep(1000);
            exitLabel.Text = "Exiting Application...";
            Application.Exit();
        }

        private void openFapmap_Click(object sender, EventArgs e)
        {
            Process.Start(pathToInstall.Text + "\\LockedFolder.exe");
            Application.Exit();
        }
    }
}
