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
    public class color
    {

        public partial class fToolStripProfessionalRenderer_Colors : ProfessionalColorTable
        {
            public fToolStripProfessionalRenderer_Colors()
            {
                base.UseSystemColors = false;
            }
            
            public override System.Drawing.Color MenuBorder { get { return System.Drawing.Color.SlateBlue; } }
            public override System.Drawing.Color MenuItemBorder { get { return System.Drawing.Color.SlateBlue; } }
            
            public override System.Drawing.Color ToolStripDropDownBackground { get { return System.Drawing.Color.FromArgb(15, 6, 15); } }
            
            public override System.Drawing.Color ToolStripGradientBegin  { get { return System.Drawing.Color.Transparent; } }
            public override System.Drawing.Color ToolStripGradientEnd    { get { return System.Drawing.Color.Transparent; } }
            public override System.Drawing.Color ToolStripGradientMiddle { get { return System.Drawing.Color.Transparent; } }
            
            public override System.Drawing.Color OverflowButtonGradientBegin  { get { return System.Drawing.Color.SlateBlue; } }
            public override System.Drawing.Color OverflowButtonGradientMiddle { get { return System.Drawing.Color.SlateBlue; } }
            public override System.Drawing.Color OverflowButtonGradientEnd    { get { return System.Drawing.Color.SlateBlue; } }
            
            public override System.Drawing.Color CheckBackground         { get { return System.Drawing.Color.Black; } }
            public override System.Drawing.Color CheckPressedBackground  { get { return System.Drawing.Color.Black; } }
            public override System.Drawing.Color CheckSelectedBackground { get { return System.Drawing.Color.Black; } }
            
            public override System.Drawing.Color ButtonSelectedHighlightBorder { get { return System.Drawing.Color.SlateBlue; } }
            public override System.Drawing.Color ButtonPressedHighlightBorder  { get { return System.Drawing.Color.SlateBlue; } }
            public override System.Drawing.Color ButtonCheckedHighlightBorder  { get { return System.Drawing.Color.SlateBlue; } }
            public override System.Drawing.Color ButtonPressedBorder           { get { return System.Drawing.Color.SlateBlue; } }
            public override System.Drawing.Color ButtonSelectedBorder          { get { return System.Drawing.Color.SlateBlue; } }


            public override System.Drawing.Color MenuItemSelectedGradientBegin { get { return System.Drawing.Color.Transparent; } }
            public override System.Drawing.Color MenuItemPressedGradientMiddle { get { return System.Drawing.Color.Transparent; } }
            public override System.Drawing.Color MenuItemSelectedGradientEnd   { get { return System.Drawing.Color.MidnightBlue; } }

            public override System.Drawing.Color MenuItemPressedGradientBegin { get { return System.Drawing.Color.MidnightBlue; } }
            public override System.Drawing.Color MenuItemPressedGradientEnd   { get { return System.Drawing.Color.Transparent; } }
            public override System.Drawing.Color MenuItemSelected             { get { return System.Drawing.Color.Transparent; } }


            public override System.Drawing.Color ImageMarginGradientBegin  { get { return System.Drawing.Color.Transparent; } }
            public override System.Drawing.Color ImageMarginGradientMiddle { get { return System.Drawing.Color.Transparent; } }
            public override System.Drawing.Color ImageMarginGradientEnd    { get { return System.Drawing.Color.Transparent; } }
        }
        public partial class fToolStripProfessionalRenderer : ToolStripProfessionalRenderer
        {
            public fToolStripProfessionalRenderer() : base(new fToolStripProfessionalRenderer_Colors())
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

    public class ColorProgressBar : ProgressBar
    {
        public ColorProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            const int inset = 2; // A single inset value to control teh sizing of the inner rect.

            using (Image offscreenImage = new Bitmap(this.Width, this.Height))
            {
                using (Graphics offscreen = Graphics.FromImage(offscreenImage))
                {
                    Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

                    if (ProgressBarRenderer.IsSupported)
                        ProgressBarRenderer.DrawHorizontalBar(offscreen, rect);

                    rect.Inflate(new Size(-inset, -inset)); // Deflate inner rect.
                    rect.Width = (int)(rect.Width * ((double)this.Value / this.Maximum));
                    if (rect.Width == 0) rect.Width = 1; // Can't draw rec with width of 0.
                    
                    offscreen.FillRectangle(new SolidBrush(Color.FromArgb(20, 20, 20)), 0, 0, this.Width, this.Height);
                    offscreen.FillRectangle(
                        /*
                        new System.Drawing.Drawing2D.LinearGradientBrush(rect, this.BackColor, this.ForeColor, System.Drawing.Drawing2D.LinearGradientMode.Vertical), //*/ Brushes.SteelBlue,
                        inset, inset, rect.Width, rect.Height
                    );

                    e.Graphics.DrawImage(offscreenImage, 0, 0);
                }
            }
        }
    }

    public class IconZZZ
    {
        // //Struct used by SHGetFileInfo function
        // [StructLayout(LayoutKind.Sequential)]
        // public struct SHFILEINFO
        // {
        //     public IntPtr hIcon;
        //     public int iIcon;
        //     public uint dwAttributes;
        //     [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        //     public string szDisplayName;
        //     [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        //     public string szTypeName;
        // };
        // 
        // //Constants flags for SHGetFileInfo 
        // public const uint SHGFI_ICON = 0x000000100;
        // public const uint SHGFI_LARGEICON = 0x000000000; // 'Large icon
        // 
        // //Import SHGetFileInfo function
        // [DllImport("shell32.dll")]
        // public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
        // 
        // public static Image GetThatIcon(string path, int side = 50)
        // {
        //     SHFILEINFO shinfo = new SHFILEINFO();
        // 
        //     //Call function with the path to the folder you want the icon for
        //     SHGetFileInfo(path, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);
        // 
        //     using (Icon i = System.Drawing.Icon.FromHandle(shinfo.hIcon))
        //     {
        //         //Convert icon to a Bitmap source
        //         BitmapSource bitmapsource = Imaging.CreateBitmapSourceFromHIcon(i.Handle, new System.Windows.Int32Rect(0, 0, i.Width, i.Height), BitmapSizeOptions.FromWidthAndHeight(side, side));
        // 
        // 
        //         Bitmap bitmap;
        //         using (var outStream = new MemoryStream())
        //         {
        //             BitmapEncoder enc = new BmpBitmapEncoder();
        //             enc.Frames.Add(BitmapFrame.Create(bitmapsource));
        //             enc.Save(outStream);
        //             bitmap = new Bitmap(outStream);
        //         }
        //         
        //         return bitmap;
        //     }
        // }

        //public static Bitmap BitmapFromSource(BitmapSource bitmapsource)
        //{
        //    Bitmap bitmap;
        //    using (var outStream = new MemoryStream())
        //    {
        //        BitmapEncoder enc = new BmpBitmapEncoder();
        //        enc.Frames.Add(BitmapFrame.Create(bitmapsource));
        //        enc.Save(outStream);
        //        bitmap = new Bitmap(outStream);
        //    }
        //    return bitmap;
        //}
    }
}
