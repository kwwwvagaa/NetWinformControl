using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Forms
{
    public partial class FrmAnchorTips : Form
    {
        private string m_strMsg = string.Empty;

        public string StrMsg
        {
            get { return m_strMsg; }
            set
            {
                m_strMsg = value;
                if (string.IsNullOrEmpty(value))
                    return;
                ResetForm(value);
            }
        }
        bool haveHandle = false;
        Rectangle m_rectControl;
        public Rectangle RectControl
        {
            get { return m_rectControl; }
            set
            {
                m_rectControl = value;
            }
        }
        AnchorTipsLocation m_location;
        Color? m_background = null;
        Color? m_foreColor = null;
        int m_fontSize = 10;
        #region 构造函数    English:Constructor
        /// <summary>
        /// 功能描述:构造函数    English:Constructor
        /// 作　　者:HZH
        /// 创建日期:2019-08-29 15:27:51
        /// 任务编号:
        /// </summary>
        /// <param name="rectControl">停靠区域</param>
        /// <param name="strMsg">消息</param>
        /// <param name="location">显示方位</param>
        /// <param name="background">背景色</param>
        /// <param name="foreColor">文字颜色</param>
        /// <param name="fontSize">文字大小</param>
        /// <param name="autoCloseTime">自动关闭时间，当<=0时不自动关闭</param>
        private FrmAnchorTips(
            Rectangle rectControl,
            string strMsg,
            AnchorTipsLocation location = AnchorTipsLocation.RIGHT,
            Color? background = null,
            Color? foreColor = null,
            int fontSize = 10,
            int autoCloseTime = 5000)
        {
            InitializeComponent();
            m_rectControl = rectControl;
            m_location = location;
            m_background = background;
            m_foreColor = foreColor;
            m_fontSize = fontSize;
            StrMsg = strMsg;
            if (autoCloseTime > 0)
            {
                Timer t = new Timer();
                t.Interval = autoCloseTime;
                t.Tick += (a, b) =>
                {
                    this.Close();
                };
                t.Enabled = true;
            }
        }

        private void ResetForm(string strMsg)
        {
            Graphics g = this.CreateGraphics();
            Font _font = new Font("微软雅黑", m_fontSize);
            Color _background = m_background == null ? Color.FromArgb(255, 77, 58) : m_background.Value;
            Color _foreColor = m_foreColor == null ? Color.White : m_foreColor.Value;
            System.Drawing.SizeF sizeText = g.MeasureString(strMsg, _font);
            g.Dispose();
            var formSize = new Size((int)sizeText.Width + 20, (int)sizeText.Height + 20);
            if (formSize.Width < 20)
                formSize.Width = 20;
            if (formSize.Height < 20)
                formSize.Height = 20;
            if (m_location == AnchorTipsLocation.LEFT || m_location == AnchorTipsLocation.RIGHT)
            {
                formSize.Width += 20;
            }
            else
            {
                formSize.Height += 20;
            }

            #region 获取窗体path    English:Get the form path
            GraphicsPath path = new GraphicsPath();
            Rectangle rect;
            switch (m_location)
            {
                case AnchorTipsLocation.TOP:
                    rect = new Rectangle(1, 1, formSize.Width - 2, formSize.Height - 20 - 1);
                    this.Location = new Point(m_rectControl.X + (m_rectControl.Width - rect.Width) / 2, m_rectControl.Y - rect.Height - 20);
                    break;
                case AnchorTipsLocation.RIGHT:
                    rect = new Rectangle(20, 1, formSize.Width - 20 - 1, formSize.Height - 2);
                    this.Location = new Point(m_rectControl.Right, m_rectControl.Y + (m_rectControl.Height - rect.Height) / 2);
                    break;
                case AnchorTipsLocation.BOTTOM:
                    rect = new Rectangle(1, 20, formSize.Width - 2, formSize.Height - 20 - 1);
                    this.Location = new Point(m_rectControl.X + (m_rectControl.Width - rect.Width) / 2, m_rectControl.Bottom);
                    break;
                default:
                    rect = new Rectangle(1, 1, formSize.Width - 20 - 1, formSize.Height - 2);
                    this.Location = new Point(m_rectControl.X - rect.Width - 20, m_rectControl.Y + (m_rectControl.Height - rect.Height) / 2);
                    break;
            }
            int cornerRadius = 2;

            path.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);//左上角
            #region 上边
            if (m_location == AnchorTipsLocation.BOTTOM)
            {
                path.AddLine(rect.X + cornerRadius, rect.Y, rect.Left + rect.Width / 2 - 10, rect.Y);//上
                path.AddLine(rect.Left + rect.Width / 2 - 10, rect.Y, rect.Left + rect.Width / 2, rect.Y - 19);//上
                path.AddLine(rect.Left + rect.Width / 2, rect.Y - 19, rect.Left + rect.Width / 2 + 10, rect.Y);//上
                path.AddLine(rect.Left + rect.Width / 2 + 10, rect.Y, rect.Right - cornerRadius * 2, rect.Y);//上
            }
            else
            {
                path.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);//上
            }
            #endregion
            path.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);//右上角
            #region 右边
            if (m_location == AnchorTipsLocation.LEFT)
            {
                path.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height / 2 - 10);//右
                path.AddLine(rect.Right, rect.Y + rect.Height / 2 - 10, rect.Right + 19, rect.Y + rect.Height / 2);//右
                path.AddLine(rect.Right + 19, rect.Y + rect.Height / 2, rect.Right, rect.Y + rect.Height / 2 + 10);//右
                path.AddLine(rect.Right, rect.Y + rect.Height / 2 + 10, rect.Right, rect.Y + rect.Height - cornerRadius * 2);//右            
            }
            else
            {
                path.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);//右
            }
            #endregion
            path.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);//右下角
            #region 下边
            if (m_location == AnchorTipsLocation.TOP)
            {
                path.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.Left + rect.Width / 2 + 10, rect.Bottom);
                path.AddLine(rect.Left + rect.Width / 2 + 10, rect.Bottom, rect.Left + rect.Width / 2, rect.Bottom + 19);
                path.AddLine(rect.Left + rect.Width / 2, rect.Bottom + 19, rect.Left + rect.Width / 2 - 10, rect.Bottom);
                path.AddLine(rect.Left + rect.Width / 2 - 10, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            }
            else
            {
                path.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            }
            #endregion
            path.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);//左下角
            #region 左边
            if (m_location == AnchorTipsLocation.RIGHT)
            {
                path.AddLine(rect.Left, rect.Y + cornerRadius * 2, rect.Left, rect.Y + rect.Height / 2 - 10);//左
                path.AddLine(rect.Left, rect.Y + rect.Height / 2 - 10, rect.Left - 19, rect.Y + rect.Height / 2);//左
                path.AddLine(rect.Left - 19, rect.Y + rect.Height / 2, rect.Left, rect.Y + rect.Height / 2 + 10);//左
                path.AddLine(rect.Left, rect.Y + rect.Height / 2 + 10, rect.Left, rect.Y + rect.Height - cornerRadius * 2);//左          
            }
            else
            {
                path.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);//左
            }
            #endregion
            path.CloseFigure();
            #endregion

            Bitmap bit = new Bitmap(formSize.Width, formSize.Height);
            this.Size = formSize;

            #region 画图    English:Drawing
            Graphics gBit = Graphics.FromImage(bit);
            gBit.SetGDIHigh();
            gBit.FillPath(new SolidBrush(_background), path);
            gBit.DrawString(strMsg, _font, new SolidBrush(_foreColor), rect.Location + new Size(10, 10));
            gBit.Dispose();
            #endregion

            SetBits(bit);
        }
        #endregion

        #region 显示一个提示    English:Show a hint
        /// <summary>
        /// 功能描述:显示一个提示    English:Show a hint
        /// 作　　者:HZH
        /// 创建日期:2019-08-29 15:28:58
        /// 任务编号:
        /// </summary>
        /// <param name="parentControl">停靠控件</param>
        /// <param name="strMsg">消息</param>
        /// <param name="location">显示方位</param>
        /// <param name="background">背景色</param>
        /// <param name="foreColor">文字颜色</param>
        /// <param name="deviation">偏移量</param>
        /// <param name="fontSize">文字大小</param>
        /// <param name="autoCloseTime">自动关闭时间，当<=0时不自动关闭</param>
        public static FrmAnchorTips ShowTips(
            Control parentControl,
            string strMsg,
            AnchorTipsLocation location = AnchorTipsLocation.RIGHT,
            Color? background = null,
            Color? foreColor = null,
            Size? deviation = null,
            int fontSize = 10,
            int autoCloseTime = 5000)
        {
            Point p;
            if (parentControl is Form)
            {
                p = parentControl.Location;
            }
            else
            {
                p = parentControl.Parent.PointToScreen(parentControl.Location);
            }
            if (deviation != null)
            {
                p = p + deviation.Value;
            }
            return ShowTips(new Rectangle(p, parentControl.Size), strMsg, location, background, foreColor, fontSize, autoCloseTime);
        }
        #endregion

        #region 显示一个提示    English:Show a hint
        /// <summary>
        /// 功能描述:显示一个提示    English:Show a hint
        /// 作　　者:HZH
        /// 创建日期:2019-08-29 15:29:07
        /// 任务编号:
        /// </summary>
        /// <param name="rectControl">停靠区域</param>
        /// <param name="strMsg">消息</param>
        /// <param name="location">显示方位</param>
        /// <param name="background">背景色</param>
        /// <param name="foreColor">文字颜色</param>
        /// <param name="fontSize">文字大小</param>
        /// <param name="autoCloseTime">自动关闭时间，当<=0时不自动关闭</param>
        /// <returns>返回值</returns>
        public static FrmAnchorTips ShowTips(
            Rectangle rectControl,
            string strMsg,
            AnchorTipsLocation location = AnchorTipsLocation.RIGHT,
            Color? background = null,
            Color? foreColor = null,
            int fontSize = 10,
            int autoCloseTime = 5000)
        {
            FrmAnchorTips frm = new FrmAnchorTips(rectControl, strMsg, location, background, foreColor, fontSize, autoCloseTime);
            frm.TopMost = true;
            frm.Show();
            return frm;
        }
        #endregion

        #region Override

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
            haveHandle = false;
            this.Dispose();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            InitializeStyles();
            base.OnHandleCreated(e);
            haveHandle = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cParms;
            }
        }

        #endregion

        private void InitializeStyles()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        #region 根据图片显示窗体    English:Display Forms Based on Pictures
        /// <summary>
        /// 功能描述:根据图片显示窗体    English:Display Forms Based on Pictures
        /// 作　　者:HZH
        /// 创建日期:2019-08-29 15:31:16
        /// 任务编号:
        /// </summary>
        /// <param name="bitmap">bitmap</param>
        private void SetBits(Bitmap bitmap)
        {
            if (!haveHandle) return;

            if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                throw new ApplicationException("The picture must be 32bit picture with alpha channel.");

            IntPtr oldBits = IntPtr.Zero;
            IntPtr screenDC = Win32.GetDC(IntPtr.Zero);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr memDc = Win32.CreateCompatibleDC(screenDC);

            try
            {
                Win32.Point topLoc = new Win32.Point(Left, Top);
                Win32.Size bitMapSize = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.BLENDFUNCTION blendFunc = new Win32.BLENDFUNCTION();
                Win32.Point srcLoc = new Win32.Point(0, 0);

                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBits = Win32.SelectObject(memDc, hBitmap);

                blendFunc.BlendOp = Win32.AC_SRC_OVER;
                blendFunc.SourceConstantAlpha = 255;
                blendFunc.AlphaFormat = Win32.AC_SRC_ALPHA;
                blendFunc.BlendFlags = 0;

                Win32.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, Win32.ULW_ALPHA);
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBits);
                    Win32.DeleteObject(hBitmap);
                }
                Win32.ReleaseDC(IntPtr.Zero, screenDC);
                Win32.DeleteDC(memDc);
            }
        }
        #endregion

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //}
    }

    public enum AnchorTipsLocation
    {
        LEFT,
        TOP,
        RIGHT,
        BOTTOM
    }

    class Win32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Size
        {
            public Int32 cx;
            public Int32 cy;

            public Size(Int32 x, Int32 y)
            {
                cx = x;
                cy = y;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public Int32 x;
            public Int32 y;

            public Point(Int32 x, Int32 y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public const byte AC_SRC_OVER = 0;
        public const Int32 ULW_ALPHA = 2;
        public const byte AC_SRC_ALPHA = 1;

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int DeleteDC(IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int DeleteObject(IntPtr hObj);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr ExtCreateRegion(IntPtr lpXform, uint nCount, IntPtr rgnData);
    }
}
