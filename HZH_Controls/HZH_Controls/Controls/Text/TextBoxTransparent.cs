// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="TextBoxTransparent.cs">
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using System.Drawing.Imaging;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class TextBoxTransparent.
    /// Implements the <see cref="HZH_Controls.Controls.TextBoxEx" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.TextBoxEx" />
    public class TextBoxTransparent : TextBoxEx
    {
        #region private variables

        /// <summary>
        /// My PictureBox
        /// </summary>
        private uPictureBox myPictureBox;
        /// <summary>
        /// My up to date
        /// </summary>
        private bool myUpToDate = false;
        /// <summary>
        /// My caret up to date
        /// </summary>
        private bool myCaretUpToDate = false;
        /// <summary>
        /// My bitmap
        /// </summary>
        private Bitmap myBitmap;
        /// <summary>
        /// My alpha bitmap
        /// </summary>
        private Bitmap myAlphaBitmap;

        /// <summary>
        /// My font height
        /// </summary>
        private int myFontHeight = 10;

        /// <summary>
        /// My timer1
        /// </summary>
        private System.Windows.Forms.Timer myTimer1;

        /// <summary>
        /// My caret state
        /// </summary>
        private bool myCaretState = true;

        /// <summary>
        /// My painted first time
        /// </summary>
        private bool myPaintedFirstTime = false;

        /// <summary>
        /// My back color
        /// </summary>
        private Color myBackColor = Color.White;
        /// <summary>
        /// My back alpha
        /// </summary>
        private int myBackAlpha = 10;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion // end private variables


        #region public methods and overrides

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxTransparent" /> class.
        /// </summary>
        public TextBoxTransparent()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            // TODO: Add any initialization after the InitializeComponent call

            this.BackColor = myBackColor;

            this.SetStyle(ControlStyles.UserPaint, false);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);


            myPictureBox = new uPictureBox();
            this.Controls.Add(myPictureBox);
            myPictureBox.Dock = DockStyle.Fill;
        }


        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Resize" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs" />。</param>
        protected override void OnResize(EventArgs e)
        {

            base.OnResize(e);
            this.myBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(this.Width,this.Height);
            this.myAlphaBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(this.Width,this.Height);
            myUpToDate = false;
            this.Invalidate();
        }


        //Some of these should be moved to the WndProc later

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.KeyDown" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.KeyEventArgs" />。</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            myUpToDate = false;
            this.Invalidate();
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.KeyUp" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.KeyEventArgs" />。</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            myUpToDate = false;
            this.Invalidate();

        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.KeyPress" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.KeyPressEventArgs" />。</param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            myUpToDate = false;
            this.Invalidate();
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.MouseUp" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.MouseEventArgs" />。</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.Invalidate();
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.GiveFeedback" /> 事件。
        /// </summary>
        /// <param name="gfbevent">包含事件数据的 <see cref="T:System.Windows.Forms.GiveFeedbackEventArgs" />。</param>
        protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        {
            base.OnGiveFeedback(gfbevent);
            myUpToDate = false;
            this.Invalidate();
        }


        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.MouseLeave" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs" />。</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            //found this code to find the current cursor location
            //at http://www.syncfusion.com/FAQ/WinForms/FAQ_c50c.asp#q597q

            Point ptCursor = Cursor.Position;

            Form f = this.FindForm();
            ptCursor = f.PointToClient(ptCursor);
            if (!this.Bounds.Contains(ptCursor))
                base.OnMouseLeave(e);
        }


        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.ChangeUICues" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.UICuesEventArgs" />。</param>
        protected override void OnChangeUICues(UICuesEventArgs e)
        {
            base.OnChangeUICues(e);
            myUpToDate = false;
            this.Invalidate();
        }


        //--
        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.GotFocus" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs" />。</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            myCaretUpToDate = false;
            myUpToDate = false;
            this.Invalidate();


            myTimer1 = new System.Windows.Forms.Timer(this.components);
            myTimer1.Interval = (int)win32.GetCaretBlinkTime(); //  usually around 500;

            myTimer1.Tick += new EventHandler(myTimer1_Tick);
            myTimer1.Enabled = true;

        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.LostFocus" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs" />。</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            myCaretUpToDate = false;
            myUpToDate = false;
            this.Invalidate();

            myTimer1.Dispose();
        }

        //--		

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.FontChanged" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs" />。</param>
        protected override void OnFontChanged(EventArgs e)
        {
            if (this.myPaintedFirstTime)
                this.SetStyle(ControlStyles.UserPaint, false);

            base.OnFontChanged(e);

            if (this.myPaintedFirstTime)
                this.SetStyle(ControlStyles.UserPaint, true);


            myFontHeight = GetFontHeight();


            myUpToDate = false;
            this.Invalidate();
        }

        /// <summary>
        /// Handles the <see cref="E:TextChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            myUpToDate = false;
            this.Invalidate();
        }


        /// <summary>
        /// 处理 Windows 消息。
        /// </summary>
        /// <param name="m">一个 Windows 消息对象。</param>
        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);

            // need to rewrite as a big switch

            if (m.Msg == win32.WM_PAINT)
            {

                myPaintedFirstTime = true;

                if (!myUpToDate || !myCaretUpToDate)
                    GetBitmaps();
                myUpToDate = true;
                myCaretUpToDate = true;

                if (myPictureBox.Image != null) myPictureBox.Image.Dispose();


                if (string.IsNullOrEmpty(this.Text) && !string.IsNullOrEmpty(this.PromptText))
                {
                    Bitmap bit = (Bitmap)myAlphaBitmap.Clone();
                    Graphics g = Graphics.FromImage(bit);
                    SizeF sizet1 = g.MeasureString(this.PromptText, this.PromptFont);
                    g.DrawString(this.PromptText, this.PromptFont, new SolidBrush(PromptColor), new PointF(3, (bit.Height - sizet1.Height) / 2));
                    g.Dispose();
                    myPictureBox.Image = bit;
                }
                else
                {
                    myPictureBox.Image = (Image)myAlphaBitmap.Clone();
                }
            }

            else if (m.Msg == win32.WM_HSCROLL || m.Msg == win32.WM_VSCROLL)
            {
                myUpToDate = false;
                this.Invalidate();
            }

            else if (m.Msg == win32.WM_LBUTTONDOWN
                || m.Msg == win32.WM_RBUTTONDOWN
                || m.Msg == win32.WM_LBUTTONDBLCLK
                //  || m.Msg == win32.WM_MOUSELEAVE  ///****
                )
            {
                myUpToDate = false;
                this.Invalidate();
            }

            else if (m.Msg == win32.WM_MOUSEMOVE)
            {
                if (m.WParam.ToInt32() != 0)  //shift key or other buttons
                {
                    myUpToDate = false;
                    this.Invalidate();
                }
            }

            if (m.Msg == 15 || m.Msg == 7 || m.Msg == 8)
            {
                base.OnPaint(null);
            }

         
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">为 true 则释放托管资源和非托管资源；为 false 则仅释放非托管资源。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //this.BackColor = Color.Pink;
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion		//end public method and overrides


        #region public property overrides

        /// <summary>
        /// 获取或设置文本框控件的边框类型。
        /// </summary>
        /// <value>The border style.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set
            {
                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, false);

                base.BorderStyle = value;

                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, true);

                this.myBitmap = null;
                this.myAlphaBitmap = null;
                myUpToDate = false;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 获取或设置控件的背景色。
        /// </summary>
        /// <value>The color of the back.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public new Color BackColor
        {
            get
            {
                return Color.FromArgb(base.BackColor.R, base.BackColor.G, base.BackColor.B);
            }
            set
            {
                myBackColor = value;
                base.BackColor = value;
                myUpToDate = false;
            }
        }
        /// <summary>
        /// 获取或设置一个值，该值指示此控件是否为多行 <see cref="T:System.Windows.Forms.TextBox" /> 控件。
        /// </summary>
        /// <value><c>true</c> if multiline; otherwise, <c>false</c>.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public override bool Multiline
        {
            get { return base.Multiline; }
            set
            {
                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, false);

                base.Multiline = value;

                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, true);

                this.myBitmap = null;
                this.myAlphaBitmap = null;
                myUpToDate = false;
                this.Invalidate();
            }
        }


        #endregion    //end public property overrides


        #region private functions and classes

        /// <summary>
        /// Gets the height of the font.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int GetFontHeight()
        {
            Graphics g = this.CreateGraphics();
            SizeF sf_font = g.MeasureString("X", this.Font);
            g.Dispose();
            return (int)sf_font.Height;
        }


        /// <summary>
        /// Gets the bitmaps.
        /// </summary>
        private void GetBitmaps()
        {

            if (myBitmap == null
                || myAlphaBitmap == null
                || myBitmap.Width != Width
                || myBitmap.Height != Height
                || myAlphaBitmap.Width != Width
                || myAlphaBitmap.Height != Height)
            {
                myBitmap = null;
                myAlphaBitmap = null;
            }



            if (myBitmap == null)
            {
                myBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(Width,Height);
                myUpToDate = false;
            }


            if (!myUpToDate)
            {
                //Capture the TextBox control window

                this.SetStyle(ControlStyles.UserPaint, false);

                win32.CaptureWindow(this, ref myBitmap);

                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                this.BackColor = Color.FromArgb(myBackAlpha, myBackColor);

            }
            //--



            Rectangle r2 = new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
            ImageAttributes tempImageAttr = new ImageAttributes();


            //Found the color map code in the MS Help

            ColorMap[] tempColorMap = new ColorMap[1];
            tempColorMap[0] = new ColorMap();
            tempColorMap[0].OldColor = Color.FromArgb(255, myBackColor);
            tempColorMap[0].NewColor = Color.FromArgb(myBackAlpha, myBackColor);

            tempImageAttr.SetRemapTable(tempColorMap);

            if (myAlphaBitmap != null)
                myAlphaBitmap.Dispose();


            myAlphaBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(Width,Height);

            Graphics tempGraphics1 = Graphics.FromImage(myAlphaBitmap);

            tempGraphics1.DrawImage(myBitmap, r2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, GraphicsUnit.Pixel, tempImageAttr);

            tempGraphics1.Dispose();

            //----

            if (this.Focused && (this.SelectionLength == 0))
            {
                Graphics tempGraphics2 = Graphics.FromImage(myAlphaBitmap);
                if (myCaretState)
                {
                    //Draw the caret
                    Point caret = this.findCaret();
                    Pen p = new Pen(this.ForeColor, 3);
                    tempGraphics2.DrawLine(p, caret.X + 2, caret.Y + 0, caret.X + 2, caret.Y + myFontHeight);
                    tempGraphics2.Dispose();
                }

            }



        }



        /// <summary>
        /// Finds the caret.
        /// </summary>
        /// <returns>Point.</returns>
        private Point findCaret()
        {
            /*  Find the caret translated from code at 
             * http://www.vb-helper.com/howto_track_textbox_caret.html
             * 
             * and 
             * 
             * http://www.microbion.co.uk/developers/csharp/textpos2.htm
             * 
             * Changed to EM_POSFROMCHAR
             * 
             * This code still needs to be cleaned up and debugged
             * */

            Point pointCaret = new Point(0);
            int i_char_loc = this.SelectionStart;
            IntPtr pi_char_loc = new IntPtr(i_char_loc);

            int i_point = win32.SendMessage(this.Handle, win32.EM_POSFROMCHAR, pi_char_loc, IntPtr.Zero);
            pointCaret = new Point(i_point);

            if (i_char_loc == 0)
            {
                pointCaret = new Point(0);
            }
            else if (i_char_loc >= this.Text.Length)
            {
                pi_char_loc = new IntPtr(i_char_loc - 1);
                i_point = win32.SendMessage(this.Handle, win32.EM_POSFROMCHAR, pi_char_loc, IntPtr.Zero);
                pointCaret = new Point(i_point);

                Graphics g = this.CreateGraphics();
                String t1 = this.Text.Substring(this.Text.Length - 1, 1) + "X";
                SizeF sizet1 = g.MeasureString(t1, this.Font);
                SizeF sizex = g.MeasureString("X", this.Font);
                g.Dispose();
                int xoffset = (int)(sizet1.Width - sizex.Width);
                pointCaret.X = pointCaret.X + xoffset;

                if (i_char_loc == this.Text.Length)
                {
                    String slast = this.Text.Substring(Text.Length - 1, 1);
                    if (slast == "\n")
                    {
                        pointCaret.X = 1;
                        pointCaret.Y = pointCaret.Y + myFontHeight;
                    }
                }

            }



            return pointCaret;
        }


        /// <summary>
        /// Handles the Tick event of the myTimer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void myTimer1_Tick(object sender, EventArgs e)
        {
            //Timer used to turn caret on and off for focused control

            myCaretState = !myCaretState;
            myCaretUpToDate = false;
            this.Invalidate();
        }


        /// <summary>
        /// Class uPictureBox.
        /// Implements the <see cref="System.Windows.Forms.PictureBox" />
        /// </summary>
        /// <seealso cref="System.Windows.Forms.PictureBox" />
        private class uPictureBox : PictureBox
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="uPictureBox" /> class.
            /// </summary>
            public uPictureBox()
            {
                this.SetStyle(ControlStyles.Selectable, false);
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);

                this.Cursor = null;
                this.Enabled = true;
                this.SizeMode = PictureBoxSizeMode.Normal;

            }




            //uPictureBox
            /// <summary>
            /// 处理 Windows 消息。
            /// </summary>
            /// <param name="m">要处理的 Windows<see cref="T:System.Windows.Forms.Message" />。</param>
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == win32.WM_LBUTTONDOWN
                    || m.Msg == win32.WM_RBUTTONDOWN
                    || m.Msg == win32.WM_LBUTTONDBLCLK
                    || m.Msg == win32.WM_MOUSELEAVE
                    || m.Msg == win32.WM_MOUSEMOVE)
                {
                    //Send the above messages back to the parent control
                    win32.PostMessage(this.Parent.Handle, (uint)m.Msg, m.WParam, m.LParam);
                }

                else if (m.Msg == win32.WM_LBUTTONUP)
                {
                    //??  for selects and such
                    this.Parent.Invalidate();
                }


                base.WndProc(ref m);
            }


        }   // End uPictureBox Class


        #endregion  // end private functions and classes


        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion


        #region New Public Properties

        /// <summary>
        /// Gets or sets the back alpha.
        /// </summary>
        /// <value>The back alpha.</value>
        [
        Category("Appearance"),
        Description("The alpha value used to blend the control's background. Valid values are 0 through 255."),
        Browsable(true),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)

        ]
        public int BackAlpha
        {
            get { return myBackAlpha; }
            set
            {
                int v = value;
                if (v > 255)
                    v = 255;
                myBackAlpha = v;
                myUpToDate = false;
                Invalidate();
            }
        }

        #endregion



    }  // End AlphaTextBox Class 
}