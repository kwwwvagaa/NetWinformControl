// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-31-2019
//
// ***********************************************************************
// <copyright file="UCRollText.cs">
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCRollText.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCRollText : UserControl
    {
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
                if (!string.IsNullOrEmpty(Text))
                {
                    Graphics g = this.CreateGraphics();
                    var size = g.MeasureString(Text, this.Font);
                    rectText = new Rectangle(0, (this.Height - rectText.Height) / 2 + 1, (int)size.Width, (int)size.Height);
                    rectText.Y = (this.Height - rectText.Height) / 2 + 1;
                }
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
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Bindable(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (!string.IsNullOrEmpty(value))
                {
                    Graphics g = this.CreateGraphics();
                    var size = g.MeasureString(value, this.Font);
                    rectText = new Rectangle(_ISChangeReset ? 0 : rectText.X, (this.Height - rectText.Height) / 2 + 1, (int)size.Width, (int)size.Height);

                }
                else
                {
                    rectText = Rectangle.Empty;
                }
            }
        }

        /// <summary>
        /// The roll style
        /// </summary>
        private RollStyle _RollStyle = RollStyle.LeftToRight;

        /// <summary>
        /// 文本改变是否重新从边缘运动
        /// </summary>
        private bool _ISChangeReset = false;




        /// <summary>
        /// Gets or sets the roll style.
        /// </summary>
        /// <value>The roll style.</value>
        [Description("滚动样式"), Category("自定义")]
        public RollStyle RollStyle
        {
            get { return _RollStyle; }
            set
            {
                _RollStyle = value;
                switch (value)
                {
                    case RollStyle.LeftToRight:
                        m_intdirection = 1;
                        break;
                    case RollStyle.RightToLeft:
                        m_intdirection = -1;
                        break;
                }
            }
        }



        [Description("文本改变是否重新从边缘运动"), Category("自定义")]
        public bool ISChangeReset
        {
            get { return _ISChangeReset; }
            set
            {
                _ISChangeReset = value;
            }
        }



        /// <summary>
        /// The move step
        /// </summary>
        private int _moveStep = 5;

        /// <summary>
        /// The move sleep time
        /// </summary>
        private int _moveSleepTime = 100;

        /// <summary>
        /// Gets or sets the move sleep time.
        /// </summary>
        /// <value>The move sleep time.</value>
        [Description("每次滚动间隔时间，越小速度越快"), Category("自定义")]
        public int MoveSleepTime
        {
            get { return _moveSleepTime; }
            set
            {
                if (value <= 0)
                {
                    return;
                }

                _moveSleepTime = value;
                m_timer.Interval = value;
            }
        }

        /// <summary>
        /// The m intdirection
        /// </summary>
        int m_intdirection = 1;

        /// <summary>
        /// The rect text
        /// </summary>
        Rectangle rectText;
        /// <summary>
        /// The m timer
        /// </summary>
        Timer m_timer;
        /// <summary>
        /// Initializes a new instance of the <see cref="UCRollText" /> class.
        /// </summary>
        public UCRollText()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            this.SizeChanged += UCRollText_SizeChanged;
            this.Size = new Size(450, 30);
            Text = "滚动文字";
            m_timer = new Timer();
            m_timer.Interval = 100;
            m_timer.Tick += m_timer_Tick;
            this.Load += UCRollText_Load;
            this.VisibleChanged += UCRollText_VisibleChanged;
            this.ForeColor = Color.FromArgb(255, 77, 59);
            if (rectText != Rectangle.Empty)
            {
                rectText.Y = (this.Height - rectText.Height) / 2 + 1;
            }
        }

        /// <summary>
        /// Handles the Tick event of the m_timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void m_timer_Tick(object sender, EventArgs e)
        {
            if (rectText == Rectangle.Empty)
            {
                return;
            }

            if (_RollStyle == HZH_Controls.Controls.RollStyle.BackAndForth && rectText.Width >= this.Width)
            {
                return;
            }
            rectText.X = rectText.X + _moveStep * m_intdirection;
            if (_RollStyle == HZH_Controls.Controls.RollStyle.BackAndForth)
            {
                if (rectText.X <= 0)
                {
                    m_intdirection = 1;
                }
                else if (rectText.Right >= this.Width)
                {
                    m_intdirection = -1;
                }
            }
            else if (_RollStyle == HZH_Controls.Controls.RollStyle.LeftToRight)
            {
                if (rectText.X > this.Width)
                {
                    rectText.X = -1 * rectText.Width - 1;
                }
            }
            else
            {
                if (rectText.Right < 0)
                {
                    rectText.X = this.Width + rectText.Width + 1;
                }
            }
            Refresh();
        }

        /// <summary>
        /// Handles the VisibleChanged event of the UCRollText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCRollText_VisibleChanged(object sender, EventArgs e)
        {
            m_timer.Enabled = this.Visible;
        }

        /// <summary>
        /// Handles the Load event of the UCRollText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCRollText_Load(object sender, EventArgs e)
        {
            if (_RollStyle == HZH_Controls.Controls.RollStyle.LeftToRight)
            {
                m_intdirection = 1;
                if (rectText != Rectangle.Empty)
                {
                    rectText.X = -1 * rectText.Width - 1;
                }
            }
            else if (_RollStyle == HZH_Controls.Controls.RollStyle.RightToLeft)
            {
                m_intdirection = -1;
                if (rectText != Rectangle.Empty)
                {
                    rectText.X = this.Width + rectText.Width + 1;
                }
            }
            else
            {
                m_intdirection = 1;
                if (rectText != Rectangle.Empty)
                {
                    rectText.X = 0;
                }
            }
            if (rectText != Rectangle.Empty)
            {
                rectText.Y = (this.Height - rectText.Height) / 2 + 1;
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the UCRollText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCRollText_SizeChanged(object sender, EventArgs e)
        {
            if (rectText != Rectangle.Empty)
            {
                rectText.Y = (this.Height - rectText.Height) / 2 + 1;
            }
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (rectText != Rectangle.Empty)
            {
                e.Graphics.SetGDIHigh();
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rectText.Location);
            }
        }
    }

    /// <summary>
    /// Enum RollStyle
    /// </summary>
    public enum RollStyle
    {
        /// <summary>
        /// The left to right
        /// </summary>
        LeftToRight,
        /// <summary>
        /// The right to left
        /// </summary>
        RightToLeft,
        /// <summary>
        /// The back and forth
        /// </summary>
        BackAndForth
    }
}
