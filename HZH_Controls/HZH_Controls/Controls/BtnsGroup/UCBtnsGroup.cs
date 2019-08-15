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
    public partial class UCBtnsGroup : UserControl
    {
        /// <summary>
        /// 选中改变事件
        /// </summary>
        public event EventHandler SelectedItemChanged;
        private Dictionary<string, string> m_dataSource = new Dictionary<string, string>();
        /// <summary>
        /// 数据源
        /// </summary>
        public Dictionary<string, string> DataSource
        {
            get { return m_dataSource; }
            set
            {
                m_dataSource = value;
                Reload();
            }
        }

        private List<string> m_selectItem = new List<string>();
        /// <summary>
        /// 选中项
        /// </summary>
        public List<string> SelectItem
        {
            get { return m_selectItem; }
            set
            {
                m_selectItem = value;
                if (m_selectItem == null)
                    m_selectItem = new List<string>();
            }
        }

        private bool m_isMultiple = false;
        /// <summary>
        /// 是否多选
        /// </summary>
        public bool IsMultiple
        {
            get { return m_isMultiple; }
            set { m_isMultiple = value; }
        }
        public UCBtnsGroup()
        {
            InitializeComponent();
        }

        private void Reload()
        {
            try
            {
                ControlHelper.FreezeControl(flowLayoutPanel1, true);
                this.flowLayoutPanel1.Controls.Clear();
                if (DataSource != null)
                {
                    foreach (var item in DataSource)
                    {
                        UCBtnExt btn = new UCBtnExt();
                        btn.BackColor = System.Drawing.Color.Transparent;
                        btn.BtnBackColor = System.Drawing.Color.White;
                        btn.BtnFont = new System.Drawing.Font("微软雅黑", 10F);
                        btn.BtnForeColor = System.Drawing.Color.Gray;
                        btn.BtnText = item.Value;
                        btn.ConerRadius = 5;
                        btn.Cursor = System.Windows.Forms.Cursors.Hand;
                        btn.FillColor = System.Drawing.Color.White;
                        btn.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                        btn.IsRadius = true;
                        btn.IsShowRect = true;
                        btn.IsShowTips = false;
                        btn.Location = new System.Drawing.Point(5, 5);
                        btn.Margin = new System.Windows.Forms.Padding(5);
                        btn.Name = item.Key;
                        btn.RectColor = System.Drawing.Color.FromArgb(224, 224, 224);
                        btn.RectWidth = 1;
                        btn.Size = new System.Drawing.Size(72, 38);
                        btn.TabStop = false;
                        btn.BtnClick += btn_BtnClick;
                        this.flowLayoutPanel1.Controls.Add(btn);
                    }
                }
            }
            finally
            {
                ControlHelper.FreezeControl(flowLayoutPanel1, false);
            }
            SetSelected();
        }

        void btn_BtnClick(object sender, EventArgs e)
        {
            var btn = sender as UCBtnExt;
            if (m_selectItem.Contains(btn.Name))
            {
                btn.RectColor = System.Drawing.Color.FromArgb(224, 224, 224);
                m_selectItem.Remove(btn.Name);
            }
            else
            {
                if (!m_isMultiple)
                {
                    foreach (var item in m_selectItem)
                    {
                        var lst = this.flowLayoutPanel1.Controls.Find(item, false);
                        if (lst.Length == 1)
                        {
                            var _btn = lst[0] as UCBtnExt;
                            _btn.RectColor = System.Drawing.Color.FromArgb(224, 224, 224);
                        }
                    }
                    m_selectItem.Clear();
                }
                btn.RectColor = System.Drawing.Color.FromArgb(255, 77, 59);
                m_selectItem.Add(btn.Name);
            }
            if (SelectedItemChanged != null)
                SelectedItemChanged(this, e);
        }

        private void SetSelected()
        {
            if (m_selectItem != null && m_selectItem.Count > 0 && DataSource != null && DataSource.Count > 0)
            {
                try
                {
                    ControlHelper.FreezeControl(flowLayoutPanel1, true);
                    if (m_isMultiple)
                    {
                        foreach (var item in m_selectItem)
                        {
                            var lst = this.flowLayoutPanel1.Controls.Find(item, false);
                            if (lst.Length == 1)
                            {
                                var btn = lst[0] as UCBtnExt;
                                btn.RectColor = System.Drawing.Color.FromArgb(255, 77, 59);
                            }
                        }
                    }
                    else
                    {
                        UCBtnExt btn = null;
                        foreach (var item in m_selectItem)
                        {
                            var lst = this.flowLayoutPanel1.Controls.Find(item, false);
                            if (lst.Length == 1)
                            {
                                btn = lst[0] as UCBtnExt;
                                break;
                            }
                        }
                        if (btn != null)
                        {
                            m_selectItem = new List<string>() { btn.Name };
                            btn.RectColor = System.Drawing.Color.FromArgb(255, 77, 59);
                        }
                    }
                }
                finally
                {
                    ControlHelper.FreezeControl(flowLayoutPanel1, false);
                }
            }
        }
    }
}
