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
    public partial class UCPanelTitle : UCControlBase
    {
        private int m_intMaxHeight = 0;
        private bool isCanExpand = true;

        [Description("是否可折叠"), Category("自定义")]
        public bool IsCanExpand
        {
            get { return isCanExpand; }
            set
            {
                isCanExpand = value;
                if (value)
                {
                    lblTitle.Image = GetImg();
                }
                else
                {
                    lblTitle.Image = null;
                }
            }
        }
        private bool isExpand = false;

        [Description("是否已折叠"), Category("自定义")]
        public bool IsExpand
        {
            get { return isExpand; }
            set
            {
                isExpand = value;
                if (value)
                {
                    m_intMaxHeight = this.Height;
                    this.Height = lblTitle.Height;
                }
                else
                {
                    this.Height = m_intMaxHeight;
                }

                lblTitle.Image = GetImg();
            }
        }

        [Description("边框颜色"), Category("自定义")]
        public Color BorderColor
        {
            get { return this.RectColor; }
            set
            {
                this.RectColor = value;
                this.lblTitle.BackColor = value;
            }
        }

        [Description("面板标题"), Category("自定义")]
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public override Color ForeColor
        {
            get
            {
                return this.lblTitle.ForeColor;
            }
            set
            {
                this.lblTitle.ForeColor = value;
                GetImg(true);
                if (isCanExpand)
                {
                    lblTitle.Image = GetImg();
                }
                else
                {
                    lblTitle.Image = null;
                }
            }
        }
        public UCPanelTitle()
        {
            InitializeComponent();
            if (isCanExpand)
            {
                lblTitle.Image = GetImg();
            }
            else
            {
                lblTitle.Image = null;
            }
        }

        Bitmap bitDown = null;
        Bitmap bitUp = null;
        private Bitmap GetImg(bool blnRefresh = false)
        {
            if (isExpand)
            {
                if (bitDown == null || blnRefresh)
                {
                    bitDown = new Bitmap(24, 24);
                    Graphics g = Graphics.FromImage(bitDown);
                    g.SetGDIHigh();
                    GraphicsPath path = new GraphicsPath();
                    path.AddLine(3, 5, 21, 5);
                    path.AddLine(21, 5, 12, 19);
                    path.AddLine(12, 19, 3, 5);
                    g.FillPath(new SolidBrush(ForeColor), path);
                    g.Dispose();
                }
                return bitDown;
            }
            else
            {
                if (bitUp == null || blnRefresh)
                {
                    bitUp = new Bitmap(24, 24);
                    Graphics g = Graphics.FromImage(bitUp);
                    g.SetGDIHigh();
                    GraphicsPath path = new GraphicsPath();
                    path.AddLine(3, 19, 21, 19);
                    path.AddLine(21, 19, 12, 5);
                    path.AddLine(12, 5, 3, 19);
                    g.FillPath(new SolidBrush(ForeColor), path);
                    g.Dispose();
                }
                return bitUp;
            }

        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (isCanExpand)
            {
                IsExpand = !IsExpand;
            }
        }

        private void UCPanelTitle_SizeChanged(object sender, EventArgs e)
        {
            if (this.Height != lblTitle.Height)
            {
                m_intMaxHeight = this.Height;
            }
        }
    }
}
