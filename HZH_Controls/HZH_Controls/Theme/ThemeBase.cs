using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Controls;

namespace HZH_Controls.Theme
{
    public abstract class ThemeBase : IControlTheme
    {
        public virtual bool ControlTheme(Control control)
        {
            #region 按钮    English:Button
            if (control is UCBtnExt)
            {
                return Theme_UCBtnExt(control as UCBtnExt);
            }
            else if (control is UCBtnFillet)
            {
                return Theme_UCBtnFillet(control as UCBtnFillet);
            }
            else if (control is UCBtnImg)
            {
                return Theme_UCBtnImg(control as UCBtnImg);
            }
            else if (control is UCDropDownBtn)
            {
                return Theme_UCDropDownBtn(control as UCDropDownBtn);
            }
            else if (control is UCBtnsGroup)
            {
                return Theme_UCBtnsGroup(control as UCBtnsGroup);
            }
            #endregion
            #region Checkbox    English:Checkbox
            else if (control is UCCheckBox)
            {
                return Theme_UCCheckBox(control as UCCheckBox);
            }
            #endregion
            #region UCComboBox    English:UCComboBox
            else if (control is UCComboBox)
            {
                return Theme_UCComboBox(control as UCComboBox);
            }
            #endregion
            #region Datagridview    English:Datagridview
            else if (control is UCDataGridView)
            {
                return Theme_UCDataGridView(control as UCDataGridView);
            }
            else if (control is UCDataGridViewRow)
            {
                return Theme_UCDataGridViewRow(control as UCDataGridViewRow);
            }
            else if (control is UCDataGridViewTreeRow)
            {
                return Theme_UCDataGridViewTreeRow(control as UCDataGridViewTreeRow);
            }
            #endregion
            #region UCDatePickerExt    English:UCDatePickerExt
            else if (control is UCDatePickerExt)
            {
                return Theme_UCDatePickerExt(control as UCDatePickerExt);
            }
            #endregion
            #region KeyBorder    English:KeyBorder
            else if (control is UCKeyBorderAll)
            {
                return Theme_UCKeyBorderAll(control as UCKeyBorderAll);
            }
            else if (control is UCKeyBorderNum)
            {
                return Theme_UCKeyBorderNum(control as UCKeyBorderNum);
            }
            else if (control is UCKeyBorderPay)
            {
                return Theme_UCKeyBorderPay(control as UCKeyBorderPay);
            }
            #endregion
            #region List    English:List
            else if (control is TreeViewEx)
            {
                return Theme_TreeViewEx(control as TreeViewEx);
            }
            else if (control is UCHorizontalList)
            {
                return Theme_UCHorizontalList(control as UCHorizontalList);
            }
            else if (control is UCListExt)
            {
                return Theme_UCListExt(control as UCListExt);
            }
            else if (control is UCListItemExt)
            {
                return Theme_UCListItemExt(control as UCListItemExt);
            }
            else if (control is UCListView)
            {
                return Theme_UCListView(control as UCListView);
            }
            else if (control is UCListViewItem)
            {
                return Theme_UCListViewItem(control as UCListViewItem);
            }
            else if (control is UCPagerControlBase)
            {
                return Theme_UCPagerControl(control as UCPagerControlBase);
            }
            #endregion
            #region Menu    English:Menu
            else if (control is UCMenu)
            {
                return Theme_UCMenu(control as UCMenu);
            }
            else if (control is UCMenuChildrenItem)
            {
                return Theme_UCMenuChildrenItem(control as UCMenuChildrenItem);
            }
            else if (control is UCMenuParentItem)
            {
                return Theme_UCMenuParentItem(control as UCMenuParentItem);
            }
            #endregion
            #region UCCrumbNavigation    English:UCCrumbNavigation
            else if (control is UCCrumbNavigation)
            {
                return Theme_UCCrumbNavigation(control as UCCrumbNavigation);
            }
            #endregion
            #region UCPanelTitle    English:UCPanelTitle
            else if (control is UCPanelTitle)
            {
                return Theme_UCPanelTitle(control as UCPanelTitle);
            }
            #endregion
            #region Process    English:Process
            else if (control is UCProcessEllipse)
            {
                return Theme_UCProcessEllipse(control as UCProcessEllipse);
            }
            else if (control is UCProcessExt)
            {
                return Theme_UCProcessExt(control as UCProcessExt);
            }
            else if (control is UCProcessLine)
            {
                return Theme_UCProcessLine(control as UCProcessLine);
            }
            else if (control is UCProcessLineExt)
            {
                return Theme_UCProcessLineExt(control as UCProcessLineExt);
            }
            else if (control is UCProcessWave)
            {
                return Theme_UCProcessWave(control as UCProcessWave);
            }
            #endregion
            #region UCRadioButton    English:UCRadioButton
            else if (control is UCRadioButton)
            {
                return Theme_UCRadioButton(control as UCRadioButton);
            }
            #endregion
            #region SplitLine    English:SplitLine
            else if (control is UCSplitLine_H)
            {
                return Theme_UCSplitLine_H(control as UCSplitLine_H);
            }
            else if (control is UCSplitLine_V)
            {
                return Theme_UCSplitLine_V(control as UCSplitLine_V);
            }
            #endregion
            #region UCStep    English:UCStep
            else if (control is UCStep)
            {
                return Theme_UCStep(control as UCStep);
            }
            #endregion
            #region UCSwitch    English:UCSwitch
            else if (control is UCSwitch)
            {
                return Theme_UCSwitch(control as UCSwitch);
            }
            #endregion
            #region TabControlExt    English:TabControlExt
            else if (control is TabControlExt)
            {
                return Theme_TabControlExt(control as TabControlExt);
            }
            #endregion
            #region Textbox    English:Textbox
            else if (control is TextBoxEx)
            {
                return Theme_TextBoxEx(control as TextBoxEx);
            }
            else if (control is TextBoxTransparent)
            {
                return Theme_TextBoxTransparent(control as TextBoxTransparent);
            }
            else if (control is UCNumTextBox)
            {
                return Theme_UCNumTextBox(control as UCNumTextBox);
            }
            else if (control is UCTextBoxEx)
            {
                return Theme_UCTextBoxEx(control as UCTextBoxEx);
            }
            #endregion
            #region Wave    English:Wave
            else if (control is UCWave)
            {
                return Theme_UCWave(control as UCWave);
            }
            else if (control is UCWaveChart)
            {
                return Theme_UCWaveChart(control as UCWaveChart);
            }
            #endregion
            else
            {
                return CustomControlTheme(control);
            }
        }

