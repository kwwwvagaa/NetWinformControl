// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：IDataGridViewRow.cs
// 创建日期：2019-08-15 15:59:21
// 功能描述：DataGridView
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    public interface IDataGridViewRow
    {
        /// <summary>
        /// CheckBox选中事件
        /// </summary>
        event DataGridViewEventHandler CheckBoxChangeEvent;
        /// <summary>
        /// 点击单元格事件
        /// </summary>
        event DataGridViewEventHandler CellClick;
        /// <summary>
        /// 数据源改变事件
        /// </summary>
        event DataGridViewEventHandler SourceChanged;
        /// <summary>
        /// 列参数，用于创建列数和宽度
        /// </summary>
        List<DataGridViewColumnEntity> Columns { get; set; }
        bool IsShowCheckBox { get; set; }
        /// <summary>
        /// 是否选中
        /// </summary>
        bool IsChecked { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        object DataSource { get; set; }
        /// <summary>
        /// 添加单元格元素，仅做添加控件操作，不做数据绑定，数据绑定使用BindingCells
        /// </summary>
        void ReloadCells();
        /// <summary>
        /// 绑定数据到Cell
        /// </summary>
        /// <param name="intIndex">cell下标</param>
        /// <returns>返回true则表示已处理过，否则将进行默认绑定（通常只针对有Text值的控件）</returns>
        void BindingCellData();
        /// <summary>
        /// 设置选中状态，通常为设置颜色即可
        /// </summary>
        /// <param name="blnSelected">是否选中</param>
        void SetSelect(bool blnSelected);
        /// <summary>
        /// 行高
        /// </summary>
        int RowHeight { get; set; }
    }
}
