using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HZH_Controls.Controls
{

    public class SmoothingModeGraphics : IDisposable
    {
        private SmoothingMode _oldMode;
        private Graphics _graphics;

        public SmoothingModeGraphics(Graphics graphics)
            : this(graphics, SmoothingMode.AntiAlias)
        {
        }

        public SmoothingModeGraphics(Graphics graphics, SmoothingMode newMode)
        {
            _graphics = graphics;
            _oldMode = graphics.SmoothingMode;
            graphics.SmoothingMode = newMode;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            _graphics.SmoothingMode = _oldMode;
        }

        #endregion
    }
}
