// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-05
//
// ***********************************************************************
// <copyright file="UCBottle.cs">
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
    /// Class UCBottle.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCBottle : UserControl
    {
        //瓶身区域
        /// <summary>
        /// The m working rect
        /// </summary>
        Rectangle m_workingRect;

        /// <summary>
        /// The title
        /// </summary>
        string title = "瓶子1";

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Description("标题"), Category("自定义")]
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                ResetWorkingRect();
                Refresh();
            }
        }

        /// <summary>
        /// The bottle color
        /// </summary>
        private Color bottleColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the color of the bottle.
        /// </summary>
        /// <value>The color of the bottle.</value>
        [Description("瓶子颜色"), Category("自定义")]
        public Color BottleColor
        {
            get { return bottleColor; }
            set
            {
                bottleColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// The bottle mouth color
        /// </summary>
        private Color bottleMouthColor = Color.FromArgb(105, 105, 105);

        /// <summary>
        /// Gets or sets the color of the bottle mouth.
        /// </summary>
        /// <value>The color of the bottle mouth.</value>
        [Description("瓶口颜色"), Category("自定义")]
        public Color BottleMouthColor
        {
            get { return bottleMouthColor; }
            set { bottleMouthColor = value; }
        }

        /// <summary>
        /// The liquid color
        /// </summary>
        private Color liquidColor = Color.FromArgb(3, 169, 243);

        /// <summary>
        /// Gets or sets the color of the liquid.
        /// </summary>
        /// <value>The color of the liquid.</value>
        [Description("液体颜色"), Category("自定义")]
        public Color LiquidColor
        {
            get { return liquidColor; }
            set
            {
                liquidColor = value;
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
        [Description("文字字体"), Category("自定义")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                ResetWorkingRect();
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
        [Description("文字颜色"), Category("自定义")]
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

        /// <summary>
        /// The maximum value
        /// </summary>
        private decimal maxValue = 100;

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        [Description("最大值"), Category("自定义")]
        public decimal MaxValue
        {
            get { return maxValue; }
            set
            {
                if (value < m_value)
                    return;
                maxValue = value;
                Refresh();
            }
        }

        /// <summary>
        /// The m value
        /// </summary>
        private decimal m_value = 50;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Description("值"), Category("自定义")]
        public decimal Value
        {
            get { return m_value; }
            set
            {
                if (value <= 0 || value > maxValue)
                    return;
                m_value = value;
                Refresh();
            }
        }

        /// <summary>
        /// The m no
        /// </summary>
        private string m_NO;
        /// <summary>
        /// Gets or sets the NO.
        /// </summary>
        /// <value>The no.</value>
        [Description("编号"), Category("自定义")]
        public string NO
        {
            get { return m_NO; }
            set
            {
                m_NO = value;
                Refresh();
            }
        }

        private Direction direction = Direction.Down;

        [Description("瓶子方向，默认朝下"), Category("自定义")]
        public Direction Direction
        {
            get { return direction; }
            set
            {
                direction = value;
                Refresh();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCBottle" /> class.
        /// </summary>
        public UCBottle()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.SizeChanged += UCBottle_SizeChanged;
            this.Size = new Size(100, 150);
        }

        /// <summary>
        /// Handles the SizeChanged event of the UCBottle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCBottle_SizeChanged(object sender, EventArgs e)
        {
            ResetWorkingRect();
        }

        /// <summary>
        /// Resets the working rect.
        /// </summary>
        private void ResetWorkingRect()
        {
            var g = this.CreateGraphics();
            var size = g.MeasureString(title, Font);
            if (direction == HZH_Controls.Controls.Direction.Down)
                m_workingRect = new Rectangle(0, (int)size.Height + 10, this.Width, this.Height - ((int)size.Height + 10) - 15);
            else
                m_workingRect = new Rectangle(0, 15, this.Width, this.Height - ((int)size.Height + 10) - 15);

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


            if (direction == HZH_Controls.Controls.Direction.Down)
            {
                //写文字
                var size = g.MeasureString(title, Font);
                g.DrawString(title, Font, new SolidBrush(ForeColor), new PointF((this.Width - size.Width) / 2, 2));
                //画空瓶子
                GraphicsPath pathPS = new GraphicsPath();
                Point[] psPS = new Point[] 
                {       
                    new Point(m_workingRect.Left, m_workingRect.Top),
                    new Point(m_workingRect.Right - 1, m_workingRect.Top),
                    new Point(m_workingRect.Right - 1, m_workingRect.Bottom - 15),
                    new Point(m_workingRect.Right - 1 - m_workingRect.Width / 4, m_workingRect.Bottom),
                    new Point(m_workingRect.Left + m_workingRect.Width / 4, m_workingRect.Bottom),
                    new Point(m_workingRect.Left, m_workingRect.Bottom - 15),
                };
                pathPS.AddLines(psPS);
                pathPS.CloseAllFigures();
                g.FillPath(new SolidBrush(bottleColor), pathPS);
                //画液体
                decimal decYTHeight = (m_value / maxValue) * m_workingRect.Height;
                GraphicsPath pathYT = new GraphicsPath();
                Rectangle rectYT = Rectangle.Empty;
                if (decYTHeight < 15)
                {
                    PointF[] psYT = new PointF[] 
                    { 
                        new PointF((float)(m_workingRect.Left+(15-decYTHeight))+3,(float)(m_workingRect.Bottom-decYTHeight)),                   
                        new PointF((float)(m_workingRect.Right-(15-decYTHeight))-3,(float)(m_workingRect.Bottom-decYTHeight)),  
                        new PointF(m_workingRect.Right-1-m_workingRect.Width/4, m_workingRect.Bottom),
                        new PointF(m_workingRect.Left+m_workingRect.Width/4, m_workingRect.Bottom),
                    };
                    pathYT.AddLines(psYT);
                    pathYT.CloseAllFigures();
                    rectYT = new Rectangle((m_workingRect.Left + (15 - (int)decYTHeight)) + 3, m_workingRect.Bottom - (int)decYTHeight - 5, m_workingRect.Width - (int)(15 - decYTHeight) * 2 - 8, 10);
                }
                else
                {
                    PointF[] psYT = new PointF[] 
                    { 
                        new PointF(m_workingRect.Left,(float)(m_workingRect.Bottom-decYTHeight)),
                        new PointF(m_workingRect.Right-1,(float)(m_workingRect.Bottom-decYTHeight)),
                        new PointF(m_workingRect.Right-1,m_workingRect.Bottom-15),
                        new PointF(m_workingRect.Right-1-m_workingRect.Width/4, m_workingRect.Bottom),
                        new PointF(m_workingRect.Left+m_workingRect.Width/4, m_workingRect.Bottom),
                        new PointF(m_workingRect.Left,m_workingRect.Bottom-15),
                    };
                    pathYT.AddLines(psYT);
                    pathYT.CloseAllFigures();
                    rectYT = new Rectangle(m_workingRect.Left, m_workingRect.Bottom - (int)decYTHeight - 5, m_workingRect.Width, 10);
                }

                g.FillPath(new SolidBrush(liquidColor), pathYT);
                g.FillPath(new SolidBrush(Color.FromArgb(50, bottleMouthColor)), pathYT);
                //画液体面
                g.FillEllipse(new SolidBrush(liquidColor), rectYT);
                g.FillEllipse(new SolidBrush(Color.FromArgb(50, Color.White)), rectYT);

                //画高亮
                int intCount = m_workingRect.Width / 2 / 4;
                int intSplit = (255 - 100) / intCount;
                for (int i = 0; i < intCount; i++)
                {
                    int _penWidth = m_workingRect.Width / 2 - 4 * i;
                    if (_penWidth <= 0)
                        _penWidth = 1;
                    g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(10, Color.White)), _penWidth), new Point(m_workingRect.Width / 2, m_workingRect.Top), new Point(m_workingRect.Width / 2, m_workingRect.Bottom - 15));
                    if (_penWidth == 1)
                        break;
                }

                //画瓶底
                g.FillEllipse(new SolidBrush(bottleColor), new RectangleF(m_workingRect.Left, m_workingRect.Top - 5, m_workingRect.Width - 2, 10));
                g.FillEllipse(new SolidBrush(Color.FromArgb(50, Color.White)), new RectangleF(m_workingRect.Left, m_workingRect.Top - 5, m_workingRect.Width - 2, 10));
                //画瓶口
                g.FillRectangle(new SolidBrush(bottleMouthColor), new Rectangle(m_workingRect.Left + m_workingRect.Width / 4, m_workingRect.Bottom, m_workingRect.Width / 2, 15));
                //画瓶颈阴影
                GraphicsPath pathPJ = new GraphicsPath();
                Point[] psPJ = new Point[] 
                {       
                    new Point(m_workingRect.Left, m_workingRect.Bottom-15),
                    new Point(m_workingRect.Right-1, m_workingRect.Bottom-15),
                    new Point(m_workingRect.Right-1-m_workingRect.Width/4, m_workingRect.Bottom),
                    new Point(m_workingRect.Left+m_workingRect.Width/4, m_workingRect.Bottom)               
                };
                pathPJ.AddLines(psPJ);
                pathPJ.CloseAllFigures();
                g.FillPath(new SolidBrush(Color.FromArgb(50, bottleMouthColor)), pathPJ);

                //写编号
                if (!string.IsNullOrEmpty(m_NO))
                {
                    var nosize = g.MeasureString(m_NO, Font);
                    g.DrawString(m_NO, Font, new SolidBrush(ForeColor), new PointF((this.Width - nosize.Width) / 2, m_workingRect.Top + 10));
                }
            }
            else
            {
                //写文字
                var size = g.MeasureString(title, Font);
                g.DrawString(title, Font, new SolidBrush(ForeColor), new PointF((this.Width - size.Width) / 2, this.Height - size.Height - 2));
                //画空瓶子
                GraphicsPath pathPS = new GraphicsPath();
                Point[] psPS = new Point[] 
                {       
                    new Point(m_workingRect.Left + m_workingRect.Width / 4, m_workingRect.Top),
                    new Point(m_workingRect.Right - 1- m_workingRect.Width / 4, m_workingRect.Top),
                    new Point(m_workingRect.Right - 1, m_workingRect.Top + 15),
                    new Point(m_workingRect.Right - 1, m_workingRect.Bottom),
                    new Point(m_workingRect.Left , m_workingRect.Bottom),
                    new Point(m_workingRect.Left, m_workingRect.Top + 15),
                };
                pathPS.AddLines(psPS);
                pathPS.CloseAllFigures();
                g.FillPath(new SolidBrush(bottleColor), pathPS);
                //画液体
                decimal decYTHeight = (m_value / maxValue) * m_workingRect.Height;
                GraphicsPath pathYT = new GraphicsPath();
                Rectangle rectYT = Rectangle.Empty;
                if (decYTHeight > m_workingRect.Height - 15)
                {
                    PointF[] psYT = new PointF[] 
                    { 
                        new PointF((float)(m_workingRect.Left+(decYTHeight-(m_workingRect.Height-15)))+3,(float)(m_workingRect.Bottom-decYTHeight)),                   
                        new PointF((float)(m_workingRect.Right-(decYTHeight-(m_workingRect.Height-15)))-3,(float)(m_workingRect.Bottom-decYTHeight)),  
                        new PointF(m_workingRect.Right-1, m_workingRect.Top+15),
                        new PointF(m_workingRect.Right-1, m_workingRect.Bottom),
                        new PointF(m_workingRect.Left, m_workingRect.Bottom),
                        new PointF(m_workingRect.Left, m_workingRect.Top+15),
                    };
                    pathYT.AddLines(psYT);
                    pathYT.CloseAllFigures();
                    rectYT = new Rectangle(m_workingRect.Left + (int)(decYTHeight - (m_workingRect.Height - 15)) +1, (int)(m_workingRect.Bottom - decYTHeight - 4), m_workingRect.Width - (int)(decYTHeight - (m_workingRect.Height - 15)) * 2-2 , 10);
                }
                else
                {
                    PointF[] psYT = new PointF[] 
                    { 
                        new PointF(m_workingRect.Left,(float)(m_workingRect.Bottom-decYTHeight)),
                        new PointF(m_workingRect.Right-1,(float)(m_workingRect.Bottom-decYTHeight)),
                        new PointF(m_workingRect.Right-1,m_workingRect.Bottom),
                        new PointF(m_workingRect.Left,m_workingRect.Bottom),
                    };
                    pathYT.AddLines(psYT);
                    pathYT.CloseAllFigures();
                    rectYT = new Rectangle(m_workingRect.Left, m_workingRect.Bottom - (int)decYTHeight - 5, m_workingRect.Width, 10);
                }

                g.FillPath(new SolidBrush(liquidColor), pathYT);
                g.FillPath(new SolidBrush(Color.FromArgb(50, bottleMouthColor)), pathYT);
                //画液体面
                g.FillEllipse(new SolidBrush(liquidColor), rectYT);
                g.FillEllipse(new SolidBrush(Color.FromArgb(50, Color.White)), rectYT);
                //画高亮
                int intCount = m_workingRect.Width / 2 / 4;
                int intSplit = (255 - 100) / intCount;
                for (int i = 0; i < intCount; i++)
                {
                    int _penWidth = m_workingRect.Width / 2 - 4 * i;
                    if (_penWidth <= 0)
                        _penWidth = 1;
                    g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(10, Color.White)), _penWidth), new Point(m_workingRect.Width / 2, m_workingRect.Top + 15), new Point(m_workingRect.Width / 2, m_workingRect.Bottom));
                    if (_penWidth == 1)
                        break;
                }
                //画瓶底
                g.FillEllipse(new SolidBrush(liquidColor), new RectangleF(m_workingRect.Left, m_workingRect.Bottom - 5, m_workingRect.Width - 2, 10));
                g.FillEllipse(new SolidBrush(Color.FromArgb(50, liquidColor)), new RectangleF(m_workingRect.Left, m_workingRect.Bottom - 5, m_workingRect.Width - 2, 10));
                //画瓶口
                g.FillRectangle(new SolidBrush(bottleMouthColor), new Rectangle(m_workingRect.Left + m_workingRect.Width / 4, m_workingRect.Top - 15 + 1, m_workingRect.Width / 2, 15));
                //画瓶颈阴影
                GraphicsPath pathPJ = new GraphicsPath();
                Point[] psPJ = new Point[] 
                {       
                    new Point(m_workingRect.Left+m_workingRect.Width/4, m_workingRect.Top),
                    new Point(m_workingRect.Right-1-m_workingRect.Width/4, m_workingRect.Top),
                    new Point(m_workingRect.Right-1, m_workingRect.Top+15),
                    new Point(m_workingRect.Left,  m_workingRect.Top+15)               
                };
                pathPJ.AddLines(psPJ);
                pathPJ.CloseAllFigures();
                g.FillPath(new SolidBrush(Color.FromArgb(50, bottleMouthColor)), pathPJ);
                //写编号
                if (!string.IsNullOrEmpty(m_NO))
                {
                    var nosize = g.MeasureString(m_NO, Font);
                    g.DrawString(m_NO, Font, new SolidBrush(ForeColor), new PointF((this.Width - nosize.Width) / 2, m_workingRect.Bottom - nosize.Height - 10));
                }
            }
        }


    }
    public enum Direction
    {
        Up,
        Down
    }
}
