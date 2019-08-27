using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HZH_Controls.Theme
{
    /// <summary>
    /// @北京-没想好
    /// 所有主题实现此样式
    /// </summary>
    public interface IControlTheme
    {
        /// <summary>
        /// 根据主题配置当前控件样式
        /// </summary>
        /// <param name="control"></param>
        void ControlTheme(object control);
    }
}
