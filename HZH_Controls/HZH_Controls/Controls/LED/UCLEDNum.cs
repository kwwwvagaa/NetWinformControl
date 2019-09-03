// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCLEDNum.cs
// 作　　者：HZH
// 创建日期：2019-09-02 16:22:59
// 功能描述：UCLEDNum    English:UCLEDNum
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
// 项目地址：https://github.com/kwwwvagaa/NetWinformControl
// 如果你使用了此类，请保留以上说明
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace HZH_Controls.Controls
{
    /* 显示位置序号
     *  ****1***
     *  *      *  
     *  6      2
     *  *      *
     *  ****7***
     *  *      *
     *  5      3
     *  *      *
     *  ****4***
     */
    public class UCLEDNum : UserControl
    {
        Rectangle m_drawRect = Rectangle.Empty;

        private static Dictionary<char, int[]> m_nums = new Dictionary<char, int[]>();
        static UCLEDNum()
        {
            m_nums['0'] = new int[] { 1, 2, 3, 4, 5, 6 };
            m_nums['1'] = new int[] { 2, 3 };
            m_nums['2'] = new int[] { 1, 2, 5, 4, 7 };
            m_nums['3'] = new int[] { 1, 2, 7, 3, 4 };
            m_nums['4'] = new int[] { 2, 3, 6, 7 };
            m_nums['5'] = new int[] { 1, 6, 7, 3, 4 };
            m_nums['6'] = new int[] { 1, 6, 5, 4, 3, 7 };
            m_nums['7'] = new int[] { 1, 2, 3 };
            m_nums['8'] = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            m_nums['9'] = new int[] { 1, 2, 3, 4, 7, 6 };
            m_nums['-'] = new int[] { 7 };
            m_nums[':'] = new int[0];
            m_nums['.'] = new int[0];
        }


        public UCLEDNum()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            SizeChanged += LEDNum_SizeChanged;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            Size = new System.Drawing.Size(40, 70);
            if (m_drawRect == Rectangle.Empty)
                m_drawRect = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
        }

        void LEDNum_SizeChanged(object sender, EventArgs e)
        {
            m_drawRect = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
        }

        private char m_value = '0';

        [Description("值"), Category("自定义")]
        public char Value
        {
            get { return m_value; }
            set
            {
                if (!m_nums.ContainsKey(value))
                {
                    return;
                }
                if (m_value != value)
                {
                    m_value = value;
                    Refresh();
                }
            }
        }

        private int m_lineWidth = 8;

        [Description("线宽度，为了更好的显示效果，请使用偶数"), Category("自定义")]
        public int LineWidth
        {
            get { return m_lineWidth; }
            set
            {
                m_lineWidth = value;
                Refresh();
            }
        }

        [Description("颜色"), Category("自定义")]
        public override System.Drawing.Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SetGDIHigh();
            if (m_value == '.')
            {
                Rectangle r2 = new Rectangle(m_drawRect.Left + (m_drawRect.Width - m_lineWidth) / 2, m_drawRect.Bottom - m_lineWidth * 2, m_lineWidth, m_lineWidth);
                e.Graphics.FillRectangle(new SolidBrush(ForeColor), r2);
            }
            else if (m_value == ':')
            {
                Rectangle r1 = new Rectangle(m_drawRect.Left + (m_drawRect.Width - m_lineWidth) / 2, m_drawRect.Top + (m_drawRect.Height / 2 - m_lineWidth) / 2, m_lineWidth, m_lineWidth);
                e.Graphics.FillRectangle(new SolidBrush(ForeColor), r1);
                Rectangle r2 = new Rectangle(m_drawRect.Left + (m_drawRect.Width - m_lineWidth) / 2, m_drawRect.Top + (m_drawRect.Height / 2 - m_lineWidth) / 2 + m_drawRect.Height / 2, m_lineWidth, m_lineWidth);
                e.Graphics.FillRectangle(new SolidBrush(ForeColor), r2);
            }
            else
            {
                int[] vs = m_nums[m_value];
                if (vs.Contains(1))
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddLines(new Point[] 
                {
                    new Point(m_drawRect.Left + 2, m_drawRect.Top),
                    new Point(m_drawRect.Right - 2, m_drawRect.Top),
                    new Point(m_drawRect.Right - m_lineWidth-2, m_drawRect.Top+m_lineWidth),
                    new Point(m_drawRect.Left + m_lineWidth+2, m_drawRect.Top+m_lineWidth),
                    new Point(m_drawRect.Left + 2, m_drawRect.Top)
                });
                    path.CloseAllFigures();
                    e.Graphics.FillPath(new SolidBrush(ForeColor), path);
                }

                if (vs.Contains(2))
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddLines(new Point[] 
                {
                    new Point(m_drawRect.Right, m_drawRect.Top),
                    new Point(m_drawRect.Right, m_drawRect.Top+(m_drawRect.Height-m_lineWidth-4)/2),
                    new Point(m_drawRect.Right-m_lineWidth/2, m_drawRect.Top+(m_drawRect.Height-m_lineWidth-4)/2+m_lineWidth/2),
                    new Point(m_drawRect.Right-m_lineWidth, m_drawRect.Top+(m_drawRect.Height-m_lineWidth-4)/2),
                    new Point(m_drawRect.Right-m_lineWidth, m_drawRect.Top+m_lineWidth),
                    new Point(m_drawRect.Right, m_drawRect.Top)
                });
                    path.CloseAllFigures();
                    e.Graphics.FillPath(new SolidBrush(ForeColor), path);
                }

                if (vs.Contains(3))
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddLines(new Point[] 
                {
                    new Point(m_drawRect.Right, m_drawRect.Bottom-(m_drawRect.Height-m_lineWidth-4)/2),
                    new Point(m_drawRect.Right, m_drawRect.Bottom),
                    new Point(m_drawRect.Right-m_lineWidth, m_drawRect.Bottom-m_lineWidth),
                    new Point(m_drawRect.Right-m_lineWidth, m_drawRect.Bottom-(m_drawRect.Height-m_lineWidth-4)/2),
                    new Point(m_drawRect.Right-m_lineWidth/2, m_drawRect.Bottom-(m_drawRect.Height-m_lineWidth-4)/2-m_lineWidth/2),
                    new Point(m_drawRect.Right, m_drawRect.Bottom-(m_drawRect.Height-m_lineWidth-4)/2),                 
                });
                    path.CloseAllFigures();
                    e.Graphics.FillPath(new SolidBrush(ForeColor), path);
                }

                if (vs.Contains(4))
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddLines(new Point[] 
                {
                    new Point(m_drawRect.Left + 2, m_drawRect.Bottom),
                    new Point(m_drawRect.Right - 2, m_drawRect.Bottom),
                    new Point(m_drawRect.Right - m_lineWidth-2, m_drawRect.Bottom-m_lineWidth),
                    new Point(m_drawRect.Left + m_lineWidth+2, m_drawRect.Bottom-m_lineWidth),
                    new Point(m_drawRect.Left + 2, m_drawRect.Bottom)
                });
                    path.CloseAllFigures();
                    e.Graphics.FillPath(new SolidBrush(ForeColor), path);
                }

                if (vs.Contains(5))
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddLines(new Point[] 
                {
                    new Point(m_drawRect.Left, m_drawRect.Bottom-(m_drawRect.Height-m_lineWidth-4)/2),
                    new Point(m_drawRect.Left, m_drawRect.Bottom),
                    new Point(m_drawRect.Left+m_lineWidth, m_drawRect.Bottom-m_lineWidth),
                    new Point(m_drawRect.Left+m_lineWidth, m_drawRect.Bottom-(m_drawRect.Height-m_lineWidth-4)/2),
                    new Point(m_drawRect.Left+m_lineWidth/2, m_drawRect.Bottom-(m_drawRect.Height-m_lineWidth-4)/2-m_lineWidth/2),
                    new Point(m_drawRect.Left, m_drawRect.Bottom-(m_drawRect.Height-m_lineWidth-4)/2),                 
                });
                    path.CloseAllFigures();
                    e.Graphics.FillPath(new SolidBrush(ForeColor), path);
                }


                if (vs.Contains(6))
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddLines(new Point[] 
                {
                    new Point(m_drawRect.Left, m_drawRect.Top),
                    new Point(m_drawRect.Left, m_drawRect.Top+(m_drawRect.Height-m_lineWidth-4)/2),
                    new Point(m_drawRect.Left+m_lineWidth/2, m_drawRect.Top+(m_drawRect.Height-m_lineWidth-4)/2+m_lineWidth/2),
                    new Point(m_drawRect.Left+m_lineWidth, m_drawRect.Top+(m_drawRect.Height-m_lineWidth-4)/2),
                    new Point(m_drawRect.Left+m_lineWidth, m_drawRect.Top+m_lineWidth),
                    new Point(m_drawRect.Left, m_drawRect.Top)
                });
                    path.CloseAllFigures();
                    e.Graphics.FillPath(new SolidBrush(ForeColor), path);
                }

                if (vs.Contains(7))
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddLines(new Point[] 
                {
                    new Point(m_drawRect.Left+m_lineWidth/2, m_drawRect.Height/2+1),            
                    new Point(m_drawRect.Left+m_lineWidth, m_drawRect.Height/2-m_lineWidth/2+1),    
                    new Point(m_drawRect.Right-m_lineWidth, m_drawRect.Height/2-m_lineWidth/2+1),
                    new Point(m_drawRect.Right-m_lineWidth/2, m_drawRect.Height/2+1),
                    new Point(m_drawRect.Right-m_lineWidth, m_drawRect.Height/2+m_lineWidth/2+1),
                    new Point(m_drawRect.Left+m_lineWidth, m_drawRect.Height/2+m_lineWidth/2+1),    
                    new Point(m_drawRect.Left+m_lineWidth/2, m_drawRect.Height/2+1)
                });
                    path.CloseAllFigures();
                    e.Graphics.FillPath(new SolidBrush(ForeColor), path);
                }
            }
        }
    }
}
