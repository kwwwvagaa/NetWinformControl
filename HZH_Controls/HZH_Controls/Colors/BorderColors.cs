using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HZH_Controls
{
    public class BorderColors
    {
        private static Color green = ColorTranslator.FromHtml("#f0f9ea");

        public static Color Green
        {
            get { return green; }
            internal set { green = value; }
        }
        private static Color blue = ColorTranslator.FromHtml("#ecf5ff");

        public static Color Blue
        {
            get { return blue; }
            internal set { blue = value; }
        }
        private static Color red = ColorTranslator.FromHtml("#fef0f0");

        public static Color Red
        {
            get { return red; }
            internal set { red = value; }
        }
        private static Color yellow = ColorTranslator.FromHtml("#fdf5e6");

        public static Color Yellow
        {
            get { return yellow; }
            internal set { yellow = value; }
        }
    }
}
