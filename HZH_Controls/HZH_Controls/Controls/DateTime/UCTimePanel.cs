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
    [ToolboxItem(false)]
    public partial class UCTimePanel : UserControl
    {
        public event EventHandler SelectSourceEvent;
        private List<KeyValuePair<string, string>> source = null;
        public bool FirstEvent { get; set; }

        public List<KeyValuePair<string, string>> Source
        {
            get { return source; }
            set
            {
                source = value;
                SetSource(value);
            }
        }

        private bool _IsShowBorder = false;

        public bool IsShowBorder
        {
            get { return _IsShowBorder; }
            set
            {
                _IsShowBorder = value;
                ucSplitLine_H1.Visible = value;
                ucSplitLine_H2.Visible = value;
                ucSplitLine_V1.Visible = value;
                ucSplitLine_V2.Visible = value;
            }
        }

        UCBtnExt selectBtn;
        /// <summary>
        /// 选中按钮
        /// </summary>
        public UCBtnExt SelectBtn
        {
            get { return selectBtn; }
            set
            {
                if (selectBtn != null && !selectBtn.IsDisposed)
                {
                    selectBtn.FillColor = System.Drawing.Color.White;
                    selectBtn.RectColor = System.Drawing.Color.White;
                    selectBtn.BtnForeColor = System.Drawing.Color.FromArgb(66, 66, 66);
                }
                bool blnEvent = FirstEvent ? true : (selectBtn != null);
                selectBtn = value;
                if (value != null)
                {
                    selectBtn.FillColor = System.Drawing.Color.FromArgb(255, 77, 59);
                    selectBtn.RectColor = System.Drawing.Color.FromArgb(255, 77, 59);
                    selectBtn.BtnForeColor = System.Drawing.Color.White;
                    if (blnEvent && SelectSourceEvent != null)
                        SelectSourceEvent(selectBtn.Tag.ToStringExt(), null);
                }
            }
        }
        public UCTimePanel()
        {
            InitializeComponent();
            this.SizeChanged += UCTimePanel_SizeChanged;
        }

        void UCTimePanel_SizeChanged(object sender, EventArgs e)
        {

        }

        private int row = 0;

        public int Row
        {
            get { return row; }
            set
            {
                row = value;
                ReloadPanel();
            }
        }


        private int column = 0;

        public int Column
        {
            get { return column; }
            set
            {
                column = value;
                ReloadPanel();
            }
        }

        private void UCTimePanel_Load(object sender, EventArgs e)
        {

        }

        #region 设置面板数据源
        /// <summary>
        /// 功能描述:设置面板数据源
        /// 作　　者:HZH
        /// 创建日期:2019-06-25 15:02:15
        /// 任务编号:POS
        /// </summary>
        /// <param name="lstSource">lstSource</param>
        public void SetSource(List<KeyValuePair<string, string>> lstSource)
        {
            try
            {
                ControlHelper.FreezeControl(this, true);
                if (row <= 0 || column <= 0)
                    return;
                if (Source != lstSource)
                    Source = lstSource;
                int index = 0;
                SelectBtn = null;
                foreach (UCBtnExt btn in this.panMain.Controls)
                {
                    if (lstSource != null && index < lstSource.Count)
                    {
                        btn.BtnText = lstSource[index].Value;
                        btn.Tag = lstSource[index].Key;
                        index++;
                    }
                    else
                    {
                        btn.BtnText = "";
                        btn.Tag = null;
                    }
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }
        #endregion
        /// <summary>
        /// 设置选中项
        /// </summary>
        /// <param name="strKey"></param>
        public void SetSelect(string strKey)
        {
            foreach (UCBtnExt item in this.panMain.Controls)
            {
                if (item.Tag != null && item.Tag.ToStringExt() == strKey)
                {
                    SelectBtn = item;
                    return;
                }
            }
            SelectBtn = new UCBtnExt();
        }

        #region 重置面板
        /// <summary>
        /// 功能描述:重置面板
        /// 作　　者:HZH
        /// 创建日期:2019-06-25 15:02:05
        /// 任务编号:POS
        /// </summary>
        public void ReloadPanel()
        {
            if (row <= 0 || column <= 0)
                return;
            SelectBtn = null;
            this.panMain.Controls.Clear();
            this.panMain.ColumnCount = column;
            this.panMain.ColumnStyles.Clear();
            for (int i = 0; i < column; i++)
            {
                this.panMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }

            this.panMain.RowCount = row;
            this.panMain.RowStyles.Clear();
            for (int i = 0; i < row; i++)
            {
                this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    UCBtnExt btn = new UCBtnExt();
                    btn.BackColor = System.Drawing.Color.Transparent;
                    btn.BtnBackColor = System.Drawing.Color.Transparent;
                    btn.BtnFont = new System.Drawing.Font("微软雅黑", 13F);
                    btn.BtnForeColor = System.Drawing.Color.FromArgb(66, 66, 66);
                    btn.ConerRadius = 5;
                    btn.Dock = DockStyle.Fill;
                    btn.FillColor = System.Drawing.Color.White;
                    btn.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                    btn.Cursor = Cursor.Current;
                    btn.IsShowRect = true;
                    btn.IsRadius = true;
                    btn.IsShowTips = false;
                    btn.Name = "btn_" + i + "_" + j;
                    btn.RectColor = System.Drawing.Color.White;
                    btn.RectWidth = 1;
                    btn.Width = this.Width;
                    btn.TabIndex = 0;
                    btn.TipsText = "";
                    btn.BtnClick += btn_BtnClick;
                    this.panMain.Controls.Add(btn, j, i);
                }
            }

            if (Source != null)
            {
                SetSource(Source);
            }
        }
        #endregion

        void btn_BtnClick(object sender, EventArgs e)
        {
            var btn = (UCBtnExt)sender;
            if (btn.Tag == null)
                return;
            SelectBtn = btn;
        }
    }
}
