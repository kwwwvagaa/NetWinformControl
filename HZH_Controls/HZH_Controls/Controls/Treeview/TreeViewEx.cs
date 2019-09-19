// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="TreeViewEx.cs">
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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Properties;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class TreeViewEx.
    /// Implements the <see cref="System.Windows.Forms.TreeView" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TreeView" />
    public partial class TreeViewEx : TreeView
    {

        /// <summary>
        /// The ws vscroll
        /// </summary>
        private const int WS_VSCROLL = 2097152;

        /// <summary>
        /// The GWL style
        /// </summary>
        private const int GWL_STYLE = -16;

        /// <summary>
        /// The LST tips
        /// </summary>
        private Dictionary<string, string> _lstTips = new Dictionary<string, string>();

        /// <summary>
        /// The tip font
        /// </summary>
        private Font _tipFont = new Font("Arial Unicode MS", 12f);

        /// <summary>
        /// The tip image
        /// </summary>
        private Image _tipImage = Resources.tips;

        /// <summary>
        /// The is show tip
        /// </summary>
        private bool _isShowTip = false;

        /// <summary>
        /// The is show by custom model
        /// </summary>
        private bool _isShowByCustomModel = true;

        /// <summary>
        /// The node height
        /// </summary>
        private int _nodeHeight = 50;

        /// <summary>
        /// The node down pic
        /// </summary>
        private Image _nodeDownPic = Resources.list_add;

        /// <summary>
        /// The node up pic
        /// </summary>
        private Image _nodeUpPic = Resources.list_subtract;

        /// <summary>
        /// The node background color
        /// </summary>
        private Color _nodeBackgroundColor = Color.White;

        /// <summary>
        /// The node fore color
        /// </summary>
        private Color _nodeForeColor = Color.FromArgb(62, 62, 62);

        /// <summary>
        /// The node is show split line
        /// </summary>
        private bool _nodeIsShowSplitLine = false;

        /// <summary>
        /// The node split line color
        /// </summary>
        private Color _nodeSplitLineColor = Color.FromArgb(232, 232, 232);

        /// <summary>
        /// The m node selected color
        /// </summary>
        private Color m_nodeSelectedColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// The m node selected fore color
        /// </summary>
        private Color m_nodeSelectedForeColor = Color.White;

        /// <summary>
        /// The parent node can select
        /// </summary>
        private bool _parentNodeCanSelect = true;

        /// <summary>
        /// The tree font size
        /// </summary>
        private SizeF treeFontSize = SizeF.Empty;

        /// <summary>
        /// The BLN has v bar
        /// </summary>
        private bool blnHasVBar = false;

        /// <summary>
        /// Gets or sets the LST tips.
        /// </summary>
        /// <value>The LST tips.</value>
        public Dictionary<string, string> LstTips
        {
            get
            {
                return this._lstTips;
            }
            set
            {
                this._lstTips = value;
            }
        }

        /// <summary>
        /// Gets or sets the tip font.
        /// </summary>
        /// <value>The tip font.</value>
        [Category("自定义属性"), Description("角标文字字体")]
        public Font TipFont
        {
            get
            {
                return this._tipFont;
            }
            set
            {
                this._tipFont = value;
            }
        }

        /// <summary>
        /// Gets or sets the tip image.
        /// </summary>
        /// <value>The tip image.</value>
        [Category("自定义属性"), Description("是否显示角标")]
        public Image TipImage
        {
            get
            {
                return this._tipImage;
            }
            set
            {
                this._tipImage = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is show tip.
        /// </summary>
        /// <value><c>true</c> if this instance is show tip; otherwise, <c>false</c>.</value>
        [Category("自定义属性"), Description("是否显示角标")]
        public bool IsShowTip
        {
            get
            {
                return this._isShowTip;
            }
            set
            {
                this._isShowTip = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is show by custom model.
        /// </summary>
        /// <value><c>true</c> if this instance is show by custom model; otherwise, <c>false</c>.</value>
        [Category("自定义属性"), Description("使用自定义模式")]
        public bool IsShowByCustomModel
        {
            get
            {
                return this._isShowByCustomModel;
            }
            set
            {
                this._isShowByCustomModel = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the node.
        /// </summary>
        /// <value>The height of the node.</value>
        [Category("自定义属性"), Description("节点高度（IsShowByCustomModel=true时生效）")]
        public int NodeHeight
        {
            get
            {
                return this._nodeHeight;
            }
            set
            {
                this._nodeHeight = value;
                base.ItemHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the node down pic.
        /// </summary>
        /// <value>The node down pic.</value>
        [Category("自定义属性"), Description("下翻图标（IsShowByCustomModel=true时生效）")]
        public Image NodeDownPic
        {
            get
            {
                return this._nodeDownPic;
            }
            set
            {
                this._nodeDownPic = value;
            }
        }

        /// <summary>
        /// Gets or sets the node up pic.
        /// </summary>
        /// <value>The node up pic.</value>
        [Category("自定义属性"), Description("上翻图标（IsShowByCustomModel=true时生效）")]
        public Image NodeUpPic
        {
            get
            {
                return this._nodeUpPic;
            }
            set
            {
                this._nodeUpPic = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the node background.
        /// </summary>
        /// <value>The color of the node background.</value>
        [Category("自定义属性"), Description("节点背景颜色（IsShowByCustomModel=true时生效）")]
        public Color NodeBackgroundColor
        {
            get
            {
                return this._nodeBackgroundColor;
            }
            set
            {
                this._nodeBackgroundColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the node fore.
        /// </summary>
        /// <value>The color of the node fore.</value>
        [Category("自定义属性"), Description("节点字体颜色（IsShowByCustomModel=true时生效）")]
        public Color NodeForeColor
        {
            get
            {
                return this._nodeForeColor;
            }
            set
            {
                this._nodeForeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [node is show split line].
        /// </summary>
        /// <value><c>true</c> if [node is show split line]; otherwise, <c>false</c>.</value>
        [Category("自定义属性"), Description("节点是否显示分割线（IsShowByCustomModel=true时生效）")]
        public bool NodeIsShowSplitLine
        {
            get
            {
                return this._nodeIsShowSplitLine;
            }
            set
            {
                this._nodeIsShowSplitLine = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the node split line.
        /// </summary>
        /// <value>The color of the node split line.</value>
        [Category("自定义属性"), Description("节点分割线颜色（IsShowByCustomModel=true时生效）")]
        public Color NodeSplitLineColor
        {
            get
            {
                return this._nodeSplitLineColor;
            }
            set
            {
                this._nodeSplitLineColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the node selected.
        /// </summary>
        /// <value>The color of the node selected.</value>
        [Category("自定义属性"), Description("选中节点背景颜色（IsShowByCustomModel=true时生效）")]
        public Color NodeSelectedColor
        {
            get
            {
                return this.m_nodeSelectedColor;
            }
            set
            {
                this.m_nodeSelectedColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the node selected fore.
        /// </summary>
        /// <value>The color of the node selected fore.</value>
        [Category("自定义属性"), Description("选中节点字体颜色（IsShowByCustomModel=true时生效）")]
        public Color NodeSelectedForeColor
        {
            get
            {
                return this.m_nodeSelectedForeColor;
            }
            set
            {
                this.m_nodeSelectedForeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [parent node can select].
        /// </summary>
        /// <value><c>true</c> if [parent node can select]; otherwise, <c>false</c>.</value>
        [Category("自定义属性"), Description("父节点是否可选中")]
        public bool ParentNodeCanSelect
        {
            get
            {
                return this._parentNodeCanSelect;
            }
            set
            {
                this._parentNodeCanSelect = value;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeViewEx" /> class.
        /// </summary>
        public TreeViewEx()
        {
            base.HideSelection = false;
            base.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            base.DrawNode += new DrawTreeNodeEventHandler(this.treeview_DrawNode);
            base.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.TreeViewEx_NodeMouseClick);
            base.SizeChanged += new EventHandler(this.TreeViewEx_SizeChanged);
            base.AfterSelect += new TreeViewEventHandler(this.TreeViewEx_AfterSelect);
            base.FullRowSelect = true;
            base.ShowLines = false;
            base.ShowPlusMinus = false;
            base.ShowRootLines = false;
            this.BackColor = Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DoubleBuffered = true;
        }
        /// <summary>
        /// 重写 <see cref="M:System.Windows.Forms.Control.WndProc(System.Windows.Forms.Message@)" />。
        /// </summary>
        /// <param name="m">要处理的 Windows<see cref="T:System.Windows.Forms.Message" />。</param>
        protected override void WndProc(ref Message m)
        {

            if (m.Msg == 0x0014) // 禁掉清除背景消息WM_ERASEBKGND

                return;

            base.WndProc(ref m);

        }
        /// <summary>
        /// Handles the AfterSelect event of the TreeViewEx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs" /> instance containing the event data.</param>
        private void TreeViewEx_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node != null)
                {
                    if (!this._parentNodeCanSelect)
                    {
                        if (e.Node.Nodes.Count > 0)
                        {
                            e.Node.Expand();
                            base.SelectedNode = e.Node.Nodes[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the TreeViewEx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void TreeViewEx_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        /// <summary>
        /// Handles the NodeMouseClick event of the TreeViewEx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs" /> instance containing the event data.</param>
        private void TreeViewEx_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node != null)
                {
                    if (e.Node.Nodes.Count > 0)
                    {
                        if (e.Node.IsExpanded)
                        {
                            e.Node.Collapse();
                        }
                        else
                        {
                            e.Node.Expand();
                        }
                    }
                    if (base.SelectedNode != null)
                    {
                        if (base.SelectedNode == e.Node && e.Node.IsExpanded)
                        {
                            if (!this._parentNodeCanSelect)
                            {
                                if (e.Node.Nodes.Count > 0)
                                {
                                    base.SelectedNode = e.Node.Nodes[0];
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the DrawNode event of the treeview control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DrawTreeNodeEventArgs" /> instance containing the event data.</param>
        private void treeview_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            try
            {

                if (e.Node == null || !this._isShowByCustomModel || (e.Node.Bounds.Width <= 0 && e.Node.Bounds.Height <= 0 && e.Node.Bounds.X <= 0 && e.Node.Bounds.Y <= 0))
                {
                    e.DrawDefault = true;
                }
                else
                {
                    e.Graphics.SetGDIHigh();
                    if (base.Nodes.IndexOf(e.Node) == 0)
                    {
                        this.blnHasVBar = this.IsVerticalScrollBarVisible();
                    }
                    Font font = e.Node.NodeFont;
                    if (font == null)
                    {
                        font = ((TreeView)sender).Font;
                    }
                    if (this.treeFontSize == SizeF.Empty)
                    {
                        this.treeFontSize = this.GetFontSize(font, e.Graphics);
                    }
                    bool flag = false;
                    int intLeft = 0;
                    if (CheckBoxes)
                    {
                        intLeft = 20;
                    }
                    int num = 0;
                    if (base.ImageList != null && base.ImageList.Images.Count > 0 && e.Node.ImageIndex >= 0 && e.Node.ImageIndex < base.ImageList.Images.Count)
                    {
                        flag = true;
                        num = (e.Bounds.Height - base.ImageList.ImageSize.Height) / 2;
                        intLeft += base.ImageList.ImageSize.Width;
                    }

                    intLeft += e.Node.Level * Indent;

                    if ((e.State == TreeNodeStates.Selected || e.State == TreeNodeStates.Focused || e.State == (TreeNodeStates.Focused | TreeNodeStates.Selected)) && (this._parentNodeCanSelect || e.Node.Nodes.Count <= 0))
                    {
                        e.Graphics.FillRectangle(new SolidBrush(this.m_nodeSelectedColor), new Rectangle(new Point(0, e.Node.Bounds.Y), new Size(base.Width, e.Node.Bounds.Height)));
                        e.Graphics.DrawString(e.Node.Text, font, new SolidBrush(this.m_nodeSelectedForeColor), (float)e.Bounds.X + intLeft, (float)e.Bounds.Y + ((float)this._nodeHeight - this.treeFontSize.Height) / 2f);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(this._nodeBackgroundColor), new Rectangle(new Point(0, e.Node.Bounds.Y), new Size(base.Width, e.Node.Bounds.Height)));
                        e.Graphics.DrawString(e.Node.Text, font, new SolidBrush(this._nodeForeColor), (float)e.Bounds.X + intLeft, (float)e.Bounds.Y + ((float)this._nodeHeight - this.treeFontSize.Height) / 2f);
                    }
                    if (CheckBoxes)
                    {
                        Rectangle rectCheck = new Rectangle(e.Bounds.X + 3 + e.Node.Level * Indent, e.Bounds.Y + (e.Bounds.Height - 16) / 2, 16, 16);
                        GraphicsPath pathCheck = rectCheck.CreateRoundedRectanglePath(3);
                        e.Graphics.FillPath(new SolidBrush(Color.FromArgb(247, 247, 247)), pathCheck);
                        if (e.Node.Checked)
                        {                           
                            e.Graphics.DrawLines(new Pen(new SolidBrush(m_nodeSelectedColor),2), new Point[] 
                            { 
                                new Point(rectCheck.Left+2,rectCheck.Top+8),
                                new Point(rectCheck.Left+6,rectCheck.Top+12),
                                new Point(rectCheck.Right-4,rectCheck.Top+4)
                            });
                        }

                        e.Graphics.DrawPath(new Pen(new SolidBrush(Color.FromArgb(200, 200, 200))), pathCheck);                       
                    }
                    if (flag)
                    {
                        int num2 = e.Bounds.X - num - base.ImageList.ImageSize.Width;
                        if (num2 < 0)
                        {
                            num2 = 3;
                        }
                        e.Graphics.DrawImage(base.ImageList.Images[e.Node.ImageIndex], new Rectangle(new Point(num2 + intLeft - base.ImageList.ImageSize.Width, e.Bounds.Y + num), base.ImageList.ImageSize));
                    }
                    if (this._nodeIsShowSplitLine)
                    {
                        e.Graphics.DrawLine(new Pen(this._nodeSplitLineColor, 1f), new Point(0, e.Bounds.Y + this._nodeHeight - 1), new Point(base.Width, e.Bounds.Y + this._nodeHeight - 1));
                    }
                    bool flag2 = false;
                    if (e.Node.Nodes.Count > 0)
                    {
                        if (e.Node.IsExpanded && this._nodeUpPic != null)
                        {
                            e.Graphics.DrawImage(this._nodeUpPic, new Rectangle(base.Width - (this.blnHasVBar ? 50 : 30), e.Bounds.Y + (this._nodeHeight - 20) / 2, 20, 20));
                        }
                        else if (this._nodeDownPic != null)
                        {
                            e.Graphics.DrawImage(this._nodeDownPic, new Rectangle(base.Width - (this.blnHasVBar ? 50 : 30), e.Bounds.Y + (this._nodeHeight - 20) / 2, 20, 20));
                        }
                        flag2 = true;
                    }
                    if (this._isShowTip && this._lstTips.ContainsKey(e.Node.Name) && !string.IsNullOrWhiteSpace(this._lstTips[e.Node.Name]))
                    {
                        int num3 = base.Width - (this.blnHasVBar ? 50 : 30) - (flag2 ? 20 : 0);
                        int num4 = e.Bounds.Y + (this._nodeHeight - 20) / 2;
                        e.Graphics.DrawImage(this._tipImage, new Rectangle(num3, num4, 20, 20));
                        SizeF sizeF = e.Graphics.MeasureString(this._lstTips[e.Node.Name], this._tipFont, 100, StringFormat.GenericTypographic);
                        e.Graphics.DrawString(this._lstTips[e.Node.Name], this._tipFont, new SolidBrush(Color.White), (float)(num3 + 10) - sizeF.Width / 2f - 3f, (float)(num4 + 10) - sizeF.Height / 2f);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the size of the font.
        /// </summary>
        /// <param name="font">The font.</param>
        /// <param name="g">The g.</param>
        /// <returns>SizeF.</returns>
        private SizeF GetFontSize(Font font, Graphics g = null)
        {
            SizeF result;
            try
            {
                bool flag = false;
                if (g == null)
                {
                    g = base.CreateGraphics();
                    flag = true;
                }
                SizeF sizeF = g.MeasureString("a", font, 100, StringFormat.GenericTypographic);
                if (flag)
                {
                    g.Dispose();
                }
                result = sizeF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Gets the window long.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="nIndex">Index of the n.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        /// <summary>
        /// Determines whether [is vertical scroll bar visible].
        /// </summary>
        /// <returns><c>true</c> if [is vertical scroll bar visible]; otherwise, <c>false</c>.</returns>
        private bool IsVerticalScrollBarVisible()
        {
            return base.IsHandleCreated && (TreeViewEx.GetWindowLong(base.Handle, -16) & 2097152) != 0;
        }
    }
}
