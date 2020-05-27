using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HZH_Controls.Controls
{
    internal class RenderHelper
    {
        internal static void RenderBackgroundInternal(
            Graphics g,
            Rectangle rect,
            Color baseColor,
            Color borderColor,
            RoundStyle style,
            bool drawBorder,
            bool drawGlass)
        {
            RenderBackgroundInternal(
                g,
                rect,
                baseColor,
                borderColor,
                style,
                8,
                drawBorder,
                drawGlass);
        }

        internal static void RenderBackgroundInternal(
           Graphics g,
           Rectangle rect,
           Color baseColor,
           Color borderColor,
           RoundStyle style,
           int roundWidth,
           bool drawBorder,
           bool drawGlass)
        {
            RenderBackgroundInternal(
                 g,
                 rect,
                 baseColor,
                 borderColor,
                 style,
                 roundWidth,
                 0.45f,
                 drawBorder,
                 drawGlass);
        }

        internal static void RenderBackgroundInternal(
           Graphics g,
           Rectangle rect,
           Color baseColor,
           Color borderColor,
           RoundStyle style,
           int roundWidth,
           float basePosition,
           bool drawBorder,
           bool drawGlass)
        {
            if (drawBorder)
            {
                rect.Width--;
                rect.Height--;
            }

            
                if (style != RoundStyle.None)
                {
                    using (GraphicsPath path =
                        GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                    {
                        g.FillPath(new SolidBrush(baseColor), path);
                    }

                    //if (baseColor.A > 80)
                    //{
                    //    Rectangle rectTop = rect;
                    //  
                    //    using (GraphicsPath pathTop = GraphicsPathHelper.CreatePath(
                    //        rectTop, roundWidth, RoundStyle.Top, false))
                    //    {
                    //        using (SolidBrush brushAlpha =
                    //            new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
                    //        {
                    //            g.FillPath(brushAlpha, pathTop);
                    //        }
                    //    }
                    //}

                    //if (drawGlass)
                    //{
                    //    RectangleF glassRect = rect;
                    //    if (mode == LinearGradientMode.Vertical)
                    //    {
                    //        glassRect.Y = rect.Y + rect.Height * basePosition;
                    //        glassRect.Height = (rect.Height - rect.Height * basePosition) * 2;
                    //    }
                    //    else
                    //    {
                    //        glassRect.X = rect.X + rect.Width * basePosition;
                    //        glassRect.Width = (rect.Width - rect.Width * basePosition) * 2;
                    //    }
                    //    ControlPaintEx.DrawGlass(g, glassRect, 170, 0);
                    //}

                    if (drawBorder)
                    {
                        using (GraphicsPath path =
                            GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                        {
                            using (Pen pen = new Pen(borderColor))
                            {
                                g.DrawPath(pen, path);
                            }
                        }

                        rect.Inflate(-1, -1);
                        //using (GraphicsPath path =
                        //    GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                        //{
                        //    using (Pen pen = new Pen(innerBorderColor))
                        //    {
                        //        g.DrawPath(pen, path);
                        //    }
                        //}
                    }
                }
                else
                {
                    g.FillRectangle(new SolidBrush(baseColor), rect);
                    //if (baseColor.A > 80)
                    //{
                    //    Rectangle rectTop = rect;
                    //    if (mode == LinearGradientMode.Vertical)
                    //    {
                    //        rectTop.Height = (int)(rectTop.Height * basePosition);
                    //    }
                    //    else
                    //    {
                    //        rectTop.Width = (int)(rect.Width * basePosition);
                    //    }
                    //    using (SolidBrush brushAlpha =
                    //        new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
                    //    {
                    //        g.FillRectangle(brushAlpha, rectTop);
                    //    }
                    //}

                    //if (drawGlass)
                    //{
                    //    RectangleF glassRect = rect;
                    //    if (mode == LinearGradientMode.Vertical)
                    //    {
                    //        glassRect.Y = rect.Y + rect.Height * basePosition;
                    //        glassRect.Height = (rect.Height - rect.Height * basePosition) * 2;
                    //    }
                    //    else
                    //    {
                    //        glassRect.X = rect.X + rect.Width * basePosition;
                    //        glassRect.Width = (rect.Width - rect.Width * basePosition) * 2;
                    //    }
                    //    ControlPaintEx.DrawGlass(g, glassRect, 200, 0);
                    //}

                    if (drawBorder)
                    {
                        using (Pen pen = new Pen(borderColor))
                        {
                            g.DrawRectangle(pen, rect);
                        }

                        rect.Inflate(-1, -1);
                        //using (Pen pen = new Pen(innerBorderColor))
                        //{
                        //    g.DrawRectangle(pen, rect);
                        //}
                    }
                }
           
        }

        internal static Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            if (a + a0 > 255) { a = 255; } else { a = Math.Max(0, a + a0); }
            if (r + r0 > 255) { r = 255; } else { r = Math.Max(0, r + r0); }
            if (g + g0 > 255) { g = 255; } else { g = Math.Max(0, g + g0); }
            if (b + b0 > 255) { b = 255; } else { b = Math.Max(0, b + b0); }

            return Color.FromArgb(a, r, g, b);
        }
    }
}
