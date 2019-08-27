using HZH_Controls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
/*
 * 后续
 * 1.用户自定义样式类实现，可以继承已有主题或者实现主题接口IControlTheme，怎让用户自定义类神效
 * 2.控件单独样式和主题的冲突
 */
/// <summary>
/// 全局主题样式
/// 分为两步分：
/// 1.循环所有页面已经存在的控件实现样式修改（实现方法:ThemeRefresh()）
/// 2.新拖动的控件继承已经选择的主题样式（实现方法:UCControlBase.UCControlBase_Load()）
/// @北京-没想好
/// </summary>
namespace HZH_Controls.Theme
{
    /// <summary>
    /// 样式组件
    /// </summary>
    [ToolboxBitmap(typeof(UCTheme),"Resources.UCTheme.bmp")]
    public class UCTheme: Component
    {
        /// <summary>
        /// 属性枚举
        /// </summary>
        public enum ThemeTypes
        {
            Default,
            Blue
        }
        /// <summary>
        /// 样式
        /// </summary>
        private ThemeTypes _ThemeType = ThemeTypes.Default;
        /// <summary>
        /// 主题样式
        /// </summary>
        [Description("主题"), Category("自定义")]
        public virtual ThemeTypes ThemeType
        {
            get
            {
                return this._ThemeType;
            }
            set
            {
                this._ThemeType = value;
                ThemeRefresh();
            }
        }

        /// <summary>
        /// 刷新样式
        /// </summary>
        private void ThemeRefresh()
        {
            //循环所有页面已经存在的控件
            foreach (var item in this.Container.Components)
            {
                try
                {
                    System.Windows.Forms.Control con = (System.Windows.Forms.Control)item;
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Object obj = assembly.CreateInstance(con.GetType().FullName);
                    //判断控件基类是否来自UCControlBase
                    if (typeof(UCControlBase).IsAssignableFrom(obj.GetType()))
                    {
                        //根据对应的主题找到实现类
                        IControlTheme uct = (IControlTheme)assembly.CreateInstance("HZH_Controls.Theme." + this._ThemeType);
                        uct.ControlTheme(con);
                    }
                }
                catch { }
            }
        }
    }
}
