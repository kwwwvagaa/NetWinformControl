using System;
using System.Collections.Generic;
using System.Text;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// 建立圆角路径的样式。
    /// </summary>
    public enum RoundStyle
    {
        /// <summary>
        /// 四个角都不是圆角。
        /// </summary>
        None = 0,
        /// <summary>
        /// 四个角都为圆角。
        /// </summary>
        All = 1,
        /// <summary>
        /// 左边两个角为圆角。
        /// </summary>
        Left = 2,
        /// <summary>
        /// 右边两个角为圆角。
        /// </summary>
        Right = 3,
        /// <summary>
        /// 上边两个角为圆角。
        /// </summary>
        Top = 4,
        /// <summary>
        /// 下边两个角为圆角。
        /// </summary>
        Bottom = 5,
        /// <summary>
        /// 左下角为圆角。
        /// </summary>
        BottomLeft = 6,
        /// <summary>
        /// 右下角为圆角。
        /// </summary>
        BottomRight = 7,
    }
}
