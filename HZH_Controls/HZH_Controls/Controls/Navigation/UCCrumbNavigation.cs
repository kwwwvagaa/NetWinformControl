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
    public partial class UCCrumbNavigation : UserControl
    {
        private Color m_navColor = Color.FromArgb(111, 122, 126);

        public Color NavColor
        {
            get { return m_navColor; }
            set
            {
                if (value == Color.Empty || value == Color.Transparent)
                    return;
                m_navColor = value;
                Refresh();
            }
        }


        private string[] m_navigations = new string[] { "目录1", "目录2", "目录3" };
        GraphicsPath[] m_paths;
        public string[] Navigations
        {
            get { return m_navigations; }
            set
            {
                m_navigations = value;
                if (value == null)
                    m_paths = new GraphicsPath[0];
                else
                    m_paths = new GraphicsPath[value.Length];
                Refresh();
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                Refresh();
            }
        }

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

        public UCCrumbNavigation()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MouseDown += UCCrumbNavigation_MouseDown;
        }

        void UCCrumbNavigation_MouseDown(object sender, MouseEventArgs e)
        {
            if (!DesignMode)
            {
                if (m_paths != null && m_paths.Length > 0)
                {
                    for (int i = 0; i < m_paths.Length; i++)
                    {
                        if (m_paths[i].IsVisible(e.Location))
                        {
                            HZH_Controls.Forms.FrmTips.ShowTipsSuccess(this.FindForm(), m_navigations[i]);
                        }
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (m_navigations != null && m_navigations.Length > 0)
            {
                var g = e.Graphics;
                g.SetGDIHigh();
                int intLastX = 0;
                int intLength = m_navigations.Length;
                for (int i = 0; i < m_navigations.Length; i++)
                {
                    GraphicsPath path = new GraphicsPath();
                    string strText = m_navigations[i];
                    System.Drawing.SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                    int intTextWidth = (int)sizeF.Width + 1;
                    path.AddLine(new Point(intLastX + 1, 1), new Point(intLastX + 1 + (i == 0 ? 0 : 10) + intTextWidth, 1));

                    //if (i != (intLength - 1))
                    //{
                    path.AddLine(new Point(intLastX + 1 + (i == 0 ? 0 : 10) + intTextWidth, 1), new Point(intLastX + 1 + (i == 0 ? 0 : 10) + intTextWidth + 10, this.Height / 2));
                    path.AddLine(new Point(intLastX + 1 + (i == 0 ? 0 : 10) + intTextWidth + 10, this.Height / 2), new Point(intLastX + 1 + (i == 0 ? 0 : 10) + intTextWidth - 1, this.Height - 1));
                    //}
                    //else
                    //{
                    //    path.AddLine(new Point(intLastX + 1 + (i == 0 ? 0 : 10) + intTextWidth, 1), new Point(intLastX + 1 + (i == 0 ? 0 : 10) + intTextWidth, this.Height - 1));
                    //}

                    path.AddLine(new Point(intLastX + 1 + (i == 0 ? 0 : 10) + intTextWidth, this.Height - 1), new Point(intLastX + 1, this.Height - 1));

                    if (i != 0)
                    {
                        path.AddLine(new Point(intLastX, this.Height - 1), new Point(intLastX + 1 + 10, this.Height / 2));
                        path.AddLine(new Point(intLastX + 1 + 10, this.Height / 2), new Point(intLastX + 1, 1));
                    }
                    else
                    {
                        path.AddLine(new Point(intLastX + 1, this.Height - 1), new Point(intLastX + 1, 1));
                    }
                    g.FillPath(new SolidBrush(m_navColor), path);

                    g.DrawString(strText, this.Font, new SolidBrush(this.ForeColor), new PointF(intLastX + 2 + (i == 0 ? 0 : 10), (this.Height - sizeF.Height) / 2 + 1));
                    m_paths[i] = path;
                    intLastX += ((i == 0 ? 0 : 10) + intTextWidth + (i == (intLength - 1) ? 0 : 10));
                }
            }

        }
    }
}
