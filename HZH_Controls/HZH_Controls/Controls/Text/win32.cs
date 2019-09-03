// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="win32.cs">
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
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class win32.
    /// </summary>
    public class win32
    {

        /// <summary>
        /// The wm mousemove
        /// </summary>
        public const int WM_MOUSEMOVE = 0x0200;
        /// <summary>
        /// The wm lbuttondown
        /// </summary>
        public const int WM_LBUTTONDOWN = 0x0201;
        /// <summary>
        /// The wm lbuttonup
        /// </summary>
        public const int WM_LBUTTONUP = 0x0202;
        /// <summary>
        /// The wm rbuttondown
        /// </summary>
        public const int WM_RBUTTONDOWN = 0x0204;
        /// <summary>
        /// The wm lbuttondblclk
        /// </summary>
        public const int WM_LBUTTONDBLCLK = 0x0203;

        /// <summary>
        /// The wm mouseleave
        /// </summary>
        public const int WM_MOUSELEAVE = 0x02A3;



        /// <summary>
        /// The wm paint
        /// </summary>
        public const int WM_PAINT = 0x000F;
        /// <summary>
        /// The wm erasebkgnd
        /// </summary>
        public const int WM_ERASEBKGND = 0x0014;

        /// <summary>
        /// The wm print
        /// </summary>
        public const int WM_PRINT = 0x0317;

        //const int EN_HSCROLL       =   0x0601;
        //const int EN_VSCROLL       =   0x0602;

        /// <summary>
        /// The wm hscroll
        /// </summary>
        public const int WM_HSCROLL = 0x0114;
        /// <summary>
        /// The wm vscroll
        /// </summary>
        public const int WM_VSCROLL = 0x0115;


        /// <summary>
        /// The em getsel
        /// </summary>
        public const int EM_GETSEL = 0x00B0;
        /// <summary>
        /// The em lineindex
        /// </summary>
        public const int EM_LINEINDEX = 0x00BB;
        /// <summary>
        /// The em linefromchar
        /// </summary>
        public const int EM_LINEFROMCHAR = 0x00C9;

        /// <summary>
        /// The em posfromchar
        /// </summary>
        public const int EM_POSFROMCHAR = 0x00D6;



        /// <summary>
        /// Posts the message.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("USER32.DLL", EntryPoint = "PostMessage")]
        public static extern bool PostMessage(IntPtr hwnd, uint msg,
            IntPtr wParam, IntPtr lParam);

        /*
            BOOL PostMessage(          HWND hWnd,
                UINT Msg,
                WPARAM wParam,
                LPARAM lParam
                );
        */

        // Put this declaration in your class   //IntPtr
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("USER32.DLL", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam,
            IntPtr lParam);




        /// <summary>
        /// Gets the caret blink time.
        /// </summary>
        /// <returns>System.UInt32.</returns>
        [DllImport("USER32.DLL", EntryPoint = "GetCaretBlinkTime")]
        public static extern uint GetCaretBlinkTime();




        /// <summary>
        /// The wm printclient
        /// </summary>
        const int WM_PRINTCLIENT = 0x0318;

        /// <summary>
        /// The PRF checkvisible
        /// </summary>
        const long PRF_CHECKVISIBLE = 0x00000001L;
        /// <summary>
        /// The PRF nonclient
        /// </summary>
        const long PRF_NONCLIENT = 0x00000002L;
        /// <summary>
        /// The PRF client
        /// </summary>
        const long PRF_CLIENT = 0x00000004L;
        /// <summary>
        /// The PRF erasebkgnd
        /// </summary>
        const long PRF_ERASEBKGND = 0x00000008L;
        /// <summary>
        /// The PRF children
        /// </summary>
        const long PRF_CHILDREN = 0x00000010L;
        /// <summary>
        /// The PRF owned
        /// </summary>
        const long PRF_OWNED = 0x00000020L;

        /*  Will clean this up later doing something like this
        enum  CaptureOptions : long
        {
            PRF_CHECKVISIBLE= 0x00000001L,
            PRF_NONCLIENT	= 0x00000002L,
            PRF_CLIENT		= 0x00000004L,
            PRF_ERASEBKGND	= 0x00000008L,
            PRF_CHILDREN	= 0x00000010L,
            PRF_OWNED		= 0x00000020L
        }
        */


        /// <summary>
        /// Captures the window.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool CaptureWindow(System.Windows.Forms.Control control,
                                ref System.Drawing.Bitmap bitmap)
        {
            //This function captures the contents of a window or control

            Graphics g2 = Graphics.FromImage(bitmap);

            //PRF_CHILDREN // PRF_NONCLIENT
            int meint = (int)(PRF_CLIENT | PRF_ERASEBKGND); //| PRF_OWNED ); //  );
            System.IntPtr meptr = new System.IntPtr(meint);

            System.IntPtr hdc = g2.GetHdc();
            win32.SendMessage(control.Handle, win32.WM_PRINT, hdc, meptr);

            g2.ReleaseHdc(hdc);
            g2.Dispose();

            return true;

        }



    }
}
