// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-27
//
// ***********************************************************************
// <copyright file="VerificationComponent.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
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
    /// <summary>
    /// Class VerificationComponent.
    /// Implements the <see cref="System.ComponentModel.Component" />
    /// Implements the <see cref="System.ComponentModel.IExtenderProvider" />
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="System.ComponentModel.IExtenderProvider" />
    [ProvideProperty("VerificationModel", typeof(Control))]
    [ProvideProperty("VerificationCustomRegex", typeof(Control))]
    [ProvideProperty("VerificationRequired", typeof(Control))]
    [ProvideProperty("VerificationErrorMsg", typeof(Control))]
    [DefaultEvent("Verificationed")]
    public class VerificationComponent : Component, IExtenderProvider
    {
        /// <summary>
        /// Delegate VerificationedHandle
        /// </summary>
        /// <param name="e">The <see cref="VerificationEventArgs"/> instance containing the event data.</param>
        public delegate void VerificationedHandle(VerificationEventArgs e);
        /// <summary>
        /// Occurs when [verificationed].
        /// </summary>
        [Browsable(true), Category("自定义属性"), Description("验证事件"), Localizable(true)]
        public event VerificationedHandle Verificationed;

        /// <summary>
        /// The m control cache
        /// </summary>
        Dictionary<Control, VerificationModel> m_controlCache = new Dictionary<Control, VerificationModel>();
        /// <summary>
        /// The m control regex cache
        /// </summary>
        Dictionary<Control, string> m_controlRegexCache = new Dictionary<Control, string>();
        /// <summary>
        /// The m control required cache
        /// </summary>
        Dictionary<Control, bool> m_controlRequiredCache = new Dictionary<Control, bool>();
        /// <summary>
        /// The m control MSG cache
        /// </summary>
        Dictionary<Control, string> m_controlMsgCache = new Dictionary<Control, string>();
        /// <summary>
        /// The m control tips
        /// </summary>
        Dictionary<Control, Forms.FrmAnchorTips> m_controlTips = new Dictionary<Control, Forms.FrmAnchorTips>();

        /// <summary>
        /// The error tips back color
        /// </summary>
        private Color errorTipsBackColor = Color.FromArgb(255, 77, 58);

        /// <summary>
        /// Gets or sets the color of the error tips back.
        /// </summary>
        /// <value>The color of the error tips back.</value>
        [Browsable(true), Category("自定义属性"), Description("错误提示背景色"), Localizable(true)]
        public Color ErrorTipsBackColor
        {
            get { return errorTipsBackColor; }
            set { errorTipsBackColor = value; }
        }

        /// <summary>
        /// The error tips fore color
        /// </summary>
        private Color errorTipsForeColor = Color.White;

        /// <summary>
        /// Gets or sets the color of the error tips fore.
        /// </summary>
        /// <value>The color of the error tips fore.</value>
        [Browsable(true), Category("自定义属性"), Description("错误提示文字颜色"), Localizable(true)]
        public Color ErrorTipsForeColor
        {
            get { return errorTipsForeColor; }
            set { errorTipsForeColor = value; }
        }

        private int autoCloseErrorTipsTime = 3000;

        [Browsable(true), Category("自定义属性"), Description("自动关闭提示事件，当值为0时不自动关闭"), Localizable(true)]
        public int AutoCloseErrorTipsTime
        {
            get { return autoCloseErrorTipsTime; }
            set
            {
                if (value < 0)
                    return;
                autoCloseErrorTipsTime = value;
            }
        }

        #region 构造函数    English:Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="VerificationComponent"/> class.
        /// </summary>
        public VerificationComponent()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VerificationComponent"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
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
        /// <summary>
        /// Gets the verification model.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>VerificationModel.</returns>
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

        /// <summary>
        /// Sets the verification model.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="vm">The vm.</param>
        public void SetVerificationModel(Control control, VerificationModel vm)
        {
            m_controlCache[control] = vm;
        }
        #endregion

        #region 自定义正则    English:Custom Rules
        /// <summary>
        /// Gets the verification custom regex.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>System.String.</returns>
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

        /// <summary>
        /// Sets the verification custom regex.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="strRegex">The string regex.</param>
        public void SetVerificationCustomRegex(Control control, string strRegex)
        {
            m_controlRegexCache[control] = strRegex;
        }
        #endregion

        #region 必填    English:Must fill
        /// <summary>
        /// Gets the verification required.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [Browsable(true), Category("自定义属性"), Description("是否必填项"), DisplayName("VerificationRequired"), Localizable(true)]
        public bool GetVerificationRequired(Control control)
        {
            if (m_controlRequiredCache.ContainsKey(control))
                return m_controlRequiredCache[control];
            return false;
        }

        /// <summary>
        /// Sets the verification required.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="blnRequired">if set to <c>true</c> [BLN required].</param>
        public void SetVerificationRequired(Control control, bool blnRequired)
        {
            m_controlRequiredCache[control] = blnRequired;
        }
        #endregion

        #region 提示信息    English:Prompt information
        /// <summary>
        /// Gets the verification error MSG.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>System.String.</returns>
        [Browsable(true), Category("自定义属性"), Description("验证错误提示信息，当为空时则使用默认提示信息"), DisplayName("VerificationErrorMsg"), Localizable(true)]
        public string GetVerificationErrorMsg(Control control)
        {
            if (m_controlMsgCache.ContainsKey(control))
                return m_controlMsgCache[control];
            return "";
        }

        /// <summary>
        /// Sets the verification error MSG.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="strErrorMsg">The string error MSG.</param>
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
                    var tips = Forms.FrmAnchorTips.ShowTips(e.VerificationControl, e.ErrorMsg, background: errorTipsBackColor, foreColor: errorTipsForeColor, autoCloseTime: autoCloseErrorTipsTime, blnTopMost: false);
                    tips.FormClosing += tips_FormClosing;
                    m_controlTips[e.VerificationControl] = tips;
                }
            }
        }

        void tips_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in m_controlTips)
            {
                if (item.Value == sender)
                {
                    m_controlTips.Remove(item.Key);
                    break;
                }
            }
        }
        #endregion        
        /// <summary>
        /// 关闭所有错误提示
        /// </summary>
        public void CloseErrorTips()
        {
            for (int i = 0; i < 1; )
            {
                try
                {
                    foreach (var item in m_controlTips)
                    {
                        if (item.Value != null && !item.Value.IsDisposed)
                        {
                            item.Value.Close();
                        }
                    }
                }
                catch
                {
                    continue;
                }
                i++;
            }

            m_controlTips.Clear();
        }
        /// <summary>
        /// 关闭指定验证控件的提示
        /// </summary>
        /// <param name="verificationControl">验证控件.</param>
        public void CloseErrorTips(Control verificationControl)
        {
            if (m_controlTips.ContainsKey(verificationControl))
            {
                if (m_controlTips[verificationControl] != null && !m_controlTips[verificationControl].IsDisposed)
                {
                    m_controlTips[verificationControl].Close();
                }
            }
        }
    }
}
