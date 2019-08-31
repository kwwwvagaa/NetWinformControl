// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCDropDownBtn.cs
// 作　　者：HZH
// 创建日期：2019-08-31 16:01:36
// 功能描述：UCDropDownBtn    English:UCDropDownBtn
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
// 项目地址：https://github.com/kwwwvagaa/NetWinformControl
// 如果你使用了此类，请保留以上说明
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls.Btn
{
    [DefaultEvent("BtnClick")]
    public partial class UCDropDownBtn : UCBtnImg
    {
        Forms.FrmAnchor _frmAnchor;
        private int _dropPanelHeight = -1;
        public new event EventHandler BtnClick;
        [Description("下拉框高度"), Category("自定义")]
        public int DropPanelHeight
        {
            get { return _dropPanelHeight; }
            set { _dropPanelHeight = value; }
        }
        private string[] btns;
        [Description("按钮"), Category("自定义")]
        public string[] Btns
        {
            get { return btns; }
            set { btns = value; }
        }
        [Obsolete("不再可用的属性")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Image Image
        {
            get;
            set;
        }
        [Obsolete("不再可用的属性")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override ContentAlignment ImageAlign
        {
            get;
            set;
        }

        public UCDropDownBtn()
        {
            InitializeComponent();
            IsShowTips = false;
            this.lbl.Image = Properties.Resources.ComboBox;
            this.lbl.ImageAlign = ContentAlignment.MiddleRight;
            base.BtnClick += UCDropDownBtn_BtnClick;
        }

        void UCDropDownBtn_BtnClick(object sender, EventArgs e)
        {
            if (_frmAnchor == null || _frmAnchor.IsDisposed || _frmAnchor.Visible == false)
            {

                if (Btns != null && Btns.Length > 0)
                {
                    int intRow = 0;
                    int intCom = 1;
                    var p = this.PointToScreen(this.Location);
                    while (true)
                    {
                        int intScreenHeight = Screen.PrimaryScreen.Bounds.Height;
                        if ((p.Y + this.Height + Btns.Length / intCom * 50 < intScreenHeight || p.Y - Btns.Length / intCom * 50 > 0)
                            && (_dropPanelHeight <= 0 ? true : (Btns.Length / intCom * 50 <= _dropPanelHeight)))
                        {
                            intRow = Btns.Length / intCom + (Btns.Length % intCom != 0 ? 1 : 0);
                            break;
                        }
                        intCom++;
                    }
                    UCTimePanel ucTime = new UCTimePanel();
                    ucTime.IsShowBorder = true;
                    int intWidth = this.Width / intCom;

                    Size size = new Size(intCom * intWidth, intRow * 50);
                    ucTime.Size = size;
                    ucTime.FirstEvent = true;
                    ucTime.SelectSourceEvent += ucTime_SelectSourceEvent;
                    ucTime.Row = intRow;
                    ucTime.Column = intCom;

                    List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
                    foreach (var item in Btns)
                    {
                        lst.Add(new KeyValuePair<string, string>(item, item));
                    }
                    ucTime.Source = lst;

                    _frmAnchor = new Forms.FrmAnchor(this, ucTime);
                    _frmAnchor.Load += (a, b) => { (a as Form).Size = size; };

                    _frmAnchor.Show(this.FindForm());

                }
            }
            else
            {
                _frmAnchor.Close();
            }
        }
        void ucTime_SelectSourceEvent(object sender, EventArgs e)
        {
            if (_frmAnchor != null && !_frmAnchor.IsDisposed && _frmAnchor.Visible)
            {
                _frmAnchor.Close();

                if (BtnClick != null)
                {
                    BtnClick(sender.ToString(), e);
                }
            }
        }
    }
}
