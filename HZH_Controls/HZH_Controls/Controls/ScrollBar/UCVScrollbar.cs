// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-19
//
// ***********************************************************************
// <copyright file="UCVScrollbar.cs">
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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Diagnostics;


namespace HZH_Controls.Controls
{

    /// <summary>
    /// Class UCVScrollbar.
    /// Implements the <see cref="HZH_Controls.Controls.UCControlBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.UCControlBase" />
    [Designer(typeof(ScrollbarControlDesigner))]
    [DefaultEvent("Scroll")]
    public class UCVScrollbar : UCControlBase
    {
        /// <summary>
        /// The mo large change
        /// </summary>
        protected int moLargeChange = 10;
        /// <summary>
        /// The mo small change
        /// </summary>
        protected int moSmallChange = 5;
        /// <summary>
        /// The mo minimum
        /// </summary>
        protected int moMinimum = 0;
        /// <summary>
        /// The mo maximum
        /// </summary>
        protected int moMaximum = 100;
        /// <summary>
        /// The mo value
        /// </summary>
        protected int moValue = 0;
        /// <summary>
        /// The n click point
        /// </summary>
        private int nClickPoint;
        /// <summary>
        /// The mo thumb top
        /// </summary>
        protected int moThumbTop = 0;
        /// <summary>
        /// The mo automatic size
        /// </summary>
        protected bool moAutoSize = false;
        /// <summary>
        /// The mo thumb down
        /// </summary>
        private bool moThumbMouseDown = false;
        /// <summary>
        /// The mo thumb dragging
        /// </summary>
        private bool moThumbMouseDragging = false;
        /// <summary>
        /// Occurs when [scroll].
        /// </summary>
        public new event EventHandler Scroll = null;
        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event EventHandler ValueChanged = null;

        /// <summary>
        /// The BTN height
        /// </summary>
        private int btnHeight = 18;
        /// <summary>
        /// The m int thumb minimum height
        /// </summary>
        private int m_intThumbMinHeight = 30;

