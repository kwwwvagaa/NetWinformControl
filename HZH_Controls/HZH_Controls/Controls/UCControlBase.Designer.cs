using System.Drawing;
using System.Windows.Forms;
namespace HZH_Controls.Controls
{
    partial class UCControlBase
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
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(9f, 20f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.DoubleBuffered = true;
            this.Font = new Font("微软雅黑", 15f, FontStyle.Regular, GraphicsUnit.Pixel);
            base.Margin = new Padding(4, 5, 4, 5);
            base.Name = "UCBase";
            base.Size = new Size(237, 154);
            base.ResumeLayout(false);
        }

        #endregion
    }
}
