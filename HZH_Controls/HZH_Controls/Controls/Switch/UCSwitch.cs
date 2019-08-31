// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCSwitch.cs
// 作　　者：HZH
// 创建日期：2019-08-31 16:05:21
// 功能描述：UCSwitch    English:UCSwitch
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
    [DefaultEvent("CheckedChanged")]
    public partial class UCSwitch : UserControl
    {
        [Description("选中改变事件"), Category("自定义")]
        public event EventHandler CheckedChanged;
        private Color m_trueColor = Color.FromArgb(73, 119, 232);

        [Description("选中时颜色"), Category("自定义")]
        public Color TrueColor
        {
            get { return m_trueColor; }
            set
            {
                m_trueColor = value;
                Refresh();
            }
        }

        private Color m_falseColor = Color.FromArgb(180, 180, 180);

        [Description("没有选中时颜色"), Category("自定义")]
        public Color FalseColor
        {
            get { return m_falseColor; }
            set
            {
                m_falseColor = value;
                Refresh();
            }
        }

        private bool m_checked;

        [Description("是否选中"), Category("自定义")]
        public bool Checked
        {
            get { return m_checked; }
            set
            {
                m_checked = value;
                Refresh();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this, null);
                }
            }
        }

        private string[] m_texts;

        [Description("文本值，当选中或没有选中时显示，必须是长度为2的数组"), Category("自定义")]
        public string[] Texts
        {
            get { return m_texts; }
            set
            {
                m_texts = value;
                Refresh();
            }
        }
        private SwitchType m_switchType = SwitchType.Ellipse;

        [Description("显示类型"), Category("自定义")]
        public SwitchType SwitchType
        {
            get { return m_switchType; }
            set
            {
                m_switchType = value;
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


        public UCSwitch()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MouseDown += UCSwitch_MouseDown;
        }

        void UCSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            Checked = !Checked;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();
            if (m_switchType == HZH_Controls.Controls.SwitchType.Ellipse)
            {
                var fillColor = m_checked ? m_trueColor : m_falseColor;
                GraphicsPath path = new GraphicsPath();
                path.AddLine(new Point(this.Height / 2, 1), new Point(this.Width - this.Height / 2, 1));
                path.AddArc(new Rectangle(this.Width - this.Height - 1, 1, this.Height - 2, this.Height - 2), -90, 180);
                path.AddLine(new Point(this.Width - this.Height / 2, this.Height - 1), new Point(this.Height / 2, this.Height - 1));
                path.AddArc(new Rectangle(1, 1, this.Height - 2, this.Height - 2), 90, 180);
                g.FillPath(new SolidBrush(fillColor), path);

                string strText = string.Empty;
                if (m_texts != null && m_texts.Length == 2)
                {
                    if (m_checked)
                    {
                        strText = m_texts[0];
                    }
                    else
                    {
                        strText = m_texts[1];
                    }
                }

                if (m_checked)
                {
                    g.FillEllipse(Brushes.White, new Rectangle(this.Width - this.Height - 1 + 2, 1 + 2, this.Height - 2 - 4, this.Height - 2 - 4));
                    if (string.IsNullOrEmpty(strText))
                    {
                        g.DrawEllipse(new Pen(Color.White, 2), new Rectangle((this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2, (this.Height - 2 - (this.Height - 2 - 4) / 2) / 2 + 1, (this.Height - 2 - 4) / 2, (this.Height - 2 - 4) / 2));
                    }
                    else
                    {
                        System.Drawing.SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                        int intTextY = (this.Height - (int)sizeF.Height) / 2 + 2;
                        g.DrawString(strText, Font, Brushes.White, new Point((this.Height - 2 - 4) / 2, intTextY));
                    }
                }
                else
                {
                    g.FillEllipse(Brushes.White, new Rectangle(1 + 2, 1 + 2, this.Height - 2 - 4, this.Height - 2 - 4));
                    if (string.IsNullOrEmpty(strText))
                    {
                        g.DrawEllipse(new Pen(Color.White, 2), new Rectangle(this.Width - 2 - (this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2, (this.Height - 2 - (this.Height - 2 - 4) / 2) / 2 + 1, (this.Height - 2 - 4) / 2, (this.Height - 2 - 4) / 2));
                    }
                    else
                    {
                        System.Drawing.SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                        int intTextY = (this.Height - (int)sizeF.Height) / 2 + 2;
                        g.DrawString(strText, Font, Brushes.White, new Point(this.Width - 2 - (this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2 - (int)sizeF.Width / 2, intTextY));
                    }
                }
            }
            else if (m_switchType == HZH_Controls.Controls.SwitchType.Quadrilateral)
            {
                var fillColor = m_checked ? m_trueColor : m_falseColor;
                GraphicsPath path = new GraphicsPath();
                int intRadius = 5;
                path.AddArc(0, 0, intRadius, intRadius, 180f, 90f);
                path.AddArc(this.Width - intRadius - 1, 0, intRadius, intRadius, 270f, 90f);
                path.AddArc(this.Width - intRadius - 1, this.Height - intRadius - 1, intRadius, intRadius, 0f, 90f);
                path.AddArc(0, this.Height - intRadius - 1, intRadius, intRadius, 90f, 90f);

                g.FillPath(new SolidBrush(fillColor), path);

                string strText = string.Empty;
                if (m_texts != null && m_texts.Length == 2)
                {
                    if (m_checked)
                    {
                        strText = m_texts[0];
                    }
                    else
                    {
                        strText = m_texts[1];
                    }
                }

                if (m_checked)
                {
                    GraphicsPath path2 = new GraphicsPath();
                    path2.AddArc(this.Width - this.Height - 1 + 2, 1 + 2, intRadius, intRadius, 180f, 90f);
                    path2.AddArc(this.Width - 1 - 2 - intRadius, 1 + 2, intRadius, intRadius, 270f, 90f);
                    path2.AddArc(this.Width - 1 - 2 - intRadius, this.Height - 2 - intRadius - 1, intRadius, intRadius, 0f, 90f);
                    path2.AddArc(this.Width - this.Height - 1 + 2, this.Height - 2 - intRadius - 1, intRadius, intRadius, 90f, 90f);
                    g.FillPath(Brushes.White, path2);

                    if (string.IsNullOrEmpty(strText))
                    {
                        g.DrawEllipse(new Pen(Color.White, 2), new Rectangle((this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2, (this.Height - 2 - (this.Height - 2 - 4) / 2) / 2 + 1, (this.Height - 2 - 4) / 2, (this.Height - 2 - 4) / 2));
                    }
                    else
                    {
                        System.Drawing.SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                        int intTextY = (this.Height - (int)sizeF.Height) / 2 + 2;
                        g.DrawString(strText, Font, Brushes.White, new Point((this.Height - 2 - 4) / 2, intTextY));
                    }
                }
                else
                {
                    GraphicsPath path2 = new GraphicsPath();
                    path2.AddArc(1 + 2, 1 + 2, intRadius, intRadius, 180f, 90f);
                    path2.AddArc(this.Height - 2 - intRadius, 1 + 2, intRadius, intRadius, 270f, 90f);
                    path2.AddArc(this.Height - 2 - intRadius, this.Height - 2 - intRadius - 1, intRadius, intRadius, 0f, 90f);
                    path2.AddArc(1 + 2, this.Height - 2 - intRadius - 1, intRadius, intRadius, 90f, 90f);
                    g.FillPath(Brushes.White, path2);

                    //g.FillEllipse(Brushes.White, new Rectangle(1 + 2, 1 + 2, this.Height - 2 - 4, this.Height - 2 - 4));
                    if (string.IsNullOrEmpty(strText))
                    {
                        g.DrawEllipse(new Pen(Color.White, 2), new Rectangle(this.Width - 2 - (this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2, (this.Height - 2 - (this.Height - 2 - 4) / 2) / 2 + 1, (this.Height - 2 - 4) / 2, (this.Height - 2 - 4) / 2));
                    }
                    else
                    {
                        System.Drawing.SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                        int intTextY = (this.Height - (int)sizeF.Height) / 2 + 2;
                        g.DrawString(strText, Font, Brushes.White, new Point(this.Width - 2 - (this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2 - (int)sizeF.Width / 2, intTextY));
                    }
                }
            }
            else
            {
                var fillColor = m_checked ? m_trueColor : m_falseColor;
                int intLineHeight = (this.Height - 2 - 4) / 2;

                GraphicsPath path = new GraphicsPath();
                path.AddLine(new Point(this.Height / 2, (this.Height - intLineHeight) / 2), new Point(this.Width - this.Height / 2, (this.Height - intLineHeight) / 2));
                path.AddArc(new Rectangle(this.Width - this.Height / 2 - intLineHeight - 1, (this.Height - intLineHeight) / 2, intLineHeight, intLineHeight), -90, 180);
                path.AddLine(new Point(this.Width - this.Height / 2, (this.Height - intLineHeight) / 2 + intLineHeight), new Point(this.Width - this.Height / 2, (this.Height - intLineHeight) / 2 + intLineHeight));
                path.AddArc(new Rectangle(this.Height / 2, (this.Height - intLineHeight) / 2, intLineHeight, intLineHeight), 90, 180);
                g.FillPath(new SolidBrush(fillColor), path);

                if (m_checked)
                {
                    g.FillEllipse(new SolidBrush(fillColor), new Rectangle(this.Width - this.Height - 1 + 2, 1 + 2, this.Height - 2 - 4, this.Height - 2 - 4));
                    g.FillEllipse(Brushes.White, new Rectangle(this.Width - 2 - (this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2 - 4, (this.Height - 2 - (this.Height - 2 - 4) / 2) / 2 + 1, (this.Height - 2 - 4) / 2, (this.Height - 2 - 4) / 2));
                }
                else
                {
                    g.FillEllipse(new SolidBrush(fillColor), new Rectangle(1 + 2, 1 + 2, this.Height - 2 - 4, this.Height - 2 - 4));
                    g.FillEllipse(Brushes.White, new Rectangle((this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2 + 4, (this.Height - 2 - (this.Height - 2 - 4) / 2) / 2 + 1, (this.Height - 2 - 4) / 2, (this.Height - 2 - 4) / 2));
                }
            }
        }

    }

    public enum SwitchType
    {
        /// <summary>
        /// 椭圆
        /// </summary>
        Ellipse,
        /// <summary>
        /// 四边形
        /// </summary>
        Quadrilateral,
        /// <summary>
        /// 横线
        /// </summary>
        Line
    }
}
