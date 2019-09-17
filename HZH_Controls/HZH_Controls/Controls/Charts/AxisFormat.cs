// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="AxisFormat.cs">
//     Copyright by Huang Zhenghui(»ÆÕý»Ô) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub£ºhttps://github.com/kwwwvagaa/NetWinformControl
// gitee£ºhttps://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System.Drawing;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class AxisFormat.
    /// </summary>
    public class AxisFormat
    {
        /// <summary>
        /// The title angle axis y
        /// </summary>
        public const int TitleAngleAxisY = -90;
        /// <summary>
        /// The title format right axis y
        /// </summary>
        static StringFormat titleFormatRightAxisY = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Far
        };
        /// <summary>
        /// Gets or sets the title format right axis y.
        /// </summary>
        /// <value>The title format right axis y.</value>
        public static StringFormat TitleFormatRightAxisY
        {
            get { return titleFormatRightAxisY; }
            set { titleFormatRightAxisY = value; }
        }

        /// <summary>
        /// The title format left axis y
        /// </summary>
        static StringFormat titleFormatLeftAxisY = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Near
        };
        /// <summary>
        /// Gets or sets the title format left axis y.
        /// </summary>
        /// <value>The title format left axis y.</value>
        public static StringFormat TitleFormatLeftAxisY
        {
            get { return titleFormatLeftAxisY; }
            set { titleFormatLeftAxisY = value; }
        }

        /// <summary>
        /// The label format left axis y
        /// </summary>
        static StringFormat labelFormatLeftAxisY = new StringFormat
        {
            Alignment = StringAlignment.Far,
            LineAlignment = StringAlignment.Center
        };
        /// <summary>
        /// Gets or sets the label format left axis y.
        /// </summary>
        /// <value>The label format left axis y.</value>
        public static StringFormat LabelFormatLeftAxisY
        {
            get { return labelFormatLeftAxisY; }
            set { labelFormatLeftAxisY = value; }
        }
        /// <summary>
        /// The label format right axis y
        /// </summary>
        static StringFormat labelFormatRightAxisY = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center
        };

        /// <summary>
        /// Gets or sets the label format right axis y.
        /// </summary>
        /// <value>The label format right axis y.</value>
        public static StringFormat LabelFormatRightAxisY
        {
            get { return AxisFormat.labelFormatRightAxisY; }
            set { AxisFormat.labelFormatRightAxisY = value; }
        }


        /// <summary>
        /// The title format top axis x
        /// </summary>
        static StringFormat titleFormatTopAxisX = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Near
        };

        /// <summary>
        /// Gets or sets the title format top axis x.
        /// </summary>
        /// <value>The title format top axis x.</value>
        public static StringFormat TitleFormatTopAxisX
        {
            get { return AxisFormat.titleFormatTopAxisX; }
            set { AxisFormat.titleFormatTopAxisX = value; }
        }


        /// <summary>
        /// The title format bottom axis x
        /// </summary>
        static StringFormat titleFormatBottomAxisX = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Far
        };

        /// <summary>
        /// Gets or sets the title format bottom axis x.
        /// </summary>
        /// <value>The title format bottom axis x.</value>
        public static StringFormat TitleFormatBottomAxisX
        {
            get { return AxisFormat.titleFormatBottomAxisX; }
            set { AxisFormat.titleFormatBottomAxisX = value; }
        }

        /// <summary>
        /// The label format top axis x
        /// </summary>
        static StringFormat labelFormatTopAxisX = new StringFormat
       {
           Alignment = StringAlignment.Center,
           LineAlignment = StringAlignment.Far
       };

        /// <summary>
        /// Gets or sets the label format top axis x.
        /// </summary>
        /// <value>The label format top axis x.</value>
        public static StringFormat LabelFormatTopAxisX
        {
            get { return AxisFormat.labelFormatTopAxisX; }
            set { AxisFormat.labelFormatTopAxisX = value; }
        }

        /// <summary>
        /// The label format bottom axis x
        /// </summary>
        static StringFormat labelFormatBottomAxisX = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Near
        };

        /// <summary>
        /// Gets or sets the label format bottom axis x.
        /// </summary>
        /// <value>The label format bottom axis x.</value>
        public static StringFormat LabelFormatBottomAxisX
        {
            get { return AxisFormat.labelFormatBottomAxisX; }
            set { AxisFormat.labelFormatBottomAxisX = value; }
        }


    }
}
