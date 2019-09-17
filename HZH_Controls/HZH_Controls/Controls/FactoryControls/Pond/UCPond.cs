// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-06
//
// ***********************************************************************
// <copyright file="UCPond.cs">
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
    /// <summary>
    /// Class UCPond.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCPond : UserControl
    {
        /// <summary>
        /// The maximum value
        /// </summary>
        private decimal maxValue = 100;

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        [Description("最大值"), Category("自定义")]
        public decimal MaxValue
        {
            get { return maxValue; }
            set
            {
                if (value < m_value)
                    return;
                maxValue = value;
                Refresh();
            }
        }

        /// <summary>
        /// The m value
        /// </summary>
        private decimal m_value = 0;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Description("值"), Category("自定义")]
        public decimal Value
        {
            get { return m_value; }
            set
            {
                if (value < 0)
                    return;
                if (value > maxValue)
                    m_value = maxValue;
                else
                    m_value = value;
                Refresh();
            }
        }

        /// <summary>
        /// The wall color
        /// </summary>
        private Color wallColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the color of the wall.
        /// </summary>
        /// <value>The color of the wall.</value>
        [Description("池壁颜色"), Category("自定义")]
        public Color WallColor
        {
            get { return wallColor; }
            set
            {
                wallColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// The wall width
        /// </summary>
        private int wallWidth = 2;

        /// <summary>
        /// Gets or sets the width of the wall.
        /// </summary>
        /// <value>The width of the wall.</value>
        [Description("池壁宽度"), Category("自定义")]
        public int WallWidth
        {
            get { return wallWidth; }
            set
            {
                if (value <= 0)
                    return;
                wallWidth = value;
                Refresh();
            }
        }

        /// <summary>
        /// The liquid color
        /// </summary>
        private Color liquidColor = Color.FromArgb(3, 169, 243);

        /// <summary>
        /// Gets or sets the color of the liquid.
        /// </summary>
        /// <value>The color of the liquid.</value>
        [Description("液体颜色"), Category("自定义")]
        public Color LiquidColor
        {
            get { return liquidColor; }
            set { liquidColor = value; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UCPond" /> class.
        /// </summary>
        public UCPond()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Size = new Size(150, 50);
        }
        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Height <= 0)
                return;
            var g = e.Graphics;
            g.SetGDIHigh();
            int intHeight = (int)(m_value / maxValue * this.Height);
            if (intHeight != 0)
            {
                g.FillRectangle(new SolidBrush(liquidColor), new Rectangle(0, this.Height - intHeight, this.Width, intHeight));
            }
            //划边
            g.FillRectangle(new SolidBrush(wallColor), 0, 0, wallWidth, this.Height);
            g.FillRectangle(new SolidBrush(wallColor), 0, this.Height - wallWidth, this.Width, wallWidth);
            g.FillRectangle(new SolidBrush(wallColor), this.Width - wallWidth-1, 0, wallWidth, this.Height);
        }
    }
}
