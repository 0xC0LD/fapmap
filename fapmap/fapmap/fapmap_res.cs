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
    public class FapmapColors
    {

        public partial class fToolStripProfessionalRenderer_Colors : ProfessionalColorTable
        {
            public fToolStripProfessionalRenderer_Colors()
            {
                base.UseSystemColors = false;
            }
            
            public override System.Drawing.Color MenuBorder { get { return System.Drawing.Color.SlateBlue; } }
            public override System.Drawing.Color MenuItemBorder { get { return System.Drawing.Color.SlateBlue; } }
            
            // MENU SUBITEM HOVER & BORDER
            public override System.Drawing.Color ToolStripDropDownBackground { get { return System.Drawing.Color.FromArgb(15, 6, 15); } }
            public override System.Drawing.Color ToolStripBorder { get { return System.Drawing.Color.Pink; } }

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
                    SolidBrush backColor = new SolidBrush(BackColor);
                    Rectangle back = new Rectangle(0, 0, this.Width, this.Height);
                    Rectangle bar = new Rectangle(60, 0, this.Width, this.Height);

                    bar.X = (int)(bar.Width * ((double)this.Value / this.Maximum));

                    offscreen.FillRectangle(backColor, back);
                    offscreen.FillRectangle
                    (
                        new System.Drawing.Drawing2D.LinearGradientBrush
                        (
                            back,
                            Color.SteelBlue,
                            Color.SpringGreen,
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
            this.OnKeyDown(new KeyEventArgs(keyData));
            return true;
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
}
