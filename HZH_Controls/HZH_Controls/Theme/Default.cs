using HZH_Controls.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HZH_Controls.Theme
{
    /// <summary>
    /// @北京-没想好
    /// 默认主题
    /// </summary>
    public class Default : IControlTheme
    {
        public virtual void ControlTheme(object control)
        {
            if (control.GetType().Name.ToString() == "UCBtnExt")
            {
                UCBtnExt c = (UCBtnExt)control;
                c.FillColor = System.Drawing.Color.Red;
                c.BtnForeColor = System.Drawing.Color.White;
            }
        }
    }
}
