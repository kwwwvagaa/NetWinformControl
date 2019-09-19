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

    [Designer(typeof(ScrollbarControlDesigner))]
    [DefaultEvent("Scroll")]
    public class UCVScrollbar : UCControlBase
    {
        //protected Color moChannelColor = Color.FromArgb(51, 166, 3);
        protected int moLargeChange = 10;
        protected int moSmallChange = 1;
        protected int moMinimum = 0;
        protected int moMaximum = 100;
        protected int moValue = 0;
        private int nClickPoint;
        protected int moThumbTop = 0;
        protected bool moAutoSize = false;
        private bool moThumbDown = false;
        private bool moThumbDragging = false;
        public new event EventHandler Scroll = null;
        public event EventHandler ValueChanged = null;

        private int btnHeight = 18;
        private int m_intThumbMinHeight = 15;

        public int BtnHeight
        {
            get { return btnHeight; }
            set { btnHeight = value; }
        }
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("LargeChange")]
        public int LargeChange
        {
            get { return moLargeChange; }
            set
            {
                moLargeChange = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("SmallChange")]
        public int SmallChange
        {
            get { return moSmallChange; }
            set
            {
                moSmallChange = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Minimum")]
        public int Minimum
        {
            get { return moMinimum; }
            set
            {
                moMinimum = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Maximum")]
        public int Maximum
        {
            get { return moMaximum; }
            set
            {
                moMaximum = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Value")]
        public int Value
        {
            get { return moValue; }
            set
            {
                moValue = value;

                int nTrackHeight = (this.Height - btnHeight * 2);
                float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
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

        private Color thumbColor = Color.FromArgb(255, 77, 58);

        public Color ThumbColor
        {
            get { return thumbColor; }
            set { thumbColor = value; }
        }

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




        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SetGDIHigh();

            //draw thumb
            int nTrackHeight = (this.Height - btnHeight * 2);
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
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
            e.Graphics.FillPath(new SolidBrush(thumbColor), new Rectangle(1, nTop, this.Width - 3, nThumbHeight).CreateRoundedRectanglePath(this.ConerRadius));

            ControlHelper.PaintTriangle(e.Graphics, new SolidBrush(thumbColor), new Point(this.Width / 2, btnHeight - Math.Min(5, this.Width / 2)), Math.Min(5, this.Width / 2), GraphDirection.Upward);
            ControlHelper.PaintTriangle(e.Graphics, new SolidBrush(thumbColor), new Point(this.Width / 2, this.Height - (btnHeight - Math.Min(5, this.Width / 2))), Math.Min(5, this.Width / 2), GraphDirection.Downward);

        }

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

        private void CustomScrollbar_MouseDown(object sender, MouseEventArgs e)
        {
            Point ptPoint = this.PointToClient(Cursor.Position);
            int nTrackHeight = (this.Height - btnHeight * 2);
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
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
                this.moThumbDown = true;
            }

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

        private void CustomScrollbar_MouseUp(object sender, MouseEventArgs e)
        {
            this.moThumbDown = false;
            this.moThumbDragging = false;
        }

        private void MoveThumb(int y)
        {
            int nRealRange = Maximum - Minimum;
            int nTrackHeight = (this.Height - btnHeight * 2);
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
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
            if (moThumbDown && nRealRange > 0)
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
                    float fValue = fPerc * (Maximum - LargeChange);
                    moValue = (int)fValue;

                    Application.DoEvents();

                    Invalidate();
                }
            }
        }

        private void CustomScrollbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moThumbDown)
                return;

            if (moThumbDown == true)
            {
                this.moThumbDragging = true;
            }

            if (this.moThumbDragging)
            {
                MoveThumb(e.Y);
            }

            if (ValueChanged != null)
                ValueChanged(this, new EventArgs());

            if (Scroll != null)
                Scroll(this, new EventArgs());
        }

    }

    internal class ScrollbarControlDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules selectionRules = base.SelectionRules;
                PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(this.Component)["AutoSize"];
                if (propDescriptor != null)
                {
                    bool autoSize = (bool)propDescriptor.GetValue(this.Component);
                    if (autoSize)
                    {
                        selectionRules = SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.BottomSizeable | SelectionRules.TopSizeable;
                    }
                    else
                    {
                        selectionRules = SelectionRules.Visible | SelectionRules.AllSizeable | SelectionRules.Moveable;
                    }
                }
                return selectionRules;
            }
        }
    }
}