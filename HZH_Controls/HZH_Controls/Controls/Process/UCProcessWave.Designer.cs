// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-23-2019
//
// ***********************************************************************
// <copyright file="UCProcessWave.Designer.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCProcessWave.
    /// Implements the <see cref="HZH_Controls.Controls.UCControlBase" />
    /// </summary>
    /// <seealso cref="HZH_Controls.Controls.UCControlBase" />
    partial class UCProcessWave
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ucWave1 = new HZH_Controls.Controls.UCWave();
            this.SuspendLayout();
            // 
            // ucWave1
            // 
            this.ucWave1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucWave1.Location = new System.Drawing.Point(0, 140);
            this.ucWave1.Name = "ucWave1";
            this.ucWave1.Size = new System.Drawing.Size(150, 10);
            this.ucWave1.TabIndex = 0;
            this.ucWave1.Text = "ucWave1";
            this.ucWave1.WaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucWave1.WaveHeight = 15;
            this.ucWave1.WaveSleep = 100;
            this.ucWave1.WaveWidth = 100;
            // 
            // UCProcessWave
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.Controls.Add(this.ucWave1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "UCProcessWave";
            this.Size = new System.Drawing.Size(150, 150);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The uc wave1
        /// </summary>
        private UCWave ucWave1;
    }
}
