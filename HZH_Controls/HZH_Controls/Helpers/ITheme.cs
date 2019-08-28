using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace HZH_Controls
{
    public interface ITheme
    {
        /// <summary>
        /// 重置主题
        /// </summary>
        /// <param name="theme"></param>
        void ResetTheme(ThemeEntity theme);
        /// <summary>
        /// 是否禁用一键换肤，默认禁用
        /// </summary>
        bool EnabledTheme { get; set; }
    }

    public class ThemeEntity
    {
        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color? BorderColor { get; set; }
        /// <summary>
        /// 填充颜色
        /// </summary>
        public Color? FillColor { get; set; }
        /// <summary>
        /// 背景色
        /// </summary>
        public Color? BackColor { get; set; }
        /// <summary>
        /// 前景色
        /// </summary>
        public Color? ForeColor { get; set; }
        /// <summary>
        /// 字体颜色
        /// </summary>
        public Color? FontColor { get; set; }
        /// <summary>
        /// 选中颜色
        /// </summary>
        public Color? SelectedColor { get; set; }
        /// <summary>
        /// 选中字体颜色
        /// </summary>
        public Color? SelectedFontColor { get; set; }
    }
}
