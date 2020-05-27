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
    public partial class UCTestContextMenu : UserControl
    {
        public UCTestContextMenu()
        {
            InitializeComponent();
            //HZH_Controls.Controls.ToolStripColorTable这里面有好多颜色  自己可以改  
            ToolStripManager.Renderer = new HZH_Controls.Controls.ProfessionalToolStripRendererEx();

        }
    }
}
