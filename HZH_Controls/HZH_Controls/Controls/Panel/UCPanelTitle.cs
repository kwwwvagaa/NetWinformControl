// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-17-2019
//
// ***********************************************************************
// <copyright file="UCPanelTitle.cs">
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
    /// Class UCPanelTitle.
    /// Implements the <see cref="HZH_Controls.Controls.UCControlBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.UCControlBase" />
    public partial class UCPanelTitle : UCControlBase, IContainerControl
    {
        /// <summary>
        /// The m int maximum height
        /// </summary>
        private int m_intMaxHeight = 0;
        /// <summary>
        /// The is can expand
        /// </summary>
        private bool isCanExpand = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is can expand.
        /// </summary>
        /// <value><c>true</c> if this instance is can expand; otherwise, <c>false</c>.</value>
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
        /// <summary>
        /// The is expand
        /// </summary>
        private bool isExpand = false;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is expand.
        /// </summary>
        /// <value><c>true</c> if this instance is expand; otherwise, <c>false</c>.</value>
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

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
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

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Description("面板标题"), Category("自定义")]
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        /// <summary>
        /// 获取或设置控件的前景色。
        /// </summary>
        /// <value>The color of the fore.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
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
        /// <summary>
        /// Initializes a new instance of the <see cref="UCPanelTitle" /> class.
        /// </summary>
        public UCPanelTitle()
        {
            InitializeComponent();
            this.SizeChanged += UCPanelTitle_SizeChanged;
            if (isCanExpand)
            {
                lblTitle.Image = GetImg();
            }
            else
            {
                lblTitle.Image = null;
            }
        }

        /// <summary>
        /// The bit down
        /// </summary>
        Bitmap bitDown = null;
        /// <summary>
        /// The bit up
        /// </summary>
        Bitmap bitUp = null;
        /// <summary>
        /// Gets the img.
        /// </summary>
        /// <param name="blnRefresh">if set to <c>true</c> [BLN refresh].</param>
        /// <returns>Bitmap.</returns>
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

        /// <summary>
        /// Handles the MouseDown event of the lblTitle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (isCanExpand)
            {
                IsExpand = !IsExpand;
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the UCPanelTitle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void UCPanelTitle_SizeChanged(object sender, EventArgs e)
        {
            if (this.Height != lblTitle.Height)
            {
                m_intMaxHeight = this.Height;
            }
            lblTitle.Width = this.Width;
        }
    }
}
