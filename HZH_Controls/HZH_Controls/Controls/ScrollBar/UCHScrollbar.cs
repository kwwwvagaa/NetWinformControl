using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    [Designer(typeof(ScrollbarControlDesigner))]
    [DefaultEvent("Scroll")]
    public class UCHScrollbar : UCControlBase
    {
        #region 属性    English:attribute
        /// <summary>
        /// The mo large change
        /// </summary>
        protected int moLargeChange = 10;
        /// <summary>
        /// The mo small change
        /// </summary>
        protected int moSmallChange = 1;
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
        protected int moThumbLeft = 0;
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
        private int btnWidth = 18;
        /// <summary>
        /// The m int thumb minimum height
        /// </summary>
        private int m_intThumbMinWidth = 15;

        /// <summary>
        /// Gets or sets the height of the BTN.
        /// </summary>
        /// <value>The height of the BTN.</value>
        public int BtnWidth
        {
            get { return btnWidth; }
            set { btnWidth = value; }
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
                if (moValue > moMaximum)
                    moValue = moMaximum;
                int nTrackWidth = (this.Width - btnWidth * 2);
                float fThumbWidth = nTrackWidth - Maximum;
                //float fThumbWidth = ((float)LargeChange / (float)Maximum) * nTrackWidth;
                int nThumbWidth = (int)fThumbWidth;

                if (nThumbWidth > nTrackWidth)
                {
                    nThumbWidth = nTrackWidth;
                    fThumbWidth = nTrackWidth;
                }
                if (nThumbWidth < m_intThumbMinWidth)
                {
                    nThumbWidth = m_intThumbMinWidth;
                    fThumbWidth = m_intThumbMinWidth;
                }

                //figure out value
                int nPixelRange = nTrackWidth - nThumbWidth;
                int nRealRange = (Maximum - Minimum) - LargeChange;
                float fPerc = 0.0f;
                if (nRealRange != 0)
                {
                    fPerc = (float)moValue / (float)nRealRange;

                }

                float fLeft = fPerc * nPixelRange;
                moThumbLeft = (int)fLeft;


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
        #endregion

        public UCHScrollbar()
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

            this.MinimumSize = new System.Drawing.Size(0, 10);
            this.Name = "UCHScrollbar";
            this.Size = new System.Drawing.Size(150, 18);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseUp);
            this.ResumeLayout(false);

        }

        #region 鼠标事件    English:Mouse event
        /// <summary>
        /// Handles the MouseDown event of the CustomScrollbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void CustomScrollbar_MouseDown(object sender, MouseEventArgs e)
        {
            if (Maximum <= 0)
            {
                return;
            }
            Point ptPoint = this.PointToClient(Cursor.Position);
            int nTrackWidth = (this.Width - btnWidth * 2);
            float fThumbWidth = nTrackWidth - Maximum;
            //float fThumbWidth = ((float)LargeChange / (float)Maximum) * nTrackWidth;
            int nThumbWidth = (int)fThumbWidth;

            if (nThumbWidth > nTrackWidth)
            {
                nThumbWidth = nTrackWidth;
                fThumbWidth = nTrackWidth;
            }
            if (nThumbWidth < m_intThumbMinWidth)
            {
                nThumbWidth = m_intThumbMinWidth;
                fThumbWidth = m_intThumbMinWidth;
            }

            int nLeft = moThumbLeft;
            nLeft += btnWidth;


            Rectangle thumbrect = new Rectangle(new Point(nLeft, 1), new Size(nThumbWidth, this.Height - 2));
            //滑块
            if (thumbrect.Contains(ptPoint))
            {
                //hit the thumb
                nClickPoint = (ptPoint.X - nLeft);
                this.moThumbMouseDown = true;
            }
            else
            {
                //左按钮
                Rectangle leftarrowrect = new Rectangle(new Point(0, 1), new Size(btnWidth, this.Height));
                if (leftarrowrect.Contains(ptPoint))
                {
                    int nRealRange = (Maximum - Minimum) - LargeChange;
                    int nPixelRange = (nTrackWidth - nThumbWidth);
                    if (nRealRange > 0)
                    {
                        if (nPixelRange > 0)
                        {
                            if ((moThumbLeft - SmallChange) < 0)
                                moThumbLeft = 0;
                            else
                                moThumbLeft -= SmallChange;

                            //figure out value
                            float fPerc = (float)moThumbLeft / (float)nPixelRange;
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
                    Rectangle rightarrowrect = new Rectangle(new Point(btnWidth + nTrackWidth, 1), new Size(btnWidth, this.Height));
                    if (rightarrowrect.Contains(ptPoint))
                    {
                        int nRealRange = (Maximum - Minimum) - LargeChange;
                        int nPixelRange = (nTrackWidth - nThumbWidth);
                        if (nRealRange > 0)
                        {
                            if (nPixelRange > 0)
                            {
                                if ((moThumbLeft + SmallChange) > nPixelRange)
                                    moThumbLeft = nPixelRange;
                                else
                                    moThumbLeft += SmallChange;

                                //figure out value
                                float fPerc = (float)moThumbLeft / (float)nPixelRange;
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
            Application.DoEvents();
        }

        /// <summary>
        /// Moves the thumb.
        /// </summary>
        /// <param name="x">The y.</param>
        private void MoveThumb(int x)
        {
            int nRealRange = Maximum - Minimum;
            int nTrackWidth = (this.Width - btnWidth * 2);
            // float fThumbWidth = ((float)LargeChange / (float)Maximum) * nTrackWidth;
            float fThumbWidth = nTrackWidth - Maximum;
            int nThumbWidth = (int)fThumbWidth;

            if (nThumbWidth > nTrackWidth)
            {
                nThumbWidth = nTrackWidth;
                fThumbWidth = nTrackWidth;
            }
            if (nThumbWidth < m_intThumbMinWidth)
            {
                nThumbWidth = m_intThumbMinWidth;
                fThumbWidth = m_intThumbMinWidth;
            }

            int nSpot = nClickPoint;

            int nPixelRange = (nTrackWidth - nThumbWidth);
            if (moThumbMouseDown && nRealRange > 0)
            {
                if (nPixelRange > 0)
                {
                    int nNewThumbLeft = x - (btnWidth + nSpot);

                    if (nNewThumbLeft < 0)
                    {
                        moThumbLeft = nNewThumbLeft = 0;
                    }
                    else if (nNewThumbLeft > nPixelRange)
                    {
                        moThumbLeft = nNewThumbLeft = nPixelRange;
                    }
                    else
                    {
                        moThumbLeft = x - (btnWidth + nSpot);
                    }


                    float fPerc = (float)moThumbLeft / (float)nPixelRange;
                    float fValue = fPerc * (Maximum - (nNewThumbLeft == nPixelRange ? 0 : LargeChange));
                    //float fValue = fPerc * (Maximum - LargeChange);
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
                MoveThumb(e.X);
            }

            if (ValueChanged != null)
                ValueChanged(this, new EventArgs());

            if (Scroll != null)
                Scroll(this, new EventArgs());
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SetGDIHigh();
            if (Maximum > 0)
            {
                //draw thumb
                int nTrackWidth = (this.Width - btnWidth * 2);
                //float fThumbWidth = ((float)LargeChange / (float)Maximum) * nTrackWidth;
                float fThumbWidth = nTrackWidth - Maximum;
                int nThumbWidth = (int)fThumbWidth;

                if (nThumbWidth > nTrackWidth)
                {
                    nThumbWidth = nTrackWidth;
                    fThumbWidth = nTrackWidth;
                }
                if (nThumbWidth < m_intThumbMinWidth)
                {
                    nThumbWidth = m_intThumbMinWidth;
                    fThumbWidth = m_intThumbMinWidth;
                }
                int nLeft = moThumbLeft;
                nLeft += btnWidth;
                if (nLeft + nThumbWidth > this.Width - btnWidth)
                    nLeft = this.Width - btnWidth - nThumbWidth;
                e.Graphics.FillPath(new SolidBrush(thumbColor), new Rectangle(nLeft, 1, nThumbWidth, this.Height - 3).CreateRoundedRectanglePath(this.ConerRadius));
            }
            ControlHelper.PaintTriangle(e.Graphics, new SolidBrush(thumbColor), new Point(btnWidth - Math.Min(5, this.Height / 2), this.Height / 2), Math.Min(5, this.Height / 2), GraphDirection.Leftward);
            ControlHelper.PaintTriangle(e.Graphics, new SolidBrush(thumbColor), new Point(this.Width - (btnWidth - Math.Min(5, this.Height / 2)), this.Height / 2), Math.Min(5, this.Height / 2), GraphDirection.Rightward);

        }
    }

}
