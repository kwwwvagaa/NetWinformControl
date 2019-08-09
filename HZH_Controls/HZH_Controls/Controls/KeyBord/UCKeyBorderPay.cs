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
    public partial class UCKeyBorderPay : UserControl
    {
        [Description("数字点击事件"), Category("自定义")]
        public event EventHandler NumClick;

        [Description("取消点击事件"), Category("自定义")]
        public event EventHandler CancelClick;

        [Description("确定点击事件"), Category("自定义")]
        public event EventHandler OKClick;

        [Description("删除点击事件"), Category("自定义")]
        public event EventHandler BackspaceClick;

        [Description("金额点击事件"), Category("自定义")]
        public event EventHandler MoneyClick;
        public UCKeyBorderPay()
        {
            InitializeComponent();
        }

        #region 设置快速付款金额
        /// <summary>
        /// 功能描述:设置快速付款金额
        /// 作　　者:HZH
        /// 创建日期:2019-03-07 11:41:04
        /// 任务编号:POS
        /// </summary>
        /// <param name="SorceMoney">SorceMoney</param>
        public void SetPayMoney(decimal SorceMoney)
        {
            List<decimal> list = new List<decimal>();
            decimal d = Math.Ceiling(SorceMoney);
            if (SorceMoney > 0m)
            {
                if (SorceMoney < 5m)
                {
                    list.Add(5m);
                    list.Add(10m);
                    list.Add(20m);
                    list.Add(50m);
                }
                else if (SorceMoney < 10m)
                {
                    list.Add(10m);
                    list.Add(20m);
                    list.Add(50m);
                    list.Add(100m);
                }
                else
                {
                    int num = Convert.ToInt32(d % 10m);
                    int num2 = Convert.ToInt32(Math.Floor(d / 10m) % 10m);
                    int num3 = Convert.ToInt32(Math.Floor(d / 100m));
                    int num4;
                    if (num < 5)
                    {
                        num4 = num2 * 10 + 5;
                        list.Add(num4 + num3 * 100);
                        num4 = (num2 + 1) * 10;
                        list.Add(num4 + num3 * 100);
                    }
                    else
                    {
                        num4 = (num2 + 1) * 10;
                        list.Add(num4 + num3 * 100);
                    }
                    if (num4 >= 0 && num4 < 10)
                    {
                        num4 = 10;
                        if (list.Count < 4)
                        {
                            list.Add(num4 + num3 * 100);
                        }
                        num4 = 20;
                        if (list.Count < 4)
                        {
                            list.Add(num4 + num3 * 100);
                        }
                        num4 = 50;
                        if (list.Count < 4)
                        {
                            list.Add(num4 + num3 * 100);
                        }
                        num4 = 100;
                        if (list.Count < 4)
                        {
                            list.Add(num4 + num3 * 100);
                        }
                    }
                    else if (num4 >= 10 && num4 < 20)
                    {
                        num4 = 20;
                        if (list.Count < 4)
                        {
                            list.Add(num4 + num3 * 100);
                        }
                        num4 = 50;
                        if (list.Count < 4)
                        {
                            list.Add(num4 + num3 * 100);
                        }
                        num4 = 100;
                        if (list.Count < 4)
                        {
                            list.Add(num4 + num3 * 100);
                        }
                    }
                    else if (num4 >= 20 && num4 < 50)
                    {
                        num4 = 50;
                        if (list.Count < 4)
                        {
                            list.Add(num4 + num3 * 100);
                        }
                        num4 = 100;
                        if (list.Count < 4)
                        {
                            list.Add(num4 + num3 * 100);
                        }
                    }
                    else if (num4 < 100)
                    {
                        num4 = 100;
                        if (list.Count < 4)
                        {
                            list.Add(num4 + num3 * 100);
                        }
                    }
                }
            }
            SetFastMoneyToContrl(list);
        }
        #endregion

        private void SetFastMoneyToContrl(List<decimal> values)
        {
            List<Label> lbl = new List<Label>() { lblFast1, lblFast2, lblFast3, lblFast4 };
            lblFast1.Tag = lblFast1.Text = "";
            lblFast2.Tag = lblFast2.Text = "";
            lblFast3.Tag = lblFast3.Text = "";
            lblFast4.Tag = lblFast4.Text = "";
            for (int i = 0; i < lbl.Count && i < values.Count; i++)
            {
                if (values[i].ToString("0.##").Length < 4)
                {
                    lbl[i].Font = new System.Drawing.Font("Arial Unicode MS", 30F);                   
                }
                else
                {
                    Graphics graphics = lbl[i].CreateGraphics();
                    for (int j = 0; j < 5; j++)
                    {
                        SizeF sizeF = graphics.MeasureString(values[i].ToString("0.##"), new System.Drawing.Font("Arial Unicode MS", 30 - j * 5), 100, StringFormat.GenericTypographic);
                        if (sizeF.Width <= lbl[i].Width - 20)
                        {
                            lbl[i].Font = new System.Drawing.Font("Arial Unicode MS", 30 - j * 5);
                            break;
                        }
                    }
                    graphics.Dispose();
                }
                lbl[i].Tag = lbl[i].Text = values[i].ToString("0.##");
            }           
        }
        private void Num_MouseDown(object sender, MouseEventArgs e)
        {
            if (NumClick != null)
                NumClick((sender as Label).Tag, e);
        }

        private void Backspace_MouseDown(object sender, MouseEventArgs e)
        {
            if (BackspaceClick != null)
                BackspaceClick((sender as Label).Tag, e);
        }

        private void Cancel_MouseDown(object sender, MouseEventArgs e)
        {
            if (CancelClick != null)
                CancelClick((sender as Label).Tag, e);
        }

        private void OK_MouseDown(object sender, MouseEventArgs e)
        {
            if (OKClick != null)
                OKClick((sender as Label).Tag, e);
        }

        private void Money_MouseDown(object sender, MouseEventArgs e)
        {
            if (MoneyClick != null)
                MoneyClick((sender as Label).Tag, e);
        }

        public void Money1Click()
        {
            Money_MouseDown(lblFast1, null);
        }

        public void Money2Click()
        {
            Money_MouseDown(lblFast2, null);
        }

        public void Money3Click()
        {
            Money_MouseDown(lblFast3, null);
        }

        public void Money4Click()
        {
            Money_MouseDown(lblFast4, null);
        }
    }
}
