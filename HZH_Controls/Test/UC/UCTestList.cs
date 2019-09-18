using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Controls;

namespace Test.UC
{
    [ToolboxItem(false)]
    public partial class UCTestList : UserControl
    {
        public UCTestList()
        {
            InitializeComponent();
            this.ucListExt2.SplitColor = Color.FromArgb(57,61,73);
        }

        private void UCTestList_Load(object sender, EventArgs e)
        {
            List<ListEntity> lst = new List<ListEntity>();
            for (int i = 0; i < 5; i++)
            {
                lst.Add(new ListEntity()
                {
                    ID = i.ToString(),
                    Title = "选项" + i,
                    ShowMoreBtn = i % 2 == 1,
                    Source = i
                });
            }
            this.ucListExt1.SetList(lst);

            List<ListEntity> lst2 = new List<ListEntity>();
            for (int i = 0; i < 5; i++)
            {
                lst2.Add(new ListEntity()
                {
                    ID = i.ToString(),
                    Title = "标题" + i,
                    ShowMoreBtn = i % 2 == 1,
                    Source = i,
                    Title2 = "副标题"
                });
            }
            this.ucListExt2.SetList(lst2);
        }
    }
}
