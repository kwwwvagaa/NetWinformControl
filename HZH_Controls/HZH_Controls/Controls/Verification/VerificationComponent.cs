using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    [ProvideProperty("VerificationModel", typeof(Control))]
    [ProvideProperty("VerificationCustomRegex", typeof(Control))]
    [ProvideProperty("VerificationRequired", typeof(Control))]
    [ProvideProperty("VerificationErrorMsg", typeof(Control))]
    [DefaultEvent("Verificationed")]
    public class VerificationComponent : Component, IExtenderProvider
    {
        public delegate void VerificationedHandle(VerificationEventArgs e);
        [Browsable(true), Category("自定义属性"), Description("验证事件"), Localizable(true)]
        public event VerificationedHandle Verificationed;

        Dictionary<Control, VerificationModel> m_controlCache = new Dictionary<Control, VerificationModel>();
        Dictionary<Control, string> m_controlRegexCache = new Dictionary<Control, string>();
        Dictionary<Control, bool> m_controlRequiredCache = new Dictionary<Control, bool>();
        Dictionary<Control, string> m_controlMsgCache = new Dictionary<Control, string>();
        Dictionary<Control, Forms.FrmAnchorTips> m_controlTips = new Dictionary<Control, Forms.FrmAnchorTips>();

        private Color errorTipsBackColor = Color.FromArgb(255, 77, 58);

        [Browsable(true), Category("自定义属性"), Description("错误提示背景色"), Localizable(true)]
        public Color ErrorTipsBackColor
        {
            get { return errorTipsBackColor; }
            set { errorTipsBackColor = value; }
        }

        private Color errorTipsForeColor = Color.White;

        [Browsable(true), Category("自定义属性"), Description("错误提示文字颜色"), Localizable(true)]
        public Color ErrorTipsForeColor
        {
            get { return errorTipsForeColor; }
            set { errorTipsForeColor = value; }
        }

        #region 构造函数    English:Constructor
        public VerificationComponent()
        {

        }

        public VerificationComponent(IContainer container)
            : this()
        {
            container.Add(this);
        }
        #endregion

        #region 指定此对象是否可以将其扩展程序属性提供给指定的对象。    English:Specifies whether this object can provide its extender properties to the specified object.
        /// <summary>
        /// 指定此对象是否可以将其扩展程序属性提供给指定的对象。
        /// </summary>
        /// <param name="extendee">要接收扩展程序属性的 <see cref="T:System.Object" />。</param>
        /// <returns>如果此对象可以扩展程序属性提供给指定对象，则为 true；否则为 false。</returns>
        public bool CanExtend(object extendee)
        {
            if (extendee is TextBoxBase || extendee is UCTextBoxEx || extendee is ComboBox || extendee is UCCombox)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 验证规则    English:Validation rule
        [Browsable(true), Category("自定义属性"), Description("验证规则"), DisplayName("VerificationModel"), Localizable(true)]
        public VerificationModel GetVerificationModel(Control control)
        {
            if (m_controlCache.ContainsKey(control))
            {
                return m_controlCache[control];
            }
            else
                return VerificationModel.None;
        }

        public void SetVerificationModel(Control control, VerificationModel vm)
        {
            m_controlCache[control] = vm;
        }
        #endregion

        #region 自定义正则    English:Custom Rules
        [Browsable(true), Category("自定义属性"), Description("自定义验证正则表达式"), DisplayName("VerificationCustomRegex"), Localizable(true)]
        public string GetVerificationCustomRegex(Control control)
        {
            if (m_controlRegexCache.ContainsKey(control))
            {
                return m_controlRegexCache[control];
            }
            else
                return "";
        }

        public void SetVerificationCustomRegex(Control control, string strRegex)
        {
            m_controlRegexCache[control] = strRegex;
        }
        #endregion

        #region 必填    English:Must fill
        [Browsable(true), Category("自定义属性"), Description("是否必填项"), DisplayName("VerificationRequired"), Localizable(true)]
        public bool GetVerificationRequired(Control control)
        {
            if (m_controlRequiredCache.ContainsKey(control))
                return m_controlRequiredCache[control];
            return false;
        }

        public void SetVerificationRequired(Control control, bool blnRequired)
        {
            m_controlRequiredCache[control] = blnRequired;
        }
        #endregion

        #region 提示信息    English:Prompt information
        [Browsable(true), Category("自定义属性"), Description("验证错误提示信息，当为空时则使用默认提示信息"), DisplayName("VerificationErrorMsg"), Localizable(true)]
        public string GetVerificationErrorMsg(Control control)
        {
            if (m_controlMsgCache.ContainsKey(control))
                return m_controlMsgCache[control];
            return "";
        }

        public void SetVerificationErrorMsg(Control control, string strErrorMsg)
        {
            m_controlMsgCache[control] = strErrorMsg;
        }
        #endregion


        #region 验证    English:Verification
        /// <summary>
        /// 功能描述:验证    English:Verification result processing
        /// 作　　者:HZH
        /// 创建日期:2019-09-28 09:02:49
        /// 任务编号:POS
        /// </summary>
        /// <param name="c">c</param>
        /// <returns>返回值</returns>
        public bool Verification(Control c)
        {
            bool bln = true;
            if (m_controlCache.ContainsKey(c))
            {
                var vm = m_controlCache[c];
                string strRegex = "";
                string strErrMsg = "";
                #region 获取正则或默认错误提示    English:Get regular or error prompts
                if (vm == VerificationModel.Custom)
                {
                    //自定义正则
                    if (m_controlRegexCache.ContainsKey(c))
                    {
                        strRegex = m_controlRegexCache[c];
                        strErrMsg = "不正确的输入";
                    }
                }
                else
                {
                    //获取默认正则和错误提示
                    Type type = vm.GetType();   //获取类型  
                    MemberInfo[] memberInfos = type.GetMember(vm.ToString());
                    if (memberInfos.Length > 0)
                    {
                        var atts = memberInfos[0].GetCustomAttributes(typeof(VerificationAttribute), false);
                        if (atts.Length > 0)
                        {
                            var va = ((VerificationAttribute)atts[0]);
                            strErrMsg = va.ErrorMsg;
                            strRegex = va.Regex;
                        }
                    }
                }
                #endregion

                #region 取值    English:Value
                string strValue = "";
                if (c is TextBoxBase)
                {
                    strValue = (c as TextBoxBase).Text;
                }
                else if (c is UCTextBoxEx)
                {
                    strValue = (c as UCTextBoxEx).InputText;
                }
                else if (c is ComboBox)
                {
                    var cbo = (c as ComboBox);
                    if (cbo.DropDownStyle == ComboBoxStyle.DropDownList)
                    {
                        strValue = cbo.SelectedItem == null ? "" : cbo.SelectedValue.ToString();
                    }
                    else
                    {
                        strValue = cbo.Text;
                    }
                }
                else if (c is UCCombox)
                {
                    strValue = (c as UCCombox).SelectedText;
                }
                #endregion

                //自定义错误信息
                if (m_controlMsgCache.ContainsKey(c) && !string.IsNullOrEmpty(m_controlMsgCache[c]))
                    strErrMsg = m_controlMsgCache[c];

                //检查必填项
                if (m_controlRequiredCache.ContainsKey(c) && m_controlRequiredCache[c])
                {
                    if (string.IsNullOrEmpty(strValue))
                    {
                        VerControl(new VerificationEventArgs()
                        {
                            VerificationModel = vm,
                            Regex = strRegex,
                            ErrorMsg = "不能为空",
                            IsVerifySuccess = false,
                            Required = true,
                            VerificationControl = c
                        });
                        bln = false;
                        return false;
                    }
                }
                //验证正则
                if (!string.IsNullOrEmpty(strValue))
                {
                    if (!string.IsNullOrEmpty(strRegex))
                    {
                        if (!Regex.IsMatch(strValue, strRegex))
                        {
                            VerControl(new VerificationEventArgs()
                            {
                                VerificationModel = vm,
                                Regex = strRegex,
                                ErrorMsg = strErrMsg,
                                IsVerifySuccess = false,
                                Required = m_controlRequiredCache.ContainsKey(c) && m_controlRequiredCache[c],
                                VerificationControl = c
                            });
                            bln = false;
                            return false;
                        }
                    }
                }
                //没有问题出发一个成功信息
                VerControl(new VerificationEventArgs()
                {
                    VerificationModel = vm,
                    Regex = strRegex,
                    ErrorMsg = strErrMsg,
                    IsVerifySuccess = true,
                    Required = m_controlRequiredCache.ContainsKey(c) && m_controlRequiredCache[c],
                    VerificationControl = c
                });
            }
            return bln;
        }
        #endregion
        #region 验证    English:Verification
        /// <summary>
        /// 功能描述:验证    English:Verification
        /// 作　　者:HZH
        /// 创建日期:2019-09-27 17:54:38
        /// 任务编号:POS
        /// </summary>
        /// <returns>返回值</returns>
        public bool Verification()
        {
            bool bln = true;
            foreach (var item in m_controlCache)
            {
                Control c = item.Key;
                if (!Verification(c))
                {
                    bln = false;
                }
            }
            return bln;
        }
        #endregion



        #region 验证结果处理    English:Verification result processing
        /// <summary>
        /// 功能描述:验证结果处理    English:Verification result processing
        /// 作　　者:HZH
        /// 创建日期:2019-09-27 17:54:59
        /// 任务编号:POS
        /// </summary>
        /// <param name="e">e</param>
        private void VerControl(VerificationEventArgs e)
        {
            //如果成功则移除失败提示
            if (e.IsVerifySuccess)
            {
                if (m_controlTips.ContainsKey(e.VerificationControl))
                {
                    m_controlTips[e.VerificationControl].Close();
                    m_controlTips.Remove(e.VerificationControl);
                }
            }
            //触发事件
            if (Verificationed != null)
            {
                Verificationed(e);
                if (e.IsProcessed)//如果已处理，则不再向下执行
                {
                    return;
                }
            }
            //如果失败则显示提示
            if (!e.IsVerifySuccess)
            {
                if (m_controlTips.ContainsKey(e.VerificationControl))
                {
                    m_controlTips[e.VerificationControl].StrMsg = e.ErrorMsg;
                }
                else
                {
                    var tips = Forms.FrmAnchorTips.ShowTips(e.VerificationControl, e.ErrorMsg, background: errorTipsBackColor, foreColor: errorTipsForeColor, autoCloseTime: 0, blnTopMost: false);
                    m_controlTips[e.VerificationControl] = tips;
                }
            }
        }
        #endregion
    }
}
