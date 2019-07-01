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

namespace LockedFolder
{
    public partial class Lock : Form
    {
        #region Main

        public static string MAIN = Directory.GetParent(Application.ExecutablePath).ToString() + "\\";
        public static string MAINFOLDER = MAIN + "Main Folder";
        public static string DATAFOLDER = MAIN + "data" + "\\";
        public static string PASSWORDS = DATAFOLDER + "passwords.dll";
        public static string LOGFILE = DATAFOLDER + "fapmap.log";

        public Lock()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(DATAFOLDER))
            {
                Directory.CreateDirectory(DATAFOLDER);
            }

            if (File.Exists(PASSWORDS) != true)
            {
                //MessageBox.Show("The application is missing some files... Please, reinstall the application...", "Application not installed properly", MessageBoxButtons.OK, MessageBoxIcon.Error);



                using (StreamWriter w = File.AppendText(PASSWORDS))
                {
                    w.Write("# THIS IS WHERE YOU LIST ALL PASSWORDS" + Environment.NewLine);
                    w.Write("# EACH PASSWORD NEEDS TO BE ABOVE AND BELOVE EACH OTHER" + Environment.NewLine);
                    w.Write("# USE \"#\" TO MAKE COMMENTS" + Environment.NewLine);
                    w.Write("# LEAVE NO EMPTY SPACES EXEPT THE ACTUAL END (because the space can count as a password too...)" + Environment.NewLine);
                    w.Write("# THE FIRST PASSWORD STARTS FROM HERE:" + Environment.NewLine);
                    w.Write("password" + Environment.NewLine);
                    w.Write("123");
                }

                Process.Start("notepad.exe", PASSWORDS);
            }

            this.ActiveControl = passwordEntered;
        }

        #endregion

        #region Graphics

        //FIX FLICKERING
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        #endregion

        #region OTHER

        //LOGGER
        public static void LogThis(string text)
        {
            // DD.AA.TEEE TT:IM:EE|||ACTN|||FILE/URL/TEXT/...

            using (StreamWriter w = File.AppendText(LOGFILE))
            {
                w.WriteLine(time() + "|||PASS|||" + text);
            }
        }

        public static string time()
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString().PadLeft(2, '0');
            string day = DateTime.Now.Day.ToString().PadLeft(2, '0');
            string hour = DateTime.Now.Hour.ToString().PadLeft(2, '0');
            string minute = DateTime.Now.Minute.ToString().PadLeft(2, '0');
            string second = DateTime.Now.Second.ToString().PadLeft(2, '0');
            string now = day + "." + month + "." + year + " " + hour + ":" + minute + ":" + second;

            //DATE = 00.00.0000
            //TIME = 00:00:00

            // now = DATE + TIME
            return now;
        }

        #endregion

        #region MAINPART

        private void CheckForPasswords()
        {
            StreamReader sr = new StreamReader(PASSWORDS);
            string line = "";

            if (string.IsNullOrEmpty(passwordEntered.Text))
            {
                Application.Exit();
            }
            else
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("#") != true)
                    {
                        if (passwordEntered.Text == line)
                        {
                            if (File.Exists(MAIN + ".\\fapmap.exe"))
                            {
                                LogThis(passwordEntered.Text);
                                Process.Start(MAIN + ".\\fapmap.exe");
                                Application.Exit();

                                return;
                            }
                            else
                            {
                                MessageBox.Show("Missing Application Executable...", "Application not installed properly", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit();

                                return;
                            }
                        }
                    }
                }

                LogThis(passwordEntered.Text);
                MessageBox.Show("Wrong Password.", "ERROR :/", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }


        private void passwordEntered_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                passwordEntered.Text = "";
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                Application.Exit();
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                CheckForPasswords();
            }

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                if (showPasswordCB.Checked != true)
                {
                    showPasswordCB.Checked = true;
                }
                else
                {
                    showPasswordCB.Checked = false;
                }
            }

            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
            }

            if (e.KeyCode == Keys.Back && e.Control)
            {
                e.SuppressKeyPress = true;
                passwordEntered.Text = "";
            }
        }

        //OK
        private void okButton_Click(object sender, EventArgs e)
        {
            CheckForPasswords();
        }

        private void showPasswordCB_CheckedChanged(object sender, EventArgs e)
        {
            passwordEntered.PasswordChar = showPasswordCB.Checked ? '\0' : '•';
        }


        #endregion

        private void passwordEntered_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CheckForPasswords();
            }

            if (e.Clicks == 2)
            {
                CheckForPasswords();
            }
        }
    }
}
