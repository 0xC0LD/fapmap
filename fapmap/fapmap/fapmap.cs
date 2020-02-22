using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WMPLib;

namespace fapmap
{
    public partial class fapmap : Form
    {
        #region main()

        public fapmap() { InitializeComponent(); }

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
                    public static string FapMapURL = "https://duckduckgo.com"; public const string FapMapURL_ = "fapmap_url";
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
                    public static bool HideOnX = false; public const string HideOnX_ = "hide_on_x";
                    public static bool FocusHide = false; public const string FocusHide_ = "hide_on_lost_focus";
                    public static bool EnableMediaPlayers = true; public const string EnableMediaPlayers_ = "enable_media_players";
                    public static bool AutoHideMediaPlayers = true; public const string AutoHideMediaPlayers_ = "auto_hide_media_players";
                    public static bool AutoPlayVideoPlayer = true; public const string AutoPlayVideoPlayer_ = "auto_play_video_player";
                    public static bool AutoPauseVideoPlayer = true; public const string AutoPauseVideoPlayer_ = "auto_pause_video_player";
                    public static bool EnableTrackbarForGifViewer = true; public const string EnableTrackbarForGifViewer_ = "enable_trackbar_for_gif_viewer";
                    public static bool EnableFileDisplay = true; public const string EnableFileDisplay_ = "enable_filedisplay";
                    public static bool EnableOpenOutsideFapmap = false; public const string EnableOpenOutsideFapmap_ = "enable_open_outside_fapmap";
                }

