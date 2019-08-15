// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCPagerControl2.cs
// 创建日期：2019-08-15 16:00:37
// 功能描述：PageControl
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls.List
{
    [ToolboxItem(true)]
    public partial class UCPagerControl2 : UCPagerControlBase
    {
        public UCPagerControl2()
        {
            InitializeComponent();
            txtPage.txtInput.KeyDown += txtInput_KeyDown;
        }

        void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnToPage_BtnClick(null, null);
                txtPage.InputText = "";
            }
        }

        public override event PageControlEventHandler ShowSourceChanged;

        private List<object> m_dataSource;
        public override List<object> DataSource
        {
            get
            {
                return m_dataSource;
            }
            set
            {
                m_dataSource = value;
                if (m_dataSource == null)
                    m_dataSource = new List<object>();
                ResetPageCount();
            }
        }
        private int m_intPageSize = 0;
        public override int PageSize
        {
            get
            {
                return m_intPageSize;
            }
            set
            {
                m_intPageSize = value;
                ResetPageCount();
            }
        }

        public override void FirstPage()
        {
            PageIndex = 1;
            StartIndex = (PageIndex - 1) * PageSize;
            ReloadPage();
            var s = GetCurrentSource();
            if (ShowSourceChanged != null)
            {
                ShowSourceChanged(s);
            }
        }

        public override void PreviousPage()
        {
            PageIndex--;
            StartIndex = (PageIndex - 1) * PageSize;
            ReloadPage();
            var s = GetCurrentSource();
            if (ShowSourceChanged != null)
            {
                ShowSourceChanged(s);
            }
        }

        public override void NextPage()
        {
            PageIndex++;
            StartIndex = (PageIndex - 1) * PageSize;
            ReloadPage();
            var s = GetCurrentSource();
            if (ShowSourceChanged != null)
            {
                ShowSourceChanged(s);
            }
        }

        public override void EndPage()
        {
            PageIndex = PageCount;
            StartIndex = (PageIndex - 1) * PageSize;
            ReloadPage();
            var s = GetCurrentSource();
            if (ShowSourceChanged != null)
            {
                ShowSourceChanged(s);
            }
        }

        private void ResetPageCount()
        {
            if (PageSize > 0)
            {
                PageCount = m_dataSource.Count / m_intPageSize + (m_dataSource.Count % m_intPageSize > 0 ? 1 : 0);
            }
            txtPage.MaxValue = PageCount;
            txtPage.MinValue = 1;
            ReloadPage();
        }

        private void ReloadPage()
        {
            try
            {
                ControlHelper.FreezeControl(tableLayoutPanel1, true);
                List<int> lst = new List<int>();
                if (PageCount > 0)
                {
                    if (PageCount <= 7)
                    {
                        for (int i = 0; i < PageCount; i++)
                        {
                            lst.Add(i + 1);
                        }
                    }
                    else
                    {
                        int start = PageIndex; //开始按钮数字
                        int end = 1; //结束按钮数字
                        int pageCount = PageCount; //总页数
                        int offset = 3; //偏移量

                        start -= offset;//计算左偏移量
                        start = start < 1 ? 1 : start;//限定最小页码
                        end = start + 7 - 1;//根据偏移计算结束按钮
                        end = end > pageCount ? pageCount : end;//限定最大页码
                        start = end - 7 + 1;//根据偏移计算开始页码
                        start = start < 1 ? 1 : start;//限定最小页码  
                        for (int i = start; i <= end; i++)
                        {
                            lst.Add(i);
                        }
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    UCBtnExt c = (UCBtnExt)this.tableLayoutPanel1.Controls.Find("p" + (i + 1), false)[0];
                    if (i >= lst.Count)
                    {
                        c.Visible = false;
                    }
                    else
                    {
                        c.BtnText = lst[i].ToString();
                        c.Visible = true;
                        if (lst[i] == PageIndex)
                        {
                            c.RectColor = Color.FromArgb(255, 77, 59);
                        }
                        else
                        {
                            c.RectColor = Color.FromArgb(223, 223, 223);
                        }
                    }
                }
                ShowBtn(PageIndex > 1, PageIndex < PageCount);
            }
            finally
            {
                ControlHelper.FreezeControl(tableLayoutPanel1, false);
            }
        }

        private void page_BtnClick(object sender, EventArgs e)
        {
            PageIndex = (sender as UCBtnExt).BtnText.ToInt();
            StartIndex = (PageIndex - 1) * PageSize;
            ReloadPage();
            var s = GetCurrentSource();

            if (ShowSourceChanged != null)
            {
                ShowSourceChanged(s);
            }
        }

        protected override void ShowBtn(bool blnLeftBtn, bool blnRightBtn)
        {
            btnFirst.Enabled = btnPrevious.Enabled = blnLeftBtn;
            btnNext.Enabled = btnEnd.Enabled = blnRightBtn;
        }

        private void btnFirst_BtnClick(object sender, EventArgs e)
        {
            FirstPage();
        }

        private void btnPrevious_BtnClick(object sender, EventArgs e)
        {
            PreviousPage();
        }

        private void btnNext_BtnClick(object sender, EventArgs e)
        {
            NextPage();
        }

        private void btnEnd_BtnClick(object sender, EventArgs e)
        {
            EndPage();
        }

        private void btnToPage_BtnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPage.InputText))
            {
                PageIndex = txtPage.InputText.ToInt();
                StartIndex = (PageIndex - 1) * PageSize;
                ReloadPage();
                var s = GetCurrentSource();
                if (ShowSourceChanged != null)
                {
                    ShowSourceChanged(s);
                }
            }
        }

    }
}
