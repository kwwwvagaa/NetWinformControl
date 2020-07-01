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
                // RichTextBox control = (RichTextBox)extendee;

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

            control_SizeChanged(control, null);
            control.VisibleChanged += control_VisibleChanged;
            control.SizeChanged += control_SizeChanged;
            control.LocationChanged += control_LocationChanged;
            control.Disposed += control_Disposed;

            control.MouseWheel += Control_MouseWheel;

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
            if (control is ScrollableControl )
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
            else if (control is TextBoxBase)
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
                    ControlHelper.SetVScrollValue(c.Handle, bar.Value );
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

        // void tv_AfterSelect(object sender, TreeViewEventArgs e)
        // {
        //     TreeView tv = (TreeView)sender;
        //     if (m_lstVCache.ContainsKey(tv))
        //     {
        //         m_lstVCache[tv].Value = tv.Nodes.Count > 0 ? Math.Abs(tv.Nodes[0].Bounds.Top) : 0;
        //     }
        // }

        ///// <summary>
        ///// Sets the TreeView scroll location.
        ///// </summary>
        ///// <param name="tv">The tv.</param>
        ///// <param name="tns">The TNS.</param>
        ///// <param name="intY">The int y.</param>
        ///// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        //private bool SetTreeViewVScrollLocation(TreeView tv, TreeNodeCollection tns, int intY)
        //{
        //    for (int i = 0; i < tns.Count; i++)
        //    {
        //        if (intY >= tns[i].Bounds.Top - tv.Nodes[0].Bounds.Top - 3 && intY <= tns[i].Bounds.Bottom - tv.Nodes[0].Bounds.Top + 3)
        //        {
        //            tns[i].EnsureVisible();
        //            return true;
        //        }
        //        else if (tns[i].IsExpanded && tns[i].Nodes.Count > 0)
        //        {
        //            bool bln = SetTreeViewVScrollLocation(tv, tns[i].Nodes, intY);
        //            if (bln)
        //                return true;
        //        }
        //    }
        //    return false;
        //}
        #endregion

        #region TextBox处理    English:TextBox Processing

        void txt_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            control_SizeChanged(txt, null);

            //if (m_lstVCache.ContainsKey(txt))
            //{
            //    using (var g = txt.CreateGraphics())
            //    {
            //        var size = g.MeasureString(txt.Text.Substring(0, txt.SelectionStart), txt.Font);
            //        m_lstVCache[txt].Value = (int)size.Height;
            //    }
            //}
        }
        //private void SetTextBoxVScrollLocation(TextBox txt, int intY)
        //{
        //    using (var g = txt.CreateGraphics())
        //    {
        //        for (int i = 0; i < txt.Lines.Length; i++)
        //        {
        //            string str = string.Join("\n", txt.Lines.Take(i + 1));
        //            var size = g.MeasureString(str, txt.Font);
        //            if (size.Height >= intY)
        //            {
        //                txt.SelectionStart = str.Length;
        //                txt.ScrollToCaret();
        //                return;
        //            }
        //        }
        //    }
        //}

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            control_SizeChanged(txt, null);
            //if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            //{
            //    TextBox txt = (TextBox)sender;
            //    if (m_lstVCache.ContainsKey(txt))
            //    {
            //        using (var g = txt.CreateGraphics())
            //        {
            //            var size = g.MeasureString(txt.Text.Substring(0, txt.SelectionStart), txt.Font);
            //            m_lstVCache[txt].Value = (int)size.Height;
            //        }
            //    }
            //}
        }

        //void txt_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    if (m_lstVCache.ContainsKey(txt))
        //    {
        //        using (var g = txt.CreateGraphics())
        //        {
        //            StringBuilder str = new StringBuilder();
        //            for (int i = 0; i < System.Windows.Forms.SystemInformation.MouseWheelScrollLines; i++)
        //            {
        //                str.AppendLine("A");
        //            }
        //            var height = (int)g.MeasureString(str.ToString(), txt.Font).Height;
        //            if (e.Delta < 0)
        //            {
        //                if (height + m_lstVCache[txt].Value > m_lstVCache[txt].Maximum)
        //                    m_lstVCache[txt].Value = m_lstVCache[txt].Maximum;
        //                else
        //                    m_lstVCache[txt].Value += height;
        //            }
        //            else
        //            {
        //                if (m_lstVCache[txt].Value - height < 0)
        //                    m_lstVCache[txt].Value = 0;
        //                else
        //                    m_lstVCache[txt].Value -= height;
        //            }
        //        }
        //    }
        //}
        #endregion
    }
}
