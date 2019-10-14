using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HZH_Controls
{
    public class GradientColors
    {
        private static Color[] orange = new Color[] { Color.FromArgb(252, 196, 136), Color.FromArgb(243, 138, 159) };

        public static Color[] Orange
        {
            get { return GradientColors.orange; }
            internal set { GradientColors.orange = value; }
        }
        private static Color[] lightGreen = new Color[] { Color.FromArgb(210, 251, 123), Color.FromArgb(152, 231, 160) };

        public static Color[] LightGreen
        {
            get { return GradientColors.lightGreen; }
            internal set { GradientColors.lightGreen = value; }
        }
        private static Color[] green = new Color[] { Color.FromArgb(138, 241, 124), Color.FromArgb(32, 190, 179) };

        public static Color[] Green
        {
            get { return GradientColors.green; }
            internal set { GradientColors.green = value; }
        }
        private static Color[] blue = new Color[] { Color.FromArgb(193, 232, 251), Color.FromArgb(162, 197, 253) };

        public static Color[] Blue
        {
            get { return GradientColors.blue; }
            internal set { GradientColors.blue = value; }
        }
        private static Color[] blueGreen = new Color[] { Color.FromArgb(122, 251, 218), Color.FromArgb(16, 193, 252) };

        public static Color[] BlueGreen
        {
            get { return GradientColors.blueGreen; }
            internal set { GradientColors.blueGreen = value; }
        }
        private static Color[] lightViolet = new Color[] { Color.FromArgb(248, 192, 234), Color.FromArgb(164, 142, 210) };

        public static Color[] LightViolet
        {
            get { return GradientColors.lightViolet; }
            internal set { GradientColors.lightViolet = value; }
        }
        private static Color[] violet = new Color[] { Color.FromArgb(185, 154, 241), Color.FromArgb(137, 124, 242) };

        public static Color[] Violet
        {
            get { return GradientColors.violet; }
            internal set { GradientColors.violet = value; }
        }
        private static Color[] gray = new Color[] { Color.FromArgb(233, 238, 239), Color.FromArgb(147, 162, 175) };

        public static Color[] Gray
        {
            get { return GradientColors.gray; }
            internal set { GradientColors.gray = value; }
        }
    }
}
