// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-19-2019
//
// ***********************************************************************
// <copyright file="UCCrumbNavigation.cs">
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCCrumbNavigation.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DefaultEvent("ClickItemed")]
    public partial class UCCrumbNavigation : UserControl
    {
        /// <summary>
        /// The m nav color
        /// </summary>
        private Color m_navColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the color of the nav.
        /// </summary>
        /// <value>The color of the nav.</value>
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



        /// <summary>
        /// The m paths
        /// </summary>
        GraphicsPath[] m_paths;     

        private CrumbNavigationItem[] items;

        public CrumbNavigationItem[] Items
        {
            get { return items; }
            set
            {
                items = value;
                if (value == null)
                    m_paths = new GraphicsPath[0];
                else
                    m_paths = new GraphicsPath[value.Length];
                Refresh();
            }
        }

        /// <summary>
        /// 获取或设置控件显示的文字的字体。
        /// </summary>
        /// <value>The font.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
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

        /// <summary>
        /// 获取或设置控件的前景色。
        /// </summary>
        /// <value>The color of the fore.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
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

        public delegate void CrumbNavigationEventHander(object sender, CrumbNavigationClickEventArgs e);
        public event CrumbNavigationEventHander ClickItemed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UCCrumbNavigation" /> class.
        /// </summary>
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
            Items = new CrumbNavigationItem[0];
            if (ControlHelper.IsDesignMode())
            {
                Items = new CrumbNavigationItem[3];
                for (int i = 0; i < 3; i++)
                {
                    Items[i] = new CrumbNavigationItem() { Text = "item" + (i + 1), Key = i.ToString() };
                }
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the UCCrumbNavigation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        void UCCrumbNavigation_MouseDown(object sender, MouseEventArgs e)
        {
            if (ClickItemed != null)
            {
                if (!DesignMode)
                {
                    if (m_paths != null && m_paths.Length > 0)
                    {
                        for (int i = 0; i < m_paths.Length; i++)
                        {
                            if (m_paths[i].IsVisible(e.Location))
                            {
                                ClickItemed(this, new CrumbNavigationClickEventArgs() { Index = i, Item = items[i] });
                            }
                        }
                    }
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

            if (items != null && items.Length > 0)
            {
                var g = e.Graphics;
                g.SetGDIHigh();
                int intLastX = 0;
                int intLength = items.Length;
                for (int i = 0; i < items.Length; i++)
                {
                    GraphicsPath path = new GraphicsPath();
                    string strText = items[i].Text;
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
                    g.FillPath(new SolidBrush((items[i].ItemColor == null || items[i].ItemColor == Color.Empty || items[i].ItemColor == Color.Transparent) ? m_navColor : items[i].ItemColor.Value), path);

                    g.DrawString(strText, this.Font, new SolidBrush(this.ForeColor), new PointF(intLastX + 2 + (i == 0 ? 0 : 10), (this.Height - sizeF.Height) / 2 + 1));
                    m_paths[i] = path;
                    intLastX += ((i == 0 ? 0 : 10) + intTextWidth + (i == (intLength - 1) ? 0 : 10));
                }
            }

        }
    }
}
