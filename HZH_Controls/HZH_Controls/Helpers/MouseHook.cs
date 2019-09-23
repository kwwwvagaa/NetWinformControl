// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="MouseHook.cs">
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
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls
{
    /// <summary>
    /// 鼠标全局钩子
    /// </summary>
    public static class MouseHook
    {
        /// <summary>
        /// The wm mousemove
        /// </summary>
        private const int WM_MOUSEMOVE = 0x200;
        /// <summary>
        /// The wm lbuttondown
        /// </summary>
        private const int WM_LBUTTONDOWN = 0x201;
        /// <summary>
        /// The wm rbuttondown
        /// </summary>
        private const int WM_RBUTTONDOWN = 0x204;
        /// <summary>
        /// The wm mbuttondown
        /// </summary>
        private const int WM_MBUTTONDOWN = 0x207;
        /// <summary>
        /// The wm lbuttonup
        /// </summary>
        private const int WM_LBUTTONUP = 0x202;
        /// <summary>
        /// The wm rbuttonup
        /// </summary>
        private const int WM_RBUTTONUP = 0x205;
        /// <summary>
        /// The wm mbuttonup
        /// </summary>
        private const int WM_MBUTTONUP = 0x208;
        /// <summary>
        /// The wm lbuttondblclk
        /// </summary>
        private const int WM_LBUTTONDBLCLK = 0x203;
        /// <summary>
        /// The wm rbuttondblclk
        /// </summary>
        private const int WM_RBUTTONDBLCLK = 0x206;
        /// <summary>
        /// The wm mbuttondblclk
        /// </summary>
        private const int WM_MBUTTONDBLCLK = 0x209;

        /// <summary>
        /// 点
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            /// <summary>
            /// The x
            /// </summary>
            public int x;
            /// <summary>
            /// The y
            /// </summary>
            public int y;
        }

        /// <summary>
        /// 钩子结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            /// <summary>
            /// The pt
            /// </summary>
            public POINT pt;
            /// <summary>
            /// The h WND
            /// </summary>
            public int hWnd;
            /// <summary>
            /// The w hit test code
            /// </summary>
            public int wHitTestCode;
            /// <summary>
            /// The dw extra information
            /// </summary>
            public int dwExtraInfo;
        }
        

        // 全局的鼠标事件
        /// <summary>
        /// Occurs when [on mouse activity].
        /// </summary>
        public static event MouseEventHandler OnMouseActivity;

      
        /// <summary>
        /// The h mouse hook
        /// </summary>
        private static int _hMouseHook = 0; // 鼠标钩子句柄
        /// <summary>
        /// 启动全局钩子
        /// </summary>
        /// <exception cref="System.Exception">SetWindowsHookEx failed.</exception>
        /// <exception cref="Exception">SetWindowsHookEx failed.</exception>
        public static void Start()
        {
            // 安装鼠标钩子
            if (_hMouseHook != 0)
            {
                Stop();
            }
            // 生成一个HookProc的实例.
            WindowsHook.HookMsgChanged += WindowsHook_HookMsgChanged;
            _hMouseHook = WindowsHook.StartHook(HookType.WH_MOUSE_LL);

            //假设装置失败停止钩子
            if (_hMouseHook == 0)
            {
                Stop();
            }
        }

        static void WindowsHook_HookMsgChanged(string strHookName, int nCode, IntPtr msg, IntPtr lParam)
        {
            // 假设正常执行而且用户要监听鼠标的消息
            if (nCode >= 0 && OnMouseActivity != null)
            {
                MouseButtons button = MouseButtons.None;
                int clickCount = 0;

                switch ((int)msg)
                {
                    case WM_LBUTTONDOWN:
                        button = MouseButtons.Left;
                        clickCount = 1;
                        break;
                    case WM_LBUTTONUP:
                        button = MouseButtons.Left;
                        clickCount = 1;
                        break;
                    case WM_LBUTTONDBLCLK:
                        button = MouseButtons.Left;
                        clickCount = 2;
                        break;
                    case WM_RBUTTONDOWN:
                        button = MouseButtons.Right;
                        clickCount = 1;
                        break;
                    case WM_RBUTTONUP:
                        button = MouseButtons.Right;
                        clickCount = 1;
                        break;
                    case WM_RBUTTONDBLCLK:
                        button = MouseButtons.Right;
                        clickCount = 2;
                        break;
                }
                if (button != MouseButtons.None && clickCount > 0)
                {
                    // 从回调函数中得到鼠标的信息
                    MouseHookStruct MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                    MouseEventArgs e = new MouseEventArgs(button, clickCount, MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y, 0);
                    OnMouseActivity(null, e);
                }
            }
        }

        /// <summary>
        /// 停止全局钩子
        /// </summary>
        /// <exception cref="System.Exception">UnhookWindowsHookEx failed.</exception>
        /// <exception cref="Exception">UnhookWindowsHookEx failed.</exception>
        public static void Stop()
        {
            bool retMouse = true;

            if (_hMouseHook != 0)
            {
                retMouse = WindowsHook.StopHook(_hMouseHook);
                _hMouseHook = 0;
            }

            // 假设卸下钩子失败
            if (!(retMouse))
                throw new Exception("UnhookWindowsHookEx failed.");
        }


    }
}
