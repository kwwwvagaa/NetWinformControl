// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：FrmInputs.cs
// 创建日期：2019-08-15 16:04:41
// 功能描述：FrmInputs
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Forms
{
    public partial class FrmInputs : FrmWithOKCancel1
    {
        public string[] Values { get; private set; }
        private Dictionary<int, string> m_mastInputs = new Dictionary<int, string>();
        #region 构造函数
        /// <summary>
        /// 功能描述:构造函数
        /// 作　　者:HZH
        /// 创建日期:2019-08-05 10:57:26
        /// 任务编号:POS
        /// </summary>
        /// <param name="strTitle">窗体标题</param>
        /// <param name="args">输入项名称</param>
        /// <param name="inTypes">输入项对应输入类型，key:输入项名称，如不设置默认不控制输入</param>
        /// <param name="regexs">输入项对应正则规则，当imTypes=Regex时有效，key:输入项名称，如不设置默认不控制输入</param>
        /// <param name="keyBoards">文本框键盘，key:输入项名称，如不设置默认英文键盘</param>
        /// <param name="mastInputs">必填输入项名称</param>
        /// <param name="defaultValues">输入项默认值，key:输入项名称</param>
        public FrmInputs(
            string strTitle,
            string[] inPutLabels,
            Dictionary<string, TextInputType> inTypes = null,
            Dictionary<string, string> regexs = null,
            Dictionary<string, HZH_Controls.Controls.KeyBoardType> keyBoards = null,
            List<string> mastInputs = null,
            Dictionary<string, string> defaultValues = null)
        {
            InitializeComponent();
            this.Title = strTitle;
            if (inPutLabels.Length <= 0)
            {
                throw new Exception("输入数量不能为空");
            }
            try
            {
                Values = new string[inPutLabels.Length];
                HZH_Controls.ControlHelper.FreezeControl(this, true);

                for (int i = inPutLabels.Length - 1; i >= 0; i--)
                {
                    Panel p = new Panel();
                    p.Dock = DockStyle.Top;
                    p.Height = 62;
                    p.Padding = new Padding(10);

                    HZH_Controls.Controls.UCTextBoxEx txt = new Controls.UCTextBoxEx();
                    txt.Dock = DockStyle.Fill;
                    txt.IsShowKeyboard = true;
                    txt.IsShowClearBtn = true;
                    txt.Name = "txt_" + i;
                    txt.TabIndex = i;
                    if (inTypes != null && inTypes.ContainsKey(inPutLabels[i]))
                    {
                        txt.InputType = inTypes[inPutLabels[i]];
                        if (txt.InputType == TextInputType.Regex && regexs != null && regexs.ContainsKey(inPutLabels[i]))
                            txt.RegexPattern = regexs[inPutLabels[i]];
                    }
                    if (keyBoards != null && keyBoards.ContainsKey(inPutLabels[i]))
                        txt.KeyBoardType = keyBoards[inPutLabels[i]];
                    if (mastInputs != null && mastInputs.Contains(inPutLabels[i]))
                    {
                        m_mastInputs[i] = inPutLabels[i];
                    }
                    if (defaultValues != null && defaultValues.ContainsKey(inPutLabels[i]))
                        txt.InputText = defaultValues[inPutLabels[i]];
                    p.Controls.Add(txt);

                    Label lbl = new Label();
                    lbl.Text = inPutLabels[i];
                    lbl.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
                    lbl.TextAlign = ContentAlignment.MiddleRight;
                    lbl.AutoSize = false;
                    lbl.Width = 120;
                    lbl.Dock = DockStyle.Left;
                    lbl.Font = new System.Drawing.Font("微软雅黑", 12);
                    p.Controls.Add(lbl);

                    Label lblT = new Label();
                    if (mastInputs != null && mastInputs.Contains(inPutLabels[i]))
                    {
                        lblT.Text = "*";
                    }
                    else
                    {
                        lblT.Text = "";
                    }
                    lblT.AutoSize = false;
                    lblT.TextAlign = ContentAlignment.MiddleLeft;
                    lblT.Width = 25;
                    lblT.Dock = DockStyle.Right;
                    lblT.Font = new System.Drawing.Font("微软雅黑", 12);
                    lblT.ForeColor = Color.Red;
                    p.Controls.Add(lblT);
                    this.panel3.Controls.Add(p);
                    this.ActiveControl = txt;
                }

                this.Height = 124 + inPutLabels.Length * 62;
            }
            finally
            {
                HZH_Controls.ControlHelper.FreezeControl(this, false);
            }
        }
        #endregion

        protected override void DoEnter()
        {
            for (int i = 0; i < Values.Length; i++)
            {
                var cs = this.panel3.Controls.Find("txt_" + i, true);
                if (cs.Length > 0)
                {
                    var txt = cs[0] as HZH_Controls.Controls.UCTextBoxEx;
                    Values[i] = txt.InputText;
                    if (m_mastInputs.ContainsKey(i) && string.IsNullOrWhiteSpace(txt.InputText))
                    {
                        HZH_Controls.Forms.FrmTips.ShowTipsInfo(this, "[" + m_mastInputs[i] + "]必须输入。");
                        return;
                    }
                }
            }
            base.DoEnter();
        }
    }
}
