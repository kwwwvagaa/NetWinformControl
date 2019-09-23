using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class ScrollbarControlDesigner.
    /// Implements the <see cref="System.Windows.Forms.Design.ControlDesigner" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    internal class ScrollbarControlDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// 获取指示组件的移动功能的选择规则。
        /// </summary>
        /// <value>The selection rules.</value>
        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules selectionRules = base.SelectionRules;
                PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(this.Component)["AutoSize"];
                if (propDescriptor != null)
                {
                    bool autoSize = (bool)propDescriptor.GetValue(this.Component);
                    if (autoSize)
                    {
                        selectionRules = SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.BottomSizeable | SelectionRules.TopSizeable;
                    }
                    else
                    {
                        selectionRules = SelectionRules.Visible | SelectionRules.AllSizeable | SelectionRules.Moveable;
                    }
                }
                return selectionRules;
            }
        }
    }
}
