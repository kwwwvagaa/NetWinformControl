// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-10-10
//
// ***********************************************************************
// <copyright file="UCTransfer.cs">
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

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCTransfer.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DefaultEvent("Transfered")]
    public partial class UCTransfer : UserControl
    {
        /// <summary>
        /// 移动数据事件
        /// </summary>
        [Description("移动数据事件"), Category("自定义")]
        public event TransferEventHandler Transfered;

        /// <summary>
        /// The left columns
        /// </summary>
        private DataGridViewColumnEntity[] leftColumns;

        /// <summary>
        /// Gets or sets the left columns.
        /// </summary>
        /// <value>The left columns.</value>
        [Description("左侧列表列"), Category("自定义")]
        public DataGridViewColumnEntity[] LeftColumns
        {
            get { return leftColumns; }
            set
            {
                leftColumns = value;
                this.dgvLeft.Columns = leftColumns.ToList();
            }
        }

        /// <summary>
        /// The right columns
        /// </summary>
        private DataGridViewColumnEntity[] rightColumns;

        /// <summary>
        /// Gets or sets the right columns.
        /// </summary>
        /// <value>The right columns.</value>
        [Description("右侧列表列"), Category("自定义")]
        public DataGridViewColumnEntity[] RightColumns
        {
            get { return rightColumns; }
            set
            {
                rightColumns = value;
                this.dgvRight.Columns = rightColumns.ToList();
            }
        }

        /// <summary>
        /// The left data source
        /// </summary>
        private object[] leftDataSource;
        /// <summary>
        /// 左右列表必须设置相同类型的数据源列表，如果为空必须为长度为0的数组
        /// </summary>
        /// <value>The left data source.</value>
        [Description("左侧列表数据源"), Category("自定义"), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public object[] LeftDataSource
        {
            get { return leftDataSource; }
            set
            {
                leftDataSource = value;
                dgvLeft.DataSource = value;
            }
        }

        /// <summary>
        /// The right data source
        /// </summary>
        private object[] rightDataSource;
        /// <summary>
        /// 左右列表必须设置相同类型的数据源列表，如果为空必须为长度为0的数组
        /// </summary>
        /// <value>The left data source.</value>
        [Description("右侧列表数据源"), Category("自定义"), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public object[] RightDataSource
        {
            get { return rightDataSource; }
            set
            {
                rightDataSource = value;
                dgvRight.DataSource = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCTransfer"/> class.
        /// </summary>
        public UCTransfer()
        {
            InitializeComponent();
            LeftColumns = new DataGridViewColumnEntity[0];
            RightColumns = new DataGridViewColumnEntity[0];
            LeftDataSource = new object[0];
            RightDataSource = new object[0];
        }

        /// <summary>
        /// Handles the BtnClick event of the btnRight control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.Exception">
        /// 左右数据源列表不能为空
        /// or
        /// 左右数据源列表类型不一致，无法进行操作
        /// </exception>
        private void btnRight_BtnClick(object sender, EventArgs e)
        {
            if (LeftDataSource == null || RightDataSource == null)
            {
                throw new Exception("左右数据源列表不能为空");
            }
            if (LeftDataSource.GetType() != RightDataSource.GetType())
            {
                throw new Exception("左右数据源列表类型不一致，无法进行操作");
            }
            if (dgvLeft.SelectRows == null || dgvLeft.SelectRows.Count <= 0)
                return;
            List<object> lst = new List<object>();
            dgvLeft.SelectRows.ForEach(p =>
            {
                lst.Add(p.DataSource);
                p.IsChecked = false;
            });
            var lstRight = RightDataSource.ToList();
            lstRight.AddRange(lst);
            var lstLeft = LeftDataSource.ToList();
            lstLeft.RemoveAll(p => lst.Contains(p));
            RightDataSource = lstRight.ToArray();
            LeftDataSource = lstLeft.ToArray();
            if (Transfered != null)
            {
                Transfered(this, new TransferEventArgs() { TransferDataSource = lst.ToArray(), ToRightOrLeft = true });
            }
        }

        /// <summary>
        /// Handles the BtnClick event of the btnLeft control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.Exception">
        /// 左右数据源列表不能为空
        /// or
        /// 左右数据源列表类型不一致，无法进行操作
        /// </exception>
        private void btnLeft_BtnClick(object sender, EventArgs e)
        {
            if (LeftDataSource == null || RightDataSource == null)
            {
                throw new Exception("左右数据源列表不能为空");
            }
            if (LeftDataSource.GetType() != RightDataSource.GetType())
            {
                throw new Exception("左右数据源列表类型不一致，无法进行操作");
            }
            if (dgvRight.SelectRows == null || dgvRight.SelectRows.Count <= 0)
                return;
            List<object> lst = new List<object>();
            dgvRight.SelectRows.ForEach(p =>
            {
                lst.Add(p.DataSource);
                p.IsChecked = false;
            });
            var lstLeft = LeftDataSource.ToList();
            lstLeft.AddRange(lst);
            var lstRight = RightDataSource.ToList();
            lstRight.RemoveAll(p => lst.Contains(p));
            RightDataSource = lstRight.ToArray();
            LeftDataSource = lstLeft.ToArray();
            if (Transfered != null)
            {
                Transfered(this, new TransferEventArgs() { TransferDataSource = lst.ToArray(), ToRightOrLeft = false });
            }
        }
    }
}