        #region 具体控件主题    English:Specific Control Theme
        #region 按钮    English:Button
        protected abstract bool Theme_UCBtnExt(UCBtnExt c);

        protected abstract bool Theme_UCBtnFillet(UCBtnFillet c);
        protected abstract bool Theme_UCBtnImg(UCBtnImg c);
        protected abstract bool Theme_UCDropDownBtn(UCDropDownBtn c);

        protected abstract bool Theme_UCBtnsGroup(UCBtnsGroup c);
        #endregion
        #region Checkbox    English:Checkbox
        /// <summary>
        /// 功能描述:Checkbox    English:Checkbox
        /// 作　　者:HZH
        /// 创建日期:2019-08-28 09:06:38
        /// 任务编号:POS
        /// </summary>
        /// <param name="c">c</param>
        protected abstract bool Theme_UCCheckBox(UCCheckBox c);
        #endregion
        #region UCComboBox    English:UCComboBox
        /// <summary>
        /// 功能描述:UCComboBox    English:UCComboBox
        /// 作　　者:HZH
        /// 创建日期:2019-08-28 09:07:31
        /// 任务编号:POS
        /// </summary>
        /// <param name="c">c</param>
        protected abstract bool Theme_UCComboBox(UCComboBox c);
        #endregion
        #region Datagridview    English:Datagridview
        protected abstract bool Theme_UCDataGridView(UCDataGridView c);
        protected abstract bool Theme_UCDataGridViewRow(UCDataGridViewRow c);
        protected abstract bool Theme_UCDataGridViewTreeRow(UCDataGridViewTreeRow c);
        #endregion
        #region UCDatePickerExt    English:UCDatePickerExt
        protected abstract bool Theme_UCDatePickerExt(UCDatePickerExt c);
        #endregion
        #region UCKeyBorderAll    English:UCKeyBorderAll
        protected abstract bool Theme_UCKeyBorderAll(UCKeyBorderAll c);
        protected abstract bool Theme_UCKeyBorderNum(UCKeyBorderNum c);
        protected abstract bool Theme_UCKeyBorderPay(UCKeyBorderPay c);
        #endregion
        #region List    English:List
        protected abstract bool Theme_TreeViewEx(TreeViewEx c);
        protected abstract bool Theme_UCHorizontalList(UCHorizontalList c);
        protected abstract bool Theme_UCListExt(UCListExt c);
        protected abstract bool Theme_UCListItemExt(UCListItemExt c);

