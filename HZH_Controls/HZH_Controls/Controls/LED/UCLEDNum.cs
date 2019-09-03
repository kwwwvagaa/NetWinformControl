// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 09-02-2019
//
// ***********************************************************************
// <copyright file="UCLEDNum.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
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
    /// <summary>
    /// Class UCLEDNum.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCLEDNum : UserControl
    {
        /// <summary>
        /// The m draw rect
        /// </summary>
        Rectangle m_drawRect = Rectangle.Empty;

        /// <summary>
        /// The m nums
        /// </summary>
        private static Dictionary<char, int[]> m_nums = new Dictionary<char, int[]>();
        /// <summary>
        /// Initializes static members of the <see cref="UCLEDNum" /> class.
        /// </summary>
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
            m_nums['A'] = new int[] { 1, 2, 3, 5, 6, 7 };
            m_nums['b'] = new int[] { 3, 4, 5, 6, 7 };
            m_nums['C'] = new int[] { 1, 6, 5, 4 };
            m_nums['c'] = new int[] { 7, 5, 4 };
            m_nums['d'] = new int[] { 2, 3, 4, 5, 7 };
            m_nums['E'] = new int[] { 1, 4, 5, 6, 7 };
            m_nums['F'] = new int[] { 1, 5, 6, 7 };
            m_nums['H'] = new int[] { 2, 3, 5, 6, 7 };
            m_nums['h'] = new int[] { 3, 5, 6, 7 };
            m_nums['J'] = new int[] { 2, 3, 4 };
            m_nums['L'] = new int[] { 4, 5, 6 };
            m_nums['o'] = new int[] { 3, 4, 5, 7 };
            m_nums['P'] = new int[] { 1, 2, 5, 6, 7 };
            m_nums['r'] = new int[] { 5, 7 };
            m_nums['U'] = new int[] { 2, 3, 4, 5, 6 };
            m_nums['-'] = new int[] { 7 };
            m_nums[':'] = new int[0];
            m_nums['.'] = new int[0];
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UCLEDNum" /> class.
        /// </summary>
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

        /// <summary>
        /// Handles the SizeChanged event of the LEDNum control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void LEDNum_SizeChanged(object sender, EventArgs e)
        {
            m_drawRect = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
        }

        /// <summary>
        /// The m value
        /// </summary>
        private char m_value = '0';

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
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

        /// <summary>
        /// Sets the character value.
        /// </summary>
        /// <value>The character value.</value>
        public LEDNumChar ValueChar
        {
            get
            {
                return (LEDNumChar)((int)m_value);
            }
            set
            {
                Value = (char)value;
            }
        }

        /// <summary>
        /// The m line width
        /// </summary>
        private int m_lineWidth = 8;

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
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

        /// <summary>
        /// 获取或设置控件的前景色。
        /// </summary>
        /// <value>The color of the fore.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
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

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
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
    /// <summary>Enum LEDNumChar</summary>
    public enum LEDNumChar : int
    {
        /// <summary>
        /// The character 0
        /// </summary>
        CHAR_0 = (int)'0',
        /// <summary>
        /// The character 1
        /// </summary>
        CHAR_1 = (int)'1',
        /// <summary>
        /// The character 2
        /// </summary>
        CHAR_2 = (int)'2',
        /// <summary>
        /// The character 3
        /// </summary>
        CHAR_3 = (int)'3',
        /// <summary>
        /// The character 4
        /// </summary>
        CHAR_4 = (int)'4',
        CHAR_5 = (int)'5',
        /// <summary>
        /// The character 6
        /// </summary>
        CHAR_6 = (int)'6',
        /// <summary>
        /// The character 7
        /// </summary>
        CHAR_7 = (int)'7',
        /// <summary>
        /// The character 8
        /// </summary>
        CHAR_8 = (int)'8',
        /// <summary>
        /// The character 9
        /// </summary>
        CHAR_9 = (int)'9',
        /// <summary>
        /// The character a
        /// </summary>
        CHAR_A = (int)'A',
        /// <summary>
        /// The character b
        /// </summary>
        CHAR_b = (int)'b',
        /// <summary>
        /// The character c
        /// </summary>
        CHAR_C = (int)'C',
        /// <summary>
        /// The character c
        /// </summary>
        CHAR_c = (int)'c',
        /// <summary>
        /// The character d
        /// </summary>
        CHAR_d = (int)'d',
        /// <summary>
        /// The character e
        /// </summary>
        CHAR_E = (int)'E',
        /// <summary>
        /// The character f
        /// </summary>
        CHAR_F = (int)'F',
        /// <summary>
        /// The character h
        /// </summary>
        CHAR_H = (int)'H',
        /// <summary>
        /// The character h
        /// </summary>
        CHAR_h = (int)'h',
        /// <summary>
        /// The character j
        /// </summary>
        CHAR_J = (int)'J',
        /// <summary>
        /// The character l
        /// </summary>
        CHAR_L = (int)'L',
        /// <summary>
        /// The character o
        /// </summary>
        CHAR_o = (int)'o',
        /// <summary>
        /// The character p
        /// </summary>
        CHAR_P = (int)'P',
        /// <summary>
        /// The character r
        /// </summary>
        CHAR_r = (int)'r',
        /// <summary>
        /// The character u
        /// </summary>
        CHAR_U = (int)'U',
        /// <summary>
        /// The character horizontal line
        /// </summary>
        CHAR_HorizontalLine = (int)'-',
        /// <summary>
        /// The character colon
        /// </summary>
        CHAR_Colon = (int)':',
        /// <summary>
        /// The character dot
        /// </summary>
        CHAR_Dot = (int)'.',
    }
}
