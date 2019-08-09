using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Forms
{
    public partial class FrmTransparent : FrmBase
    {
        private const int WM_ACTIVATE = 6;

        private const int WM_ACTIVATEAPP = 28;

        private const int WM_NCACTIVATE = 134;

        private const int WA_INACTIVE = 0;

        private const int WM_MOUSEACTIVATE = 33;

        private const int MA_NOACTIVATE = 3;

        public FrmBase frmchild
        {
            get;
            set;
        }
        public FrmTransparent()
        {
            InitializeComponent();
           
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);

            MethodInfo method = base.GetType().GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
            method.Invoke(this, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, new object[]
			{
				ControlStyles.Selectable,
				false
			}, Application.CurrentCulture);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            base.ShowInTaskbar = false;
            base.ShowIcon = true;
        }
        [DllImport("user32.dll")]
        private static extern IntPtr SetActiveWindow(IntPtr handle);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 33)
            {
                m.Result = new IntPtr(3);
            }
            else
            {
                if (m.Msg == 134)
                {
                    if (((int)m.WParam & 65535) != 0)
                    {
                        if (m.LParam != IntPtr.Zero)
                        {
                            FrmTransparent.SetActiveWindow(m.LParam);
                        }
                        else
                        {
                            FrmTransparent.SetActiveWindow(IntPtr.Zero);
                        }
                    }
                }
                else if (m.Msg == 2000)
                {
                }
                base.WndProc(ref m);
            }
        }

        private void FrmTransparent_Load(object sender, EventArgs e)
        {
            if (frmchild != null)
            {
                frmchild.IsShowMaskDialog = false;
                var dia = frmchild.ShowDialog(this);
                this.DialogResult = dia;
            }
        }
    }
}
