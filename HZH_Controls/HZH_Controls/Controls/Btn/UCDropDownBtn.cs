// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-27-2019
//
// ***********************************************************************
// <copyright file="UCDropDownBtn.cs">
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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCDropDownBtn.
    /// Implements the <see cref="HZH_Controls.Controls.UCBtnImg" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.UCBtnImg" />
    [DefaultEvent("BtnClick")]
    public partial class UCDropDownBtn : UCBtnImg
    {
        /// <summary>
        /// The FRM anchor
        /// </summary>
        Forms.FrmAnchor _frmAnchor;
        /// <summary>
        /// The drop panel height
        /// </summary>
        private int _dropPanelHeight = -1;
        /// <summary>
        /// 按钮点击事件
        /// </summary>
        public new event EventHandler BtnClick;
        /// <summary>
        /// 下拉框高度
        /// </summary>
        /// <value>The height of the drop panel.</value>
        [Description("下拉框高度"), Category("自定义")]
        public int DropPanelHeight
        {
            get { return _dropPanelHeight; }
            set { _dropPanelHeight = value; }
        }
        /// <summary>
        /// The BTNS
        /// </summary>
        private string[] btns;
        /// <summary>
        /// 需要显示的按钮文字
        /// </summary>
        /// <value>The BTNS.</value>
        [Description("需要显示的按钮文字"), Category("自定义")]
        public string[] Btns
        {
            get { return btns; }
            set { btns = value; }
        }
        /// <summary>
        /// 图片
        /// </summary>
        /// <value>The image.</value>
        [Obsolete("不再可用的属性")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Image Image
        {
            get;
            set;
        }
        /// <summary>
        /// 图片位置
        /// </summary>
        /// <value>The image align.</value>
        [Obsolete("不再可用的属性")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override ContentAlignment ImageAlign
        {
            get;
            set;
        }
        /// <summary>
        /// 按钮字体颜色
        /// </summary>
        /// <value>The color of the BTN fore.</value>
        [Description("按钮字体颜色"), Category("自定义")]
        public override Color BtnForeColor
        {
            get
            {
                return base.BtnForeColor;
            }
            set
            {
                base.BtnForeColor = value;
                Bitmap bit = new Bitmap(12, 10);
                Graphics g = Graphics.FromImage(bit);
                g.SetGDIHigh();
                GraphicsPath path = new GraphicsPath();
                path.AddLines(new Point[] 
                {
                    new Point(1,1),
                    new Point(11,1),
                    new Point(6,10),
                    new Point(1,1)
                });
                g.FillPath(new SolidBrush(value), path);
                g.Dispose();
                this.lbl.Image = bit;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDropDownBtn" /> class.
        /// </summary>
        public UCDropDownBtn()
        {
            InitializeComponent();
            IsShowTips = false;
            this.lbl.ImageAlign = ContentAlignment.MiddleRight;
            base.BtnClick += UCDropDownBtn_BtnClick;
        }

        /// <summary>
        /// Handles the BtnClick event of the UCDropDownBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
        /// <summary>
        /// Handles the SelectSourceEvent event of the ucTime control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
