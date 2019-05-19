using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Net;
using WMPLib;
using AxWMPLib;
// using System.Reflection;
// using System.Text.RegularExpressions;
// using System.Threading.Tasks;
// using System.Windows.Interop;
// using System.Text;
// using System.Data;
// using System.Windows;
// using System.Windows.Media;
// using System.Windows.Media.Imaging;
// using Microsoft.Win32;

namespace fapmap
{
    public partial class fapmap : Form
    {
        #region main()

        public fapmap() //MAIN LOOP
        {
            InitializeComponent();
        }

        public class GlobalVariables
        {
            public class FileTypes
            {
                //CONST FILE TYPES
                public static readonly List<string> Video = new List<string> { ".mp4", ".webm", ".avi", ".mov", ".mkv", ".flv", ".mpeg", ".mpg", ".wmv", ".mp3", ".ogg" };
                public static readonly List<string> Image = new List<string> { ".jpg", ".jpeg", ".jpe", ".jiff", ".jfif", ".png", ".gif", ".ico", ".svg", ".bmp", ".dib", ".tif", ".tiff" };
                public static readonly List<string> Other = new List<string> { ".zip", ".rar", ".exe", ".bat", ".swf", ".dll", ".txt" };

            }


            public class Settings
            {
                public class Common
                {
                    public const char Equal = '=';
                    public const char Split = '|';
                    public const string Comment = "#";
                }

                public class WebBrowser
                {
                    public static string Browser = "firefox.exe"; public const string Browser_ = "browser";
                    public static string BrowserArguments = "-private-window"; public const string BrowserArguments_ = "browser_arguments";
                    public static string FapMapURL = "https://www.google.com"; public const string FapMapURL_ = "fapmap_url";
                }

                public class Media
                {
                    public static int GifDelay = 50; public const string GifDelay_ = "gif_delay";
                    
                    public class FileTypes
                    {
                        //CHANGABLE FILE TYPES FOR RANDOM GENERATOR
                        public static List<string> Video = new List<string> { ".mp4", ".webm", ".avi", ".mov", ".mkv", ".flv", ".mpeg", ".mpg", ".wmv", ".mp3", ".ogg" };
                        public const string Video_ = "types_video";

                        public static List<string> Image = new List<string> { ".jpg", ".jpeg", ".jpe", ".jiff", ".jfif", ".png", ".gif", ".ico", ".svg", ".bmp", ".dib", ".tif", ".tiff" };
                        public const string Image_ = "types_image";
                    }
                }
                
                public class CheckBoxes
                {
                    public static bool HideOnX                    = false; public const string HideOnX_                    = "hide_on_x";
                    public static bool FocusHide                  = false; public const string FocusHide_                  = "hide_on_lost_focus";
                    public static bool EnableMediaPlayers         = true;  public const string EnableMediaPlayers_         = "enable_media_players";
                    public static bool AutoHideMediaPlayers       = true;  public const string AutoHideMediaPlayers_       = "auto_hide_media_players";
                    public static bool AutoPlayVideoPlayer        = true;  public const string AutoPlayVideoPlayer_        = "auto_play_video_player";
                    public static bool AutoPauseVideoPlayer       = true;  public const string AutoPauseVideoPlayer_       = "auto_pause_video_player";
                    public static bool EnableTrackbarForGifViewer = true;  public const string EnableTrackbarForGifViewer_ = "enable_trackbar_for_gif_viewer";
                    public static bool EnableFileDisplay          = true;  public const string EnableFileDisplay_          = "enable_filedisplay";
                    public static bool EnableOpenOutsideFapmap    = false; public const string EnableOpenOutsideFapmap_    = "enable_open_outside_fapmap";
                }

                public class Other
                {
                    public static List<string> AutoCompleteLines = new List<string>();
                    public static List<string> WebGrabTableLines = new List<string>(); public const string WebGrabTableLines_ = "wgtl";
                    public static List<string> MoveFileToLines = new List<string>();   public const string MoveFileToLines_   = "move";
                }
            }

            public class Path
            {
                public class Dir
                {
                    //FILES
                    public static string Main = Directory.GetParent(Application.ExecutablePath).ToString() + "\\";
                    public static string MainFolder = Main + "Main Folder";
                    public static string DataFolder = Main + "data" + "\\";
                    public static string FavIcons = DataFolder + "favicons";
                }
                
                public class File
                {
                    public static string Password   = Path.Dir.DataFolder + "passwords.dll";
                    public static string Links       = Path.Dir.DataFolder + "urls.lst";
                    public static string Settings    = Path.Dir.DataFolder + "fapmap.ini";
                    public static string Board       = Path.Dir.DataFolder + "board.ini";
                    public static string Keywords = Path.Dir.DataFolder + "keywords.lst";
                    public static string Log         = Path.Dir.DataFolder + "fapmap.log";

                    public class Exe
                    {
                        public static string Ffmpeg = Path.Dir.Main + "ffmpeg.exe";
                        public static string Webgrab = Path.Dir.Main + "webgrab.exe";
                        public static string Youtubedl = Path.Dir.Main + "youtube-dl.exe";
                    }
                }
            }

            public class LOG_TYPE
            {
                public static string PLAY = "PLAY";
                public static string EXEC = "EXEC";
                public static string LOAD = "LOAD";
                public static string OPEN = "OPEN";
                public static string NTFD = "404E";
                public static string DING = "DING";
                public static string DLED = "DLED";
                public static string MOVE = "MOVE";
                public static string RENM = "RENM";
                public static string MDIR = "MDIR";
                public static string FMWB = "FMWB";
                public static string RMVD = "RMVD";
                public static string UDEL = "UDEL";
            }
        }
        
        public static bool this_selected = false;
        private void fapmap_Load(object sender, EventArgs e)
        {
            //SET CURRENT WORKING DIRECTORY
            fapmap_cd();

            //Export All
            file_export_all();

            //LOAD THAT SHIT
            settings_load();
            settings_apply();
            
            //TREEVIEW EXPLORER
            faftv_ListDirectory(faftv, GlobalVariables.Path.Dir.MainFolder);

            //GET SAVED LINKS
            links_reload();

            // cb_fileDisplay.Checked = false; //ENABLE DEBUG
            
            //HIDE PANEL 2
            menu_changeTabs_MouseUp(null, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));

            //resize
            this.Size = this.MinimumSize;
            this.CenterToScreen();
            
            //REMOVE TEXTBOX FOCUS
            this.ActiveControl = menu;
            menu.Focus();
            load_file_or_dir(GlobalVariables.Path.Dir.MainFolder);
        }

        #endregion

        #region FapMap Form

        //CLOSING

