using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HZH_Controls
{
    public class TableColors
    {
        private static Color green = ColorTranslator.FromHtml("#c2e7b0");

        public static Color Green
        {
            get { return green; }
            internal set { green = value; }
        }
        private static Color blue = ColorTranslator.FromHtml("#a3d0fd");

        public static Color Blue
        {
            get { return blue; }
            internal set { blue = value; }
        }
        private static Color red = ColorTranslator.FromHtml("#fbc4c4");

        public static Color Red
        {
            get { return red; }
            internal set { red = value; }
        }
        private static Color yellow = ColorTranslator.FromHtml("#f5dab1");

        public static Color Yellow
        {
            get { return yellow; }
            internal set { yellow = value; }
        }
        private static Color gray = ColorTranslator.FromHtml("#d3d4d6");

        public static Color Gray
        {
            get { return gray; }
            internal set { gray = value; }
        }
    }
}
