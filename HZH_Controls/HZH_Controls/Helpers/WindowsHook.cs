using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HZH_Controls
{
    /// <summary>
    /// 钩子类型
    /// </summary>
    public enum HookType : int
    {
        /// <summary>
        /// 安装一个钩子过程，该过程监视由于对话框，消息框，菜单或滚动条中的输入事件而生成的消息。 
        /// 有关更多信息，请参阅MessageProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644987(v=vs.85)）挂接过程。
        /// </summary>
        WH_MSGFILTER = -1,
        /// <summary>
        /// 安装一个钩子过程，记录发布到系统消息队列的输入消息。 此挂钩对于录制宏非常有用。 
        /// 有关更多信息，请参阅JournalRecordProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644983(v=vs.85)）挂钩过程。
        /// </summary>
        WH_JOURNALRECORD = 0,
        /// <summary>
        /// 安装一个挂钩过程，该过程发布先前由WH_JOURNALRECORD挂钩过程记录的消息。 
        /// 有关更多信息，请参阅JournalPlaybackProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644982(v=vs.85)）挂钩过程。
        /// </summary>
        WH_JOURNALPLAYBACK = 1,
        /// <summary>
        /// 安装一个监视击键消息的钩子程序。 
        /// 有关更多信息，请参阅KeyboardProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644984(v=vs.85)）挂钩过程。
        /// </summary>
        WH_KEYBOARD = 2,
        /// <summary>
        /// 安装一个钩子过程来监视发布到消息队列的消息。 
        /// 有关更多信息，请参阅GetMsgProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644981(v=vs.85)）挂接过程。
        /// </summary>
        WH_GETMESSAGE = 3,
        /// <summary>
        /// 安装一个钩子过程，在系统将消息发送到目标窗口过程之前监视消息。 
        /// 有关更多信息，请参阅CallWndProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644975(v=vs.85)）挂接过程。
        /// </summary>
        WH_CALLWNDPROC = 4,
        /// <summary>
        /// 安装一个钩子程序，接收对CBT应用程序有用的通知。 
        /// 有关更多信息，请参阅CBTProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644977(v=vs.85)）挂钩过程。
        /// </summary>
        WH_CBT = 5,
        /// <summary>
        /// 安装一个钩子过程，该过程监视由于对话框，消息框，菜单或滚动条中的输入事件而生成的消息。 
        /// 钩子过程监视与调用线程在同一桌面中的所有应用程序的这些消息。 
        /// 有关更多信息，请参阅SysMsgProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644992(v=vs.85)）挂接过程。
        /// </summary>
        WH_SYSMSGFILTER = 6,
        /// <summary>
        /// 安装监视鼠标消息的钩子过程。 
        /// 有关更多信息，请参阅MouseProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644988(v=vs.85)）挂钩过程。
        /// </summary>
        WH_MOUSE = 7,
        /// <summary>
        /// 安装一个用于调试其他钩子过程的钩子过程。 
        /// 有关更多信息，请参阅DebugProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644978(v=vs.85)）挂接过程。
        /// </summary>
        WH_DEBUG = 9,
        /// <summary>
        /// 安装一个钩子过程，接收对shell应用程序有用的通知。 
        /// 有关更多信息，请参阅ShellProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644991(v=vs.85)）挂钩过程。
        /// </summary>
        WH_SHELL = 10,
        /// <summary>
        /// 安装一个钩子过程，当应用程序的前台线程即将变为空闲时将调用该过程。 
        /// 此挂钩对于在空闲时执行低优先级任务非常有用。 
        /// 有关更多信息，请参阅ForegroundIdleProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644980(v=vs.85)）挂钩过程。
        /// </summary>
        WH_FOREGROUNDIDLE = 11,
        /// <summary>
        /// 安装一个钩子过程，该过程在目标窗口过程处理完消息后对其进行监视。 
        /// 有关更多信息，请参阅CallWndRetProc（https://docs.microsoft.com/windows/desktop/api/winuser/nc-winuser-hookproc）挂接过程。
        /// </summary>
        WH_CALLWNDPROCRET = 12,
        /// <summary>
        /// 安装一个监视低级键盘输入事件的钩子过程。 有关更多信息，
        /// 请参阅LowLevelKeyboardProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644985(v=vs.85)）挂接过程。
        /// </summary>
        WH_KEYBOARD_LL = 13,
        /// <summary>
        /// 安装一个监视低级鼠标输入事件的钩子过程。 有关更多信息，
        /// 请参阅LowLevelMouseProc（https://docs.microsoft.com/previous-versions/windows/desktop/legacy/ms644986(v=vs.85)）挂接过程。
        /// </summary>
        WH_MOUSE_LL = 14,
    }
    public class WindowsHook
    {
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        // 装置钩子的函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, int hInstance, int threadId);

        // 卸下钩子的函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        // 下一个钩挂的函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        /// <summary>
        /// Delegate HookMsgHandler
        /// </summary>
        /// <param name="strHookName">钩子名称</param>
        /// <param name="msg">消息值</param>
        public delegate void HookMsgHandler(string strHookName, int nCode, IntPtr msg, IntPtr lParam);
        /// <summary>
        /// 钩子消息事件
        /// </summary>
        public static event HookMsgHandler HookMsgChanged;
        /// <summary>
        /// 启动一个钩子
        /// </summary>
        /// <param name="hookType">钩子类型</param>
        /// <param name="wParam">模块句柄，为空则为当前模块</param>
        /// <param name="pid">进程句柄，默认为0则表示当前进程</param>
        /// <param name="strHookName">钩子名称</param>
        /// <returns>钩子句柄（消耗钩子时需要使用）</returns>
        /// <exception cref="Exception">SetWindowsHookEx failed.</exception>
        public static int StartHook(HookType hookType, int wParam = 0, int pid = 0, string strHookName = "")
        {
            int _hHook = 0;
            // 生成一个HookProc的实例.
            var _hookProcedure = new HookProc((nCode, msg, lParam) =>
            {

                if (HookMsgChanged != null)
                {
                    try
                    {
                        HookMsgChanged(strHookName, nCode, msg, lParam);
                    }
                    catch { }
                }

                int inext = CallNextHookEx(_hHook, nCode, msg, lParam);
                return inext;
            });
            if (pid ==0)
                pid = AppDomain.GetCurrentThreadId();
            _hHook = SetWindowsHookEx((int)hookType, _hookProcedure, wParam, pid);

            //假设装置失败停止钩子
            if (_hHook == 0)
            {
                StopHook(_hHook);
            }
            return _hHook;
        }

        /// <summary>
        /// 停止钩子
        /// </summary>
        /// <param name="_hHook">StartHook函数返回的钩子句柄</param>
        /// <returns><c>true</c> if 停止成功, <c>false</c> 否则.</returns>
        public static bool StopHook(int _hHook)
        {
            bool ret = true;

            if (_hHook != 0)
            {
                ret = UnhookWindowsHookEx(_hHook);
            }

            // 假设卸下钩子失败
            if (!ret)
                return false;
            return true;
        }
    }
}
