// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCProcessLineExt.cs
// 作　　者：HZH
// 创建日期：2019-08-31 16:04:44
// 功能描述：UCProcessLineExt    English:UCProcessLineExt
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
// 项目地址：https://github.com/kwwwvagaa/NetWinformControl
// 如果你使用了此类，请保留以上说明
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HZH_Controls.Controls
{
    public partial class UCProcessLineExt : UserControl
    {
        [Description("值变更事件"), Category("自定义")]
        public event EventHandler ValueChanged;

        [Description("当前属性"), Category("自定义")]
        public int Value
        {
            set
            {
                ucProcessLine1.Value = value;
                Refresh();
            }
            get
            {
                return ucProcessLine1.Value;
            }
        }



        [Description("最大值"), Category("自定义")]
        public int MaxValue
        {
            get { return ucProcessLine1.MaxValue; }
            set
            {
                ucProcessLine1.MaxValue = value;
                Refresh();
            }
        }


        [Description("值进度条颜色"), Category("自定义")]
        public Color ValueColor
        {
            get { return ucProcessLine1.ValueColor; }
            set
            {
                ucProcessLine1.ValueColor = value;
                Refresh();
            }
        }


        [Description("值背景色"), Category("自定义")]
        public Color ValueBGColor
        {
            get { return ucProcessLine1.ValueBGColor; }
            set
            {
                ucProcessLine1.ValueBGColor = value;
                Refresh();
            }
        }


        [Description("边框颜色"), Category("自定义")]
        public Color BorderColor
        {
            get { return ucProcessLine1.BorderColor; }
            set
            {
                ucProcessLine1.BorderColor = value;
                Refresh();
            }
        }

        [Description("值字体"), Category("自定义")]
        public override Font Font
        {
            get
            {
                return ucProcessLine1.Font;
            }
            set
            {
                ucProcessLine1.Font = value;
                Refresh();
            }
        }

        [Description("值块颜色"), Category("自定义")]
        public override System.Drawing.Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                Refresh();
            }
        }

        public UCProcessLineExt()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            ucProcessLine1.ValueChanged += ucProcessLine1_ValueChanged;
        }

        void ucProcessLine1_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SetGDIHigh();
            float fltIndex = (float)this.ucProcessLine1.Value / (float)this.ucProcessLine1.MaxValue;

            int x = (int)(fltIndex * this.ucProcessLine1.Width + this.ucProcessLine1.Location.X - 15) - 2;
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(x, 1, 30, 20);
            int cornerRadius = 2;
            path.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            path.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            path.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            path.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            path.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            path.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.Right - cornerRadius * 2 - 5, rect.Bottom);//下
            path.AddLine(rect.Right - cornerRadius * 2 - 5, 21, x + 15, ucProcessLine1.Location.Y);
            path.AddLine(x + 15, ucProcessLine1.Location.Y, rect.X + cornerRadius * 2 + 5, 21);
            path.AddLine(rect.X + cornerRadius * 2 + 5, 20, rect.X + cornerRadius * 2, rect.Bottom);//下
            path.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            path.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);//上
            path.CloseFigure();

            e.Graphics.FillPath(new SolidBrush(ForeColor), path);

            string strValue = ((float)Value / (float)MaxValue).ToString("0%");
            System.Drawing.SizeF sizeF = e.Graphics.MeasureString(strValue, Font);
            e.Graphics.DrawString(strValue, Font, new SolidBrush(Color.White), new PointF(x + (30 - sizeF.Width) / 2 + 1, (20 - sizeF.Height) / 2 + 1));
        }
    }
}
