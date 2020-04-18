using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;

namespace fapmap_res
{
    public class FapMapColors
    {

        public partial class toolStripProfessionalColorTable : ProfessionalColorTable
        {
            private readonly Color ThemeColor = Color.FromArgb(230, 134, 206);

            public toolStripProfessionalColorTable(Color themeColor)
            {
                base.UseSystemColors = false;

                ThemeColor = themeColor;
            }
            
            public override System.Drawing.Color MenuBorder { get { return ThemeColor; } }
            public override System.Drawing.Color MenuItemBorder { get { return ThemeColor; } }
            
            // MENU SUBITEM HOVER & BORDER
            public override System.Drawing.Color ToolStripDropDownBackground { get { return System.Drawing.Color.FromArgb(15, 6, 15); } }
            public override System.Drawing.Color ToolStripBorder { get { return System.Drawing.Color.Pink; } }

            public override System.Drawing.Color ToolStripGradientBegin  { get { return System.Drawing.Color.Transparent; } }
            public override System.Drawing.Color ToolStripGradientEnd    { get { return System.Drawing.Color.Transparent; } }
            public override System.Drawing.Color ToolStripGradientMiddle { get { return System.Drawing.Color.Transparent; } }
            
            public override System.Drawing.Color OverflowButtonGradientBegin  { get { return ThemeColor; } }
            public override System.Drawing.Color OverflowButtonGradientMiddle { get { return ThemeColor; } }
            public override System.Drawing.Color OverflowButtonGradientEnd    { get { return ThemeColor; } }
            
            public override System.Drawing.Color CheckBackground         { get { return System.Drawing.Color.Black; } }
            public override System.Drawing.Color CheckPressedBackground  { get { return System.Drawing.Color.Black; } }
            public override System.Drawing.Color CheckSelectedBackground { get { return System.Drawing.Color.Black; } }
            
            public override System.Drawing.Color ButtonSelectedHighlightBorder { get { return ThemeColor; } }
            public override System.Drawing.Color ButtonPressedHighlightBorder  { get { return ThemeColor; } }
            public override System.Drawing.Color ButtonCheckedHighlightBorder  { get { return ThemeColor; } }
            public override System.Drawing.Color ButtonPressedBorder           { get { return ThemeColor; } }
            public override System.Drawing.Color ButtonSelectedBorder          { get { return ThemeColor; } }


            // MENU HOVER
            public override System.Drawing.Color MenuItemSelectedGradientBegin { get { return System.Drawing.Color.Transparent; } }
            public override System.Drawing.Color MenuItemPressedGradientMiddle { get { return System.Drawing.Color.Indigo; } }
            public override System.Drawing.Color MenuItemSelectedGradientEnd   { get { return System.Drawing.Color.MidnightBlue; } }

            // MENU PRESS
            public override System.Drawing.Color MenuItemPressedGradientBegin { get { return System.Drawing.Color.MidnightBlue; } }
            public override System.Drawing.Color MenuItemPressedGradientEnd   { get { return System.Drawing.Color.Transparent; } }

            // hover over subitem
            public override System.Drawing.Color MenuItemSelected             { get { return System.Drawing.Color.FromArgb(0,0, 30); } }


            public override System.Drawing.Color ImageMarginGradientBegin  { get { return System.Drawing.Color.Transparent; } }
            public override System.Drawing.Color ImageMarginGradientMiddle { get { return System.Drawing.Color.Transparent; } }
            public override System.Drawing.Color ImageMarginGradientEnd    { get { return System.Drawing.Color.Transparent; } }
        }
        public partial class FapMapToolStripRenderer : ToolStripProfessionalRenderer
        {
            public FapMapToolStripRenderer(Color ThemeColor) : base(new toolStripProfessionalColorTable(ThemeColor))
            {

            }
            
            //arrow color
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                ToolStripMenuItem tsMenuItem = (ToolStripMenuItem)e.Item;
                if (tsMenuItem != null) { e.ArrowColor = Color.Silver; }
                base.OnRenderArrow(e);
            }
        }
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
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, ForeColor, ButtonBorderStyle.Solid);
        }
    }

    public class FapMapProgressBar : ProgressBar
    {
        public FapMapProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Image offscreenImage = new Bitmap(this.Width, this.Height))
            {
                using (Graphics offscreen = Graphics.FromImage(offscreenImage))
                {
                    SolidBrush foreColor = new SolidBrush(ForeColor);
                    SolidBrush backColor = new SolidBrush(BackColor);
                    Rectangle back = new Rectangle(0, 0, this.Width, this.Height);
                    Rectangle bar = new Rectangle
                    (
                        (int)(this.Width * ((double)this.Value / this.Maximum)),
                        0,
                        this.Width,
                        this.Height
                    );

                    offscreen.FillRectangle(backColor, back);
                    offscreen.FillRectangle
                    (
                        new System.Drawing.Drawing2D.LinearGradientBrush
                        (
                            back,
                            Color.FromArgb(13, 81, 74),
                            Color.Lime,
                            System.Drawing.Drawing2D.LinearGradientMode.Horizontal
                        ),
                        back
                    );
                    offscreen.FillRectangle(backColor, bar);

                    e.Graphics.DrawImage(offscreenImage, 0, 0);
                }
            }
        }
    }
    
    public class FapMapTreeView : TreeView
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
            base.OnHandleCreated(e);
        }
        // Pinvoke:
        private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
        private const int TVM_GETEXTENDEDSTYLE = 0x1100 + 45;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs kea = new KeyEventArgs(keyData);
            this.OnKeyDown(kea);

            if (kea.Handled && kea.SuppressKeyPress) { return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    public class FapMapListView : ListView
    {
        public FapMapListView()
        {
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }

    public class FixedRichTextBox : RichTextBox
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!base.AutoWordSelection)
            {
                base.AutoWordSelection = true;
                base.AutoWordSelection = false;
            }
        }
    }

    public class MouseDetector
    {
        #region APIs

        [DllImport("gdi32")]
        public static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out POINT pt);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        #endregion

        Timer tm = new Timer() { Interval = 10 };
        public delegate void MouseMoveDLG(object sender, Point p);
        public event MouseMoveDLG MouseMove;
        public MouseDetector()
        {
            tm.Tick += new EventHandler(tm_Tick); tm.Start();
        }

        void tm_Tick(object sender, EventArgs e)
        {
            GetCursorPos(out POINT p);
            if (MouseMove != null) { this.MouseMove(this, new Point(p.X, p.Y)); }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }

    public class WinAPI
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetFileInformationByHandle(Microsoft.Win32.SafeHandles.SafeFileHandle hFile, out BY_HANDLE_FILE_INFORMATION lpFileInformation);

        public struct BY_HANDLE_FILE_INFORMATION
        {
            public uint FileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME CreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastWriteTime;
            public uint VolumeSerialNumber;
            public uint FileSizeHigh;
            public uint FileSizeLow;
            public uint NumberOfLinks;
            public uint FileIndexHigh;
            public uint FileIndexLow;
        }
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
}
