// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-23
//
// ***********************************************************************
// <copyright file="MarkText.cs">
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
    /// Class MarkText.
    /// </summary>
    public class MarkText
    {
        /// <summary>
        /// The mark text offect
        /// </summary>
        public static readonly int MarkTextOffect = 5;

        /// <summary>
        /// Gets or sets the curve key.
        /// </summary>
        /// <value>The curve key.</value>
        public string CurveKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>The index.</value>
        public int Index
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the mark text.
        /// </summary>
        /// <value>The mark text.</value>
        public string Text
        {
            get;
            set;
        }

        private Color? textColor = null;

        public Color? TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }


        /// <summary>
        /// The position style
        /// </summary>
        private MarkTextPositionStyle positionStyle = MarkTextPositionStyle.Auto;

        /// <summary>
        /// Gets or sets the position style.
        /// </summary>
        /// <value>The position style.</value>
        public MarkTextPositionStyle PositionStyle
        {
            get { return positionStyle; }
            set { positionStyle = value; }
        }

        /// <summary>
        /// Calculates the index of the direction from data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="Index">The index.</param>
        /// <returns>MarkTextPositionStyle.</returns>
        public static MarkTextPositionStyle CalculateDirectionFromDataIndex(float[] data, int Index)
        {
            float num = (Index == 0) ? data[Index] : data[Index - 1];
            float num2 = (Index == data.Length - 1) ? data[Index] : data[Index + 1];
            if (num < data[Index] && data[Index] < num2)
            {
                return MarkTextPositionStyle.Left;
            }
            if (num > data[Index] && data[Index] > num2)
            {
                return MarkTextPositionStyle.Right;
            }
            if (num <= data[Index] && data[Index] >= num2)
            {
                return MarkTextPositionStyle.Up;
            }
            if (num >= data[Index] && data[Index] <= num2)
            {
                return MarkTextPositionStyle.Down;
            }
            return MarkTextPositionStyle.Up;
        }
    }
}
