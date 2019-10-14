using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HZH_Controls
{
    public class LineColors
    {
        /// <summary>
        /// The more light
        /// </summary>
        private static Color _MoreLight = ColorTranslator.FromHtml("#f2f6fc");

        /// <summary>
        /// Gets the more light.
        /// </summary>
        /// <value>The more light.</value>
        public static Color MoreLight
        {
            get { return _MoreLight; }
            internal set { _MoreLight = value; }
        }
        /// <summary>
        /// The light
        /// </summary>
        private static Color _Light = ColorTranslator.FromHtml("#ebeef5");

        /// <summary>
        /// Gets the light.
        /// </summary>
        /// <value>The light.</value>
        public static Color Light
        {
            get { return _Light; }
            internal set { _Light = value; }
        }
        /// <summary>
        /// The dark
        /// </summary>
        private static Color _Dark = ColorTranslator.FromHtml("#e4e7ed");

        /// <summary>
        /// Gets the dark.
        /// </summary>
        /// <value>The dark.</value>
        public static Color Dark
        {
            get { return _Dark; }
            internal set { _Dark = value; }
        }
        /// <summary>
        /// The more dark
        /// </summary>
        private static Color _MoreDark = ColorTranslator.FromHtml("#dcdfe6");

        /// <summary>
        /// Gets the more dark.
        /// </summary>
        /// <value>The more dark.</value>
        public static Color MoreDark
        {
            get { return _MoreDark; }
            internal set { _MoreDark = value; }
        }
    }
}