        /// <summary>
        /// Gets or sets the height of the BTN.
        /// </summary>
        /// <value>The height of the BTN.</value>
        public int BtnHeight
        {
            get { return btnHeight; }
            set { btnHeight = value; }
        }
        /// <summary>
        /// Gets or sets the large change.
        /// </summary>
        /// <value>The large change.</value>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("自定义"), Description("LargeChange")]
        public int LargeChange
        {
            get { return moLargeChange; }
            set
            {
                moLargeChange = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the small change.
        /// </summary>
        /// <value>The small change.</value>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("自定义"), Description("SmallChange")]
        public int SmallChange
        {
            get { return moSmallChange; }
            set
            {
                moSmallChange = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("自定义"), Description("Minimum")]
        public int Minimum
        {
            get { return moMinimum; }
            set
            {
                moMinimum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("自定义"), Description("Maximum")]
        public int Maximum
        {
            get { return moMaximum; }
            set
            {
                moMaximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("自定义"), Description("Value")]
        public int Value
        {
            get { return moValue; }
            set
            {
                moValue = value;

                int nTrackHeight = (this.Height - btnHeight * 2);
                //float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
                float fThumbHeight = nTrackHeight - Maximum;
                int nThumbHeight = (int)fThumbHeight;

                if (nThumbHeight > nTrackHeight)
                {
                    nThumbHeight = nTrackHeight;
                    fThumbHeight = nTrackHeight;
                }
                if (nThumbHeight < m_intThumbMinHeight)
                {
                    nThumbHeight = m_intThumbMinHeight;
                    fThumbHeight = m_intThumbMinHeight;
                }

                //figure out value
                int nPixelRange = nTrackHeight - nThumbHeight;
                int nRealRange = (Maximum - Minimum) - LargeChange;
                float fPerc = 0.0f;
                if (nRealRange != 0)
                {
                    fPerc = (float)moValue / (float)nRealRange;

                }

                float fTop = fPerc * nPixelRange;
                moThumbTop = (int)fTop;


                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic size].
        /// </summary>
        /// <value><c>true</c> if [automatic size]; otherwise, <c>false</c>.</value>
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
                if (base.AutoSize)
                {
                    this.Width = 15;
                }
            }
        }

        /// <summary>
        /// The thumb color
        /// </summary>
        private Color thumbColor = Color.FromArgb(255, 77, 58);

        /// <summary>
        /// Gets or sets the color of the thumb.
        /// </summary>
        /// <value>The color of the thumb.</value>
        public Color ThumbColor
        {
            get { return thumbColor; }
            set { thumbColor = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCVScrollbar"/> class.
        /// </summary>
        public UCVScrollbar()
        {
            InitializeComponent();
            ConerRadius = 2;
            FillColor = Color.FromArgb(239, 239, 239);
            IsShowRect = false;
            IsRadius = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UCVScrollbar
            // 
            this.MinimumSize = new System.Drawing.Size(10, 0);
            this.Name = "UCVScrollbar";
            this.Size = new System.Drawing.Size(18, 150);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseUp);
            this.ResumeLayout(false);

        }


        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SetGDIHigh();
            if (Maximum > 0)
            {
                //draw thumb
                int nTrackHeight = (this.Height - btnHeight * 2);
                //float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
                float fThumbHeight = nTrackHeight - Maximum;
                int nThumbHeight = (int)fThumbHeight;

                if (nThumbHeight > nTrackHeight)
                {
                    nThumbHeight = nTrackHeight;
                    fThumbHeight = nTrackHeight;
                }
                if (nThumbHeight < m_intThumbMinHeight)
                {
                    nThumbHeight = m_intThumbMinHeight;
                    fThumbHeight = m_intThumbMinHeight;
                }
                int nTop = moThumbTop;
                nTop += btnHeight;
                if (nTop + nThumbHeight > this.Height - btnHeight)
                    nTop = this.Height - btnHeight - nThumbHeight;
                e.Graphics.FillPath(new SolidBrush(thumbColor), new Rectangle(1, nTop, this.Width - 3, nThumbHeight).CreateRoundedRectanglePath(this.ConerRadius));
            }
            ControlHelper.PaintTriangle(e.Graphics, new SolidBrush(thumbColor), new Point(this.Width / 2, btnHeight - Math.Min(5, this.Width / 2)), Math.Min(5, this.Width / 2), GraphDirection.Upward);
            ControlHelper.PaintTriangle(e.Graphics, new SolidBrush(thumbColor), new Point(this.Width / 2, this.Height - (btnHeight - Math.Min(5, this.Width / 2))), Math.Min(5, this.Width / 2), GraphDirection.Downward);

        }

        /// <summary>
        /// Handles the MouseDown event of the CustomScrollbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void CustomScrollbar_MouseDown(object sender, MouseEventArgs e)
        {
            if (Maximum <= 0)
                return;
            Point ptPoint = this.PointToClient(Cursor.Position);
            int nTrackHeight = (this.Height - btnHeight * 2);
            //float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            float fThumbHeight = nTrackHeight - Maximum;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < m_intThumbMinHeight)
            {
                nThumbHeight = m_intThumbMinHeight;
                fThumbHeight = m_intThumbMinHeight;
            }

            int nTop = moThumbTop;
            nTop += btnHeight;


            Rectangle thumbrect = new Rectangle(new Point(1, nTop), new Size(this.Width - 2, nThumbHeight));
            if (thumbrect.Contains(ptPoint))
            {

                //hit the thumb
                nClickPoint = (ptPoint.Y - nTop);
                //MessageBox.Show(Convert.ToString((ptPoint.Y - nTop)));
                this.moThumbMouseDown = true;
            }
            else
            {
                Rectangle uparrowrect = new Rectangle(new Point(1, 0), new Size(this.Width, btnHeight));
                if (uparrowrect.Contains(ptPoint))
                {

                    int nRealRange = (Maximum - Minimum) - LargeChange;
                    int nPixelRange = (nTrackHeight - nThumbHeight);
                    if (nRealRange > 0)
                    {
                        if (nPixelRange > 0)
                        {
                            if ((moThumbTop - SmallChange) < 0)
                                moThumbTop = 0;
                            else
                                moThumbTop -= SmallChange;

                            //figure out value
                            float fPerc = (float)moThumbTop / (float)nPixelRange;
                            float fValue = fPerc * (Maximum - LargeChange);

                            moValue = (int)fValue;

                            if (ValueChanged != null)
                                ValueChanged(this, new EventArgs());

                            if (Scroll != null)
                                Scroll(this, new EventArgs());

                            Invalidate();
                        }
                    }
                }
                else
                {
                    Rectangle downarrowrect = new Rectangle(new Point(1, btnHeight + nTrackHeight), new Size(this.Width, btnHeight));
                    if (downarrowrect.Contains(ptPoint))
                    {
                        int nRealRange = (Maximum - Minimum) - LargeChange;
                        int nPixelRange = (nTrackHeight - nThumbHeight);
                        if (nRealRange > 0)
                        {
                            if (nPixelRange > 0)
                            {
                                if ((moThumbTop + SmallChange) > nPixelRange)
                                    moThumbTop = nPixelRange;
                                else
                                    moThumbTop += SmallChange;

                                //figure out value
                                float fPerc = (float)moThumbTop / (float)nPixelRange;
                                float fValue = fPerc * (Maximum - LargeChange);

                                moValue = (int)fValue;

                                if (ValueChanged != null)
                                    ValueChanged(this, new EventArgs());

                                if (Scroll != null)
                                    Scroll(this, new EventArgs());

                                Invalidate();
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Handles the MouseUp event of the CustomScrollbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void CustomScrollbar_MouseUp(object sender, MouseEventArgs e)
        {
            this.moThumbMouseDown = false;
            this.moThumbMouseDragging = false;
        }

        /// <summary>
        /// Moves the thumb.
        /// </summary>
        /// <param name="y">The y.</param>
        private void MoveThumb(int y)
        {
            int nRealRange = Maximum - Minimum;
            int nTrackHeight = (this.Height - btnHeight * 2);
            //float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            float fThumbHeight = nTrackHeight - Maximum;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight)
            {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < m_intThumbMinHeight)
            {
                nThumbHeight = m_intThumbMinHeight;
                fThumbHeight = m_intThumbMinHeight;
            }

            int nSpot = nClickPoint;

            int nPixelRange = (nTrackHeight - nThumbHeight);
            if (moThumbMouseDown && nRealRange > 0)
            {
                if (nPixelRange > 0)
                {
                    int nNewThumbTop = y - (btnHeight + nSpot);

                    if (nNewThumbTop < 0)
                    {
                        moThumbTop = nNewThumbTop = 0;
                    }
                    else if (nNewThumbTop > nPixelRange)
                    {
                        moThumbTop = nNewThumbTop = nPixelRange;
                    }
                    else
                    {
                        moThumbTop = y - (btnHeight + nSpot);
                    }


                    float fPerc = (float)moThumbTop / (float)nPixelRange;
                    float fValue = fPerc * (Maximum - (nNewThumbTop == nPixelRange ? 0 : LargeChange));
                    if (Math.Abs(moValue - fValue) < 1)
                    {
                        return;
                    }
                    moValue = (int)fValue;
                    Invalidate();

                    try
                    {
                        Application.DoEvents();
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the CustomScrollbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void CustomScrollbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moThumbMouseDown)
                return;

            if (moThumbMouseDown == true)
            {
                this.moThumbMouseDragging = true;
            }

            if (this.moThumbMouseDragging)
            {
                MoveThumb(e.Y);
            }

            if (ValueChanged != null)
                ValueChanged(this, new EventArgs());

            if (Scroll != null)
                Scroll(this, new EventArgs());
        }

    }
}