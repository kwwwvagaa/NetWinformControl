// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-10-09
//
// ***********************************************************************
// <copyright file="UCSplitLabel.cs">
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
using System.ComponentModel;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCSplitLabel.
    /// Implements the <see cref="System.Windows.Forms.Label" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Label" />
    public class UCSplitLabel : Label
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Localizable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                ResetMaxSize();
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
        [Localizable(true)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                ResetMaxSize();
            }
        }
        /// <summary>
        /// 获取或设置大小，该大小是 <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> 可以指定的下限。
        /// </summary>
        /// <value>The minimum size.</value>
        [Localizable(true)]
        public override Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }
            set
            {
                base.MinimumSize = value;
                ResetMaxSize();
            }
        }


        /// <summary>
        /// 获取或设置大小，该大小是 <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> 可以指定的上限。
        /// </summary>
        /// <value>The maximum size.</value>
        [Localizable(true)]
        public override Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }
            set
            {
                base.MaximumSize = value;
                ResetMaxSize();
            }
        }
        /// <summary>
        /// 获取或设置一个值，该值指示是否自动调整控件的大小以完整显示其内容。
        /// </summary>
        /// <value><c>true</c> if [automatic size]; otherwise, <c>false</c>.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }


        /// <summary>
        /// The line color
        /// </summary>
        private Color lineColor = LineColors.Light;

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        public Color LineColor
        {
            get { return lineColor; }
            set
            {
                lineColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Resets the maximum size.
        /// </summary>
        private void ResetMaxSize()
        {
            using (var g = this.CreateGraphics())
            {
                var _width = Width;
                var size = g.MeasureString(string.IsNullOrEmpty(Text) ? "A" : Text, Font);
                if (MinimumSize.Height != (int)size.Height)
                    MinimumSize = new Size(base.MinimumSize.Width, (int)size.Height);
                if (MaximumSize.Height != (int)size.Height)
                    MaximumSize = new Size(base.MaximumSize.Width, (int)size.Height);
                this.Width = _width;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UCSplitLabel"/> class.
        /// </summary>
        public UCSplitLabel()
            : base()
        {
            if (ControlHelper.IsDesignMode())
            {
                Text = "分割线";
                Font = new Font("微软雅黑", 8f);
            }
            this.AutoSize = false;
            Padding = new Padding(20, 0, 0, 0);
            MinimumSize = new System.Drawing.Size(150, 10);
            PaddingChanged += UCSplitLabel_PaddingChanged;
            this.Width = 200;
        }

        /// <summary>
        /// Handles the PaddingChanged event of the UCSplitLabel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void UCSplitLabel_PaddingChanged(object sender, EventArgs e)
        {
            if (Padding.Left < 20)
            {
                Padding = new Padding(20, Padding.Top, Padding.Right, Padding.Bottom);
            }
        }

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();

            var size = g.MeasureString(Text, Font);
            g.DrawLine(new Pen(new SolidBrush(lineColor)), new PointF(1, Padding.Top + (this.Height - Padding.Top - Padding.Bottom) / 2), new PointF(Padding.Left - 2, Padding.Top + (this.Height - Padding.Top - Padding.Bottom) / 2));
            g.DrawLine(new Pen(new SolidBrush(lineColor)), new PointF(Padding.Left + size.Width + 1, Padding.Top + (this.Height - Padding.Top - Padding.Bottom) / 2), new PointF(Width - Padding.Right, Padding.Top + (this.Height - Padding.Top - Padding.Bottom) / 2));

        }
    }
}