                public class Other
                {
                    public static List<string> AutoCompleteLines = new List<string>();
                    public static List<string> WebGrabTableLines = new List<string>(); public const string WebGrabTableLines_ = "wgtl";
                    public static List<string> MoveFileToLines = new List<string>(); public const string MoveFileToLines_ = "move";
                }
            }

            public class Path
            {
                public class Dir
                {
                    //FILES
                    public static string Main = Directory.GetParent(Application.ExecutablePath).FullName;
                    public static string MainFolder = Main + "\\Main Folder";
                    public static string DataFolder = Main + "\\data";
                    public static string FavIcons = DataFolder + "\\favicons";
                    public static string Thumbnails = DataFolder + "\\thumbnails";
                }

                public class File
                {
                    public static string Password = Path.Dir.DataFolder + "\\passwords.dll";
                    public static string Links = Path.Dir.DataFolder + "\\urls.txt";
                    public static string Settings = Path.Dir.DataFolder + "\\fapmap.ini";
                    public static string Board = Path.Dir.DataFolder + "\\board.ini";
                    public static string Keywords = Path.Dir.DataFolder + "\\keywords.lst";
                    public static string Log = Path.Dir.DataFolder + "\\fapmap.log";

                    public class Exe
                    {
                        public static string FFMPEG = Path.Dir.Main + "\\ffmpeg.exe";
                        public static string WEBGRAB = Path.Dir.Main + "\\webgrab.exe";
                        public static string YOUTUBEDL = Path.Dir.Main + "\\youtube-dl.exe";
                        public static string FSCAN = Path.Dir.Main + "\\fscan.exe";
                    }
                }
            }

            public class LOG_TYPE
            {
                public const string OPEN = "OPEN";
                public const string PLAY = "PLAY";
                public const string EXEC = "EXEC";

                public const string MOVE = "MOVE";
                public const string COPY = "COPY";
                public const string RENM = "RENM";
                public const string MKDR = "MKDR";
                public const string RMVD = "RMVD";
                public const string DING = "DING";
                public const string DLED = "DLED";
                public const string NTFD = "404E";

                public const string LOAD = "LOAD";
                public const string FAIL = "FAIL";

                public const string UDEL = "UDEL";
                public const string PASS = "PASS";
            }
        }

        public static bool this_selected = false;
        private void fapmap_Load(object sender, EventArgs e)
        {
            nestFiles();

            settings_load();
            settings_apply();

            faftv_reload();

            links_reload(GlobalVariables.Path.File.Links);

            menu_changeTabs_MouseUp(null, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)); //HIDE PANEL 2

            //REMOVE TEXTBOX FOCUS
            this.ActiveControl = menu;
            menu.Focus();
            load_file_or_dir(GlobalVariables.Path.Dir.MainFolder);
        }

        #endregion

        #region Main Window Events

        private void fapmap_FormClosed(object sender, FormClosedEventArgs e) { Quit(); }
        private void fapmap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (menu_cb_fapmap_xhide.Checked)
            {
                this_hideOrShow();
                e.Cancel = true;
            }
        }
        private void fapmap_Activated(object sender, EventArgs e)
        {
            this_selected = true;

            if (menu_cb_players_autoPlay.Checked && (showMedia_video.playState == WMPPlayState.wmppsPaused || showMedia_video.playState == WMPPlayState.wmppsReady))
            {
                showMedia_video.Ctlcontrols.play();
            }
        }
        private void fapmap_Deactivate(object sender, EventArgs e)
        {
            this_selected = false;

            if (menu_cb_fapmap_focusHide.Checked) { this_hideOrShow(); return; }

            if (menu_cb_players_autoPause.Checked && showMedia_video.playState == WMPPlayState.wmppsPlaying)
            { showMedia_video.Ctlcontrols.pause(); return; }
        }
        private void fapmap_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized
             && menu_cb_players_autoPause.Checked
             && showMedia_video.playState == WMPPlayState.wmppsPlaying
            ) { showMedia_video.Ctlcontrols.pause(); }
        }
        private void Quit()
        {
            this_trayicon.Dispose();
            System.Environment.Exit(0);
        }

        private void this_hideOrShow()
        {
            if (this.Visible)
            {
                showMedia_video.Ctlcontrols.pause();
                this.Icon = Properties.Resources.fapmap_silver;
                this.this_trayicon.Icon = Properties.Resources.fapmap_silver;
                this.Hide();
            }
            else
            {
                this.Show();
                if (this.WindowState == FormWindowState.Minimized) { this.WindowState = FormWindowState.Normal; }
                this.Icon = Properties.Resources.fapmap_mediumblue;
                this.this_trayicon.Icon = Properties.Resources.fapmap_purple;
            }
        }
        private void this_trayicon_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left: this_hideOrShow(); break;
                case MouseButtons.Right: Quit(); break;
            }
        }

        #endregion

        #region fx

        // fix tooltip color
        private void HelpBalloon_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void faftv_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            /*
            TreeNodeStates state = e.State;
            Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
            Color foreColor = Color.MediumSlateBlue;
            Color backColor = Color.FromArgb(20, 20, 20);

            string path = e.Node.Tag.ToString();
            if (Directory.Exists(path))
            {
                //SET COLOR BY ATTRIB
                FileAttributes attrib_dir = File.GetAttributes(path);
                if (attrib_dir.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { foreColor = Color.MediumPurple; }
                else if (attrib_dir.HasFlag(FileAttributes.Hidden)) { foreColor = Color.SteelBlue; }
                else { foreColor = Color.DarkOrchid; }
            }
            else if (File.Exists(path))
            {
                //SET COLOR BY ATTRIB
                FileAttributes attrib_dir = File.GetAttributes(path);
                if (attrib_dir.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { foreColor = Color.MediumPurple; }
                else if (attrib_dir.HasFlag(FileAttributes.Hidden)) { foreColor = Color.SteelBlue; }
                else { foreColor = Color.DarkOrchid; }
            }
            else { e.Node.Remove(); return; }

            // node is selected
            if (!e.Node.TreeView.Focused && e.Node == e.Node.TreeView.SelectedNode)
            {
                foreColor = Color.CornflowerBlue;
                using (Brush background = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(background, e.Bounds);
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, foreColor, TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
                }
            }
            else if ((state & TreeNodeStates.Selected) == TreeNodeStates.Selected)
            {
                foreColor = Color.SkyBlue;
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
            /**/
        }

        #endregion

        #region Global Functions

        #region DO

        public static bool checkForApp(string path, string downloadUrl)
        {
            if (!File.Exists(path))
            {
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, path);

                if (MessageBox.Show(
                    "Unable to find: " + Path.GetFileName(path) + Environment.NewLine +
                    "Do you want to download " + Path.GetFileNameWithoutExtension(path) + "?" + Environment.NewLine +
                    "Click [Yes] to open URL:" + Environment.NewLine +
                    downloadUrl,
                    "ERROR",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error
                ) == DialogResult.Yes) { fapmap.Incognito(downloadUrl); }

                return false;
            }

            return true;
        }

        public static bool OpenPathSelector(IWin32Window th, TextBox tx, bool appendSlash)
        {
            bool ret = true;
            fapmap_dirSelect fp = new fapmap_dirSelect();
            if (fp.ShowDialog(th) == DialogResult.OK)
            {
                tx.Text = fp.path + (appendSlash ? "\\" : "");
                ret = true;
            }
            else { ret = false; }
            fp.Dispose();
            return ret;
        }
        public static bool OpenProperties(string fileOrDirPath)
        {
            if (string.IsNullOrEmpty(fileOrDirPath)) { return false; }
            new fapmap_info() { path = fileOrDirPath }.Show();
            return true;
        }
        public static string OpenInputBox(IWin32Window t, string Prompt, string defInput, int selFrom, int selCount)
        {
            string ret = string.Empty;
            fapmap_input fi = new fapmap_input()
            {
                prompt = Prompt,
                defaultInput = defInput,
                selectFrom = selFrom,
                selectCount = selCount
            };

            if (fi.ShowDialog(t) == DialogResult.OK) { ret = fi.input; }
            fi.Dispose();
            return ret;
        }

        public static bool Open(string path)
        {
            try { Process.Start(path); }
            catch (FileNotFoundException) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, path); return false; }
            catch (Win32Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (ObjectDisposedException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }

            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.OPEN, path);
            return true;
        }

        public static bool OpenInExplorer(string path)
        {
            string str4log = "explorer.exe \"" + path + "\"";
            try { Process.Start("explorer.exe", "\"" + path + "\""); }
            catch (FileNotFoundException) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, path); return false; }
            catch (Win32Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + str4log); return false; }
            catch (ObjectDisposedException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + str4log); return false; }
            catch (Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + str4log); return false; }

            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, str4log);
            return true;
        }
        public static bool OpenAndSelectInExplorer(string file)
        {
            string str4log = "explorer.exe /select,\"" + file + "\"";
            try { Process.Start("explorer.exe", "/select,\"" + file + "\""); }
            catch (Win32Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + str4log); return false; }
            catch (ObjectDisposedException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + str4log); return false; }
            catch (FileNotFoundException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, e.Message + " : " + str4log); return false; }
            catch (Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + str4log); return false; }

            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, str4log);
            return true;
        }
        public static bool OpenInNotepad(string path)
        {
            string str4log = "notepad.exe \"" + path + "\"";
            try { Process.Start("notepad.exe", "\"" + path + "\""); }
            catch (FileNotFoundException) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, path); return false; }
            catch (Win32Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + str4log); return false; }
            catch (ObjectDisposedException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + str4log); return false; }
            catch (Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + str4log); return false; }

            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, str4log);
            return true;
        }
        public static void OpenScript(string file, string workingDir, IWin32Window owner)
        {
            string input = fapmap.OpenInputBox(owner, "Arguments:", "", 0, 0);
            if (!string.IsNullOrEmpty(input))
            {
                if (File.Exists(workingDir)) { workingDir = new FileInfo(workingDir).Directory.FullName; }

                //FFMPEG
                Process bat = new Process();
                bat.StartInfo.FileName = file;
                bat.StartInfo.Arguments = input;
                bat.StartInfo.UseShellExecute = false;
                bat.StartInfo.CreateNoWindow = false;
                bat.StartInfo.WorkingDirectory = workingDir;
                bat.StartInfo.RedirectStandardOutput = false;
                bat.StartInfo.RedirectStandardError = false;
                bat.Start();
            }
        }
        public static bool Incognito(string link = "")
        {
            string url = link;

            if (!string.IsNullOrEmpty(url) && !Uri.IsWellFormedUriString(url, UriKind.Absolute)) { url = "https://duckduckgo.com/?q=" + url.Replace(" ", "+"); }

            try
            {
                Process.Start(GlobalVariables.Settings.WebBrowser.Browser, GlobalVariables.Settings.WebBrowser.BrowserArguments + " " + url);
            }
            catch (Win32Exception e)
            {
                LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, GlobalVariables.Settings.WebBrowser.Browser);
                LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message);
                MessageBox.Show("Unable to find: " + GlobalVariables.Settings.WebBrowser.Browser + Environment.NewLine + Environment.NewLine +
                    "You can change the browser in the settings...",
                    "Browser not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (ObjectDisposedException e) { LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message); return false; }
            catch (FileNotFoundException e) { LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message); return false; }
            catch (Exception e) { LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message); return false; }

            LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, GlobalVariables.Settings.WebBrowser.Browser + " " + GlobalVariables.Settings.WebBrowser.BrowserArguments + " " + url);
            return true;
        }

        public static bool MoveFile(string src, string dest)
        {
            if (!File.Exists(src))
            {
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, src);
                return false;
            }

            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.MoveFile
                (
                    src,
                    dest,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException
                );
            }
            catch (FileNotFoundException) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, src + "->" + dest); return false; }
            catch (OperationCanceledException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (ArgumentNullException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (ArgumentException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (PathTooLongException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (NotSupportedException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (System.Security.SecurityException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (UnauthorizedAccessException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (IOException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }

            // skipped
            if (File.Exists(src)) { return false; }

            LogThis(fapmap.GlobalVariables.LOG_TYPE.MOVE, src + " -> " + dest);
            return true;
        }
        public static bool MoveDir(string src, string dest)
        {
            if (!Directory.Exists(src))
            {
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, src);
                return false;
            }

            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory
                (
                    src,
                    dest,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException
                );
            }
            catch (FileNotFoundException) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, src + "->" + dest); return false; }
            catch (OperationCanceledException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (ArgumentNullException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (ArgumentException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (PathTooLongException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (NotSupportedException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (System.Security.SecurityException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (UnauthorizedAccessException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (IOException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }

            // skipped
            if (Directory.Exists(src)) { return false; }

            LogThis(fapmap.GlobalVariables.LOG_TYPE.MOVE, src + " -> " + dest);
            return true;
        }

        public static bool CopyFile(string src, string dest)
        {
            if (!File.Exists(src))
            {
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, src);
                return false;
            }

            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.CopyFile
                (
                    src,
                    dest,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException
                );
            }
            catch (FileNotFoundException) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, src + "->" + dest); return false; }
            catch (OperationCanceledException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (ArgumentNullException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (ArgumentException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (PathTooLongException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (NotSupportedException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (System.Security.SecurityException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (UnauthorizedAccessException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (IOException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }

            LogThis(fapmap.GlobalVariables.LOG_TYPE.COPY, src + " -> " + dest);
            return false;
        }
        public static bool CopyDir(string src, string dest)
        {
            if (!Directory.Exists(src))
            {
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, src);
                return false;
            }

            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory
                (
                    src,
                    dest,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException
                );
            }
            catch (FileNotFoundException) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, src + "->" + dest); return false; }
            catch (OperationCanceledException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (ArgumentNullException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (ArgumentException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (PathTooLongException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (NotSupportedException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (System.Security.SecurityException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (UnauthorizedAccessException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (IOException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }
            catch (Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + src + "->" + dest); return false; }

            LogThis(fapmap.GlobalVariables.LOG_TYPE.COPY, src + " -> " + dest);
            return false;
        }

        public static bool TrashFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, filePath);
                return false;
            }

            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile
                (
                    filePath,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin
                );
            }
            catch (FileNotFoundException) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, filePath); return false; }
            catch (ArgumentNullException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + filePath); return false; }
            catch (ArgumentException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + filePath); return false; }
            catch (PathTooLongException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + filePath); return false; }
            catch (NotSupportedException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + filePath); return false; }
            catch (System.Security.SecurityException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + filePath); return false; }
            catch (UnauthorizedAccessException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + filePath); return false; }
            catch (IOException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + filePath); return false; }
            catch (Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + filePath); return false; }

            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.RMVD, filePath);
            return true;

        }
        public static bool TrashDir(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, dirPath);
                return false;
            }

            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory
                (
                    dirPath,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin
                );
            }
            catch (FileNotFoundException) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, dirPath); return false; }
            catch (ArgumentNullException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + dirPath); return false; }
            catch (ArgumentException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + dirPath); return false; }
            catch (PathTooLongException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + dirPath); return false; }
            catch (NotSupportedException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + dirPath); return false; }
            catch (System.Security.SecurityException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + dirPath); return false; }
            catch (UnauthorizedAccessException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + dirPath); return false; }
            catch (IOException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + dirPath); return false; }
            catch (Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + dirPath); return false; }

            fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.RMVD, dirPath);
            return true;
        }

        public static bool CreateDir(string path)
        {
            if (Directory.Exists(path)) { return false; }

            try
            {
                Directory.CreateDirectory(path);
            }
            catch (UnauthorizedAccessException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (ArgumentNullException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (ArgumentException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (PathTooLongException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (DirectoryNotFoundException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (NotSupportedException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (IOException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }

            LogThis(GlobalVariables.LOG_TYPE.MKDR, path);
            return true;
        }

        public static void LogThis(string action, string text)
        {
            // DD.AA.TEEE TT:IM:EE|||ACTN|||FILE/URL/TEXT/...
            using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Log))
            {
                w.WriteLine(time() + "|||" + action + "|||" + text);
            }
        }

        public static void nestFiles()
        {
            if (!Directory.Exists(GlobalVariables.Path.Dir.MainFolder)) { Directory.CreateDirectory(GlobalVariables.Path.Dir.MainFolder); }
            if (!Directory.Exists(GlobalVariables.Path.Dir.DataFolder)) { Directory.CreateDirectory(GlobalVariables.Path.Dir.DataFolder); }
            if (!Directory.Exists(GlobalVariables.Path.Dir.FavIcons)) { Directory.CreateDirectory(GlobalVariables.Path.Dir.FavIcons); }
            if (!Directory.Exists(GlobalVariables.Path.Dir.Thumbnails)) { Directory.CreateDirectory(GlobalVariables.Path.Dir.Thumbnails); }

            Directory.SetCurrentDirectory(fapmap.GlobalVariables.Path.Dir.MainFolder);

            if (!File.Exists(GlobalVariables.Path.File.Settings))
            {
                using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Settings))
                {
                    //COMMENTS
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + " ============[ FAPMAP SETTINGS ]============");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "  FIREFOX.: firefox.exe -private-window");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "  OPERA...: opera.exe --private");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "  CHROME..: chrome.exe --incognito");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "===[CHECKBOXES]");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "");
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.HideOnX_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.HideOnX));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.FocusHide_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.FocusHide));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableFileDisplay_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableFileDisplay));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap));
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "===[WEBGRAB TABLE]");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "");
                    string resource_data = Properties.Resources.file_webgrab_table;
                    List<string> words = resource_data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    foreach (string line in words) { w.WriteLine(GlobalVariables.Settings.Other.WebGrabTableLines_ + GlobalVariables.Settings.Common.Equal + line); }
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "===[MOVE (FILE) TO]");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + GlobalVariables.Settings.Other.MoveFileToLines_ + GlobalVariables.Settings.Common.Equal + ".\\trash");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "===[OTHER]");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "");
                    w.WriteLine(GlobalVariables.Settings.WebBrowser.Browser_ + GlobalVariables.Settings.Common.Equal + GlobalVariables.Settings.WebBrowser.Browser);
                    w.WriteLine(GlobalVariables.Settings.WebBrowser.BrowserArguments_ + GlobalVariables.Settings.Common.Equal + GlobalVariables.Settings.WebBrowser.BrowserArguments);
                    w.WriteLine(GlobalVariables.Settings.WebBrowser.FapMapURL_ + GlobalVariables.Settings.Common.Equal + GlobalVariables.Settings.WebBrowser.FapMapURL);
                    w.WriteLine(GlobalVariables.Settings.Media.GifDelay_ + GlobalVariables.Settings.Common.Equal + GlobalVariables.Settings.Media.GifDelay);
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "FILE TYPES FOR \"OPEN RANDOM FILE\" BUTTONS");
                    w.Write(GlobalVariables.Settings.Media.FileTypes.Video_ + GlobalVariables.Settings.Common.Equal);
                    foreach (string type in GlobalVariables.Settings.Media.FileTypes.Video)
                    {
                        if (type == GlobalVariables.Settings.Media.FileTypes.Video[GlobalVariables.Settings.Media.FileTypes.Video.Count - 1])
                        { w.Write("*" + type); }
                        else { w.Write("*" + type + ","); }
                    }
                    w.WriteLine("");
                    w.Write(GlobalVariables.Settings.Media.FileTypes.Image_ + GlobalVariables.Settings.Common.Equal);
                    foreach (string type in GlobalVariables.Settings.Media.FileTypes.Image)
                    {
                        if (type == GlobalVariables.Settings.Media.FileTypes.Image[GlobalVariables.Settings.Media.FileTypes.Image.Count - 1])
                        { w.Write("*" + type); }
                        else { w.Write("*" + type + ","); }
                    }
                    w.WriteLine("");


                }
            }

            if (!File.Exists(GlobalVariables.Path.File.Links))
            {
                using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Links))
                {
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + " <- use this to comment");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + " comments can't be opened (with double click)");
                    w.WriteLine(@"https://duckduckgo.com/");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + " however the link above can...");
                }
            }

            if (!File.Exists(GlobalVariables.Path.File.Log)) { using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Log)) { w.WriteLine(GlobalVariables.Settings.Common.Comment + " " + new FileInfo(GlobalVariables.Path.File.Log).Name); } }

            if (!File.Exists(GlobalVariables.Path.File.Password)) { using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Password)) { foreach (string line in GetResourceLines(Properties.Resources.file_passwords)) { w.WriteLine(line); } } }
            if (!File.Exists(GlobalVariables.Path.File.Keywords)) { using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Keywords)) { foreach (string line in GetResourceLines(Properties.Resources.file_keywords)) { w.WriteLine(line); } } }
            if (!File.Exists(GlobalVariables.Path.File.Board)) { using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Board)) { foreach (string line in GetResourceLines(Properties.Resources.file_board)) { w.WriteLine(line); } } }
        }
        public static void settings_load()
        {
            nestFiles();

            string path = fapmap.GlobalVariables.Path.File.Settings;

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

            string[] lines_settings = File.ReadAllLines(path);
            int countLine = 0;
            foreach (var line in lines_settings)
            {
                countLine++;

                if (!string.IsNullOrEmpty(line) && !line.StartsWith(GlobalVariables.Settings.Common.Comment)) //IGNORE COMMENTS
                {
                    string[] settings_index = line.Split(GlobalVariables.Settings.Common.Equal);

                    if (settings_index.Length < 2)
                    {
                        LogThis(GlobalVariables.LOG_TYPE.LOAD, "fapmap.ini (line: " + countLine + ")");
                        MessageBox.Show("Failed to load fapmap.ini on line: " + countLine, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    string setting = settings_index[0];
                    string value = line.Remove(0, (setting + GlobalVariables.Settings.Common.Equal).Length);

                    switch (setting)
                    {
                        //CHECKBOXES
                        case GlobalVariables.Settings.CheckBoxes.HideOnX_: { GlobalVariables.Settings.CheckBoxes.HideOnX = string_to_bool(value); break; }
                        case GlobalVariables.Settings.CheckBoxes.FocusHide_: { GlobalVariables.Settings.CheckBoxes.FocusHide = string_to_bool(value); break; }
                        case GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers_: { GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers = string_to_bool(value); break; }
                        case GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers_: { GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers = string_to_bool(value); break; }
                        case GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer_: { GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer = string_to_bool(value); break; }
                        case GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer_: { GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer = string_to_bool(value); break; }
                        case GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer_: { GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer = string_to_bool(value); break; }
                        case GlobalVariables.Settings.CheckBoxes.EnableFileDisplay_: { GlobalVariables.Settings.CheckBoxes.EnableFileDisplay = string_to_bool(value); break; }
                        case GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap_: { GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap = string_to_bool(value); break; }

                        //OTHER
                        case GlobalVariables.Settings.WebBrowser.Browser_: { GlobalVariables.Settings.WebBrowser.Browser = value; break; }
                        case GlobalVariables.Settings.WebBrowser.BrowserArguments_: { GlobalVariables.Settings.WebBrowser.BrowserArguments = value; break; }
                        case GlobalVariables.Settings.WebBrowser.FapMapURL_: { GlobalVariables.Settings.WebBrowser.FapMapURL = value; break; }
                        case GlobalVariables.Settings.Media.GifDelay_:
                            {
                                if (int.TryParse(value, out int output))
                                {
                                    if (output < 5) { GlobalVariables.Settings.Media.GifDelay = 5; }
                                    else { GlobalVariables.Settings.Media.GifDelay = output; }
                                }
                                else { GlobalVariables.Settings.Media.GifDelay = 50; }

                                break;
                            }
                        case GlobalVariables.Settings.Media.FileTypes.Video_:
                            {
                                GlobalVariables.Settings.Media.FileTypes.Video.Clear();
                                foreach (string type in value.Split(','))
                                    if (!string.IsNullOrEmpty(type)) { GlobalVariables.Settings.Media.FileTypes.Video.Add(type); }

                                break;
                            }
                        case GlobalVariables.Settings.Media.FileTypes.Image_:
                            {
                                GlobalVariables.Settings.Media.FileTypes.Image.Clear();
                                foreach (string type in value.Split(','))
                                    if (!string.IsNullOrEmpty(type)) { GlobalVariables.Settings.Media.FileTypes.Image.Add(type); }

                                break;
                            }

                        case GlobalVariables.Settings.Other.WebGrabTableLines_: { GlobalVariables.Settings.Other.WebGrabTableLines.Add(value); break; }
                        case GlobalVariables.Settings.Other.MoveFileToLines_: { GlobalVariables.Settings.Other.MoveFileToLines.Add(value); break; }
                    }
                }
            }

            //add prn keyword list
            GlobalVariables.Settings.Other.AutoCompleteLines.AddRange(fapmap.SafeReadLines(GlobalVariables.Path.File.Keywords));

            // add history
            foreach (string line in fapmap.SafeReadLines(GlobalVariables.Path.File.Log))
            {
                string[] index = line.Split(new string[] { "|||" }, StringSplitOptions.None);

                if (index.Length == 3)
                {
                    string str = index[2];

                    if (index[1] == fapmap.GlobalVariables.LOG_TYPE.OPEN)
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
                //if (Uri.IsWellFormedUriString(word, UriKind.Absolute)) { continue; } // remove urls

                // if it's a sentence brake it down into words
                if (word.Contains(' ')) { words.AddRange(word.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)); continue; }
                words.Add(word);
            }
            words = words.Distinct().ToList(); //remove dupes
            words.Reverse(); //bring to top
            GlobalVariables.Settings.Other.AutoCompleteLines = words; //set
        }
        public static void settings_edit(string setting_find, string newSetting)
        {
            fapmap.nestFiles();

            string[] lines = SafeReadLines(fapmap.GlobalVariables.Path.File.Settings);

            using (FileStream fs = new FileStream(fapmap.GlobalVariables.Path.File.Settings, FileMode.Open))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line) && line == "") { continue; }

                        if (line.Contains(setting_find + GlobalVariables.Settings.Common.Equal))
                        {
                            tw.WriteLine(setting_find + GlobalVariables.Settings.Common.Equal + newSetting);
                            continue;
                        }
                        tw.WriteLine(line);
                    }

                    tw.Flush();
                    fs.SetLength(fs.Position);
                }
            }
        }
        public static void settings_edit_browser(int browser)
        {
            string brws = "firefox.exe";
            string args = "-private-window";

            switch (browser)
            {
                case 0: { brws = "firefox.exe"; args = "-private-window"; break; }
                case 1: { brws = "chrome.exe"; args = "--incognito"; break; }
                case 2: { brws = "opera.exe"; args = "--private"; break; }
            }

            settings_edit(GlobalVariables.Settings.WebBrowser.Browser_, brws);
            settings_edit(GlobalVariables.Settings.WebBrowser.BrowserArguments_, args);
        }

        public static bool isMediaFileUrl(string URL)
        {
            if (string.IsNullOrEmpty(URL)) { return false; }
            if (!URL.StartsWith("http")) { return false; }
            foreach (string type in GlobalVariables.FileTypes.Video) { if (URL.Contains(type)) { return true; } }
            foreach (string type in GlobalVariables.FileTypes.Image) { if (URL.Contains(type)) { return true; } }
            return false;
        }

        #endregion

        #region GET

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
        public static string get_utc()
        {
            return DateTime.UtcNow.TimeOfDay.TotalSeconds.ToString();
        }

        public static string[] SafeReadLines(string path)
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
        public static string[] GetResourceLines(string file)
        {
            return file.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        // convert
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
        public static bool string_to_bool(string str)
        {
            return (str == "true" || str == "1" || str == "yes") ? true : false;
        }
        public static string bool_to_string(bool bl)
        {
            return bl ? "true" : "false";
        }
        public static string get_html_title(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url)) { return ""; }
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute)) { return ""; }
                foreach (string type in GlobalVariables.FileTypes.Video) { if (url.Contains(type)) { return "video?"; } }
                foreach (string type in GlobalVariables.FileTypes.Image) { if (url.Contains(type)) { return "image?"; } }
                foreach (string type in GlobalVariables.FileTypes.Other) { if (url.Contains(type)) { return "file?"; } }

                System.Net.WebClient wc = new System.Net.WebClient();
                wc.Headers.Add("user-agent", "fapmap.exe");

                string titleUNICODE = System.Net.WebUtility.HtmlDecode(get_string_in_between("<title>", "</title>", System.Text.Encoding.Default.GetString(wc.DownloadData(url)), false, false));
                string title = System.Text.Encoding.ASCII.GetString(System.Text.Encoding.ASCII.GetBytes(titleUNICODE));
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

        #endregion

        #endregion

        #region fapmap functions

        private void settings_apply()
        {
            //AUTOCOMPLTE
            foreach (string item in GlobalVariables.Settings.Other.AutoCompleteLines) { wb_url_autoCompleteMenu.AddItem(item); }

            //start a
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
                txt_url.Text = GlobalVariables.Settings.WebBrowser.FapMapURL;
                showMedia_image_gif_timer.Interval = GlobalVariables.Settings.Media.GifDelay;
            }
            catch (Exception) { }
        }

        private void OpenFile(string file)
        {
            if (fapmap.Open(file))
            {
                media_remove(menu_cb_players_autoHide.Checked);
            }
        }

        #endregion

        #region Menu Strip

        private void menu_hideWindow_Click(object sender, EventArgs e) { this_hideOrShow(); }
        private bool panel1_show = true;
        private void menu_changeTabs_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // switch tabs
            {
                if (panel1_show)
                {
                    splitContainer_main.Panel2Collapsed = true;
                    splitContainer_main.Panel2.Hide();
                    splitContainer_main.Panel1Collapsed = false;
                    splitContainer_main.Panel1.Show();
                    panel1_show = false;
                }
                else
                {
                    splitContainer_main.Panel1Collapsed = true;
                    splitContainer_main.Panel1.Hide();
                    splitContainer_main.Panel2Collapsed = false;
                    splitContainer_main.Panel2.Show();
                    panel1_show = true;
                }
            }
            else if (e.Button == MouseButtons.Right) // show both tabs
            {
                splitContainer_main.Panel1Collapsed = false;
                splitContainer_main.Panel2Collapsed = false;
                splitContainer_main.Panel1.Show();
                splitContainer_main.Panel2.Show();
            }
        }

        private void menu_open_explorer_Click(object sender, EventArgs e) { nestFiles(); OpenInExplorer(Directory.Exists(txt_path.Text) ? txt_path.Text : GlobalVariables.Path.Dir.MainFolder); }
        private void menu_open_browser_Click(object sender, EventArgs e) { Incognito(); }
        private void menu_open_finder_Click(object sender, EventArgs e) { new fapmap_find().Show(); }
        private void menu_open_fscan_Click(object sender, EventArgs e) { new fapmap_fscan() { pass_path = txt_path.Text }.Show(); }
        private void menu_open_videoPlayer_Click(object sender, EventArgs e)
        {
            if (menu_cb_players_enable.Checked)
            {
                media_remove();
                showMedia_video_panel.Visible = true;
                showMedia_video_panel.BringToFront();
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
        }
        private void menu_open_urlBoard_Click(object sender, EventArgs e) { new fapmap_board().Show(); }
        private void menu_open_converter_Click(object sender, EventArgs e) { new fapmap_ffmpeg() { pass_path = txt_path.Text }.Show(); }
        private void menu_open_urlDownloader_Click(object sender, EventArgs e) { new fapmap_download() { pass_path = txt_path.Text }.Show(); }
        private void menu_open_youtubedl_Click(object sender, EventArgs e) { new fapmap_youtubedl() { pass_path = txt_path.Text }.Show(); }
        private void menu_open_logViewer_Click(object sender, EventArgs e) { new fapmap_log().Show(); }
        private void menu_open_credits_Click(object sender, EventArgs e) { new fapmap_credit().Show(); }
        private void menu_open_settings_Click(object sender, EventArgs e) { new fapmap_settings().Show(); }

        private void menu_hideGallery_0_Click(object sender, EventArgs e) { gallery_hide(0); }
        private void menu_hideGallery_1_Click(object sender, EventArgs e) { gallery_hide(1); }
        private void menu_hideGallery_2_Click(object sender, EventArgs e) { gallery_hide(2); }

        private void gallery_hide(int Hide)
        {
            switch (Hide)
            {
                case 0: { new Thread(gallery_hide_remove) { IsBackground = true }.Start(); break; }
                case 1: { new Thread(gallery_hide_normal) { IsBackground = true }.Start(); break; }
                case 2: { new Thread(gallery_hide_full) { IsBackground = true }.Start(); break; }

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
            hideWindowsFiles();

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
            hideWindowsFiles();

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
            hideWindowsFiles();

            LogThis(GlobalVariables.LOG_TYPE.EXEC, "attrib.exe +s +h /d /s");
            this.Text = "FAPMAP: GALLERY: Files hidden (full)";
        }
        private static void hideWindowsFiles()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "attrib.exe";
            cmd.StartInfo.WorkingDirectory = fapmap.GlobalVariables.Path.Dir.Main;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.Arguments = "+s +h /d /s desktop.ini";
            cmd.Start();
            cmd.WaitForExit();
        }

        private void menu_restart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Restart FapMap?", "FAPMAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start(Application.ExecutablePath);
                Quit();
            }
        }

        #endregion

        #region load_file_or_dir

        private void load_file(string path)
        {
            if (!menu_cb_players_enable.Checked) { return; }

            //CHECK IF IMAGE FILE
            foreach (string type in GlobalVariables.FileTypes.Image)
            {
                if (path.EndsWith(type))
                {
                    //LOAD FOR GIFS
                    if (menu_cb_players_trackbar.Checked && path.EndsWith(".gif")) //GIF VIEWER
                    {
                        //this.Text = "FAPMAP: LOADING: " + path;

                        bool gif_is_valid = true;

                        //LOAD
                        try
                        {
                            Image img = Image.FromFile(path);
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

                            LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, path);
                            //this.Text = "FAPMAP: SHOWING: " + path;
                            media_title_echo(path, showMedia_image_title);

                            return;
                        }
                    }

                    //NORMAL LOAD
                    showMedia_image_gifbox(false);

                    try
                    {
                        showMedia_image.Image = Image.FromFile(path);
                        showMedia_image_panel.Visible = true;
                        showMedia_image_panel.BringToFront();
                    }
                    catch (Exception)
                    {
                        LogThis(GlobalVariables.LOG_TYPE.LOAD, "Error loading image file: " + path);
                        media_remove(menu_cb_players_autoHide.Checked);
                        MessageBox.Show(path, "Image file is invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, path);
                    //this.Text = "FAPMAP: SHOWING: " + path;
                    media_title_echo(path, showMedia_image_title);

                    break;
                }
            }

            foreach (string type in GlobalVariables.FileTypes.Video)
            {
                if (path.EndsWith(type))
                {
                    try
                    {
                        showMedia_video.URL = path;
                        showMedia_video_panel.Visible = true;
                        showMedia_video_panel.BringToFront();
                    }
                    catch (Exception)
                    {
                        LogThis(GlobalVariables.LOG_TYPE.LOAD, "Error loading video file: " + path);
                        MessageBox.Show(path, "Video file is invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, path);
                    //this.Text = "FAPMAP: SHOWING: " + path;
                    media_title_echo(path, showMedia_video_title);

                    return;
                }
            }
        }

        private bool load_dir_busy = false;
        private bool load_dir_cancel = false;
        private Mutex load_dir_mutex = new Mutex();
        private int load_dir_count = 0;
        private void load_dir(string path)
        {
            if (!menu_cb_fapmap_fileDisplay.Checked) { return; }

            if (load_dir_cancel) { load_dir_busy = false; load_dir_cancel = false; return; }
            if (load_dir_busy) { load_dir_cancel = true; }
            load_dir_busy = true;

            new Thread(() =>
            {
                try
                {
                    load_dir_count++;
                    load_dir_mutex.WaitOne(); // 129312
                    if (load_dir_count > 1) { load_dir_count--; load_dir_mutex.ReleaseMutex(); return; }
                    load_dir_count = 0;

                    new Action(() => {

                        // set path
                        txt_path.Text = path;
                        if (File.Exists(path)) { path = new FileInfo(path).Directory.FullName; }
                        if (!Directory.Exists(path)) { return; }

                        fileDisplay_icons.Images.Clear();
                        fileDisplay.Items.Clear();

                        if (fileDisplay_watcher != null) { fileDisplay_watcher.Dispose(); }
                        fileDisplay_watcher = new FileSystemWatcher()
                        {
                            NotifyFilter = NotifyFilters.LastAccess
                                             | NotifyFilters.LastWrite
                                             | NotifyFilters.FileName
                                             | NotifyFilters.DirectoryName,
                            Filter = "*.*",
                            IncludeSubdirectories = true,
                            Path = path,
                        };
                        fileDisplay_watcher.Changed += fileDisplay_watcher_Changed;
                        fileDisplay_watcher.Created += fileDisplay_watcher_Created;
                        fileDisplay_watcher.Deleted += fileDisplay_watcher_Deleted;
                        fileDisplay_watcher.Renamed += fileDisplay_watcher_Renamed;
                        fileDisplay_watcher.EnableRaisingEvents = true;

                        //this.Text = "FAPMAP: Loading...";

                        List<ListViewItem> items = new List<ListViewItem>();
                        DirectoryInfo loadDir = new DirectoryInfo(path);
                        DirectoryInfo[] dirs = loadDir.GetDirectories();
                        FileInfo[] files = loadDir.GetFiles();

                        // get dirs
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            if (load_dir_cancel) { return; }

                            fileDisplay_icons.Images.Add(new Bitmap(Properties.Resources.dir, fileDisplay_icons.ImageSize));
                            items.Add(new ListViewItem() { Name = dirs[i].FullName, ImageIndex = items.Count, Text = dirs[i].Name });

                            if (load_dir_cancel) { return; }
                        }

                        // get files
                        Mutex mutex = new Mutex();
                        for (int i = 0; i < files.Length; i++)
                        {
                            if (load_dir_cancel) { return; }

                            if (files[i].Name == "desktop.ini") { continue; }

                            // get file thumb
                            try { fileDisplay_icons.Images.Add(new Bitmap(Icon.ExtractAssociatedIcon(files[i].FullName).ToBitmap(), fileDisplay_icons.ImageSize)); }
                            catch (Exception) { fileDisplay_icons.Images.Add(new Bitmap(Properties.Resources.image, fileDisplay_icons.ImageSize)); }

                            if (load_dir_cancel) { return; }

                            // get image thumbs
                            foreach (string type in GlobalVariables.FileTypes.Image)
                            {
                                if (files[i].Extension != type) { continue; }

                                int currentFileIndex = i;
                                int currentImageIndex = fileDisplay_icons.Images.Count - 1;

                                new Thread(() =>
                                {
                                    mutex.WaitOne();
                                    if (load_dir_cancel) { mutex.ReleaseMutex(); return; }

                                    try
                                    {
                                        Image img = Image.FromFile(files[currentFileIndex].FullName);
                                        Bitmap bmp = new Bitmap(img);
                                        img.Dispose();
                                        int size = Math.Max(bmp.Width, bmp.Height);
                                        Bitmap bmpDrawOn = new Bitmap(size, size);
                                        using (Graphics g = Graphics.FromImage(bmpDrawOn)) { g.Clear(Color.Transparent); g.DrawImage(bmp, 0, 0); }
                                        if (load_dir_cancel) { mutex.ReleaseMutex(); return; }
                                        fileDisplay_icons.Images[currentImageIndex] = new Bitmap(bmpDrawOn, fileDisplay_icons.ImageSize);
                                        bmp.Dispose();
                                        bmpDrawOn.Dispose();
                                    }
                                    catch (Exception) { }

                                    mutex.ReleaseMutex();
                                })
                                { IsBackground = true }.Start();

                                break;
                            }

                            if (load_dir_cancel) { return; }
                            
                            // get video thumbs
                            if (File.Exists(GlobalVariables.Path.File.Exe.FFMPEG))
                            {
                                foreach (string type in GlobalVariables.FileTypes.Video)
                                {
                                    if (files[i].Extension != type) { continue; }

                                    int currentFileIndex = i;
                                    int currentImageIndex = fileDisplay_icons.Images.Count - 1;

                                    new Thread(() =>
                                    {
                                        mutex.WaitOne();
                                        if (load_dir_cancel) { mutex.ReleaseMutex(); return; }

                                        try
                                        {
                                            string src = files[currentFileIndex].FullName;
                                            string dest = GlobalVariables.Path.Dir.Thumbnails + "\\" + files[currentFileIndex].Name + ".jpg";

                                            if (File.Exists(dest))
                                            {
                                                Image directImage = Image.FromFile(dest);
                                                Bitmap directImageBmp = new Bitmap(directImage);
                                                directImage.Dispose();
                                                int size = Math.Max(directImageBmp.Width, directImageBmp.Height);
                                                Bitmap drawON = new Bitmap(size, size);
                                                using (Graphics g = Graphics.FromImage(drawON)) { g.Clear(Color.Transparent); g.DrawImage(directImageBmp, 0, 0); }
                                                if (load_dir_cancel) { mutex.ReleaseMutex(); return; }
                                                fileDisplay_icons.Images[currentImageIndex] = new Bitmap(drawON, fileDisplay_icons.ImageSize);
                                                directImageBmp.Dispose();
                                                drawON.Dispose();
                                                mutex.ReleaseMutex();
                                                return;
                                            }

                                            // get image using ffmpeg
                                            var cmd = "ffmpeg  -itsoffset -1  -i " + '"' + src + '"' + " -vcodec mjpeg -vframes 1 -an -f rawvideo " + '"' + dest + '"';

                                            var startInfo = new ProcessStartInfo
                                            {
                                                WindowStyle = ProcessWindowStyle.Hidden,
                                                FileName = "cmd.exe",
                                                Arguments = "/C " + cmd
                                            };

                                            var process = new Process { StartInfo = startInfo };
                                            process.Start();
                                            process.WaitForExit();

                                            // check for changes
                                            if (load_dir_cancel) { mutex.ReleaseMutex(); return; }

                                            // load image thumb
                                            Image img = Image.FromFile(dest);
                                            Bitmap bmp = new Bitmap(img);
                                            img.Dispose();
                                            int s = Math.Max(bmp.Width, bmp.Height);
                                            Bitmap drawOnbmp = new Bitmap(s, s);
                                            using (Graphics g = Graphics.FromImage(drawOnbmp)) { g.Clear(Color.Transparent); g.DrawImage(bmp, 0, 0); }
                                            if (load_dir_cancel) { mutex.ReleaseMutex(); return; }
                                            fileDisplay_icons.Images[currentImageIndex] = new Bitmap(drawOnbmp, fileDisplay_icons.ImageSize);
                                            bmp.Dispose();
                                            drawOnbmp.Dispose();
                                        }
                                        catch (Exception) { }

                                        mutex.ReleaseMutex();
                                    })
                                    { IsBackground = true }.Start();

                                    break;
                                }
                            }
                            /**/
                            if (load_dir_cancel) { return; }

                            items.Add(new ListViewItem() { Name = files[i].FullName, ImageIndex = items.Count, Text = files[i].Name });

                            if (load_dir_cancel) { return; }
                        }
                        
                        if (load_dir_cancel) { return; }

                        // echo loaded thumbs
                        new Thread(() =>
                        {
                            mutex.WaitOne();
                            if (load_dir_cancel) { mutex.ReleaseMutex(); return; }
                            fileDisplay.Refresh();
                            mutex.ReleaseMutex();

                        })
                        { IsBackground = true }.Start();

                        if (load_dir_cancel) { return; }
                        fileDisplay.Items.AddRange(items.ToArray());
                        //this.Text = "FAPMAP: LOADED: " + fileDisplay.Items.Count + " item(s)";
                    })();

                    if (load_dir_cancel) { load_dir_cancel = false; }

                    load_dir_mutex.ReleaseMutex();
                }
                catch (Exception) { }

                load_dir_busy = false;
            }
            ) { IsBackground = true }.Start();
        }

        private string selectedFilePath = string.Empty;
        private void load_file_or_dir(string selected_path)
        {
            txt_path.Text = selected_path;

            media_remove(menu_cb_players_autoHide.Checked);

            if (Directory.Exists(selected_path)) { load_dir(selected_path); return; }

            if (File.Exists(selected_path))
            {
                selectedFilePath = selected_path;
                if (selected_path.ToLower().EndsWith(".lst")
                 || selected_path.ToLower().EndsWith(".txt")
                )
                {
                    menu_changeTabs_MouseUp(null, new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0));
                    links_reload(selected_path);
                    return;
                }
                
                load_file(selected_path);
            }

            if (isMediaFileUrl(selected_path))
            {
                media_playUrl(selected_path);
                return;
            }
        }

        #endregion

        #region fileDisplay

        #region functions

        private FileSystemWatcher fileDisplay_watcher = new FileSystemWatcher();
        private void fileDisplay_open(bool openFiles = false, bool openDirs = false)
        {
            foreach (ListViewItem item in fileDisplay.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string itemPath = item.Name;
                if (string.IsNullOrEmpty(itemPath)) { continue; }

                if (Directory.Exists(itemPath))
                {
                    if (openDirs) { fapmap.Open(itemPath); }
                    else { load_file_or_dir(itemPath); }
                }
                
                if (openFiles && File.Exists(itemPath))
                {
                    FileInfo fi = new FileInfo(itemPath);

                    if (fi.Name.Contains("fapmap_mod"))
                    {
                        OpenScript(fi.FullName, fi.Directory.FullName, this);
                        return;
                    }

                    fapmap.Open(fi.FullName);
                    media_remove(menu_cb_players_autoHide.Checked);
                }
            }
        }
        private void fileDisplay_explorer()
        {
            foreach (ListViewItem item in fileDisplay.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string itemPath = item.Name;
                if (string.IsNullOrEmpty(itemPath)) { continue; }
                OpenAndSelectInExplorer(itemPath);
            }
        }
        private void fileDisplay_backDir()
        {
            string path = this.txt_path.Text;
            if (File.Exists(path)) { this.txt_path.Text = Directory.GetParent(path).FullName; return; }
            if (!Directory.Exists(path)) { load_file_or_dir(GlobalVariables.Path.Dir.MainFolder); return; }
            
            if (new DirectoryInfo(path).Name != new DirectoryInfo(GlobalVariables.Path.Dir.MainFolder).Name)
            { load_file_or_dir(Directory.GetParent(path).ToString()); }
        }
        private void fileDisplay_delete()
        {
            foreach (ListViewItem item in fileDisplay.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string itemPath = item.Name;
                if (string.IsNullOrEmpty(itemPath)) { continue; }

                if (Directory.Exists(itemPath))
                {
                    if (fapmap.TrashDir(itemPath)) { fileDisplay.Items.Remove(item); }
                }
                else if (File.Exists(itemPath))
                {
                    media_remove(menu_cb_players_autoHide.Checked);
                    if (fapmap.TrashFile(itemPath)) { fileDisplay.Items.Remove(item); }
                }
            }
        }
        private void fileDisplay_createDir()
        {
            string path = this.txt_path.Text;

            if (File.Exists(path)) { path = Directory.GetParent(path).FullName; }
            if (!Directory.Exists(path)) { return; }

            string input = fapmap.OpenInputBox(this, "Create New Folder in: " + new DirectoryInfo(path).Name, "New Folder", 0, "New Folder".Length);
            if (!string.IsNullOrEmpty(input))
            {
                fapmap.CreateDir(new DirectoryInfo(path).FullName + "\\" + input);
            }
        }
        private void fileDisplay_rename()
        {
            foreach (ListViewItem item in fileDisplay.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string itemPath = item.Name;
                if (string.IsNullOrEmpty(itemPath)) { continue; }

                if (File.Exists(itemPath))
                {
                    media_remove(menu_cb_players_autoHide.Checked);

                    FileInfo fi_src = new FileInfo(itemPath);
                    string input = fapmap.OpenInputBox(this, "Rename file?", fi_src.Name, 0, fi_src.Name.Length - fi_src.Extension.Length);
                    if (!string.IsNullOrEmpty(input))
                    {
                        fapmap.MoveFile(fi_src.FullName, fi_src.Directory.FullName + "\\" + input);
                    }
                }
                else if (Directory.Exists(itemPath))
                {
                    if (itemPath == fapmap.GlobalVariables.Path.Dir.MainFolder)
                    {
                        MessageBox.Show("You can't rename \"Main Folder\"", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    DirectoryInfo di_src = new DirectoryInfo(itemPath);
                    string input = fapmap.OpenInputBox(this, "Rename folder?", di_src.Name, 0, di_src.Name.Length);
                    if (!string.IsNullOrEmpty(input))
                    {
                        fapmap.MoveDir(di_src.FullName, di_src.Parent.FullName + "\\" + input);
                    }
                }
            }
        }
        private void fileDisplay_properties()
        {
            foreach (ListViewItem item in fileDisplay.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string itemPath = item.Name;
                if (string.IsNullOrEmpty(itemPath)) { continue; }
                fapmap.OpenProperties(itemPath);
            }
        }
        
        private void fileDisplay_watcher_Changed(object sender, FileSystemEventArgs e)
        {
        }
        private void fileDisplay_watcher_Created(object sender, FileSystemEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (Directory.Exists(e.FullPath))
                {
                    fileDisplay_icons.Images.Add(new Bitmap(Properties.Resources.dir, fileDisplay_icons.ImageSize));
                    fileDisplay.Items.Add(new ListViewItem() { Name = e.FullPath, ImageIndex = fileDisplay.Items.Count, Text = new DirectoryInfo(e.FullPath).Name });
                }
                else if (File.Exists(e.FullPath))
                {
                    try { fileDisplay_icons.Images.Add(new Bitmap(Icon.ExtractAssociatedIcon(e.FullPath).ToBitmap(), fileDisplay_icons.ImageSize)); }
                    catch (Exception) { fileDisplay_icons.Images.Add(new Bitmap(Properties.Resources.image, fileDisplay_icons.ImageSize)); }
                    fileDisplay.Items.Add(new ListViewItem() { Name = e.FullPath, ImageIndex = fileDisplay.Items.Count, Text = new FileInfo(e.FullPath).Name });
                }
            });
        }
        private void fileDisplay_watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                foreach(ListViewItem lvi in fileDisplay.Items.Find(e.FullPath, true))
                {
                    lvi.Remove();
                    fileDisplay_icons.Images.RemoveByKey(lvi.ImageKey);
                }
            });
        }
        private void fileDisplay_watcher_Renamed(object sender, FileSystemEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                load_dir(txt_path.Text);
            });
        }
        
        #endregion

        #region ui events

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
            fileDisplay_open(menu_cb_fapmap_outside.Checked);
        }
        private void fileDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in fileDisplay.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string itemPath = item.Name;
                if (string.IsNullOrEmpty(itemPath)) { continue; }
                if (fileDisplay_isKeydown) { continue; }
                if (!Directory.Exists(itemPath))
                {
                    load_file_or_dir(itemPath);
                }
            }
        }
        
        private bool fileDisplay_isKeydown = false;
        private bool fileDisplay_escapeDown = false;
        private void fileDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            fileDisplay_isKeydown = true;
            fileDisplay_ctrl = e.Control;
            fileDisplay_shift = e.Shift;

            switch (e.KeyCode)
            {
                case Keys.Escape: media_remove(true); fileDisplay_escapeDown = true; e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.F5:     load_dir(txt_path.Text);                           e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Enter:  fileDisplay_open(true, false);                     e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Back:   fileDisplay_backDir();                             e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Delete: fileDisplay_delete();                              e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.F2:     fileDisplay_rename();                              e.Handled = true; e.SuppressKeyPress = true; break;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R: load_dir(txt_path.Text);      e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.A: fileDisplay_explorer();       e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.W: fileDisplay_open(true, true); e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.S: fileDisplay_createDir();      e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.D: fileDisplay_properties();     e.Handled = true; e.SuppressKeyPress = true; break;

                    // hidden shortcuts
                    case Keys.Z: this_hideOrShow();            e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.X: media_sw();                   e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.F: new fapmap_find().Show();     e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.G: new fapmap_settings().Show(); e.Handled = true; e.SuppressKeyPress = true; break;
                }
            }
        }
        private void fileDisplay_KeyUp(object sender, KeyEventArgs e)
        {
            fileDisplay_isKeydown = false;
            fileDisplay_ctrl = false;
            fileDisplay_shift = false;

            if (e.KeyCode == Keys.Escape) { fileDisplay_escapeDown = false; return; }
            if (fileDisplay_escapeDown) { return; }
            fileDisplay_SelectedIndexChanged(null, null);
        }
        
        #region buttons

        private void fileDisplay_btn_backDir_Click(object sender, EventArgs e)
        {
            fileDisplay_backDir();
        }
        private void fileDisplay_btn_reload_Click(object sender, EventArgs e)
        {
            load_file_or_dir(txt_path.Text);
        }
        private void fileDisplay_btn_root_Click(object sender, EventArgs e)
        {
            load_file_or_dir(GlobalVariables.Path.Dir.MainFolder);
        }
        private void fileDisplay_btn_randImage_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left: Random_VOI(selectedFilePath, true, true); break;
                case MouseButtons.Right: Random_VOI(GlobalVariables.Path.Dir.MainFolder, true, true); break;
            }
        }
        private void fileDisplay_btn_randVideo_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left: Random_VOI(selectedFilePath, false, true); break;
                case MouseButtons.Right: Random_VOI(GlobalVariables.Path.Dir.MainFolder, false, true); break;
            }
        }

        #endregion

        #region change icon size

        private bool fileDisplay_ctrl = false;
        private bool fileDisplay_shift = false;
        private int fileDisplay_sideSize = 50;
        private int fileDisplay_sideSize_min = 50;
        private int fileDisplay_sideSize_max = 255;
        private void fileDisplay_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!fileDisplay_ctrl) { return; }

            int last = fileDisplay_sideSize;
            if (e.Delta > 0 ? true : false) { fileDisplay_sideSize += (fileDisplay_shift ? 60 : 20); }
            else                            { fileDisplay_sideSize -= (fileDisplay_shift ? 60 : 20); }

            if      (fileDisplay_sideSize < fileDisplay_sideSize_min) { fileDisplay_sideSize = fileDisplay_sideSize_min; }
            else if (fileDisplay_sideSize > fileDisplay_sideSize_max) { fileDisplay_sideSize = fileDisplay_sideSize_max; }
            if (fileDisplay_sideSize == last) { return; }

            if      (fileDisplay_sideSize == fileDisplay_sideSize_min) { fileDisplay.View = View.Tile; }
            else if (fileDisplay_sideSize >  fileDisplay_sideSize_min) { fileDisplay.View = View.LargeIcon; }

            Size s = new Size(fileDisplay_sideSize, fileDisplay_sideSize);
            fileDisplay.Clear();
            fileDisplay_icons.Images.Clear();
            fileDisplay_icons.ImageSize = s;
            fileDisplay_icons.Images.Add(new Bitmap(Properties.Resources.image, s));
            for (int i = 0; i < 5; i++)
            {
                fileDisplay.Items.Add(new ListViewItem { Text = "", Tag = "", ImageIndex = 0 });
            }
        }

        #endregion

        #region RMB

        private void fileDisplay_RMB_refresh_Click(object sender, EventArgs e)
        {
            load_dir(txt_path.Text);
        }
        private void fileDisplay_RMB_open_Click(object sender, EventArgs e)
        {
            fileDisplay_open(true, true);
        }
        private void fileDisplay_RMB_explorer_Click(object sender, EventArgs e)
        {
            fileDisplay_explorer();
        }
        private void fileDisplay_RMB_delete_Click(object sender, EventArgs e)
        {
            fileDisplay_delete();
        }
        private void fileDisplay_RMB_newFolder_Click(object sender, EventArgs e)
        {
            fileDisplay_createDir();
        }
        private void fileDisplay_RMB_rename_Click(object sender, EventArgs e)
        {
            fileDisplay_rename();
        }
        private void fileDisplay_RMB_properties_Click(object sender, EventArgs e)
        {
            fileDisplay_properties();
        }

        #endregion

        #region drag n drop

        private void fileDisplay_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = System.Windows.Forms.DragDropEffects.All;
        }
        private void fileDisplay_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string url = e.Data.GetData(DataFormats.StringFormat) as string;

            if (!string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                fapmap_download fd = new fapmap_download() { pass_path = txt_path.Text };
                fd.pass_URLs.Add(url);
                fd.Show();
                return;
            }

            foreach (string src in (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop, false))
            {
                string destDir = txt_path.Text;

                if (File.Exists(txt_path.Text)) { destDir = Directory.GetParent(txt_path.Text).FullName; }
                if (!Directory.Exists(txt_path.Text)) { destDir = GlobalVariables.Path.Dir.MainFolder; }
                if (Directory.Exists(txt_path.Text)) { destDir = new DirectoryInfo(txt_path.Text).FullName; }

                if (Directory.Exists(src)) { fapmap.CopyDir(src, destDir + "\\" + new DirectoryInfo(src).Name); }
                else if (File.Exists(src)) { fapmap.CopyFile(src, destDir + "\\" + new FileInfo(src).Name); }
            }
        }

        #endregion

        #endregion

        #endregion
        
        // clean this junky code below
        #region media

        #region GIF VIEWER

        // get bitmaps
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

        // our image frames
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
            catch (System.NullReferenceException) { }
            catch (Exception) { }
        }

        private void showMedia_image_gif_trackbar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                showMedia_image.Image = showMedia_image_gif_frames[showMedia_image_gif_trackbar.Value - 1];
                showMedia_image_gif_frame.Text = showMedia_image_gif_trackbar.Value + " / " + showMedia_image_gif_trackbar.Maximum;
            }
            catch (Exception) { }
        }

        private bool showMedia_image_gif_paused = false;
        private void showMedia_image_gif_play_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!showMedia_image_gif_timer.Enabled)
                {
                    showMedia_image_gif_timer.Enabled = true;
                    showMedia_image_gif_play.BackgroundImage = Properties.Resources.pause;
                    showMedia_image_gif_paused = false;
                }
                else
                {
                    showMedia_image_gif_timer.Enabled = false;
                    showMedia_image_gif_play.BackgroundImage = Properties.Resources.play;
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
            else if (isMediaFileUrl(path))
            {
                text = path;
            }

            Bitmap bmp = new Bitmap(text.Length * 8, 20);

            //graphics
            Graphics g = Graphics.FromImage(bmp);

            //clear graphics
            g.Clear(Color.Transparent);

            g.DrawString(text, new Font("Consolas", 10), Brushes.RoyalBlue, new PointF(0, 0));

            contrl.BackgroundImage = bmp;
            contrl.BackgroundImageLayout = ImageLayout.Center;
        }
        

        //ENABLE MEDIA PLAYERS
        private void menu_cb_players_enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!menu_cb_players_enable.Checked)
            {
                media_close();
                media_repos();
            }
        }
        
        private void showMedia_close(object sender, EventArgs e)
        {
            media_close();
        }

        private void move_to_setup()
        {
            nestFiles();

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
            tsmi.ForeColor = showMedia_video_RMB_moveTo.ForeColor;
            tsmi.BackColor = Color.FromArgb(20, 20, 20);
            tsmi.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            tsmi.Image = global::fapmap.Properties.Resources.arrow_right;
            tsmi.Click += Tsmi_Click;
            tsmi.BackgroundImage = Properties.Resources.bg4;
            tsmi.BackgroundImageLayout = ImageLayout.Tile;

            return tsmi;
        }
        private void Tsmi_Click(object sender, EventArgs e)
        {
            //close video/image
            media_remove(menu_cb_players_autoHide.Checked);

            //get path
            string path = ((ToolStripMenuItem)sender).Tag.ToString();

            //make dir
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }

            if (File.Exists(selectedFilePath))
            {
                //copy file
                FileInfo fi = new FileInfo(selectedFilePath);
                string dest = new DirectoryInfo(path).FullName + "\\" + fi.Name;
                fapmap.MoveFile(fi.FullName, dest);
            }
        }

        private void showMedia_RMB_openFile_Click(object sender, EventArgs e)
        {
            OpenFile(selectedFilePath);
        }
        private void showMedia_RMB_explorer_Click(object sender, EventArgs e)
        {
            OpenInExplorer(selectedFilePath);
        }
        private void showMedia_RMB_convert_Click(object sender, EventArgs e)
        {
            media_remove(menu_cb_players_autoHide.Checked);
            new fapmap_ffmpeg() { pass_path = selectedFilePath };
        }
        private void showMedia_RMB_trashFile_Click(object sender, EventArgs e)
        {
            fapmap.TrashFile(selectedFilePath);
        }
        private void showMedia_RMB_info(object sender, EventArgs e)
        {
            OpenProperties(selectedFilePath);
        }
        
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
            // remove title
            showMedia_video_title.BackgroundImage = null;
            showMedia_image_title.BackgroundImage = null;
            
            showMedia_image_ctrlbox.Visible = false;
            showMedia_image.Size = new System.Drawing.Size(showMedia_image.Size.Width, showMedia_image_panel.Size.Height - 34);
            showMedia_image_gif_frames = null;
            showMedia_image_gif_timer.Enabled = false;
            showMedia_image.Image = new Bitmap(16, 16);
            
            showMedia_video.currentPlaylist.clear();
            showMedia_video.URL = null;
            showMedia_video.close();
            
            if (hide)
            {
                showMedia_video_panel.Visible = false;
                showMedia_image_panel.Visible = false;
            }

            GC.Collect();
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

        #region move and resize showMedia_image

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

        #region move and resize showMedia_video

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
        private void Random_VOI(string path, bool isImage, bool IsInside = true)
        {
            if (!Random_Busy)
            {
                Random_Busy = true;
                media_remove(menu_cb_players_autoHide.Checked);

                List<string> TYPES = isImage ? GlobalVariables.Settings.Media.FileTypes.Image : GlobalVariables.Settings.Media.FileTypes.Video;
                if (string.IsNullOrEmpty(path)) { path = GlobalVariables.Path.Dir.MainFolder; }
                if (File.Exists(path)) { path = new FileInfo(path).Directory.FullName; }

                List<string> all_files = new List<string>();
                foreach (string type in TYPES) //run through each type
                {
                    if      (type.StartsWith("*.")) { all_files.AddRange(Directory.GetFiles(path,        type, SearchOption.AllDirectories)); }
                    else if (type.StartsWith("."))  { all_files.AddRange(Directory.GetFiles(path, "*"  + type, SearchOption.AllDirectories)); }
                    else                            { all_files.AddRange(Directory.GetFiles(path, "*." + type, SearchOption.AllDirectories)); }
                }
                
                if (all_files.Count == 0) { Random_Busy = false; return; }

                string randFile = all_files[new Random().Next(0, all_files.Count - 1)];
                if (!IsInside || menu_cb_fapmap_outside.Checked) { fapmap.Open(randFile);      }
                else                                             { load_file_or_dir(randFile); }
                Random_Busy = false;
            }
        }

        //VIDEO POS SCROLL
        private bool showMedia_video_ctrlsPanel_pos_scrolling = false;
        //private bool showMedia_video_ctrlsPanel_pos_hovering = false;
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
            //showMedia_video_ctrlsPanel_pos_hovering = true;

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

            string str = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
            //showMedia_video_ctrlsPanel_pos_cur.ForeColor = Color.Teal;
            //showMedia_video_ctrlsPanel_pos_cur.Text = str;
            HelpBalloon.SetToolTip(showMedia_video_ctrlsPanel_pos, str);
        }
        private void showMedia_video_ctrlsPanel_pos_MouseLeave(object sender, EventArgs e)
        {
            //showMedia_video_ctrlsPanel_pos_hovering = false;
            //showMedia_video_ctrlsPanel_pos_cur.ForeColor = Color.SlateBlue;
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
                    //if (!showMedia_video_ctrlsPanel_pos_hovering)
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
                                            draw_graph((int)(peak * 100), showMedia_video_audioPanel, Color.DarkMagenta);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private DirectBitmap bmp = new DirectBitmap(160, 80);
        private void draw_graph(int data, Control pb, Color clr)
        {
            try
            {
                //new input
                using (var g = Graphics.FromImage(bmp.Bitmap))
                {
                    double pbUnit = bmp.Height / 100.0;
                    int val = (int)(data * pbUnit);

                    int point1 = bmp.Height - (val + 10);

                    g.DrawLine(new Pen(clr), new Point(0, point1 < 0 ? 0 : point1), new Point(0, bmp.Height - 1));
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
        private class DirectBitmap : IDisposable
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
        
        private int  showMedia_video_ctrlsPanel_pos_times = 100;
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
                showMedia_video_ctrlsPanel_play.BackgroundImage = Properties.Resources.pause;
            }
            else if (showMedia_video.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                showMedia_video_ctrlsPanel_pos_timer.Stop();
                showMedia_video_ctrlsPanel_play.BackgroundImage = Properties.Resources.play;
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
                    if (showMedia_video_RMB_autoRand_main.Checked)     { Random_VOI(GlobalVariables.Path.Dir.MainFolder, false, true); }
                    else if (showMedia_video_RMB_autoRand_dir.Checked) { Random_VOI(selectedFilePath,                    false, true); }
                    else if (video_playlist_enabled)                   { playlist_update(-1); }
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
            HelpBalloon.SetToolTip(showMedia_video_sound, "Player Volume ("+ showMedia_video_sound.Value + "%)");
        }
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

        
        
        private bool media_playUrl(string URL)
        {
            if (!menu_cb_players_enable.Checked) { return false ; }

            //CLEAR
            media_remove(true);

            foreach (string type in GlobalVariables.FileTypes.Image)
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
                        //this.Text = "FAPMAP: DOWNLOADING: " + URL;

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

            foreach (string type in GlobalVariables.FileTypes.Video)
            {
                if (URL.Contains(type))
                {
                    //SETUP CTRLS
                    showMedia_video_panel.Visible = true;
                    showMedia_video_panel.BringToFront();

                    try
                    {
                        //this.Text = "FAPMAP: DOWNLOADING: " + URL;

                        showMedia_video.URL = URL; // DOWNLOAD

                        LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, URL);
                        //this.Text = "FAPMAP: SHOWING: " + URL;
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

            return false;
        }

        private string showMedia_image_URL = string.Empty;
        private void showMedia_image_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Bitmap bmp = new Bitmap(showMedia_image.Width, showMedia_image.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.DrawString(e.ProgressPercentage + "%", new Font("Consolas", 15), Brushes.DarkSlateBlue, new PointF(10, 10));

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
            //this.Text = "FAPMAP: SHOWING: " + showMedia_image_URL;
        }

        
        private void showMedia_image_skip_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:  Random_VOI(selectedFilePath,                    true, true); break;
                case MouseButtons.Right: Random_VOI(GlobalVariables.Path.Dir.MainFolder, true, true); break;
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
                    case MouseButtons.Left:  Random_VOI(selectedFilePath,                    false, true); break;
                    case MouseButtons.Right: Random_VOI(GlobalVariables.Path.Dir.MainFolder, false, true); break;
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
                    load_file_or_dir(txt_path.Text);
                }
            }
        }

        #endregion
        
        #region txt_path
        
        private void txt_path_TextChanged(object sender, EventArgs e)
        {
            string str = txt_path.Text;
            str = str.Replace("\n", String.Empty);
            str = str.Replace("\r", String.Empty);
            str = str.Replace("\t", String.Empty);
            txt_path.Text = str;

            if (File.Exists(txt_path.Text) || Directory.Exists(txt_path.Text))
            {
                txt_path.ForeColor = Color.YellowGreen;
            }
            else
            {
                txt_path.ForeColor = Color.DarkOrchid;
            }

            if (string.IsNullOrEmpty(txt_path.Text) || string.IsNullOrWhiteSpace(txt_path.Text) || txt_path.Text == "NULL")
            {
                txt_path.Text = GlobalVariables.Path.Dir.MainFolder;
            }
        }
        private void txt_path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                load_file_or_dir(txt_path.Text);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_path_DragDrop(object sender, DragEventArgs e)
        {
            string str = e.Data.GetData(typeof(string)) as string;
            str = str.Replace("\n", String.Empty);
            str = str.Replace("\r", String.Empty);
            str = str.Replace("\t", String.Empty);
            load_file_or_dir(str);
        }
        private void txt_path_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }

        #endregion

        #region faftv
        
        #region functions

        private TreeNode faftv_CreateDirectoryNode(DirectoryInfo di)
        {
            TreeNode node_dir = new TreeNode() { Text = di.Name, Name = di.FullName };
            
            //GET DIRS
            foreach (DirectoryInfo directory in di.GetDirectories())
            {
                faftv_setImage("dir", node_dir);
                node_dir.Nodes.Add(faftv_CreateDirectoryNode(directory));
            }

            //GET FILES
            foreach (FileInfo file in di.GetFiles())
            {
                string ext = file.Extension.ToLower();
                if (ext != ".ini") //ignore desktop.ini
                {
                    TreeNode node_file = new TreeNode() { Text = file.Name, Name = file.FullName };
                    faftv_setImage(ext, node_file);
                    node_dir.Nodes.Add(node_file);
                }
            }

            return node_dir;
        }
        private void faftv_setImage(string ext, TreeNode node_file)
        {
            int num = 14; // default 14 = unknown file type

            switch (ext.ToLower())
            {
                case "dir":  num = 0; break;
                case ".exe": num = 1; break;
                case ".mp4":
                case ".wmv":
                case ".mkv":
                case ".mpeg":
                case ".mpg": num = 2; break;
                case ".webm":
                case ".avi":
                case ".mov": num = 3; break;
                case ".swf":
                case ".flv": num = 4; break;
                case ".gif": num = 5; break;
                case ".png":
                case ".svg":
                case ".ico": num = 6; break;
                case ".jpg":
                case ".jpeg":
                case ".jpe":
                case ".jiff":
                case ".jfif":
                case ".bmp":
                case ".dib":
                case ".tif":
                case ".tiff": num = 7; break;
                case ".mp3":
                case ".ogg":  num = 8; break;
                case ".html": num = 9; break;
                case ".lst":
                case ".webgrab_skip":
                case ".txt": num = 10; break;
                case ".bat": num = 11; break;
                case ".reg": num = 12; break;
            }

            node_file.ImageIndex = node_file.SelectedImageIndex = num;
        }

        private FileSystemWatcher faftv_watcher = new FileSystemWatcher();
        private void faftv_reload()
        {
            nestFiles();
            faftv.Nodes.Clear();
            txt_path.Text = GlobalVariables.Path.Dir.MainFolder;
            faftv.Nodes.Add(faftv_CreateDirectoryNode(new DirectoryInfo(GlobalVariables.Path.Dir.MainFolder)));

            if (faftv_watcher != null) { faftv_watcher.Dispose(); }
            faftv_watcher = new FileSystemWatcher()
            {
                NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName,
                Filter = "*.*",
                IncludeSubdirectories = true,
                Path = GlobalVariables.Path.Dir.MainFolder,
            };
            faftv_watcher.Changed += faftv_watcher_Changed;
            faftv_watcher.Created += faftv_watcher_Created;
            faftv_watcher.Deleted += faftv_watcher_Deleted;
            faftv_watcher.Renamed += faftv_watcher_Renamed;
            faftv_watcher.EnableRaisingEvents = true;
        }
        private void faftv_startFile(bool openDirs = false)
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }

            if (File.Exists(path))
            {
                if (new FileInfo(path).Name.Contains("fapmap_mod"))
                {
                    OpenScript(path, txt_path.Text, this);
                }
                else
                {
                    if (fapmap.Open(path))
                    {
                        media_remove(menu_cb_players_autoHide.Checked);
                    }
                }
            }
            else if (Directory.Exists(path) && openDirs)
            {
                fapmap.OpenInExplorer(path);
            }
        }
        private void faftv_delete()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }

            if (Directory.Exists(path))
            { if (fapmap.TrashDir(path)) { faftv.SelectedNode.Remove(); } }
            else if (File.Exists(path))
            {
                media_remove(menu_cb_players_autoHide.Checked);
                if (fapmap.TrashFile(path)) { faftv.SelectedNode.Remove(); }
            }
        }
        private void faftv_newFolder()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }
            
            if (File.Exists(path)) { path = Directory.GetParent(path).FullName; }
            if (!Directory.Exists(path)) { return; }

            string input = fapmap.OpenInputBox(this, "Create New Folder in: " + new DirectoryInfo(path).Name, "New Folder", 0, "New Folder".Length);
            if (!string.IsNullOrEmpty(input))
            {
                fapmap.CreateDir(new DirectoryInfo(path).FullName + "\\" + input);
            }
        }
        private void faftv_rename()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }
            
            if (File.Exists(path))
            {
                media_remove();

                FileInfo fi_src = new FileInfo(path);
                string input = fapmap.OpenInputBox(this, "Rename file?", fi_src.Name, 0, fi_src.Name.Length - fi_src.Extension.Length);
                if (!string.IsNullOrEmpty(input))
                {
                    fapmap.MoveFile(fi_src.FullName, fi_src.Directory.FullName + "\\" + input);
                }
            }
            else if (Directory.Exists(path))
            {
                if (path == fapmap.GlobalVariables.Path.Dir.MainFolder)
                {
                    MessageBox.Show("You can't rename \"Main Folder\"", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DirectoryInfo di_src = new DirectoryInfo(path);
                string input = fapmap.OpenInputBox(this, "Rename folder?", di_src.Name, 0, di_src.Name.Length);
                if (!string.IsNullOrEmpty(input))
                {
                    fapmap.MoveDir(di_src.FullName, di_src.Parent.FullName + "\\" + input);
                }
            }
        }
        private void faftv_properties()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }
            OpenProperties(path);
        }
        private void faftv_enter()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }

            if (Directory.Exists(path))
            {
                try
                {
                    if (faftv.SelectedNode.IsExpanded) { faftv.SelectedNode.Collapse(); }
                    else { faftv.SelectedNode.Expand(); }
                }
                catch (Exception) { }
            }
            else if (File.Exists(path))
            {
                load_file_or_dir(path);
            }
        }
        
        private void faftv_watcher_Changed(object sender, FileSystemEventArgs e)
        {
        }
        private void faftv_watcher_Created(object sender, FileSystemEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (File.Exists(e.FullPath))
                {
                    FileInfo fi = new FileInfo(e.FullPath);
                    foreach (TreeNode t in faftv.Nodes.Find(fi.Directory.FullName, true))
                    {
                        TreeNode newNode = new TreeNode() { Text = fi.Name, Name = fi.FullName };
                        faftv_setImage(fi.Extension, newNode);
                        t.Nodes.Add(newNode);
                    }
                }
                else if (Directory.Exists(e.FullPath))
                {
                    DirectoryInfo di = new DirectoryInfo(e.FullPath);
                    foreach (TreeNode t in faftv.Nodes.Find(di.Parent.FullName, true))
                    {
                        TreeNode newNode = new TreeNode() { Text = di.Name, Name = di.FullName };
                        faftv_setImage("dir", newNode);
                        t.Nodes.Add(newNode);
                    }
                }
            });
        }
        private void faftv_watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                foreach (TreeNode t in faftv.Nodes.Find(e.FullPath, true))
                {
                    t.Remove();
                }
            });
        }
        private void faftv_watcher_Renamed(object sender, FileSystemEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                faftv_update();
            });
        }

        // update treeview for changes
        private void checkNode(TreeNode tn)
        {
            if (tn == null) { return; }
            if (!File.Exists(tn.Name) && !Directory.Exists(tn.Name)) { tn.Remove(); }

            if (Directory.Exists(tn.Name))
            {
                foreach (string file in Directory.GetFiles(tn.Name))
                {
                    if (!tn.Nodes.ContainsKey(file))
                    {
                        TreeNode newNode = new TreeNode() { Text = Path.GetFileName(file), Name = file };
                        faftv_setImage(Path.GetExtension(file), newNode);
                        tn.Nodes.Add(newNode);
                    }
                }
                
                foreach (string dir in Directory.GetDirectories(tn.Name))
                {
                    if (!tn.Nodes.ContainsKey(dir))
                    {
                        TreeNode newNode = new TreeNode() { Text = new DirectoryInfo(dir).Name, Name = dir };
                        faftv_setImage("dir", newNode);
                        tn.Nodes.Add(newNode);
                    }
                }
            }

            foreach (TreeNode t in tn.Nodes) { checkNode(t); }
        }
        private void faftv_update()
        {
            foreach(TreeNode tn in faftv.Nodes)
            {
                checkNode(tn);
            }
        }

        #endregion

        #region ui events
        
        private bool faftv_isKeydown = false;
        private bool faftv_escapeDown = false;
        private void faftv_KeyDown(object sender, KeyEventArgs e)
        {
            faftv_isKeydown = true;

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A: OpenInExplorer(txt_path.Text); e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.R: faftv_reload();                e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.Q: faftv.CollapseAll();           e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.E: faftv.ExpandAll();             e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.W: faftv_startFile(true);         e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.D: faftv_properties();            e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.S: faftv_newFolder();             e.Handled = true; e.SuppressKeyPress = true; break;

                    // hidden shortcuts
                    case Keys.Z: this_hideOrShow();            e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.X: media_sw();                   e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.F: new fapmap_find().Show();     e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.G: new fapmap_settings().Show(); e.Handled = true; e.SuppressKeyPress = true; break;
                }
            }

            switch (e.KeyCode)
            {
                case Keys.Escape: media_remove(true); faftv_escapeDown = true; e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Enter:  faftv_enter();                               e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Delete: faftv_delete();                              e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.F5:     faftv_reload();                              e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.F2:     faftv_rename();                              e.Handled = true; e.SuppressKeyPress = true; break;
            }
        }
        private void faftv_KeyUp(object sender, KeyEventArgs e)
        {
            faftv_isKeydown = false;
            if (e.KeyCode == Keys.Escape) { faftv_escapeDown = false; return; }
            if (faftv_escapeDown) { return; }
            if (e.Shift || e.Control) { return; }
            faftv_AfterSelect(null, null);
        }
        private void faftv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }
            if (faftv_isKeydown) { return; }
            load_file_or_dir(path);
        }
        private void faftv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (menu_cb_fapmap_outside.Checked) { faftv_startFile(); }
        }

        #region drag n drop

        private void faftv_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = System.Windows.Forms.DragDropEffects.All;
        }
        private void faftv_DragDrop(object sender, DragEventArgs e)
        {
            string url = e.Data.GetData(DataFormats.StringFormat) as string;

            if (!string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                fapmap_download fd = new fapmap_download() { pass_path = txt_path.Text };
                fd.pass_URLs.Add(url);
                fd.Show();
                return;
            }
            
            foreach (string src in (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop, false))
            {
                string destDir = txt_path.Text;

                if (File.Exists(txt_path.Text)) { destDir = Directory.GetParent(txt_path.Text).FullName; }
                if (!Directory.Exists(txt_path.Text)) { destDir = GlobalVariables.Path.Dir.MainFolder; }
                if (Directory.Exists(txt_path.Text)) { destDir = new DirectoryInfo(txt_path.Text).FullName; }

                if (Directory.Exists(src)) { fapmap.CopyDir (src, destDir + "\\" + new DirectoryInfo(src).Name); }
                else if (File.Exists(src)) { fapmap.CopyFile(src, destDir + "\\" + new FileInfo     (src).Name); }
            }
        }

        #endregion

        #region RMB

        private void faftv_RMB_refresh_Click(object sender, EventArgs e)
        {
            faftv_reload();
        }
        private void faftv_RMB_collapseTree_Click(object sender, EventArgs e)
        {
            txt_path.Text = null;
            faftv.CollapseAll();
        }
        private void faftv_RMB_expandTree_Click(object sender, EventArgs e)
        {
            txt_path.Text = null;
            faftv.ExpandAll();
        }
        private void faftv_RMB_open_Click(object sender, EventArgs e)
        {
            faftv_startFile(true);
        }
        private void faftv_RMB_explorer_Click(object sender, EventArgs e)
        {
            OpenInExplorer(txt_path.Text);
        }
        private void faftv_RMB_rename_Click(object sender, EventArgs e)
        {
            faftv_rename();
        }
        private void faftv_RMB_newFolder_Click(object sender, EventArgs e)
        {
            faftv_newFolder();
        }
        private void faftv_RMB_delete_Click(object sender, EventArgs e)
        {
            faftv_delete();
        }
        private void faftv_RMB_properties_Click(object sender, EventArgs e)
        {
            faftv_properties();
        }

        #endregion

        #endregion

        #endregion

        #region links

        private void playURL(string link)
        {
            string url = link;

            if (isMediaFileUrl(url))
            {
                media_playUrl(url);
                return;
            }

            Incognito(url);
        }
        
        private void txt_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.Handled = true; e.SuppressKeyPress = true; }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                    case Keys.Enter: playURL(txt_url.Text); e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.S: links_add(txt_url.Text);        e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.Back:
                        {
                            txt_url.Text = fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL;

                            txt_url.SelectionStart = 0;
                            txt_url.SelectionLength = txt_url.Text.Length;

                            e.Handled = true;
                            e.SuppressKeyPress = true;
                            break;
                        }
                }
            }
        }
        
        private void btn_startURL_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { playURL(txt_url.Text); }
        }
        private void btn_openURL_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { Incognito(txt_url.Text); }
        }
        private void btn_saveURL_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { links_add(txt_url.Text); }
        }

        private void wb_btn_dragOut_DragOver(object sender, DragEventArgs e)
        {
            if (links.SelectedItems.Count == 0) { return; }
            e.Effect = DragDropEffects.Copy;
        }
        private void wb_btn_dragOut_MouseDown(object sender, MouseEventArgs e)
        {
            if (links.SelectedItems.Count == 0) { return; }

            string urls = string.Empty;
            foreach (ListViewItem lvi in links.SelectedItems)
            {
                if (lvi.Tag == null) { continue; }
                string text = lvi.Tag.ToString();
                if (string.IsNullOrEmpty(text)) { continue; }
                urls += text + Environment.NewLine;
            }

            this.links.DoDragDrop(new System.Windows.Forms.DataObject(System.Windows.Forms.DataFormats.StringFormat, urls), DragDropEffects.Copy);
        }

        #region functions

        private string links_filePath = string.Empty;
        private Color links_color_normal = Color.Teal;
        private Color links_color_comment = Color.DarkSlateBlue;
        
        private void links_reload(string path)
        {
            nestFiles();

            // set global path
            links_filePath = path;

            //REMOVE NULL LINES
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    foreach (string line in SafeReadLines(path))
                    {
                        if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line) && line != "")
                        { tw.WriteLine(line); }
                    }
                    tw.Flush(); fs.SetLength(fs.Position);
                }
            }

            //CLEAR
            favicons.Images.Clear();
            links.Items.Clear();

            List<string> lines = System.IO.File.ReadAllLines(path).ToList();
            List<ListViewItem> items = new List<ListViewItem>();
            int index = -1;
            
            bool noIcons = false;
            List<string> icons = new List<string>();
            if (Directory.Exists(fapmap.GlobalVariables.Path.Dir.FavIcons))
            { icons.AddRange(Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.FavIcons)); }
            if (icons.Count == 0) { noIcons = true; }

            foreach (string url in lines)
            {
                //MAKE ITEM
                index++;
                string number = (index + 1).ToString();
                ListViewItem lvi = new ListViewItem(new string[] { number, url, "" })
                {
                    Tag = url,
                    ImageKey = index.ToString(),
                    ForeColor = url.StartsWith(GlobalVariables.Settings.Common.Comment) ? links_color_comment : links_color_normal
                };

                if (!noIcons)
                {
                    favicons.Images.Add(index.ToString(), ((Func<Image>)(() => {

                        foreach (string icon in icons)
                        {
                            if (url.Contains(Path.GetFileNameWithoutExtension(icon)))
                                return Image.FromFile(icon);
                        }

                        foreach (string icon in icons)
                        {
                            if (new System.Globalization.CultureInfo("").CompareInfo.IndexOf(url, Path.GetFileNameWithoutExtension(icon), System.Globalization.CompareOptions.IgnoreCase) >= 0)
                                return Image.FromFile(icon);
                        }

                        return new Bitmap(16, 16);
                    }))());
                }

                items.Add(lvi);
            }

            links.Items.AddRange(items.ToArray());
            
            //auto resize
            foreach (ColumnHeader column in links.Columns) { column.Width = -2; }
        }
        private void links_add(string url)
        {
            // check url
            if (url == "") { return; }
            if (string.IsNullOrEmpty(url)) { return; }
            if (string.IsNullOrWhiteSpace(url)) { return; }
            foreach (ListViewItem a in links.Items) { if (a.Tag.ToString() == url) { this.Text = "FAPMAP: Link already exists: " + url; return; } }
            
            // add url to file
            using (TextWriter tw = new StreamWriter(links_filePath, true)) { tw.WriteLine(url); }

            int index = links.Items.Count;

            ListViewItem lvi = new ListViewItem(new string[] { (links.Items.Count + 1).ToString(), url, "" })
            {
                Tag = url,
                ImageKey = index.ToString(),
                ForeColor = url.StartsWith(GlobalVariables.Settings.Common.Comment) ? links_color_comment : links_color_normal
            };

            //ADD ITEM
            links.Items.Add(lvi);
            
            bool noIcons = false;
            List<string> icons = new List<string>();
            if (Directory.Exists(fapmap.GlobalVariables.Path.Dir.FavIcons))
            { icons.AddRange(Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.FavIcons)); }
            if (icons.Count == 0) { noIcons = true; }

            if (!noIcons)
            {
                favicons.Images.Add(index.ToString(), ((Func<Image>)(() => {

                    foreach (string icon in icons)
                    {
                        if (url.Contains(Path.GetFileNameWithoutExtension(icon)))
                            return Image.FromFile(icon);
                    }

                    foreach (string icon in icons)
                    {
                        if (new System.Globalization.CultureInfo("").CompareInfo.IndexOf(url, Path.GetFileNameWithoutExtension(icon), System.Globalization.CompareOptions.IgnoreCase) >= 0)
                            return Image.FromFile(icon);
                    }

                    return new Bitmap(16, 16);
                }))());
            }
            
            new Thread(() =>
            {
                links.Items[index].SubItems[2].Text = get_html_title(links.Items[index].Tag.ToString());
                foreach (ColumnHeader column in links.Columns) { column.Width = -2; }
            })
            { IsBackground = true }.Start();

            //SCROLL
            links.Items[links.Items.Count - 1].EnsureVisible();

            //auto resize
            foreach (ColumnHeader column in links.Columns) { column.Width = -2; }
        }
        private void links_start()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Tag == null) { continue; }
                string text = item.Tag.ToString();
                if (string.IsNullOrEmpty(text)) { continue; }
                if (!text.StartsWith(GlobalVariables.Settings.Common.Comment)) { playURL(text); }
            }
        }
        private void links_reloadTitle()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                new Thread(() =>
                {
                    string backup = item.SubItems[2].Text;
                    item.SubItems[2].Text = "reloading...";
                    string title = get_html_title(item.Tag.ToString());
                    if (title == "...") { item.SubItems[2].Text = backup; }
                    else { item.SubItems[2].Text = title; }
                    foreach (ColumnHeader column in links.Columns) { column.Width = -2; }
                })
                { IsBackground = true }.Start();
            }
        }
        private void links_incognito()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Tag == null) { continue; }
                string text = item.Tag.ToString();
                if (string.IsNullOrEmpty(text)) { continue; }
                if (!text.StartsWith(GlobalVariables.Settings.Common.Comment)) { Incognito(text); }
            }
        }
        private void links_download()
        {
            fapmap_download fd = new fapmap_download() { pass_path = txt_path.Text };
            foreach (ListViewItem item in links.SelectedItems)
            {
                fd.pass_URLs.Add(item.Tag.ToString());
            }
            fd.Show();
        }
        private void links_webgrab()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Tag == null) { continue; }
                string text = item.Tag.ToString();
                if (string.IsNullOrEmpty(text)) { continue; }
                new fapmap_download() { pass_path = txt_path.Text, pass_webgrabURL = text }.Show();
            }
        }
        private void links_youtubedl()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Tag == null) { continue; }
                string text = item.Tag.ToString();
                if (string.IsNullOrEmpty(text)) { continue; }
                new fapmap_youtubedl() { pass_path = txt_path.Text, pass_url = text }.Show();
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
            links_add(Clipboard.GetText());
        }
        private void links_del()
        {
            string file = GlobalVariables.Path.File.Links;
            if (links_filePath != string.Empty) { file = links_filePath; }

            foreach (ListViewItem item in links.SelectedItems)
            {
                string line = null;
                string line_to_delete = item.Tag.ToString();

                using (StreamReader reader = new StreamReader(file))
                {
                    using (StreamWriter writer = new StreamWriter(GlobalVariables.Path.Dir.Main + "\\links_inuse.dll"))
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
                File.Replace(GlobalVariables.Path.Dir.Main + "\\links_inuse.dll", file, null);
                LogThis(fapmap.GlobalVariables.LOG_TYPE.UDEL, line_to_delete);
            }
        }
        private void links_comment()
        {
            string file = GlobalVariables.Path.File.Links;
            if (links_filePath != string.Empty) { file = links_filePath; }

            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Tag == null) { continue; }
                string text = item.Tag.ToString();
                if (string.IsNullOrEmpty(text)) { continue; }
                if (text.StartsWith(GlobalVariables.Settings.Common.Comment)) { continue; }

                string[] lines = fapmap.SafeReadLines(file);

                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    using (TextWriter tw = new StreamWriter(fs))
                    {
                        foreach (string line in lines)
                        {
                            tw.WriteLine(line == text ? GlobalVariables.Settings.Common.Comment + " " + text : line);
                        }
                        
                        tw.Flush();
                        fs.SetLength(fs.Position);
                    }
                }
                
                item.ForeColor = links_color_comment;
                item.SubItems[1].Text = GlobalVariables.Settings.Common.Comment + " " + text;
                item.Tag = GlobalVariables.Settings.Common.Comment + " " + text;
            }
            
            foreach (ColumnHeader column in links.Columns) { column.Width = -2; }
        }
        private void links_unComment()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Tag == null) { continue; }
                string text = item.Tag.ToString();
                if (string.IsNullOrEmpty(text)) { continue; }

                string replaceText = string.Empty;
                if (text.StartsWith(GlobalVariables.Settings.Common.Comment + " "))
                {
                    replaceText = text.Remove(0, (GlobalVariables.Settings.Common.Comment + " ").Length);
                }
                else if (text.StartsWith(GlobalVariables.Settings.Common.Comment))
                {
                    replaceText = text.Remove(0, (GlobalVariables.Settings.Common.Comment).Length);
                }
                else
                {
                    continue;
                }

                string[] lines = fapmap.SafeReadLines(links_filePath);

                using (FileStream fs = new FileStream(links_filePath, FileMode.Open))
                {
                    using (TextWriter tw = new StreamWriter(fs))
                    {
                        foreach (string line in lines)
                        {
                            tw.WriteLine(line == text ? replaceText : line);
                        }
                        tw.Flush();
                        fs.SetLength(fs.Position);
                    }
                }
                
                item.ForeColor = links_color_normal;
                item.SubItems[1].Text = replaceText;
                item.Tag = replaceText;
            }

            foreach (ColumnHeader column in links.Columns) { column.Width = -2; }
        }
        private void links_edit()
        {
            nestFiles();
            fapmap.OpenInNotepad(links_filePath);
        }
        private void links_find()
        {
            string input = fapmap.OpenInputBox(this, "Find:", "", 0, 0);
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
            }
        }
        private void links_selectAll()
        {
            foreach (ListViewItem lvi in links.Items) { lvi.Selected = true; }
        }

        #endregion

        #region ui events
        
        private void links_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                links_start();
            }
        }
        private void links_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter: e.SuppressKeyPress = true; links_start(); break;
                case Keys.Delete: links_del(); break;
                case Keys.F5: links_reload(GlobalVariables.Path.File.Links); break;
            }
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A: links_selectAll(); break;
                    case Keys.R: links_reload(GlobalVariables.Path.File.Links); break;
                    case Keys.S: links_reloadTitle(); break;
                    case Keys.W: links_incognito(); break;
                    case Keys.Q: links_comment(); break;
                    case Keys.T: links_unComment(); break;
                    case Keys.D: if (e.Shift) { links_webgrab(); } else { links_download(); } break;
                    case Keys.Y: links_youtubedl(); break;
                    case Keys.F: links_find(); break;
                    case Keys.B: new fapmap_board().Show(); break;
                    case Keys.C: links_copy(); break;
                    case Keys.X: links_copy(); links_del(); break;
                    case Keys.V: links_paste(); break;
                    case Keys.E: links_edit(); break;
                }
            }


        }

        #region drag n drop

        private void txt_url_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }
        private void txt_url_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string stringData = e.Data.GetData(typeof(string)) as string;
            txt_url.Text = stringData;
        }

        private void links_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
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
        private void links_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            try
            {
                string stringData = e.Data.GetData(typeof(string)) as string;
                links_add(stringData);
            }
            catch (Exception) { }
        }
        
        #endregion

        #region RMB

        private void links_RMB_refresh_Click(object sender, EventArgs e)
        {
            links_reload(GlobalVariables.Path.File.Links);
        }
        private void links_RMB_open_Click(object sender, EventArgs e)
        {
            links_start();
        }
        private void links_RMB_incognito_Click(object sender, EventArgs e)
        {
            links_incognito();
        }
        private void links_RMB_commentOut_Click(object sender, EventArgs e)
        {
            links_comment();
        }
        private void links_RMB_uncomment_Click(object sender, EventArgs e)
        {
            links_unComment();
        }
        private void links_RMB_copy_Click(object sender, EventArgs e)
        {
            links_copy();
        }
        private void links_RMB_cut_Click(object sender, EventArgs e)
        {
            links_copy();
            links_del();
        }
        private void links_RMB_paste_Click(object sender, EventArgs e)
        {
            links_paste();
        }
        private void links_RMB_delete_Click(object sender, EventArgs e)
        {
            links_del();
        }
        private void links_RMB_find_Click(object sender, EventArgs e)
        {
            links_find();
        }
        private void links_RMB_reloadTitle_Click(object sender, EventArgs e)
        {
            links_reloadTitle();
        }
        private void links_RMB_edit_Click(object sender, EventArgs e)
        {
            links_edit();
        }
        private void links_RMB_download_Click(object sender, EventArgs e)
        {
            links_download();
        }
        private void links_RMB_webgrab_Click(object sender, EventArgs e)
        {
            links_webgrab();
        }
        private void links_RMB_youtubedl_Click(object sender, EventArgs e)
        {
            links_youtubedl();
        }
        private void links_RMB_urlBoard_Click(object sender, EventArgs e)
        {
            new fapmap_board().Show();
        }

        #endregion

        #endregion

        #endregion

        // clean this junky code below
        #region video - playlist

        private void showMedia_video_fit_CheckedChanged(object sender, EventArgs e)
        {
            showMedia_video.stretchToFit = showMedia_video_fit.Checked;
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
            showMedia_video_undo.BackgroundImage = Properties.Resources.restart;

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
                showMedia_video_undo.BackgroundImage = Properties.Resources.arrow_left;

                if (File.Exists(path)) { path = Directory.GetParent(path).ToString(); }

                //ECHO
                //this.Text = "FAPMAP: Playlist[...]";

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
                    MessageBox.Show("No video files found...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("No video files found...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    video_playList_disable();
                    return;
                }

                //no logged files
                if (nologs)
                {
                    string[] log_lines = fapmap.SafeReadLines(GlobalVariables.Path.File.Log);
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
                    MessageBox.Show("No video files found...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //this.Text = "FAPMAP: Playlist[" + (video_playlist_current + 1).ToString() + "/" + video_playlist.Count + "]";
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

        

        private void showMedia_video_RMB_playList_make_CheckedChanged(object sender, EventArgs e)
        {
            if (showMedia_video_RMB_playList_make.Checked)
            {
                fapmap_playlist fp = new fapmap_playlist() { path = txt_path.Text };

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
                              + "Create a playlist first...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            string input = fapmap.OpenInputBox(this, "Enter a number to go to:", "", 0, 0);
            if (!string.IsNullOrEmpty(input))
            {
                if (!int.TryParse(input, out int input_)) { MessageBox.Show("Not a number: " + input, "Playlist - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else { playlist_update(input_ > 0 ? input_ : 0); }
            }
        }
        
        #endregion
        
    }
}
