// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-29-2019
//
// ***********************************************************************
// <copyright file="UCTrackBar.cs">
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
    /// Class UCTrackBar.
    /// Implements the <see cref="System.Windows.Forms.Control" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("ValueChanged")]
    public class UCTrackBar : Control
    {
        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        [Description("值改变事件"), Category("自定义")]
        public event EventHandler ValueChanged;

        /// <summary>
        /// The dcimal digits
        /// </summary>
        private int dcimalDigits = 0;

        /// <summary>
        /// Gets or sets the dcimal digits.
        /// </summary>
        /// <value>The dcimal digits.</value>
        [Description("值小数精确位数"), Category("自定义")]
        public int DcimalDigits
        {
            get { return dcimalDigits; }
            set { dcimalDigits = value; }
        }

        /// <summary>
        /// The line width
        /// </summary>
        private float lineWidth = 10;

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        [Description("线宽度"), Category("自定义")]
        public float LineWidth
        {
            get { return lineWidth; }
            set { lineWidth = value; }
        }

        /// <summary>
        /// The minimum value
        /// </summary>
        private float minValue = 0;

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        [Description("最小值"), Category("自定义")]
        public float MinValue
        {
            get { return minValue; }
            set
            {
                if (minValue > m_value)
                    return;
                minValue = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// The maximum value
        /// </summary>
        private float maxValue = 100;

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        [Description("最大值"), Category("自定义")]
        public float MaxValue
        {
            get { return maxValue; }
            set
            {
                if (value < m_value)
                    return;
                maxValue = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// The m value
        /// </summary>
        private float m_value = 0;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Description("值"), Category("自定义")]
        public float Value
        {
            get { return this.m_value; }
            set
            {
                if (value > maxValue || value < minValue)
                    return;
                var v = (float)Math.Round((double)value, dcimalDigits);
                if (m_value == v)
                    return;
                this.m_value = v;
                this.Refresh();
                if (ValueChanged != null)
                {
                    ValueChanged(this, null);
                }
            }
        }

        /// <summary>
        /// The m line color
        /// </summary>
        private Color m_lineColor = Color.FromArgb(228, 231, 237);

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        [Description("线颜色"), Category("自定义")]
        public Color LineColor
        {
            get { return m_lineColor; }
            set
            {
                m_lineColor = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// The m value color
        /// </summary>
        private Color m_valueColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the color of the value.
        /// </summary>
        /// <value>The color of the value.</value>
        [Description("值颜色"), Category("自定义")]
        public Color ValueColor
        {
            get { return m_valueColor; }
            set
            {
                m_valueColor = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// The is show tips
        /// </summary>
        private bool isShowTips = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is show tips.
        /// </summary>
        /// <value><c>true</c> if this instance is show tips; otherwise, <c>false</c>.</value>
        [Description("点击滑动时是否显示数值提示"), Category("自定义")]
        public bool IsShowTips
        {
            get { return isShowTips; }
            set { isShowTips = value; }
        }

        /// <summary>
        /// Gets or sets the tips format.
        /// </summary>
        /// <value>The tips format.</value>
        [Description("显示数值提示的格式化形式"), Category("自定义")]
        public string TipsFormat { get; set; }

        /// <summary>
        /// The m line rectangle
        /// </summary>
        RectangleF m_lineRectangle;
        /// <summary>
        /// The m track rectangle
        /// </summary>
        RectangleF m_trackRectangle;

        /// <summary>
        /// Initializes a new instance of the <see cref="UCTrackBar" /> class.
        /// </summary>
        public UCTrackBar()
        {
            this.Size = new Size(250, 30);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MouseDown += UCTrackBar_MouseDown;
            this.MouseMove += UCTrackBar_MouseMove;
            this.MouseUp += UCTrackBar_MouseUp;

        }



        /// <summary>
        /// The BLN down
        /// </summary>
        bool blnDown = false;
        /// <summary>
        /// Handles the MouseDown event of the UCTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        void UCTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_lineRectangle.Contains(e.Location) || m_trackRectangle.Contains(e.Location))
            {
                blnDown = true;
                Value = minValue+((float)e.Location.X / (float)this.Width) * (maxValue - minValue);
                ShowTips();
            }
        }
        /// <summary>
        /// Handles the MouseMove event of the UCTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        void UCTrackBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnDown)
            {
                Value = minValue + ((float)e.Location.X / (float)this.Width) * (maxValue - minValue);
                ShowTips();
            }
        }
        /// <summary>
        /// Handles the MouseUp event of the UCTrackBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        void UCTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            blnDown = false;

            if (frmTips != null && !frmTips.IsDisposed)
            {
                frmTips.Close();
                frmTips = null;
            }
        }
        /// <summary>
        /// The FRM tips
        /// </summary>
        Forms.FrmAnchorTips frmTips = null;

        /// <summary>
        /// Shows the tips.
        /// </summary>
        private void ShowTips()
        {
            if (isShowTips)
            {
                string strValue = Value.ToString();
                if (!string.IsNullOrEmpty(TipsFormat))
                {
                    try
                    {
                        strValue = Value.ToString(TipsFormat);
                    }
                    catch { }
                }
                var p = this.PointToScreen(new Point((int)m_trackRectangle.X, (int)m_trackRectangle.Y));

                if (frmTips == null || frmTips.IsDisposed || !frmTips.Visible)
                {
                    frmTips = Forms.FrmAnchorTips.ShowTips(new Rectangle(p.X, p.Y, (int)m_trackRectangle.Width, (int)m_trackRectangle.Height), strValue, Forms.AnchorTipsLocation.TOP, ValueColor, autoCloseTime: -1);
                }
                else
                {
                    frmTips.RectControl = new Rectangle(p.X, p.Y, (int)m_trackRectangle.Width, (int)m_trackRectangle.Height);
                    frmTips.StrMsg = strValue;
                }
            }
        }


        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs" /> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SetGDIHigh();
            m_lineRectangle = new RectangleF(lineWidth, (this.Size.Height - lineWidth) / 2, this.Size.Width - lineWidth * 2, lineWidth);
            GraphicsPath pathLine = ControlHelper.CreateRoundedRectanglePath(m_lineRectangle, 5);
            g.FillPath(new SolidBrush(m_lineColor), pathLine);


            GraphicsPath valueLine = ControlHelper.CreateRoundedRectanglePath(new RectangleF(lineWidth, (this.Size.Height - lineWidth) / 2, ((float)(m_value - minValue) / (float)(maxValue - minValue)) * m_lineRectangle.Width, lineWidth), 5);
            g.FillPath(new SolidBrush(m_valueColor), valueLine);

            m_trackRectangle = new RectangleF(m_lineRectangle.Left - lineWidth + (((float)(m_value - minValue) / (float)(maxValue - minValue)) * (this.Size.Width - lineWidth * 2)), (this.Size.Height - lineWidth * 2) / 2, lineWidth * 2, lineWidth * 2);
            g.FillEllipse(new SolidBrush(m_valueColor), m_trackRectangle);
            g.FillEllipse(Brushes.White, new RectangleF(m_trackRectangle.X + m_trackRectangle.Width / 4, m_trackRectangle.Y + m_trackRectangle.Height / 4, m_trackRectangle.Width / 2, m_trackRectangle.Height / 2));
        }
    }
}
