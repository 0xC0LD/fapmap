﻿using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WMPLib;

namespace fapmap
{
    public partial class fapmap : Form
    {
        #region main()

        public fapmap()
        {
            InitializeComponent();

            // menu
            menu.Renderer = new fapmap_res.FapMapColors.FapMapToolStripRenderer(Color.FromArgb(128, 128, 255));
            menu.Cursor = Cursors.Arrow;

            // rmb
            links_RMB.Renderer = new fapmap_res.FapMapColors.FapMapToolStripRenderer(Color.Turquoise);
            faftv_RMB.Renderer = new fapmap_res.FapMapColors.FapMapToolStripRenderer(Color.HotPink);
            fileDisplay_RMB.Renderer = new fapmap_res.FapMapColors.FapMapToolStripRenderer(Color.HotPink);
            showMedia_video_RMB.Renderer = new fapmap_res.FapMapColors.FapMapToolStripRenderer(Color.FromArgb(128, 128, 255));
            showMedia_image_RMB.Renderer = new fapmap_res.FapMapColors.FapMapToolStripRenderer(Color.FromArgb(128, 128, 255));

            fapmap_res.MouseDetector m = new fapmap_res.MouseDetector();
            m.MouseMove += new fapmap_res.MouseDetector.MouseMoveDLG(this_MouseMove);
        }

        private void this_MouseMove(object sender, Point p)
        {
            if (!GlobalVariables.Settings.CheckBoxes.InvisibleWindow) { return; }

            Point pt = this.PointToClient(p);
            bool isIn = (this.ClientSize.Width >= pt.X &&
                         this.ClientSize.Height >= pt.Y &&
                         pt.X > 0 && pt.Y > 0);

            if (isIn && this.Opacity == 0.20f) { this.Opacity = 1.0f; }
            else if (!isIn && this.Opacity == 1.0f) { this.Opacity = 0.20f; }
        }

        public class GlobalVariables
        {
            public class FileTypes
            {
                //CONST FILE TYPES
                public static readonly IList<string> Video = new ReadOnlyCollection<string>(new[] { ".mp4", ".webm", ".avi", ".mov", ".mkv", ".flv", ".mpeg", ".mpg", ".wmv", ".mp3", ".ogg" });
                public static readonly IList<string> Image = new ReadOnlyCollection<string>(new[] { ".jpg", ".jpeg", ".jiff", ".jfif", ".png", ".gif", ".ico", ".svg", ".bmp", ".dib", ".tif", ".tiff" });
                public static readonly IList<string> Other = new ReadOnlyCollection<string>(new[] { ".zip", ".rar", ".exe", ".bat", ".swf", ".dll", ".txt" });
            }

            public class Settings
            {
                public class Common
                {
                    public const char Equal = '=';
                    public const char Split = '|';
                    public const string Comment = "#";
                    public const string Comment2 = "//";
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
                        public static List<string> Video = new List<string> { };
                        public const string Video_ = "types_video";

                        public static List<string> Image = new List<string> { };
                        public const string Image_ = "types_image";
                    }
                }

                public class CheckBoxes /// if a setting has a '*' it needs to be added
                {
                    // hide
                    public static bool HideOnX = false; public const string HideOnX_ = "hideOnX";
                    public static bool FocusHide = false; public const string FocusHide_ = "hideOnLostFocus";
                    public static bool InvisibleWindow = false; public const string InvisibleWindow_ = "invisibleWindow";

                    // enable
                    public static bool EnableLogs = true; public const string EnableLogs_ = "enable_logs";
                    public static bool EnableMediaPlayers = true; public const string EnableMediaPlayers_ = "enable_mediaPlayers";
                    public static bool EnableTrackbarForGifViewer = true; public const string EnableTrackbarForGifViewer_ = "enable_trackBar";
                    public static bool EnableFileDisplay = true; public const string EnableFileDisplay_ = "enable_fileDisplay";
                    public static bool EnableFaftv = true; public const string EnableFaftv_ = "enable_treeView";
                    public static bool EnableOpenOutsideFapmap = false; public const string EnableOpenOutsideFapmap_ = "enable_openOutsideFapmap";

                    // players
                    public static bool AutoHideMediaPlayers = true; public const string AutoHideMediaPlayers_ = "audo_hideMediaPlayers";
                    public static bool AutoPlayVideoPlayer = true; public const string AutoPlayVideoPlayer_ = "auto_playVideoPlayer";
                    public static bool AutoPauseVideoPlayer = true; public const string AutoPauseVideoPlayer_ = "auto_pauseVideoPlayer";

                    // faftv
                    public static bool TreeViewSortByCreationDate = true; public const string TreeViewSortByCreationDate_ = "treeView_sortByDate";
                    public static bool TreeViewShowItemIndex = false; public const string TreeViewShowItemIndex_ = "treeView_showItemIndex";

                    // fileDisplay
                    public static bool FileDisplaySortByCreationDate = true; public const string FileDisplaySortByCreationDate_ = "fileDisplay_sortByDate";
                    public static bool FileDisplayShowThumbnails = true; public const string FileDisplayShowThumbnails_ = "fileDisplay_showThumbnails";

                    // links
                    public static bool LinksGetSiteTitle = true; public const string LinksGetSiteTitle_ = "links_getSiteTitle";
                    public static bool LinksGetSiteFavicon = true; public const string LinksGetSiteFavicon_ = "links_getSiteFavicon"; /// *

                    // downloader
                    public static bool DownloaderAutoClose = true; public const string DownloaderAutoClose_ = "downloader_autoCloseWhenItemPassed";
                    public static bool DownloaderAutoRetry = false; public const string DownloaderAutoRetry_ = "downloader_autoRetry"; /// *

                    // finder
                    public static bool FinderShowImage = true; public const string FinderShowImage_ = "finder_showImage"; /// *
                    public static bool FinderShowImageIcon = true; public const string FinderShowImageIcon_ = "finder_showImageIcon"; /// *
                    public static bool FinderCaseSensitive = false; public const string FinderCaseSensitive_ = "finder_caseSensitive"; /// *
                    public static bool FinderSortByCreationDate = true; public const string FinderSortByCreationDate_ = "finder_sortByDate"; /// *
                    public static bool FinderJustPrintFilename = false; public const string FinderJustPrintFilename_ = "finder_justPrintFilename"; /// *
                }

                public class Other
                {
                    public static List<string> AutoCompleteLines = new List<string>();
                    public static List<string> WebGrabTableLines = new List<string>(); public const string WebGrabTableLines_ = "wgtl";
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
                    public static string Cache = DataFolder + "\\cache";
                }

                public class File
                {
                    public static string Passwords = Path.Dir.DataFolder + "\\passwords.dll";
                    public static string Links = Path.Dir.DataFolder + "\\urls.txt";
                    public static string Settings = Path.Dir.DataFolder + "\\fapmap.ini";
                    public static string Board = Path.Dir.DataFolder + "\\board.txt";
                    public static string Keywords = Path.Dir.DataFolder + "\\keywords.lst";
                    public static string Log = Path.Dir.Cache + "\\fapmap.log";

                    public class Exe
                    {
                        public static string FFMPEG = Path.Dir.Main + "\\ffmpeg.exe";
                        public static string FFPROBE = Path.Dir.Main + "\\ffprobe.exe";
                        public static string WEBGRAB = Path.Dir.Main + "\\webgrab.exe";
                        public static string YOUTUBEDL = Path.Dir.Main + "\\youtube-dl.exe";
                        public static string FSCAN = Path.Dir.Main + "\\fscan.exe";
                        public static string CRASHHANDLER = Path.Dir.Main + "\\CrashHandler.exe";
                    }
                }
            }

            public class LOG_TYPE
            {
                public const string OPEN = "OPEN"; public static readonly Color OPEN_ = Color.Gold;
                public const string PLAY = "PLAY"; public static readonly Color PLAY_ = Color.Lime;
                public const string EXEC = "EXEC"; public static readonly Color EXEC_ = Color.YellowGreen;

                public const string MOVE = "MOVE"; public static readonly Color MOVE_ = Color.Yellow;
                public const string COPY = "COPY"; public static readonly Color COPY_ = Color.PaleGreen;
                public const string RENM = "RENM"; public static readonly Color RENM_ = Color.SteelBlue;
                public const string MKDR = "MKDR"; public static readonly Color MKDR_ = Color.CadetBlue;
                public const string MKFL = "MKFL"; public static readonly Color MKFL_ = Color.DodgerBlue;
                public const string RMVD = "RMVD"; public static readonly Color RMVD_ = Color.Crimson;

                public const string DING = "DING"; public static readonly Color DING_ = Color.LightGreen;
                public const string DLED = "DLED"; public static readonly Color DLED_ = Color.SpringGreen;

                public const string NTFD = "404E"; public static readonly Color NTFD_ = Color.PaleVioletRed;
                public const string FAIL = "FAIL"; public static readonly Color FAIL_ = Color.Magenta;
                public const string UDEL = "UDEL"; public static readonly Color UDEL_ = Color.Tomato;
                public const string PASS = "PASS"; public static readonly Color PASS_ = Color.LightSalmon;
            }

            public class BooruSearchMD5
            {
                public const string API = @"https://cure.ninja/booru/api/json/md5/";
                public const string rule34xxx = @"https://rule34.xxx/index.php?page=post&s=list&tags=md5%3a";
                public const string gelbooru = @"https://www.gelbooru.com/index.php?page=post&s=list&tags=md5%3a";
                public const string danbooru = @"https://danbooru.donmai.us/posts?tags=md5%3A";
                public const string xbooru = @"https://xbooru.com/index.php?page=post&s=list&tags=md5%3a";
                public const string yandere = @"https://yande.re/post?tags=md5%3A";
            }

            public class CreditsImageUrls
            {
                public const string web_img_url_0 = "https://yt3.ggpht.com/-MpInHIQi5kQ/AAAAAAAAAAI/AAAAAAAAAOo/uMD40-lPnJk/s288-mo-c-c0xffffffff-rj-k-no/photo.jpg";
                public const string web_img_url_1 = "https://yt3.ggpht.com/-wmTdd-ozcCw/AAAAAAAAAAI/AAAAAAAAAAA/Jab5AL6CxZ4/s288-mo-c-c0xffffffff-rj-k-no/photo.jpg";
                public const string web_img_url_2 = "https://yt3.ggpht.com/-Cz0f2loHk5E/AAAAAAAAAAI/AAAAAAAAAAA/j6ZFt-9xPiA/s288-mo-c-c0xffffffff-rj-k-no/photo.jpg";
                public const string web_img_url_3 = "https://yt3.ggpht.com/-iAD_RVsx1I0/AAAAAAAAAAI/AAAAAAAAAAA/aEojIbiyYlA/s288-mo-c-c0xffffffff-rj-k-no/photo.jpg";
            }
        }

        public static bool this_selected = false;
        private void fapmap_Load(object sender, EventArgs e)
        {
            nestFiles();

            settings_load();
            settings_apply();

            changeMainTabs();
            this.ActiveControl = menu;

            CrashHandler_start();

            load_file_or_dir(GlobalVariables.Path.Dir.MainFolder);
            faftv_reload();
            links_reload(GlobalVariables.Path.File.Links);
        }

        #endregion

        #region Main Window Events

