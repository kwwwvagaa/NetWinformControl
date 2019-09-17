// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="AuxiliaryLine.cs">
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
using System.Drawing;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class AuxiliaryLine.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
	internal class AuxiliaryLine : IDisposable
	{
        private string tip;
        /// <summary>
        /// Gets or sets the tip.
        /// </summary>
        /// <value>The tip.</value>
        public string Tip
        {
            get { return tip; }
            set { tip = value; }
        }
        /// <summary>
        /// The disposed value
        /// </summary>
		private bool disposedValue = false;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
		public float Value
		{
			get;
			set;
		}

        /// <summary>
        /// Gets or sets the paint value.
        /// </summary>
        /// <value>The paint value.</value>
		public float PaintValue
		{
			get;
			set;
		}

        /// <summary>
        /// Gets or sets the paint value back up.
        /// </summary>
        /// <value>The paint value back up.</value>
		public float PaintValueBackUp
		{
			get;
			set;
		}

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
		public Color LineColor
		{
			get;
			set;
		}

        /// <summary>
        /// Gets or sets the pen dash.
        /// </summary>
        /// <value>The pen dash.</value>
		public Pen PenDash
		{
			get;
			set;
		}

        /// <summary>
        /// Gets or sets the pen solid.
        /// </summary>
        /// <value>The pen solid.</value>
		public Pen PenSolid
		{
			get;
			set;
		}

        /// <summary>
        /// Gets or sets the line thickness.
        /// </summary>
        /// <value>The line thickness.</value>
		public float LineThickness
		{
			get;
			set;
		}

        /// <summary>
        /// Gets or sets the line text brush.
        /// </summary>
        /// <value>The line text brush.</value>
		public Brush LineTextBrush
		{
			get;
			set;
		}

        /// <summary>
        /// The is dash style
        /// </summary>
        private bool isDashStyle = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is dash style.
        /// </summary>
        /// <value><c>true</c> if this instance is dash style; otherwise, <c>false</c>.</value>
        public bool IsDashStyle
        {
            get { return isDashStyle; }
            set { isDashStyle = value; }
        }



        /// <summary>
        /// Gets the pen.
        /// </summary>
        /// <returns>Pen.</returns>
		public Pen GetPen()
		{
			return IsDashStyle ? PenDash : PenSolid;
		}

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
                    if(PenDash!=null)
					PenDash.Dispose();
                    if(PenSolid!=null)
					PenSolid.Dispose();
                    if(LineTextBrush!=null)
					LineTextBrush.Dispose();
				}
				disposedValue = true;
			}
		}

        /// <summary>
        /// 执行与释放或重置非托管资源相关的应用程序定义的任务。
        /// </summary>
		public void Dispose()
		{
			Dispose(true);
		}
	}
}
