using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.UC
{
    public partial class UCTestCurveChart : UserControl
    {
        public UCTestCurveChart()
        {
            InitializeComponent();
        }

        private void UCTestCurveChart_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            this.ucCurve1.SetCurveText(new string[] { "周一", "周二", "周三", "周四", "周五", "周六", "周日" });
            float[] data1 = new float[7];
            float[] data2 = new float[7];
            float[] data3 = new float[7];
            for (int i = 0; i < data1.Length; i++)
            {
                data1[i] = r.Next(0, 100);
                data2[i] = r.Next(0, 100);
                data3[i] = r.Next(0, 100);
            }
            ucCurve1.SetLeftCurve("A", data1);
            ucCurve1.SetLeftCurve("B", data2);
            ucCurve1.SetLeftCurve("C", data3);
            //辅助文字
            ucCurve1.AddMarkText("A", 0, "周一数据", Color.Red);
            ucCurve1.AddMarkText("A", 1, "周二数据");
            ucCurve1.AddMarkText("B", 0, "周一数据");
            ucCurve1.AddMarkText("B", 1, "周二数据");

            ucCurve1.AddAuxiliaryLabel(new HZH_Controls.Controls.AuxiliaryLable()
            {
                LocationX = 0.8f,
                Text = "不合格数：5",
                TextBack = Brushes.Red,
                TextBrush = Brushes.White
            });

            ucCurve1.AddLeftAuxiliary(20, Color.Red);
            
            ucCurve2.SetLeftCurve("A", null, Color.Red);
            ucCurve2.SetLeftCurve("B", null, Color.Orange);
            ucCurve2.SetLeftCurve("C", null, Color.Blue);
            ucCurve2.SetLeftCurve("D", null, Color.Green);


            this.ucCurve3.SetCurveText(new string[] { "第一次模拟", "第二次模拟", "第三次模拟", "第四次模拟", "第五次模拟", "第六次模拟", "第七次模拟" });
            float[] data31 = new float[6];
            float[] data32 = new float[6];
            float[] data33 = new float[6];
            float[] data34 = new float[6];
            float[] data35 = new float[6];
            float[] data36 = new float[6];
            for (int i = 0; i < data31.Length; i++)
            {
                data31[i] = r.Next(10 + i * 10, 40+i*10);
                data32[i] = r.Next(10 + i * 10, 40+i*10);
                data33[i] = r.Next(10 + i * 10, 40+i*10);
                data34[i] = r.Next(10 + i * 10, 40+i*10);
                data35[i] = r.Next(10 + i * 10, 40+i*10);
                data36[i] = r.Next(10 + i * 10, 40+i*10);
            }
            ucCurve3.SetLeftCurve("语文", data31);
            ucCurve3.SetLeftCurve("数学", data32);
            ucCurve3.SetLeftCurve("英语", data33);
            ucCurve3.SetLeftCurve("化学", data34);
            ucCurve3.SetLeftCurve("生物", data35);
            ucCurve3.SetLeftCurve("物理", data36);
            
            for (int i = 0; i < data31.Length; i++)
			{
                ucCurve3.AddMarkText("语文", i, data31[i].ToString());
                ucCurve3.AddMarkText("数学", i, data32[i].ToString());
                ucCurve3.AddMarkText("英语", i, data33[i].ToString());
                ucCurve3.AddMarkText("化学", i, data34[i].ToString());
                ucCurve3.AddMarkText("生物", i, data35[i].ToString());
                ucCurve3.AddMarkText("物理", i, data36[i].ToString());
			}
          
        }
        int count_tick = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            count_tick++;
            float random1 = (float)(Math.Sin(2 * Math.PI * count_tick / 30) * 0.5d + 0.5);
            float random2 = (float)(Math.Sin(2 * Math.PI * count_tick / 50) * 0.5d + 0.5);
            float random3 = (float)(Math.Cos(2 * Math.PI * count_tick / 80) * 0.5d + 0.5);
            float random4 = (float)(Math.Cos(2 * Math.PI * count_tick / 10) * 0.5d + 0.5);

            if (count_tick % 50 == 0)
            {
                ucCurve2.AddCurveData(
                  new string[] { "A", "B", "C", "D" },
                  new float[]
                {
                    random1*10 + 80,
                    random2*20+50,
                    random3*20+30,
                    random4*10+20,
                }, new string[] { "标签1", "标签2", "标签3", "标签4" }
              );
            }
            else
            {
                ucCurve2.AddCurveData(
                   new string[] { "A", "B", "C", "D" },
                   new float[]
                {
                    random1*10 + 80,
                    random2*20+50,
                    random3*20+30,
                    random4*10+20,
                }
               );
            }

            if (count_tick > 10000)
                count_tick = 0;
        }
    }
}
