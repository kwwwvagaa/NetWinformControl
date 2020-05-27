using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace HZH_Controls.Controls
{
    public class ProfessionalToolStripRendererEx 
        : ToolStripRenderer
    {
        private static readonly int OffsetMargin = 24;
        private const int m_radius = 2;
        private const int m_borderRadius = 2;
        private string _menuLogoString = "";
        private ToolStripColorTable _colorTable;

        public ProfessionalToolStripRendererEx()
            : base()
        {
        }

        public ProfessionalToolStripRendererEx(
            ToolStripColorTable colorTable) : base()
        {
            _colorTable = colorTable;
        }

        public string MenuLogoString
        {
            get { return _menuLogoString; }
            set { _menuLogoString = value; }
        }

        protected virtual ToolStripColorTable ColorTable
        {
            get
            {
                if (_colorTable == null)
                {
                    _colorTable = new ToolStripColorTable();
                }
                return _colorTable;
            }
        }

        protected override void OnRenderToolStripBackground(
            ToolStripRenderEventArgs e)
        {           
            ToolStrip toolStrip = e.ToolStrip;
            Graphics g = e.Graphics;
            Rectangle bounds = e.AffectedBounds;

            if (toolStrip is ToolStripDropDown)
            {
                RegionHelper.CreateRegion(toolStrip, bounds, m_borderRadius);
                using (SolidBrush brush = new SolidBrush(ColorTable.BackNormal))
                {
                    g.FillRectangle(brush, bounds);
                }
            }
            else if (toolStrip is MenuStrip)
            {              
                RenderHelper.RenderBackgroundInternal(
                    g,
                    bounds,
                    ColorTable.Base,
                    ColorTable.Border,
                    RoundStyle.None,
                    0,
                    .35f,
                    false,
                    false);
            }
            else
            {
                base.OnRenderToolStripBackground(e);
            }
        }

        protected override void OnRenderImageMargin(
            ToolStripRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics g = e.Graphics;
            Rectangle bounds = e.AffectedBounds;

            if (toolStrip is ToolStripDropDown)
            {
                bool bDrawLogo = NeedDrawLogo(toolStrip);
                bool bRightToLeft = toolStrip.RightToLeft == RightToLeft.Yes;

                Rectangle imageBackRect = bounds;
                imageBackRect.Width = OffsetMargin;

                if (bDrawLogo)
                {
                    Rectangle logoRect = bounds;
                    logoRect.Width = OffsetMargin;
                    if (bRightToLeft)
                    {
                        logoRect.X -= 2;
                        imageBackRect.X = logoRect.X - OffsetMargin;
                    }
                    else
                    {
                        logoRect.X += 2;
                        imageBackRect.X = logoRect.Right;
                    }
                    logoRect.Y += 1;
                    logoRect.Height -= 2;

                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        logoRect,
                        ColorTable.BackHover,
                        ColorTable.BackNormal,
                        90f))
                    {
                        Blend blend = new Blend();
                        blend.Positions = new float[] { 0f, .2f, 1f };
                        blend.Factors = new float[] { 0f, 0.1f, .9f };
                        brush.Blend = blend;
                        logoRect.Y += 1;
                        logoRect.Height -= 2;
                        using (GraphicsPath path =
                            GraphicsPathHelper.CreatePath(logoRect, 8, RoundStyle.All, false))
                        {
                            using (SmoothingModeGraphics sg = new SmoothingModeGraphics(g))
                            {
                                g.FillPath(brush, path);
                            }
                        }
                    }

                    StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
                    Font font = new Font(
                        toolStrip.Font.FontFamily, 11, FontStyle.Bold);
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Trimming = StringTrimming.EllipsisCharacter;

                    g.TranslateTransform(logoRect.X, logoRect.Bottom);
                    g.RotateTransform(270f);

                    if (!string.IsNullOrEmpty(MenuLogoString))
                    {
                        Rectangle newRect = new Rectangle(
                            0, 0, logoRect.Height, logoRect.Width);

                        using (Brush brush = new SolidBrush(ColorTable.Fore))
                        {
                            using (TextRenderingHintGraphics tg = 
                                new TextRenderingHintGraphics(g))
                            {
                                g.DrawString(
                                    MenuLogoString,
                                    font,
                                    brush,
                                    newRect,
                                    sf);
                            }
                        }
                    }

                    g.ResetTransform();
                }
                else
                {
                    if (bRightToLeft)
                    {
                        imageBackRect.X -= 3;
                    }
                    else
                    {
                        imageBackRect.X += 3;
                    }
                }

                imageBackRect.Y += 2;
                imageBackRect.Height -= 4;
                using (SolidBrush brush = new SolidBrush(ColorTable.DropDownImageBack))
                {
                    g.FillRectangle(brush, imageBackRect);
                }

                Point ponitStart;
                Point pointEnd;
                if (bRightToLeft)
                {
                    ponitStart = new Point(imageBackRect.X, imageBackRect.Y);
                    pointEnd = new Point(imageBackRect.X, imageBackRect.Bottom);
                }
                else
                {
                    ponitStart = new Point(imageBackRect.Right - 1, imageBackRect.Y);
                    pointEnd = new Point(imageBackRect.Right - 1, imageBackRect.Bottom);
                }

                using (Pen pen = new Pen(ColorTable.DropDownImageSeparator))
                {
                    g.DrawLine(pen, ponitStart, pointEnd);
                }
            }
            else
            {
                base.OnRenderImageMargin(e);
            }
        }

        protected override void OnRenderToolStripBorder(
            ToolStripRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics g = e.Graphics;
            Rectangle bounds = e.AffectedBounds;

            if (toolStrip is ToolStripDropDown)
            {
                using (SmoothingModeGraphics sg = new SmoothingModeGraphics(g))
                {
                    using (GraphicsPath path =
                        GraphicsPathHelper.CreatePath(bounds, 8, RoundStyle.All, true))
                    {
                        using (Pen pen = new Pen(ColorTable.DropDownImageSeparator))
                        {
                            path.Widen(pen);
                            g.DrawPath(pen, path);
                        }
                    }
                }

                bounds.Inflate(-1, -1);
                using (GraphicsPath innerPath = GraphicsPathHelper.CreatePath(
                    bounds, 8, RoundStyle.All, true))
                {
                    using (Pen pen = new Pen(ColorTable.BackNormal))
                    {
                        g.DrawPath(pen, innerPath);
                    }
                }
            }
            else if (toolStrip is StatusStrip)
            {
                using (Pen pen = new Pen(ColorTable.Border))
                {
                    e.Graphics.DrawRectangle(
                        pen, 0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
                }
            }
            else if (toolStrip is MenuStrip)
            {
                base.OnRenderToolStripBorder(e);
            }
            else
            {
                using (Pen pen = new Pen(ColorTable.Border))
                {
                    g.DrawRectangle(
                        pen, 0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
                }
            }
        }

        protected override void OnRenderMenuItemBackground(
           ToolStripItemRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            ToolStripItem item = e.Item;

            if (!item.Enabled)
            {
                return;
            }

            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);

            if (toolStrip is MenuStrip)
            {
                if (item.Selected)
                {
                    RenderHelper.RenderBackgroundInternal(
                        g,
                        rect,
                        ColorTable.BackHover,
                        ColorTable.BackHover,
                        RoundStyle.All,
                        m_radius,
                        true,
                        true);
                }
                else if (item.Pressed)
                {
                    RenderHelper.RenderBackgroundInternal(
                       g,
                       rect,
                       ColorTable.BackPressed,
                       ColorTable.BackPressed,
                       RoundStyle.All,
                       m_radius,
                       true,
                       true);
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }
            else if (toolStrip is ToolStripDropDown)
            {
                bool bDrawLogo = NeedDrawLogo(toolStrip);

                int offsetMargin = bDrawLogo ? OffsetMargin : 0;

                if (item.RightToLeft == RightToLeft.Yes)
                {
                    rect.X += 4;
                }
                else
                {
                    rect.X += offsetMargin + 4;
                }
                rect.Width -= offsetMargin + 8;
                rect.Height--;

                if (item.Selected)
                {
                    RenderHelper.RenderBackgroundInternal(
                       g,
                       rect,
                       ColorTable.BackHover,
                       ColorTable.BackHover,
                       RoundStyle.All,
                       m_radius,
                       true,
                       true);
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }

        protected override void OnRenderItemImage(
            ToolStripItemImageRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics g = e.Graphics;

            if (toolStrip is ToolStripDropDown &&
               e.Item is ToolStripMenuItem)
            {
                bool bDrawLogo = NeedDrawLogo(toolStrip);
                int offsetMargin = bDrawLogo ? OffsetMargin : 0;

                ToolStripMenuItem item = (ToolStripMenuItem)e.Item;
                if (item.Checked)
                {
                    return;
                }
                Rectangle rect = e.ImageRectangle;
                if (e.Item.RightToLeft == RightToLeft.Yes)
                {
                    rect.X -= offsetMargin + 2;
                }
                else
                {
                    rect.X += offsetMargin + 2;
                }

                using (InterpolationModeGraphics ig = 
                    new InterpolationModeGraphics(g))
                {
                    ToolStripItemImageRenderEventArgs ne =
                        new ToolStripItemImageRenderEventArgs(
                        g, e.Item, e.Image, rect);
                    base.OnRenderItemImage(ne);
                }
            }
            else
            {
                base.OnRenderItemImage(e);
            }
        }

        protected override void OnRenderItemText(
            ToolStripItemTextRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;

            e.TextColor = ColorTable.Fore;

            if (toolStrip is ToolStripDropDown &&
                e.Item is ToolStripMenuItem)
            {
                bool bDrawLogo = NeedDrawLogo(toolStrip);

                int offsetMargin = bDrawLogo ? 18 : 0;

                Rectangle rect = e.TextRectangle;
                if (e.Item.RightToLeft == RightToLeft.Yes)
                {
                    rect.X -= offsetMargin;
                }
                else
                {
                    rect.X += offsetMargin;
                }
                rect.Height = e.Item.Height;
                rect.Y = 0;
               
                e.TextRectangle = rect;
            }
            e.Graphics.DrawString(e.Text, e.TextFont, new SolidBrush(e.TextColor), e.TextRectangle, new StringFormat() { LineAlignment= StringAlignment.Center });
            //base.OnRenderItemText(e);
        }

        protected override void OnRenderItemCheck(
            ToolStripItemImageRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics g = e.Graphics;

            if (toolStrip is ToolStripDropDown &&
               e.Item is ToolStripMenuItem)
            {
                bool bDrawLogo = NeedDrawLogo(toolStrip);
                int offsetMargin = bDrawLogo ? OffsetMargin : 0;
                Rectangle rect = e.ImageRectangle;

                if (e.Item.RightToLeft == RightToLeft.Yes)
                {
                    rect.X -= offsetMargin + 2;
                }
                else
                {
                    rect.X += offsetMargin + 2;
                }

                rect.Width = 13;
                rect.Y += 1;
                rect.Height -= 3;

                using (SmoothingModeGraphics sg = new SmoothingModeGraphics(g))
                {
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddRectangle(rect);
                        using (PathGradientBrush brush = new PathGradientBrush(path))
                        {
                            brush.CenterColor = Color.White;
                            brush.SurroundColors = new Color[] { ControlPaint.Light(ColorTable.BackNormal) };
                            Blend blend = new Blend();
                            blend.Positions = new float[] { 0f, 0.3f, 1f };
                            blend.Factors = new float[] { 0f, 0.5f, 1f };
                            brush.Blend = blend;
                            g.FillRectangle(brush, rect);
                        }
                    }

                    using (Pen pen = new Pen(ControlPaint.Light(ColorTable.BackNormal)))
                    {
                        g.DrawRectangle(pen, rect);
                    }

                    ControlPaintEx.DrawCheckedFlag(g, rect, ColorTable.Fore);
                }
            }
            else
            {
                base.OnRenderItemCheck(e);
            }
        }

        protected override void OnRenderArrow(
            ToolStripArrowRenderEventArgs e)
        {
            if (e.Item.Enabled)
            {
                e.ArrowColor = ColorTable.Fore;
            }

            ToolStrip toolStrip = e.Item.Owner;

            if (toolStrip is ToolStripDropDown &&
                e.Item is ToolStripMenuItem)
            {
                bool bDrawLogo = NeedDrawLogo(toolStrip);

                int offsetMargin = bDrawLogo ? 3 : 0;

                Rectangle rect = e.ArrowRectangle;
                if (e.Item.RightToLeft == RightToLeft.Yes)
                {
                    rect.X -= offsetMargin;
                }
                else
                {
                    rect.X += offsetMargin;
                }

                e.ArrowRectangle = rect;
            }

            base.OnRenderArrow(e);
        }

        protected override void OnRenderSeparator(
            ToolStripSeparatorRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Rectangle rect = e.Item.ContentRectangle;
            Graphics g = e.Graphics;

            if (toolStrip is ToolStripDropDown)
            {
                bool bDrawLogo = NeedDrawLogo(toolStrip);

                int offsetMargin = bDrawLogo ? 
                    OffsetMargin * 2 : OffsetMargin;

                if (e.Item.RightToLeft != RightToLeft.Yes)
                {
                    rect.X += offsetMargin + 2;
                }
                rect.Width -= offsetMargin + 4;
            }

            RenderSeparatorLine(
               g,
               rect,
               ColorTable.DropDownImageSeparator,
               ColorTable.BackNormal,
               SystemColors.ControlLightLight,
               e.Vertical);
        }

        internal void RenderSeparatorLine(
            Graphics g,
            Rectangle rect,
            Color baseColor,
            Color backColor,
            Color shadowColor,
            bool vertical)
        {
            float angle;
            if (vertical)
            {
                angle = 90F;
            }
            else
            {
                angle = 180F;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect,
                    baseColor,
                    backColor,
                    angle))
            {
                Blend blend = new Blend();
                blend.Positions = new float[] { 0f, .2f, .5f, .8f, 1f };
                blend.Factors = new float[] { 1f, .3f, 0f, .3f, 1f };
                brush.Blend = blend;
                using (Pen pen = new Pen(brush))
                {
                    if (vertical)
                    {
                        g.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Bottom);
                    }
                    else
                    {
                        g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
                    }

                    brush.LinearColors = new Color[] {
                        shadowColor, ColorTable.BackNormal };
                    pen.Brush = brush;
                    if (vertical)
                    {
                        g.DrawLine(pen, rect.X + 1, rect.Y, rect.X + 1, rect.Bottom);
                    }
                    else
                    {
                        g.DrawLine(pen, rect.X, rect.Y + 1, rect.Right, rect.Y + 1);
                    }
                }
            }
        }

        internal bool NeedDrawLogo(ToolStrip toolStrip)
        {
            ToolStripDropDown dropDown = toolStrip as ToolStripDropDown;
            bool bDrawLogo =
                (dropDown.OwnerItem != null &&
                dropDown.OwnerItem.Owner is MenuStrip) ||
                (toolStrip is ContextMenuStrip);
            //return bDrawLogo;
            return false;
        }
    }
}
