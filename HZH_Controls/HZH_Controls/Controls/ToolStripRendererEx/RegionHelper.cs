using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    public static class RegionHelper
    {
        public static void CreateRegion(
            Control control,
            Rectangle bounds,
            int radius,
            RoundStyle roundStyle)
        {
            using (GraphicsPath path =
                GraphicsPathHelper.CreatePath(
                bounds, radius, roundStyle, true))
            {
                Region region = new Region(path);
                path.Widen(Pens.White);
                region.Union(path);
                if (control.Region != null)
                {
                    control.Region.Dispose();
                }
                control.Region = region;
            }
        }

        public static void CreateRegion(
            Control control,
            Rectangle bounds,
            int radius)
        {
            CreateRegion(control, bounds, radius, RoundStyle.All);
        }
    }
}
