using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace HZH_Controls.Controls
{
    public class InterpolationModeGraphics : IDisposable
    {
        private InterpolationMode _oldMode;
        private Graphics _graphics;

        public InterpolationModeGraphics(Graphics graphics)
            : this(graphics, InterpolationMode.HighQualityBicubic)
        {
        }

        public InterpolationModeGraphics(
            Graphics graphics, InterpolationMode newMode)
        {
            _graphics = graphics;
            _oldMode = graphics.InterpolationMode;
            graphics.InterpolationMode = newMode;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            _graphics.InterpolationMode = _oldMode;
        }

        #endregion
    }
}
