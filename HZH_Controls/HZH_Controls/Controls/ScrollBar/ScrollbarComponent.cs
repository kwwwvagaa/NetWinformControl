using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    [ProvideProperty("UserCustomScrollbar", typeof(Control))]
    public class ScrollbarComponent : Component, IExtenderProvider
    {
        public ScrollbarComponent()
        {

        }

        public ScrollbarComponent(IContainer container)
        {
            container.Add(this);
        }

        Dictionary<Control, bool> m_controlCache = new Dictionary<Control, bool>();
        public bool CanExtend(object extendee)
        {
            if (extendee is ScrollableControl)
            {
                ScrollableControl control = (ScrollableControl)extendee;
                if (control.AutoScroll == true)
                {
                    return true;
                }
            }
            else if (extendee is TreeView)
            {
                TreeView control = (TreeView)extendee;
                if (control.Scrollable)
                {
                    return true;
                }
            }
            else if (extendee is TextBox)
            {
                TextBox control = (TextBox)extendee;
                if (control.Multiline && control.ScrollBars != ScrollBars.None)
                {
                    return true;
                }
            }
            else if (extendee is RichTextBox)
            {
                return true;
            }
            else if (extendee is ListBox)
            {
                return true;
            }
            //else if (extendee is ListView)
            //{
            //    return true;
            //}
            else if (extendee is DataGridView)
            {
                return true;
            }
            return false;
        }

        [Browsable(true), Category("自定义属性"), Description("是否使用自定义滚动条"), DisplayName("UserCustomScrollbar"), Localizable(true)]
        public bool GetUserCustomScrollbar(Control control)
        {
            if (m_controlCache.ContainsKey(control))
                return m_controlCache[control];
            return true;
        }

        public void SetUserCustomScrollbar(Control control, bool blnUserCustomScrollbar)
        {
            m_controlCache[control] = blnUserCustomScrollbar;
            if (!blnUserCustomScrollbar)
                return;

            if (control is TreeView)
            {
                TreeView tv = (TreeView)control;
                //tv.MouseWheel += tv_MouseWheel;
                //tv.AfterSelect += tv_AfterSelect;
                tv.AfterExpand += tv_AfterExpand;
                tv.AfterCollapse += tv_AfterCollapse;
            }
            else if (control is TextBox)
            {
                TextBox txt = (TextBox)control;
                //txt.MouseWheel += txt_MouseWheel;
                txt.TextChanged += txt_TextChanged;
                txt.KeyDown += txt_KeyDown;
            }
            else if (control is RichTextBox)
            {
                RichTextBox txt = (RichTextBox)control;
                //txt.MouseWheel += txt_MouseWheel;
                txt.TextChanged += txt_TextChanged;
                txt.KeyDown += txt_KeyDown;
            }
            else if (control is ListBox)
            {
                ListBox lb = (ListBox)control;
                lb.DataSourceChanged += Lb_DataSourceChanged;
                lb.SelectedIndexChanged += Lb_SelectedIndexChanged;                
            }
            //else if (control is ListView)
            //{
            //    ListView lv = (ListView)control;

            //}
            else if (control is DataGridView)
            {
                DataGridView dgv = (DataGridView)control;
                dgv.DataSourceChanged += dgv_DataSourceChanged;
                dgv.RowsAdded += dgv_RowsAdded;
                dgv.RowsRemoved += dgv_RowsRemoved;
                dgv.Scroll += dgv_Scroll;
            }

            control.VisibleChanged += control_VisibleChanged;
            control.SizeChanged += control_SizeChanged;
            control.LocationChanged += control_LocationChanged;
            control.Disposed += control_Disposed;
            control.MouseWheel += Control_MouseWheel;
            control_SizeChanged(control, null);
        }

        void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue == e.OldValue)
                return;
            DataGridView dgv = (DataGridView)sender;
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                if (m_lstHCache.ContainsKey(dgv))
                {
                    m_lstHCache[dgv].Value = e.NewValue;
                }
            }
            else if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                if (m_lstVCache.ContainsKey(dgv))
                {
                    m_lstVCache[dgv].Value = e.NewValue;
                }
            }
        }

        void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Control control = sender as Control;
            control_SizeChanged(control, null);
        }

        void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Control control = sender as Control;
            control_SizeChanged(control, null);
        }

        void dgv_DataSourceChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            control_SizeChanged(control, null);
        }

        private void Lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control c = sender as Control;
            SetVMaxNum(c);
        }

        private void Lb_DataSourceChanged(object sender, EventArgs e)
        {
            Control c = sender as Control;
            control_SizeChanged(c, null);
        }

        private void Control_MouseWheel(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            if (m_lstVCache.ContainsKey(c))
            {
                if (e.Delta > 5)
                {
                    ControlHelper.ScrollUp(c.Handle);
                }
                else if (e.Delta < -5)
                {
                    ControlHelper.ScrollDown(c.Handle);
                }

                SetVMaxNum(c);
            }
            else if (m_lstHCache.ContainsKey(c))
            {
                if (e.Delta > 5)
                {
                    ControlHelper.ScrollLeft(c.Handle);
                }
                else if (e.Delta < -5)
                {
                    ControlHelper.ScrollRight(c.Handle);
                }

                SetHMaxNum(c);
            }
        }

        void control_Disposed(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (m_lstVCache.ContainsKey(control) && m_lstVCache[control].Parent != null)
            {
                m_lstVCache[control].Parent.Controls.Remove(m_lstVCache[control]);
                m_lstVCache.Remove(control);
            }
        }

        void control_LocationChanged(object sender, EventArgs e)
        {
            ResetScrollLocation(sender);
        }

        void control_SizeChanged(object sender, EventArgs e)
        {
            if (ControlHelper.IsDesignMode())
            {
                return;
            }
            else
            {
                var control = sender as Control;

                bool blnHasVScrollbar = control.IsHandleCreated && (ControlHelper.GetWindowLong(control.Handle, STYLE) & VSCROLL) != 0;
                bool blnHasHScrollbar = control.IsHandleCreated && (ControlHelper.GetWindowLong(control.Handle, STYLE) & HSCROLL) != 0;
                if (control is TextBox)
                {
                    var txt = (TextBox)control;
                    if (txt.ScrollBars == ScrollBars.Both)
                    {
                        blnHasVScrollbar = true;
                        blnHasHScrollbar = true;
                    }
                    else if (txt.ScrollBars == ScrollBars.Vertical)
                    {
                        blnHasVScrollbar = true;
                        blnHasHScrollbar = false;
                    }
                    else if (txt.ScrollBars == ScrollBars.Horizontal)
                    {
                        blnHasVScrollbar = false;
                        blnHasHScrollbar = true;
                    }
                    else
                    {
                        blnHasVScrollbar = false;
                        blnHasHScrollbar = false;
                    }
                }
                else if (control is DataGridView)
                {
                    var dgv = (DataGridView)control;
                    if (dgv.ScrollBars == ScrollBars.Both || dgv.ScrollBars == ScrollBars.Vertical)
                    {
                        int _height = dgv.RowTemplate.Height * dgv.Rows.Count;
                        if (dgv.ColumnHeadersVisible)
                        {
                            _height += dgv.ColumnHeadersHeight;
                        }
                        blnHasVScrollbar = _height > dgv.Height;
                    }
                    if (dgv.ScrollBars == ScrollBars.Both || dgv.ScrollBars == ScrollBars.Horizontal)
                    {
                        int _width = 0;
                        foreach (DataGridViewColumn com in dgv.Columns)
                        {
                            _width += com.Width;
                        }
                        if (dgv.RowHeadersVisible)
                        {
                            _width += dgv.RowHeadersWidth;
                        }
                        blnHasHScrollbar = _width > dgv.Width;
                    }
                }
                else if (control is ListView)
                {
                    if (!((ListView)control).Scrollable)
                    {
                        blnHasVScrollbar = false;
                        blnHasHScrollbar = false;
                    }
                }
                if (blnHasVScrollbar)
                {
                    if (!m_lstVCache.ContainsKey(control))
                    {
                        if (control.Parent != null)
                        {
                            UCVScrollbar barV = new UCVScrollbar();
                            barV.SmallChange = 5;
                            barV.Width = SystemInformation.VerticalScrollBarWidth + 1;
                            barV.Scroll += barV_Scroll;
                            m_lstVCache[control] = barV;
                            if (blnHasHScrollbar)
                            {
                                barV.Height = control.Height - barV.Width;
                            }
                            else
                            {
                                barV.Height = control.Height;
                            }
                            SetVMaxNum(control);
                            barV.Location = new System.Drawing.Point(control.Right - barV.Width, control.Top);
                            control.Parent.Controls.Add(barV);
                            int intControlIndex = control.Parent.Controls.GetChildIndex(control);
                            control.Parent.Controls.SetChildIndex(barV, intControlIndex);
                        }
                    }
                    else
                    {
                        if (blnHasHScrollbar)
                        {
                            m_lstVCache[control].Height = control.Height - m_lstVCache[control].Width;
                        }
                        else
                        {
                            m_lstVCache[control].Height = control.Height;
                        }
                        SetVMaxNum(control);
                    }
                }
                else
                {
                    if (m_lstVCache.ContainsKey(control) && m_lstVCache[control].Parent != null)
                    {
                        m_lstVCache[control].Visible = false;
                    }
                }

                if (blnHasHScrollbar)
                {
                    if (!m_lstHCache.ContainsKey(control))
                    {
                        if (control.Parent != null)
                        {
                            UCHScrollbar barH = new UCHScrollbar();
                            barH.Height = SystemInformation.HorizontalScrollBarHeight + 1;
                            barH.SmallChange = 5;

                            barH.Scroll += barH_Scroll;
                            m_lstHCache[control] = barH;
                            if (blnHasHScrollbar)
                            {
                                barH.Width = control.Width - barH.Height;
                            }
                            else
                            {
                                barH.Width = control.Width;
                            }
                            SetHMaxNum(control);
                            barH.Location = new System.Drawing.Point(control.Left, control.Bottom - barH.Height);
                            control.Parent.Controls.Add(barH);
                            int intControlIndex = control.Parent.Controls.GetChildIndex(control);
                            control.Parent.Controls.SetChildIndex(barH, intControlIndex);
                        }
                    }
                    else
                    {
                        if (blnHasHScrollbar)
                        {
                            m_lstHCache[control].Width = control.Width - m_lstHCache[control].Height;
                        }
                        else
                        {
                            m_lstHCache[control].Width = control.Width;
                        }
                        SetHMaxNum(control);
                    }
                }
                else
                {
                    if (m_lstHCache.ContainsKey(control))
                    {
                        if (m_lstHCache[control].Visible && m_lstHCache[control].Parent != null)
                        {
                            m_lstHCache[control].Visible = false;
                        }
                    }
                }
            }
            ResetScrollLocation(sender);
        }


        private void SetVMaxNum(Control control)
        {
            if (!m_lstVCache.ContainsKey(control))
                return;
            var intoV = ControlHelper.GetVScrollBarInfo(control.Handle);
            UCVScrollbar barV = m_lstVCache[control];
            if (control is ScrollableControl)
            {
                barV.Maximum = intoV.ScrollMax;
                barV.Visible = intoV.ScrollMax > 0 && intoV.nMax > 0 && intoV.nPage > 0;
                barV.Value = intoV.nPos;
                barV.BringToFront();
                // barV.Maximum = (control as ScrollableControl).VerticalScroll.Maximum;
                // barV.Value = (control as ScrollableControl).VerticalScroll.Value;
            }
            else if (control is TreeView)
            {
                var tv = control as TreeView;
                barV.Maximum = intoV.ScrollMax * tv.ItemHeight;
                barV.Visible = intoV.ScrollMax > 0 && intoV.nMax > 0 && intoV.nPage > 0;
                barV.Value = intoV.nPos * tv.ItemHeight;
                barV.BringToFront();

                //barV.Maximum = GetTreeNodeMaxY(control as TreeView) - control.Height;
                //barV.Value = (control as TreeView).AutoScrollOffset.Y;
            }
            else if (control is TextBox)
            {
                TextBox txt = (TextBox)control;
                barV.Maximum = intoV.ScrollMax * txt.PreferredHeight;
                if (txt.ScrollBars == ScrollBars.Both || txt.ScrollBars == ScrollBars.Vertical)
                {
                    barV.Visible = true;
                }
                else
                {
                    barV.Visible = false;
                }
                barV.Value = intoV.nPos * txt.PreferredHeight;
                barV.BringToFront();
            }
            else if (control is RichTextBox)
            {
                bool blnHasVScrollbar = control.IsHandleCreated && (ControlHelper.GetWindowLong(control.Handle, STYLE) & VSCROLL) != 0;
                barV.Maximum = intoV.ScrollMax;
                barV.Visible = blnHasVScrollbar;
                barV.Value = intoV.nPos;
                barV.BringToFront();
            }
            else if (control is ListBox)
            {
                var lb = control as ListBox;
                if (intoV.ScrollMax <= 1)
                {
                    var v = lb.ItemHeight * lb.Items.Count - lb.Height;
                    if (v > 0)
                        barV.Maximum = v;
                    else
                        barV.Maximum = intoV.ScrollMax * lb.ItemHeight;
                }
                else
                {
                    barV.Maximum = intoV.ScrollMax * lb.ItemHeight;
                }
                barV.Visible = intoV.ScrollMax > 0 && intoV.nMax > 0 && intoV.nPage > 0;
                barV.Value = intoV.nPos * lb.ItemHeight;
                barV.BringToFront();
            }
            else if (control is ListView)
            {
                barV.Maximum = intoV.ScrollMax;
                barV.Visible = intoV.ScrollMax > 0 && intoV.nMax > 0 && intoV.nPage > 0;
                barV.Value = intoV.nPos;
                barV.BringToFront();
            }
            else if (control is DataGridView)
            {
                bool blnHasVScrollbar = false;
                var dgv = (DataGridView)control;
                if (dgv.ScrollBars == ScrollBars.Both || dgv.ScrollBars == ScrollBars.Vertical)
                {
                    int _height = dgv.RowTemplate.Height * dgv.Rows.Count;
                    if (dgv.ColumnHeadersVisible)
                    {
                        _height += dgv.ColumnHeadersHeight;
                    }
                    blnHasVScrollbar = _height > dgv.Height;
                }
                barV.Maximum = dgv.Rows.Count;
                barV.Visible = blnHasVScrollbar;
                barV.Value = dgv.FirstDisplayedScrollingRowIndex; ;
                barV.BringToFront();
            }
        }
        private void SetHMaxNum(Control control)
        {
            if (!m_lstHCache.ContainsKey(control))
                return;
            var intoH = ControlHelper.GetHScrollBarInfo(control.Handle);
            UCHScrollbar barH = m_lstHCache[control];
            if (control is ScrollableControl)
            {
                barH.Maximum = intoH.ScrollMax;
                barH.Visible = intoH.ScrollMax > 0 && intoH.nMax > 0 && intoH.nPage > 0;
                barH.Value = intoH.nPos;
                barH.BringToFront();

                //barH.Maximum = (control as ScrollableControl).HorizontalScroll.Maximum;
                //barH.Value = (control as ScrollableControl).HorizontalScroll.Value;
            }
            else if (control is TreeView)
            {
                var tv = control as TreeView;
                barH.Maximum = intoH.ScrollMax;
                barH.Visible = intoH.ScrollMax > 0 && intoH.nMax > 0 && intoH.nPage > 0;
                barH.Value = intoH.nPos;
                barH.BringToFront();
                //barH.Maximum = GetTreeNodeMaxX(control as TreeView);
                //barH.Value = (control as TreeView).AutoScrollOffset.X;
            }
            else if (control is TextBox)
            {
                TextBox txt = (TextBox)control;
                barH.Maximum = intoH.ScrollMax;

                if (txt.ScrollBars == ScrollBars.Both || txt.ScrollBars == ScrollBars.Horizontal)
                {
                    barH.Visible = true;
                }
                else
                {
                    barH.Visible = false;
                }

                barH.Value = intoH.nPos;
                barH.BringToFront();
            }
            else if (control is RichTextBox)
            {
                bool blnHasHScrollbar = control.IsHandleCreated && (ControlHelper.GetWindowLong(control.Handle, STYLE) & HSCROLL) != 0;

                barH.Maximum = intoH.ScrollMax;
                barH.Visible = blnHasHScrollbar;
                barH.Value = intoH.nPos;
                barH.BringToFront();
            }
            else if (control is ListBox)
            {
                var lb = control as ListBox;
                barH.Maximum = intoH.ScrollMax * lb.ItemHeight;
                barH.Visible = intoH.ScrollMax > 0 && intoH.nMax > 0 && intoH.nPage > 0;
                barH.Value = intoH.nPos * lb.ItemHeight;
                barH.BringToFront();
            }
            else if (control is ListView)
            {
                barH.Maximum = intoH.ScrollMax;
                barH.Visible = intoH.ScrollMax > 0 && intoH.nMax > 0 && intoH.nPage > 0;
                barH.Value = intoH.nPos;
                barH.BringToFront();
            }
            else if (control is DataGridView)
            {
                bool blnHasHScrollbar = false;
                var dgv = (DataGridView)control;
                int _width = 0;
                if (dgv.ScrollBars == ScrollBars.Both || dgv.ScrollBars == ScrollBars.Horizontal)
                {
                    foreach (DataGridViewColumn com in dgv.Columns)
                    {
                        _width += com.Width;
                    }
                    if (dgv.RowHeadersVisible)
                    {
                        _width += dgv.RowHeadersWidth;
                    }
                    blnHasHScrollbar = _width > dgv.Width;
                }
                if (blnHasHScrollbar)
                    barH.Maximum = _width - dgv.Width;
                barH.Visible = blnHasHScrollbar;
                barH.Value = dgv.FirstDisplayedScrollingColumnHiddenWidth;
                barH.BringToFront();
            }
        }
        /// <summary>
        /// Resets the v scroll location.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void ResetScrollLocation(object sender)
        {
            Control control = (Control)sender;
            bool blnHasVScrollbar = control.IsHandleCreated && (ControlHelper.GetWindowLong(control.Handle, STYLE) & VSCROLL) != 0;
            bool blnHasHScrollbar = control.IsHandleCreated && (ControlHelper.GetWindowLong(control.Handle, STYLE) & HSCROLL) != 0;
            if (control is TextBox)
            {
                var txt = (TextBox)control;
                if (txt.ScrollBars == ScrollBars.Both)
                {
                    blnHasVScrollbar = true;
                    blnHasHScrollbar = true;
                }
                else if (txt.ScrollBars == ScrollBars.Vertical)
                {
                    blnHasVScrollbar = true;
                    blnHasHScrollbar = false;
                }
                else if (txt.ScrollBars == ScrollBars.Horizontal)
                {
                    blnHasVScrollbar = false;
                    blnHasHScrollbar = true;
                }
                else
                {
                    blnHasVScrollbar = false;
                    blnHasHScrollbar = false;
                }
            }
            else if (control is DataGridView)
            {
                var dgv = (DataGridView)control;
                if (dgv.ScrollBars == ScrollBars.Both || dgv.ScrollBars == ScrollBars.Vertical)
                {
                    int _height = dgv.RowTemplate.Height * dgv.Rows.Count;
                    if (dgv.ColumnHeadersVisible)
                    {
                        _height += dgv.ColumnHeadersHeight;
                    }
                    blnHasVScrollbar = _height > dgv.Height;
                }
                if (dgv.ScrollBars == ScrollBars.Both || dgv.ScrollBars == ScrollBars.Horizontal)
                {
                    int _width = 0;
                    foreach (DataGridViewColumn com in dgv.Columns)
                    {
                        _width += com.Width;
                    }
                    if (dgv.RowHeadersVisible)
                    {
                        _width += dgv.RowHeadersWidth;
                    }
                    blnHasHScrollbar = _width > dgv.Width;
                }
            }
            else if (control is ListView)
            {
                if (!((ListView)control).Scrollable)
                {
                    blnHasVScrollbar = false;
                    blnHasHScrollbar = false;
                }
            }
            if (control.Visible)
            {
                if (m_lstVCache.ContainsKey(control))
                {
                    m_lstVCache[control].Location = new System.Drawing.Point(control.Right - m_lstVCache[control].Width, control.Top);
                    if (blnHasHScrollbar)
                    {
                        m_lstVCache[control].Height = control.Height - m_lstHCache[control].Height;
                    }
                    else
                    {
                        m_lstVCache[control].Height = control.Height;
                    }
                    SetVMaxNum(control);
                }

                if (m_lstHCache.ContainsKey(control))
                {
                    m_lstHCache[control].Location = new System.Drawing.Point(control.Left, control.Bottom - m_lstHCache[control].Height);
                    //if (blnHasVScrollbar)
                    //{
                    //    m_lstHCache[control].Width = control.Width - m_lstVCache[control].Width;
                    //}
                    //else
                    //{
                    m_lstHCache[control].Width = control.Width;
                    //}
                    SetHMaxNum(control);
                }
            }
        }

        /// <summary>
        /// Handles the VisibleChanged event of the control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void control_VisibleChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            if (m_lstVCache.ContainsKey(control) && m_lstVCache[control].Parent != null)
            {
                m_lstVCache[control].Visible = control.Visible;
            }

            if (m_lstHCache.ContainsKey(control) && m_lstHCache[control].Parent != null)
            {
                m_lstHCache[control].Visible = control.Visible;
            }
            if (control.Visible)
            {
                control_SizeChanged(control, null);
            }
        }

        private const int HSCROLL = 0x100000;
        private const int VSCROLL = 0x200000;
        private const int STYLE = -16;

        private Dictionary<Control, UCVScrollbar> m_lstVCache = new Dictionary<Control, UCVScrollbar>();
        private Dictionary<Control, UCHScrollbar> m_lstHCache = new Dictionary<Control, UCHScrollbar>();

        void barV_Scroll(object sender, EventArgs e)
        {
            UCVScrollbar bar = (UCVScrollbar)sender;
            if (m_lstVCache.ContainsValue(bar))
            {
                Control c = m_lstVCache.FirstOrDefault(p => p.Value == bar).Key;

                //ControlHelper.SetVScrollValue(c.Handle, bar.Value);
                if (c is ScrollableControl)
                {
                    (c as ScrollableControl).AutoScrollPosition = new Point((c as ScrollableControl).AutoScrollPosition.X, bar.Value);
                }
                else if (c is TreeView)
                {
                    ControlHelper.SetVScrollValue(c.Handle, bar.Value / ((c as TreeView).ItemHeight));
                }
                else if (c is TextBox)
                {
                    ControlHelper.SetVScrollValue(c.Handle, bar.Value / ((c as TextBox).PreferredHeight));
                }
                else if (c is RichTextBox)
                {
                    ControlHelper.SetVScrollValue(c.Handle, bar.Value);
                }
                else if (c is ListBox)
                {
                    ControlHelper.SetVScrollValue(c.Handle, bar.Value / ((c as ListBox).ItemHeight));
                }
                else if (c is ListView)
                {
                    ControlHelper.SetVScrollValue(c.Handle, bar.Value);
                }
                else if (c is DataGridView)
                {
                    var dgv = (DataGridView)c;
                    if(bar.Value>0)
                    dgv.FirstDisplayedScrollingRowIndex = bar.Value - 1;
                }
            }
        }

        void barH_Scroll(object sender, EventArgs e)
        {
            UCHScrollbar bar = (UCHScrollbar)sender;
            if (m_lstHCache.ContainsValue(bar))
            {
                Control c = m_lstHCache.FirstOrDefault(p => p.Value == bar).Key;
                if (c is ScrollableControl)
                {
                    (c as ScrollableControl).AutoScrollPosition = new Point(bar.Value, (c as ScrollableControl).AutoScrollPosition.Y);
                }
                else if (c is TreeView)
                {
                    ControlHelper.SetHScrollValue(c.Handle, bar.Value);
                    //TreeView tv = (c as TreeView);
                    //SetTreeViewVScrollLocation(tv, tv.Nodes, bar.Value);
                }
                else if (c is TextBox)
                {
                    ControlHelper.SetHScrollValue(c.Handle, bar.Value);
                    //TextBox txt = (c as TextBox);
                    //SetTextBoxVScrollLocation(txt, bar.Value);
                }
                else if (c is RichTextBox)
                {
                    ControlHelper.SetHScrollValue(c.Handle, bar.Value);
                }
                else if (c is ListBox)
                {
                    ControlHelper.SetHScrollValue(c.Handle, bar.Value);
                }
                else if (c is ListView)
                {
                    ControlHelper.SetHScrollValue(c.Handle, bar.Value);
                }
                else if (c is DataGridView)
                {
                    var dgv = (DataGridView)c;
                    dgv.HorizontalScrollingOffset = bar.Value;
                }
            }
        }

        #region Treeview处理    English:Treeview\u5904\u7406
        void tv_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            control_SizeChanged(sender as Control, null);
        }

        void tv_AfterExpand(object sender, TreeViewEventArgs e)
        {
            control_SizeChanged(sender as Control, null);
        }

        #endregion

        #region TextBox处理    English:TextBox Processing

        void txt_TextChanged(object sender, EventArgs e)
        {
            Control txt = sender as Control;
            control_SizeChanged(txt, null);
        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            Control txt = sender as Control;
            control_SizeChanged(txt, null);
        }
        #endregion
    }
}
