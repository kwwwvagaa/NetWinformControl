using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Controls;
using HZH_Controls;
using System.Drawing.Drawing2D;

namespace Test.UC
{
    [ToolboxItem(false)]
    public partial class UCTestVerification : UserControl
    {
        public UCTestVerification()
        {
            InitializeComponent();
        }

        List<Control> lstErrorControl = new List<Control>();

        private void button1_Click(object sender, EventArgs e)
        {
            lstErrorControl.Clear();
            this.verificationComponent1.Verification();
            this.panel1.Invalidate(true);
        }

        private void UCTestVerification_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> lstCom = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < 5; i++)
            {
                lstCom.Add(new KeyValuePair<string, string>(i.ToString(), "选项" + i));
            }

            this.ucComboBox1.Source = lstCom;
            this.ucComboBox2.Source = lstCom;
            this.ucCombox2.Source = lstCom;
            this.ucCombox1.Source = lstCom;

            List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "编号", Width = 70, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Name", HeadText = "姓名", Width = 100, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Age", HeadText = "年龄", Width = 100, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Birthday", HeadText = "生日", Width = 120, WidthType = SizeType.Absolute, Format = (a) => { return ((DateTime)a).ToString("yyyy-MM-dd"); } });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Sex", HeadText = "性别", Width = 100, WidthType = SizeType.Absolute, Format = (a) => { return ((int)a) == 0 ? "女" : "男"; } });
            this.ucComboxGrid1.GridColumns = lstCulumns;
            List<object> lstSourceGrid = new List<object>();
            for (int i = 0; i < 100; i++)
            {
                TestGridModel model = new TestGridModel()
                {
                    ID = i.ToString(),
                    Age = 3 * i,
                    Name = "姓名——" + i,
                    Birthday = DateTime.Now.AddYears(-10),
                    Sex = i % 2
                };
                lstSourceGrid.Add(model);
            }
            this.ucComboxGrid1.GridDataSource = lstSourceGrid;
            ucComboxGrid2.GridDataSource = lstSourceGrid;
        }

        private void graphicalOverlay1_Paint(object sender, PaintEventArgs e)
        {
            if (lstErrorControl.Count > 0)
            {
                e.Graphics.SetGDIHigh();
                foreach (Control control in lstErrorControl)
                {
                    if (control.Parent == this.groupBox2 || control.Parent == this.groupBox4)
                    {
                        var p = control.Location;
                        p.Offset(control.Parent.Location);
                        GraphicsPath path = ControlHelper.CreateRoundedRectanglePath(new Rectangle(p.X - 1, p.Y - 1, control.Width + 2, control.Height + 2), 4);
                        e.Graphics.DrawPath(new Pen(new SolidBrush(Color.FromArgb(100, 255, 0, 0)), 2), path);
                    }
                }              
            }
        }

        private void verificationComponent1_Verificationed(VerificationEventArgs e)
        {
            if (!e.IsVerifySuccess)
            {
                lstErrorControl.Add(e.VerificationControl);
            }
        }
    }
}
