// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="ChartPoint.cs">
//     Copyright by Huang Zhenghui(»ÆÕý»Ô) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub£ºhttps://github.com/kwwwvagaa/NetWinformControl
// gitee£ºhttps://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class ChartPoint.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ChartPoint
    {
        /// <summary>
        /// The chart
        /// </summary>
        private UCChart _chart;

        /// <summary>
        /// The series
        /// </summary>
        private SeriesBase _series;

        /// <summary>
        /// The x
        /// </summary>
        private double _x;

        /// <summary>
        /// The y
        /// </summary>
        private double _y;

        /// <summary>
        /// The label
        /// </summary>
        private string _label;

        /// <summary>
        /// Gets the chart.
        /// </summary>
        /// <value>The chart.</value>
        [Browsable(false)]
        public UCChart Chart
        {
            get
            {
                return _chart;
            }
            internal set
            {
                _chart = value;
            }
        }

        /// <summary>
        /// Gets the series.
        /// </summary>
        /// <value>The series.</value>
        [Browsable(false)]
        public SeriesBase Series
        {
            get
            {
                return _series;
            }
            internal set
            {
                _series = value;
            }
        }

        /// <summary>
        /// Gets the parent axis x.
        /// </summary>
        /// <value>The parent axis x.</value>
        [Browsable(false)]
        public Axis ParentAxisX
        {
            get
            {
                if (_series != null)
                {
                    return _series.ParentAxisX;
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the parent axis y.
        /// </summary>
        /// <value>The parent axis y.</value>
        [Browsable(false)]
        public Axis ParentAxisY
        {
            get
            {
                if (_series != null)
                {
                    return _series.ParentAxisY;
                }
                return null;
            }
        }

        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>The x.</value>
        public double X
        {
            get
            {
                return _x;
            }
            set
			{
				if (_x != value)
				{
					_x = value;
                    if(_chart!=null)
					_chart.Invalidate();
					OnValueChanged(new EventArgs());
				}
			}
        }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>The y.</value>
        public double Y
        {
            get
            {
                return _y;
            }
            set
			{
				if (_y != value)
				{
					_y = value;
                    if(_chart!=null)
					_chart.Invalidate();
					OnValueChanged(new EventArgs());
				}
			}
        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        public string Label
        {
            get
            {
                return _label;
            }
            set
			{
				if (_label != value)
				{
					_label = value;
                    if(_chart!=null)
					_chart.Invalidate();
					OnLabelChanged(new EventArgs());
				}
			}
        }

        /// <summary>
        /// Gets the left.
        /// </summary>
        /// <value>The left.</value>
        [Browsable(false)]
        public int Left
        {
            get
            {
                int num = (_chart != null) ? _chart.OffsetX : 0;
                return (int)(Series.CountLeft(X) + (float)num);
            }
        }

        /// <summary>
        /// Gets the top.
        /// </summary>
        /// <value>The top.</value>
        [Browsable(false)]
        public int Top
        {
            get
            {
                int num = (_chart != null) ? _chart.OffsetY : 0;
                return (int)(Series.CountTop(Y) + (float)num);
            }
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>The location.</value>
        [Browsable(false)]
        public Point Location { get { return new Point(Left, Top); } }

        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// Occurs when [label changed].
        /// </summary>
        public event EventHandler LabelChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartPoint"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public ChartPoint(double x, double y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartPoint"/> class.
        /// </summary>
        public ChartPoint()
            : this(0.0, 0.0)
        {
        }

        /// <summary>
        /// Handles the <see cref="E:ValueChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void OnValueChanged(EventArgs e)
		{
            if(this.ValueChanged!=null)
			this.ValueChanged.Invoke(this, e);
		}

        /// <summary>
        /// Handles the <see cref="E:LabelChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void OnLabelChanged(EventArgs e)
		{
            if(this.LabelChanged!=null)
			this.LabelChanged.Invoke(this, e);
		}

        /// <summary>
        /// Gets the label from axis x.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetLabelFromAxisX()
        {
            if (ParentAxisX != null)
            {
                return ParentAxisX.GetLabel(_x);
            }
            return null;
        }

        /// <summary>
        /// Gets the label from axis y.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetLabelFromAxisY()
        {
            if (ParentAxisY != null)
            {
                return ParentAxisY.GetLabel(_y);
            }
            return null;
        }
    }
}
