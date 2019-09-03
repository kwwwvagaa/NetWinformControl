// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="FrmAnchor.cs">
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
    /// <seealso cref="System.Windows.Forms.Form" />
    /// <seealso cref="System.Windows.Forms.IMessageFilter" />
    public partial class FrmAnchor : Form, IMessageFilter
    {

        /// <summary>
        /// The m parent control
        /// </summary>
        Control m_parentControl = null;
        /// <summary>
        /// The BLN down
        /// </summary>
        private bool blnDown = true;
        /// <summary>
        /// The m size
        /// </summary>
        Size m_size;
        /// <summary>
        /// The m deviation
        /// </summary>
        Point? m_deviation;
        /// <summary>
        /// The m is not focus
        /// </summary>
        bool m_isNotFocus = true;
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
        /// <param name="isNotFocus">是否无焦点窗体</param>
        public FrmAnchor(Control parentControl, Control childControl, Point? deviation = null,bool isNotFocus=true)
        {
            m_isNotFocus = isNotFocus;
            m_parentControl = parentControl;
            InitializeComponent();
            this.Size = childControl.Size;
            this.HandleCreated += FrmDownBoard_HandleCreated;
            this.HandleDestroyed += FrmDownBoard_HandleDestroyed;
            this.Controls.Add(childControl);
            childControl.Dock = DockStyle.Fill;

            m_size = childControl.Size;
            m_deviation = deviation;

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


        /// <summary>
        /// Initializes a new instance of the <see cref="FrmAnchor" /> class.
        /// </summary>
        /// <param name="parentControl">The parent control.</param>
        /// <param name="size">The size.</param>
        /// <param name="deviation">The deviation.</param>
        /// <param name="isNotFocus">if set to <c>true</c> [is not focus].</param>
        public FrmAnchor(Control parentControl, Size size, Point? deviation = null, bool isNotFocus = true)
        {
            m_isNotFocus = isNotFocus;
            m_parentControl = parentControl;
            InitializeComponent();
            this.Size = size;
            this.HandleCreated += FrmDownBoard_HandleCreated;
            this.HandleDestroyed += FrmDownBoard_HandleDestroyed;

            m_size = size;
            m_deviation = deviation;           
        }

        /// <summary>
        /// Handles the LocationChanged event of the frmP control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void frmP_LocationChanged(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        /// <summary>
        /// Handles the HandleDestroyed event of the FrmDownBoard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmDownBoard_HandleDestroyed(object sender, EventArgs e)
        {
            Application.RemoveMessageFilter(this);
        }

        /// <summary>
        /// Handles the HandleCreated event of the FrmDownBoard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmDownBoard_HandleCreated(object sender, EventArgs e)
        {
            Application.AddMessageFilter(this);
        }

        #region 无焦点窗体

        /// <summary>
        /// Sets the active window.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns>IntPtr.</returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private extern static IntPtr SetActiveWindow(IntPtr handle);
        /// <summary>
        /// The wm activate
        /// </summary>
        private const int WM_ACTIVATE = 0x006;
        /// <summary>
        /// The wm activateapp
        /// </summary>
        private const int WM_ACTIVATEAPP = 0x01C;
        /// <summary>
        /// The wm ncactivate
        /// </summary>
        private const int WM_NCACTIVATE = 0x086;
        /// <summary>
        /// The wa inactive
        /// </summary>
        private const int WA_INACTIVE = 0;
        /// <summary>
        /// The wm mouseactivate
        /// </summary>
        private const int WM_MOUSEACTIVATE = 0x21;
        /// <summary>
        /// The ma noactivate
        /// </summary>
        private const int MA_NOACTIVATE = 3;
        /// <summary>
        /// WNDs the proc.
        /// </summary>
        /// <param name="m">要处理的 Windows <see cref="T:System.Windows.Forms.Message" />。</param>
        protected override void WndProc(ref Message m)
        {
            if (m_isNotFocus)
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
            }
            base.WndProc(ref m);
        }

        #endregion

        /// <summary>
        /// 在调度消息之前将其筛选出来。
        /// </summary>
        /// <param name="m">要调度的消息。无法修改此消息。</param>
        /// <returns>如果筛选消息并禁止消息被调度，则为 true；如果允许消息继续到达下一个筛选器或控件，则为 false。</returns>
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != 0x0201 || this.Visible == false)
                return false;
            var pt = this.PointToClient(MousePosition);
            this.Visible = this.ClientRectangle.Contains(pt);
            return false;
        }

        /// <summary>
        /// Handles the Load event of the FrmAnchor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmAnchor_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Handles the VisibleChanged event of the FrmAnchor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmAnchor_VisibleChanged(object sender, EventArgs e)
        {
            timer1.Enabled = this.Visible;
            if (this.Visible)
            {
                Point p = m_parentControl.Parent.PointToScreen(m_parentControl.Location);
                int intX = 0;
                int intY = 0;
                if (p.Y + m_parentControl.Height + m_size.Height > Screen.PrimaryScreen.Bounds.Height)
                {
                    intY = p.Y - m_size.Height - 1;
                    blnDown = false;
                }
                else
                {
                    intY = p.Y + m_parentControl.Height + 1;
                    blnDown = true;
                }

                if (p.X + m_size.Width > Screen.PrimaryScreen.Bounds.Width)
                {
                    intX = Screen.PrimaryScreen.Bounds.Width - m_size.Width;

                }
                else
                {
                    intX = p.X;
                }
                if (m_deviation.HasValue)
                {
                    intX += m_deviation.Value.X;
                    intY += m_deviation.Value.Y;
                }
                this.Location = new Point(intX, intY);
            }
        }

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                Form frm = this.Owner as Form;
                IntPtr _ptr = ControlHelper.GetForegroundWindow();
                if (_ptr != frm.Handle && _ptr!=this.Handle)
                {
                    this.Hide();
                }
            }
        }
    }
}
