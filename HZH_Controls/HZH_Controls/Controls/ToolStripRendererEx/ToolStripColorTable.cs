using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HZH_Controls.Controls
{

    public class ToolStripColorTable
    {
        private static readonly Color _base = Color.FromArgb(49, 56, 82);
        private static readonly Color _border = Color.FromArgb(49, 56, 82);
        private static readonly Color _backNormal = Color.FromArgb(49, 56, 82);
        private static readonly Color _backHover = Color.FromArgb(29, 33, 49);
        private static readonly Color _backPressed = Color.FromArgb(29, 33, 49);
        private static readonly Color _fore = Color.FromArgb(175, 193, 225);
        private static readonly Color _dropDownImageBack = Color.FromArgb(49, 56, 82);
        private static readonly Color _dropDownImageSeparator = Color.FromArgb(49, 56, 82);

        public ToolStripColorTable() { }

        public virtual Color Base
        {
            get { return _base; }
        }

        public virtual Color Border
        {
            get { return _border; }
        }

        public virtual Color BackNormal
        {
            get { return _backNormal; }
        }

        public virtual Color BackHover
        {
            get { return _backHover; }
        }

        public virtual Color BackPressed
        {
            get { return _backPressed; }
        }

        public virtual Color Fore
        {
            get { return _fore; }
        }

        public virtual Color DropDownImageBack
        {
            get { return _dropDownImageBack; }
        }

        public virtual Color DropDownImageSeparator
        {
            get { return _dropDownImageSeparator; }
        }
    }
}
