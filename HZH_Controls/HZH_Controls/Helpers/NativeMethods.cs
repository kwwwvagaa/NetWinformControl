using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HZH_Controls
{
    internal class NativeMethods
    {
        public enum ComboBoxButtonState
        {
            STATE_SYSTEM_NONE,
            STATE_SYSTEM_INVISIBLE = 32768,
            STATE_SYSTEM_PRESSED = 8
        }

        public struct RECT
        {
            public int Left;

            public int Top;

            public int Right;

            public int Bottom;

            public Rectangle Rect
            {
                get
                {
                    return new Rectangle(this.Left, this.Top, this.Right - this.Left, this.Bottom - this.Top);
                }
            }

            public Size Size
            {
                get
                {
                    return new Size(this.Right - this.Left, this.Bottom - this.Top);
                }
            }

            public RECT(int left, int top, int right, int bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }

            public RECT(Rectangle rect)
            {
                this.Left = rect.Left;
                this.Top = rect.Top;
                this.Right = rect.Right;
                this.Bottom = rect.Bottom;
            }

            public static NativeMethods.RECT FromXYWH(int x, int y, int width, int height)
            {
                return new NativeMethods.RECT(x, y, x + width, y + height);
            }

            public static NativeMethods.RECT FromRectangle(Rectangle rect)
            {
                return new NativeMethods.RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
            }
        }

        public struct PAINTSTRUCT
        {
            public IntPtr hdc;

            public int fErase;

            public NativeMethods.RECT rcPaint;

            public int fRestore;

            public int fIncUpdate;

            public int Reserved1;

            public int Reserved2;

            public int Reserved3;

            public int Reserved4;

            public int Reserved5;

            public int Reserved6;

            public int Reserved7;

            public int Reserved8;
        }

        public struct ComboBoxInfo
        {
            public int cbSize;

            public NativeMethods.RECT rcItem;

            public NativeMethods.RECT rcButton;

            public NativeMethods.ComboBoxButtonState stateButton;

            public IntPtr hwndCombo;

            public IntPtr hwndEdit;

            public IntPtr hwndList;
        }

        public const int WM_PAINT = 15;

        public const int WM_SETREDRAW = 11;

        public static readonly IntPtr FALSE = IntPtr.Zero;

        public static readonly IntPtr TRUE = new IntPtr(1);

        [DllImport("user32.dll")]
        public static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref NativeMethods.ComboBoxInfo info);

        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hwnd, ref NativeMethods.RECT lpRect);

        [DllImport("user32.dll")]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref NativeMethods.PAINTSTRUCT ps);

        [DllImport("user32.dll")]
        public static extern bool EndPaint(IntPtr hWnd, ref NativeMethods.PAINTSTRUCT ps);

        [DllImport("user32.dll")]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
    }
}
