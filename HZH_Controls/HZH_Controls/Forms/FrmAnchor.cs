// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：FrmAnchor.cs
// 创建日期：2019-08-15 16:04:24
// 功能描述：FrmAnchor
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
    /// <summary>
    /// 功能描述:停靠窗体
    /// 作　　者:HZH
    /// 创建日期:2019-02-27 11:49:03
    /// 任务编号:POS
    /// </summary>
    public partial class FrmAnchor : Form, IMessageFilter
    {
        Control m_parentControl = null;
        private bool blnDown = true;
        #region 构造函数
        /// <summary>
        /// 功能描述:构造函数
        /// 作　　者:HZH
        /// 创建日期:2019-02-27 11:49:08
        /// 任务编号:POS
        /// </summary>
        /// <param name="parentControl">父控件</param>
        /// <param name="childControl">子控件</param>
        /// <param name="deviation">偏移</param>
        public FrmAnchor(Control parentControl, Control childControl, Point? deviation = null)
        {
            m_parentControl = parentControl;
            InitializeComponent();
            this.Size = childControl.Size;
            this.HandleCreated += FrmDownBoard_HandleCreated;
            this.HandleDestroyed += FrmDownBoard_HandleDestroyed;
            this.Controls.Add(childControl);
            childControl.Dock = DockStyle.Fill;
            Point p = parentControl.Parent.PointToScreen(parentControl.Location);
            int intX = 0;
            int intY = 0;
            if (p.Y + parentControl.Height + childControl.Height > Screen.PrimaryScreen.Bounds.Height)
            {
                intY = p.Y - childControl.Height - 1;
                blnDown = false;
            }
            else
            {
                intY = p.Y + parentControl.Height + 1;
                blnDown = true;
            }

            if (p.X + childControl.Width > Screen.PrimaryScreen.Bounds.Width)
            {
                intX = Screen.PrimaryScreen.Bounds.Width - childControl.Width;

            }
            else
            {
                intX = p.X;
            }
            if (deviation.HasValue)
            {
                intX += deviation.Value.X;
                intY += deviation.Value.Y;
            }
            this.Location = new Point(intX, intY);

            if (parentControl.FindForm() != null)
            {
                Form frmP = parentControl.FindForm();
                if (!frmP.IsDisposed)
                {
                    frmP.LocationChanged += frmP_LocationChanged;
                }
            }
            parentControl.LocationChanged += frmP_LocationChanged;
        }

        void frmP_LocationChanged(object sender, EventArgs e)
        {
            this.Hide();
        }

        public FrmAnchor(Control parentControl, Size size, Point? deviation = null)
        {
            m_parentControl = parentControl;
            InitializeComponent();
            this.Size = size;
            this.HandleCreated += FrmDownBoard_HandleCreated;
            this.HandleDestroyed += FrmDownBoard_HandleDestroyed;

            Point p = parentControl.Parent.PointToScreen(parentControl.Location);
            int intX = 0;
            int intY = 0;
            if (p.Y + parentControl.Height + size.Height > Screen.PrimaryScreen.Bounds.Height)
            {
                intY = p.Y - size.Height - 1;
                blnDown = false;
            }
            else
            {
                intY = p.Y + parentControl.Height + 1;
                blnDown = true;
            }

            if (p.X + size.Width > Screen.PrimaryScreen.Bounds.Width)
            {
                intX = Screen.PrimaryScreen.Bounds.Width - size.Width;

            }
            else
            {
                intX = p.X;
            }
            if (deviation.HasValue)
            {
                intX += deviation.Value.X;
                intY += deviation.Value.Y;
            }
            this.Location = new Point(intX, intY);
        }

        #endregion

        private void FrmDownBoard_HandleDestroyed(object sender, EventArgs e)
        {
            Application.RemoveMessageFilter(this);
        }

        private void FrmDownBoard_HandleCreated(object sender, EventArgs e)
        {
            Application.AddMessageFilter(this);
        }

        #region 无焦点窗体

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private extern static IntPtr SetActiveWindow(IntPtr handle);
        private const int WM_ACTIVATE = 0x006;
        private const int WM_ACTIVATEAPP = 0x01C;
        private const int WM_NCACTIVATE = 0x086;
        private const int WA_INACTIVE = 0;
        private const int WM_MOUSEACTIVATE = 0x21;
        private const int MA_NOACTIVATE = 3;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                m.Result = new IntPtr(MA_NOACTIVATE);
                return;
            }
            else if (m.Msg == WM_NCACTIVATE)
            {
                if (((int)m.WParam & 0xFFFF) != WA_INACTIVE)
                {
                    if (m.LParam != IntPtr.Zero)
                    {
                        SetActiveWindow(m.LParam);
                    }
                    else
                    {
                        SetActiveWindow(IntPtr.Zero);
                    }
                }
            }
            base.WndProc(ref m);
        }

        #endregion

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != 0x0201 || this.Visible == false)
                return false;
            var pt = this.PointToClient(MousePosition);
            this.Visible = this.ClientRectangle.Contains(pt);
            return false;
        }

        private void FrmAnchor_Load(object sender, EventArgs e)
        {

        }


        private void FrmAnchor_VisibleChanged(object sender, EventArgs e)
        {
            timer1.Enabled = this.Visible;
            if (Visible)
            {
                if (blnDown)
                    ControlHelper.AnimateWindow(this.Handle, 100, ControlHelper.AW_VER_POSITIVE);
                else
                {
                    ControlHelper.AnimateWindow(this.Handle, 100, ControlHelper.AW_VER_NEGATIVE);
                }
            }
            else
            {
                if (blnDown)
                    ControlHelper.AnimateWindow(this.Handle, 100, ControlHelper.AW_VER_NEGATIVE | ControlHelper.AW_HIDE);
                else
                {
                    ControlHelper.AnimateWindow(this.Handle, 100, ControlHelper.AW_VER_POSITIVE | ControlHelper.AW_HIDE);

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                Form frm = this.Owner as Form;
                IntPtr _ptr = ControlHelper.GetForegroundWindow();
                if (_ptr != frm.Handle)
                {
                    this.Hide();
                }
            }
        }

    }
}