        private void fapmap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GlobalVariables.Settings.CheckBoxes.HideOnX)
            {
                this_hideOrShow(ChangeWindowStateTo.Hidden);
                e.Cancel = true;
            }
            else
            {
                Quit();
            }
        }
        private void fapmap_Activated(object sender, EventArgs e)
        {
            this_selected = true;

            if (GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer && (showMedia_video.playState == WMPPlayState.wmppsPaused || showMedia_video.playState == WMPPlayState.wmppsReady))
            {
                showMedia_video.Ctlcontrols.play();
            }
        }
        private void fapmap_Deactivate(object sender, EventArgs e)
        {
            this_selected = false;

            if (GlobalVariables.Settings.CheckBoxes.FocusHide) { this_hideOrShow(ChangeWindowStateTo.Hidden); return; }

            if (GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer && showMedia_video.playState == WMPPlayState.wmppsPlaying)
            { showMedia_video.Ctlcontrols.pause(); return; }
        }
        private void fapmap_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized
             && GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer
             && showMedia_video.playState == WMPPlayState.wmppsPlaying
            ) { showMedia_video.Ctlcontrols.pause(); }
        }
        private void Quit()
        {
            try
            {
                CrashHandler_stop();
                this_trayicon.Dispose();
                System.Environment.Exit(0);
            }
            catch (Exception) { }

        }

        private enum ChangeWindowStateTo
        {
            Normal,
            Hidden,
            Switch
        }
        private void this_hideOrShow(ChangeWindowStateTo windowState = ChangeWindowStateTo.Switch)
        {
            DoChangeWindowState:
            switch (windowState)
            {
                case ChangeWindowStateTo.Normal:
                    {
                        this.Show();
                        this.Icon = Properties.Resources.fapmap_mediumblue;
                        this.this_trayicon.Icon = Properties.Resources.fapmap_purple;
                        if (this.WindowState == FormWindowState.Minimized) { this.WindowState = FormWindowState.Normal; }
                        this.BringToFront();
                        this.Focus();
                        break;
                    }
                case ChangeWindowStateTo.Hidden:
                    {
                        showMedia_video.Ctlcontrols.pause();
                        this.Icon = Properties.Resources.fapmap_silver;
                        this.this_trayicon.Icon = Properties.Resources.fapmap_silver;
                        this.Hide();
                        break;
                    }
                case ChangeWindowStateTo.Switch:
                    {
                        windowState = this.Visible ? ChangeWindowStateTo.Hidden : ChangeWindowStateTo.Normal;
                        goto DoChangeWindowState;
                    }
            }
        }
        private void this_trayicon_MouseUp(object sender, MouseEventArgs e)
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

        #endregion

        #region Global Functions

        #region DO

        public enum attrib_args
        {
            unhide,
            normal,
            full
        }
        public static bool attrib(attrib_args arg)
        {
            string args = "";
            switch (arg)
            {
                case attrib_args.unhide: args = "-s -h /d /s"; break;
                case attrib_args.normal: args = "-s +h /d /s"; break;
                case attrib_args.full:   args = "+s +h /d /s"; break;
                default: return false;
            }

            string log = "attrib.exe " + args;
            LogThis(GlobalVariables.LOG_TYPE.EXEC, log);

            try
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "attrib.exe";
                cmd.StartInfo.WorkingDirectory = fapmap.GlobalVariables.Path.Dir.Main;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.StartInfo.Arguments = args;
                cmd.Start();
                cmd.WaitForExit();

                // hide windows files
                Process cmd2 = new Process();
                cmd2.StartInfo.FileName = "attrib.exe";
                cmd2.StartInfo.WorkingDirectory = fapmap.GlobalVariables.Path.Dir.Main;
                cmd2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd2.StartInfo.Arguments = "+s +h /d /s desktop.ini";
                cmd2.Start();
                cmd2.WaitForExit();
            }
            catch (Win32Exception e) { LogThis(GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + log); return false; }
            catch (InvalidOperationException e) { LogThis(GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + log); return false; }
            catch (Exception e) { LogThis(GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + log); return false; }
            return true;
        }

        public static bool makeThumb(string file, string dest)
        {
            if (!File.Exists(GlobalVariables.Path.File.Exe.FFMPEG)) { return false; }

            // mjpeg or bmp
            string args = "-itsoffset -1  -i " + '"' + file + '"' + " -vcodec mjpeg -vframes 1 -an -f rawvideo " + '"' + dest + '"';
            string log = GlobalVariables.Path.File.Exe.FFMPEG + " " + args;

            try
            {
                Process ffmpeg = new Process();
                ffmpeg.StartInfo.UseShellExecute = false;
                ffmpeg.StartInfo.CreateNoWindow = true;
                ffmpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ffmpeg.StartInfo.FileName = GlobalVariables.Path.File.Exe.FFMPEG;
                ffmpeg.StartInfo.Arguments = args;
                ffmpeg.Start();
                ffmpeg.WaitForExit();
            }
            catch (Win32Exception e) { LogThis(GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + log); return false; }
            catch (InvalidOperationException e) { LogThis(GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + log); return false; }
            catch (Exception e) { LogThis(GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + log); return false; }

            // ffmpeg failed
            if (!File.Exists(dest)) { LogThis(GlobalVariables.LOG_TYPE.FAIL, "THUMB: " + file + " -> " + dest); return false; }
            if (new FileInfo(dest).Length == 0) { LogThis(GlobalVariables.LOG_TYPE.FAIL, "THUMB: " + file + " -> " + dest); File.Delete(dest); return false; }

            return true;
        }

        public static bool downloadFavicon(string url, out string faviconPath)
        {
            faviconPath = "";
            if (string.IsNullOrEmpty(url)) { return false; }
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute)) { return false; }

            Uri uri = new Uri(url);
            string host = uri.Host;
            string faviconUrl = "http://" + host + "/favicon.ico";

            faviconPath = GlobalVariables.Path.Dir.FavIcons + "\\" + host + ".ico";
            if (File.Exists(faviconPath)) { return true; }

            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.Headers.Add("user-agent", "fapmap.exe");
                wc.DownloadFile(faviconUrl, faviconPath);
            }
            catch (Exception) { goto fail; }

            if (File.Exists(faviconPath))
            {
                FileInfo fi = new FileInfo(faviconPath);
                if (fi.Length == 0) { fi.Delete(); goto fail; }

                // check if the file is an image
                try
                {
                    Image img = fapmap_res.ImageFast.FromFile(fi.FullName);
                    img.Dispose();
                    return true;
                }
                catch (Exception) { fi.Delete(); goto fail; }
            }

        fail:
            Properties.Resources.browser.Save(faviconPath, ImageFormat.Icon);
            return true;
        }

        public static string OpenPathSelector(IWin32Window th, string selectPath = "")
        {
            string ret = string.Empty;
            fapmap_dirSelect fp = new fapmap_dirSelect() { preSelectedPath = selectPath };
            if (fp.ShowDialog(th) == DialogResult.OK)
            {
                ret = fp.outPath;
            }
            fp.Dispose();
            return ret;
        }
        public static bool OpenPathSelectorTXT(IWin32Window th, TextBox txt, bool addBackslashAtTheEnd, string selectPath = "")
        {
            string str = OpenPathSelector(th, selectPath);
            if (!string.IsNullOrEmpty(str))
            {
                txt.Text = str + (addBackslashAtTheEnd ? "\\" : "");
                return true;
            }
            return false;
        }
        public static bool OpenProperties(string fileOrDirPath)
        {
            if (string.IsNullOrEmpty(fileOrDirPath)) { return false; }
            new fapmap_info() { pass_path = fileOrDirPath }.Show();
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

        public static DialogResult OpenFileExistsDialog(IWin32Window t, string filePath_)
        {
            fapmap_fileExistsDialog fi = new fapmap_fileExistsDialog() { filePath = filePath_ };
            DialogResult dr = fi.ShowDialog(t);
            fi.Dispose();
            return dr;
        }

        public static bool Open(string path)
        {
            try { Process.Start(new ProcessStartInfo { FileName = path, WorkingDirectory = Directory.GetParent(path).FullName }); }
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
        public static void OpenScript(IWin32Window owner, string file)
        {
            if (!File.Exists(file))
            {
                fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.NTFD, file);
                return;
            }

            string input = fapmap.OpenInputBox(owner, "Arguments:", "", 0, 0);
            if (!string.IsNullOrEmpty(input))
            {
                FileInfo fi = new FileInfo(file);
                string workingDir = fi.Directory.FullName;
                workingDir = OpenPathSelector(owner, workingDir);

                // SCRIPT
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
        public static bool Incognito(string url = "")
        {
            if (!string.IsNullOrEmpty(url) && !Uri.IsWellFormedUriString(url, UriKind.Absolute)) { url = "https://duckduckgo.com/?q=" + System.Web.HttpUtility.UrlEncode(url); }

            try
            {
                Process.Start(GlobalVariables.Settings.WebBrowser.Browser, GlobalVariables.Settings.WebBrowser.BrowserArguments + " \"" + url + "\"");
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
        public static bool OpenInBrowser(string filePath)
        {
            try
            {
                Process.Start(GlobalVariables.Settings.WebBrowser.Browser, GlobalVariables.Settings.WebBrowser.BrowserArguments + " \"" + filePath + "\"");
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

            LogThis(fapmap.GlobalVariables.LOG_TYPE.EXEC, GlobalVariables.Settings.WebBrowser.Browser + " " + GlobalVariables.Settings.WebBrowser.BrowserArguments + " " + filePath);
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

            if (src == fapmap.GlobalVariables.Path.Dir.MainFolder)
            {
                MessageBox.Show("You can't move \"Main Folder\"", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static bool TrashFile(string filePath, Microsoft.VisualBasic.FileIO.UIOption DialogOption = Microsoft.VisualBasic.FileIO.UIOption.AllDialogs)
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
                    DialogOption,
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
        public static int TrashFiles(List<string> files)
        {
            if (files.Count == 0) { return 0; }

            int count = 0;
            foreach (string file in files)
            {
                if (TrashFile(file, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs)) { count++; }
            }

            return count;
        }

        public static bool TrashDir(string dirPath, Microsoft.VisualBasic.FileIO.UIOption DialogOption = Microsoft.VisualBasic.FileIO.UIOption.AllDialogs)
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
                    DialogOption,
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
        public static int TrashDirs(List<string> dirs)
        {
            if (dirs.Count == 0) { return 0; }

            int count = 0;
            foreach (string dir in dirs)
            {
                if (TrashDir(dir, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs)) { count++; }
            }

            return count;
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
        public static bool CreateFile(string path)
        {
            if (File.Exists(path)) { return false; }

            try
            {
                using (File.Create(path)) { }
            }
            catch (UnauthorizedAccessException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (ArgumentNullException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (ArgumentException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (PathTooLongException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (DirectoryNotFoundException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (NotSupportedException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (IOException e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }
            catch (Exception e) { fapmap.LogThis(fapmap.GlobalVariables.LOG_TYPE.FAIL, e.Message + " : " + path); return false; }

            LogThis(GlobalVariables.LOG_TYPE.MKFL, path);
            return true;
        }

        public static void LogThis(string action, string text)
        {
            if (!GlobalVariables.Settings.CheckBoxes.EnableLogs) { return; }

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
            if (!Directory.Exists(GlobalVariables.Path.Dir.Cache)) { Directory.CreateDirectory(GlobalVariables.Path.Dir.Cache); }

            Directory.SetCurrentDirectory(fapmap.GlobalVariables.Path.Dir.MainFolder);

            if (!File.Exists(GlobalVariables.Path.File.Settings))
            {
                using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Settings))
                {
                    //COMMENTS
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + " ============[ FAPMAP SETTINGS ]============");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "  FIREFOX.: firefox.exe -private-window");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "  OPERA...: opera.exe --private");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "  CHROME..: chrome.exe --incognito");
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "===[CHECKBOXES]");

                    // hide
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.HideOnX_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.HideOnX));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.FocusHide_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.FocusHide));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.InvisibleWindow_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.InvisibleWindow));

                    // enable
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableLogs_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableLogs));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableFileDisplay_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableFileDisplay));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableFaftv_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableFaftv));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap));

                    // players
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer));

                    // treeView
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.TreeViewSortByCreationDate_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.TreeViewSortByCreationDate));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex));

                    // fileDisplay
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.FileDisplaySortByCreationDate_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.FileDisplaySortByCreationDate));
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.FileDisplayShowThumbnails_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.FileDisplayShowThumbnails));

                    // links
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.LinksGetSiteTitle_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.LinksGetSiteTitle));

                    // downloader
                    w.WriteLine(GlobalVariables.Settings.CheckBoxes.DownloaderAutoClose_ + GlobalVariables.Settings.Common.Equal + bool_to_string(GlobalVariables.Settings.CheckBoxes.DownloaderAutoClose));

                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "===[WEBGRAB TABLE]");
                    string resource_data = Properties.Resources.file_webgrab_table;
                    List<string> words = resource_data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    foreach (string line in words) { w.WriteLine(GlobalVariables.Settings.Other.WebGrabTableLines_ + GlobalVariables.Settings.Common.Equal + line); }
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "===[OTHER]");
                    w.WriteLine(GlobalVariables.Settings.WebBrowser.Browser_ + GlobalVariables.Settings.Common.Equal + GlobalVariables.Settings.WebBrowser.Browser);
                    w.WriteLine(GlobalVariables.Settings.WebBrowser.BrowserArguments_ + GlobalVariables.Settings.Common.Equal + GlobalVariables.Settings.WebBrowser.BrowserArguments);
                    w.WriteLine(GlobalVariables.Settings.WebBrowser.FapMapURL_ + GlobalVariables.Settings.Common.Equal + GlobalVariables.Settings.WebBrowser.FapMapURL);
                    w.WriteLine(GlobalVariables.Settings.Media.GifDelay_ + GlobalVariables.Settings.Common.Equal + GlobalVariables.Settings.Media.GifDelay);
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + "FILE TYPES FOR \"OPEN RANDOM FILE\" BUTTONS");
                    w.Write(GlobalVariables.Settings.Media.FileTypes.Video_ + GlobalVariables.Settings.Common.Equal);
                    foreach (string type in GlobalVariables.FileTypes.Video)
                    {
                        w.Write(type == GlobalVariables.FileTypes.Video.Last() ? type : type + ",");
                    }
                    w.WriteLine("");
                    w.Write(GlobalVariables.Settings.Media.FileTypes.Image_ + GlobalVariables.Settings.Common.Equal);
                    foreach (string type in GlobalVariables.FileTypes.Image)
                    {
                        w.Write(type == GlobalVariables.FileTypes.Image.Last() ? type : type + ",");
                    }
                    w.WriteLine("");
                }
            }

            if (!File.Exists(GlobalVariables.Path.File.Links))
            {
                using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Links))
                {
                    w.WriteLine(GlobalVariables.Settings.Common.Comment + " comment");
                    w.WriteLine(@"https://duckduckgo.com");
                }
            }

            if (!File.Exists(GlobalVariables.Path.File.Log)) { using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Log)) { w.WriteLine(GlobalVariables.Settings.Common.Comment + " " + new FileInfo(GlobalVariables.Path.File.Log).Name); } }

            if (!File.Exists(GlobalVariables.Path.File.Passwords)) { using (StreamWriter w = File.AppendText(GlobalVariables.Path.File.Passwords)) { foreach (string line in GetResourceLines(Properties.Resources.file_passwords)) { w.WriteLine(line); } } }
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
                        LogThis(GlobalVariables.LOG_TYPE.FAIL, "fapmap.ini (line: " + countLine + ")");
                        MessageBox.Show("Failed to load fapmap.ini on line: " + countLine, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    string setting = settings_index[0];
                    string value = line.Remove(0, (setting + GlobalVariables.Settings.Common.Equal).Length);

                    switch (setting)
                    {
                        //
                        // == CHECKBOX
                        //
                        // hide
                        case GlobalVariables.Settings.CheckBoxes.HideOnX_: GlobalVariables.Settings.CheckBoxes.HideOnX = string_to_bool(value); break;
                        case GlobalVariables.Settings.CheckBoxes.FocusHide_: GlobalVariables.Settings.CheckBoxes.FocusHide = string_to_bool(value); break;
                        case GlobalVariables.Settings.CheckBoxes.InvisibleWindow_: GlobalVariables.Settings.CheckBoxes.InvisibleWindow = string_to_bool(value); break;

                        // enable
                        case GlobalVariables.Settings.CheckBoxes.EnableLogs_: GlobalVariables.Settings.CheckBoxes.EnableLogs = string_to_bool(value); break;
                        case GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers_: GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers = string_to_bool(value); break;
                        case GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer_: GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer = string_to_bool(value); break;
                        case GlobalVariables.Settings.CheckBoxes.EnableFileDisplay_: GlobalVariables.Settings.CheckBoxes.EnableFileDisplay = string_to_bool(value); break;
                        case GlobalVariables.Settings.CheckBoxes.EnableFaftv_: GlobalVariables.Settings.CheckBoxes.EnableFaftv = string_to_bool(value); break;
                        case GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap_: GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap = string_to_bool(value); break;

                        // players
                        case GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers_: GlobalVariables.Settings.CheckBoxes.AutoHideMediaPlayers = string_to_bool(value); break;
                        case GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer_: GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer = string_to_bool(value); break;
                        case GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer_: GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer = string_to_bool(value); break;

                        // faftv
                        case GlobalVariables.Settings.CheckBoxes.TreeViewSortByCreationDate_: GlobalVariables.Settings.CheckBoxes.TreeViewSortByCreationDate = string_to_bool(value); break;
                        case GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex_: GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex = string_to_bool(value); break;

                        // fileDisplay
                        case GlobalVariables.Settings.CheckBoxes.FileDisplaySortByCreationDate_: GlobalVariables.Settings.CheckBoxes.FileDisplaySortByCreationDate = string_to_bool(value); break;
                        case GlobalVariables.Settings.CheckBoxes.FileDisplayShowThumbnails_: GlobalVariables.Settings.CheckBoxes.FileDisplayShowThumbnails = string_to_bool(value); break;

                        // links
                        case GlobalVariables.Settings.CheckBoxes.LinksGetSiteTitle_: GlobalVariables.Settings.CheckBoxes.LinksGetSiteTitle = string_to_bool(value); break;

                        // downloader
                        case GlobalVariables.Settings.CheckBoxes.DownloaderAutoClose_: GlobalVariables.Settings.CheckBoxes.DownloaderAutoClose = string_to_bool(value); break;

                        //
                        // == OTHER
                        //
                        case GlobalVariables.Settings.WebBrowser.Browser_: { GlobalVariables.Settings.WebBrowser.Browser = value; break; }
                        case GlobalVariables.Settings.WebBrowser.BrowserArguments_: { GlobalVariables.Settings.WebBrowser.BrowserArguments = value; break; }
                        case GlobalVariables.Settings.WebBrowser.FapMapURL_: { GlobalVariables.Settings.WebBrowser.FapMapURL = value; break; }
                        case GlobalVariables.Settings.Media.GifDelay_:
                            {
                                if (!int.TryParse(value, out int output)) { output = 50; }
                                if (output < 5) { output = 5; }
                                if (output > 1000) { output = 1000; }

                                GlobalVariables.Settings.Media.GifDelay = output;
                                break;
                            }
                        case GlobalVariables.Settings.Media.FileTypes.Video_:
                            {
                                GlobalVariables.Settings.Media.FileTypes.Video.Clear();
                                GlobalVariables.Settings.Media.FileTypes.Video.AddRange(value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
                                break;
                            }
                        case GlobalVariables.Settings.Media.FileTypes.Image_:
                            {
                                GlobalVariables.Settings.Media.FileTypes.Image.Clear();
                                GlobalVariables.Settings.Media.FileTypes.Image.AddRange(value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
                                break;
                            }

                        case GlobalVariables.Settings.Other.WebGrabTableLines_: { GlobalVariables.Settings.Other.WebGrabTableLines.Add(value); break; }
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

            string[] lines = SafeReadLines(fapmap.GlobalVariables.Path.File.Settings).ToArray();

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

            GlobalVariables.Settings.WebBrowser.Browser = brws;
            GlobalVariables.Settings.WebBrowser.BrowserArguments = args;
            settings_edit(GlobalVariables.Settings.WebBrowser.Browser_, brws);
            settings_edit(GlobalVariables.Settings.WebBrowser.BrowserArguments_, args);
        }

        public static bool isURLMediaFile(string URL)
        {
            if (string.IsNullOrEmpty(URL)) { return false; }
            if (!URL.StartsWith("http")) { return false; }
            foreach (string type in GlobalVariables.FileTypes.Video) { if (URL.ToLower().Contains(type)) { return true; } }
            foreach (string type in GlobalVariables.FileTypes.Image) { if (URL.ToLower().Contains(type)) { return true; } }
            return false;
        }

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

        public static bool IsMD5(string input)
        {
            if (string.IsNullOrEmpty(input)) { return false; }
            return System.Text.RegularExpressions.Regex.IsMatch(input,
                "^[0-9a-fA-F]{32}$", System.Text.RegularExpressions.RegexOptions.Compiled);
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
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis) { size += fi.Length; }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis) { size += DirSize(di); }
            return size;
        }

        public static IEnumerable<string> SafeReadLines(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 0x1000, FileOptions.SequentialScan))
            using (var sr = new StreamReader(fs, System.Text.Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        public static string[] GetResourceLines(string file)
        {
            return file.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static Bitmap[] getGifFrames(Image originalImg)
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

                string UrlFileName = Path.GetFileName(new Uri(url).LocalPath);
                if (UrlFileName != "index")
                {
                    foreach (string type in GlobalVariables.FileTypes.Video) { if (url.Contains(type)) { return string.IsNullOrEmpty(UrlFileName) ? "video?" : UrlFileName; } }
                    foreach (string type in GlobalVariables.FileTypes.Image) { if (url.Contains(type)) { return string.IsNullOrEmpty(UrlFileName) ? "image?" : UrlFileName; } }
                    foreach (string type in GlobalVariables.FileTypes.Other) { if (url.Contains(type)) { return string.IsNullOrEmpty(UrlFileName) ? "file?"  : UrlFileName; } }
                }
                
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

        public static void shuffleListString(List<string> list)
        {
            Random rand = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static Tuple<int, int, int> getFileCount_VisibleNormalFull(DirectoryInfo[] dirs, FileInfo[] files)
        {
            if (dirs.Length == 0 && files.Length == 0) { return new Tuple<int, int, int>(0, 0, 0); }

            int visible = 0;
            int normal = 0;
            int full = 0;

            foreach (DirectoryInfo dir in dirs)
            {
                if (dir.Attributes.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { full++; }
                else if (dir.Attributes.HasFlag(FileAttributes.Hidden)) { normal++; }
                else { visible++; }
            }
            foreach (FileInfo file in files)
            {
                if (file.Attributes.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { full++; }
                else if (file.Attributes.HasFlag(FileAttributes.Hidden)) { normal++; }
                else { visible++; }
            }

            return new Tuple<int, int, int>(visible, normal, full);
        }

        public static Tuple<string, string, string> getVideoInfo(string filePath)
        {
            if (!File.Exists(GlobalVariables.Path.File.Exe.FFPROBE)) { goto Fail; }

            Process ffprobe = new Process();
            try
            {
                ffprobe.StartInfo.FileName = GlobalVariables.Path.File.Exe.FFPROBE;
                ffprobe.StartInfo.Arguments = "\"" + filePath + "\"";
                ffprobe.StartInfo.UseShellExecute = false;
                ffprobe.StartInfo.CreateNoWindow = true;
                ffprobe.StartInfo.RedirectStandardOutput = true;
                ffprobe.StartInfo.RedirectStandardError = true;
                ffprobe.Start();
            }
            catch (Win32Exception) { goto Fail; }
            catch (Exception) { goto Fail; }

            string output = ffprobe.StandardError.ReadToEnd();
            ffprobe.WaitForExit();

            string duration = string.Empty;
            string title = string.Empty;
            string encoder = string.Empty;

            foreach (string line in output.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (line.StartsWith("  Duration: ")) { duration = System.Text.RegularExpressions.Regex.Replace(line.Remove(0, "  Duration: ".Length).Split(',')[0], @"\t|\n|\r", ""); }
                if (line.StartsWith("    title           : ")) { title = System.Text.RegularExpressions.Regex.Replace(line.Remove(0, "    title           : ".Length), @"\t|\n|\r", ""); }
                if (line.StartsWith("    encoder         : ")) { encoder = System.Text.RegularExpressions.Regex.Replace(line.Remove(0, "    encoder         : ".Length), @"\t|\n|\r", ""); }
            }

            return new Tuple<string, string, string>(duration, title, encoder);

        Fail:
            return new Tuple<string, string, string>("", "", "");
        }

        public static ulong getFileId(FileInfo fi)
        {
            fapmap_res.WinAPI.BY_HANDLE_FILE_INFORMATION objectFileInfo = new fapmap_res.WinAPI.BY_HANDLE_FILE_INFORMATION();
            FileStream fs = fi.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            fapmap_res.WinAPI.GetFileInformationByHandle(fs.SafeFileHandle, out objectFileInfo);
            fs.Close();
            return (((ulong)objectFileInfo.FileIndexHigh << 32) + (ulong)objectFileInfo.FileIndexLow);
        }

        public static string CalculateMD5(string path)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        #endregion

        #endregion

        #region fapmap functions

        private void settings_apply()
        {
            //AUTOCOMPLTE
            foreach (string item in GlobalVariables.Settings.Other.AutoCompleteLines) { wb_url_autoCompleteMenu.AddItem(item); }

            // wmp settings
            showMedia_video.settings.setMode("loop", true);
            showMedia_video.settings.autoStart = true;
            showMedia_video.settings.volume = 100;
            showMedia_video.stretchToFit = true;
            showMedia_video.uiMode = "none";
            showMedia_video.enableContextMenu = false;
            showMedia_video.Ctlenabled = false; // also disables fullscreen
            showMedia_video.settings.enableErrorDialogs = false;
            showMedia_video_panel2.MouseWheel += showMedia_video_panel2_MouseWheel;

            fapmap_cb_hideOnX.Checked = GlobalVariables.Settings.CheckBoxes.HideOnX;
            fapmap_cb_hideOnFocus.Checked = GlobalVariables.Settings.CheckBoxes.FocusHide;
            fapmap_cb_invisibleWindow.Checked = GlobalVariables.Settings.CheckBoxes.InvisibleWindow;

            fapmap_cb_media.Checked = GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers;
            fapmap_cb_fileDisplay.Checked = GlobalVariables.Settings.CheckBoxes.EnableFileDisplay;
            fapmap_cb_faftv.Checked = GlobalVariables.Settings.CheckBoxes.EnableFaftv;

            faftv_cb_sort.Checked = GlobalVariables.Settings.CheckBoxes.TreeViewSortByCreationDate;
            faftv_cb_index.Checked = GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex;

            fileDisplay_cb_sort.Checked = GlobalVariables.Settings.CheckBoxes.FileDisplaySortByCreationDate;
            fileDisplay_cb_thumb.Checked = GlobalVariables.Settings.CheckBoxes.FileDisplayShowThumbnails;

            updateFileBrowserSplitContainer_faftv();
            updateFileBrowserSplitContainer_fileDisplay();

            // set url
            txt_url.Text = GlobalVariables.Settings.WebBrowser.FapMapURL;

            // set gif delay
            showMedia_image_gif_timer.Interval = GlobalVariables.Settings.Media.GifDelay;

            // start drawaudio thread
            new Thread(drawAudioThread) { IsBackground = true }.Start();
        }

        private void showMedia_video_panel2_MouseWheel(object sender, MouseEventArgs e)
        {
            //Point xy_player = showMedia_video.Location;
            //Size size_player = showMedia_video.Size;
            //if (e.X > xy_player.X && e.Y > xy_player.Y && e.X < size_player.Width && e.Y < size_player.Height)
            if (showMedia_video.ClientRectangle.Contains(e.X, e.Y))
            {
                int val = showMedia_video_sound.Value;
                if (e.Delta > 0) { val += 3; }
                else { val -= 3; }
                if (val > showMedia_video_sound.Maximum) { val = showMedia_video_sound.Maximum; }
                if (val < showMedia_video_sound.Minimum) { val = showMedia_video_sound.Minimum; }
                showMedia_video_sound.Value = val;
            }
        }

        private void fapmap_echo(string text)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.Text = string.IsNullOrEmpty(text) ? "FapMap" : ("FapMap: " + text);
            });
        }

        private void OpenFile(string file)
        {
            if (fapmap.Open(file))
            {
                media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers);
            }
        }

        public static Process CrashHandler = new Process();
        public static bool CrashHandler_running = false;
        public static void CrashHandler_start()
        {
            if (File.Exists(GlobalVariables.Path.File.Exe.CRASHHANDLER))
            {
                try
                {
                    CrashHandler = new Process();
                    CrashHandler.StartInfo.FileName = GlobalVariables.Path.File.Exe.CRASHHANDLER;
                    CrashHandler.StartInfo.Arguments = "\"" + Process.GetCurrentProcess().Id + "\" \"" + Application.ExecutablePath + "\" \"FapMap\"";
                    CrashHandler.StartInfo.WorkingDirectory = GlobalVariables.Path.Dir.Main;
                    CrashHandler.StartInfo.UseShellExecute = false;
                    CrashHandler.StartInfo.CreateNoWindow = true;
                    CrashHandler.Start();
                    CrashHandler_running = true;
                }
                catch (Exception) { CrashHandler_running = false; }
            }
        }
        public static void CrashHandler_stop()
        {
            if (CrashHandler_running) { try { CrashHandler.Kill(); CrashHandler_running = false; } catch (Exception) { } }
        }

        #endregion

        #region Menu Strip

        private void menu_hideWindow_Click(object sender, EventArgs e) { this_hideOrShow(); }

        private void menu_changeTabs_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // show both tabs
            {
                splitContainer_main.Panel1Collapsed = false;
                splitContainer_main.Panel2Collapsed = false;
                splitContainer_main.Panel1.Show();
                splitContainer_main.Panel2.Show();
            }
        }
        private void menu_changeTabs_Click(object sender, EventArgs e)
        {
            changeMainTabs();
        }

        private bool panel1_show = true;
        private void changeMainTabs()
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

        private void menu_open_explorer_Click(object sender, EventArgs e) { nestFiles(); OpenInExplorer(Directory.Exists(txt_path.Text) ? txt_path.Text : GlobalVariables.Path.Dir.MainFolder); }
        private void menu_open_browser_Click(object sender, EventArgs e) { Incognito(); }
        private void menu_open_finder_Click(object sender, EventArgs e) { new fapmap_find().Show(); }
        private void menu_open_fscan_Click(object sender, EventArgs e) { new fapmap_fscan() { pass_path = txt_path.Text }.Show(); }
        private void menu_open_md5_Click(object sender, EventArgs e) { new fapmap_md5() { pass_path = txt_path.Text }.Show(); }
        private void menu_open_videoPlayer_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers)
            {
                media_remove();
                showMedia_video_panel.Visible = true;
                showMedia_video_panel.BringToFront();
            }
        }
        private void menu_open_imageViewer_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers)
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

        private void menu_hideGallery_0_Click(object sender, EventArgs e) { gallery_hide(attrib_args.unhide); }
        private void menu_hideGallery_1_Click(object sender, EventArgs e) { gallery_hide(attrib_args.normal); }
        private void menu_hideGallery_2_Click(object sender, EventArgs e) { gallery_hide(attrib_args.full);   }

        private bool gallery_hide_busy = false;
        private void gallery_hide(attrib_args args)
        {
            if (gallery_hide_busy) { return; }

            new Thread(() =>
            {
                gallery_hide_busy = true;
                fapmap_echo("RUNNING: attrib.exe -- ...");
                attrib(args);
                fapmap_echo("RUNNING: attrib.exe -- DONE!");
                gallery_hide_busy = false;
            })
            { IsBackground = true }.Start();
        }

        private void menu_restart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Restart FapMap?", "FAPMAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start(Application.ExecutablePath);
                Quit();
            }
        }

        private void fapmap_cb_hideOnX_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVariables.Settings.CheckBoxes.HideOnX = fapmap_cb_hideOnX.Checked;
        }
        private void fapmap_cb_hideOnFocus_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVariables.Settings.CheckBoxes.FocusHide = fapmap_cb_hideOnFocus.Checked;
        }
        private void fapmap_cb_invisibleWindow_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVariables.Settings.CheckBoxes.InvisibleWindow = fapmap_cb_invisibleWindow.Checked;
            if (!fapmap_cb_invisibleWindow.Checked)
            {
                this.Opacity = 1.0f;
            }
        }
        private void fapmap_cb_media_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers = fapmap_cb_media.Checked;
            if (!fapmap_cb_media.Checked) { media_close(); }
        }
        private void fapmap_cb_fileDisplay_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVariables.Settings.CheckBoxes.EnableFileDisplay = fapmap_cb_fileDisplay.Checked;
            fileDisplay.Enabled = fapmap_cb_fileDisplay.Checked;
        }
        private void fapmap_cb_faftv_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVariables.Settings.CheckBoxes.EnableFaftv = fapmap_cb_faftv.Checked;
            faftv.Enabled = fapmap_cb_faftv.Checked;
        }

        private void updateFileBrowserSplitContainer_fileDisplay()
        {
            splitContainer_files.Visible = (!fileDisplay.Enabled && !faftv.Enabled) ? false : true;

            if (fileDisplay.Enabled)
            {
                splitContainer_files.Panel2.Show();
                splitContainer_files.Panel2Collapsed = false;
                load_dir(txt_path.Text);
            }
            else
            {
                splitContainer_files.Panel2.Hide();
                splitContainer_files.Panel2Collapsed = true;
                load_dir_cur++; // cancel loading thumbs
                fileDisplay.Items.Clear();
                fileDisplay_icons.Images.Clear();
                fileDisplay_watcher.Dispose();
            }
        }
        private void updateFileBrowserSplitContainer_faftv()
        {
            splitContainer_files.Visible = (!fileDisplay.Enabled && !faftv.Enabled) ? false : true;

            if (faftv.Enabled)
            {
                splitContainer_files.Panel1.Show();
                splitContainer_files.Panel1Collapsed = false;
                faftv_reload();
            }
            else
            {
                splitContainer_files.Panel1.Hide();
                splitContainer_files.Panel1Collapsed = true;
                faftv.Nodes.Clear();
                faftv_watcher.Dispose();
            }
        }

        private void fileDisplay_EnabledChanged(object sender, EventArgs e)
        {
            updateFileBrowserSplitContainer_fileDisplay();
        }
        private void faftv_EnabledChanged(object sender, EventArgs e)
        {
            updateFileBrowserSplitContainer_faftv();
        }

        #endregion

        #region load_file_or_dir

        private string selectedFilePath = string.Empty;
        private void load_file(string path)
        {
            if (!GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers) { return; }

            media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers);

            foreach (string type in GlobalVariables.FileTypes.Image)
            {
                if (!path.ToLower().EndsWith(type)) { continue; }

                selectedFilePath = path;
                media_echo(path, showMedia_image_title);

                if (GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer && path.ToLower().EndsWith(".gif"))
                {
                    bool gif_is_valid = true;

                    try
                    {
                        Image img = fapmap_res.ImageFast.FromFile(path);
                        showMedia_image_gif_frames = getGifFrames(img);
                        img.Dispose();
                    }
                    catch (OutOfMemoryException) { gif_is_valid = false; }
                    catch (Exception) { gif_is_valid = false; }

                    if (gif_is_valid)
                    {
                        showMedia_image_gifbox(true);

                        showMedia_image_panel.Visible = true;
                        showMedia_image_panel.BringToFront();
                        media_isRemoved = false;
                        LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, path);
                    }
                }
                else
                {
                    showMedia_image_gifbox(false);

                    try
                    {
                        showMedia_image.Image = fapmap_res.ImageFast.FromFile(path);
                    }
                    catch (Exception)
                    {
                        LogThis(GlobalVariables.LOG_TYPE.FAIL, "Error loading image file: " + path);
                        media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers);
                        MessageBox.Show(path, "Image file is invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    showMedia_image_panel.Visible = true;
                    showMedia_image_panel.BringToFront();
                    media_isRemoved = false;
                    LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, path);
                }

                return;
            }

            foreach (string type in GlobalVariables.FileTypes.Video)
            {
                if (!path.ToLower().EndsWith(type)) { continue; }

                selectedFilePath = path;
                media_echo(path, showMedia_video_title);

                try
                {
                    showMedia_video.URL = path;
                }
                catch (Exception)
                {
                    LogThis(GlobalVariables.LOG_TYPE.FAIL, "Error loading video file: " + path);
                    MessageBox.Show(path, "Video file is invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                showMedia_video_panel.Visible = true;
                showMedia_video_panel.BringToFront();
                media_isRemoved = false;
                LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, path);
                return;
            }
        }

        private bool media_playUrl(string URL)
        {
            if (!GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers) { return false; }

            media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers);

            foreach (string type in GlobalVariables.FileTypes.Image)
            {
                if (URL.ToLower().Contains(type))
                {
                    showMedia_image_gifbox(false);
                    showMedia_image_panel.Visible = true;
                    showMedia_image_panel.BringToFront();
                    media_echo(URL, showMedia_image_title);

                    try
                    {
                        showMedia_image_URL = URL;
                        showMedia_image.LoadAsync(URL);
                    }
                    catch (Exception)
                    {
                        LogThis(GlobalVariables.LOG_TYPE.FAIL, URL);
                        MessageBox.Show(URL, "Image url is invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    showMedia_image_pb.Visible = true;

                    LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, URL);
                    media_isRemoved = false;
                    return true;
                }
            }

            foreach (string type in GlobalVariables.FileTypes.Video)
            {
                if (URL.ToLower().Contains(type))
                {
                    showMedia_video_panel.Visible = true;
                    showMedia_video_panel.BringToFront();
                    media_echo(URL, showMedia_video_title);

                    try
                    {
                        showMedia_video.URL = URL;

                    }
                    catch (Exception)
                    {
                        LogThis(GlobalVariables.LOG_TYPE.FAIL, URL);
                        MessageBox.Show(URL, "Video url is invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers);
                    }

                    LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, URL);
                    media_isRemoved = false;
                    return true;
                }
            }

            return false;
        }

        private string selectedDirPath = GlobalVariables.Path.Dir.MainFolder;
        private int load_dir_cur = 0;
        private void load_dir(string path)
        {
            if (!GlobalVariables.Settings.CheckBoxes.EnableFileDisplay) { fileDisplay.Enabled = false; return; }
            fileDisplay.Enabled = true;

            // current run index (for thumbs)
            load_dir_cur++;

            try
            {
                // set path
                selectedDirPath = path;
                txt_path.Text = path;
                if (File.Exists(path)) { path = new FileInfo(path).Directory.FullName; }
                if (!Directory.Exists(path)) { return; }

                //fileDisplay_icons.Images.Clear();
                fileDisplay.Items.Clear();

                if (fileDisplay_watcher != null) { fileDisplay_watcher.Dispose(); }
                fileDisplay_watcher = new FileSystemWatcher()
                {
                    NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName,
                    Filter = "*.*",
                    IncludeSubdirectories = false,
                    Path = path,
                };
                fileDisplay_watcher.Changed += fileDisplay_watcher_Changed;
                fileDisplay_watcher.Created += fileDisplay_watcher_Created;
                fileDisplay_watcher.Deleted += fileDisplay_watcher_Deleted;
                fileDisplay_watcher.Renamed += fileDisplay_watcher_Renamed;
                fileDisplay_watcher.EnableRaisingEvents = true;

                DirectoryInfo loadDir = new DirectoryInfo(path);
                DirectoryInfo[] dirs = loadDir.GetDirectories();
                FileInfo[] files = loadDir.GetFiles();

                if (GlobalVariables.Settings.CheckBoxes.FileDisplaySortByCreationDate)
                {
                    dirs = dirs.OrderBy(p => p.CreationTime).ToArray();
                    files = files.OrderBy(p => p.CreationTime).ToArray();
                }

                List<ListViewItem> items = new List<ListViewItem>();

                // get dirs
                for (int i = 0; i < dirs.Length; i++)
                {
                    items.Add(load_dir_dir(dirs[i]));
                }

                // get files
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name == "desktop.ini") { continue; }
                    items.Add(load_dir_file(files[i]));
                    load_dir_thumbnail(files[i], items.Last());
                }

                fileDisplay.Items.AddRange(items.ToArray());
            }
            catch (Exception) { }
        }
        private void load_dir_refresh()
        {
            if (!Directory.Exists(selectedDirPath)) { return; }
            DirectoryInfo di = new DirectoryInfo(selectedDirPath);

            DirectoryInfo[] dirs = di.GetDirectories();
            FileInfo[] files = di.GetFiles();

            if (GlobalVariables.Settings.CheckBoxes.FileDisplaySortByCreationDate)
            {
                dirs = dirs.OrderBy(p => p.CreationTime).ToArray();
                files = files.OrderBy(p => p.CreationTime).ToArray();
            }

            for (int i = 0; i < dirs.Length; i++)
            {
                int index = fileDisplay.Items.IndexOfKey(dirs[i].FullName);
                if (index == -1)
                {
                    fileDisplay.Items.Add(load_dir_dir(dirs[i]));
                    index = fileDisplay.Items.Count - 1;
                }
                else
                {
                    Color foreColor = fileDisplay.ForeColor;
                    if (dirs[i].Attributes.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { foreColor = faftv.ForeColor; }
                    else if (dirs[i].Attributes.HasFlag(FileAttributes.Hidden)) { foreColor = Color.SkyBlue; }
                    else { foreColor = Color.Magenta; }
                    fileDisplay.Items[index].ForeColor = foreColor;
                }
            }

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name == "desktop.ini") { continue; }

                int index = fileDisplay.Items.IndexOfKey(files[i].FullName);
                if (index == -1)
                {
                    fileDisplay.Items.Add(load_dir_file(files[i]));
                    index = fileDisplay.Items.Count - 1;
                }
                else
                {
                    Color foreColor = fileDisplay.ForeColor;
                    if (files[i].Attributes.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { foreColor = faftv.ForeColor; }
                    else if (files[i].Attributes.HasFlag(FileAttributes.Hidden)) { foreColor = Color.SkyBlue; }
                    else { foreColor = Color.Magenta; }
                    fileDisplay.Items[index].ForeColor = foreColor;
                }

                load_dir_thumbnail(files[i], fileDisplay.Items[index]);
            }

            // remove stuff that doesn't exist
            List<ListViewItem> itemsToRemove = new List<ListViewItem>();
            foreach (ListViewItem lvi in fileDisplay.Items)
            { if (!Directory.Exists(lvi.Name) && !File.Exists(lvi.Name)) { itemsToRemove.Add(lvi); } }
            foreach (ListViewItem lvi in itemsToRemove) { fileDisplay.Items.Remove(lvi); }
        }
        private Mutex load_dir_thumbnail_mutex = new Mutex();
        private void load_dir_thumbnail(FileInfo fi, ListViewItem item = null)
        {
            int c_load_dir_cur = load_dir_cur;

            if (GlobalVariables.Settings.CheckBoxes.FileDisplayShowThumbnails)
            {
                // get image thumbs
                if (GlobalVariables.FileTypes.Image.Contains(fi.Extension.ToLower()))
                {
                    ThreadPool.QueueUserWorkItem((i) =>
                    {
                        load_dir_thumbnail_mutex.WaitOne();
                        if (c_load_dir_cur != load_dir_cur) { load_dir_thumbnail_mutex.ReleaseMutex(); return; }

                        try
                        {
                            string file = fi.FullName;
                            string id = getFileId(fi).ToString();

                            // get index
                            int iIndex = -1;
                            this.Invoke((MethodInvoker)delegate { iIndex = fileDisplay_icons.Images.IndexOfKey(id); });
                            if (iIndex == -1)
                            {
                                Image img = fapmap_res.ImageFast.FromFile(file);
                                Bitmap bmp = new Bitmap(img);
                                img.Dispose();
                                int size = Math.Max(bmp.Width, bmp.Height);
                                Bitmap bmpDrawOn = new Bitmap(size, size);
                                using (Graphics g = Graphics.FromImage(bmpDrawOn)) { g.Clear(Color.Transparent); g.DrawImage(bmp, 0, 0); }

                                if (c_load_dir_cur == load_dir_cur)
                                {
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        fileDisplay_icons.Images.Add(id, bmpDrawOn);
                                        if (item != null) { item.ImageIndex = fileDisplay_icons.Images.Count - 1; }
                                    });
                                }
                                bmp.Dispose();
                                bmpDrawOn.Dispose();
                            }
                            else
                            {
                                if (item != null) { item.ImageIndex = iIndex; }
                            }
                        }
                        catch (Exception) { }

                        load_dir_thumbnail_mutex.ReleaseMutex();
                    });
                }

                // get video thumbs
                if (File.Exists(GlobalVariables.Path.File.Exe.FFMPEG)
                 && GlobalVariables.FileTypes.Video.Contains(fi.Extension.ToLower()))
                {
                    ThreadPool.QueueUserWorkItem((i) =>
                    {
                        load_dir_thumbnail_mutex.WaitOne();
                        if (c_load_dir_cur != load_dir_cur) { load_dir_thumbnail_mutex.ReleaseMutex(); return; }

                        try
                        {
                            string file = fi.FullName;
                            string id = getFileId(fi).ToString();
                            string dest = GlobalVariables.Path.Dir.Cache + "\\" + id + ".tmp";

                            // get index
                            int iIndex = -1;
                            this.Invoke((MethodInvoker)delegate { iIndex = fileDisplay_icons.Images.IndexOfKey(id); });
                            if (iIndex == -1)
                            {
                                if (!File.Exists(dest))
                                {
                                    makeThumb(file, dest);
                                    if (c_load_dir_cur != load_dir_cur) { load_dir_thumbnail_mutex.ReleaseMutex(); return; }
                                }

                                if (File.Exists(dest))
                                {
                                    Image img = fapmap_res.ImageFast.FromFile(dest);
                                    Bitmap bmp = new Bitmap(img);
                                    img.Dispose();
                                    int size = Math.Max(bmp.Width, bmp.Height);
                                    Bitmap bmpDrawOn = new Bitmap(size, size);
                                    using (Graphics g = Graphics.FromImage(bmpDrawOn)) { g.Clear(Color.Transparent); g.DrawImage(bmp, 0, 0); }
                                    if (c_load_dir_cur == load_dir_cur)
                                    {
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            fileDisplay_icons.Images.Add(id, bmpDrawOn);
                                            if (item != null) { item.ImageIndex = fileDisplay_icons.Images.Count - 1; }
                                        });
                                    }
                                    bmp.Dispose();
                                    bmpDrawOn.Dispose();
                                }
                            }
                            else
                            {
                                if (item != null) { item.ImageIndex = iIndex; }
                            }
                        }
                        catch (Exception) { }

                        load_dir_thumbnail_mutex.ReleaseMutex();
                    });
                }
            }
        }
        private ListViewItem load_dir_dir(DirectoryInfo di)
        {
            string ext = "dir";
            int extIndex = fileDisplay_icons.Images.IndexOfKey(ext);
            if (extIndex == -1)
            {
                fileDisplay_icons.Images.Add(ext, Properties.Resources.dir);
                extIndex = fileDisplay_icons.Images.Count - 1;
            }

            Color foreColor = fileDisplay.ForeColor;
            if (di.Attributes.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { foreColor = faftv.ForeColor; }
            else if (di.Attributes.HasFlag(FileAttributes.Hidden)) { foreColor = Color.SkyBlue; }
            else { foreColor = Color.Magenta; }

            return new ListViewItem() { Name = di.FullName, Text = di.Name, ImageIndex = extIndex, ForeColor = foreColor };
        }
        private ListViewItem load_dir_file(FileInfo fi)
        {
            string key = fi.Extension.ToLower();
            if (key == ".exe") { key = fapmap.getFileId(fi).ToString(); }

            int extIndex = fileDisplay_icons.Images.IndexOfKey(key);
            if (extIndex == -1)
            {
                fileDisplay_icons.Images.Add(key, System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName));
                extIndex = fileDisplay_icons.Images.Count - 1;
            }

            Color foreColor = fileDisplay.ForeColor;
            if (fi.Attributes.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { foreColor = faftv.ForeColor; }
            else if (fi.Attributes.HasFlag(FileAttributes.Hidden)) { foreColor = Color.SkyBlue; }
            else { foreColor = Color.Magenta; }

            return new ListViewItem() { Name = fi.FullName, Text = fi.Name, ImageIndex = extIndex, ForeColor = foreColor };
        }

        private void load_file_or_dir(string path)
        {
            if (Directory.Exists(path))
            {
                txt_path.Text = path;
                load_dir(path);
                return;
            }

            if (File.Exists(path))
            {
                txt_path.Text = path;
                if (path.ToLower().EndsWith(".lst")
                 || path.ToLower().EndsWith(".txt")
                )
                {
                    menu_changeTabs_MouseUp(null, new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0));
                    links_reload(path);
                    return;
                }

                load_file(path);
            }

            if (isURLMediaFile(path))
            {
                media_playUrl(path);
            }

        }

        #endregion

        #region faftv & fileDisplay

        private enum ClipBoardType { None, Cut, Copy }
        List<string> clipboard = new List<string>();
        private ClipBoardType cliboardType = ClipBoardType.None;

        private void clipboard_paste(string dir)
        {
            if (cliboardType == ClipBoardType.None) { return; }
            if (!Directory.Exists(dir)) { return; }
            DirectoryInfo moveToDI = new DirectoryInfo(dir);

            bool mediaRemoved = false;
            foreach (string path in clipboard)
            {
                if (Directory.Exists(path))
                {
                    if (!mediaRemoved && selectedFilePath.Contains(path)) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }

                    DirectoryInfo di = new DirectoryInfo(path);
                    switch (cliboardType)
                    {
                        case ClipBoardType.Cut: fapmap.MoveDir(path, moveToDI.FullName + "\\" + di.Name); break;
                        case ClipBoardType.Copy: fapmap.CopyDir(path, moveToDI.FullName + "\\" + di.Name); break;
                    }

                }
                else if (File.Exists(path))
                {
                    if (!mediaRemoved && selectedFilePath == path) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }

                    FileInfo fi = new FileInfo(path);
                    switch (cliboardType)
                    {
                        case ClipBoardType.Cut: fapmap.MoveFile(path, moveToDI.FullName + "\\" + fi.Name); break;
                        case ClipBoardType.Copy: fapmap.CopyFile(path, moveToDI.FullName + "\\" + fi.Name); break;
                    }
                }
            }

            clipboard_clear();
        }
        private void clipboard_clear()
        {
            // clear clipboard
            cliboardType = ClipBoardType.None;
            clipboard.Clear();
            faftv_N_fileDisplay_refresh();
        }

        private void faftv_N_fileDisplay_refresh()
        {
            faftv.Refresh();
            fileDisplay.Refresh();
        }

        private void faftv_n_fileDisplay_dragNdrop(string dirPath, System.Windows.Forms.DragEventArgs e)
        {
            if (!Directory.Exists(dirPath)) { return; }
            DirectoryInfo di = new DirectoryInfo(dirPath);

            string url = e.Data.GetData(DataFormats.StringFormat) as string;

            if (!string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                fapmap_download fd = new fapmap_download() { pass_path = di.FullName };
                bool i = Path.GetFileNameWithoutExtension(new Uri(url).LocalPath) == "index";
                bool f = !isURLMediaFile(url);
                if ((i || f) && File.Exists(fapmap.GlobalVariables.Path.File.Exe.WEBGRAB))
                     { fd.pass_webgrabURL = url;             }
                else { fd.pass_URLs = new string[1] { url }; }
                fd.Show();
                return;
            }

            foreach (string src in (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop, false))
            {
                string destDir = di.FullName;
                if (Directory.Exists(src)) { fapmap.CopyDir (src, destDir + "\\" + new DirectoryInfo(src).Name); }
                else if (File.Exists(src)) { fapmap.CopyFile(src, destDir + "\\" + new FileInfo     (src).Name); }
            }
        }

        #endregion

        #region fileDisplay

        #region functions

        private FileSystemWatcher fileDisplay_watcher = new FileSystemWatcher();
        private void fileDisplay_selectAll()
        {
            foreach (ListViewItem item in fileDisplay.Items)
            {
                item.Selected = true;
            }
        }
        private void fileDisplay_find()
        {
            string input = fapmap.OpenInputBox(this, "Find:", "", 0, 0);
            if (!string.IsNullOrEmpty(input))
            {
                fileDisplay.SelectedItems.Clear();
                foreach (ListViewItem lvi in fileDisplay.Items)
                {
                    if (lvi.Text.Contains(input))
                    {
                        lvi.Focused = true;
                        lvi.Selected = true;
                        lvi.EnsureVisible();
                        fileDisplay.Select();
                    }
                }
            }
        }
        private void fileDisplay_open(bool openFiles = false, bool openDirs = false)
        {
            if (fileDisplay.SelectedItems.Count == 0) { return; }

            bool mediaRemoved = false;
            if (fileDisplay.SelectedItems.Count == 1)
            {
                ListViewItem item = fileDisplay.SelectedItems[0];
                if (item.Name == null) { return; }
                string path = item.Name;
                if (string.IsNullOrEmpty(path)) { return; }

                if (Directory.Exists(path))
                {
                    if (openDirs) { fapmap.Open(path); }
                    else { load_file_or_dir(path); }
                }
                else if (File.Exists(path))
                {
                    FileInfo fi = new FileInfo(path);
                    if (openFiles)
                    {
                        if (fi.Name.Contains("fapmap_mod")) { OpenScript(this, fi.FullName); }
                        else
                        {
                            if (!mediaRemoved && selectedFilePath == path) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }
                            fapmap.Open(fi.FullName);
                        }
                    }
                    else { load_file_or_dir(path); }
                }
            }
            else
            {
                if (MessageBox.Show("Open " + fileDisplay.SelectedItems.Count + " items?", "Open", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in fileDisplay.SelectedItems)
                    {
                        if (item.Name == null) { return; }
                        string path = item.Name;
                        if (string.IsNullOrEmpty(path)) { return; }

                        if (Directory.Exists(path))
                        {
                            if (openDirs) { fapmap.Open(path); }
                            else { load_file_or_dir(path); }
                        }
                        else if (File.Exists(path))
                        {
                            FileInfo fi = new FileInfo(path);
                            if (openFiles)
                            {
                                if (fi.Name.Contains("fapmap_mod")) { OpenScript(this, fi.FullName); }
                                else
                                {
                                    if (!mediaRemoved && selectedFilePath == path) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }
                                    fapmap.Open(fi.FullName);
                                }
                            }
                            else { load_file_or_dir(path); }
                        }
                    }
                }
            }
        }
        private void fileDisplay_openInBrowser()
        {
            if (fileDisplay.SelectedItems.Count == 0) { return; }

            if (fileDisplay.SelectedItems.Count == 1)
            {
                ListViewItem item = fileDisplay.SelectedItems[0];
                if (item.Name == null) { return; }
                string path = item.Name;
                if (string.IsNullOrEmpty(path)) { return; }
                OpenInBrowser(path);
            }
            else
            {
                if (MessageBox.Show("Open " + fileDisplay.SelectedItems.Count + " items?", "Open", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in fileDisplay.SelectedItems)
                    {
                        if (item.Name == null) { return; }
                        string path = item.Name;
                        if (string.IsNullOrEmpty(path)) { return; }
                        OpenInBrowser(path);
                    }
                }
            }
        }
        private void fileDisplay_explorer()
        {
            if (fileDisplay.SelectedItems.Count == 0) { return; }

            if (fileDisplay.SelectedItems.Count == 1)
            {
                ListViewItem item = fileDisplay.SelectedItems[0];
                if (item.Name == null) { return; }
                string path = item.Name;
                if (string.IsNullOrEmpty(path)) { return; }
                OpenInExplorer(path);
            }
            else
            {
                if (MessageBox.Show("Open " + fileDisplay.SelectedItems.Count + " items?", "Open", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in fileDisplay.SelectedItems)
                    {
                        if (item.Name == null) { return; }
                        string path = item.Name;
                        if (string.IsNullOrEmpty(path)) { return; }
                        OpenInExplorer(path);
                    }
                }
            }
        }
        private void fileDisplay_explorer2()
        {
            if (fileDisplay.SelectedItems.Count == 0) { return; }

            if (fileDisplay.SelectedItems.Count == 1)
            {
                ListViewItem item = fileDisplay.SelectedItems[0];
                if (item.Name == null) { return; }
                string path = item.Name;
                if (string.IsNullOrEmpty(path)) { return; }
                OpenAndSelectInExplorer(path);
            }
            else
            {
                if (MessageBox.Show("Open " + fileDisplay.SelectedItems.Count + " explorers and select items?", "Open", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in fileDisplay.SelectedItems)
                    {
                        if (item.Name == null) { return; }
                        string path = item.Name;
                        if (string.IsNullOrEmpty(path)) { return; }
                        OpenAndSelectInExplorer(path);
                    }
                }
            }
        }
        private void fileDisplay_backDir()
        {
            string path = selectedDirPath;
            if (!Directory.Exists(path)) { load_file_or_dir(GlobalVariables.Path.Dir.MainFolder); return; }

            if (new DirectoryInfo(path).Name != new DirectoryInfo(GlobalVariables.Path.Dir.MainFolder).Name)
            { load_file_or_dir(Directory.GetParent(path).ToString()); }
        }
        private void fileDisplay_move()
        {
            cliboardType = ClipBoardType.Cut;
            fileDisplay_clip();
        }
        private void fileDisplay_copy()
        {
            cliboardType = ClipBoardType.Copy;
            fileDisplay_clip();
        }
        private void fileDisplay_clip()
        {
            if (fileDisplay.SelectedItems.Count == 0) { return; }

            foreach (ListViewItem item in fileDisplay.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string path = item.Name;
                if (string.IsNullOrEmpty(path)) { continue; }

                if (clipboard.Contains(path)) { clipboard.Remove(path); }
                else { clipboard.Add(path); }
            }

            faftv_N_fileDisplay_refresh();
        }
        private void fileDisplay_paste()
        {
            clipboard_paste(selectedDirPath);
        }
        private void fileDisplay_unMarkAll()
        {
            // clear selected items
            fileDisplay.SelectedItems.Clear();

            clipboard_clear();
            faftv_N_fileDisplay_refresh();
        }
        private void fileDisplay_move_now()
        {
            if (fileDisplay.SelectedItems.Count == 0) { return; }

            string dir = fapmap.OpenPathSelector(this, selectedDirPath);
            if (string.IsNullOrEmpty(dir) || !Directory.Exists(dir)) { return; }
            DirectoryInfo moveToDI = new DirectoryInfo(dir);

            bool mediaRemoved = false;
            foreach (ListViewItem item in fileDisplay.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string path = item.Name;
                if (string.IsNullOrEmpty(path)) { continue; }

                if (Directory.Exists(path))
                {
                    if (!mediaRemoved && selectedFilePath.Contains(path)) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }

                    DirectoryInfo di = new DirectoryInfo(path);
                    fapmap.MoveDir(path, moveToDI.FullName + "\\" + di.Name);
                }
                else if (File.Exists(path))
                {
                    if (!mediaRemoved && selectedFilePath == path) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }

                    FileInfo fi = new FileInfo(path);
                    fapmap.MoveFile(path, moveToDI.FullName + "\\" + fi.Name);
                }
            }
        }
        private void fileDisplay_copy_now()
        {
            if (fileDisplay.SelectedItems.Count == 0) { return; }

            string dir = fapmap.OpenPathSelector(this, selectedDirPath);
            if (string.IsNullOrEmpty(dir) || !Directory.Exists(dir)) { return; }
            DirectoryInfo moveToDI = new DirectoryInfo(dir);

            bool mediaRemoved = false;
            foreach (ListViewItem item in fileDisplay.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string path = item.Name;
                if (string.IsNullOrEmpty(path)) { continue; }

                if (Directory.Exists(path))
                {
                    if (!mediaRemoved && selectedFilePath.Contains(path)) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }

                    DirectoryInfo di = new DirectoryInfo(path);
                    fapmap.CopyDir(path, moveToDI.FullName + "\\" + di.Name);
                }
                else if (File.Exists(path))
                {
                    if (!mediaRemoved && selectedFilePath == path) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }

                    FileInfo fi = new FileInfo(path);
                    fapmap.CopyFile(path, moveToDI.FullName + "\\" + fi.Name);
                }
            }
        }
        private void fileDisplay_rename()
        {
            bool mediaRemoved = false;
            foreach (ListViewItem item in fileDisplay.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string path = item.Name;
                if (string.IsNullOrEmpty(path)) { continue; }

                if (Directory.Exists(path))
                {
                    if (!mediaRemoved && selectedFilePath.Contains(path)) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }

                    DirectoryInfo di_src = new DirectoryInfo(path);
                    string input = fapmap.OpenInputBox(this, "Rename folder?", di_src.Name, 0, di_src.Name.Length);
                    if (!string.IsNullOrEmpty(input))
                    {
                        fapmap.MoveDir(di_src.FullName, di_src.Parent.FullName + "\\" + input);
                    }
                }
                else if (File.Exists(path))
                {
                    if (!mediaRemoved && selectedFilePath == path) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }

                    FileInfo fi_src = new FileInfo(path);
                    string input = fapmap.OpenInputBox(this, "Rename file?", fi_src.Name, 0, fi_src.Name.Length - fi_src.Extension.Length);
                    if (!string.IsNullOrEmpty(input))
                    {
                        fapmap.MoveFile(fi_src.FullName, fi_src.Directory.FullName + "\\" + input);
                    }
                }
            }
        }
        private void fileDisplay_delete()
        {
            if (fileDisplay.SelectedItems.Count == 0) { return; }

            bool mediaRemoved = false;
            if (fileDisplay.SelectedItems.Count == 1)
            {
                ListViewItem item = fileDisplay.SelectedItems[0];
                if (item.Name == null) { return; }
                string path = item.Name;
                if (string.IsNullOrEmpty(path)) { return; }

                if (Directory.Exists(path))
                {
                    if (!mediaRemoved && selectedFilePath.Contains(path)) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }
                    if (fapmap.TrashDir(path)) { fileDisplay.Items.Remove(item); }
                }
                else if (File.Exists(path))
                {
                    if (!mediaRemoved && selectedFilePath == path) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }
                    if (fapmap.TrashFile(path)) { fileDisplay.Items.Remove(item); }
                }
            }
            else
            {
                if (MessageBox.Show("Trash " + fileDisplay.SelectedItems.Count + " items?", "Send To Recycle Bin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<string> dirsToTrash = new List<string>();
                    List<string> filesToTrash = new List<string>();

                    foreach (ListViewItem item in fileDisplay.SelectedItems)
                    {
                        if (item.Name == null) { continue; }
                        string path = item.Name;
                        if (string.IsNullOrEmpty(path)) { continue; }

                        if (Directory.Exists(path))
                        {
                            if (!mediaRemoved && selectedFilePath.Contains(path)) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }
                            dirsToTrash.Add(path);
                        }
                        else if (File.Exists(path))
                        {
                            if (!mediaRemoved && selectedFilePath == path) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); mediaRemoved = true; }
                            filesToTrash.Add(path);
                        }
                    }

                    fapmap.TrashDirs(dirsToTrash);
                    fapmap.TrashFiles(filesToTrash);
                }
            }
        }
        private void fileDisplay_makeDir()
        {
            string path = selectedDirPath;

            if (File.Exists(path)) { path = Directory.GetParent(path).FullName; }
            if (!Directory.Exists(path)) { return; }

            string input = fapmap.OpenInputBox(this, "Create New Folder in: " + new DirectoryInfo(path).Name, "New Folder", 0, "New Folder".Length);
            if (!string.IsNullOrEmpty(input))
            {
                fapmap.CreateDir(new DirectoryInfo(path).FullName + "\\" + input);
            }
        }
        private void fileDisplay_makeFile()
        {
            string path = selectedDirPath;

            if (File.Exists(path)) { path = Directory.GetParent(path).FullName; }
            if (!Directory.Exists(path)) { return; }

            string input = fapmap.OpenInputBox(this, "Create New File in: " + new DirectoryInfo(path).Name, "NewTextFile.txt", 0, "NewTextFile".Length);
            if (!string.IsNullOrEmpty(input))
            {
                fapmap.CreateFile(new DirectoryInfo(path).FullName + "\\" + input);
            }
        }
        private void fileDisplay_properties()
        {
            if (fileDisplay.SelectedItems.Count == 0) { return; }

            if (fileDisplay.SelectedItems.Count == 1)
            {
                ListViewItem item = fileDisplay.SelectedItems[0];
                if (item.Name == null) { return; }
                string path = item.Name;
                if (string.IsNullOrEmpty(path)) { return; }
                fapmap.OpenProperties(path);
            }
            else
            {
                if (MessageBox.Show("Open " + fileDisplay.SelectedItems.Count + " properties?", "Open", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in fileDisplay.SelectedItems)
                    {
                        if (item.Name == null) { return; }
                        string path = item.Name;
                        if (string.IsNullOrEmpty(path)) { return; }
                        fapmap.OpenProperties(path);
                    }
                }
            }
        }

        private void fileDisplay_cb_sort_CheckedChanged(object sender, EventArgs e) { GlobalVariables.Settings.CheckBoxes.FileDisplaySortByCreationDate = fileDisplay_cb_sort.Checked; }
        private void fileDisplay_cb_thumb_CheckedChanged(object sender, EventArgs e) { GlobalVariables.Settings.CheckBoxes.FileDisplayShowThumbnails = fileDisplay_cb_thumb.Checked; }

        private void fileDisplay_watcher_Changed(object sender, FileSystemEventArgs e)
        {
        }
        private void fileDisplay_watcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (Directory.Exists(e.FullPath))
                    {
                        fileDisplay.Items.Add(load_dir_dir(new DirectoryInfo(e.FullPath)));
                        fileDisplay.Items[fileDisplay.Items.Count - 1].EnsureVisible();
                    }
                    else if (File.Exists(e.FullPath))
                    {
                        // add file
                        if (e.Name == "desktop.ini") { return; }
                        fileDisplay.Items.Add(load_dir_file(new FileInfo(e.FullPath)));
                        fileDisplay.Items[fileDisplay.Items.Count - 1].EnsureVisible();
                    }
                });
            }
            catch (Exception) { }
        }
        private void fileDisplay_watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    foreach (ListViewItem lvi in fileDisplay.Items.Find(e.FullPath, true))
                    {
                        lvi.Remove();
                        break;
                    }
                });
            }
            catch (Exception) { }
        }
        private void fileDisplay_watcher_Renamed(object sender, FileSystemEventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (Directory.Exists(e.FullPath))
                    {
                        // remove items that don't exist
                        List<ListViewItem> itemsToRemove = new List<ListViewItem>();
                        foreach (ListViewItem lvi in fileDisplay.Items) { if (!File.Exists(lvi.Name) && !Directory.Exists(lvi.Name)) { itemsToRemove.Add(lvi); } }
                        foreach (ListViewItem lvi in itemsToRemove) { fileDisplay.Items.Remove(lvi); }

                        fileDisplay.Items.Add(load_dir_dir(new DirectoryInfo(e.FullPath)));
                    }
                    else if (File.Exists(e.FullPath))
                    {
                        // remove items that don't exist
                        List<ListViewItem> itemsToRemove = new List<ListViewItem>();
                        foreach (ListViewItem lvi in fileDisplay.Items) { if (!File.Exists(lvi.Name) && !Directory.Exists(lvi.Name)) { itemsToRemove.Add(lvi); } }
                        foreach (ListViewItem lvi in itemsToRemove) { fileDisplay.Items.Remove(lvi); }

                        // add file
                        if (e.Name == "desktop.ini") { return; }
                        fileDisplay.Items.Add(load_dir_file(new FileInfo(e.FullPath)));
                    }
                });
            }
            catch (Exception) { }
        }

        private void fileDisplay_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (clipboard.Contains(e.Item.Name))
            {
                switch (cliboardType)
                {
                    case ClipBoardType.Cut: e.Graphics.FillRectangle(Brushes.Purple, e.Bounds); break;
                    case ClipBoardType.Copy: e.Graphics.FillRectangle(Brushes.MediumBlue, e.Bounds); break;
                }
            }

            e.DrawDefault = true;
        }

        #endregion

        #region ui events

        private void fileDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fileDisplay_open(GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap);
        }
        private void fileDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool fileDisplay_ctrl = false;
        private bool fileDisplay_shift = false;
        private void fileDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            fileDisplay_ctrl = e.Control;
            fileDisplay_shift = e.Shift;

            switch (e.KeyCode)
            {
                case Keys.Escape: fileDisplay_unMarkAll(); e.Handled = e.SuppressKeyPress = true; break;
                case Keys.F5: load_dir(selectedDirPath); e.Handled = e.SuppressKeyPress = true; break;
                case Keys.Enter: fileDisplay_open(false, false); e.Handled = e.SuppressKeyPress = true; break;
                case Keys.Back: fileDisplay_backDir(); e.Handled = e.SuppressKeyPress = true; break;
                case Keys.Delete: fileDisplay_delete(); e.Handled = e.SuppressKeyPress = true; break;
                case Keys.F2: fileDisplay_rename(); e.Handled = e.SuppressKeyPress = true; break;
            }

            if (e.Control)
            {
                e.Handled = e.SuppressKeyPress = true;
                switch (e.KeyCode)
                {
                    case Keys.A: fileDisplay_selectAll(); break;
                    case Keys.R: load_dir_refresh(); break;
                    case Keys.F: if (e.Shift) { new fapmap_find().Show(); } else { fileDisplay_find(); } break;
                    case Keys.E: fileDisplay_explorer(); break;
                    case Keys.T: fileDisplay_explorer2(); break;
                    case Keys.W: fileDisplay_open(true, true); break;
                    case Keys.B: fileDisplay_openInBrowser(); break;
                    case Keys.S: fileDisplay_makeDir(); break;
                    case Keys.Z: fileDisplay_makeFile(); break;
                    case Keys.D: fileDisplay_properties(); break;

                    case Keys.C: if (e.Shift) { fileDisplay_copy_now(); } else { fileDisplay_copy(); } break;
                    case Keys.X: if (e.Shift) { fileDisplay_move_now(); } else { fileDisplay_move(); } break;
                    case Keys.V: fileDisplay_paste(); break;

                    // hidden shortcuts
                    case Keys.G: new fapmap_settings().Show(); break;
                }
            }
        }
        private void fileDisplay_KeyUp(object sender, KeyEventArgs e)
        {
            fileDisplay_ctrl = false;
            fileDisplay_shift = false;
        }
        private void fileDisplay_LostFocus(object sender, System.EventArgs e)
        {
            fileDisplay_ctrl = false;
            fileDisplay_shift = false;
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
        private void fileDisplay_btn_randVideo_Click(object sender, EventArgs e)
        {
            Random_VOI(txt_path.Text, false, true);
        }
        private void fileDisplay_btn_randVideo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Random_VOI(GlobalVariables.Path.Dir.MainFolder, false, true); }
        }

        private void fileDisplay_btn_randImage_Click(object sender, EventArgs e)
        {
            Random_VOI(txt_path.Text, true, true);
        }
        private void fileDisplay_btn_randImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Random_VOI(GlobalVariables.Path.Dir.MainFolder, true, true); }
        }

        private void fileDisplay_btn_info_Click(object sender, EventArgs e)
        {
            fapmap.OpenProperties(txt_path.Text);
        }

        private void fileDisplay_btn_info_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & System.Windows.Forms.DragDropEffects.All) != 0 && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
        }
        private void fileDisplay_btn_info_DragDrop(object sender, DragEventArgs e)
        {
            string data = (e.Data.GetData(typeof(string)) as string);
            string search = data;

            if (Uri.IsWellFormedUriString(search, UriKind.Absolute))
            {
                search = Path.GetFileNameWithoutExtension(new Uri(search).LocalPath);

                if (search == "index" && File.Exists(fapmap.GlobalVariables.Path.File.Exe.WEBGRAB))
                {
                    string args = string.Empty;
                    if      (data.Contains("rule34.xxx"))   { args = "https://img.rule34.xxx//images/"; }
                    else if (data.Contains("gelbooru.com")) { args = "https://img2.gelbooru.com/images/"; }
                    else                                    { return; }

                    Process webgrab = new Process();
                    try
                    {
                        webgrab.StartInfo.UseShellExecute = false;
                        webgrab.StartInfo.RedirectStandardOutput = true;
                        webgrab.StartInfo.RedirectStandardError = true;
                        webgrab.StartInfo.FileName = fapmap.GlobalVariables.Path.File.Exe.WEBGRAB;
                        webgrab.StartInfo.Arguments = "out \"" + data + "\" \"@media,@valid,@nodupes," + args + "\"";
                        webgrab.Start();
                    }
                    catch (Win32Exception) { return; }
                    catch (Exception) { return; }

                    string output = webgrab.StandardOutput.ReadToEnd();
                    webgrab.WaitForExit();

                    string[] lines = output.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        search = Path.GetFileNameWithoutExtension(new Uri(line).LocalPath);
                    }
                }
            }

            new fapmap_find() { pass_input = search }.Show();
        }

        #endregion

        #region change icon size

        private int fileDisplay_sideSize = 150;
        private int fileDisplay_sideSize_min = 50;
        private int fileDisplay_sideSize_max = 255;
        private void fileDisplay_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!fileDisplay_ctrl) { return; }

            int last = fileDisplay_sideSize;
            if (e.Delta > 0) { fileDisplay_sideSize += (fileDisplay_shift ? 60 : 20); }
            else { fileDisplay_sideSize -= (fileDisplay_shift ? 60 : 20); }

            if (fileDisplay_sideSize < fileDisplay_sideSize_min) { fileDisplay_sideSize = fileDisplay_sideSize_min; }
            else if (fileDisplay_sideSize > fileDisplay_sideSize_max) { fileDisplay_sideSize = fileDisplay_sideSize_max; }
            if (fileDisplay_sideSize == last) { return; }

            if (fileDisplay_sideSize == fileDisplay_sideSize_min) { fileDisplay.View = View.Tile; }
            else if (fileDisplay_sideSize > fileDisplay_sideSize_min) { fileDisplay.View = View.LargeIcon; }

            load_dir_cur++; // cancel loading thumbs
            Size s = new Size(fileDisplay_sideSize, fileDisplay_sideSize);
            fileDisplay.Items.Clear();
            fileDisplay_icons.Images.Clear();
            fileDisplay_icons.ImageSize = s;
            for (int i = 0; i < 5; i++)
            {
                string ext = "img";
                int extIndex = fileDisplay_icons.Images.IndexOfKey(ext);
                if (extIndex == -1)
                {
                    fileDisplay_icons.Images.Add(ext, Properties.Resources.image);
                    extIndex = fileDisplay_icons.Images.Count - 1;
                }

                ListViewItem lvi = new ListViewItem() { Name = "", Text = "ITEM [" + (i + 1).ToString() + "]", ImageIndex = extIndex };
                fileDisplay.Items.Add(lvi);
            }
        }

        #endregion

        #region RMB

        private void fileDisplay_RMB_refresh_Click(object sender, EventArgs e)
        {
            load_dir_refresh();
        }
        private void fileDisplay_RMB_reload_Click(object sender, EventArgs e)
        {
            load_dir(selectedDirPath);
        }
        private void fileDisplay_RMB_selectAll_Click(object sender, EventArgs e)
        {
            fileDisplay_selectAll();
        }
        private void fileDisplay_RMB_unmark_Click(object sender, EventArgs e)
        {
            fileDisplay_unMarkAll();
        }
        private void fileDisplay_RMB_find_Click(object sender, EventArgs e)
        {
            fileDisplay_find();
        }
        private void fileDisplay_RMB_open_Click(object sender, EventArgs e)
        {
            fileDisplay_open(true, true);
        }
        private void fileDisplay_RMB_openInBrowser_Click(object sender, EventArgs e)
        {
            fileDisplay_openInBrowser();
        }
        private void fileDisplay_RMB_explorer_Click(object sender, EventArgs e)
        {
            fileDisplay_explorer();
        }
        private void fileDisplay_RMB_explorer2_Click(object sender, EventArgs e)
        {
            fileDisplay_explorer2();
        }
        private void fileDisplay_RMB_makeDir_Click(object sender, EventArgs e)
        {
            fileDisplay_makeDir();
        }
        private void fileDisplay_RMB_makeFile_Click(object sender, EventArgs e)
        {
            fileDisplay_makeFile();
        }
        private void fileDisplay_RMB_copy_Click(object sender, EventArgs e)
        {
            fileDisplay_copy();
        }
        private void fileDisplay_RMB_copyNow_Click(object sender, EventArgs e)
        {
            fileDisplay_copy_now();
        }
        private void fileDisplay_RMB_move_Click(object sender, EventArgs e)
        {
            fileDisplay_move();
        }
        private void fileDisplay_RMB_moveNow_Click(object sender, EventArgs e)
        {
            fileDisplay_move_now();
        }
        private void fileDisplay_RMB_paste_Click(object sender, EventArgs e)
        {
            fileDisplay_paste();
        }
        private void fileDisplay_RMB_rename_Click(object sender, EventArgs e)
        {
            fileDisplay_rename();
        }
        private void fileDisplay_RMB_delete_Click(object sender, EventArgs e)
        {
            fileDisplay_delete();
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
            faftv_n_fileDisplay_dragNdrop(selectedDirPath, e);
        }

        #endregion

        #endregion

        #endregion

        /// TODO: clean 'media' code
        #region media

        #region functions

        private void media_close()
        {
            media_remove(true);
        }
        private bool media_isRemoved = false;
        private void media_remove(bool hide = true)
        {
            if (!media_isRemoved)
            {
                // remove title
                showMedia_video_title.BackgroundImage = null;
                showMedia_image_title.BackgroundImage = null;

                showMedia_image_ctrlbox.Visible = false;
                showMedia_image.Size = new System.Drawing.Size(showMedia_image.Size.Width, showMedia_image_panel.Size.Height - 34);
                showMedia_image_gif_frames = null;
                showMedia_image_gif_timer.Enabled = false;
                showMedia_image.CancelAsync();
                showMedia_image.Image = showMedia_image.BackgroundImage = new Bitmap(16, 16);

                showMedia_video.currentPlaylist.clear();
                showMedia_video.URL = null;
                showMedia_video.close();
                GC.Collect();

                media_isRemoved = true;
            }

            if (hide)
            {
                showMedia_video_panel.Visible = false;
                showMedia_image_panel.Visible = false;
            }
        }
        private void media_echo(string path, Panel contrl)
        {
            string text = string.Empty;

            if (File.Exists(path))
            {
                text = Directory.GetParent(path).Name + "\\" + new FileInfo(path).Name;
            }
            else if (isURLMediaFile(path))
            {
                text = path;
            }

            Bitmap bmp = new Bitmap(text.Length * 8, 20);

            //graphics
            Graphics g = Graphics.FromImage(bmp);

            //clear graphics
            g.Clear(Color.Transparent);

            g.DrawString(text, new Font("Consolas", 10), Brushes.SkyBlue, new PointF(0, 0));

            contrl.BackgroundImage = bmp;
            contrl.BackgroundImageLayout = ImageLayout.Center;
        }

        private void showMedia_close(object sender, EventArgs e)
        {
            media_close();
        }
        private void showMedia_open()
        {
            OpenFile(selectedFilePath);
        }
        private void showMedia_move()
        {
            if (!File.Exists(selectedFilePath)) { return; }

            media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers);

            FileInfo fi = new FileInfo(selectedFilePath);
            string dir = OpenPathSelector(this, fi.Directory.FullName);
            if (!string.IsNullOrEmpty(dir) && Directory.Exists(dir))
            {
                fapmap.MoveFile(selectedFilePath, new DirectoryInfo(dir).FullName + "\\" + fi.Name);
            }
        }
        private void showMedia_explorer()
        {
            OpenInExplorer(selectedFilePath);
        }
        private void showMedia_explorer2()
        {
            OpenAndSelectInExplorer(selectedFilePath);
        }
        private void showMedia_convert()
        {
            media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers);
            new fapmap_ffmpeg() { pass_path = selectedFilePath }.Show();
        }
        private void showMedia_trash()
        {
            media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers);
            fapmap.TrashFile(selectedFilePath);
        }
        private void showMedia_info()
        {
            OpenProperties(selectedFilePath);
        }

        private bool Random_Busy = false;
        private void Random_VOI(string path, bool isImage, bool IsInside = true)
        {
            if (!Random_Busy)
            {
                Random_Busy = true;
                media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers);

                List<string> TYPES = isImage ? GlobalVariables.Settings.Media.FileTypes.Image : GlobalVariables.Settings.Media.FileTypes.Video;
                if (string.IsNullOrEmpty(path)) { path = GlobalVariables.Path.Dir.MainFolder; }
                if (File.Exists(path)) { path = new FileInfo(path).Directory.FullName; }

                List<string> all_files = new List<string>();
                foreach (string type in TYPES) //run through each type
                {
                    if (type.StartsWith("*.")) { all_files.AddRange(Directory.GetFiles(path, type, SearchOption.AllDirectories)); }
                    else if (type.StartsWith(".")) { all_files.AddRange(Directory.GetFiles(path, "*" + type, SearchOption.AllDirectories)); }
                    else { all_files.AddRange(Directory.GetFiles(path, "*." + type, SearchOption.AllDirectories)); }
                }

                if (all_files.Count == 0)
                {
                    fapmap_echo("Can't find random file...");
                    Random_Busy = false;
                    return;
                }

                string randFile = all_files[new Random().Next(0, all_files.Count - 1)];
                if (!IsInside || GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap) { fapmap.Open(randFile); }
                else { load_file_or_dir(randFile); }
                Random_Busy = false;
            }
        }

        private void openURL(string url)
        {
            if (File.Exists(url)) { load_file_or_dir(url); return; }
            if (media_playUrl(url)) { return; }
            Incognito(url);
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            txt_url.Text = e.Url.AbsoluteUri;
        }

        #endregion

        #region ui events

        // RMB
        private void showMedia_RMB_openFile_Click(object sender, EventArgs e)
        {
            showMedia_open();
        }
        private void showMedia_RMB_moveTo_Click(object sender, EventArgs e)
        {
            showMedia_move();
        }
        private void showMedia_RMB_explorer_Click(object sender, EventArgs e)
        {
            showMedia_explorer();
        }
        private void showMedia_RMB_explorer2_Click(object sender, EventArgs e)
        {
            showMedia_explorer2();
        }
        private void showMedia_RMB_convert_Click(object sender, EventArgs e)
        {
            showMedia_convert();
        }
        private void showMedia_RMB_trashFile_Click(object sender, EventArgs e)
        {
            showMedia_trash();
        }
        private void showMedia_RMB_info(object sender, EventArgs e)
        {
            showMedia_info();
        }

        // dock/fill/fullscreen players
        private Point showMedia_image_lastPos, showMedia_video_lastPos;
        private Size showMedia_image_lastSize, showMedia_video_lastSize;
        private void showMedia_dock_sw()
        {
            showMedia_dock(!showMedia_docked);
        }
        private bool showMedia_docked = false;
        private void showMedia_dock(bool dock)
        {
            if (dock) //DOCK
            {
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
        // dock events
        private void showMedia_image_title_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { showMedia_dock_sw(); }
        }
        private void showMedia_video_title_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { showMedia_dock_sw(); }
        }

        #endregion

        #region move and resize showMedia_image

        private Point showMedia_image_startDraggingPoint;
        private Size showMedia_image_startSize;
        private Rectangle showMedia_image_rectProposedSize = Rectangle.Empty;

        // move (title)
        private void showMedia_image_title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!showMedia_docked)
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
                if (!showMedia_docked)
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
                if (!showMedia_docked)
                {
                    if (showMedia_image_panel != null)
                    {
                        try
                        {
                            //set image player Location
                            showMedia_video_panel.Location = showMedia_image_panel.Location;
                        }
                        catch (System.NullReferenceException) { }
                        catch (System.Exception) { }
                    }
                }
            }
        }

        // resize (panel)
        private void showMedia_image_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!showMedia_docked)
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
                if (!showMedia_docked)
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
                if (!showMedia_docked)
                {
                    if (showMedia_image_panel != null)
                    {
                        try
                        {
                            //set image player Size
                            showMedia_video_panel.Size = showMedia_image_panel.Size;
                        }
                        catch (System.NullReferenceException) { }
                        catch (System.Exception) { }
                    }
                }
            }
        }

        #endregion

        #region move and resize showMedia_video

        private Point showMedia_video_startDraggingPoint;
        private Size showMedia_video_startSize;
        private Rectangle showMedia_video_rectProposedSize = Rectangle.Empty;

        // move (title)
        private void showMedia_video_title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!showMedia_docked)
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
                if (!showMedia_docked)
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
                if (!showMedia_docked)
                {
                    if (showMedia_video_panel != null)
                    {
                        try
                        {
                            //set image player Location
                            showMedia_image_panel.Location = showMedia_video_panel.Location;
                        }
                        catch (System.NullReferenceException) { }
                        catch (System.Exception) { }
                    }
                }
            }
        }

        // resize (panel)
        private void showMedia_video_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!showMedia_docked)
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
                if (!showMedia_docked)
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
                if (!showMedia_docked)
                {
                    if (showMedia_video_panel != null)
                    {
                        try
                        {
                            //set image player Size
                            showMedia_image_panel.Size = showMedia_video_panel.Size;
                        }
                        catch (System.NullReferenceException) { }
                        catch (System.Exception) { }
                    }
                }
            }
        }

        #endregion

        #region IMAGE / GIF VIEWER

        Bitmap[] showMedia_image_gif_frames = null;
        private void showMedia_image_gif_timer_Tick(object sender, EventArgs e)
        {
            if (showMedia_image_gif_timer.Interval != GlobalVariables.Settings.Media.GifDelay)
            { showMedia_image_gif_timer.Interval = GlobalVariables.Settings.Media.GifDelay; }

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
        private void showMedia_image_gif_playNpause()
        {
            if (!showMedia_image_gif_timer.Enabled)
            {
                showMedia_image_gif_timer.Enabled = true;
                showMedia_image_gif_playBTN.BackgroundImage = Properties.Resources.pause;
                showMedia_image_gif_paused = false;
            }
            else
            {
                showMedia_image_gif_timer.Enabled = false;
                showMedia_image_gif_playBTN.BackgroundImage = Properties.Resources.play;
                showMedia_image_gif_paused = true;
            }
        }
        private void showMedia_image_gif_trackbar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                showMedia_image_gif_playNpause();
            }
        }
        private void showMedia_image_gif_playBTN_Click(object sender, EventArgs e)
        {
            showMedia_image_gif_playNpause();
        }

        private void showMedia_image_gifbox(bool show)
        {
            if (show) //show
            {
                showMedia_image_gif_trackbar.Maximum = showMedia_image_gif_frames.Length - 1;
                showMedia_image_gif_trackbar.ScaleDivisions = showMedia_image_gif_frames.Length - 2;
                showMedia_image_gif_trackbar.Value = 1;
                showMedia_image.Image = showMedia_image_gif_frames[showMedia_image_gif_trackbar.Value - 1];

                showMedia_image_gif_frame.Text = showMedia_image_gif_trackbar.Value + " / " + showMedia_image_gif_trackbar.Maximum;
                showMedia_image_ctrlbox.Visible = true;
                showMedia_image.Size = new System.Drawing.Size(showMedia_image.Size.Width, showMedia_image_panel.Size.Height - showMedia_image_title.Size.Height - showMedia_image_ctrlbox.Height - (showMedia_image_panel.Size.Width - showMedia_image.Size.Width));
                showMedia_image_panel.Visible = true;
                showMedia_image_panel.BringToFront();

                if (!showMedia_image_gif_paused) { showMedia_image_gif_timer.Enabled = true; }
            }
            else //hide
            {
                showMedia_image_ctrlbox.Visible = false;
                showMedia_image.Size = new System.Drawing.Size(showMedia_image.Size.Width, showMedia_image_panel.Size.Height - showMedia_image_title.Size.Height - (showMedia_image_panel.Size.Width - showMedia_image.Size.Width));
            }
        }

        private string showMedia_image_URL = string.Empty;
        private void showMedia_image_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            showMedia_image_pb.Value = e.ProgressPercentage;
        }
        private void showMedia_image_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled) { return; }

            showMedia_image_pb.Visible = false;
            if (GlobalVariables.Settings.CheckBoxes.EnableTrackbarForGifViewer && showMedia_image_URL.ToLower().Contains(".gif")) //GIF VIEWER
            {
                bool gif_is_valid = true;

                try
                {
                    showMedia_image_gif_frames = getGifFrames(showMedia_image.Image);
                }
                catch (OutOfMemoryException) { gif_is_valid = false; }
                catch (Exception) { gif_is_valid = false; }

                if (gif_is_valid)
                {
                    showMedia_image_gifbox(true);

                    LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, showMedia_image_URL);
                    media_isRemoved = false;

                    return;
                }
            }

            showMedia_image_gifbox(false);
            LogThis(fapmap.GlobalVariables.LOG_TYPE.PLAY, showMedia_image_URL);
            media_isRemoved = false;
        }

        private void showMedia_image_skip_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left: Random_VOI(txt_path.Text, true, true); break;
                case MouseButtons.Right: Random_VOI(GlobalVariables.Path.Dir.MainFolder, true, true); showMedia_image_RMB.Hide(); ; break;
            }
        }
        /// TODO: ADD IMAGE UNDO (priv)

        #endregion

        #region Video Player

        // change time in player
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
            //showMedia_video_ctrlsPanel_pos_cur.ForeColor = Color.MediumPurple;
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

        // fast forward
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

        // reverse
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

        // core
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
                catch (Exception) { }
            }


        }
        private void showMedia_video_PlayStateChange_clear()
        {
            drawAudioThread_maxPeak = 0;
            showMedia_video_ctrlsPanel_pos_timer.Stop();
            showMedia_video_ctrlsPanel_pos.Maximum = 1;
            showMedia_video_ctrlsPanel_pos.Minimum = 0;
            showMedia_video_ctrlsPanel_pos.Value = 0;
            showMedia_video_ctrlsPanel_pos.Enabled = false;
            showMedia_video_ctrlsPanel_pos_cur.Text = "00:00:00";
            showMedia_video_ctrlsPanel_pos_max.Text = "00:00:00";
        }
        private int showMedia_video_ctrlsPanel_pos_times = 100;
        private void showMedia_video_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            //media player control's playstate change event handler
            if (showMedia_video.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                showMedia_video_ctrlsPanel_pos.Enabled = true;
                showMedia_video_ctrlsPanel_pos.Maximum = (int)(showMedia_video.Ctlcontrols.currentItem.duration * showMedia_video_ctrlsPanel_pos_times);
                showMedia_video_ctrlsPanel_pos_max.Text =
                    showMedia_video.Ctlcontrols.currentItem.durationString.Length == 5 ?
                        ("00:" + showMedia_video.Ctlcontrols.currentItem.durationString)
                    :
                        showMedia_video.Ctlcontrols.currentItem.durationString;

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
                showMedia_video_PlayStateChange_clear();
            }

            if (showMedia_video.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                showMedia_video_PlayStateChange_clear();

                // play next
                if (!showMedia_video_RMB_repeat.Checked)
                {
                    // random or playlist
                    if (showMedia_video_RMB_autoRand_main.Checked) { Random_VOI(GlobalVariables.Path.Dir.MainFolder, false, true); }
                    else if (showMedia_video_RMB_autoRand_dir.Checked) { Random_VOI(txt_path.Text, false, true); }
                    else if (video_playlist_enabled) { playlist_update(-1); }
                }
            }

            if (!this_selected && GlobalVariables.Settings.CheckBoxes.AutoPauseVideoPlayer)
            {
                showMedia_video.Ctlcontrols.pause();
            }
            else
            {
                if (showMedia_video.playState == WMPLib.WMPPlayState.wmppsReady && showMedia_video_panel.Visible && GlobalVariables.Settings.CheckBoxes.AutoPlayVideoPlayer)
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
                showMedia_video_RMB.Show(Cursor.Position); // showMedia_video.Ctlcontrols.stop(); //replaced with contextmenustrip
            }
        }
        private void showMedia_video_sound_ValueChanged(object sender, EventArgs e)
        {
            showMedia_video.settings.volume = showMedia_video_sound.Value;
            HelpBalloon.SetToolTip(showMedia_video_sound, "Player Volume (" + showMedia_video_sound.Value + "%)");
        }

        // RMB checkboxes
        private void showMedia_video_RMB_repeat_CheckedChanged(object sender, EventArgs e)
        {
            showMedia_video.settings.setMode("loop", showMedia_video_RMB_repeat.Checked);
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
        private void showMedia_video_fit_CheckedChanged(object sender, EventArgs e)
        {
            showMedia_video.stretchToFit = showMedia_video_fit.Checked;
        }

        // PRIV & NEXT
        private void showMedia_video_skip_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left: if (video_playlist_enabled) { playlist_update(-1); } else { Random_VOI(txt_path.Text, false, true); } break;
                case MouseButtons.Right: Random_VOI(GlobalVariables.Path.Dir.MainFolder, false, true); break;
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
                    load_file_or_dir(selectedFilePath);
                }
            }
        }

        #region Draw Audio

        // change max
        private bool changeMaxAuto = true;
        private bool drawAudioThread_maxPeakLabel_holding = false;
        private Point drawAudioThread_maxPeakLabel_holdStartPoint = new Point();
        private void drawAudioThread_maxPeakLabel_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        drawAudioThread_maxPeakLabel_holdStartPoint = new Point(e.X, e.Y);
                        drawAudioThread_maxPeakLabel_holding = true;
                        break;
                    }
                case MouseButtons.Right:
                    {
                        changeMaxAuto = !changeMaxAuto;
                        drawAudioThread_maxPeakLabel.ForeColor = changeMaxAuto ? Color.MediumPurple : Color.MediumSlateBlue;

                        break;
                    }
            }
        }
        private void drawAudioThread_maxPeakLabel_MouseMove(object sender, MouseEventArgs e)
        {

            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        if (drawAudioThread_maxPeakLabel_holding)
                        {
                            if (e.Y < drawAudioThread_maxPeakLabel_holdStartPoint.Y)
                            {
                                // increase max
                                float copy = drawAudioThread_maxPeak;
                                copy += 0.01f;
                                if (copy < 0.01f) { copy = 0.01f; }
                                if (copy > 2.0f) { copy = 2.0f; }
                                drawAudioThread_maxPeak = copy;

                                drawAudioThread_maxPeakLabel_holdStartPoint = new Point(e.X, e.Y);
                            }
                            else if (e.Y > drawAudioThread_maxPeakLabel_holdStartPoint.Y)
                            {
                                // decrease max
                                float copy = drawAudioThread_maxPeak;
                                copy -= 0.01f;
                                if (copy < 0.01f) { copy = 0.01f; }
                                if (copy > 2.0f) { copy = 2.0f; }
                                drawAudioThread_maxPeak = copy;

                                drawAudioThread_maxPeakLabel_holdStartPoint = new Point(e.X, e.Y);
                            }
                        }

                        break;
                    }

            }
        }
        private void drawAudioThread_maxPeakLabel_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left: drawAudioThread_maxPeakLabel_holding = false; break;
            }
        }
        private float drawAudioThread_maxPeak_;
        private float drawAudioThread_maxPeak
        {
            get { return drawAudioThread_maxPeak_; }
            set
            {
                drawAudioThread_maxPeak_ = value;
                this.Invoke((MethodInvoker)delegate
                {
                    drawAudioThread_maxPeakLabel.Text = Math.Round(drawAudioThread_maxPeak_ * 100, 2).ToString();
                });
            }
        }

        // draw audio
        private void drawAudioThread()
        {
            int id = Process.GetCurrentProcess().Id;
            fapmap_res.DirectBitmap drawGraphBMP = new fapmap_res.DirectBitmap(160, 80);

            using (var enumerator = new CSCore.CoreAudioAPI.MMDeviceEnumerator())
            using (var device = enumerator.GetDefaultAudioEndpoint(CSCore.CoreAudioAPI.DataFlow.Render, CSCore.CoreAudioAPI.Role.Multimedia))
            using (var sessionEnumerator = CSCore.CoreAudioAPI.AudioSessionManager2.FromMMDevice(device).GetSessionEnumerator())
            {
                while (true)
                {
                    Thread.Sleep(25);

                    foreach (var session in sessionEnumerator)
                    {
                        using (var session2 = session.QueryInterface<CSCore.CoreAudioAPI.AudioSessionControl2>())
                        {
                            if (session2.ProcessID != id) { continue; }
                        }

                        using (var audioMeterInformation = session.QueryInterface<CSCore.CoreAudioAPI.AudioMeterInformation>())
                        {
                            float curr = audioMeterInformation.GetPeakValue();
                            if (curr <= 0) { continue; }

                            if (changeMaxAuto && curr > drawAudioThread_maxPeak) { drawAudioThread_maxPeak = curr; }

                            drawGraphLine(curr, 10, drawAudioThread_maxPeak, drawGraphBMP, Color.DeepPink, Color.SlateBlue);
                            this.Invoke((MethodInvoker)delegate
                            {
                                showMedia_video_audioPanel.BackgroundImage = new Bitmap(drawGraphBMP.Bitmap);
                            });
                        }

                        break;
                    }
                }
            }
        }
        private void drawGraphLine(float curr, int minPx, float max, fapmap_res.DirectBitmap bmp, Color c1, Color c2)
        {
            try
            {
                //new input
                using (var g = Graphics.FromImage(bmp.Bitmap))
                {
                    float pbUnit = bmp.Height / max;
                    float val = curr * pbUnit;

                    int point1 = bmp.Height - ((int)val + minPx);

                    Point p1 = new Point(0, 0);
                    Point p2 = new Point(0, bmp.Height - 1);

                    using (Brush aGradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(p1, p2, c1, c2))
                    {
                        g.DrawLine(new Pen(aGradientBrush), p1, p2);
                    }

                    g.DrawLine(new Pen(Color.FromArgb(15, 15, 15)), new Point(0, 0), new Point(0, point1 < 0 ? 0 : point1));
                }

                fapmap_res.DirectBitmap copy = new fapmap_res.DirectBitmap(bmp.Width, bmp.Height);
                using (var g = Graphics.FromImage(copy.Bitmap)) { g.DrawImage(bmp.Bitmap, new PointF(0, 0)); }
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        if (x != bmp.Width - 1)
                        {
                            bmp.SetPixel(x + 1, y, copy.GetPixel(x, y));
                        }
                    }
                }
                copy.Dispose();

                for (int y = 0; y < bmp.Height; y++)
                {
                    bmp.SetPixel(0, y, Color.Transparent);
                }

            }
            catch (Exception) { }
        }

        #endregion

        #region video - playlist

        private List<string> video_playlist = new List<string>();
        private bool video_playlist_enabled = false;
        private int video_playlist_current = -1;
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
        private void video_playlist_create(string path, bool only, string only_str, bool nologs, bool random, bool reverse)
        {
            if (!video_playlist_create_busy)
            {
                video_playlist_create_busy = true;

                this.Invoke((MethodInvoker)delegate
                {
                    HelpBalloon.SetToolTip(showMedia_video_undo, "Previous file");
                    showMedia_video_undo.BackgroundImage = Properties.Resources.arrow_left;
                });

                if (File.Exists(path)) { path = Directory.GetParent(path).ToString(); }

                //ECHO
                //this.Text = "FAPMAP: Playlist[...]";

                //clear playlist
                video_playlist.Clear();

                //GET VIDEO FILES
                List<string> all_files = new List<string>();
                foreach (string type in GlobalVariables.Settings.Media.FileTypes.Video)
                {
                    all_files.AddRange(Directory.GetFiles(path, "*" + type, SearchOption.AllDirectories));
                }

                //no files
                if (all_files.Count == 0)
                {
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
                    string[] logLines = fapmap.SafeReadLines(GlobalVariables.Path.File.Log).ToArray();
                    List<string> playedFiles = new List<string>();
                    foreach (string line in logLines)
                    {
                        string[] index = line.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
                        if (index.Length == 3) { if (index[1] == fapmap.GlobalVariables.LOG_TYPE.PLAY) { playedFiles.Add(index[2]); } }
                    }
                    playedFiles = playedFiles.Distinct().ToList(); // remove dupes


                    List<string> newFiles = new List<string>();
                    foreach (string file in all_files)
                    {
                        if (!playedFiles.Contains(file)) { newFiles.Add(file); }
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

                if (random) { shuffleListString(all_files); }
                if (reverse) { all_files.Reverse(); }

                //ENABLE
                video_playlist_enabled = true;

                //set new files to playlist
                video_playlist = all_files;

                //set
                //this.Text = "FAPMAP: Playlist[" + (video_playlist_current + 1).ToString() + "/" + video_playlist.Count + "]";

                this.Invoke((MethodInvoker)delegate
                {
                    HelpBalloon.SetToolTip(showMedia_video_skip, "Next File");
                });

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

        private void showMedia_video_RMB_playList_make_CheckedChanged(object sender, EventArgs e)
        {
            if (showMedia_video_RMB_playList_make.Checked)
            {
                fapmap_playlist fp = new fapmap_playlist() { path = txt_path.Text };

                if (fp.ShowDialog(this) == DialogResult.OK)
                {
                    video_playlist_create(fp.path, fp.keyword, fp.keyword_str, fp.rmlogs, fp.random, fp.reverse);
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
        private void showMedia_video_RMB_playList_skip_Click(object sender, EventArgs e)
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

        #endregion

        #endregion

        #region txt_path

        private void txt_path_TextChanged(object sender, EventArgs e)
        {
            if (txt_path.Text.Contains("\n")) { txt_path.Text = txt_path.Text.Replace("\n", String.Empty); }
            if (txt_path.Text.Contains("\r")) { txt_path.Text = txt_path.Text.Replace("\r", String.Empty); }
            if (txt_path.Text.Contains("\t")) { txt_path.Text = txt_path.Text.Replace("\t", String.Empty); }

            txt_path.ForeColor = (File.Exists(txt_path.Text) || Directory.Exists(txt_path.Text)) ? Color.HotPink : Color.Magenta;

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
            string str = string.Empty;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string f in files)
                {
                    str = f;
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                str = e.Data.GetData(DataFormats.StringFormat).ToString();
            }

            if (!string.IsNullOrEmpty(str))
            {
                load_file_or_dir(str);
            }
        }
        private void txt_path_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            }
            else if (e.Data.GetDataPresent(DataFormats.StringFormat))
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

            DirectoryInfo[] dirs = di.GetDirectories();
            FileInfo[] files = di.GetFiles();

            if (GlobalVariables.Settings.CheckBoxes.TreeViewSortByCreationDate)
            {
                dirs = dirs.OrderBy(p => p.CreationTime).ToArray();
                files = files.OrderBy(p => p.CreationTime).ToArray();
            }

            int itemsCount = dirs.Length + files.Length;
            int pad = itemsCount.ToString().Length;

            foreach (DirectoryInfo directory in dirs)
            {
                faftv_setImage(directory.FullName == GlobalVariables.Path.Dir.MainFolder ? "main" : "dir", node_dir);
                node_dir.Nodes.Add(faftv_CreateDirectoryNode(directory));

                if (GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex)
                {
                    node_dir.Nodes[node_dir.Nodes.Count - 1].Text = (node_dir.Nodes.Count).ToString().PadLeft(pad, '0') + ". " + directory.Name;
                }
            }

            foreach (FileInfo file in files)
            {
                if (file.Name == "desktop.ini") { continue; }

                TreeNode node_file = new TreeNode()
                {
                    Text =
                    (GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex ? (node_dir.Nodes.Count + 1).ToString().PadLeft(pad, '0') + ". " : "")
                    + file.Name,
                    Name = file.FullName,
                    ToolTipText = ROund(file.Length) + " (" + file.Length + " bytes)",
                };
                faftv_setImage(file.Extension.ToLower(), node_file);
                node_dir.Nodes.Add(node_file);
            }

            return node_dir;
        }
        private void faftv_setImage(string ext, TreeNode node_file)
        {
            string key = ext.ToLower();

            if (key == "dir") { node_file.ImageIndex = node_file.SelectedImageIndex = 0; return; }

            if (File.Exists(node_file.Name))
            {
                FileInfo fi = new FileInfo(node_file.Name);
                if (key == ".exe") { key = fapmap.getFileId(fi).ToString(); }

                int imageIndex = faftv_icons.Images.IndexOfKey(key);
                if (imageIndex == -1)
                {
                    faftv_icons.Images.Add(key, System.Drawing.Icon.ExtractAssociatedIcon(node_file.Name));
                    imageIndex = faftv_icons.Images.Count - 1;
                }

                node_file.ImageIndex = node_file.SelectedImageIndex = imageIndex;
            }
        }

        // update treeview for changes
        List<TreeNode> faftv_checkNode_nodesToRemove = new List<TreeNode>();
        private void faftv_checkNode(TreeNode tn)
        {
            if (tn == null) { return; }
            if (!File.Exists(tn.Name) && !Directory.Exists(tn.Name)) { faftv_checkNode_nodesToRemove.Add(tn); }

            if (Directory.Exists(tn.Name))
            {
                foreach (string dir in Directory.GetDirectories(tn.Name))
                {
                    if (!tn.Nodes.ContainsKey(dir))
                    {
                        TreeNode newNode = new TreeNode() { Text = new DirectoryInfo(dir).Name, Name = dir };
                        faftv_setImage("dir", newNode);
                        tn.Nodes.Add(newNode);
                    }
                }

                foreach (string file in Directory.GetFiles(tn.Name))
                {
                    if (!tn.Nodes.ContainsKey(file))
                    {
                        TreeNode newNode = new TreeNode() { Text = Path.GetFileName(file), Name = file };
                        faftv_setImage(Path.GetExtension(file).ToLower(), newNode);
                        tn.Nodes.Add(newNode);
                    }
                }
            }

            foreach (TreeNode t in tn.Nodes) { faftv_checkNode(t); }
        }
        private void faftv_refresh()
        {
            nestFiles();
            foreach (TreeNode tn in faftv.Nodes) { faftv_checkNode(tn); }
            foreach (TreeNode tn in faftv_checkNode_nodesToRemove) { tn.Remove(); }
            faftv_checkNode_nodesToRemove = new List<TreeNode>();
            faftv.Refresh();
        }
        private FileSystemWatcher faftv_watcher = new FileSystemWatcher();
        private void faftv_reload()
        {
            if (!GlobalVariables.Settings.CheckBoxes.EnableFaftv) { faftv.Enabled = false; return; }
            faftv.Enabled = true;

            fapmap_echo("");
            nestFiles();
            faftv.Nodes.Clear();
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
        private void faftv_collapse()
        {
            faftv.CollapseAll();
        }
        private void faftv_expand()
        {
            faftv.ExpandAll();
        }
        private void faftv_startFile(bool openDirs = false)
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }

            if (openDirs && Directory.Exists(path)) { fapmap.OpenInExplorer(path); }
            else if (File.Exists(path))
            {
                if (new FileInfo(path).Name.Contains("fapmap_mod")) { OpenScript(this, path); }
                else { if (fapmap.Open(path)) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); } }
            }
        }
        private void faftv_openInBrowser()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }
            OpenInBrowser(path);
        }
        private void faftv_move()
        {
            cliboardType = ClipBoardType.Cut;
            faftv_clip();
        }
        private void faftv_copy()
        {
            cliboardType = ClipBoardType.Copy;
            faftv_clip();
        }
        private void faftv_clip()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }

            if (clipboard.Contains(path)) { clipboard.Remove(path); }
            else { clipboard.Add(path); }

            faftv_N_fileDisplay_refresh();
        }
        private void faftv_paste()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }

            if (File.Exists(path)) { path = Directory.GetParent(path).FullName; }
            if (!Directory.Exists(path)) { return; }

            clipboard_paste(path);
        }
        private void faftv_unMarkAll()
        {
            faftv.SelectedNode = null;

            clipboard_clear();
            faftv_N_fileDisplay_refresh();
        }
        private void faftv_move_now()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }

            if (Directory.Exists(path))
            {
                if (selectedFilePath.Contains(path)) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); }

                DirectoryInfo di = new DirectoryInfo(path);
                string dir = fapmap.OpenPathSelector(this, di.Parent.FullName);
                if (!string.IsNullOrEmpty(dir) && Directory.Exists(path) && Directory.Exists(dir))
                {
                    fapmap.MoveDir(path, new DirectoryInfo(dir).FullName + "\\" + di.Name);
                }
            }
            else if (File.Exists(path))
            {
                if (selectedFilePath == path) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); }

                FileInfo fi = new FileInfo(path);
                string dir = fapmap.OpenPathSelector(this, fi.Directory.FullName);
                if (!string.IsNullOrEmpty(dir) && Directory.Exists(dir))
                {
                    fapmap.MoveFile(path, new DirectoryInfo(dir).FullName + "\\" + fi.Name);
                }
            }
        }
        private void faftv_copy_now()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }

            if (Directory.Exists(path))
            {
                if (selectedFilePath.Contains(path)) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); }

                DirectoryInfo di = new DirectoryInfo(path);
                string dir = fapmap.OpenPathSelector(this, di.Parent.FullName);
                if (!string.IsNullOrEmpty(dir) && Directory.Exists(path) && Directory.Exists(dir))
                {
                    fapmap.CopyDir(path, new DirectoryInfo(dir).FullName + "\\" + di.Name);
                }
            }
            else if (File.Exists(path))
            {
                if (selectedFilePath == path) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); }

                FileInfo fi = new FileInfo(path);
                string dir = fapmap.OpenPathSelector(this, fi.Directory.FullName);
                if (!string.IsNullOrEmpty(dir) && Directory.Exists(dir))
                {
                    fapmap.CopyFile(path, new DirectoryInfo(dir).FullName + "\\" + fi.Name);
                }
            }
        }
        private void faftv_delete()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }

            if (Directory.Exists(path))
            {
                if (selectedFilePath.Contains(path)) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); }
                if (fapmap.TrashDir(path)) { faftv.SelectedNode.Remove(); }
            }
            else if (File.Exists(path))
            {
                if (selectedFilePath == path) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); }
                if (fapmap.TrashFile(path)) { faftv.SelectedNode.Remove(); }
            }
        }
        private void faftv_makeDir()
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
        private void faftv_makeFile()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }

            if (File.Exists(path)) { path = Directory.GetParent(path).FullName; }
            if (!Directory.Exists(path)) { return; }

            string input = fapmap.OpenInputBox(this, "Create New File in: " + new DirectoryInfo(path).Name, "NewTextFile.txt", 0, "NewTextFile".Length);
            if (!string.IsNullOrEmpty(input))
            {
                fapmap.CreateFile(new DirectoryInfo(path).FullName + "\\" + input);
            }
        }
        private void faftv_rename()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }

            if (Directory.Exists(path))
            {
                if (selectedFilePath.Contains(path)) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); }

                DirectoryInfo di_src = new DirectoryInfo(path);
                string input = fapmap.OpenInputBox(this, "Rename folder?", di_src.Name, 0, di_src.Name.Length);
                if (!string.IsNullOrEmpty(input))
                {
                    fapmap.MoveDir(di_src.FullName, di_src.Parent.FullName + "\\" + input);
                }
            }
            else if (File.Exists(path))
            {
                if (selectedFilePath == path) { media_remove(GlobalVariables.Settings.CheckBoxes.EnableMediaPlayers); }

                FileInfo fi_src = new FileInfo(path);
                string input = fapmap.OpenInputBox(this, "Rename file?", fi_src.Name, 0, fi_src.Name.Length - fi_src.Extension.Length);
                if (!string.IsNullOrEmpty(input))
                {
                    fapmap.MoveFile(fi_src.FullName, fi_src.Directory.FullName + "\\" + input);
                }
            }
        }
        private void faftv_explorer()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }
            OpenInExplorer(path);
        }
        private void faftv_explorer2()
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }
            OpenAndSelectInExplorer(path);
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

        private void faftv_cb_sort_CheckedChanged(object sender, EventArgs e) { GlobalVariables.Settings.CheckBoxes.TreeViewSortByCreationDate = faftv_cb_sort.Checked; }
        private void faftv_cb_index_CheckedChanged(object sender, EventArgs e) { GlobalVariables.Settings.CheckBoxes.TreeViewShowItemIndex = faftv_cb_index.Checked; }

        private void faftv_watcher_Changed(object sender, FileSystemEventArgs e)
        {

        }
        private void faftv_watcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (Directory.Exists(e.FullPath))
                    {
                        DirectoryInfo di = new DirectoryInfo(e.FullPath);
                        foreach (TreeNode t in faftv.Nodes.Find(di.Parent.FullName, true))
                        {
                            t.Nodes.Add(faftv_CreateDirectoryNode(di));
                        }
                    }
                    else if (File.Exists(e.FullPath))
                    {
                        if (e.Name == "desktop.ini") { return; }

                        FileInfo fi = new FileInfo(e.FullPath);
                        foreach (TreeNode t in faftv.Nodes.Find(fi.Directory.FullName, true))
                        {
                            TreeNode newNode = new TreeNode() { Text = fi.Name, Name = fi.FullName };
                            faftv_setImage(fi.Extension, newNode);
                            t.Nodes.Add(newNode);
                        }
                    }
                });
            }
            catch (Exception) { }
        }
        private void faftv_watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    TreeNode[] nodes = faftv.Nodes.Find(e.FullPath, true);
                    if (nodes.Length >= 1)
                    {
                        nodes[0].Remove();
                    }
                });
            }
            catch (Exception) { }
        }
        private void faftv_watcher_Renamed(object sender, FileSystemEventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (Directory.Exists(e.FullPath))
                    {
                        DirectoryInfo di = new DirectoryInfo(e.FullPath);
                        foreach (TreeNode t in faftv.Nodes.Find(di.Parent.FullName, true))
                        {
                            // remove nodes that don't exist
                            List<TreeNode> nodesToRemove = new List<TreeNode>();
                            foreach (TreeNode child in t.Nodes)
                            { if (!File.Exists(child.Name) && !Directory.Exists(child.Name)) { nodesToRemove.Add(child); } }
                            foreach (TreeNode tn in nodesToRemove) { t.Nodes.Remove(tn); }
                            // add renamed node
                            t.Nodes.Add(faftv_CreateDirectoryNode(di));
                        }
                    }
                    else if (File.Exists(e.FullPath))
                    {
                        FileInfo fi = new FileInfo(e.FullPath);
                        foreach (TreeNode t in faftv.Nodes.Find(fi.Directory.FullName, true))
                        {
                            // remove nodes that don't exist
                            List<TreeNode> nodesToRemove = new List<TreeNode>();
                            foreach (TreeNode child in t.Nodes)
                            { if (!File.Exists(child.Name) && !Directory.Exists(child.Name)) { nodesToRemove.Add(child); } }
                            foreach (TreeNode tn in nodesToRemove) { t.Nodes.Remove(tn); }
                            // add rename node
                            TreeNode newNode = new TreeNode() { Text = fi.Name, Name = fi.FullName };
                            faftv_setImage(fi.Extension, newNode);
                            t.Nodes.Add(newNode);
                        }
                    }
                });
            }
            catch (Exception) { }
        }

        #endregion

        #region ui events

        private void faftv_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            try
            {
                TreeNodeStates state = e.State;
                Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                Color foreColor = faftv.ForeColor;
                Color backColor = faftv.BackColor;
                bool forceBackColor = false;
                Color selectedBackColor = Color.FromArgb(15, 15, 15);

                Color border = Color.Transparent;
                Color start = Color.Transparent;
                Color end = Color.Transparent;

                // SET COLOR BY ATTRIB
                string path = e.Node.Name;
                if (Directory.Exists(path))
                {
                    //SET COLOR BY ATTRIB
                    FileAttributes attrib_dir = File.GetAttributes(path);
                    if (attrib_dir.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { foreColor = faftv.ForeColor; }
                    else if (attrib_dir.HasFlag(FileAttributes.Hidden)) { foreColor = Color.SkyBlue; }
                    else { foreColor = Color.Magenta; }
                }
                else if (File.Exists(path))
                {
                    //SET COLOR BY ATTRIB
                    FileAttributes attrib_dir = File.GetAttributes(path);
                    if (attrib_dir.HasFlag(FileAttributes.System | FileAttributes.Hidden)) { foreColor = faftv.ForeColor; }
                    else if (attrib_dir.HasFlag(FileAttributes.Hidden)) { foreColor = Color.SkyBlue; }
                    else { foreColor = Color.Magenta; }
                }
                else { e.Node.Remove(); return; }

                if (clipboard.Contains(e.Node.Name))
                {
                    switch (cliboardType)
                    {
                        case ClipBoardType.Cut: backColor = Color.Purple; forceBackColor = true; break;
                        case ClipBoardType.Copy: backColor = Color.MediumBlue; forceBackColor = true; break;
                    }
                }

                // node is selected but not focused on treeview
                if (!e.Node.TreeView.Focused && e.Node == e.Node.TreeView.SelectedNode)
                {
                    start = Color.FromArgb(40, 0, 70);
                    end = Color.FromArgb(16, 16, 69);
                    border = Color.SlateBlue;
                }
                // node selected
                else if ((state & TreeNodeStates.Selected) == TreeNodeStates.Selected)
                {
                    start = Color.Indigo;
                    end = Color.MidnightBlue;
                    border = Color.MediumPurple;
                }

                using (Brush background = new SolidBrush(backColor))
                {
                    if (!forceBackColor && start != Color.Transparent && end != Color.Transparent)
                    {
                        using (LinearGradientBrush selectedBrush = e.Node.IsExpanded ?
                            new LinearGradientBrush(e.Bounds, start, end, System.Drawing.Drawing2D.LinearGradientMode.Vertical)
                                :
                            new LinearGradientBrush(e.Bounds, end, start, System.Drawing.Drawing2D.LinearGradientMode.Vertical)
                        )
                        {
                            e.Graphics.FillRectangle(selectedBrush, e.Bounds);
                        }
                    }
                    else
                    {
                        e.Graphics.FillRectangle(background, e.Bounds);
                    }

                    if (border != Color.Transparent) { e.Graphics.DrawRectangle(new Pen(border), new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width - 1, e.Bounds.Height - 1))); }
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, foreColor, TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
                }
            }
            catch (Exception) { }
        }

        private void faftv_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape: faftv_unMarkAll(); e.Handled = e.SuppressKeyPress = true; break;
                case Keys.Enter: faftv_enter(); e.Handled = e.SuppressKeyPress = true; break;
                case Keys.Delete: faftv_delete(); e.Handled = e.SuppressKeyPress = true; break;
                case Keys.F5: faftv_reload(); e.Handled = e.SuppressKeyPress = true; break;
                case Keys.F2: faftv_rename(); e.Handled = e.SuppressKeyPress = true; break;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.W: faftv_startFile(true); e.Handled = e.SuppressKeyPress = true; break;
                    case Keys.B: faftv_openInBrowser(); e.Handled = e.SuppressKeyPress = true; break;
                    case Keys.A: faftv_explorer(); e.Handled = e.SuppressKeyPress = true; break;
                    case Keys.T: faftv_explorer2(); e.Handled = e.SuppressKeyPress = true; break;
                    case Keys.R: faftv_refresh(); e.Handled = e.SuppressKeyPress = true; break;
                    case Keys.Q: faftv_collapse(); e.Handled = e.SuppressKeyPress = true; break;
                    case Keys.E: faftv_expand(); e.Handled = e.SuppressKeyPress = true; break;
                    case Keys.D: faftv_properties(); e.Handled = e.SuppressKeyPress = true; break;
                    case Keys.S: faftv_makeDir(); e.Handled = e.SuppressKeyPress = true; break;
                    case Keys.Z: faftv_makeFile(); e.Handled = e.SuppressKeyPress = true; break;

                    case Keys.X: if (e.Shift) { faftv_move_now(); } else { faftv_move(); } e.Handled = e.SuppressKeyPress = true; break;
                    case Keys.C: if (e.Shift) { faftv_copy_now(); } else { faftv_copy(); } e.Handled = e.SuppressKeyPress = true; break;
                    case Keys.V: faftv_paste(); e.Handled = e.SuppressKeyPress = true; break;

                    // hidden shortcuts
                    case Keys.F: new fapmap_find().Show(); e.Handled = e.SuppressKeyPress = true; break;
                    case Keys.G: new fapmap_settings().Show(); e.Handled = e.SuppressKeyPress = true; break;
                }
            }
        }

        private void faftv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }
            load_file_or_dir(path);
        }
        private void faftv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (GlobalVariables.Settings.CheckBoxes.EnableOpenOutsideFapmap) { faftv_startFile(); }
        }

        #region drag n drop

        private void faftv_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = System.Windows.Forms.DragDropEffects.All;
        }
        private void faftv_DragDrop(object sender, DragEventArgs e)
        {
            if (faftv.SelectedNode == null) { return; }
            if (faftv.SelectedNode.Name == null) { return; }
            string path = faftv.SelectedNode.Name;
            if (string.IsNullOrEmpty(path)) { return; }

            if (File.Exists(path)) { path = Directory.GetParent(path).FullName; }
            if (!Directory.Exists(path)) { return; }

            faftv_n_fileDisplay_dragNdrop(path, e);
        }

        #endregion

        #region RMB

        private void faftv_RMB_refresh_Click(object sender, EventArgs e)
        {
            faftv_refresh();
        }
        private void faftv_RMB_reload_Click(object sender, EventArgs e)
        {
            faftv_reload();
        }
        private void faftv_RMB_unmark_Click(object sender, EventArgs e)
        {
            faftv_unMarkAll();
        }
        private void faftv_RMB_collapseTree_Click(object sender, EventArgs e)
        {
            faftv_collapse();
        }
        private void faftv_RMB_expandTree_Click(object sender, EventArgs e)
        {
            faftv_expand();
        }
        private void faftv_RMB_open_Click(object sender, EventArgs e)
        {
            faftv_startFile(true);
        }
        private void faftv_RMB_openInBrowser_Click(object sender, EventArgs e)
        {
            faftv_openInBrowser();
        }
        private void faftv_RMB_explorer_Click(object sender, EventArgs e)
        {
            faftv_explorer();
        }
        private void faftv_RMB_explorer2_Click(object sender, EventArgs e)
        {
            faftv_explorer2();
        }
        private void faftv_RMB_move_Click(object sender, EventArgs e)
        {
            faftv_move();
        }
        private void faftv_RMB_moveNow_Click(object sender, EventArgs e)
        {
            faftv_move_now();
        }
        private void faftv_RMB_copy_Click(object sender, EventArgs e)
        {
            faftv_copy();
        }
        private void faftv_RMB_copyNow_Click(object sender, EventArgs e)
        {
            faftv_copy_now();
        }
        private void faftv_RMB_paste_Click(object sender, EventArgs e)
        {
            faftv_paste();
        }
        private void faftv_RMB_rename_Click(object sender, EventArgs e)
        {
            faftv_rename();
        }
        private void faftv_RMB_makeDir_Click(object sender, EventArgs e)
        {
            faftv_makeDir();
        }
        private void faftv_RMB_makeFile_Click(object sender, EventArgs e)
        {
            faftv_makeFile();
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

        private void txt_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.Handled = true; e.SuppressKeyPress = true; }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                    case Keys.Enter: openURL(txt_url.Text); e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.S: links_add(txt_url.Text); e.Handled = true; e.SuppressKeyPress = true; break;
                    case Keys.Back:
                        {
                            txt_url.Text = fapmap.GlobalVariables.Settings.WebBrowser.FapMapURL;

                            txt_url.SelectionStart = 0;
                            txt_url.SelectionLength = txt_url.Text.Length;
                            e.Handled = true; e.SuppressKeyPress = true;
                            break;
                        }
                }
            }
        }
        private void txt_url_TextChanged(object sender, EventArgs e)
        {
            if (txt_url.Text.Contains("\n")) { txt_url.Text = txt_url.Text.Replace("\n", String.Empty); }
            if (txt_url.Text.Contains("\r")) { txt_url.Text = txt_url.Text.Replace("\r", String.Empty); }
            if (txt_url.Text.Contains("\t")) { txt_url.Text = txt_url.Text.Replace("\t", String.Empty); }
        }

        private void btn_startURL_Click(object sender, EventArgs e)
        {
            openURL(txt_url.Text);
        }
        private void btn_openURL_Click(object sender, EventArgs e)
        {
            Incognito(txt_url.Text);
        }
        private void btn_saveURL_Click(object sender, EventArgs e)
        {
            links_add(txt_url.Text);
        }

        private void wb_btn_dragOut_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = links.SelectedItems.Count == 0 ? DragDropEffects.None : DragDropEffects.Copy;
        }
        private void wb_btn_dragOut_MouseDown(object sender, MouseEventArgs e)
        {
            if (links.SelectedItems == null) { return; }
            if (links.SelectedItems.Count == 0) { return; }
            string clip = string.Empty;
            foreach (ListViewItem item in links.SelectedItems)
            {
                clip += item == links.SelectedItems[links.SelectedItems.Count - 1] ? item.Name : item.Name + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(clip))
            { this.links.DoDragDrop(new DataObject(DataFormats.StringFormat, clip), DragDropEffects.Copy); }
        }

        #region functions

        private string links_filePath = string.Empty;
        private Color links_color_normal = Color.Turquoise;
        private Color links_color_comment = Color.Teal;

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

            List<string> icons = new List<string>();
            if (Directory.Exists(fapmap.GlobalVariables.Path.Dir.FavIcons))
            { icons.AddRange(Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.FavIcons)); }

            foreach (string url in lines)
            {
                //MAKE ITEM
                index++;
                string number = (index + 1).ToString();
                ListViewItem lvi = new ListViewItem(new string[] { number, url, "" })
                {
                    Name = url,
                    ImageKey = url,
                    ForeColor = url.StartsWith(GlobalVariables.Settings.Common.Comment) ? links_color_comment : links_color_normal
                };

                Image img = null;
                try
                {
                    foreach (string icon in icons)
                    {
                        if (url.Contains(Path.GetFileNameWithoutExtension(icon)))
                            img = fapmap_res.ImageFast.FromFile(icon);
                    }

                    if (img == null)
                    {
                        foreach (string icon in icons)
                        {
                            if (new System.Globalization.CultureInfo("").CompareInfo.IndexOf(url, Path.GetFileNameWithoutExtension(icon), System.Globalization.CompareOptions.IgnoreCase) >= 0)
                                img = fapmap_res.ImageFast.FromFile(icon);
                        }
                    }
                }
                catch (Exception) { }

                // set icon
                if (img != null)
                {
                    favicons.Images.Add(url, img);
                    img.Dispose();
                }

                items.Add(lvi);
            }

            links.Items.AddRange(items.ToArray());

            //auto resize
            links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private Mutex faviconDownloadMutex = new Mutex();
        private void links_add(string url)
        {
            // check url
            if (url == "") { return; }
            if (string.IsNullOrEmpty(url)) { return; }
            if (string.IsNullOrWhiteSpace(url)) { return; }
            foreach (ListViewItem i in links.Items) { if (i.Name == url) { i.Selected = true; fapmap_echo("Link already exists: " + url); return; } }

            // add url to file
            using (TextWriter tw = new StreamWriter(links_filePath, true)) { tw.WriteLine(url); }

            int index = links.Items.Count;

            ListViewItem lvi = new ListViewItem(new string[] { (links.Items.Count + 1).ToString(), url, "" })
            {
                Name = url,
                ImageKey = url,
                ForeColor = url.StartsWith(GlobalVariables.Settings.Common.Comment) ? links_color_comment : links_color_normal,
                Selected = true
            };

            //ADD ITEM
            links.Items.Add(lvi);

            List<string> icons = new List<string>();
            if (Directory.Exists(fapmap.GlobalVariables.Path.Dir.FavIcons))
            { icons.AddRange(Directory.GetFiles(fapmap.GlobalVariables.Path.Dir.FavIcons)); }

            // get icon
            Image img = null;
            try
            {
                foreach (string icon in icons)
                {
                    if (url.Contains(Path.GetFileNameWithoutExtension(icon)))
                        img = fapmap_res.ImageFast.FromFile(icon);
                }

                if (img == null)
                {
                    foreach (string icon in icons)
                    {
                        if (new System.Globalization.CultureInfo("").CompareInfo.IndexOf(url, Path.GetFileNameWithoutExtension(icon), System.Globalization.CompareOptions.IgnoreCase) >= 0)
                            img = fapmap_res.ImageFast.FromFile(icon);
                    }
                }
            }
            catch (Exception) { }

            // download icon
            if (fapmap.GlobalVariables.Settings.CheckBoxes.LinksGetSiteFavicon && img == null)
            {
                new Thread(() =>
                {
                    faviconDownloadMutex.WaitOne();
                    try
                    {
                        if (fapmap.downloadFavicon(url, out string path))
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                lvi.ImageKey = url;
                                Image img2 = fapmap_res.ImageFast.FromFile(path);
                                favicons.Images.Add(url, img2);
                                img2.Dispose();
                            });
                        }
                    }
                    catch (Exception) { }
                    faviconDownloadMutex.ReleaseMutex();
                })
                { IsBackground = true }.Start();
            }

            // set icon
            if (img != null)
            {
                favicons.Images.Add(url, img);
                img.Dispose();
            }

            // get webpage title
            if (GlobalVariables.Settings.CheckBoxes.LinksGetSiteTitle)
            {
                new Thread(() =>
                {
                    try
                    {
                        string text = get_html_title(url);
                        this.Invoke((MethodInvoker)delegate
                        {
                            lvi.SubItems[2].Text = text;
                            links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        });
                    }
                    catch (Exception) { }
                })
                { IsBackground = true }.Start();
            }

            //auto resize & SCROLL
            links.Items[links.Items.Count - 1].EnsureVisible();
            links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private void links_start()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string text = item.Name;
                if (string.IsNullOrEmpty(text)) { continue; }
                if (!text.StartsWith(GlobalVariables.Settings.Common.Comment)) { openURL(text); }
            }
        }
        private void links_reloadTitle()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                new Thread(() =>
                {
                    try
                    {
                        string backup = "";
                        this.Invoke((MethodInvoker)delegate
                        {
                            backup = item.SubItems[2].Text;
                            item.SubItems[2].Text = "reloading...";
                            links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        });

                        string title = get_html_title(item.Name);
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (title == "...") { item.SubItems[2].Text = backup; }
                            else { item.SubItems[2].Text = title; }
                            links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        });
                    }
                    catch (Exception) { }
                })
                { IsBackground = true }.Start();
            }
        }
        private void links_incognito()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string text = item.Name;
                if (string.IsNullOrEmpty(text)) { continue; }
                if (!text.StartsWith(GlobalVariables.Settings.Common.Comment)) { Incognito(text); }
            }
        }
        private void links_download()
        {
            fapmap_download fd = new fapmap_download() { pass_path = txt_path.Text };

            List<string> vs = new List<string>();
            foreach (ListViewItem item in links.SelectedItems) { vs.Add(item.Name); }
            fd.pass_URLs = vs.ToArray();
            fd.Show();
        }
        private void links_webgrab()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string text = item.Name;
                if (string.IsNullOrEmpty(text)) { continue; }
                new fapmap_download() { pass_path = txt_path.Text, pass_webgrabURL = text }.Show();
            }
        }
        private void links_youtubedl()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string text = item.Name;
                if (string.IsNullOrEmpty(text)) { continue; }
                new fapmap_youtubedl() { pass_path = txt_path.Text, pass_url = text }.Show();
            }
        }
        private void links_copy()
        {
            if (links.SelectedItems == null) { return; }
            if (links.SelectedItems.Count == 0) { return; }
            string clip = string.Empty;
            foreach (ListViewItem item in links.SelectedItems)
            {
                clip += item == links.SelectedItems[links.SelectedItems.Count - 1] ? item.Name : item.Name + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(clip)) { System.Windows.Forms.Clipboard.SetText(clip); }
        }
        private void links_paste()
        {
            string text = Clipboard.GetText();
            string[] links = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (links.Length > 1) { foreach (string line in links) { links_add(line); } }
            else { links_add(text); }
        }
        private void links_delete()
        {
            string file = GlobalVariables.Path.File.Links;
            if (!string.IsNullOrEmpty(links_filePath)) { file = links_filePath; }
            FileInfo fi = new FileInfo(file);

            foreach (ListViewItem item in links.SelectedItems)
            {
                string text = item.Name;
                if (string.IsNullOrEmpty(text)) { continue; }

                links.Items.Remove(item);
                favicons.Images.RemoveByKey(item.ImageKey);
                LogThis(fapmap.GlobalVariables.LOG_TYPE.UDEL, text);
            }


            FileAttributes backupAttribs = fi.Attributes;
            fi.Attributes = FileAttributes.Normal; // remove attribs so the file is writeable
            using (var sw = new StreamWriter(fi.FullName, false, System.Text.Encoding.UTF8))
            {
                foreach (ListViewItem lvi in links.Items)
                {
                    sw.WriteLine(lvi.Name);
                }
            }
            fi.Attributes = backupAttribs; // put back the original attribs

            links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private void links_comment()
        {
            string file = GlobalVariables.Path.File.Links;
            if (!string.IsNullOrEmpty(links_filePath)) { file = links_filePath; }

            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string text = item.Name;
                if (string.IsNullOrEmpty(text)) { continue; }
                if (text.StartsWith(GlobalVariables.Settings.Common.Comment)) { continue; }

                string[] lines = fapmap.SafeReadLines(file).ToArray();

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
                item.Name = GlobalVariables.Settings.Common.Comment + " " + text;
            }

            links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private void links_unComment()
        {
            foreach (ListViewItem item in links.SelectedItems)
            {
                if (item.Name == null) { continue; }
                string text = item.Name;
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

                string[] lines = fapmap.SafeReadLines(links_filePath).ToArray();

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
                item.Name = replaceText;
            }

            links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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

        private bool links_ctrl = false;
        private bool links_shift = false;
        private void links_KeyDown(object sender, KeyEventArgs e)
        {
            links_ctrl = e.Control;
            links_shift = e.Shift;

            switch (e.KeyCode)
            {
                case Keys.Escape: links.SelectedItems.Clear(); if (links.FocusedItem != null) { links.FocusedItem.Focused = false; } e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Enter: links_start(); e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.Delete: links_delete(); e.Handled = true; e.SuppressKeyPress = true; break;
                case Keys.F5: links_reload(GlobalVariables.Path.File.Links); e.Handled = true; e.SuppressKeyPress = true; break;
            }
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R: links_reload(GlobalVariables.Path.File.Links); break;
                    case Keys.A: links_selectAll(); break;
                    case Keys.S: links_reloadTitle(); break;
                    case Keys.W: links_incognito(); break;
                    case Keys.Q: links_comment(); break;
                    case Keys.T: links_unComment(); break;
                    case Keys.D: if (e.Shift) { links_webgrab(); } else { links_download(); } break;
                    case Keys.Y: links_youtubedl(); break;
                    case Keys.F: links_find(); break;

                    case Keys.C: links_copy(); break;
                    case Keys.X: links_copy(); links_delete(); break;
                    case Keys.V: links_paste(); break;
                    case Keys.E: links_edit(); break;

                    //hidden shortcuts

                    case Keys.B: new fapmap_board().Show(); break;
                }
            }


        }
        private void links_KeyUp(object sender, KeyEventArgs e)
        {
            links_ctrl = false;
            links_shift = false;
        }
        private void links_LostFocus(object sender, System.EventArgs e)
        {
            links_ctrl = false;
            links_shift = false;
        }

        private int links_fontSize_min = 8;
        private int links_fontSize_max = 50;
        private int links_fontSize = 10;
        private void links_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!links_ctrl) { return; }

            int last = links_fontSize;
            if (e.Delta > 0) { links_fontSize += (links_shift ? 6 : 2); }
            else { links_fontSize -= (links_shift ? 6 : 2); }

            if (links_fontSize < links_fontSize_min) { links_fontSize = links_fontSize_min; }
            else if (links_fontSize > links_fontSize_max) { links_fontSize = links_fontSize_max; }
            if (links_fontSize == last) { return; }

            links.Font = new Font(links.Font.FontFamily, links_fontSize, links.Font.Style);
            links.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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
            string text = e.Data.GetData(typeof(string)) as string;
            string[] links = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (links.Length > 1) { foreach (string line in links) { links_add(line); } }
            else { links_add(text); }
        }

        #endregion

        #region RMB

        private void links_RMB_reload_Click(object sender, EventArgs e)
        {
            links_reload(GlobalVariables.Path.File.Links);
        }
        private void links_RMB_selectAll_Click(object sender, EventArgs e)
        {
            links_selectAll();
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
            links_delete();
        }
        private void links_RMB_paste_Click(object sender, EventArgs e)
        {
            links_paste();
        }
        private void links_RMB_delete_Click(object sender, EventArgs e)
        {
            links_delete();
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

        #region split container update realtime

        private void splitContainer_MouseDown(object sender, MouseEventArgs e)
        {
            ((SplitContainer)sender).IsSplitterFixed = true;
        }
        private void splitContainer_MouseUp(object sender, MouseEventArgs e)
        {
            ((SplitContainer)sender).IsSplitterFixed = false;
        }
        private void splitContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (((SplitContainer)sender).IsSplitterFixed)
            {
                if (e.Button.Equals(MouseButtons.Left))
                {
                    if (((SplitContainer)sender).Orientation.Equals(Orientation.Vertical))
                    {
                        if (e.X > 0 && e.X < ((SplitContainer)sender).Width)
                        {
                            ((SplitContainer)sender).SplitterDistance = e.X;
                            ((SplitContainer)sender).Refresh();
                        }
                    }
                    else
                    {
                        if (e.Y > 0 && e.Y < ((SplitContainer)sender).Height)
                        {
                            // Move the splitter & force a visual refresh
                            ((SplitContainer)sender).SplitterDistance = e.Y;
                            ((SplitContainer)sender).Refresh();
                        }
                    }
                }
                else
                {
                    ((SplitContainer)sender).IsSplitterFixed = false;
                }
            }
        }

        #endregion
    }
}
