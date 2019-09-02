// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：TreeViewEx.cs
// 创建日期：2019-08-15 16:00:55
// 功能描述：TreeView
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Properties;

namespace HZH_Controls.Controls
{
    public partial class TreeViewEx : TreeView
    {

        private const int WS_VSCROLL = 2097152;

        private const int GWL_STYLE = -16;

        private Dictionary<string, string> _lstTips = new Dictionary<string, string>();

        private Font _tipFont = new Font("Arial Unicode MS", 12f);

        private Image _tipImage = Resources.tips;

        private bool _isShowTip = false;

        private bool _isShowByCustomModel = true;

        private int _nodeHeight = 50;

        private Image _nodeDownPic = Resources.list_add;

        private Image _nodeUpPic = Resources.list_subtract;

        private Color _nodeBackgroundColor = Color.White;

        private Color _nodeForeColor = Color.FromArgb(62, 62, 62);

        private bool _nodeIsShowSplitLine = false;

        private Color _nodeSplitLineColor = Color.FromArgb(232, 232, 232);

        private Color m_nodeSelectedColor = Color.FromArgb(255, 77, 59);

        private Color m_nodeSelectedForeColor = Color.White;

        private bool _parentNodeCanSelect = true;

        private SizeF treeFontSize = SizeF.Empty;

        private bool blnHasVBar = false;

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
        protected override void WndProc(ref Message m)
        {

            if (m.Msg == 0x0014) // 禁掉清除背景消息WM_ERASEBKGND

                return;

            base.WndProc(ref m);

        }
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

        private void TreeViewEx_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

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
                    int num = 0;
                    if (base.ImageList != null && base.ImageList.Images.Count > 0 && e.Node.ImageIndex >= 0 && e.Node.ImageIndex < base.ImageList.Images.Count)
                    {
                        flag = true;
                        num = (e.Bounds.Height - base.ImageList.ImageSize.Height) / 2;
                    }
                    if ((e.State == TreeNodeStates.Selected || e.State == TreeNodeStates.Focused || e.State == (TreeNodeStates.Focused | TreeNodeStates.Selected)) && (this._parentNodeCanSelect || e.Node.Nodes.Count <= 0))
                    {
                        e.Graphics.FillRectangle(new SolidBrush(this.m_nodeSelectedColor), new Rectangle(new Point(0, e.Node.Bounds.Y), new Size(base.Width, e.Node.Bounds.Height)));
                        e.Graphics.DrawString(e.Node.Text, font, new SolidBrush(this.m_nodeSelectedForeColor), (float)e.Bounds.X, (float)e.Bounds.Y + ((float)this._nodeHeight - this.treeFontSize.Height) / 2f);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(this._nodeBackgroundColor), new Rectangle(new Point(0, e.Node.Bounds.Y), new Size(base.Width, e.Node.Bounds.Height)));
                        e.Graphics.DrawString(e.Node.Text, font, new SolidBrush(this._nodeForeColor), (float)e.Bounds.X, (float)e.Bounds.Y + ((float)this._nodeHeight - this.treeFontSize.Height) / 2f);
                    }
                    if (flag)
                    {
                        int num2 = e.Bounds.X - num - base.ImageList.ImageSize.Width;
                        if (num2 < 0)
                        {
                            num2 = 3;
                        }
                        e.Graphics.DrawImage(base.ImageList.Images[e.Node.ImageIndex], new Rectangle(new Point(num2, e.Bounds.Y + num), base.ImageList.ImageSize));
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

        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        private bool IsVerticalScrollBarVisible()
        {
            return base.IsHandleCreated && (TreeViewEx.GetWindowLong(base.Handle, -16) & 2097152) != 0;
        }
    }
}
