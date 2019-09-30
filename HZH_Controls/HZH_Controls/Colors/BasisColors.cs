using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace HZH_Controls
{
    public class BasisColors
    {
        private static Color light = ColorTranslator.FromHtml("#f5f7fa");

        public static Color Light
        {
            get { return light; }
            internal set { light = value; }
        }
        private static Color medium = ColorTranslator.FromHtml("#f0f2f5");

        public static Color Medium
        {
            get { return medium; }
            internal set { medium = value; }
        }
        private static Color dark = ColorTranslator.FromHtml("#000000");

        public static Color Dark
        {
            get { return dark; }
            internal set { dark = value; }
        }
      
    }
}
