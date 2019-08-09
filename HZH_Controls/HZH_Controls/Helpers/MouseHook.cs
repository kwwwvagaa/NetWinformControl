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
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_MBUTTONUP = 0x208;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_MBUTTONDBLCLK = 0x209;

        /// <summary>
        /// 点
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }

        /// <summary>
        /// 钩子结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hWnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        public const int WH_MOUSE_LL = 14; // mouse hook constant

        // 装置钩子的函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        // 卸下钩子的函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        // 下一个钩挂的函数
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        // 全局的鼠标事件
        public static event MouseEventHandler OnMouseActivity;

        // 钩子回调函数
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

        // 声明鼠标钩子事件类型
        private static HookProc _mouseHookProcedure;
        private static int _hMouseHook = 0; // 鼠标钩子句柄
        /// <summary>
        /// 启动全局钩子
        /// </summary>
        public static void Start()
        {
            // 安装鼠标钩子
            if (_hMouseHook != 0)
            {
                Stop();
            }
            // 生成一个HookProc的实例.
            _mouseHookProcedure = new HookProc(MouseHookProc);

            _hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, _mouseHookProcedure, Marshal.GetHINSTANCE(System.Reflection.Assembly.GetEntryAssembly().GetModules()[0]), 0);

            //假设装置失败停止钩子
            if (_hMouseHook == 0)
            {
                Stop();
                throw new Exception("SetWindowsHookEx failed.");
            }
        }

        /// <summary>
        /// 停止全局钩子
        /// </summary>
        public static void Stop()
        {
            bool retMouse = true;

            if (_hMouseHook != 0)
            {
                retMouse = UnhookWindowsHookEx(_hMouseHook);
                _hMouseHook = 0;
            }

            // 假设卸下钩子失败
            if (!(retMouse))
                throw new Exception("UnhookWindowsHookEx failed.");
        }

        /// <summary>
        /// 鼠标钩子回调函数
        /// </summary>
        private static int MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            // 假设正常执行而且用户要监听鼠标的消息
            if ((nCode >= 0) && (OnMouseActivity != null))
            {
                MouseButtons button = MouseButtons.None;
                int clickCount = 0;

                switch (wParam)
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

            // 启动下一次钩子
            int inext = CallNextHookEx(_hMouseHook, nCode, wParam, lParam);
            return inext;
        }
    }
}
