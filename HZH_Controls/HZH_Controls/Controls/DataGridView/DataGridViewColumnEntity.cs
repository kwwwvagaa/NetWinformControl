// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：DataGridViewColumnEntity.cs
// 创建日期：2019-08-15 15:59:17
// 功能描述：DataGridView
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace HZH_Controls.Controls
{
    public class DataGridViewColumnEntity
    {
        public string HeadText { get; set; }
        public int Width { get; set; }
        public System.Windows.Forms.SizeType WidthType { get; set; }
        public string DataField { get; set; }
        public Func<object, string> Format { get; set; }
        private ContentAlignment _TextAlign = ContentAlignment.MiddleCenter;
        public ContentAlignment TextAlign { get { return _TextAlign; } set { _TextAlign = value; } }
    }
}