        protected abstract bool Theme_UCListView(UCListView c);
        protected abstract bool Theme_UCListViewItem(UCListViewItem c);

        protected abstract bool Theme_UCPagerControl(UCPagerControlBase c);
        #endregion
        #region Menu    English:Menu
        protected abstract bool Theme_UCMenu(UCMenu c);
        protected abstract bool Theme_UCMenuChildrenItem(UCMenuChildrenItem c);
        protected abstract bool Theme_UCMenuParentItem(UCMenuParentItem c);
        #endregion
        #region UCCrumbNavigation    English:UCCrumbNavigation
        protected abstract bool Theme_UCCrumbNavigation(UCCrumbNavigation c);
        #endregion
        #region UCPanelTitle    English:UCPanelTitle
        protected abstract bool Theme_UCPanelTitle(UCPanelTitle c);
        #endregion
        #region Process    English:Process
        protected abstract bool Theme_UCProcessEllipse(UCProcessEllipse c);
        protected abstract bool Theme_UCProcessExt(UCProcessExt c);
        protected abstract bool Theme_UCProcessLine(UCProcessLine c);
        protected abstract bool Theme_UCProcessLineExt(UCProcessLineExt c);
        protected abstract bool Theme_UCProcessWave(UCProcessWave c);
        #endregion
        #region UCRadioButton    English:UCRadioButton
        protected abstract bool Theme_UCRadioButton(UCRadioButton c);
        #endregion
        #region SplitLine    English:SplitLine
        protected abstract bool Theme_UCSplitLine_H(UCSplitLine_H c);
        protected abstract bool Theme_UCSplitLine_V(UCSplitLine_V c);
        #endregion
        #region UCStep    English:UCStep
        protected abstract bool Theme_UCStep(UCStep c);
        #endregion
        #region UCSwitch    English:UCSwitch
        protected abstract bool Theme_UCSwitch(UCSwitch c);
        #endregion
        #region TabControlExt    English:TabControlExt
        protected abstract bool Theme_TabControlExt(TabControlExt c);
        #endregion
        #region Textbox    English:Textbox
        protected abstract bool Theme_TextBoxEx(TextBoxEx c);
        protected abstract bool Theme_TextBoxTransparent(TextBoxTransparent c);
        protected abstract bool Theme_UCNumTextBox(UCNumTextBox c);
        protected abstract bool Theme_UCTextBoxEx(UCTextBoxEx c);
        #endregion
        #region Wave    English:Wave
        protected abstract bool Theme_UCWave(UCWave c);
        protected abstract bool Theme_UCWaveChart(UCWaveChart c);
        #endregion
        #endregion

        #region 自定义控件主题，如果需要对自定义的控件进行处理，请添加对应的主题类，使用partial关键字，然后重写此函数即可    English:Custom control theme. If you need to process the custom control, add the corresponding topic class, use the partial keyword, and then rewrite the function.
        /// <summary>
        /// 功能描述:自定义控件主题，如果需要对自定义的控件进行处理，请添加对应的主题类，使用partial关键字，然后重写此函数即可    English:Custom control theme. If you need to process the custom control, add the corresponding topic class, use the partial keyword, and then rewrite the function.
        /// 作　　者:HZH
        /// 创建日期:2019-08-28 09:58:04
        /// 任务编号:
        /// </summary>
        /// <param name="control">control</param>
        protected virtual bool CustomControlTheme(Control control)
        {
            return true;
        }
        #endregion

        #region 获取控件真实的背景色，当为透明色时取父控件颜色    English:Gets the true background color of the control and the parent color when it is transparent
        /// <summary>
        /// 功能描述:获取控件真实的背景色，当为透明色时取父控件颜色    English:Gets the true background color of the control and the parent color when it is transparent
        /// 作　　者:HZH
        /// 创建日期:2019-08-28 11:15:22
        /// 任务编号:
        /// </summary>
        /// <param name="control">control</param>
        /// <returns>返回值</returns>
        protected Color GetBackColor(Control control)
        {
            if (control.BackColor == Color.Transparent && control.Parent != null)
            {
                return GetBackColor(control.Parent);
            }
            else
            {
                return control.BackColor;
            }
        }
        #endregion
    }
}
