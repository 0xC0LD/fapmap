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
        public static string MAIN = Directory.GetParent(Application.ExecutablePath).FullName;
        public static string MAINFOLDER = MAIN + "\\Main Folder";
        public static string DATAFOLDER = MAIN + "\\data";
        public static string PASSWORDS = DATAFOLDER + "\\passwords.dll";
        public static string LOGFILE = DATAFOLDER + "\\cache\\fapmap.log";

        public Lock()
        {
            InitializeComponent();
        }

        private void Lock_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(DATAFOLDER)) { Directory.CreateDirectory(DATAFOLDER); }

            if (!File.Exists(PASSWORDS))
            {
                using (StreamWriter w = File.AppendText(PASSWORDS))
                {
                    w.Write("# password list" + Environment.NewLine);
                    w.Write("password" + Environment.NewLine);
                    w.Write("123");
                }

                Process.Start("notepad.exe", PASSWORDS);
            }

            this.ActiveControl = txt_passwd;
        }

        #region fx

        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        [System.ComponentModel.DesignerCategory("Code")]
        public class FapMapPanel : Panel
        {
            public FapMapPanel()
            {
                SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                // using (SolidBrush brush = new SolidBrush(BackColor))
                //     e.Graphics.FillRectangle(brush, ClientRectangle);
                // e.Graphics.DrawRectangle(new Pen(Color.MediumPurple), 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);

                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, ForeColor, ButtonBorderStyle.Solid);
            }

        }

        #endregion

        #region main

        private void lock_checkPasswords()
        {
            if (string.IsNullOrEmpty(txt_passwd.Text)) { Application.Exit(); return; }
            StreamReader sr = new StreamReader(PASSWORDS);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("#")) { continue; }

                if (txt_passwd.Text == line)
                {
                    if (File.Exists(MAIN + "\\fapmap.exe"))
                    {
                        LogThis(txt_passwd.Text);
                        Process.Start(MAIN + "\\fapmap.exe");
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("fapmap.exe not found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }
                }
            }

            LogThis(txt_passwd.Text);
            MessageBox.Show("Wrong Password.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        #endregion

        #region ui events

        private void txt_passwd_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Escape: Application.Exit(); e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Enter: lock_checkPasswords(); e.Handled = true; e.SuppressKeyPress = true; break;
            }


            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Back: txt_passwd.Text = ""; e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.S: cb_show.Checked = !cb_show.Checked; e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.A: txt_passwd.SelectAll(); break;
                }
            }
        }
        private void cb_show_CheckedChanged(object sender, EventArgs e)
        {
            cb_show.ForeColor = cb_show.Checked ? Color.CornflowerBlue : Color.SlateBlue;

            txt_passwd.PasswordChar = cb_show.Checked ? '\0' : '•';
        }
        private void txt_passwd_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Clicks == 2)
            {
                lock_checkPasswords();
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            lock_checkPasswords();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region other

        public static void LogThis(string text)
        {
            using (StreamWriter w = File.AppendText(LOGFILE))
            {
                w.WriteLine(time() + "|||PASS|||" + text);
            }
        }
        public static string time()
        {
            DateTime dt = DateTime.Now;
            return
                dt.Year.ToString() + "-" +
                dt.Month.ToString().PadLeft(2, '0') + "-" +
                dt.Day.ToString().PadLeft(2, '0') + " " +
                dt.Hour.ToString().PadLeft(2, '0') + ":" +
                dt.Minute.ToString().PadLeft(2, '0') + ":" +
                dt.Second.ToString().PadLeft(2, '0')
                ;
        }

        #endregion

        
    }
}
