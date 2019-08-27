using HZH_Controls.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HZH_Controls.Theme
{
    /// <summary>
    /// @北京-没想好
    /// 主题类-蓝色
    /// </summary>
    public class Blue : Default
    {
        public override void ControlTheme(object control)
        {
            base.ControlTheme(control);
            //按控件设置主题
            //如果是按钮
            if (control.GetType().Name.ToString() == "UCBtnExt") {
                UCBtnExt c = (UCBtnExt)control;
                c.FillColor = System.Drawing.Color.Blue;
            }
            //如果是按钮
            if (control.GetType().Name.ToString() == "UCBtnFillet") {
                UCBtnFillet c = (UCBtnFillet)control;
                c.FillColor = System.Drawing.Color.Blue;
                c.ForeColor = System.Drawing.Color.White;
            }
            //如果是XXX
        }
    }
}