        private void fapmap_FormClosed(object sender, FormClosedEventArgs e) { Quit(); }
        private void fapmap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (menu_cb_fapmap_xhide.Checked)
            {
                new Thread(CancelClosing) { IsBackground = true }.Start();
                e.Cancel = true;
            }
        }
        private void fapmap_Activated(object sender, EventArgs e)
        {
            this_selected = true;

            if (menu_cb_players_autoPlay.Checked)
            {
                if (showMedia_video.playState == WMPPlayState.wmppsPaused || showMedia_video.playState == WMPPlayState.wmppsReady)
                {
                    showMedia_video.Ctlcontrols.play();
                }
            }
        }
        private void fapmap_Deactivate(object sender, EventArgs e)
        {
            this_selected = false;

            if (menu_cb_fapmap_focusHide.Checked)
            {
                this_hide();
            }
            else
            {
                if (menu_cb_players_autoPause.Checked)
                {
                    if (showMedia_video.playState == WMPPlayState.wmppsPlaying)
                    {
                        showMedia_video.Ctlcontrols.pause();
                    }
                }
            }
        }
        private void fapmap_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (menu_cb_players_autoPause.Checked)
                {
                    if (showMedia_video.playState == WMPPlayState.wmppsPlaying)
                    {
                        showMedia_video.Ctlcontrols.pause();
                    }
                }
            }

            if (this.Size.Width > 230 && this.Size.Width > 200) { showMedia_video_panel.MaximumSize = this.Size; showMedia_image_panel.MaximumSize = this.Size; }
        }
        private void CancelClosing()
        {
            this_hide();
        }
        private void Quit()
        {
            this_trayicon.Dispose();
            System.Environment.Exit(0);
        }

        #endregion

        #region fx

        //IMAGE
        public static Image GetImage(string path)
        {
            if (!File.Exists(path)) { return Properties.Resources.image_error; }

            try
            {
                Image image;
                using (Stream stream = File.OpenRead(path)) { image = System.Drawing.Image.FromStream(stream); }
                return image;
            }
            catch (Exception)
            {
                return Properties.Resources.image_error;
            }
        }
        
        //TOOLTIP COLOR FIX
        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
        
        private void move_to_setup()
        {
            file_export_all();

            foreach (string line in fapmap.GlobalVariables.Settings.Other.MoveFileToLines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    showMedia_image_RMB_moveTo.DropDownItems.Add(get_tsmi(line));
                    showMedia_video_RMB_moveTo.DropDownItems.Add(get_tsmi(line));
                }
            }
        }
        private ToolStripMenuItem get_tsmi(string line)
        {
            string path = line;

            //make dir
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                DirectoryInfo di = new DirectoryInfo(path);
                path = di.FullName;
            }

            ToolStripMenuItem tsmi = new ToolStripMenuItem();
            if (path.Contains(GlobalVariables.Path.Dir.MainFolder))
            {
                tsmi.Text = path.Replace(GlobalVariables.Path.Dir.MainFolder + "\\", "") + "\\.";
            }
            else
            {
                tsmi.Text = path + "\\.";
            }
            tsmi.Tag = path;
            tsmi.ForeColor = Color.Silver;
            tsmi.BackColor = Color.FromArgb(20, 20, 20);
            tsmi.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            tsmi.Image = global::fapmap.Properties.Resources.image_button_arrow_right;
            tsmi.Click += Tsmi_Click;

            return tsmi;
        }
        private void Tsmi_Click(object sender, EventArgs e)
        {
            //close video/image
            media_remove(menu_cb_players_autoHide.Checked);

            //get path
            string path = ((ToolStripMenuItem)sender).Tag.ToString();

            //make dir
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                DirectoryInfo di = new DirectoryInfo(path);
                path = di.FullName;
            }

            if (File.Exists(faftv_path.Text))
            {
                //copy file
                FileInfo fi = new FileInfo(faftv_path.Text);
                string dest = path + "\\" + fi.Name;

                try
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(fi.FullName, dest, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);

                    this.Text = "FAPMAP: MOVED: " + fi.FullName + " -> " + dest;
                    LogThis(fapmap.GlobalVariables.LOG_TYPE.MOVE, fi.FullName + " -> " + dest);
                }
                catch (ArgumentException) { MessageBox.Show("ERRO[ArgumentException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (FileNotFoundException) { MessageBox.Show("ERRO[FileNotFoundException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (IOException exx) { MessageBox.Show("ERRO[IOException]: " + exx.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (InvalidOperationException) { MessageBox.Show("ERRO[InvalidOperationException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (NotSupportedException) { MessageBox.Show("ERRO[NotSupportedException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (System.Security.SecurityException) { MessageBox.Show("ERRO[SecurityException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (UnauthorizedAccessException) { MessageBox.Show("ERRO[UnauthorizedAccessException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                catch (Exception) { MessageBox.Show("ERRO[Exception]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        
        #endregion

        #region Hide Window
        
        private void this_hide()
        {
            if (this.Visible)
            {
                showMedia_video.Ctlcontrols.pause(); //PAUSE ANY VIDEO THAT IS PLAYING
                this.Icon = Properties.Resources.image_icon_fapmap_silver;
                this.this_trayicon.Icon = Properties.Resources.image_icon_fapmap_silver;
                this.Hide();
            }
            else
            {
                this.Show();
                if (this.WindowState == FormWindowState.Minimized) { this.WindowState = FormWindowState.Normal; }
                this.Icon = Properties.Resources.image_icon_fapmap_mediumblue;
                this.this_trayicon.Icon = Properties.Resources.image_icon_fapmap_purple;
            }
        }
        private void SystemTrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this_hide();
            }

            if (e.Button == MouseButtons.Right)
            {
                Quit();
            }
        }

        #endregion

        #region GLOBAL FUNCTIONS

        //LOGGER
        public static void LogThis(string action, string text)
        {
            // DD.AA.TEEE TT:IM:EE|||ACTN|||FILE/URL/TEXT/...

            using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Log))
            {
                w.WriteLine(time() + "|||" + action + "|||" + text);
            }
        }

        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        public static string get_html_title(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url)) { return ""; }
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute)) { return ""; }
                foreach (string type in GlobalVariables.FileTypes.Video) { if (url.Contains(type)) { return "video"; } }
                foreach (string type in GlobalVariables.FileTypes.Image) { if (url.Contains(type)) { return "image"; } }
                foreach (string type in GlobalVariables.FileTypes.Other) { if (url.Contains(type)) { return "file?"; } }

                System.Net.WebClient wc = new System.Net.WebClient();
                wc.Headers.Add("user-agent", "fapmap.exe");
                
                string title = System.Net.WebUtility.HtmlDecode(get_string_in_between("<title>", "</title>", System.Text.Encoding.Default.GetString(wc.DownloadData(url)), false, false));
                return string.IsNullOrEmpty(title) ? "..." : title;
            }
            catch (Exception) { return "..."; }
        }
        
        public static string get_string_in_between(string strBegin, string strEnd, string strSource, bool includeBegin, bool includeEnd)
        {
            string[] result = { string.Empty, string.Empty };
            int iIndexOfBegin = strSource.IndexOf(strBegin);

            if (iIndexOfBegin != -1)
            {
                // include the Begin string if desired 
                if (includeBegin) { iIndexOfBegin -= strBegin.Length; }

                strSource = strSource.Substring(iIndexOfBegin + strBegin.Length);

                int iEnd = strSource.IndexOf(strEnd);
                if (iEnd != -1)
                {
                    // include the End string if desired 
                    if (includeEnd) { iEnd += strEnd.Length; }
                    result[0] = strSource.Substring(0, iEnd);

                    // advance beyond this segment 
                    if (iEnd + strEnd.Length < strSource.Length) { result[1] = strSource.Substring(iEnd + strEnd.Length); }
                }
            }
            else
            {
                // stay where we are 
                result[1] = strSource;
            }

            return result[0];
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

        private DirectBitmap bmp = new DirectBitmap(160, 80);
        private void draw_graph(int data, Control pb, Color clr)
        {
            try
            {
                //new input
                using (var g = Graphics.FromImage(bmp.Bitmap))
                {
                    if (data > 0)
                    {
                        double pbUnit = bmp.Height / 100.0;
                        int val = (int)(data * pbUnit);

                        int point1 = bmp.Height - (val + 10);

                        g.DrawLine(new Pen(clr), new Point(0, point1 < 0 ? 0 : point1), new Point(0, bmp.Height - 1));
                    }
                }

                DirectBitmap copy = new DirectBitmap(bmp.Width, bmp.Height);
                using (var g = Graphics.FromImage(copy.Bitmap)) { g.DrawImage(bmp.Bitmap, new PointF(0, 0)); }
                for (int column = 0; column < bmp.Height; column++)
                {
                    for (int row = 0; row < bmp.Width; row++)
                    {
                        if (row != bmp.Width - 1)
                        {
                            bmp.SetPixel(row + 1, column, copy.GetPixel(row, column));
                        }
                    }
                }
                for (int column = 0; column < bmp.Height; column++)
                {
                    bmp.SetPixel(0, column, Color.Transparent);
                }
                copy.Dispose();

                pb.BackgroundImage = new Bitmap(bmp.Bitmap);
            }
            catch (Exception) { }
        }
        public class DirectBitmap : IDisposable
        {
            public Bitmap Bitmap { get; private set; }
            public Int32[] Bits { get; private set; }
            public bool Disposed { get; private set; }
            public int Height { get; private set; }
            public int Width { get; private set; }

            protected GCHandle BitsHandle { get; private set; }

            public DirectBitmap(int width, int height)
            {
                Width = width;
                Height = height;
                Bits = new Int32[width * height];
                BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
                Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
            }

            public void SetPixel(int x, int y, Color colour)
            {
                int index = x + (y * Width);
                int col = colour.ToArgb();

                Bits[index] = col;
            }

            public Color GetPixel(int x, int y)
            {
                int index = x + (y * Width);
                int col = Bits[index];
                Color result = Color.FromArgb(col);

                return result;
            }

            public void Dispose()
            {
                if (Disposed) return;
                Disposed = true;
                Bitmap.Dispose();
                BitsHandle.Free();
            }
        }

        public static void draw_progressBar(int data, PictureBox pb, Color clr)
        {
            try
            {
                int pbWIDTH = pb.Width;
                int pbHEIGHT = pb.Height;

                double pbUnit = pbWIDTH / 100.0;

                Bitmap bmp = new Bitmap(pbWIDTH, pbHEIGHT);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Transparent);

                    if (clr != Color.Transparent) //if only clear
                    {
                        //draw progressbar
                        g.FillRectangle(new SolidBrush(clr), new Rectangle(0, 0, (int)(data * pbUnit), pbHEIGHT));
                    }
                }

                pb.Image = bmp;
            }
            catch (Exception) { }
        }
        public static void draw_progressBar_icon(NotifyIcon ni, int perc, Brush brush)
        {
            try
            {
                Bitmap bmp = new Bitmap(100, 100);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Transparent);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), new Rectangle(0, bmp.Height - bmp.Height / 4, bmp.Width, bmp.Height / 4));
                    g.FillRectangle(brush, new Rectangle(0, bmp.Height - bmp.Height / 4, perc, bmp.Height / 4));

                    g.DrawString(perc.ToString(), new Font("Arial", bmp.Height / 2, FontStyle.Regular), brush, new Point(0, 0));
                }
                // //flip vert
                // bmp.RotateFlip(RotateFlipType.Rotate180FlipX);

                //convert and show on icon
                ni.Icon = Icon.FromHandle(bmp.GetHicon());
            }
            catch (Exception) {  }
        }

        //GALLERY HIDE
        private void gallery_hide(int Hide)
        {
            switch (Hide)
            {
                case 0: { new Thread(gallery_hide_remove) { IsBackground = true }.Start(); break; }
                case 1: { new Thread(gallery_hide_normal) { IsBackground = true }.Start(); break; }
                case 2: { new Thread(gallery_hide_full)   { IsBackground = true }.Start(); break; }

                default: { new Thread(gallery_hide_full) { IsBackground = true }.Start(); break; }
            }
        }
        private void gallery_hide_remove()
        {
            this.Text = "FAPMAP: GALLERY: Unhiding files...";

            Process cmd = new Process();
            cmd.StartInfo.FileName = "attrib.exe";
            cmd.StartInfo.WorkingDirectory = fapmap.GlobalVariables.Path.Dir.Main;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.Arguments = "-s -h /d /s";
            cmd.Start();
            cmd.WaitForExit();

            //HIDE desktop.ini
            Hide_Desktop_ini();

            LogThis(GlobalVariables.LOG_TYPE.EXEC, "attrib.exe -s -h /d /s");
            this.Text = "FAPMAP: GALLERY: Files unhidden";
        }
        private void gallery_hide_normal()
        {
            this.Text = "FAPMAP: GALLERY: Hiding files (normal)....";

            Process cmd = new Process();
            cmd.StartInfo.FileName = "attrib.exe";
            cmd.StartInfo.WorkingDirectory = fapmap.GlobalVariables.Path.Dir.Main;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.Arguments = "-s +h /d /s";
            cmd.Start();
            cmd.WaitForExit();

            //HIDE desktop.ini
            Hide_Desktop_ini();

            LogThis(GlobalVariables.LOG_TYPE.EXEC, "attrib.exe -s +h /d /s");
            this.Text = "FAPMAP: GALLERY: Files hidden (normal)";
        }
        private void gallery_hide_full()
        {
            this.Text = "FAPMAP: GALLERY: Hiding files (full)....";

            Process cmd = new Process();
            cmd.StartInfo.FileName = "attrib.exe";
            cmd.StartInfo.WorkingDirectory = fapmap.GlobalVariables.Path.Dir.Main;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.Arguments = "+s +h /d /s";
            cmd.Start();
            cmd.WaitForExit();

            //HIDE desktop.ini
            Hide_Desktop_ini();

            LogThis(GlobalVariables.LOG_TYPE.EXEC, "attrib.exe +s +h /d /s");
            this.Text = "FAPMAP: GALLERY: Files hidden (full)";
        }
        private static void Hide_Desktop_ini()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "attrib.exe";
            cmd.StartInfo.WorkingDirectory = fapmap.GlobalVariables.Path.Dir.Main;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.Arguments = "+s +h /d /s desktop.ini";
            cmd.Start();
            cmd.WaitForExit();
        }

        public static void settings_load()
        {
            //IF FAPMAP.INI DOESN'T EXIST
            file_export_all();

            //REMOVE NULL LINES
            using (FileStream fs = new FileStream(fapmap.GlobalVariables.Path.File.Settings, FileMode.Open))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    foreach (string line in SafeReadLines(fapmap.GlobalVariables.Path.File.Settings))
                    {
                        if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line) && line != "")
                        {
                            tw.WriteLine(line);
                        }
                    }

                    tw.Flush();                // Flush the writer in order to get a correct stream position for truncating
                    fs.SetLength(fs.Position); // Set the stream length to the current position in order to truncate leftover text
                }
            }
            
            List<string> lines_settings = File.ReadAllLines(GlobalVariables.Path.File.Settings).ToList();
            int countLine = 0;
            foreach (var line in lines_settings)
            {
                countLine++;

                if (!(string.IsNullOrEmpty(line) || line.StartsWith(GlobalVariables.Settings.Common.Comment))) //IGNORE COMMENTS
                {
                    string[] settings_index = line.Split(GlobalVariables.Settings.Common.Equal);
                    switch (settings_index.Length)
                    {
                        case 1:
                            {
                                LogThis(GlobalVariables.LOG_TYPE.LOAD, "fapmap.ini (line: " + countLine + ")");
                                MessageBox.Show("Failed to load fapmap.ini on line: " + countLine, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        case 2:
                            {
                                switch (settings_index[0])
                                {
                                    //CHECKBOXES
                                    case GlobalVariables.Settings.CheckBoxes.HideOnX_:             { GlobalVariables.Settings.CheckBoxes.HideOnX             = string_to_bool(settings_index[1]); break; }
                                    case GlobalVariables.Settings.CheckBoxes.FocusHide_:             { GlobalVariables.Settings.CheckBoxes.FocusHide             = string_to_bool(settings_index[1]); break; }
                                    case GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers_:             { GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers             = string_to_bool(settings_index[1]); break; }
                                    case GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers_:         { GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers         = string_to_bool(settings_index[1]); break; }
                                    case GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer_:         { GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer         = string_to_bool(settings_index[1]); break; }
                                    case GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer_:        { GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer        = string_to_bool(settings_index[1]); break; }
                                    case GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer_:          { GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer          = string_to_bool(settings_index[1]); break; }
                                    case GlobalVariables.Settings.CheckBoxes.EnableFileDisplay_:  { GlobalVariables.Settings.CheckBoxes.EnableFileDisplay  = string_to_bool(settings_index[1]); break; }
                                    case GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap_: { GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap = string_to_bool(settings_index[1]); break; }

                                    //OTHER
                                    case GlobalVariables.Settings.WebBrowser.Browser_:      { GlobalVariables.Settings.WebBrowser.Browser      = settings_index[1]; break; }
                                    case GlobalVariables.Settings.WebBrowser.BrowserArguments_:    { GlobalVariables.Settings.WebBrowser.BrowserArguments    = settings_index[1]; break; }
                                    case GlobalVariables.Settings.WebBrowser.FapMapURL_: { GlobalVariables.Settings.WebBrowser.FapMapURL = settings_index[1]; break; }
                                    case GlobalVariables.Settings.Media.GifDelay_:
                                        {
                                            if (int.TryParse(settings_index[1], out int output))
                                            {
                                                if (output < 5)
                                                {
                                                    GlobalVariables.Settings.Media.GifDelay = 5;
                                                }
                                                else
                                                {
                                                    GlobalVariables.Settings.Media.GifDelay = output;
                                                }
                                            }
                                            else
                                            {
                                                GlobalVariables.Settings.Media.GifDelay = 50;
                                            }

                                            break;
                                        }
                                    case GlobalVariables.Settings.Media.FileTypes.Video_:
                                        {
                                            // RANDOM_VAR.VIDEO_TYPES.Clear();

                                            List<string> Types = new List<string>();

                                            string[] types = settings_index[1].Split(',');
                                            foreach (string type in types)
                                            {
                                                if (string.IsNullOrEmpty(type))
                                                {
                                                    LogThis(GlobalVariables.LOG_TYPE.LOAD, "fapmap.ini (line: " + countLine + ")");
                                                    MessageBox.Show("Failed to load fapmap.ini on line: " + countLine, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    break; //keep the declared types
                                                }
                                                else
                                                {
                                                    Types.Add(type);
                                                }
                                            }

                                            //REPLACE THE GLOBAL TYPES WITH THE NEW FILE TYPES
                                            GlobalVariables.Settings.Media.FileTypes.Video.Clear();
                                            GlobalVariables.Settings.Media.FileTypes.Video = Types;

                                            break;
                                        }
                                    case GlobalVariables.Settings.Media.FileTypes.Image_:
                                        {
                                            // RANDOM_VAR.IMAGE_TYPES.Clear();

                                            List<string> Types = new List<string>();

                                            string[] types = settings_index[1].Split(',');
                                            foreach (string type in types)
                                            {
                                                if (string.IsNullOrEmpty(type))
                                                {
                                                    LogThis(GlobalVariables.LOG_TYPE.LOAD, "fapmap.ini (line: " + countLine + ")");
                                                    MessageBox.Show("Failed to load fapmap.ini on line: " + countLine, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    break; //keep the declared types
                                                }
                                                else
                                                {
                                                    Types.Add(type);
                                                }
                                            }

                                            //REPLACE THE GLOBAL TYPES WITH THE NEW FILE TYPES
                                            GlobalVariables.Settings.Media.FileTypes.Image.Clear();
                                            GlobalVariables.Settings.Media.FileTypes.Image = Types;

                                            break;
                                        }

                                    case GlobalVariables.Settings.Other.WebGrabTableLines_:
                                        {
                                            GlobalVariables.Settings.Other.WebGrabTableLines.Add(settings_index[1]);

                                            break;
                                        }

                                    case GlobalVariables.Settings.Other.MoveFileToLines_:
                                        {
                                            GlobalVariables.Settings.Other.MoveFileToLines.Add(settings_index[1]);

                                            break;
                                        }
                                }

                                break;
                            }

                        default:
                            {
                                LogThis(GlobalVariables.LOG_TYPE.LOAD, "fapmap.ini (line: " + countLine + ")");
                                MessageBox.Show("Failed to load fapmap.ini on line: " + countLine, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                    }
                }
            }
            
            //add porn list
            foreach (string line in File.ReadAllLines(GlobalVariables.Path.File.Keywords))
            {
                GlobalVariables.Settings.Other.AutoCompleteLines.Add(line);
            }

            //add history
            List<string> lines_ac = File.ReadAllLines(GlobalVariables.Path.File.Log).ToList();
            foreach (string line in lines_ac)
            {
                string[] index = line.Split(new string[] { "|||" }, StringSplitOptions.None);

                if (index.Length == 3)
                {
                    string str = index[2];

                    if (index[1] == fapmap.GlobalVariables.LOG_TYPE.OPEN || index[1] == "FMWB")
                    {
                        GlobalVariables.Settings.Other.AutoCompleteLines.Add(str);
                    }
                }
            }

            
            List<string> words = new List<string>();
            foreach (string word in GlobalVariables.Settings.Other.AutoCompleteLines)
            {
                if (string.IsNullOrEmpty(word)) { continue; }
                if (word.StartsWith("#")) { continue; }
                if (Uri.IsWellFormedUriString(word, UriKind.Absolute)) { continue; }

                if (word.Contains(' ')) // if it's a sentence brake it down into words
                {
                    string[] index = word.Split(' ');

                    foreach (string str in index)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            words.Add(str);
                        }
                    }

                    continue;
                }

                words.Add(word);
            }
            words = words.Distinct().ToList(); //remove dupes
            words.Reverse(); //bring to top
            GlobalVariables.Settings.Other.AutoCompleteLines = words; //set
        }

        private void settings_apply()
        {
            //AUTOCOMPLTE
            foreach(string item in GlobalVariables.Settings.Other.AutoCompleteLines)
            {
                wb_url_autoCompleteMenu.AddItem(item);
            }

            //start audio  reader
            new Thread(DrawAudio) { IsBackground = true }.Start();

            //MENU
            menu.Renderer = new fapmap_res.color.fToolStripProfessionalRenderer();
            menu.Cursor = Cursors.Arrow;

            //CONTEXT MENU STRIPS LOOK
            links_RMB.Renderer = new fapmap_res.color.fToolStripProfessionalRenderer();
            faftv_RMB.Renderer = new fapmap_res.color.fToolStripProfessionalRenderer();
            fileDisplay_RMB.Renderer = new fapmap_res.color.fToolStripProfessionalRenderer();

            //CONTEXT TMENU STRIPS FOR PLAYERS
            showMedia_video_RMB.Renderer = new fapmap_res.color.fToolStripProfessionalRenderer();
            showMedia_image_RMB.Renderer = new fapmap_res.color.fToolStripProfessionalRenderer();
            
            //MOVE TO RMB SETUP
            move_to_setup();

            //VIDEO PLAYER SETTINGS
            showMedia_video.settings.setMode("loop", true);
            showMedia_video.settings.autoStart = true;
            showMedia_video.settings.volume = 100;
            showMedia_video.stretchToFit = true;

            //WINOWS MEDIA PLAYER SETTINGS
            showMedia_video.uiMode = "none";
            showMedia_video.enableContextMenu = false;
            showMedia_video.Ctlenabled = false;
            // showMedia_video.settings.enableErrorDialogs = true;
            
            //CHECKBOXES
            menu_cb_fapmap_xhide.Checked = GlobalVariables.Settings.CheckBoxes.HideOnX;
            menu_cb_fapmap_focusHide.Checked = GlobalVariables.Settings.CheckBoxes.FocusHide;
            menu_cb_fapmap_fileDisplay.Checked = GlobalVariables.Settings.CheckBoxes.EnableFileDisplay; fileDisplay_sw();
            menu_cb_fapmap_outside.Checked = GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap;
            menu_cb_players_enable.Checked = GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers;
            menu_cb_players_autoHide.Checked = GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers;
            menu_cb_players_autoPlay.Checked = GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer;
            menu_cb_players_autoPause.Checked = GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer;
            menu_cb_players_trackbar.Checked = GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer;

            //OTHER
            try
            {
                wb_url.Text = GlobalVariables.Settings.WebBrowser.FapMapURL;
                showMedia_image_gif_timer.Interval = GlobalVariables.Settings.Media.GifDelay;
            }
            catch (Exception) { }
        }
        // Constants
        private const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;
        private const int SET_FEATURE_ON_THREAD = 0x00000001;
        private const int SET_FEATURE_ON_PROCESS = 0x00000002;
        private const int SET_FEATURE_IN_REGISTRY = 0x00000004;
        private const int SET_FEATURE_ON_THREAD_LOCALMACHINE = 0x00000008;
        private const int SET_FEATURE_ON_THREAD_INTRANET = 0x00000010;
        private const int SET_FEATURE_ON_THREAD_TRUSTED = 0x00000020;
        private const int SET_FEATURE_ON_THREAD_INTERNET = 0x00000040;
        private const int SET_FEATURE_ON_THREAD_RESTRICTED = 0x00000080;

        // Necessary dll import
        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        static extern int CoInternetSetFeatureEnabled(
        int FeatureEntry,
        [MarshalAs(UnmanagedType.U4)] int dwFlags,
        bool fEnable);


        public static bool string_to_bool(string str)
        {
            if (str == "true" || str == "1" || str == "yes")
            {
                return true;
            }
            else
            {
                //(str == "false" || str == "0" || str == "no")
                return false;
            }
        }
        public static string bool_to_string(bool bl)
        {
            if (bl == true)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        public static void fapmap_cd()
        {
            if (!Directory.Exists(GlobalVariables.Path.Dir.MainFolder)) { Directory.CreateDirectory(GlobalVariables.Path.Dir.MainFolder); }
            if (!Directory.Exists(GlobalVariables.Path.Dir.DataFolder)) { Directory.CreateDirectory(GlobalVariables.Path.Dir.DataFolder); }
            Directory.SetCurrentDirectory(fapmap.GlobalVariables.Path.Dir.MainFolder);
        }

        public static void file_export_all()
        {
            if (!Directory.Exists(GlobalVariables.Path.Dir.MainFolder)) { Directory.CreateDirectory(GlobalVariables.Path.Dir.MainFolder); }
            if (!Directory.Exists(GlobalVariables.Path.Dir.DataFolder)) { Directory.CreateDirectory(GlobalVariables.Path.Dir.DataFolder); }
            
            if (!File.Exists(GlobalVariables.Path.File.Settings))
            {
                using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Settings))
                {
                    //COMMENTS
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                         + " ============[ FAPMAP SETTINGS ]============");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                         + "");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                         + "  FIREFOX.: firefox.exe -private-window");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                         + "  OPERA...: opera.exe --private");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                         + "  CHROME..: chrome.exe --incognito");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                         + "");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                         + "");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                         + "===[CHECKBOXES]");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                         + "");
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.HideOnX_                    + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.HideOnX));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.FocusHide_                  + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.FocusHide));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers_         + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers_       + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer_        + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer_       + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableFileDisplay_          + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableFileDisplay));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap_    + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap));
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                         + "");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                         + "===[WEBGRAB TABLE]");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                         + "");
                    string resource_data = Properties.Resources.webgrab_table;
                    List<string> words = resource_data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    foreach(string line in words) { w.WriteLine(GlobalVariables.Settings.Other.WebGrabTableLines_ + GlobalVariables.Settings.Common.Equal + line); }
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                + "");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                + "===[MOVE (FILE) TO]");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                + "");
                    w.WriteLine(GlobalVariables.Settings.Other.MoveFileToLines_        + GlobalVariables.Settings.Common.Equal + ".\\trash");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                + "");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                + "===[OTHER]");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment                + "");
                    w.WriteLine(GlobalVariables.Settings.WebBrowser.Browser_           + GlobalVariables.Settings.Common.Equal + GlobalVariables.Settings.WebBrowser.Browser);
                    w.WriteLine(GlobalVariables.Settings.WebBrowser.BrowserArguments_  + GlobalVariables.Settings.Common.Equal + GlobalVariables.Settings.WebBrowser.BrowserArguments);
                    w.WriteLine(GlobalVariables.Settings.WebBrowser.FapMapURL_         + GlobalVariables.Settings.Common.Equal + GlobalVariables.Settings.WebBrowser.FapMapURL);
                    w.WriteLine(GlobalVariables.Settings.Media.GifDelay_               + GlobalVariables.Settings.Common.Equal + GlobalVariables.Settings.Media.GifDelay);
                    w.WriteLine(GlobalVariables.Settings.Common.Comment     + "FILE TYPES FOR \"OPEN RANDOM FILE\" BUTTONS");
                    w.Write(GlobalVariables.Settings.Media.FileTypes.Video_ + GlobalVariables.Settings.Common.Equal);
                    foreach (string type in GlobalVariables.Settings.Media.FileTypes.Video)
                    { if (type == GlobalVariables.Settings.Media.FileTypes.Video[GlobalVariables.Settings.Media.FileTypes.Video.Count - 1])
                        { w.Write("*" + type); } else { w.Write("*" + type + ","); } } w.WriteLine("");
                    w.Write(GlobalVariables.Settings.Media.FileTypes.Image_ + GlobalVariables.Settings.Common.Equal);
                    foreach (string type in GlobalVariables.Settings.Media.FileTypes.Image)
                    { if (type == GlobalVariables.Settings.Media.FileTypes.Image[GlobalVariables.Settings.Media.FileTypes.Image.Count - 1])
                        { w.Write("*" + type); } else { w.Write("*" + type + ","); } } w.WriteLine("");
                    

                }
            }

            if (!File.Exists(GlobalVariables.Path.File.Links))
            {
                using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Links))
                {
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + " <- use this to comment");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + " comments can't be opened (with double click)");
                    w.WriteLine(@"https://www.google.com");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + " however the link above can...");
                }
            }

            if (!File.Exists(GlobalVariables.Path.File.Log)) { using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Log)) { w.WriteLine(GlobalVariables.Settings.Common.Comment + " " + new FileInfo(GlobalVariables.Path.File.Log).Name); } }
            if (!File.Exists(GlobalVariables.Path.File.Log)) { using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Log)) { w.WriteLine(GlobalVariables.Settings.Common.Comment + " " + new FileInfo(GlobalVariables.Path.File.Log).Name); } }
            if (!File.Exists(GlobalVariables.Path.File.Log)) { using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Log)) { w.WriteLine(GlobalVariables.Settings.Common.Comment + " " + new FileInfo(GlobalVariables.Path.File.Log).Name); } }
            if (!File.Exists(GlobalVariables.Path.File.Log)) { using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Log)) { w.WriteLine(GlobalVariables.Settings.Common.Comment + " " + new FileInfo(GlobalVariables.Path.File.Log).Name); } }

            if (!File.Exists(GlobalVariables.Path.File.Password))   { using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Password))    { foreach (string line in get_res_lines(Properties.Resources.passwords)) { w.WriteLine(line); } } }
            if (!File.Exists(GlobalVariables.Path.File.Keywords)) { using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Keywords))  { foreach (string line in get_res_lines(Properties.Resources.keywords)) { w.WriteLine(line); } } }
            if (!File.Exists(GlobalVariables.Path.File.Board))       { using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Board))        { foreach (string line in get_res_lines(Properties.Resources.board)) { w.WriteLine(line); } } }
        }

        private static List<string> get_res_lines(string file)
        {
            return file.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static void ImportBrowser(int browser)
        {
            fapmap.file_export_all();

            string brws = "firefox.exe";
            string args = "-private-window";

            switch (browser)
            {
                case 1: //chrome.exe --incognito
                    {
                        brws = "chrome.exe";
                        args = "--incognito";

                        break;
                    }
                case 2: //firefox.exe -private-window
                    {
                        brws = "firefox.exe";
                        args = "-private-window";

                        break;
                    }
                case 3: //opera.exe --private
                    {
                        brws = "opera.exe";
                        args = "--private";

                        break;
                    }

                default:
                    {
                        brws = "firefox.exe";
                        args = "-private-window";

                        break;
                    }
            }

            string[] lines = fapmap.SafeReadLines(fapmap.GlobalVariables.Path.File.Settings);

            using (FileStream fs = new FileStream(fapmap.GlobalVariables.Path.File.Settings, FileMode.Open))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    foreach (string line in lines)
                    {
                        if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line) && line != "")
                        {
                            if (!line.StartsWith(GlobalVariables.Settings.Common.Comment))
                            {
                                if (line.Contains(GlobalVariables.Settings.WebBrowser.BrowserArguments_ + GlobalVariables.Settings.Common.Equal))
                                {
                                    tw.WriteLine(GlobalVariables.Settings.WebBrowser.BrowserArguments_ + GlobalVariables.Settings.Common.Equal + args);
                                    fapmap.GlobalVariables.Settings.WebBrowser.BrowserArguments = args;
                                }
                                else if (line.Contains(GlobalVariables.Settings.WebBrowser.Browser_ + GlobalVariables.Settings.Common.Equal))
                                {
                                    tw.WriteLine(GlobalVariables.Settings.WebBrowser.Browser_ + GlobalVariables.Settings.Common.Equal + brws);
                                    fapmap.GlobalVariables.Settings.WebBrowser.Browser = brws;
                                }
                                else
                                {
                                    tw.WriteLine(line);
                                }
                            }
                            else
                            {
                                tw.WriteLine(line);
                            }
                        }
                    }

                    // Flush the writer in order to get a correct stream position for truncating
                    tw.Flush();
                    // Set the stream length to the current position in order to truncate leftover text
                    fs.SetLength(fs.Position);
                }
            }
        }
        public static void settings_edit(string setting_find, string newSetting)
        {
            fapmap.file_export_all();
            
            string[] lines = SafeReadLines(fapmap.GlobalVariables.Path.File.Settings);

            using (FileStream fs = new FileStream(fapmap.GlobalVariables.Path.File.Settings, FileMode.Open))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    foreach (string line in lines)
                    {
                        if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line) && line != "")
                        {
                            if (!line.StartsWith(GlobalVariables.Settings.Common.Comment))
                            {
                                if (line.Contains(setting_find + GlobalVariables.Settings.Common.Equal))
                                {
                                    tw.WriteLine(setting_find + GlobalVariables.Settings.Common.Equal + newSetting);
                                }
                                else
                                {
                                    tw.WriteLine(line);
                                }
                            }
                            else
                            {
                                tw.WriteLine(line);
                            }
                        }
                    }

                    // Flush the writer in order to get a correct stream position for truncating
                    tw.Flush();
                    // Set the stream length to the current position in order to truncate leftover text
                    fs.SetLength(fs.Position);
                }
            }
        }

        public static string[] SafeReadLines(String path)
        {
            using (var csv = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(csv))
            {
                List<string> file = new List<string>();
                while (!sr.EndOfStream)
                {
                    file.Add(sr.ReadLine());
                }

                return file.ToArray();
            }
        }

        public static void open_script(string file)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox
                           (
                               file + Environment.NewLine + Environment.NewLine + "arguments:",
                               "Open Batch File",
                               "",
                               -1,
                               -1
                           );

            if (!string.IsNullOrEmpty(input))
            {
                //FFMPEG
                Process bat = new Process();
                bat.StartInfo.FileName = file;
                bat.StartInfo.Arguments = input;
                bat.StartInfo.UseShellExecute = false;
                bat.StartInfo.CreateNoWindow = false;
                bat.StartInfo.WorkingDirectory = fapmap.GlobalVariables.Path.Dir.MainFolder;
                bat.StartInfo.RedirectStandardOutput = false;
                bat.StartInfo.RedirectStandardError = false;
                bat.Start();
            }
        }
        
        public static string ROund(double num)
        {
            // 1 Byte = 8 Bit
            // 1 Kilobyte = 1024 Bytes
            // 1 Megabyte = 1048576 Bytes
            // 1 Gigabyte = 1073741824 Bytes
            // 1 Terabyte = 1099511627776 Bytes

            string num_double_string = num + " B";

            if (num > 1099511627776) //TB
            {
                num = num / 1099511627776;
                num_double_string = Math.Round(num, 2) + " TB";
            }
            else if (num > 1073741824) //GB
            {
                num = num / 1073741824;
                num_double_string = Math.Round(num, 2) + " GB";
            }
            else if (num > 1048576) //MB
            {
                num = num / 1048576;
                num_double_string = Math.Round(num, 2) + " MB";
            }
            else if (num > 1024) //KB
            {
                num = num / 1024;
                num_double_string = Math.Round(num, 2) + " KB";
            }
            else
            {
                num_double_string = num + " B";
            }

            return num_double_string;
        }
        public static string get_epoch()
        {
            TimeSpan diff = (new DateTime(2011, 02, 10) - new DateTime(2011, 02, 01));
            return diff.TotalMilliseconds.ToString();
        }

        public static void draw_title(string default_title, string text, Panel title)
        {
            if (string.IsNullOrEmpty(text))
            {
                text = default_title;
            }

            Bitmap bmp = new Bitmap(text.Length * 8, 20);

            //graphics
            Graphics g = Graphics.FromImage(bmp);

            //clear graphics
            g.Clear(Color.Transparent);

            g.DrawString(text, new Font("Consolas", 10), Brushes.RoyalBlue, new PointF(0, 0));

            title.BackgroundImage = bmp;
            title.BackgroundImageLayout = ImageLayout.Center;
        }

        #endregion

        #region menu
        
        //OPEN
        private void menu_open_explorer_Click(object sender, EventArgs e) { file_export_all(); Process.Start("explorer.exe", GlobalVariables.Path.Dir.MainFolder); }
        private void menu_open_google_Click(object sender, EventArgs e) { Incognito("https://www.google.com"); }
        private void menu_open_finder_Click(object sender, EventArgs e) { fapmap_find fi = new fapmap_find(); fi.Show(); }
        private void menu_open_videoPlayer_Click(object sender, EventArgs e)
        {
            if (menu_cb_players_enable.Checked)
            {
                media_remove();
                showMedia_video_panel.Visible = true;
                showMedia_video_panel.BringToFront();
            }
            else
            {
                MessageBox.Show("Media players are disabled...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void menu_open_imageViewer_Click(object sender, EventArgs e)
        {
            if (menu_cb_players_enable.Checked)
            {
                media_remove();
                showMedia_image_panel.Visible = true;
                showMedia_image_panel.BringToFront();
            }
            else
            {
                MessageBox.Show("Media players are disabled...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void menu_open_urlBoard_Click(object sender, EventArgs e) { fapmap_board fb = new fapmap_board(); fb.Show(); }
        private void menu_open_converter_Click(object sender, EventArgs e) { fapmap_ffmpeg ff = new fapmap_ffmpeg(); ff.Show(); }
        private void menu_open_urlDownloader_Click(object sender, EventArgs e) { fapmap_download fd = new fapmap_download(); fd.Show(); }
        private void menu_open_logViewer_Click(object sender, EventArgs e) { fapmap_log fl = new fapmap_log(); fl.Show(); }
        private void menu_open_credits_Click(object sender, EventArgs e) { fapmap_credit fc = new fapmap_credit(); fc.Show(); }
        private void menu_open_settings_Click(object sender, EventArgs e) { fapmap_settings fs = new fapmap_settings(); fs.Show(); }


        //HIDE GALLERY
        private void menu_hideGallery_0_Click(object sender, EventArgs e) { gallery_hide(0); }
        private void menu_hideGallery_1_Click(object sender, EventArgs e) { gallery_hide(1); }
        private void menu_hideGallery_2_Click(object sender, EventArgs e) { gallery_hide(2); }

        #endregion

        #region tabs[2]
        
        private bool panel1_show = true;
        private void menu_changeTabs_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //normal switch
                if (panel1_show)
                {
                    //hide 2
                    splitContainer_main.Panel2Collapsed = true;
                    splitContainer_main.Panel2.Hide();

                    //show 1
                    splitContainer_main.Panel1Collapsed = false;
                    splitContainer_main.Panel1.Show();

                    panel1_show = false;
                }
                else
                {
                    //hide 1
                    splitContainer_main.Panel1Collapsed = true;
                    splitContainer_main.Panel1.Hide();

                    //show 2
                    splitContainer_main.Panel2Collapsed = false;
                    splitContainer_main.Panel2.Show();

                    panel1_show = true;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                //show both
                splitContainer_main.Panel1Collapsed = false;
                splitContainer_main.Panel2Collapsed = false;
                splitContainer_main.Panel1.Show();
                splitContainer_main.Panel2.Show();
            }
        }

        #endregion

        #region fileDisplay

        #region fileDisplay -> Functions

        private void fileDisplay_startFile(bool openDirs = false)
        {
            foreach (ListViewItem item in fileDisplay.SelectedItems)
            {
                string file = item.Tag.ToString();

                if (Directory.Exists(file))
                {
                    if (openDirs)
                    {
                        try
                        {
                            Process.Start(file);
                            media_remove(menu_cb_players_autoHide.Checked);
                            LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, file);
                        }
                        catch (Exception)
                        {
                            LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file);
                            MessageBox.Show(file, "Application for the file not found. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, file);
                        this.Text = "FAPMAP: OPENED: " + file;
                    }
                    else
                    {
                        load_file_or_dir(file);
                    }
                }
                else if (File.Exists(file))
                {
                    if (new FileInfo(file).Name.Contains("fapmap_mod"))
                    {
                        open_script(file);
                    }
                    else
                    {

                        try
                        {
                            Process.Start(file);
                            media_remove(menu_cb_players_autoHide.Checked);

                            LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, file);
                            this.Text = "FAPMAP: OPENED: " + file;
                        }
                        catch (Exception)
                        {
                            LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file);
                            MessageBox.Show(file, "Application for the file not found. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void fileDisplay_backDir()
        {
            string path = this.faftv_path.Text;
            if (File.Exists(path)) { path = Directory.GetParent(path).ToString(); }
            if (!Directory.Exists(path)) { load_file_or_dir(GlobalVariables.Path.Dir.MainFolder); return; }
            
            if (new DirectoryInfo(path).Name != new DirectoryInfo(GlobalVariables.Path.Dir.MainFolder).Name)
            { load_file_or_dir(Directory.GetParent(path).ToString()); }
        }
        private void fileDisplay_delete()
        {
            media_remove(menu_cb_players_autoHide.Checked);

            foreach (ListViewItem item in fileDisplay.SelectedItems)
            {
                if (item != null)
                {
                    if (File.Exists(item.Tag.ToString()))
                    {
                        FileInfo fi = new FileInfo(item.Tag.ToString());

                        try
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(fi.FullName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                        }
                        catch (System.OperationCanceledException) { return; }
                        catch (IOException) { return; }
                        catch (UnauthorizedAccessException) { return; }

                        //REMOVE NODE
                        fileDisplay.Items.Remove(item);

                        //DISPLAY
                        LogThis(fapmap.GlobalVariables.LOG_TYPE.RMVD, fi.FullName);
                        this.Text = "FAPMAP: REMOVED: " + fi.FullName;
                    }
                    else if (Directory.Exists(item.Tag.ToString()))
                    {
                        DirectoryInfo di = new DirectoryInfo(item.Tag.ToString());

                        try
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(di.FullName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                        }
                        catch (System.OperationCanceledException) { return; }
                        catch (IOException) { return; }
                        catch (UnauthorizedAccessException) { return; }

                        //REMOVE NODE
                        fileDisplay.Items.Remove(item);

                        //DISPLAY
                        LogThis(fapmap.GlobalVariables.LOG_TYPE.RMVD, di.FullName);
                        this.Text = "FAPMAP: REMOVED: " + di.FullName;
                    }
                }
            }
        }
        private void fileDisplay_newFolder()
        {
            string path = this.faftv_path.Text;

            //if file get parent dir
            if (File.Exists(path)) { path = Directory.GetParent(path).ToString(); }

            string input = Microsoft.VisualBasic.Interaction.InputBox("New Folder in: " + path, "Create New Folder", "New Folder", -1, -1);

            if (!string.IsNullOrEmpty(input))
            {
                if (!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(path))
                {
                    Directory.CreateDirectory(path + "\\" + input);
                }

                fileDisplay_icons.Images.Add(Properties.Resources.image_selection_explorer);
                fileDisplay.Items.Add(input, fileDisplay_icons.Images.Count - 1);
                fileDisplay.Items[fileDisplay.Items.Count - 1].Tag = path + "\\" + input;
                
                //DISPLAY
                LogThis(GlobalVariables.LOG_TYPE.MDIR, path + "\\" + input);
                this.Text = "FAPMAP: MKDIR: " + path + "\\" + input;
            }
        }

        #endregion

        #region fileDisplay -> CTRLS

        //DISABLE/ENABLE FILE DISPLAY
        private void fileDisplay_sw()
        {
            if (!menu_cb_fapmap_fileDisplay.Checked)
            {
                splitContainer_files.Panel2.Hide();
                splitContainer_files.Panel2Collapsed = true;
            }
            else
            {
                splitContainer_files.Panel2.Show();
                splitContainer_files.Panel2Collapsed = false;
            }
        }
        private void menu_cb_fapmap_fileDisplay_CheckedChanged(object sender, EventArgs e)
        {
            fileDisplay_sw();
        }

        private void fileDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (menu_cb_fapmap_outside.Checked)
            {
                fileDisplay_startFile();
            }
            else
            {
                foreach (ListViewItem item in fileDisplay.SelectedItems)
                {
                    if (item != null)
                    {
                        if (!Directory.Exists(item.Tag.ToString()))
                        {
                            load_file_or_dir(item.Tag.ToString());
                        }
                        else
                        {
                            fileDisplay_startFile();
                        }
                    }
                }
            }
        }
        private void fileDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in fileDisplay.SelectedItems)
            {
                if (item != null)
                {
                    if (!Directory.Exists(item.Tag.ToString()))
                    {
                        load_file_or_dir(item.Tag.ToString());
                    }
                }
            }
        }

        //BTNS
        private void fileDisplay_btn_backDir_Click(object sender, EventArgs e)
        {
            fileDisplay_backDir();
        }
        private void fileDisplay_btn_reload_Click(object sender, EventArgs e)
        {
            load_file_or_dir(faftv_path.Text);
        }
        private void fileDisplay_btn_root_Click(object sender, EventArgs e)
        {
            load_file_or_dir(GlobalVariables.Path.Dir.MainFolder);
        }
        private void fileDisplay_btn_rename_Click(object sender, EventArgs e)
        {
            string item = faftv_path.Text;

            if (File.Exists(item))
            {
                media_remove(menu_cb_players_autoHide.Checked);

                FileInfo fi = new FileInfo(item);
                string input = Microsoft.VisualBasic.Interaction.InputBox(fi.Name, "Rename file?", fi.Name, -1, -1);

                if (!string.IsNullOrEmpty(input))
                {
                    string str1 = fi.FullName;
                    string str2 = fi.FullName.Replace(fi.Name, input);

                    File.Move(str1, str2);
                    
                    //DISPLAY
                    LogThis(fapmap.GlobalVariables.LOG_TYPE.RENM, str1 + " -> " + str2);
                    this.Text = "FAPMAP: RENAMED: " + str1 + " -> " + str2;
                }
            }
            else if (Directory.Exists(item))
            {
                if (item == fapmap.GlobalVariables.Path.Dir.MainFolder)
                {
                    MessageBox.Show("You can't rename \"Main Folder\"", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(item);
                    string input = Microsoft.VisualBasic.Interaction.InputBox(di.Name, "Rename directory?", di.Name, -1, -1);

                    if (!string.IsNullOrEmpty(input))
                    {
                        string str1 = di.FullName;
                        string str2 = di.FullName.Replace(di.Name, input);

                        Directory.Move(str1, str2);

                        //DISPLAY
                        LogThis(GlobalVariables.LOG_TYPE.RENM, str1 + "->" + str2);
                        this.Text = "FAPMAP: RENAMED: " + str1 + "->" + str2;
                    }
                }
            }
        }
        private void fileDisplay_btn_trashFile_Click(object sender, EventArgs e)
        {
            string file = faftv_path.Text;

            if (!string.IsNullOrEmpty(file))
            {
                if (File.Exists(file))
                {
                    FileInfo fi = new FileInfo(file);

                    media_remove(menu_cb_players_autoHide.Checked);
                    this.Cursor = Cursors.Arrow;

                    try
                    {
                        // txt_path.Text = Directory.GetParent(fi.FullName).ToString();
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(fi.FullName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                    }
                    catch (System.OperationCanceledException) { return; }
                    catch (IOException) { return; }
                    catch (UnauthorizedAccessException) { return; }

                    //DISPLAY
                    LogThis(fapmap.GlobalVariables.LOG_TYPE.RMVD, fi.FullName);
                    this.Text = "FAPMAP: REMOVED: " + fi.FullName;
                }
                else
                {
                    LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file);
                    this.Text = "FAPMAP: File not found: " + file;
                }
            }
        }
        //OPEN FILE
        private void fileDisplay_btn_open_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                open_file(faftv_path.Text);
            }
            else if (e.Button == MouseButtons.Right)
            {
                open_in_explorer(faftv_path.Text);
            }
        }
        #endregion

        #region fileDisplay -> RMB/SHORTCUTS

        bool fileDisplay_ctrl = false;
        bool fileDisplay_shift = false;
        
        private void fileDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            fileDisplay_ctrl = e.Control;
            fileDisplay_shift = e.Shift;

            switch (e.KeyCode)
            {
                case Keys.F5: load_dir(); break;
                case Keys.Enter: e.SuppressKeyPress = true; fileDisplay_startFile(); break;
                case Keys.Back: fileDisplay_backDir(); break;
                case Keys.Delete: fileDisplay_delete(); break;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R: load_dir(); break;
                    case Keys.U: foreach (ListViewItem lvi in fileDisplay.SelectedItems) { open_in_explorer(lvi.Tag.ToString()); } break;
                    case Keys.W: string path = this.faftv_path.Text; if (File.Exists(path)) { path = Directory.GetParent(this.faftv_path.Text).ToString(); } Process.Start(@"explorer.exe", path); break;
                    case Keys.E: fileDisplay_newFolder(); break;
                    case Keys.P: foreach (ListViewItem lvi in fileDisplay.SelectedItems) { start_fapmap_info(lvi.Tag.ToString()); } break;
                    case Keys.T: media_sw(); break;
                    case Keys.F: fapmap_find fi = new fapmap_find(); fi.Show(); break;
                    case Keys.G: fapmap_settings fs = new fapmap_settings(); fs.Show(); break;
                    case Keys.Z: Random_VOI(e.Shift ? GlobalVariables.Path.Dir.MainFolder : faftv_path.Text, "video", false); break;
                    case Keys.X: Random_VOI(e.Shift ? GlobalVariables.Path.Dir.MainFolder : faftv_path.Text, "image", false); break;
                }
            }
        }
        private void fileDisplay_KeyUp(object sender, KeyEventArgs e)
        {
            fileDisplay_ctrl = false;
            fileDisplay_shift = false;
        }
        private void fileDisplay_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            bool IsGoUp = e.Delta > 0 ? true : false;

            if (fileDisplay_ctrl)
            {
                if (fileDisplay_shift)
                {
                    if (IsGoUp)
                    {
                        fileDisplay_sideSize = fileDisplay_sideSize + 10;

                        //max
                        if (fileDisplay_sideSize <= 50) { fileDisplay_sideSize = 50; }
                        else if (fileDisplay_sideSize >= 250) { fileDisplay_sideSize = 250; }

                        //change view
                        if (fileDisplay_sideSize == 50) { fileDisplay.View = View.Tile; }
                        else if (fileDisplay_sideSize >= 60) { fileDisplay.View = View.LargeIcon; }
                        // else if (fileDisplay_side <= 100) { fileDisplay.View = View.SmallIcon; }


                        // Thread th = new Thread(() => load_dir(true));
                        // th.IsBackground = true;
                        // th.Start();
                    }
                    else
                    {
                        fileDisplay_sideSize = fileDisplay_sideSize - 10;

                        //max
                        if (fileDisplay_sideSize <= 50) { fileDisplay_sideSize = 50; }
                        else if (fileDisplay_sideSize >= 250) { fileDisplay_sideSize = 250; }

                        //change view
                        if (fileDisplay_sideSize == 50) { fileDisplay.View = View.Tile; }
                        else if (fileDisplay_sideSize >= 60) { fileDisplay.View = View.LargeIcon; }
                        // else if (fileDisplay_side <= 100) { fileDisplay.View = View.SmallIcon; }


                        // Thread th = new Thread(() => load_dir(true));
                        // th.IsBackground = true;
                        // th.Start();
                    }
                }
                else
                {
                    if (IsGoUp)
                    {
                        fileDisplay_sideSize++;

                        //max
                        if (fileDisplay_sideSize <= 50) { fileDisplay_sideSize = 50; }
                        else if (fileDisplay_sideSize >= 250) { fileDisplay_sideSize = 250; }

                        //change view
                        if (fileDisplay_sideSize == 50) { fileDisplay.View = View.Tile; }
                        else if (fileDisplay_sideSize >= 60) { fileDisplay.View = View.LargeIcon; }
                        // else if (fileDisplay_side <= 100) { fileDisplay.View = View.SmallIcon; }

                        fileDisplay_icons.ImageSize = new System.Drawing.Size(fileDisplay_sideSize, fileDisplay_sideSize);
                        fileDisplay.Refresh();

                        // Thread th = new Thread(() => load_dir(true));
                        // th.IsBackground = true;
                        // th.Start();
                    }
                    else
                    {
                        fileDisplay_sideSize--;

                        //max
                        if (fileDisplay_sideSize <= 50) { fileDisplay_sideSize = 50; }
                        else if (fileDisplay_sideSize >= 250) { fileDisplay_sideSize = 250; }

                        //change view
                        if (fileDisplay_sideSize == 50) { fileDisplay.View = View.Tile; }
                        else if (fileDisplay_sideSize >= 60) { fileDisplay.View = View.LargeIcon; }
                        // else if (fileDisplay_side <= 100) { fileDisplay.View = View.SmallIcon; }

                        fileDisplay_icons.ImageSize = new System.Drawing.Size(fileDisplay_sideSize, fileDisplay_sideSize);
                        fileDisplay.Refresh();

                        // Thread th = new Thread(() => load_dir(true));
                        // th.IsBackground = true;
                        // th.Start();
                    }
                }
            }
        }
        
        //F5
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            load_file_or_dir(faftv_path.Text);
        }
        //OPEN
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            fileDisplay_startFile(true);
        }
        //OPEN IN EXPLORER
        private void openInExplorerCTRLFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem lvi in fileDisplay.SelectedItems)
            {
                open_in_explorer(lvi.Tag.ToString());
            }
        }
        //WIN EXP
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            string path = this.faftv_path.Text;

            if (File.Exists(path))
            {
                path = Directory.GetParent(this.faftv_path.Text).ToString();
            }

            Process.Start(@"explorer.exe", path);
        }
        //DELTE FILE/FOLDER
        private void deleteFileDELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileDisplay_delete();
        }
        //NEW FOLDER
        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileDisplay_newFolder();
        }
        //properties
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in fileDisplay.SelectedItems)
            {
                start_fapmap_info(lvi.Tag.ToString());
            }
        }

        #endregion

        #region fileDisplay -> Load
        
        #region GIF VIEWER

        //GET BITMAPS
        Bitmap[] getFrames(Image originalImg)
        {
            int numberOfFrames = originalImg.GetFrameCount(FrameDimension.Time);
            Bitmap[] frames = new Bitmap[numberOfFrames];

            for (int i = 0; i < numberOfFrames; i++)
            {
                originalImg.SelectActiveFrame(FrameDimension.Time, i);
                frames[i] = new Bitmap(originalImg);
            }

            return frames;
        }

        //OUR image frames
        Bitmap[] showMedia_image_gif_frames = null;

        private void showMedia_image_gif_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                //AUTO RESET
                if (showMedia_image_gif_trackbar.Value == showMedia_image_gif_trackbar.Maximum)
                {
                    showMedia_image_gif_trackbar.Value = 1; //reset
                }
                else
                {
                    showMedia_image_gif_trackbar.Value++; //update ++
                }
            }
            catch (System.NullReferenceException) {  }
            catch (Exception) {  }
        }

        private void showMedia_image_gif_trackbar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                showMedia_image.Image = showMedia_image_gif_frames[showMedia_image_gif_trackbar.Value - 1];
                showMedia_image_gif_frame.Text = showMedia_image_gif_trackbar.Value + " / " + showMedia_image_gif_trackbar.Maximum;
            }
            catch (Exception) {  }
        }

        private bool showMedia_image_gif_paused = false;
        private void showMedia_image_gif_play_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!showMedia_image_gif_timer.Enabled)
                {
                    showMedia_image_gif_timer.Enabled = true;
                    showMedia_image_gif_play.BackgroundImage = Properties.Resources.image_button_pause;
                    showMedia_image_gif_paused = false;
                }
                else
                {
                    showMedia_image_gif_timer.Enabled = false;
                    showMedia_image_gif_play.BackgroundImage = Properties.Resources.image_button_play;
                    showMedia_image_gif_paused = true;
                }
            }
        }

        private void showMedia_image_gif_trackbar_KeyDown(object sender, KeyEventArgs e)
        {
            //HOLD RIGHT
            if (e.KeyCode == Keys.Right)
            {
                //AUTO RESET WHEN END REACHED
                if (showMedia_image_gif_trackbar.Value == showMedia_image_gif_trackbar.Maximum)
                {
                    showMedia_image_gif_trackbar.Value = 0; //reset
                    showMedia_image_gif_frame.Text = "0 / " + showMedia_image_gif_trackbar.Maximum;
                    e.SuppressKeyPress = true; //if not supressed it will skip the first one instantly when reset
                }
            }

            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                showMedia_image_gif_play_MouseUp(null, null);
            }
        }

        #endregion


        private void media_title_echo(string path, Panel contrl)
        {
            string text = string.Empty;

            if (File.Exists(path))
            {
                text = Directory.GetParent(path).Name + "\\" + new FileInfo(path).Name;
            }
            else if (media_isFile(path))
            {
                text = path;
            }

            Bitmap bmp = new Bitmap(text.Length * 8, 20);

            //graphics
            Graphics g = Graphics.FromImage(bmp);

            //clear graphics
            g.Clear(Color.Transparent);

            g.DrawString(text, new Font("Consolas", 10), Brushes.Silver, new PointF(0, 0));

            contrl.BackgroundImage = bmp;
            contrl.BackgroundImageLayout = ImageLayout.Center;
        }

        private void load_file()
        {
            if (!menu_cb_players_enable.Checked) { return; }

            string selected_path = faftv_path.Text;
            
            if (string.IsNullOrEmpty(selected_path)) { return; }
            if (!File.Exists(selected_path)) { return; }


            //CHECK IF IMAGE FILE
            foreach (string type in GlobalVariables.FileTypes.Image)
            {
                if (selected_path.EndsWith(type))
                {
                    //LOAD FOR GIFS
                    if (menu_cb_players_trackbar.Checked && selected_path.EndsWith(".gif")) //GIF VIEWER
                    {
                        this.Text = "FAPMAP: LOADING: " + selected_path;

                        bool gif_is_valid = true;

                        //LOAD
                        try
                        {
                            Image img = Image.FromFile(selected_path);
                            showMedia_image_gif_frames = getFrames(img);
                            img.Dispose();
                        }
                        catch (OutOfMemoryException) { gif_is_valid = false; }
                        catch (Exception) { gif_is_valid = false; }

                        if (gif_is_valid)
                        {
                            //SET UP EVERYTHING
                            showMedia_image_gif_trackbar.Maximum = showMedia_image_gif_frames.Length;
                            showMedia_image_gif_trackbar.ScaleDivisions = showMedia_image_gif_trackbar.Maximum - 1;
                            showMedia_image_gif_trackbar.Value = 1;
                            showMedia_image.Image = showMedia_image_gif_frames[showMedia_image_gif_trackbar.Value - 1];
                            showMedia_image_gif_frame.Text = showMedia_image_gif_trackbar.Value + " / " + showMedia_image_gif_trackbar.Maximum;

                            showMedia_image_gifbox(true);

                            if (!showMedia_image_gif_paused)
                            {
                                //START TIMER
                                showMedia_image_gif_timer.Enabled = true;
                            }

                            LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, selected_path);
                            this.Text = "FAPMAP: SHOWING: " + selected_path;
                            media_title_echo(selected_path, showMedia_image_title);

                            return;
                        }
                    }
                    
                    //NORMAL LOAD
                    showMedia_image_gifbox(false);

                    try
                    {
                        if (selected_path.EndsWith(".gif")) //without trackbar
                        {
                            showMedia_image.Image = Image.FromFile(selected_path); //use image
                        }
                        else
                        {
                            showMedia_image.Image = GetImage(selected_path); //copy image
                        }
                        showMedia_image_panel.Visible = true;
                        showMedia_image_panel.BringToFront();
                    }
                    catch (Exception)
                    {
                        LogThis(GlobalVariables.LOG_TYPE.LOAD, "Error loading image file: " + selected_path);
                        MessageBox.Show(selected_path, "Image file is invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        media_remove(menu_cb_players_autoHide.Checked);
                    }

                    LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, selected_path);
                    this.Text = "FAPMAP: SHOWING: " + selected_path;
                    media_title_echo(selected_path, showMedia_image_title);
                }
            }

            foreach (string type in GlobalVariables.FileTypes.Video)
            {
                if (selected_path.EndsWith(type))
                {
                    try
                    {
                        showMedia_video.URL = selected_path;
                        showMedia_video_panel.Visible = true;
                        showMedia_video_panel.BringToFront();
                    }
                    catch (Exception)
                    {
                        LogThis(GlobalVariables.LOG_TYPE.LOAD, "Error loading video file: " + selected_path);
                        MessageBox.Show(selected_path, "Video file is invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, selected_path);
                    this.Text = "FAPMAP: SHOWING: " + selected_path;
                    media_title_echo(selected_path, showMedia_video_title);

                    return;
                }
            }
        }

        //LOAD DIR
        private bool load_dir_busy = false;
        private int fileDisplay_sideSize = 50;
        private int load_dir()
        {
            //invoke
            if (fileDisplay.InvokeRequired) { return (int)fileDisplay.Invoke(new Func<int>(load_dir)); }

            if (menu_cb_fapmap_fileDisplay.Checked)
            {
                if (!load_dir_busy)
                {
                    load_dir_busy = true;

                    fileDisplay.Items.Clear();
                    fileDisplay_icons.Images.Clear();
                    
                    //IF NULL
                    if (faftv_path.Text == "NULL") { faftv_path.Text = GlobalVariables.Path.Dir.MainFolder; }

                    //IF FILE GET PARENT DIR OF FILE
                    if (File.Exists(faftv_path.Text) || !Directory.Exists(faftv_path.Text))
                    { load_dir_busy = false; faftv_path.Text = Directory.GetParent(faftv_path.Text).ToString(); load_dir(); return 1; }

                    //max
                    if      (fileDisplay_sideSize <= 50)  { fileDisplay_sideSize = 50;  }
                    else if (fileDisplay_sideSize >= 250) { fileDisplay_sideSize = 250; }
                    fileDisplay_icons.ImageSize = new System.Drawing.Size(fileDisplay_sideSize, fileDisplay_sideSize);

                    DirectoryInfo MainPath = new DirectoryInfo(faftv_path.Text);
                    this.Text = "FAPMAP: Loading...";

                    List<ListViewItem> items = new List<ListViewItem>();
                    int imgIndex = -1;

                    DirectoryInfo[] dirs = MainPath.GetDirectories();
                    FileInfo[] files = MainPath.GetFiles();
                    
                    ListViewItem[] dirs_lvis = new ListViewItem[dirs.Length];
                    ListViewItem[] files_lvis = new ListViewItem[files.Length];

                    for (int i = 0; i < dirs.Length; i++)
                    {
                        imgIndex++;

                        //DISABLED MID LOAD
                        if (!menu_cb_fapmap_fileDisplay.Checked) { this.Text = "FAPMAP"; load_dir_busy = false; return 1; }
                        if (!faftv_path.Text.Contains(MainPath.Name) || (MainPath.FullName != faftv_path.Text && Directory.Exists(faftv_path.Text))) { load_dir_busy = false; load_dir(); return 1; }
                        
                        fileDisplay_icons.Images.Add(imgIndex.ToString(), Properties.Resources.image_selection_explorer);
                        
                        items.Add(new ListViewItem() { Name = dirs[i].Name, Text = dirs[i].Name, ImageIndex = imgIndex, Tag = dirs[i].FullName });
                    }
                    
                    for (int i = 0; i < files.Length; i++)
                    {
                        imgIndex++;

                        //DISABLED MID LOAD
                        if (!menu_cb_fapmap_fileDisplay.Checked) { this.Text = "FAPMAP"; load_dir_busy = false; return 1; }
                        if (!faftv_path.Text.Contains(MainPath.Name) || (MainPath.FullName != faftv_path.Text && Directory.Exists(faftv_path.Text))) { load_dir_busy = false; load_dir(); return 1; }

                        if (files[i].Name != "desktop.ini")
                        {
                            bool thumbnailExists = false;
                            foreach (string type in GlobalVariables.FileTypes.Image) {
                                if (files[i].Extension == type) { // must be image

                                    try { // try getting thumbnail directly
                                        Image thumb = GetThumbnailDirectly(files[i].FullName);
                                        int side_size = thumb.Width > thumb.Height ? thumb.Width : thumb.Height;
                                        Bitmap bmp = new Bitmap(side_size, side_size);
                                        using (Graphics g = Graphics.FromImage(bmp)) { g.Clear(Color.Transparent); g.DrawImage(thumb, 0, 0); }
                                        fileDisplay_icons.Images.Add(bmp);
                                    } catch (Exception) {

                                        try{ // get image from file
                                            Image thumb = Image.FromFile(files[i].FullName);
                                            int side_size = thumb.Width > thumb.Height ? thumb.Width : thumb.Height;
                                            Bitmap bmp = new Bitmap(side_size, side_size);
                                            using (Graphics g = Graphics.FromImage(bmp)) { g.Clear(Color.Transparent); g.DrawImage(thumb, 0, 0); }
                                            fileDisplay_icons.Images.Add(bmp);
                                        }
                                        catch (Exception) { thumbnailExists = false; break; }
                                    }                                    
                            
                                    thumbnailExists = true;
                                    break;
                                }
                            }
                            
                            if (!thumbnailExists) //get FILE thumb
                                try { fileDisplay_icons.Images.Add(Icon.ExtractAssociatedIcon(files[i].FullName).ToBitmap()); }
                                catch (Exception) { fileDisplay_icons.Images.Add(Properties.Resources.image_error); }
                            
                            items.Add(new ListViewItem() { Name = files[i].Name, Text = files[i].Name, ImageIndex = imgIndex, Tag = files[i].FullName });
                        }
                    }

                    //add items
                    fileDisplay.Items.AddRange(items.ToArray());

                    fileDisplay.Refresh();
                    load_dir_busy = false;
                    this.Text = "FAPMAP: LOADED: " + fileDisplay.Items.Count + " item(s)";

                    if (MainPath.FullName != faftv_path.Text && Directory.Exists(faftv_path.Text))
                    { load_dir_busy = false; load_dir(); return 1; }
                }
            }

            return 0;
        }
        
        private const int THUMBNAIL_DATA = 0x501B;
        private Image GetThumbnailDirectly(string path)
        {
            FileStream fs = File.OpenRead(path);
            // Last parameter tells GDI+ not the load the actual image data
            Image img = Image.FromStream(fs, false, false);


            // GDI+ throws an error if we try to read a property when the image
            // doesn't have that property. Check to make sure the thumbnail property
            // item exists.
            bool propertyFound = false;
            for (int i = 0; i < img.PropertyIdList.Length; i++)
                if (img.PropertyIdList[i] == THUMBNAIL_DATA)
                {
                    propertyFound = true;
                    break;
                }

            if (!propertyFound)
                return null;

            PropertyItem p = img.GetPropertyItem(THUMBNAIL_DATA);
            fs.Close();
            img.Dispose();


            // The image data is in the form of a byte array. Write all 
            // the bytes to a stream and create a new image from that stream
            byte[] imageBytes = p.Value;
            MemoryStream stream = new MemoryStream(imageBytes.Length);
            stream.Write(imageBytes, 0, imageBytes.Length);

            return Image.FromStream(stream);
        }

        //LOAD
        private void load_file_or_dir(string selected_path)
        {
            faftv_path.Text = selected_path;
            
            if (Directory.Exists(selected_path))
            {
                //CLEAR, HIDE
                if (menu_cb_players_autoHide.Checked) { media_remove(true); }

                load_dir();

                return;
            }

            if (File.Exists(selected_path))
            {
                //CLEAR, SHOW ANOTHER FILE
                media_remove(true);

                load_file();

                return;
            }
            

            if (menu_cb_players_enable.Checked && media_isFile(selected_path))
            {
                media_playUrl(selected_path);
                return;
            }

            media_remove(false);
        }

        #endregion

        #region fileDisplay -> File Managment

        private void fileDisplay_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = System.Windows.Forms.DragDropEffects.All;
        }
        private void fileDisplay_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop, false);

            foreach (string item in FileList)
            {
                string parent = faftv_path.Text;
                string dest = "";

                //get parent if file is txt_path.Text
                if (File.Exists(faftv_path.Text)) { parent = Directory.GetParent(faftv_path.Text).ToString(); }

                if (Directory.Exists(item)) //copy dir
                {
                    DirectoryInfo di = new DirectoryInfo(item);
                    dest = parent + "\\" + di.Name;
                    try
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(di.FullName, dest);
                    }
                    catch (ArgumentException) { MessageBox.Show("ERRO[ArgumentException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (DirectoryNotFoundException) { MessageBox.Show("ERRO[DirectoryNotFoundException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (IOException) { MessageBox.Show("ERRO[IOException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (InvalidOperationException) { MessageBox.Show("ERRO[InvalidOperationException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (NotSupportedException) { MessageBox.Show("ERRO[NotSupportedException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (System.Security.SecurityException) { MessageBox.Show("ERRO[SecurityException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (UnauthorizedAccessException) { MessageBox.Show("ERRO[UnauthorizedAccessException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (Exception) { MessageBox.Show("ERRO[Exception]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else if (File.Exists(item))
                {
                    //copy file
                    FileInfo fi = new FileInfo(item);
                    dest = parent + "\\" + fi.Name;
                    try
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(fi.FullName, dest);
                    }
                    catch (ArgumentException) { MessageBox.Show("ERRO[ArgumentException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (FileNotFoundException) { MessageBox.Show("ERRO[FileNotFoundException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (IOException) { MessageBox.Show("ERRO[IOException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (InvalidOperationException) { MessageBox.Show("ERRO[InvalidOperationException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (NotSupportedException) { MessageBox.Show("ERRO[NotSupportedException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (System.Security.SecurityException) { MessageBox.Show("ERRO[SecurityException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (UnauthorizedAccessException) { MessageBox.Show("ERRO[UnauthorizedAccessException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    catch (Exception) { MessageBox.Show("ERRO[Exception]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }

            load_dir();
        }

        //... not finished ...

        #endregion

        #endregion

        #region media
            
        //PATH
        private void txt_path_TextChanged(object sender, EventArgs e)
        {
            faftv_path.Text = faftv_path.Text.Replace("\n", String.Empty);
            faftv_path.Text = faftv_path.Text.Replace("\r", String.Empty);
            faftv_path.Text = faftv_path.Text.Replace("\t", String.Empty);

            if (File.Exists(faftv_path.Text) || Directory.Exists(faftv_path.Text))
            {
                faftv_path.ForeColor = Color.Silver;
            }
            else
            {
                faftv_path.ForeColor = Color.Red;
            }

            if (string.IsNullOrEmpty(faftv_path.Text) || string.IsNullOrWhiteSpace(faftv_path.Text) || faftv_path.Text == "NULL")
            {
                faftv_path.Text = GlobalVariables.Path.Dir.MainFolder;
            }

            
        }
        private void txt_path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                {
                    ((TextBox)sender).SelectAll();
                }
            }

            if (e.Control && e.KeyCode == Keys.V)
            {
                string paste = System.Windows.Clipboard.GetText();
                load_file_or_dir(paste);
            }
        }
        private void txt_path_DragDrop(object sender, DragEventArgs e)
        {
            string stringData = e.Data.GetData(typeof(string)) as string;
            load_file_or_dir(stringData);
        }

        private void txt_path_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }

        private void open_file(string file)
        {
            if (File.Exists(file))
            {
                try
                {
                    Process.Start(file);
                    media_remove(menu_cb_players_autoHide.Checked);
                    LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, file);
                    this.Text = "FAPMAP: OPENED: " + file;
                }
                catch (Exception)
                {
                    LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file);
                    MessageBox.Show(file, "Application for the file not found. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file);
                this.Text = "FAPMAP: File not found: " + file;
            }
        }

        //OPEN IN EXPLORER
        public static void open_in_explorer(string file)
        {
            Process.Start("explorer.exe", "/select, \"" + file + "\"");
        }

        //ENABLE MEDIA PLAYERS
        private void menu_cb_players_enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!menu_cb_players_enable.Checked)
            {
                media_close();
                media_repos();
            }
            else
            {
                load_file_or_dir(faftv_path.Text);
            }
        }

        //CLOSE PLAYERS
        private void showMedia_close(object sender, EventArgs e)
        {
            media_close();
        }

        //EXPLOERR VIDEO
        private void showMedia_explorer(object sender, EventArgs e)
        {
            open_in_explorer(faftv_path.Text);
        }

        private void showMedia_openFile(object sender, EventArgs e)
        {
            open_file(faftv_path.Text);
        }

        //CONVERT
        private void showMedia_convert(object sender, EventArgs e)
        {
            if (File.Exists(faftv_path.Text))
            {
                fapmap_ffmpeg ff = new fapmap_ffmpeg();
                fapmap_ffmpeg.passed_location = faftv_path.Text;
                ff.Show();

                media_remove(menu_cb_players_autoHide.Checked);
            }
            else
            {
                this.Text = "FAPMAP: File not found.";
            }
        }


        private void start_fapmap_info(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                new fapmap_info() { path = text }.Show();
            }
        }

        //PROPERTIES
        private void showMedia_info(object sender, EventArgs e)
        {
            if (File.Exists(faftv_path.Text))
            {
                start_fapmap_info(faftv_path.Text);
            }
            else
            {
                this.Text = "FAPMAP: File not found.";
            }
        }
        
        //REMOVE PLAYERS
        private void media_close()
        {
            //UNDOCK VIDEO
            showMedia_video_title.Cursor = Cursors.Cross;
            showMedia_video_panel.Cursor = Cursors.SizeNWSE;
            showMedia_video_panel.Dock = DockStyle.None;
            showMedia_video_panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            //UNDOCK IMAGE
            showMedia_image_title.Cursor = Cursors.Cross;
            showMedia_image_panel.Cursor = Cursors.SizeNWSE;
            showMedia_image_panel.Dock = DockStyle.None;
            showMedia_image_panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            showMedia_docked = false;

            media_remove(true);
        }
        private void media_remove(bool hide = true)
        {
            //remove title image
            showMedia_video_title.BackgroundImage = null;
            showMedia_image_title.BackgroundImage = null;

            //HIDE CTRLS / REMOVE GIF
            showMedia_image_ctrlbox.Visible = false;
            showMedia_image.Size = new System.Drawing.Size(showMedia_image.Size.Width, showMedia_image_panel.Size.Height - 34);
            showMedia_image_gif_frames = null;
            showMedia_image_gif_timer.Enabled = false;
            //REMOVE IMAGE
            if (showMedia_image.Image != null)
            {
                var image = new Bitmap(10, 10, PixelFormat.Format32bppArgb);
                using (var g = Graphics.FromImage(image))
                {
                    g.Clear(Color.Transparent);
                    // g.DrawLine(Pens.Red, 0, 0, 135, 135);
                }

                showMedia_image.Image.Dispose();
                showMedia_image.Image = image;
                showMedia_image.BackgroundImage = image;
            }
            

            //CLEAR VIDEO
            showMedia_video.currentPlaylist.clear();
            showMedia_video.URL = null;
            showMedia_video.close();
            
            //repos
            if (this.Size.Width > 230 && this.Size.Width > 200) { showMedia_video_panel.MaximumSize = this.Size; showMedia_image_panel.MaximumSize = this.Size; }

            if (showMedia_video_panel.Location.X < 0 || showMedia_video_panel.Location.Y < 0) { showMedia_video_panel.Location = new Point(0, 0); showMedia_image_panel.Location = new Point(0, 0); }
            if (showMedia_image_panel.Location.X < 0 || showMedia_image_panel.Location.Y < 0) { showMedia_video_panel.Location = new Point(0, 0); showMedia_image_panel.Location = new Point(0, 0); }

            if (showMedia_video_panel.Location.X > this.Size.Width || showMedia_video_panel.Location.Y > this.Size.Height) { showMedia_video_panel.Location = new Point(0, 0); showMedia_image_panel.Location = new Point(0, 0); }
            if (showMedia_image_panel.Location.X > this.Size.Width || showMedia_image_panel.Location.Y > this.Size.Height) { showMedia_video_panel.Location = new Point(0, 0); showMedia_image_panel.Location = new Point(0, 0); }

            //HIDE PLAYERS
            if (hide)
            {
                showMedia_video_panel.Visible = false;
                showMedia_image_panel.Visible = false;
            }
        }
        private void media_repos()
        {
            showMedia_image_panel.Location = new Point(0, 0);
            showMedia_video_panel.Location = new Point(0, 0);

            showMedia_image_panel.Size = showMedia_image_panel.MinimumSize;
            showMedia_video_panel.Size = showMedia_video_panel.MinimumSize;
        }
        private void media_sw()
        {
            if (menu_cb_players_enable.Checked)
            {
                menu_cb_players_enable.Checked = false;
            }
            else
            {
                menu_cb_players_enable.Checked = true;
            }
        }

        private Point showMedia_image_lastPos, showMedia_video_lastPos;
        private Size showMedia_image_lastSize, showMedia_video_lastSize;

        //IMAGE DOCK
        private bool showMedia_docked = false;
        private void showMedia_dock()
        {
            if (!showMedia_docked) //DOCK
            {
                //REMEMBER SIZE AND LOCATION
                showMedia_image_lastPos = showMedia_image_panel.Location;
                showMedia_image_lastSize = showMedia_image_panel.Size;
                showMedia_video_lastPos = showMedia_video_panel.Location;
                showMedia_video_lastSize = showMedia_video_panel.Size;


                //DOCK VIDEO
                showMedia_video_title.Cursor = Cursors.Arrow;
                showMedia_video_panel.Cursor = Cursors.Arrow;
                showMedia_video_panel.Dock = DockStyle.Fill;

                //DOCK IMAGE
                showMedia_image_title.Cursor = Cursors.Arrow;
                showMedia_image_panel.Cursor = Cursors.Arrow;
                showMedia_image_panel.Dock = DockStyle.Fill;
                
                showMedia_docked = true;
            }
            else //UNDOCK
            {
                //UNDOCK VIDEO
                showMedia_video_title.Cursor = Cursors.Cross;
                showMedia_video_panel.Cursor = Cursors.SizeNWSE;
                showMedia_video_panel.Dock = DockStyle.None;
                showMedia_video_panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                //UNDOCK IMAGE
                showMedia_image_title.Cursor = Cursors.Cross;
                showMedia_image_panel.Cursor = Cursors.SizeNWSE;
                showMedia_image_panel.Dock = DockStyle.None;
                showMedia_image_panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                //SET REMEMBERED SIZE AND LOCATION
                showMedia_image_panel.Location = showMedia_image_lastPos;
                showMedia_image_panel.Size = showMedia_image_lastSize;
                showMedia_video_panel.Location = showMedia_video_lastPos;
                showMedia_video_panel.Size = showMedia_video_lastSize;

                showMedia_docked = false;
            }
        }

        private void showMedia_image_title_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                showMedia_dock();
            }
        }
        private void showMedia_video_title_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                showMedia_dock();
            }
        }



        #region move: showMedia_image

        private Point showMedia_image_startDraggingPoint;
        private Size showMedia_image_startSize;
        private Rectangle showMedia_image_rectProposedSize = Rectangle.Empty;

        //MOVE (TITLE)
        private void showMedia_image_title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (showMedia_docked != true)
                {
                    if (showMedia_image_panel != null)
                    {
                        // start point location
                        showMedia_image_startDraggingPoint = e.Location;
                    }
                }
            }
        }
        private void showMedia_image_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (showMedia_docked != true)
                {
                    if (showMedia_image_panel != null)
                    {
                        int left = showMedia_image_panel.Left;
                        int top = showMedia_image_panel.Top;
                        left += e.X - showMedia_image_startDraggingPoint.X;
                        top += e.Y - showMedia_image_startDraggingPoint.Y;
                        if (left < 0) { showMedia_image_panel.Left = 0; } else { showMedia_image_panel.Left = left; }
                        if (top < 0) { showMedia_image_panel.Top = 0; } else { showMedia_image_panel.Top = top; }
                        Application.DoEvents();
                    }
                }
            }
        }
        private void showMedia_image_title_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (showMedia_docked != true)
                {
                    if (showMedia_image_panel != null)
                    {
                        try
                        {
                            //set image player Location
                            showMedia_video_panel.Location = showMedia_image_panel.Location;
                        }
                        catch (System.NullReferenceException) {  }
                        catch (System.Exception) {  }
                    }
                }
            }
        }

        //RESIZE (PANEL)
        private void showMedia_image_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (showMedia_docked != true)
                {
                    if (showMedia_image_panel != null)
                    {
                        // starting size
                        showMedia_image_startSize = new System.Drawing.Size(e.X, e.Y);

                        // get the location of the picture box
                        showMedia_image_rectProposedSize = new Rectangle(this.PointToScreen(showMedia_image_panel.Location), showMedia_image_startSize);

                        // start point location
                        showMedia_image_startDraggingPoint = e.Location;
                    }
                }
            }
        }
        private void showMedia_image_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (showMedia_docked != true)
                {
                    if (showMedia_image_panel != null)
                    {
                        // calculate rect new size
                        showMedia_image_rectProposedSize.Width = e.X - this.showMedia_image_startDraggingPoint.X + this.showMedia_image_startSize.Width;
                        showMedia_image_rectProposedSize.Height = e.Y - this.showMedia_image_startDraggingPoint.Y + this.showMedia_image_startSize.Height;

                        if (showMedia_image_rectProposedSize.Width < showMedia_image_panel.MinimumSize.Width)
                        {
                            showMedia_image_rectProposedSize.Width = showMedia_image_panel.MinimumSize.Width;
                        }

                        if (showMedia_image_rectProposedSize.Height < showMedia_image_panel.MinimumSize.Height)
                        {
                            showMedia_image_rectProposedSize.Height = showMedia_image_panel.MinimumSize.Height;
                        }

                        showMedia_image_panel.Size = showMedia_image_rectProposedSize.Size;

                        Application.DoEvents();
                    }
                }
            }
        }
        private void showMedia_image_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (showMedia_docked != true)
                {
                    if (showMedia_image_panel != null)
                    {
                        try
                        {
                            //set image player Size
                            showMedia_video_panel.Size = showMedia_image_panel.Size;
                        }
                        catch (System.NullReferenceException) {  }
                        catch (System.Exception) {  }
                    }
                }
            }
        }

        #endregion

        #region move: showMedia_video

        private Point showMedia_video_startDraggingPoint;
        private Size showMedia_video_startSize;
        private Rectangle showMedia_video_rectProposedSize = Rectangle.Empty;

        //MOVE (TITLE)
        private void showMedia_video_title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (showMedia_docked != true)
                {
                    if (showMedia_video_panel != null)
                    {
                        // start point location
                        showMedia_video_startDraggingPoint = e.Location;
                    }
                }
            }
        }
        private void showMedia_video_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (showMedia_docked != true)
                {
                    if (showMedia_video_panel != null)
                    {
                        int left = showMedia_video_panel.Left;
                        int top = showMedia_video_panel.Top;
                        left += e.X - showMedia_video_startDraggingPoint.X;
                        top += e.Y - showMedia_video_startDraggingPoint.Y;
                        if (left < 0) { showMedia_video_panel.Left = 0; } else { showMedia_video_panel.Left = left; }
                        if (top < 0) { showMedia_video_panel.Top = 0; } else { showMedia_video_panel.Top = top; }
                        Application.DoEvents();
                    }
                }
            }
        }
        private void showMedia_video_title_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (showMedia_docked != true)
                {
                    if (showMedia_video_panel != null)
                    {
                        try
                        {
                            //set image player Location
                            showMedia_image_panel.Location = showMedia_video_panel.Location;
                        }
                        catch (System.NullReferenceException) {  }
                        catch (System.Exception) {  }
                    }
                }
            }
        }

        //RESIZE (PANEL)
        private void showMedia_video_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (showMedia_docked != true)
                {
                    if (showMedia_video_panel != null)
                    {
                        // starting size
                        showMedia_video_startSize = new System.Drawing.Size(e.X, e.Y);

                        // get the location of the picture box
                        showMedia_video_rectProposedSize = new Rectangle(this.PointToScreen(showMedia_video_panel.Location), showMedia_video_startSize);

                        // start point location
                        showMedia_video_startDraggingPoint = e.Location;
                    }
                }
            }
        }
        private void showMedia_video_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (showMedia_docked != true)
                {
                    if (showMedia_video_panel != null)
                    {
                        // calculate rect new size
                        showMedia_video_rectProposedSize.Width = e.X - this.showMedia_video_startDraggingPoint.X + this.showMedia_video_startSize.Width;
                        showMedia_video_rectProposedSize.Height = e.Y - this.showMedia_video_startDraggingPoint.Y + this.showMedia_video_startSize.Height;

                        if (showMedia_video_rectProposedSize.Width < showMedia_video_panel.MinimumSize.Width)
                        {
                            showMedia_video_rectProposedSize.Width = showMedia_video_panel.MinimumSize.Width;
                        }

                        if (showMedia_video_rectProposedSize.Height < showMedia_video_panel.MinimumSize.Height)
                        {
                            showMedia_video_rectProposedSize.Height = showMedia_video_panel.MinimumSize.Height;
                        }

                        showMedia_video_panel.Size = showMedia_video_rectProposedSize.Size;

                        Application.DoEvents();
                    }
                }
            }
        }
        private void showMedia_video_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (showMedia_docked != true)
                {
                    if (showMedia_video_panel != null)
                    {
                        try
                        {
                            //set image player Size
                            showMedia_image_panel.Size = showMedia_video_panel.Size;
                        }
                        catch (System.NullReferenceException) {  }
                        catch (System.Exception) {  }
                    }
                }
            }
        }

        #endregion


        private bool Random_Busy = false;
        private void Random_VOI(string path, string media_type, bool IsInside = true)
        {
            if (!Random_Busy)
            {
                Random_Busy = true;

                this.Text = "FAPMAP: Searching for a random file...";

                media_remove(menu_cb_players_autoHide.Checked);
                // file_export_all(); //old export bat

                List<string> TYPES = null;
                if (media_type == "image")
                {
                    TYPES = GlobalVariables.Settings.Media.FileTypes.Image;
                }
                else if (media_type == "video")
                {
                    TYPES = GlobalVariables.Settings.Media.FileTypes.Video;
                }
                else
                {
                    media_type = "image";
                    TYPES = GlobalVariables.Settings.Media.FileTypes.Image;
                }

                //PATH
                if (string.IsNullOrEmpty(path))
                {
                    path = GlobalVariables.Path.Dir.MainFolder;
                }
                else
                {
                    bool getParent = false;

                    if (File.Exists(path))
                    {
                        getParent = true;
                    }
                    foreach (string type in GlobalVariables.FileTypes.Video)
                    {
                        if (getParent) { break; }
                        if (path.EndsWith(type)) { getParent = true; }
                    }
                    foreach (string type in GlobalVariables.FileTypes.Image)
                    {
                        if (getParent) { break; }
                        if (path.EndsWith(type)) { getParent = true; }
                    }
                    foreach (string type in GlobalVariables.FileTypes.Other)
                    {
                        if (getParent) { break; }
                        if (path.EndsWith(type)) { getParent = true; }
                    }

                    if (getParent)
                    {
                        path = Directory.GetParent(path).ToString();
                    }
                }

                List<string> all_files = new List<string>();
                foreach (string type in TYPES) //run through each type
                {
                    //get all files
                    string[] files = null;
                    if (type.StartsWith("*."))
                    {
                        files = Directory.GetFiles(path, type, SearchOption.AllDirectories);
                    }
                    else if (type.StartsWith("."))
                    {
                        files = Directory.GetFiles(path, "*" + type, SearchOption.AllDirectories);
                    }
                    else
                    {
                        files = Directory.GetFiles(path, "*." + type, SearchOption.AllDirectories);
                    }
                    
                    //add got files with type
                    foreach (string file in files)
                    {
                        all_files.Add(file);
                    }
                }

                string randFile = "";

                if (all_files.Count == 0) //no files
                {
                    this.Text = "FAPMAP: Could not find a random file.";
                    Random_Busy = false;
                    return;
                }
                else if (all_files.Count == 1) //if one file exists set it...
                {
                    randFile = all_files[0];
                }
                else
                {
                    //choose random file
                    randFile = all_files[new Random().Next(1, all_files.Count)];
                }

                //SET PATH
                faftv_path.Text = randFile;

                //START
                if (!IsInside || menu_cb_fapmap_outside.Checked)
                {
                    this.Text = "FAPMAP: OPENED: " + randFile;
                    Process.Start(randFile);
                    LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, randFile);
                }
                else
                {
                    this.Text = "FAPMAP: LOADED: " + randFile;
                    load_file_or_dir(randFile);
                }
                
                Random_Busy = false;
            }
        }

        //VIDEO POS SCROLL
        private bool showMedia_video_ctrlsPanel_pos_scrolling = false;
        private bool showMedia_video_ctrlsPanel_pos_hovering = false;
        private void showMedia_video_ctrlsPanel_pos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                showMedia_video_ctrlsPanel_pos_scrolling = true;

                double dblValue = ((double)e.X / (double)showMedia_video_ctrlsPanel_pos.Width) * (showMedia_video_ctrlsPanel_pos.Maximum - showMedia_video_ctrlsPanel_pos.Minimum);
                int dblValue_int = Convert.ToInt32(dblValue);
                dblValue_int =
                    dblValue_int > showMedia_video_ctrlsPanel_pos.Maximum ?
                        showMedia_video_ctrlsPanel_pos.Maximum
                    : (dblValue_int < showMedia_video_ctrlsPanel_pos.Minimum ?
                        dblValue_int = showMedia_video_ctrlsPanel_pos.Minimum
                        : dblValue_int
                    );
                showMedia_video_ctrlsPanel_pos.Value = dblValue_int;
                // showMedia_video.Ctlcontrols.currentPosition = set_value;
            }
        }

        private void showMedia_video_ctrlsPanel_pos_MouseMove(object sender, MouseEventArgs e)
        {
            showMedia_video_ctrlsPanel_pos_hovering = true;

            double dblValue = ((double)e.X / (double)showMedia_video_ctrlsPanel_pos.Width) * (showMedia_video_ctrlsPanel_pos.Maximum - showMedia_video_ctrlsPanel_pos.Minimum);
            int dblValue_int = Convert.ToInt32(dblValue);
            dblValue_int =
                dblValue_int > showMedia_video_ctrlsPanel_pos.Maximum ?
                    showMedia_video_ctrlsPanel_pos.Maximum
                : (dblValue_int < showMedia_video_ctrlsPanel_pos.Minimum ?
                    dblValue_int = showMedia_video_ctrlsPanel_pos.Minimum
                    : dblValue_int
                );
            TimeSpan t = TimeSpan.FromSeconds(Convert.ToInt32(dblValue_int) / showMedia_video_ctrlsPanel_pos_times);

            // showMedia_video_ctrlsPanel_pos_cur.Text = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
            //                 t.Hours,
            //                 t.Minutes,
            //                 t.Seconds,
            //                 t.Milliseconds);

            showMedia_video_ctrlsPanel_pos_cur.ForeColor = Color.White;
            showMedia_video_ctrlsPanel_pos_cur.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
        }

        private void showMedia_video_ctrlsPanel_pos_MouseLeave(object sender, EventArgs e)
        {
            showMedia_video_ctrlsPanel_pos_hovering = false;
            showMedia_video_ctrlsPanel_pos_cur.ForeColor = Color.Silver;
        }

        private void showMedia_video_ctrlsPanel_pos_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                showMedia_video_ctrlsPanel_pos_scrolling = false;

                double dblValue = ((double)e.X / (double)showMedia_video_ctrlsPanel_pos.Width) * (showMedia_video_ctrlsPanel_pos.Maximum - showMedia_video_ctrlsPanel_pos.Minimum);
                int dblValue_int = Convert.ToInt32(dblValue);
                dblValue_int = 
                    dblValue_int > showMedia_video_ctrlsPanel_pos.Maximum ?
                        showMedia_video_ctrlsPanel_pos.Maximum
                    : (dblValue_int < showMedia_video_ctrlsPanel_pos.Minimum ?
                        dblValue_int = showMedia_video_ctrlsPanel_pos.Minimum
                        : dblValue_int
                    );
                showMedia_video_ctrlsPanel_pos.Value = dblValue_int;
                double set_value = (showMedia_video_ctrlsPanel_pos.Value / showMedia_video_ctrlsPanel_pos_times);
                showMedia_video.Ctlcontrols.currentPosition = set_value;
            }
        }
        
        //FAST FORWARD
        private void showMedia_video_ctrlsPanel_pos_fastforward_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                showMedia_video.Ctlcontrols.fastForward();
            }
        }
        private void showMedia_video_ctrlsPanel_pos_fastforward_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                showMedia_video.Ctlcontrols.currentPosition = showMedia_video.Ctlcontrols.currentPosition;
            }
        }

        //REVERSE
        private void showMedia_video_ctrlsPanel_pos_rewind_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                showMedia_video.Ctlcontrols.fastReverse();
            }
        }
        private void showMedia_video_ctrlsPanel_pos_rewind_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                showMedia_video.Ctlcontrols.currentPosition = showMedia_video.Ctlcontrols.currentPosition;
            }
        }
        
        private void showMedia_video_ctrlsPanel_pos_timer_Tick(object sender, EventArgs e)
        {
            //timer 1 tick event handler
            if (showMedia_video.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                try
                {
                    if (!showMedia_video_ctrlsPanel_pos_hovering)
                    {
                        showMedia_video_ctrlsPanel_pos_cur.Text
                            = showMedia_video.Ctlcontrols.currentPositionString.Length == 5 ?
                            "00:" + showMedia_video.Ctlcontrols.currentPositionString : showMedia_video.Ctlcontrols.currentPositionString;
                    }
                    

                    if (!showMedia_video_ctrlsPanel_pos_scrolling)
                    {
                        showMedia_video_ctrlsPanel_pos.Value = (int)(showMedia_video.Ctlcontrols.currentPosition * showMedia_video_ctrlsPanel_pos_times);
                    }
                }
                catch (Exception) {  }
            }

            
        }
        
        private void DrawAudio()
        {
            using (var enumerator = new CSCore.CoreAudioAPI.MMDeviceEnumerator())
            {
                using (var device = enumerator.GetDefaultAudioEndpoint(CSCore.CoreAudioAPI.DataFlow.Render, CSCore.CoreAudioAPI.Role.Multimedia))
                {
                    // Debug.WriteLine("DefaultDevice: " + device.FriendlyName);
                    var sessionManager = CSCore.CoreAudioAPI.AudioSessionManager2.FromMMDevice(device);

                    using (var sessionEnumerator = sessionManager.GetSessionEnumerator())
                    {
                        while (true)
                        {
                            Thread.Sleep(30);

                            foreach (var session in sessionEnumerator)
                            {
                                using (var session2 = session.QueryInterface<CSCore.CoreAudioAPI.AudioSessionControl2>())
                                using (var audioMeterInformation = session.QueryInterface<CSCore.CoreAudioAPI.AudioMeterInformation>())
                                {
                                    float peak = audioMeterInformation.GetPeakValue();

                                    //must be my process (id) window
                                    if (session2.ProcessID == Process.GetCurrentProcess().Id)
                                    {
                                        if (peak > 0)
                                        {
                                            draw_graph((int)(peak * 100), showMedia_video_audioPanel, Color.DimGray);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        //MULTYPLY TIME
        private int  showMedia_video_ctrlsPanel_pos_times = 100;

        //PLAY STATE
        private void showMedia_video_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            //media player control's playstate change event handler
            if (showMedia_video.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                showMedia_video_ctrlsPanel_pos.Maximum = (int)(showMedia_video.Ctlcontrols.currentItem.duration * showMedia_video_ctrlsPanel_pos_times);
                if (showMedia_video.Ctlcontrols.currentItem.durationString.Length == 5)
                {
                    showMedia_video_ctrlsPanel_pos_max.Text = "00:" + showMedia_video.Ctlcontrols.currentItem.durationString;
                }
                else
                {
                    showMedia_video_ctrlsPanel_pos_max.Text = showMedia_video.Ctlcontrols.currentItem.durationString;
                }
                showMedia_video_ctrlsPanel_pos_timer.Start();
                showMedia_video_ctrlsPanel_play.BackgroundImage = Properties.Resources.image_button_pause;
            }
            else if (showMedia_video.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                showMedia_video_ctrlsPanel_pos_timer.Stop();
                showMedia_video_ctrlsPanel_play.BackgroundImage = Properties.Resources.image_button_play;
            }
            else if (showMedia_video.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                //CLEAR
                showMedia_video_ctrlsPanel_pos_timer.Stop();
                showMedia_video_ctrlsPanel_pos.Maximum = 1;
                showMedia_video_ctrlsPanel_pos.Minimum = 0;
                showMedia_video_ctrlsPanel_pos.Value = 0;
                showMedia_video_ctrlsPanel_pos_cur.Text = "00:00:00";
                showMedia_video_ctrlsPanel_pos_max.Text = "00:00:00";
            }

            if (showMedia_video.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                //CLEAR
                showMedia_video_ctrlsPanel_pos_timer.Stop();
                showMedia_video_ctrlsPanel_pos.Maximum = 1;
                showMedia_video_ctrlsPanel_pos.Minimum = 0;
                showMedia_video_ctrlsPanel_pos.Value = 0;
                showMedia_video_ctrlsPanel_pos_cur.Text = "00:00:00";
                showMedia_video_ctrlsPanel_pos_max.Text = "00:00:00";

                //PLAY NEXT
                if (showMedia_video_RMB_repeat.Checked != true)
                {
                    //CHECK FOR RANDOM
                    if (showMedia_video_RMB_autoRand_main.Checked)
                    {
                        Random_VOI(GlobalVariables.Path.Dir.MainFolder, "video", true);
                    }
                    else if (showMedia_video_RMB_autoRand_dir.Checked)
                    {
                        Random_VOI(faftv_path.Text, "video", true);
                    }
                    else if (video_playlist_enabled) //PLAYLIST
                    {
                        playlist_update(-1);
                    }
                }
            }
            
            if(!this_selected && menu_cb_players_autoPause.Checked)
            {
                showMedia_video.Ctlcontrols.pause();
            }
            else
            {
                //AUTO PLAY
                if (showMedia_video.playState == WMPLib.WMPPlayState.wmppsReady && showMedia_video_panel.Visible && menu_cb_players_autoPlay.Checked)
                {
                    showMedia_video.Ctlcontrols.play();
                }
            }
        }
        
        // private void move_mute_thread(string file)
        // {
        //     string[] lines = File.ReadAllLines(VAR.PATH.FILE.MOVETO);
        // 
        //     Thread.Sleep(1000);
        // 
        //     if (lines.Length > 0)
        //     {
        //         if (File.Exists(file))
        //         {
        //             //get dir
        //             string dir = lines[0];
        //             
        //             //make dir
        //             if (!Directory.Exists(dir))
        //             {
        //                 Directory.CreateDirectory(dir);
        //                 dir = new DirectoryInfo(dir).FullName;
        //             }
        //             
        //             //get file dest
        //             FileInfo fi = new FileInfo(file);
        //             string dest = dir + "\\" + fi.Name;
        // 
        //             string dest_msg = dest;
        //             if (dest_msg.Contains(VAR.PATH.DIR.MAINFOLDER))
        //             {
        //                 dest_msg = dest_msg.Replace(VAR.PATH.DIR.MAINFOLDER + "\\", "");
        //             }
        // 
        //             DialogResult dialogResult = MessageBox.Show("> " + fi.Name + Environment.NewLine + "> " + dest_msg, "Move file?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        // 
        //             if (dialogResult == DialogResult.Yes)
        //             {
        //                 try
        //                 {
        //                     Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(fi.FullName, dest, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
        // 
        //                     this.Text = "FAPMAP: MOVED: " + fi.FullName + " -> " + dest;
        //                     LogThis(fapmap.VAR.LOG_TYPE.MOVE, fi.FullName + " -> " + dest);
        //                 }
        //                 catch (ArgumentException) { MessageBox.Show("ERRO[ArgumentException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        //                 catch (FileNotFoundException) { MessageBox.Show("ERRO[FileNotFoundException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        //                 catch (IOException exx) { MessageBox.Show("ERRO[IOException]: " + exx.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        //                 catch (InvalidOperationException) { MessageBox.Show("ERRO[InvalidOperationException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        //                 catch (NotSupportedException) { MessageBox.Show("ERRO[NotSupportedException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        //                 catch (System.Security.SecurityException) { MessageBox.Show("ERRO[SecurityException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        //                 catch (UnauthorizedAccessException) { MessageBox.Show("ERRO[UnauthorizedAccessException]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        //                 catch (Exception) { MessageBox.Show("ERRO[Exception]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        //             }
        //             else if (dialogResult == DialogResult.No)
        //             {
        //                 //nothing...
        //             }
        //         }
        //     }
        // }

        //CTRL - PLAY/PAUSE
        private void showMedia_video_playNpause()
        {
            if (showMedia_video.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                showMedia_video.Ctlcontrols.pause();
            }
            else if (showMedia_video.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                showMedia_video.Ctlcontrols.play();
            }
        }
        private void showMedia_video_ctrlsPanel_play_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                showMedia_video_playNpause();
            }
            else if (e.Button == MouseButtons.Right)
            {
                showMedia_video.Ctlcontrols.stop();
            }
        }

        private void showMedia_video_MouseUpEvent(object sender, _WMPOCXEvents_MouseUpEvent e)
        {
            if (e.nButton == 1)
            {
                showMedia_video_playNpause();
            }
            else if (e.nButton == 2)
            {
                showMedia_video_RMB.Show(Cursor.Position);                // showMedia_video.Ctlcontrols.stop(); //replaced with contextmenustrip
            }
        }
        
        private void showMedia_video_sound_ValueChanged(object sender, EventArgs e)
        {
            showMedia_video.settings.volume = showMedia_video_sound.Value;
        }
        
        // //since Windows Vista/7 MS changed the access to control volume, mixers, etc.
        // //and it's called the coreaudio API
        // static class AudioCtrl
        // {
        //     [DllImport("winmm.dll", EntryPoint = "waveOutSetVolume")]
        //     public static extern int WaveOutSetVolume(IntPtr hwo, uint dwVolume);
        //     
        //     [DllImport("winmm.dll", SetLastError = true)]
        //     public static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);
        //
        //
        //     private void Example()
        //     {
        //          //Calculate the volume that's being set
        //          double newVolume = ushort.MaxValue * val / 10.0;
        //          uint v = ((uint)newVolume) & 0xffff;
        //          uint vAll = v | (v << 16)
        //          //Set the volume
        //          AudioCtrl.WaveOutSetVolume(IntPtr.Zero, vAll);
        //          AudioCtrl.PlaySound("tada.wav", IntPtr.Zero, 0x2001);
        //     }
        // }

        private void showMedia_video_RMB_autoRand_main_CheckedChanged(object sender, EventArgs e)
        {
            if (showMedia_video_RMB_autoRand_main.Checked)
            {
                showMedia_video_RMB_autoRand_dir.Checked = false;
            }
        }
        private void showMedia_video_RMB_autoRand_dir_CheckedChanged(object sender, EventArgs e)
        {
            if (showMedia_video_RMB_autoRand_dir.Checked)
            {
                showMedia_video_RMB_autoRand_main.Checked = false;
            }
        }

        private bool media_isFile(string URL)
        {
            foreach(string type in GlobalVariables.FileTypes.Video)
            {
                if (URL.Contains(type))
                {
                    return true;
                }
            }

            foreach (string type in GlobalVariables.FileTypes.Image)
            {
                if (URL.Contains(type))
                {
                    return true;
                }
            }

            return false;
        }
        

        //PLAY FILES FROM URL
        private bool media_playUrl(string URL)
        {
            if (menu_cb_players_enable.Checked)
            {
                //CLEAR
                media_remove(true);
                
                foreach (var type in GlobalVariables.FileTypes.Image)
                {
                    if (URL.Contains(type))
                    {
                        //SETUP CTRLS - HIDE CTRLS
                        showMedia_image_ctrlbox.Visible = false;
                        showMedia_image.Size = new System.Drawing.Size(showMedia_image.Size.Width, showMedia_image_panel.Size.Height - 34);
                        showMedia_image_panel.Visible = true;
                        showMedia_image_panel.BringToFront();
                        
                        try
                        {
                            this.Text = "FAPMAP: DOWNLOADING: " + URL;

                            showMedia_image_URL = URL;

                            //DOWNLOAD
                            showMedia_image.LoadAsync(URL);

                            media_title_echo(URL, showMedia_image_title);
                        }
                        catch (Exception)
                        {
                            LogThis(GlobalVariables.LOG_TYPE.LOAD, URL);
                            MessageBox.Show(URL, "Image url is invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            media_remove(menu_cb_players_autoHide.Checked);
                        }
                        
                        return true;
                    }
                }
                
                foreach(string type in GlobalVariables.FileTypes.Video)
                {
                    if (URL.Contains(type))
                    {
                        //SETUP CTRLS
                        showMedia_video_panel.Visible = true;
                        showMedia_video_panel.BringToFront();
                        
                        try
                        {
                            this.Text = "FAPMAP: DOWNLOADING: " + URL;

                            showMedia_video.URL = URL; // DOWNLOAD

                            LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, URL);
                            this.Text = "FAPMAP: SHOWING: " + URL;
                            media_title_echo(URL, showMedia_video_title);
                        }
                        catch (Exception)
                        {
                            LogThis(GlobalVariables.LOG_TYPE.LOAD, URL);
                            MessageBox.Show(URL, "Video url is invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            media_remove(menu_cb_players_autoHide.Checked);
                        }
                        
                        return true;
                    }
                }
            }

            return false;
        }

        private string showMedia_image_URL = string.Empty;
        private void showMedia_image_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Bitmap bmp = new Bitmap(showMedia_image.Width, showMedia_image.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.DrawString(e.ProgressPercentage + "%", new Font("Consolas", 10), Brushes.Silver, new PointF(10, 10));

            showMedia_image.BackgroundImage = bmp;
        }

        private void showMedia_image_gifbox(bool show)
        {
            if (show) //show
            {
                showMedia_image_ctrlbox.Visible = true;
                showMedia_image.Size = new System.Drawing.Size(showMedia_image.Size.Width, showMedia_image_panel.Size.Height - showMedia_image_title.Size.Height - showMedia_image_ctrlbox.Height - (showMedia_image_panel.Size.Width - showMedia_image.Size.Width));
                showMedia_image_panel.Visible = true;
                showMedia_image_panel.BringToFront();
            }
            else //hide
            {
                showMedia_image_ctrlbox.Visible = false;
                showMedia_image.Size = new System.Drawing.Size(showMedia_image.Size.Width, showMedia_image_panel.Size.Height - showMedia_image_title.Size.Height - (showMedia_image_panel.Size.Width - showMedia_image.Size.Width));
            }
        }

        private void showMedia_image_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (menu_cb_players_trackbar.Checked && showMedia_image_URL.EndsWith(".gif")) //GIF VIEWER
            {
                bool gif_is_valid = true;

                //LOAD
                try
                {
                    //LOAD FILE
                    showMedia_image_gif_frames = getFrames(showMedia_image.Image);
                }
                catch (OutOfMemoryException) { gif_is_valid = false; }
                catch (Exception) { gif_is_valid = false; }
                
                if (gif_is_valid)
                {
                    showMedia_image_gif_trackbar.Maximum = showMedia_image_gif_frames.Length - 1;
                    showMedia_image_gif_trackbar.ScaleDivisions = showMedia_image_gif_frames.Length - 2;
                    showMedia_image_gif_trackbar.Value = 1;
                    showMedia_image.Image = showMedia_image_gif_frames[showMedia_image_gif_trackbar.Value - 1];
                    showMedia_image_gif_frame.Text = showMedia_image_gif_trackbar.Value + " / " + showMedia_image_gif_trackbar.Maximum;

                    showMedia_image_gifbox(true);

                    if (!showMedia_image_gif_paused)
                    {
                        //START TIMER
                        showMedia_image_gif_timer.Enabled = true;
                    }

                    return;
                }
            }

            showMedia_image_gifbox(false);

            LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, showMedia_image_URL);
            this.Text = "FAPMAP: SHOWING: " + showMedia_image_URL;
        }

        

        private void fileDisplay_btn_randVideo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Random_VOI(faftv_path.Text, "video", true);
                
            }
            else if (e.Button == MouseButtons.Right)
            {
                Random_VOI(GlobalVariables.Path.Dir.MainFolder, "video", true);
            }
        }
        private void fileDisplay_btn_randImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Random_VOI(faftv_path.Text, "image", true);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Random_VOI(GlobalVariables.Path.Dir.MainFolder, "image", true);
            }
        }
        
        private void showMedia_image_skip_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Random_VOI(faftv_path.Text, "image", true);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Random_VOI(GlobalVariables.Path.Dir.MainFolder, "image", true);
            }
        }
        
        private void showMedia_video_skip_MouseUp(object sender, MouseEventArgs e)
        {
            //PLAYLIST SKIP
            if (video_playlist_enabled && e.Button == MouseButtons.Left)
            {
                playlist_update(-1);
            }
            else
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:  { Random_VOI(faftv_path.Text, "video", true);         break; }
                    case MouseButtons.Right: { Random_VOI(GlobalVariables.Path.Dir.MainFolder, "video", true); break; }
                }
            }
        }

        private void showMedia_video_undo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //PLAYLIST UNDO
                if (video_playlist_enabled)
                {
                    playlist_update(-2);
                }
                else
                {
                    load_file_or_dir(faftv_path.Text);
                }
            }
        }
        
        #endregion

        #region faftv

        #region faftv -> Functions

        //MAIN
        private void faftv_ListDirectory(TreeView treeView, string path)
        {
            file_export_all();

            //CLEAR TREE VIEW
            treeView.Nodes.Clear();

            //USE THE "CreateDirectoryNode" FUNCTION TO ADD DIRS
            treeView.Nodes.Add(faftv_CreateDirectoryNode(new DirectoryInfo(path)));
        }
        private TreeNode faftv_CreateDirectoryNode(DirectoryInfo di)
        {
            //DIR
            TreeNode node_dir = new TreeNode(di.Name) { Tag = di.FullName };

            //FILE
            TreeNode node_file = new TreeNode(di.Name);

            //GET DIRS
            foreach (DirectoryInfo directory in di.GetDirectories())
            {
                //SET IMAGE TO DIR
                node_dir.ImageIndex = node_dir.SelectedImageIndex = 0;

                //ADD DIR
                node_dir.Nodes.Add(faftv_CreateDirectoryNode(directory));
            }

            //GET FILES
            foreach (FileInfo file in di.GetFiles())
            {
                if (file.Extension != ".ini") //ignore desktop.ini
                {

                    //ADD FILE
                    node_dir.Nodes.Add(node_file = new TreeNode(file.Name));

                    //SET THE PATH OF THE FILE TO TAG
                    node_file.Tag = file.FullName;

                    switch (file.Extension)
                    {
                        case ".exe": node_file.ImageIndex = node_file.SelectedImageIndex = 1; break;
                        case ".mp4": node_file.ImageIndex = node_file.SelectedImageIndex = 2; break;
                        case ".wmv": node_file.ImageIndex = node_file.SelectedImageIndex = 2; break;
                        case ".mkv": node_file.ImageIndex = node_file.SelectedImageIndex = 2; break;
                        case ".mpeg": node_file.ImageIndex = node_file.SelectedImageIndex = 2; break;
                        case ".mpg": node_file.ImageIndex = node_file.SelectedImageIndex = 2; break;
                        case ".webm": node_file.ImageIndex = node_file.SelectedImageIndex = 3; break;
                        case ".avi": node_file.ImageIndex = node_file.SelectedImageIndex = 3; break;
                        case ".mov": node_file.ImageIndex = node_file.SelectedImageIndex = 3; break;
                        case ".swf": node_file.ImageIndex = node_file.SelectedImageIndex = 4; break;
                        case ".flv": node_file.ImageIndex = node_file.SelectedImageIndex = 4; break;
                        case ".gif": node_file.ImageIndex = node_file.SelectedImageIndex = 5; break;
                        case ".png": node_file.ImageIndex = node_file.SelectedImageIndex = 6; break;
                        case ".svg": node_file.ImageIndex = node_file.SelectedImageIndex = 6; break;
                        case ".ico": node_file.ImageIndex = node_file.SelectedImageIndex = 6; break;
                        case ".jpg": node_file.ImageIndex = node_file.SelectedImageIndex = 7; break;
                        case ".jpeg": node_file.ImageIndex = node_file.SelectedImageIndex = 7; break;
                        case ".jpe": node_file.ImageIndex = node_file.SelectedImageIndex = 7; break;
                        case ".jiff": node_file.ImageIndex = node_file.SelectedImageIndex = 7; break;
                        case ".jfif": node_file.ImageIndex = node_file.SelectedImageIndex = 7; break;
                        case ".bmp": node_file.ImageIndex = node_file.SelectedImageIndex = 7; break;
                        case ".dib": node_file.ImageIndex = node_file.SelectedImageIndex = 7; break;
                        case ".tif": node_file.ImageIndex = node_file.SelectedImageIndex = 7; break;
                        case ".tiff": node_file.ImageIndex = node_file.SelectedImageIndex = 7; break;
                        case ".mp3": node_file.ImageIndex = node_file.SelectedImageIndex = 8; break;
                        case ".ogg": node_file.ImageIndex = node_file.SelectedImageIndex = 8; break;
                        case ".html": node_file.ImageIndex = node_file.SelectedImageIndex = 9; break;
                        case ".txt": node_file.ImageIndex = node_file.SelectedImageIndex = 10; break;
                        case ".bat": node_file.ImageIndex = node_file.SelectedImageIndex = 11; break;
                        case ".reg": node_file.ImageIndex = node_file.SelectedImageIndex = 12; break;

                        default: node_file.ImageIndex = node_file.SelectedImageIndex = 14; break;
                    }

                    
                }
            }

            return node_dir;
        }

        //RELOAD
        private void faftv_reload()
        {
            faftv.SelectedNode = null;
            faftv_path.Text = GlobalVariables.Path.Dir.MainFolder;
            faftv_ListDirectory(faftv, GlobalVariables.Path.Dir.MainFolder);
            this.Text = "FAPMAP";
        }

        
        //OPEN FUNCTION
        private void faftv_startFile(bool openDirs = false)
        {
            if (faftv.SelectedNode != null)
            {
                string file = faftv.SelectedNode.Tag.ToString();

                if (File.Exists(file))
                {
                    if (new FileInfo(file).Name.Contains("fapmap_mod"))
                    {
                        open_script(file);
                    }
                    else
                    {
                        media_remove(menu_cb_players_autoHide.Checked);

                        try
                        {
                            Process.Start(file);

                            LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, file);
                            this.Text = "FAPMAP: OPENED: " + file;
                        }
                        catch (Exception)
                        {
                            LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file);
                            MessageBox.Show(file, "Application for the file not found. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (Directory.Exists(file) && openDirs)
                {
                    try
                    {
                        Process.Start(file);

                        LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, file);
                        this.Text = "FAPMAP: OPENED: " + file;
                    }
                    catch (Exception)
                    {
                        LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file);
                        MessageBox.Show(file, "Application for the file not found. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void faftv_delete()
        {
            if (faftv.SelectedNode != null)
            {
                string item = faftv.SelectedNode.Tag.ToString();

                if (!string.IsNullOrEmpty(item))
                {
                    if (Directory.Exists(item))
                    {
                        DirectoryInfo di = new DirectoryInfo(item);

                        try
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(di.FullName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                        }
                        catch (System.OperationCanceledException) { return; }
                        catch (IOException) { return; }
                        catch (UnauthorizedAccessException) { return; }

                        //REMOVE NODE
                        faftv.Nodes.Remove(faftv.SelectedNode);

                        //DISPLAY
                        LogThis(fapmap.GlobalVariables.LOG_TYPE.RMVD, di.FullName);
                        this.Text = "FAPMAP: REMOVED: " + di.FullName;
                    }
                    else if (File.Exists(item))
                    {
                        FileInfo fi = new FileInfo(item);

                        media_remove(menu_cb_players_autoHide.Checked);

                        try
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(fi.FullName, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                        }
                        catch (System.OperationCanceledException) {  return; }
                        catch (IOException) {  return; }
                        catch (UnauthorizedAccessException) {  return; }

                        //REMOVE NODE
                        faftv.Nodes.Remove(faftv.SelectedNode);

                        //DISPLAY
                        LogThis(fapmap.GlobalVariables.LOG_TYPE.RMVD, fi.FullName);
                        this.Text = "FAPMAP: REMOVED: " + fi.FullName;
                    }
                    else
                    {
                        LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, item);
                        this.Text = "FAPMAP: File not found: " + item;
                    }
                }
            }
        }
        
        #endregion

        #region faftv -> RMB/SHORTCUTS

        //KEYSDOWN TREEVIEW
        private void faftv_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        e.SuppressKeyPress = true; faftv_startFile();

                        try
                        {
                            if (faftv.SelectedNode.IsExpanded) { faftv.SelectedNode.Collapse(); }
                            else { faftv.SelectedNode.Expand(); }
                        }
                        catch (Exception) {  }

                        break;
                    }
                case Keys.Delete: faftv_delete(); break;
                case Keys.F5: faftv_reload(); break;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R: faftv_reload(); e.SuppressKeyPress = true; break;
                    case Keys.Q: faftv.CollapseAll(); break;
                    case Keys.E: faftv.ExpandAll(); break;
                    case Keys.W: Process.Start(@"explorer.exe", faftv_path.Text); break;
                    case Keys.P: if (faftv.SelectedNode != null) { start_fapmap_info(faftv.SelectedNode.Tag.ToString()); } break;
                    case Keys.F: fapmap_find fi = new fapmap_find(); fi.Show(); break;
                    case Keys.H: this_hide(); break;
                    case Keys.N: fileDisplay_newFolder(); break;
                }
            }
            
        }

        //F5
        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            faftv_reload();
        }
        //Collapse
        private void collapseTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            faftv_path.Text = null;
            faftv.CollapseAll();
        }
        //EXPAND
        private void expandTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            faftv_path.Text = null;
            faftv.ExpandAll();
        }
        //OPEN SELECTED FILE
        private void openSelectedFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            faftv_startFile(true);
        }
        //WINDOWS
        private void openWindowsExplorerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Process.Start(@"explorer.exe", GlobalVariables.Path.Dir.MainFolder);
        }
        //RAND VID
        private void randomVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random_VOI(faftv_path.Text, "video", true);
        }
        //RAND IMG
        private void randomImageGifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random_VOI(faftv_path.Text, "image", true);
        }

        //RAND VID file display
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Random_VOI(faftv_path.Text, "video", true);
        }
        //RAND IMG file display
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Random_VOI(faftv_path.Text, "image", true);
        }

        #endregion

        #region faftv -> CTRLS

        //DOUBLE CLICK TREEVIEW = OPEN FILE
        private void faftv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            faftv_startFile();
        }
        
        //VIEW SLECTED
        private void faftv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            load_file_or_dir(faftv.SelectedNode.Tag.ToString());
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            faftv_delete();
        }

        #endregion

        #endregion

        #region web

        public static void Open(string file)
        {
            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, file);
            Process.Start(file);
        }

        public static void Incognito(string link)
        {
            string url = link;

            if (!Uri.IsWellFormedUriString(link, UriKind.Absolute))
            {
                url = "https://www.google.com/search?q=" + link.Replace(" ", "+");
            }

            try
            {
                Process.Start(GlobalVariables.Settings.WebBrowser.Browser, GlobalVariables.Settings.WebBrowser.BrowserArguments + " " + url);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, GlobalVariables.Settings.WebBrowser.Browser);
                MessageBox.Show("Unable to find: " + GlobalVariables.Settings.WebBrowser.Browser + Environment.NewLine + Environment.NewLine + "You can change the browser in the settings...",
                    "Browser not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, link);
        }

        #region wb

        #region wb -> Functions
        
        private void url_navigate(string link)
        {
            string url = link;

            if (menu_cb_players_enable.Checked && media_isFile(url))
            {
                media_playUrl(url);
                return;
            }


            Incognito(url);
        }
        
        #endregion

        #region wb -> CTRLS

        private void wb_url_KeyDown(object sender, KeyEventArgs e)
        {
            //NAVIGATE
            if (e.Control && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.W))
            {
                e.SuppressKeyPress = true;

                url_navigate(wb_url.Text);
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
            }
            
            if (e.Control && e.KeyCode == Keys.S) { links_add(wb_url.Text); } //ADD LINK
            
            //DEL TEXT
            if (string.IsNullOrEmpty(wb_url.Text))
            {
                if (e.Shift && e.KeyCode == Keys.Back) //ON BLANK ADD MAIN WEBSITE
                {
                    wb_url.Text = fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL;

                    //select end
                    wb_url.SelectionStart = wb_url.Text.Length;
                    wb_url.SelectionLength = 0;

                    e.SuppressKeyPress = true;
                }
            }
            
        }

        private void wb_btn_navigate_Click(object sender, EventArgs e)
        {
            Incognito(wb_url.Text);
        }
        private void wb_btn_open_Click(object sender, EventArgs e)
        {
            Incognito(wb_url.Text);
        }
        private void wb_btn_pin_Click(object sender, EventArgs e)
        {
            links_add(wb_url.Text);
        }
        
        private void wb_btn_dragOut_DragOver(object sender, DragEventArgs e)
        {
            if (links.SelectedItems.Count != 0)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void wb_btn_dragOut_MouseDown(object sender, MouseEventArgs e)
        {
            if (links.SelectedItems.Count != 0)
            {
                string text = string.Empty;
                foreach (ListViewItem lvi in links.SelectedItems) { text = lvi.Tag.ToString(); } //get items

                //clean items
                if (text.StartsWith(GlobalVariables.Settings.Common.Comment + " "))
                {
                    text = text.Replace(GlobalVariables.Settings.Common.Comment + " ", "");
                }
                else if (text.StartsWith(GlobalVariables.Settings.Common.Comment))
                {
                    text = text.Replace(GlobalVariables.Settings.Common.Comment, "");
                }

                this.links.DoDragDrop(new System.Windows.Forms.DataObject(System.Windows.Forms.DataFormats.StringFormat, text), DragDropEffects.Copy);
            }
        }

        #endregion

        #endregion

        #endregion

        #region Links 

        #region Links -> Functions

        private void links_reload()
        {
            file_export_all();

            string file = GlobalVariables.Path.File.Links;

            //REMOVE NULL LINES
            using (FileStream fs = new FileStream(fapmap.GlobalVariables.Path.File.Links, FileMode.Open))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    foreach (string line in SafeReadLines(fapmap.GlobalVariables.Path.File.Links))
                    {
                        if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line) && line != "")
                        {
                            tw.WriteLine(line);
                        }
                    }

                    tw.Flush();                // Flush the writer in order to get a correct stream position for truncating
                    fs.SetLength(fs.Position); // Set the stream length to the current position in order to truncate leftover text
                }
            }

            //CLEAR
            favicons.Images.Clear();
            links.Items.Clear();

            //add
            List<string> lines = System.IO.File.ReadAllLines(fapmap.GlobalVariables.Path.File.Links).ToList();
            foreach (string line in lines) { links_add(line, false); }

            //auto resize
            foreach (ColumnHeader column in links.Columns) { column.Width = -2; }
        }
        
        private void links_start()
        {
            if (links.SelectedItems != null)
            {
                foreach (ListViewItem item in links.SelectedItems)
                {
                    string str = item.Tag.ToString();

                    if (!str.StartsWith(GlobalVariables.Settings.Common.Comment))
                    {
                        url_navigate(str);
                    }
                }
            }
        }
        private void links_reloadTitle()
        {
            if (links.SelectedItems != null)
            {
                foreach (ListViewItem item in links.SelectedItems)
                {
                    new Thread(() => links_reloadTitle_(item)) { IsBackground = true }.Start();
                }
            }
        }
        private void links_reloadTitle_(ListViewItem item)
        {
            string backup = item.SubItems[2].Text;
            item.SubItems[2].Text = "reloading...";
            string title = get_html_title(item.Tag.ToString());
            if (title == "...") { item.SubItems[2].Text = backup; }
            else                { item.SubItems[2].Text = title;  }
        }

        private void links_incognito()
        {
            if (links.SelectedItems != null)
            {
                foreach (ListViewItem item in links.SelectedItems)
                {
                    string str = item.Tag.ToString();

                    if (!str.StartsWith(GlobalVariables.Settings.Common.Comment))
                    {
                        Incognito(str);
                    }
                }
            }
        }
        private void links_download()
        {
            if (links.SelectedItems != null)
            {
                try
                {

                    fapmap_download fd = new fapmap_download();

                    foreach (ListViewItem item in links.SelectedItems)
                    {
                        fd.links_pass_download.Add(item.Tag.ToString());
                    }

                    fd.Show();
                }
                catch (Exception) {  }
            }
        }

        private void links_webgrab()
        {
            if (links.SelectedItems != null)
            {
                foreach (ListViewItem item in links.SelectedItems)
                {
                    try
                    {
                        new fapmap_download() { links_pass_webgrab = item.Tag.ToString() }.Show();

                        Thread.Sleep(100);
                    }
                    catch (Exception) {  }
                }
            }
        }

        private void links_youtubedl()
        {
            if (links.SelectedItems != null)
            {
                foreach (ListViewItem item in links.SelectedItems)
                {
                    try
                    {
                        new fapmap_download() { links_pass_youtubedl = item.Tag.ToString() }.Show();
                        Thread.Sleep(100);
                    }
                    catch (Exception) {  }
                }
            }
        }

        private void links_copy()
        {
            if (links.SelectedItems.Count > 0)
            {
                string items = string.Empty;
                foreach (ListViewItem item in links.SelectedItems)
                {
                    string text = item.Tag.ToString();
                    if (text.StartsWith(GlobalVariables.Settings.Common.Comment + " "))
                    {
                        items += text.Replace(GlobalVariables.Settings.Common.Comment + " ", "") + Environment.NewLine;
                    }
                    else if (text.StartsWith(GlobalVariables.Settings.Common.Comment))
                    {
                        items += text.Replace(GlobalVariables.Settings.Common.Comment, "") + Environment.NewLine;
                    }
                    else
                    {
                        items += text + Environment.NewLine;
                    }
                }
                
                System.Windows.Forms.Clipboard.SetText(items);
            }
        }
        private void links_paste()
        {
            string paste = System.Windows.Clipboard.GetText();
            links_add(paste);
        }
        private void links_del()
        {
            if (links.SelectedItems != null)
            {
                foreach (ListViewItem item in links.SelectedItems)
                {
                    string line = null;
                    string line_to_delete = item.Tag.ToString();

                    using (StreamReader reader = new StreamReader(GlobalVariables.Path.File.Links))
                    {
                        using (StreamWriter writer = new StreamWriter(GlobalVariables.Path.Dir.Main + "links_inuse.dll"))
                        {
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (String.Compare(line, line_to_delete) == 0)
                                {
                                    links.Items.Remove(item);
                                    favicons.Images.RemoveByKey(item.ImageKey);
                                    continue;
                                }
                                writer.WriteLine(line);
                            }
                        }
                    }
                    File.Replace(GlobalVariables.Path.Dir.Main + "links_inuse.dll", GlobalVariables.Path.File.Links, null);
                    LogThis(fapmap.GlobalVariables.LOG_TYPE.UDEL, line_to_delete);
                }
            }
        }
        private void links_comment()
        {
            if (links.SelectedItems != null)
            {
                foreach (ListViewItem item in links.SelectedItems)
                {
                    string item_text = item.SubItems[1].Text;

                    if (!item_text.StartsWith(GlobalVariables.Settings.Common.Comment))
                    {
                        string[] lines = fapmap.SafeReadLines(fapmap.GlobalVariables.Path.File.Links);

                        using (FileStream fs = new FileStream(fapmap.GlobalVariables.Path.File.Links, FileMode.Open))
                        {
                            using (TextWriter tw = new StreamWriter(fs))
                            {
                                foreach (string line in lines)
                                {
                                    if (!line.StartsWith(GlobalVariables.Settings.Common.Comment))
                                    {
                                        if (line == item.Tag.ToString())
                                        {
                                            tw.WriteLine(GlobalVariables.Settings.Common.Comment + " " + line);
                                        }
                                        else
                                        {
                                            tw.WriteLine(line);
                                        }
                                    }
                                    else
                                    {
                                        tw.WriteLine(line);
                                    }

                                }

                                // Flush the writer in order to get a correct stream position for truncating
                                tw.Flush();
                                // Set the stream length to the current position in order to truncate leftover text
                                fs.SetLength(fs.Position);
                            }
                        }

                        //look
                        item.Font = new System.Drawing.Font(links.Font, System.Drawing.FontStyle.Italic);
                        item.ForeColor = System.Drawing.Color.Gray;

                        //text
                        item.SubItems[1].Text = GlobalVariables.Settings.Common.Comment + " " + item_text;
                        item.Tag = GlobalVariables.Settings.Common.Comment + " " + item_text;
                    }
                }
            }

            //auto resize
            foreach (ColumnHeader column in links.Columns)
            {
                column.Width = -2;
            }
        }
        private void links_unComment()
        {
            if (links.SelectedItems != null)
            {
                foreach (ListViewItem item in links.SelectedItems)
                {
                    string[] lines = fapmap.SafeReadLines(fapmap.GlobalVariables.Path.File.Links);

                    using (FileStream fs = new FileStream(fapmap.GlobalVariables.Path.File.Links, FileMode.Open))
                    {
                        using (TextWriter tw = new StreamWriter(fs))
                        {
                            foreach (string line in lines)
                            {
                                if (line.StartsWith(GlobalVariables.Settings.Common.Comment + " ") && line == item.SubItems[1].Text)
                                {
                                    string text = line.Replace(GlobalVariables.Settings.Common.Comment + " ", "");
                                    tw.WriteLine(text);

                                    //look
                                    item.Font = new System.Drawing.Font(links.Font, System.Drawing.FontStyle.Regular);
                                    item.ForeColor = System.Drawing.Color.Silver;

                                    //text
                                    item.SubItems[1].Text = text;
                                    item.Tag = text;
                                }
                                else if (line.StartsWith(GlobalVariables.Settings.Common.Comment) && line == item.SubItems[1].Text)
                                {
                                    string text = line.Replace(GlobalVariables.Settings.Common.Comment, "");
                                    tw.WriteLine(text);
                                    item.SubItems[1].Text = text;

                                    //look
                                    item.Font = new System.Drawing.Font(links.Font, System.Drawing.FontStyle.Regular);
                                    item.ForeColor = System.Drawing.Color.Silver;

                                    //text
                                    item.SubItems[1].Text = text;
                                    item.Tag = text;
                                }
                                else
                                {
                                    tw.WriteLine(line);
                                }
                            }

                            // Flush the writer in order to get a correct stream position for truncating
                            tw.Flush();
                            // Set the stream length to the current position in order to truncate leftover text
                            fs.SetLength(fs.Position);
                        }
                    }
                }
            }

            //auto resize
            foreach (ColumnHeader column in links.Columns)
            {
                column.Width = -2;
            }
        }
        private void links_edit()
        {
            file_export_all();

            Process.Start("notepad.exe", GlobalVariables.Path.File.Links);
        }
        private void links_add(string url, bool write = true)
        {
            if (write)
            {
                //CHECK
                if (url == "") { return; }
                if (string.IsNullOrEmpty(url)) { return; }
                if (string.IsNullOrWhiteSpace(url)) { return; }
                foreach (ListViewItem a in links.Items) { if (a.Tag.ToString() == url) { this.Text = "FAPMAP: Link already exists: " + url; return; } }

                //ADD URL
                using (TextWriter tw = new StreamWriter(GlobalVariables.Path.File.Links, true)) { tw.WriteLine(url); }
            }

            //MAKE ITEM
            ListViewItem lvi = new ListViewItem(new string[] { (links.Items.Count + 1).ToString(), url, "" }) { /*for opening*/ Tag = url }; 
            if (url.StartsWith(GlobalVariables.Settings.Common.Comment))
            {
                lvi.Font = new System.Drawing.Font(links.Font, System.Drawing.FontStyle.Italic);
                lvi.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                lvi.ForeColor = System.Drawing.Color.Silver;
            }

            //ADD ITEM
            links.Items.Add(lvi);

            //GET ICON & TITLE
            int index = links.Items.Count - 1; //define int because links.Items.Count changes fast

            new Thread(() =>
            {
                try
                {
                    string[] icons = Directory.GetFiles(GlobalVariables.Path.Dir.FavIcons);
                    bool added = false;
                    foreach (string icon in icons)
                    {
                        FileInfo fi = new FileInfo(icon);

                        if (links.Items[index].Tag.ToString().Contains(fi.Name.Replace(fi.Extension, "")))
                        {
                            string hash = links.Items[index].GetHashCode().ToString();
                            favicons.Images.Add(hash, Image.FromFile(fi.FullName));
                            links.Items[index].ImageKey = hash;
                            added = true;
                            break;
                        }
                    }

                    //LASTLY TRY THE URL
                    if (!added)
                    {
                        foreach (string file in icons)
                        {
                            FileInfo fi = new FileInfo(file);
                            if (new System.Globalization.CultureInfo("").CompareInfo.IndexOf(links.Items[index].Tag.ToString(), fi.Name.Replace(fi.Extension, ""), System.Globalization.CompareOptions.IgnoreCase) >= 0)
                            {
                                string hash = links.Items[index].GetHashCode().ToString();
                                favicons.Images.Add(hash, Image.FromFile(fi.FullName));
                                links.Items[index].ImageKey = hash;
                                added = true;
                                break;
                            }
                        }
                    }

                    //if all fails add null icon
                    if (!added)
                    {
                        favicons.Images.Add(index.ToString(), new Bitmap(16, 16));
                    }
                }
                catch (Exception) { }
            }){ IsBackground = true }.Start();


            new Thread(() =>
            {
                links.Items[index].SubItems[2].Text = get_html_title(links.Items[index].Tag.ToString());
            }) { IsBackground = true }.Start();

            //SCROLL
            links.Items[links.Items.Count - 1].EnsureVisible();

            //auto resize
            foreach (ColumnHeader column in links.Columns) { column.Width = -2; }
        }

        private void links_find()
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Find what?", "Find URL/COMMENT", "", -1, -1);

            if (!string.IsNullOrEmpty(input))
            {
                links.SelectedItems.Clear();
                foreach (ListViewItem lvi in links.Items)
                {
                    if (lvi.SubItems[1].Text.Contains(input))
                    {
                        links.Items[lvi.Index].Selected = true;
                        links.Items[lvi.Index].EnsureVisible();
                        links.Select();
                    }
                }

                this.Text = "FAPMAP: Found " + links.SelectedItems.Count + " item(s)";
            }
        }

        

        #endregion

        #region Links -> RMB/SHORTCUTS

        private void wb_url_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }

        private void wb_url_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string stringData = e.Data.GetData(typeof(string)) as string;
            wb_url.Text = stringData;
        }

        //START
        private void Links_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                links_start();
            }
        }
        //SHORTCUTS
        private void Links_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter: e.SuppressKeyPress = true; links_start(); break;
                case Keys.Delete: links_del(); break;
                case Keys.F5: links_reload(); break;
            }
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A: foreach (ListViewItem lvi in links.Items) { lvi.Selected = true; } break;
                    case Keys.R: links_reload(); break;
                    case Keys.S: links_reloadTitle(); break;
                    case Keys.W: links_incognito(); break;
                    case Keys.Q: links_comment(); break;
                    case Keys.T: links_unComment(); break;
                    case Keys.D: if (e.Shift) { links_webgrab(); }else{ links_download(); } break;
                    case Keys.Y: links_youtubedl(); break;
                    case Keys.F: links_find(); break;
                    case Keys.B: fapmap_board fb = new fapmap_board(); fb.Show(); break;
                    case Keys.C: links_copy(); break;
                    case Keys.X: links_copy(); links_del(); break;
                    case Keys.V: links_paste(); break;
                    case Keys.E: links_edit(); break;
                }
            }
            
            
        }
        
        //REFRESH
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            links_reload();
        }
        //OPEN LINK // RIGHT CLICK
        private void openSelectedLinkToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            links_start();
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            links_incognito();
        }
        //COMMENT OUT
        private void commentOutCTRLQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            links_comment();
        }
        //UNCOMMENT
        private void unCommentCTRLQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            links_unComment();
        }
        //COPY SELECTED
        private void copyLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            links_copy();
        }
        //CUT SELECTED
        private void cutLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            links_copy();
            links_del();
        }
        //PASTE FROM CLIPBOARD
        private void pasteFromClipBoardCTRLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            links_paste();
        }
        //DELETE
        private void deleteSelectedLinkDELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            links_del();
        }
        //FIND
        private void findCTRLFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            links_find();
        }
        //reload title
        private void links_RMB_reloadTitle_Click(object sender, EventArgs e)
        {
            links_reloadTitle();
        }
        //EDIT LINKS
        private void editLinksLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            links_edit();
        }
        //DOWNLOAD
        private void downloadCTRLDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            links_download();
        }
        //SCAN PAGE
        private void scanPageCTRLSHIFTDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            links_webgrab();
        }
        private void links_RMB_youtubedl_Click(object sender, EventArgs e)
        {
            links_youtubedl();
        }
        //URL BOARD
        private void uRLBoardCTRLBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fapmap_board fb = new fapmap_board(); fb.Show();
        }

        #endregion

        #region Links -> Drag&Drop 

        private void Links_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            try
            {
                if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
                {
                    e.Effect = System.Windows.Forms.DragDropEffects.All;
                }
            }
            catch (Exception) { }
        }
        private void Links_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            try
            {
                string stringData = e.Data.GetData(typeof(string)) as string;
                links_add(stringData);
            }
            catch (Exception) { }
        }

        #endregion

        #region Links -> FontSize

        public static int LinksSize = 9;

        //++
        private void resizelink_add_Click(object sender, EventArgs e)
        {
            if (LinksSize < 20)
            {
                LinksSize++;
                links.Font = new Font("Consolas", LinksSize, System.Drawing.FontStyle.Regular);
            }

            links_reload();
        }
        //--
        private void resizelink_sub_Click(object sender, EventArgs e)
        {
            if (LinksSize > 6)
            {
                LinksSize--;
                links.Font = new Font("Consolas", LinksSize, System.Drawing.FontStyle.Regular);
            }

            links_reload();
        }
        //reset
        private void resizelink_def_Click(object sender, EventArgs e)
        {
            LinksSize = 9;
            links.Font = new Font("Consolas", LinksSize, System.Drawing.FontStyle.Regular);

            links_reload();
        }
        
        #endregion

        #endregion

        #region video - playlist
        
        private void faftv_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            TreeNodeStates state = e.State;
            Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
            Color foreColor = Color.MediumSlateBlue;
            Color backColor = Color.FromArgb(20, 20, 20);

            string path = e.Node.Tag.ToString();
            if (Directory.Exists(path))
            {
                //SET COLOR BY ATTRIB
                FileAttributes attrib_dir = File.GetAttributes(path);
                if (attrib_dir.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { foreColor = Color.Silver; }
                else if (attrib_dir.HasFlag(FileAttributes.Hidden)) { foreColor = Color.Orange; }
                else { foreColor = Color.Red; }
            }
            else if (File.Exists(path))
            {
                //SET COLOR BY ATTRIB
                FileAttributes attrib_dir = File.GetAttributes(path);
                if (attrib_dir.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { foreColor = Color.Silver; }
                else if (attrib_dir.HasFlag(FileAttributes.Hidden)) { foreColor = Color.Orange; }
                else { foreColor = Color.Red; }
            }
            else { e.Node.Remove(); return; }

            // node is selected
            if (!e.Node.TreeView.Focused && e.Node == e.Node.TreeView.SelectedNode)
            {
                foreColor = Color.LightGray;
                using (Brush background = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(background, e.Bounds);
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, foreColor, TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
                }
            }
            else if ((state & TreeNodeStates.Selected) == TreeNodeStates.Selected)
            {
                foreColor = Color.White;
                using (Brush background = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(background, e.Bounds);
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, foreColor, TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
                }
            }
            // node is not selected
            else
            {
                using (Brush background = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(background, e.Bounds);
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, foreColor, TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
                }
            }
        }
        
        private void showMedia_video_fit_CheckedChanged(object sender, EventArgs e)
        {
            if (showMedia_video_fit.Checked)
            {
                showMedia_video.stretchToFit = true;
            }
            else
            {
                showMedia_video.stretchToFit = false;
            }
        }
        
        private void menu_restart_Click(object sender, EventArgs e)
        {
            DialogResult di = MessageBox.Show("Are You Sure You Want To Restart FapMap?", "FAPMAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (di == DialogResult.Yes)
            {
                Process.Start(Application.ExecutablePath);
                Quit();
            }
        }

        private void menu_hideWindow_Click(object sender, EventArgs e)
        {
            this_hide();
        }
        
        private List<string> video_playlist = new List<string>();
        private bool video_playlist_enabled = false;
        private int video_playlist_current = -1;
        private string video_playlist_current_path = string.Empty;
        private void video_playList_disable()
        {
            //DISABLE
            showMedia_video_RMB_playList_make.Checked = false;
            video_playlist_create_busy = false;
            video_playlist_enabled = false;
            video_playlist_current = -1;

            //RESET CONTROL
            HelpBalloon.SetToolTip(showMedia_video_undo, "Refresh");
            showMedia_video_undo.BackgroundImage = Properties.Resources.image_menu_restart;

            HelpBalloon.SetToolTip(showMedia_video_skip, "Random Video (LMB = FROM MAIN FOLDER/RMB = FROM CURRENT FOLDER)");
            showMedia_video_ctrlsPanel_playlistIndex.Text = "...";
        }
        private bool video_playlist_create_busy = false;
        private void video_playlist_create_thread(string path, bool only, string only_str, bool nologs, bool random, bool reverse)
        {
            if (!video_playlist_create_busy)
            {
                new Thread(() => video_playlist_create(path, only, only_str, nologs, random, reverse))
                { IsBackground = true }.Start();
            }
        }
        private void video_playlist_create(string path, bool only, string only_str, bool nologs, bool random, bool reverse)
        {
            if (!video_playlist_create_busy)
            {
                video_playlist_create_busy = true;
                
                //CONTROL
                HelpBalloon.SetToolTip(showMedia_video_undo, "Previous file");
                showMedia_video_undo.BackgroundImage = Properties.Resources.image_button_arrow_left;

                if (File.Exists(path)) { path = Directory.GetParent(path).ToString(); }

                //ECHO
                this.Text = "FAPMAP: Playlist[...]";

                //clear playlist
                video_playlist.Clear();

                //set path for timestamp
                video_playlist_current_path = path;

                //GET VIDEO FILES
                List<string> all_files = new List<string>();
                foreach (string type in GlobalVariables.Settings.Media.FileTypes.Video)
                {
                    foreach (string file in Directory.GetFiles(path, "*" + type, SearchOption.AllDirectories))
                    {
                        all_files.Add(file);
                    }
                }

                //no files
                if (all_files.Count == 0){
                    MessageBox.Show("No video files found...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    video_playList_disable();
                    return;
                }
                
                if (only)
                {
                    List<string> newFiles = new List<string>();
                    System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("");
                    foreach (string file in all_files)
                    {
                        if (ci.CompareInfo.IndexOf(file, only_str, System.Globalization.CompareOptions.IgnoreCase) >= 0) { newFiles.Add(file); }
                    }
                    all_files = newFiles;
                }

                //no files
                if (all_files.Count == 0)
                {
                    MessageBox.Show("No video files found...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    video_playList_disable();
                    return;
                }

                //no logged files
                if (nologs)
                {
                    string[] log_lines = File.ReadAllLines(GlobalVariables.Path.File.Log);
                    List<string> log_files = new List<string>();
                    foreach (string line in log_lines)
                    {
                        string[] index = line.Split(new string[] { "|||" }, StringSplitOptions.None);
                        if (index.Length == 3) { if (index[1] == fapmap.GlobalVariables.LOG_TYPE.PLAY) { log_files.Add(index[2]); } }
                    }
                    log_files = log_files.Distinct().ToList(); //remove dupes
                    
                    List<string> newFiles = new List<string>();
                    foreach (string file in all_files)
                    {
                        bool add = true;
                        FileInfo fi_file = new FileInfo(file);
                        foreach (string log in log_files)
                        {
                            FileInfo fi_log = new FileInfo(log);
                            if (fi_log.Name.Replace(fi_log.Extension, "") == fi_file.Name.Replace(fi_file.Extension, ""))
                            { add = false; }
                        }
                        if (add) { newFiles.Add(file); }
                    }
                    all_files = newFiles;
                }
                
                //no files
                if (all_files.Count == 0)
                {
                    MessageBox.Show("No video files found...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    video_playList_disable();
                    return;
                }

                if (random) { shuffle_string_list(all_files); }
                if (reverse) { all_files.Reverse(); }

                ///done

                //ENABLE
                video_playlist_enabled = true;
                
                //set new files to playlist
                video_playlist = all_files;

                //set
                this.Text = "FAPMAP: Playlist[" + (video_playlist_current + 1).ToString() + "/" + video_playlist.Count + "]";
                HelpBalloon.SetToolTip(showMedia_video_skip, "Next File");

                //play first one
                playlist_update(-1);

                video_playlist_create_busy = false;
            }
        }

        private void playlist_update(int index)
        {
            if (video_playlist.Count == 0) { return; }

            switch (index)
            {
                //++
                case -1:
                    {
                        //UPDATE
                        if (video_playlist_current >= video_playlist.Count - 1) { video_playlist_current = -1; }
                        video_playlist_current++;

                        //PLAY
                        string file = video_playlist[video_playlist_current];
                        load_file_or_dir(file);
                        showMedia_video_ctrlsPanel_playlistIndex.Text = (video_playlist_current + 1).ToString() + "/" + video_playlist.Count;

                        break;
                    }

                //--
                case -2:
                    {
                        //UPDATE
                        if (video_playlist_current <= 0) { video_playlist_current = video_playlist.Count; }
                        video_playlist_current--;

                        //PLAY
                        string file = video_playlist[video_playlist_current];
                        load_file_or_dir(file);
                        showMedia_video_ctrlsPanel_playlistIndex.Text = (video_playlist_current + 1).ToString() + "/" + video_playlist.Count;

                        break;
                    }

                default:
                    {
                        //UPDATE
                        video_playlist_current = index - 1;
                        if (video_playlist_current >= video_playlist.Count - 1 || index <= 0) { video_playlist_current = 0; }

                        //PLAY
                        string file = video_playlist[video_playlist_current];
                        load_file_or_dir(file);
                        showMedia_video_ctrlsPanel_playlistIndex.Text = (video_playlist_current + 1).ToString() + "/" + video_playlist.Count;
                        break;
                    }
            }


        }

        private static Random shuffle_string_list_num = new Random();

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (faftv.SelectedNode != null)
            {
                start_fapmap_info(faftv.SelectedNode.Tag.ToString());
            }
        }

        private void showMedia_video_RMB_playList_make_CheckedChanged(object sender, EventArgs e)
        {
            if (showMedia_video_RMB_playList_make.Checked)
            {
                fapmap_playlist fp = new fapmap_playlist() { path = faftv_path.Text };

                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (fp.ShowDialog(this) == DialogResult.OK)
                {
                    video_playlist_create_thread(fp.path, fp.keyword, fp.keyword_str, fp.rmlogs, fp.random, fp.reverse);
                }
                else
                {
                    showMedia_video_RMB_playList_make.Checked = false;
                }

                fp.Dispose();
            }
            else
            {
                video_playList_disable();
            }
        }

        

        public static void shuffle_string_list(List<string> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = shuffle_string_list_num.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        private void skipToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!video_playlist_enabled)
            {
                MessageBox.Show("No playlist found in current session..."
                              + Environment.NewLine
                              + Environment.NewLine
                              + "Create a playlist first...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter a number:", "Playlist - Skip To", "", -1, -1);

            if (!string.IsNullOrEmpty(input))
            {
                if (!int.TryParse(input, out int input_)) { MessageBox.Show("Not a number: " + input, "Playlist - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else                                  { playlist_update(input_ > 0 ? input_ : 0); }
            }
        }
        
        #endregion
        
    }
}
