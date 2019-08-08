using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    public partial class UCKeyBorderNum : UserControl
    {
        private bool useCustomEvent = false;
        /// <summary>
        /// 是否使用自定义的事件来接收按键，当为true时将不再向系统发送按键请求
        /// </summary>
        [Description("是否使用自定义的事件来接收按键，当为true时将不再向系统发送按键请求"), Category("自定义")]
        public bool UseCustomEvent
        {
            get { return useCustomEvent; }
            set { useCustomEvent = value; }
        }
        [Description("数字点击事件"),Category("自定义")]
        public event EventHandler NumClick;
        [Description("删除点击事件"), Category("自定义")]
        public event EventHandler BackspaceClick;
        [Description("回车点击事件"), Category("自定义")]
        public event EventHandler EnterClick;
        public UCKeyBorderNum()
        {
            InitializeComponent();           
        }

        private void Num_MouseDown(object sender, MouseEventArgs e)
        {
            if (NumClick != null)
            {
                NumClick(sender, e);
            }
            if (useCustomEvent)
                return;
            Label lbl = sender as Label;
            SendKeys.Send(lbl.Tag.ToString());
        }

        private void Backspace_MouseDown(object sender, MouseEventArgs e)
        {
            if (BackspaceClick != null)
            {
                BackspaceClick(sender, e);
            }
            if (useCustomEvent)
                return;
            Label lbl = sender as Label;
            SendKeys.Send("{BACKSPACE}");
        }

        private void Enter_MouseDown(object sender, MouseEventArgs e)
        {
            if (EnterClick != null)
            {
                EnterClick(sender, e);
            }
            if (useCustomEvent)
                return;  
            SendKeys.Send("{ENTER}");            
        }
    }
}
