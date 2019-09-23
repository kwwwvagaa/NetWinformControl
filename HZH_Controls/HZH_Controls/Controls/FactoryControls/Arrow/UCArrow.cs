// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-10
//
// ***********************************************************************
// <copyright file="UCArrow.cs">
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
    /// Class UCArrow.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCArrow : UserControl
    {
        /// <summary>
        /// The arrow color
        /// </summary>
        private Color arrowColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the color of the arrow.
        /// </summary>
        /// <value>The color of the arrow.</value>
        [Description("箭头颜色"), Category("自定义")]
        public Color ArrowColor
        {
            get { return arrowColor; }
            set
            {
                arrowColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// The border color
        /// </summary>
        private Color? borderColor = null;

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Description("箭头边框颜色，为空则无边框"), Category("自定义")]
        public Color? BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// The direction
        /// </summary>
        private ArrowDirection direction = ArrowDirection.Right;

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        [Description("箭头方向"), Category("自定义")]
        public ArrowDirection Direction
        {
            get { return direction; }
            set
            {
                direction = value;
                ResetPath();
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
        public override Color ForeColor
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
        /// <summary>
        /// The text
        /// </summary>
        private string text;
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Bindable(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        [Description("箭头文字"), Category("自定义")]
        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                Refresh();
            }
        }
        /// <summary>
        /// The m path
        /// </summary>
        GraphicsPath m_path;
        /// <summary>
        /// Initializes a new instance of the <see cref="UCArrow" /> class.
        /// </summary>
        public UCArrow()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.ForeColor = Color.White;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.SizeChanged += UCArrow_SizeChanged;
            this.Size = new Size(100, 50);
        }

        /// <summary>
        /// Handles the SizeChanged event of the UCArrow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCArrow_SizeChanged(object sender, EventArgs e)
        {
            ResetPath();
        }

        /// <summary>
        /// Resets the path.
        /// </summary>
        private void ResetPath()
        {
            Point[] ps = null;
            switch (direction)
            {
                case ArrowDirection.Left:
                    ps = new Point[] 
                    { 
                        new Point(0,this.Height/2),
                        new Point(40,0),
                        new Point(40,this.Height/4),
                        new Point(this.Width-1,this.Height/4),
                        new Point(this.Width-1,this.Height-this.Height/4),
                        new Point(40,this.Height-this.Height/4),
                        new Point(40,this.Height),
                        new Point(0,this.Height/2)
                    };
                    break;
                case ArrowDirection.Right:
                    ps = new Point[] 
                    {
                        new Point(0,this.Height/4),
                        new Point(this.Width-40,this.Height/4),
                        new Point(this.Width-40,0),
                        new Point(this.Width-1,this.Height/2),
                        new Point(this.Width-40,this.Height),
                        new Point(this.Width-40,this.Height-this.Height/4),                      
                        new Point(0,this.Height-this.Height/4),
                        new Point(0,this.Height/4)
                    };
                    break;
                case ArrowDirection.Top:
                    ps = new Point[] 
                    {
                       new Point(this.Width/2,0),
                       new Point(this.Width,40),
                       new Point(this.Width-this.Width/4,40),
                       new Point(this.Width-this.Width/4,this.Height-1),
                       new Point(this.Width/4,this.Height-1),
                       new Point(this.Width/4,40),
                       new Point(0,40),
                       new Point(this.Width/2,0),
                    };
                    break;
                case ArrowDirection.Bottom:
                    ps = new Point[] 
                    {
                       new Point(this.Width-this.Width/4,0),
                       new Point(this.Width-this.Width/4,this.Height-40),
                       new Point(this.Width,this.Height-40),
                       new Point(this.Width/2,this.Height-1),
                       new Point(0,this.Height-40),
                       new Point(this.Width/4,this.Height-40),
                       new Point(this.Width/4,0),
                       new Point(this.Width-this.Width/4,0),                      
                    };
                    break;
                case ArrowDirection.Left_Right:
                    ps = new Point[] 
                    { 
                        new Point(0,this.Height/2),
                        new Point(40,0),
                        new Point(40,this.Height/4),
                        new Point(this.Width-40,this.Height/4),
                        new Point(this.Width-40,0),
                        new Point(this.Width-1,this.Height/2),
                        new Point(this.Width-40,this.Height),
                        new Point(this.Width-40,this.Height-this.Height/4),
                        new Point(40,this.Height-this.Height/4),
                        new Point(40,this.Height),
                        new Point(0,this.Height/2),                       
                    };
                    break;
                case ArrowDirection.Top_Bottom:
                    ps = new Point[] 
                    {
                       new Point(this.Width/2,0),
                       new Point(this.Width,40),
                       new Point(this.Width-this.Width/4,40),
                       new Point(this.Width-this.Width/4,this.Height-40),
                       new Point(this.Width,this.Height-40),
                       new Point(this.Width/2,this.Height-1),
                       new Point(0,this.Height-40),
                       new Point(this.Width/4,this.Height-40),
                       new Point(this.Width/4,40),
                       new Point(0,40),
                       new Point(this.Width/2,0),                      
                    };
                    break;
            }
            m_path = new GraphicsPath();
            m_path.AddLines(ps);
            m_path.CloseAllFigures();
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SetGDIHigh();
            base.Region = new Region(m_path);

            g.FillPath(new SolidBrush(arrowColor), m_path);

            if (borderColor != null && borderColor != Color.Empty)
                g.DrawPath(new Pen(new SolidBrush(borderColor.Value)), m_path);
            if (!string.IsNullOrEmpty(text))
            {
                var size = g.MeasureString(Text, Font);
                g.DrawString(Text, Font, new SolidBrush(ForeColor), new PointF((this.Width - size.Width) / 2, (this.Height - size.Height) / 2));
            }
        }
    }

    /// <summary>
    /// Enum ArrowDirection
    /// </summary>
    public enum ArrowDirection
    {
        /// <summary>
        /// The left
        /// </summary>
        Left,
        /// <summary>
        /// The right
        /// </summary>
        Right,
        /// <summary>
        /// The top
        /// </summary>
        Top,
        /// <summary>
        /// The bottom
        /// </summary>
        Bottom,
        /// <summary>
        /// The left right
        /// </summary>
        Left_Right,
        /// <summary>
        /// The top bottom
        /// </summary>
        Top_Bottom
    }
}
