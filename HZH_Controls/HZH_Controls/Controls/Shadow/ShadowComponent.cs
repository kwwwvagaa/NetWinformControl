// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-28
//
// ***********************************************************************
// <copyright file="ShadowComponent.cs">
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
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class ShadowComponent.
    /// Implements the <see cref="System.ComponentModel.Component" />
    /// Implements the <see cref="System.ComponentModel.IExtenderProvider" />
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="System.ComponentModel.IExtenderProvider" />
    [ProvideProperty("ShowShadow", typeof(Control))]
    public class ShadowComponent : Component, IExtenderProvider
    {
        /// <summary>
        /// The m control cache
        /// </summary>
        Dictionary<Control, bool> m_controlCache = new Dictionary<Control, bool>();

        #region 构造函数    English:Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ShadowComponent" /> class.
        /// </summary>
        public ShadowComponent()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShadowComponent" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ShadowComponent(IContainer container)
            : this()
        {
            container.Add(this);
        }
        #endregion

        /// <summary>
        /// 指定此对象是否可以将其扩展程序属性提供给指定的对象。
        /// </summary>
        /// <param name="extendee">要接收扩展程序属性的 <see cref="T:System.Object" />。</param>
        /// <returns>如果此对象可以扩展程序属性提供给指定对象，则为 true；否则为 false。</returns>
        public bool CanExtend(object extendee)
        {
            if (extendee is Control && !(extendee is Form))
                return true;
            return false;
        }

        /// <summary>
        /// Gets the show shadow.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [Browsable(true), Category("自定义属性"), Description("是否显示倒影"), DisplayName("ShowShadow"), Localizable(true)]
        public bool GetShowShadow(Control control)
        {
            if (m_controlCache.ContainsKey(control))
                return m_controlCache[control];
            else
                return false;
        }

        /// <summary>
        /// Sets the show shadow.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="isShowShadow">if set to <c>true</c> [is show shadow].</param>
        public void SetShowShadow(Control control, bool isShowShadow)
        {
            control.ParentChanged += control_ParentChanged;
            m_controlCache[control] = isShowShadow;
        }

        /// <summary>
        /// Handles the ParentChanged event of the control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void control_ParentChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.Parent != null && m_controlCache[control])
            {
                if (!lstPaintEventControl.Contains(control.Parent))
                {
                    lstPaintEventControl.Add(control.Parent);
                    Type type = control.Parent.GetType();
                    System.Reflection.PropertyInfo pi = type.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    pi.SetValue(control.Parent, true, null);
                    control.Parent.Paint += Parent_Paint;
                }
            }
        }

        /// <summary>
        /// The LST paint event control
        /// </summary>
        List<Control> lstPaintEventControl = new List<Control>();
        /// <summary>
        /// The shadow height
        /// </summary>
        private float shadowHeight = 0.3f;

        /// <summary>
        /// Gets or sets the height of the shadow.
        /// </summary>
        /// <value>The height of the shadow.</value>
        [Browsable(true), Category("自定义属性"), Description("倒影高度，0-1"), Localizable(true)]
        public float ShadowHeight
        {
            get { return shadowHeight; }
            set { shadowHeight = value; }
        }
        /// <summary>
        /// The BLN loading
        /// </summary>
        bool blnLoading = false;
        /// <summary>
        /// Handles the Paint event of the Parent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        void Parent_Paint(object sender, PaintEventArgs e)
        {
            if (blnLoading)
                return;           
            if (shadowHeight > 0)
            {
                var control = sender as Control;
                var lst = m_controlCache.Where(p => p.Key.Parent == control && p.Value);
                if (lst != null && lst.Count() > 0)
                {
                    blnLoading = true;
                    e.Graphics.SetGDIHigh();
                    foreach (var item in lst)
                    {
                        Control _control = item.Key;

                        using (Bitmap bit = new Bitmap(_control.Width, _control.Height))
                        {
                            _control.DrawToBitmap(bit, _control.ClientRectangle);
                            using (Bitmap bitNew = new Bitmap(bit.Width, (int)(bit.Height * shadowHeight)))
                            {
                                using (var g = Graphics.FromImage(bitNew))
                                {
                                    g.DrawImage(bit, new RectangleF(0, 0, bitNew.Width, bitNew.Height), new RectangleF(0, bit.Height - bit.Height * shadowHeight, bit.Width, bit.Height * shadowHeight), GraphicsUnit.Pixel);
                                }
                                bitNew.RotateFlip(RotateFlipType.RotateNoneFlipY);
                                e.Graphics.DrawImage(bitNew, new Point(_control.Location.X, _control.Location.Y + _control.Height + 1));
                                Color bgColor = GetParentColor(_control);
                                LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(_control.Location.X, _control.Location.Y + _control.Height + 1, bitNew.Width, bitNew.Height), Color.FromArgb(50, bgColor), bgColor, 90f);   //75f 表示角度
                                e.Graphics.FillRectangle(lgb, new Rectangle(new Point(_control.Location.X, _control.Location.Y + _control.Height + 1), bitNew.Size));
                            }
                        }
                    }
                }
            }
            blnLoading = false;
        }

        /// <summary>
        /// Gets the color of the parent.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>Color.</returns>
        private Color GetParentColor(Control c)
        {
            if (c.Parent.BackColor != Color.Transparent)
            {
                return c.Parent.BackColor;
            }
            return GetParentColor(c.Parent);
        }
    }
}
