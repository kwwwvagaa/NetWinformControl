// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：ControlHelper.cs
// 创建日期：2019-08-15 16:05:35
// 功能描述：ControlHelper
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace HZH_Controls
{
    public static class ControlHelper
    {
        #region 设置控件Enabled，切不改变控件颜色
        /// <summary>
        /// 功能描述:设置控件Enabled，切不改变控件颜色
        /// 作　　者:HZH
        /// 创建日期:2019-03-04 13:43:32
        /// 任务编号:POS
        /// </summary>
        /// <param name="c">c</param>
        /// <param name="enabled">enabled</param>
        public static void SetControlEnabled(this Control c, bool enabled)
        {
            if (!c.IsDisposed)
            {
                if (enabled)
                {
                    ControlHelper.SetWindowLong(c.Handle, -16, -134217729 & ControlHelper.GetWindowLong(c.Handle, -16));
                }
                else
                {
                    ControlHelper.SetWindowLong(c.Handle, -16, 134217728 + ControlHelper.GetWindowLong(c.Handle, -16));
                }
            }
        }

        /// <summary>
        /// 功能描述:设置控件Enabled，切不改变控件颜色
        /// 作　　者:HZH
        /// 创建日期:2019-03-04 13:43:32
        /// 任务编号:POS
        /// </summary>
        /// <param name="cs">cs</param>
        /// <param name="enabled">enabled</param>
        public static void SetControlEnableds(Control[] cs, bool enabled)
        {
            for (int i = 0; i < cs.Length; i++)
            {
                Control c = cs[i];
                SetControlEnabled(c, enabled);
            }
        }
        #endregion
        [DllImport("user32.dll ")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int wndproc);

        [DllImport("user32.dll ")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        private static void ThreadBaseCallBack(Control parent, object obj)
        {
            if (obj is Exception)
            {
                if (parent != null)
                {
                    ThreadInvokerControl(parent, delegate
                    {
                        Exception ex = obj as Exception;
                    });
                }
            }
        }
        /// <summary>
        /// 委托调用主线程控件
        /// </summary>
        /// <param name="parent">主线程控件</param>
        /// <param name="action">修改控件方法</param>
        public static void ThreadInvokerControl(Control parent, Action action)
        {
            if (parent != null)
            {
                if (parent.InvokeRequired)
                {
                    parent.BeginInvoke(action);
                }
                else
                {
                    action();
                    SetForegroundWindow(parent.Handle);
                }
            }
        }
        /// <summary>
        /// 使用一个线程执行一个操作
        /// </summary>
        /// <param name="parent">父控件</param>
        /// <param name="func">执行内容</param>
        /// <param name="callback">执行后回调</param>
        /// <param name="enableControl">执行期间禁用控件列表</param>
        /// <param name="blnShowSplashScreen">执行期间是否显示等待提示</param>
        /// <param name="strMsg">执行期间等待提示内容，默认为“正在处理，请稍候...”</param>
        /// <param name="intSplashScreenDelayTime">延迟显示等待提示时间</param>
        public static void ThreadRunExt(
          Control parent,
          Action func,
          Action<object> callback,
          Control enableControl = null,
          bool blnShowSplashScreen = true,
          string strMsg = null,
          int intSplashScreenDelayTime = 200)
        {
            ThreadRunExt(parent, func, callback, new Control[] { enableControl }, blnShowSplashScreen, strMsg, intSplashScreenDelayTime);
        }
        /// <summary>
        /// 使用一个线程执行一个操作
        /// </summary>
        /// <param name="parent">父控件</param>
        /// <param name="func">执行内容</param>
        /// <param name="callback">执行后回调</param>
        /// <param name="enableControl">执行期间禁用控件列表</param>
        /// <param name="blnShowSplashScreen">执行期间是否显示等待提示</param>
        /// <param name="strMsg">执行期间等待提示内容，默认为“正在处理，请稍候...”</param>
        /// <param name="intSplashScreenDelayTime">延迟显示等待提示时间</param>
        public static void ThreadRunExt(
            Control parent,
            Action func,
            Action<object> callback,
            Control[] enableControl = null,
            bool blnShowSplashScreen = true,
            string strMsg = null,
            int intSplashScreenDelayTime = 200)
        {
            if (blnShowSplashScreen)
            {
                if (string.IsNullOrEmpty(strMsg))
                {
                    strMsg = "正在处理，请稍候...";
                }
                if (parent != null)
                {
                    ShowProcessPanel(parent, strMsg, intSplashScreenDelayTime);
                }
            }
            if (enableControl != null)
            {
                List<Control> lstCs = new List<Control>();
                foreach (var c in enableControl)
                {
                    if (c == null)
                        continue;
                    if (c is Form)
                    {
                        lstCs.AddRange(c.Controls.ToArray());
                    }
                    else
                    {
                        lstCs.Add(c);
                    }
                }
                SetControlEnableds(lstCs.ToArray(), false);
            }
            ThreadPool.QueueUserWorkItem(delegate(object a)
            {
                try
                {
                    func();
                    if (callback != null)
                    {
                        callback(null);
                    }
                }
                catch (Exception obj)
                {
                    if (callback != null)
                    {
                        callback(obj);
                    }
                    else
                    {
                        ThreadBaseCallBack(parent, obj);
                    }
                }
                finally
                {
                    if (parent != null)
                    {
                        ThreadInvokerControl(parent, delegate
                        {
                            CloseProcessPanel(parent);
                            SetForegroundWindow(parent.Handle);
                        });
                    }
                    if (enableControl != null)
                    {
                        if (parent != null)
                        {
                            ThreadInvokerControl(parent, delegate
                            {
                                List<Control> lstCs = new List<Control>();
                                foreach (var c in enableControl)
                                {
                                    if (c == null)
                                        continue;
                                    if (c is Form)
                                    {
                                        lstCs.AddRange(c.Controls.ToArray());
                                    }
                                    else
                                    {
                                        lstCs.Add(c);
                                    }
                                }
                                SetControlEnableds(lstCs.ToArray(), true);
                            });
                        }
                    }
                }
            });
        }

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        public static void ShowProcessPanel(Control parent, string strMessage, int intSplashScreenDelayTime = 0)
        {
            if (parent.InvokeRequired)
            {
                parent.BeginInvoke(new MethodInvoker(delegate
                {
                    ShowProcessPanel(parent, strMessage, intSplashScreenDelayTime);
                }));
            }
            else
            {
                parent.VisibleChanged -= new EventHandler(parent_VisibleChanged);
                parent.VisibleChanged += new EventHandler(parent_VisibleChanged);
                parent.FindForm().FormClosing -= ControlHelper_FormClosing;
                parent.FindForm().FormClosing += ControlHelper_FormClosing;
                Control control = null;
                lock (parent)
                {
                    control = HaveProcessPanelControl(parent);
                    if (control == null)
                    {
                        control = CreateProgressPanel();
                        parent.Controls.Add(control);
                    }
                }
                Forms.FrmWaiting frmWaitingEx = control.Tag as Forms.FrmWaiting;
                frmWaitingEx.Msg = strMessage;
                frmWaitingEx.ShowForm(intSplashScreenDelayTime);
            }
        }

        static void ControlHelper_FormClosing(object sender, FormClosingEventArgs e)
        {
            Control control = sender as Control;
            control.FindForm().FormClosing -= ControlHelper_FormClosing;
            CloseWaiting(control);
        }

        private static void parent_VisibleChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            control.VisibleChanged -= new EventHandler(parent_VisibleChanged);
            if (!control.Visible)
            {
                CloseWaiting(control);
            }
        }

        private static void CloseWaiting(Control control)
        {
            Control[] array = control.Controls.Find("myprogressPanelext", false);
            if (array.Length > 0)
            {
                Control control2 = array[0];
                if (control2.Tag != null && control2.Tag is Forms.FrmWaiting)
                {
                    Forms.FrmWaiting frmWaitingEx = control2.Tag as Forms.FrmWaiting;
                    if (frmWaitingEx != null && !frmWaitingEx.IsDisposed && frmWaitingEx.Visible)
                    {
                        frmWaitingEx.Hide();
                    }
                }
            }
        }

        public static void CloseProcessPanel(Control parent)
        {
            if (parent.InvokeRequired)
            {
                parent.BeginInvoke(new MethodInvoker(delegate
                {
                    CloseProcessPanel(parent);
                }));
            }
            else if (parent != null)
            {
                Control control = HaveProcessPanelControl(parent);
                if (control != null)
                {
                    Form frm = control.Tag as Form;
                    if (frm != null && !frm.IsDisposed && frm.Visible)
                    {
                        if (frm.InvokeRequired)
                        {
                            frm.BeginInvoke(new MethodInvoker(delegate
                            {
                                frm.Hide();
                            }));
                        }
                        else
                        {
                            frm.Hide();
                        }
                    }
                }
            }
        }

        public static Control HaveProcessPanelControl(Control parent)
        {
            Control[] array = parent.Controls.Find("myprogressPanelext", false);
            Control result;
            if (array.Length > 0)
            {
                result = array[0];
            }
            else
            {
                result = null;
            }
            return result;
        }

        public static Control CreateProgressPanel()
        {
            return new Label
            {
                Name = "myprogressPanelext",
                Visible = false,
                Tag = new Forms.FrmWaiting
                {
                    TopMost = true,
                    Opacity = 0.0
                }
            };
        }

        public static Control[] ToArray(this System.Windows.Forms.Control.ControlCollection controls)
        {
            if (controls == null || controls.Count <= 0)
                return new Control[0];
            List<Control> lst = new List<Control>();
            foreach (Control item in controls)
            {
                lst.Add(item);
            }
            return lst.ToArray();
        }


        #region 根据控件宽度截取字符串
        /// <summary>
        /// 功能描述:根据控件宽度截取字符串
        /// 作　　者:HZH
        /// 创建日期:2019-06-27 10:49:10
        /// 任务编号:POS
        /// </summary>
        /// <param name="strSource">字符串</param>
        /// <param name="fltControlWidth">控件宽度</param>
        /// <param name="g">Graphics</param>
        /// <param name="font">字体</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(
            string strSource,
            float fltControlWidth,
            System.Drawing.Graphics g,
            System.Drawing.Font font)
        {
            try
            {
                fltControlWidth = fltControlWidth - 20;
                strSource = strSource.Trim();
                while (true)
                {

                    System.Drawing.SizeF sizeF = g.MeasureString(strSource.Replace(" ", "A"), font);
                    if (sizeF.Width > fltControlWidth)
                    {
                        strSource = strSource.TrimEnd('…');
                        if (strSource.Length <= 1)
                            return "";
                        strSource = strSource.Substring(0, strSource.Length - 1).Trim() + "…";
                    }
                    else
                    {
                        return strSource;
                    }
                }
            }
            finally
            {
                g.Dispose();
            }
        }
        #endregion

        #region 获取字符串宽度
        /// <summary>
        /// 功能描述:获取字符串宽度
        /// 作　　者:HZH
        /// 创建日期:2019-06-27 11:54:50
        /// 任务编号:POS
        /// </summary>
        /// <param name="strSource">strSource</param>
        /// <param name="g">g</param>
        /// <param name="font">font</param>
        /// <returns>返回值</returns>
        public static int GetStringWidth(
           string strSource,
           System.Drawing.Graphics g,
           System.Drawing.Font font)
        {
            string[] strs = strSource.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            float fltWidth = 0;
            foreach (var item in strs)
            {
                System.Drawing.SizeF sizeF = g.MeasureString(strSource.Replace(" ", "A"), font);
                if (sizeF.Width > fltWidth)
                    fltWidth = sizeF.Width;
            }

            return (int)fltWidth;
        }
        #endregion

        #region 动画特效
        [DllImport("user32.dll")]
        public static extern bool AnimateWindow(IntPtr whnd, int dwtime, int dwflag);
        //dwflag的取值如下
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        //从左到右显示
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        //从右到左显示
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        //从上到下显示
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        //从下到上显示
        public const Int32 AW_CENTER = 0x00000010;
        //若使用了AW_HIDE标志，则使窗口向内重叠，即收缩窗口；否则使窗口向外扩展，即展开窗口
        public const Int32 AW_HIDE = 0x00010000;
        //隐藏窗口，缺省则显示窗口
        public const Int32 AW_ACTIVATE = 0x00020000;
        //激活窗口。在使用了AW_HIDE标志后不能使用这个标志
        public const Int32 AW_SLIDE = 0x00040000;
        //使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略
        public const Int32 AW_BLEND = 0x00080000;
        //透明度从高到低
        #endregion

        #region 检查文本控件输入类型是否有效
        /// <summary>
        /// 功能描述:检查文本控件输入类型是否有效
        /// 作　　者:HZH
        /// 创建日期:2019-02-28 10:23:34
        /// 任务编号:POS
        /// </summary>
        /// <param name="strValue">值</param>
        /// <param name="inputType">控制类型</param>
        /// <param name="decMaxValue">最大值</param>
        /// <param name="decMinValue">最小值</param>
        /// <param name="intLength">小数位长度</param>
        /// <param name="strRegexPattern">正则</param>
        /// <returns>返回值</returns>
        public static bool CheckInputType(
            string strValue,
            TextInputType inputType,
            decimal decMaxValue = default(decimal),
            decimal decMinValue = default(decimal),
            int intLength = 2,
            string strRegexPattern = null)
        {
            bool result;
            switch (inputType)
            {
                case TextInputType.NotControl:
                    result = true;
                    return result;
                case TextInputType.UnsignNumber:
                    if (string.IsNullOrEmpty(strValue))
                    {
                        result = true;
                        return result;
                    }
                    else
                    {
                        if (strValue.IndexOf("-") >= 0)
                        {
                            result = false;
                            return result;
                        }
                    }
                    break;
                case TextInputType.Number:
                    if (string.IsNullOrEmpty(strValue))
                    {
                        result = true;
                        return result;
                    }
                    else
                    {
                        if (!Regex.IsMatch(strValue, "^-?\\d*(\\.?\\d*)?$"))
                        {
                            result = false;
                            return result;
                        }
                    }
                    break;
                case TextInputType.Integer:
                    if (string.IsNullOrEmpty(strValue))
                    {
                        result = true;
                        return result;
                    }
                    else
                    {
                        if (!Regex.IsMatch(strValue, "^-?\\d*$"))
                        {
                            result = false;
                            return result;
                        }
                    }
                    break;
                case TextInputType.PositiveInteger:
                    if (string.IsNullOrEmpty(strValue))
                    {
                        result = true;
                        return result;
                    }
                    else
                    {
                        if (!Regex.IsMatch(strValue, "^\\d+$"))
                        {
                            result = false;
                            return result;
                        }
                    }
                    break;
                case TextInputType.Regex:
                    result = (string.IsNullOrEmpty(strRegexPattern) || Regex.IsMatch(strValue, strRegexPattern));
                    return result;
            }
            if (strValue == "-")
            {
                return true;
            }
            decimal d;
            if (!decimal.TryParse(strValue, out d))
            {
                result = false;
            }
            else if (d < decMinValue || d > decMaxValue)
            {
                result = false;
            }
            else
            {
                if (inputType == TextInputType.Number || inputType == TextInputType.UnsignNumber || inputType == TextInputType.PositiveNumber)
                {
                    if (strValue.IndexOf(".") >= 0)
                    {
                        string text = strValue.Substring(strValue.IndexOf("."));
                        if (text.Length > intLength + 1)
                        {
                            result = false;
                            return result;
                        }
                    }
                }
                result = true;
            }
            return result;
        }
        #endregion

        #region 冻结控件
        static Dictionary<Control, bool> m_lstFreezeControl = new Dictionary<Control, bool>();
        /// <summary>
        /// 功能描述:停止更新控件
        /// 作　　者:HZH
        /// 创建日期:2019-07-13 11:11:32
        /// 任务编号:POS
        /// </summary>
        /// <param name="control">control</param>
        /// <param name="blnToFreeze">是否停止更新</param>
        public static void FreezeControl(Control control, bool blnToFreeze)
        {
            if (blnToFreeze && control.IsHandleCreated && control.Visible && !control.IsDisposed && (!m_lstFreezeControl.ContainsKey(control) || (m_lstFreezeControl.ContainsKey(control) && m_lstFreezeControl[control] == false)))
            {
                m_lstFreezeControl[control] = true;
                control.Disposed += control_Disposed;
                NativeMethods.SendMessage(control.Handle, 11, 0, 0);
            }
            else if (!blnToFreeze && !control.IsDisposed && m_lstFreezeControl.ContainsKey(control) && m_lstFreezeControl[control] == true)
            {
                m_lstFreezeControl.Remove(control);
                NativeMethods.SendMessage(control.Handle, 11, 1, 0);
                control.Invalidate(true);
            }
        }

        static void control_Disposed(object sender, EventArgs e)
        {
            try
            {
                if (m_lstFreezeControl.ContainsKey((Control)sender))
                    m_lstFreezeControl.Remove((Control)sender);
            }
            catch { }
        }
        #endregion

    }
}
