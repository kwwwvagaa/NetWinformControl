// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="ChartsHelper.cs">
//     Copyright by Huang Zhenghui(»ÆÕý»Ô) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub£ºhttps://github.com/kwwwvagaa/NetWinformControl
// gitee£ºhttps://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System;
// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-17
//
// ***********************************************************************
// <copyright file="Helper.cs">
//     Copyright by Huang Zhenghui(»ÆÕý»Ô) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub£ºhttps://github.com/kwwwvagaa/NetWinformControl
// gitee£ºhttps://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;


namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class Helper.
    /// </summary>
    public class ChartsHelper
    {

        /// <summary>
        /// Draws the string.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="s">The s.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="point">The point.</param>
        /// <param name="format">The format.</param>
        /// <param name="angle">The angle.</param>
        public static void DrawString(Graphics g, string s, Font font, Brush brush, PointF point, StringFormat format, float angle)
        {
            Matrix transform = g.Transform;
            Matrix transform2 = g.Transform;
            transform2.RotateAt(angle, point);
            g.Transform = transform2;
            g.DrawString(s, font, brush, point, format);
            g.Transform = transform;
        }

        /// <summary>
        /// Gets the rhombus from rectangle.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns>Point[].</returns>
        public static Point[] GetRhombusFromRectangle(Rectangle rect)
        {
            return new Point[5]
			{
				new Point(rect.X, rect.Y + rect.Height / 2),
				new Point(rect.X + rect.Width / 2, rect.Y + rect.Height - 1),
				new Point(rect.X + rect.Width - 1, rect.Y + rect.Height / 2),
				new Point(rect.X + rect.Width / 2, rect.Y),
				new Point(rect.X, rect.Y + rect.Height / 2)
			};
        }

        /// <summary>
        /// Computes the paint location y.
        /// </summary>
        /// <param name="max">The maximum.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="height">The height.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Single.</returns>
        public static float ComputePaintLocationY(int max, int min, int height, int value)
        {
            if ((float)(max - min) == 0f)
            {
                return height;
            }
            return (float)height - (float)(value - min) * 1f / (float)(max - min) * (float)height;
        }

        /// <summary>
        /// Computes the paint location y.
        /// </summary>
        /// <param name="max">The maximum.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="height">The height.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.Single.</returns>
        public static float ComputePaintLocationY(float max, float min, float height, float value)
        {
            if (max - min == 0f)
            {
                return height;
            }
            return height - (value - min) / (max - min) * height;
        }
       

        /// <summary>
        /// Paints the coordinate divide.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="penLine">The pen line.</param>
        /// <param name="penDash">The pen dash.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="sf">The sf.</param>
        /// <param name="degree">The degree.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <param name="up">Up.</param>
        /// <param name="down">Down.</param>
        public static void PaintCoordinateDivide(Graphics g, System.Drawing.Pen penLine, System.Drawing.Pen penDash, Font font, System.Drawing.Brush brush, StringFormat sf, int degree, int max, int min, int width, int height, int left = 60, int right = 8, int up = 8, int down = 8)
        {
            for (int i = 0; i <= degree; i++)
            {
                int value = (max - min) * i / degree + min;
                int num = (int)ComputePaintLocationY(max, min, height - up - down, value) + up + 1;
                g.DrawLine(penLine, left - 1, num, left - 4, num);
                if (i != 0)
                {
                    g.DrawLine(penDash, left, num, width - right, num);
                }
                g.DrawString(value.ToString(), font, brush, new Rectangle(-5, num - font.Height / 2, left, font.Height), sf);
            }
        }

        /// <summary>
        /// Paints the triangle.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="point">The point.</param>
        /// <param name="size">The size.</param>
        /// <param name="direction">The direction.</param>
        public static void PaintTriangle(Graphics g, System.Drawing.Brush brush, Point point, int size, GraphDirection direction)
        {
            Point[] array = new Point[4];
            switch (direction)
            {
                case GraphDirection.Leftward:
                    array[0] = new Point(point.X, point.Y - size);
                    array[1] = new Point(point.X, point.Y + size);
                    array[2] = new Point(point.X - 2 * size, point.Y);
                    break;
                case GraphDirection.Rightward:
                    array[0] = new Point(point.X, point.Y - size);
                    array[1] = new Point(point.X, point.Y + size);
                    array[2] = new Point(point.X + 2 * size, point.Y);
                    break;
                case GraphDirection.Upward:
                    array[0] = new Point(point.X - size, point.Y);
                    array[1] = new Point(point.X + size, point.Y);
                    array[2] = new Point(point.X, point.Y - 2 * size);
                    break;
                default:
                    array[0] = new Point(point.X - size, point.Y);
                    array[1] = new Point(point.X + size, point.Y);
                    array[2] = new Point(point.X, point.Y + 2 * size);
                    break;
            }
            array[3] = array[0];
            g.FillPolygon(brush, array);
        }

        /// <summary>
        /// Paints the triangle.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="point">The point.</param>
        /// <param name="size">The size.</param>
        /// <param name="direction">The direction.</param>
        public static void PaintTriangle(Graphics g, System.Drawing.Brush brush, PointF point, int size, GraphDirection direction)
        {
            PointF[] array = new PointF[4];
            switch (direction)
            {
                case GraphDirection.Leftward:
                    array[0] = new PointF(point.X, point.Y - (float)size);
                    array[1] = new PointF(point.X, point.Y + (float)size);
                    array[2] = new PointF(point.X - (float)(2 * size), point.Y);
                    break;
                case GraphDirection.Rightward:
                    array[0] = new PointF(point.X, point.Y - (float)size);
                    array[1] = new PointF(point.X, point.Y + (float)size);
                    array[2] = new PointF(point.X + (float)(2 * size), point.Y);
                    break;
                case GraphDirection.Upward:
                    array[0] = new PointF(point.X - (float)size, point.Y);
                    array[1] = new PointF(point.X + (float)size, point.Y);
                    array[2] = new PointF(point.X, point.Y - (float)(2 * size));
                    break;
                default:
                    array[0] = new PointF(point.X - (float)size, point.Y);
                    array[1] = new PointF(point.X + (float)size, point.Y);
                    array[2] = new PointF(point.X, point.Y + (float)(2 * size));
                    break;
            }
            array[3] = array[0];
            g.FillPolygon(brush, array);
        }

        /// <summary>
        /// Adds the array data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="data">The data.</param>
        /// <param name="max">The maximum.</param>
        public static void AddArrayData<T>(ref T[] array, T[] data, int max)
        {
            if (data == null || data.Length == 0)
            {
                return;
            }
            if (array.Length == max)
            {
                Array.Copy(array, data.Length, array, 0, array.Length - data.Length);
                Array.Copy(data, 0, array, array.Length - data.Length, data.Length);
            }
            else if (array.Length + data.Length > max)
            {
                T[] array2 = new T[max];
                for (int i = 0; i < max - data.Length; i++)
                {
                    array2[i] = array[i + (array.Length - max + data.Length)];
                }
                for (int j = 0; j < data.Length; j++)
                {
                    array2[array2.Length - data.Length + j] = data[j];
                }
                array = array2;
            }
            else
            {
                T[] array3 = new T[array.Length + data.Length];
                for (int k = 0; k < array.Length; k++)
                {
                    array3[k] = array[k];
                }
                for (int l = 0; l < data.Length; l++)
                {
                    array3[array3.Length - data.Length + l] = data[l];
                }
                array = array3;
            }
        }

        /// <summary>
        /// Converts the size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="angle">The angle.</param>
        /// <returns>SizeF.</returns>
        public static SizeF ConvertSize(SizeF size, float angle)
        {
            System.Drawing.Drawing2D.Matrix matrix = new System.Drawing.Drawing2D.Matrix();
            matrix.Rotate(angle);
            PointF[] array = new PointF[4];
            array[0].X = (0f - size.Width) / 2f;
            array[0].Y = (0f - size.Height) / 2f;
            array[1].X = (0f - size.Width) / 2f;
            array[1].Y = size.Height / 2f;
            array[2].X = size.Width / 2f;
            array[2].Y = size.Height / 2f;
            array[3].X = size.Width / 2f;
            array[3].Y = (0f - size.Height) / 2f;
            matrix.TransformPoints(array);
            float num = float.MaxValue;
            float num2 = float.MinValue;
            float num3 = float.MaxValue;
            float num4 = float.MinValue;
            PointF[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                PointF pointF = array2[i];
                if (pointF.X < num)
                {
                    num = pointF.X;
                }
                if (pointF.X > num2)
                {
                    num2 = pointF.X;
                }
                if (pointF.Y < num3)
                {
                    num3 = pointF.Y;
                }
                if (pointF.Y > num4)
                {
                    num4 = pointF.Y;
                }
            }
            return new SizeF(num2 - num, num4 - num3);
        }



        /// <summary>
        /// Gets the pow.
        /// </summary>
        /// <param name="digit">The digit.</param>
        /// <returns>System.Int32.</returns>
        private static int GetPow(int digit)
        {
            int num = 1;
            for (int i = 0; i < digit; i++)
            {
                num *= 10;
            }
            return num;
        }

        /// <summary>
        /// Calculates the maximum section from.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>System.Int32.</returns>
        public static double CalculateMaxSectionFrom(double[] values)
        {
            double num = values.Max();
            return CalculateMaxSection(num);
        }

        public static double CalculateMaxSectionFrom(double[][] values)
        {
            double num = values.Max(p=>p.Max());
            return CalculateMaxSection(num);
        }

        private static double CalculateMaxSection(double num)
        {
            if (num <= 5)
            {
                return 5;
            }
            if (num <= 10)
            {
                return 10;
            }
            int digit = num.ToString().Length - 2;
            int num2 = int.Parse(num.ToString().Substring(0, 2));
            if (num2 < 12)
            {
                return 12 * GetPow(digit);
            }
            if (num2 < 14)
            {
                return 14 * GetPow(digit);
            }
            if (num2 < 16)
            {
                return 16 * GetPow(digit);
            }
            if (num2 < 18)
            {
                return 18 * GetPow(digit);
            }
            if (num2 < 20)
            {
                return 20 * GetPow(digit);
            }
            if (num2 < 22)
            {
                return 22 * GetPow(digit);
            }
            if (num2 < 24)
            {
                return 24 * GetPow(digit);
            }
            if (num2 < 26)
            {
                return 26 * GetPow(digit);
            }
            if (num2 < 28)
            {
                return 28 * GetPow(digit);
            }
            if (num2 < 30)
            {
                return 30 * GetPow(digit);
            }
            if (num2 < 40)
            {
                return 40 * GetPow(digit);
            }
            if (num2 < 50)
            {
                return 50 * GetPow(digit);
            }
            if (num2 < 60)
            {
                return 60 * GetPow(digit);
            }
            if (num2 < 80)
            {
                return 80 * GetPow(digit);
            }
            return 100 * GetPow(digit);
        }

        /// <summary>
        /// Gets the color light.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>System.Drawing.Color.</returns>
        public static System.Drawing.Color GetColorLight(System.Drawing.Color color)
        {
            return System.Drawing.Color.FromArgb(color.R + (255 - color.R) * 40 / 100, color.G + (255 - color.G) * 40 / 100, color.B + (255 - color.B) * 40 / 100);
        }

        /// <summary>
        /// Gets the color light five.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>System.Drawing.Color.</returns>
        public static System.Drawing.Color GetColorLightFive(System.Drawing.Color color)
        {
            return System.Drawing.Color.FromArgb(color.R + (255 - color.R) * 50 / 100, color.G + (255 - color.G) * 50 / 100, color.B + (255 - color.B) * 50 / 100);
        }

        /// <summary>
        /// Gets the points from.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="soureWidth">Width of the soure.</param>
        /// <param name="sourceHeight">Height of the source.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="dx">The dx.</param>
        /// <param name="dy">The dy.</param>
        /// <returns>PointF[].</returns>
        public static PointF[] GetPointsFrom(string points, float soureWidth, float sourceHeight, float width, float height, float dx = 0f, float dy = 0f)
        {
            string[] array = points.Split(new char[1]
			{
				' '
			}, StringSplitOptions.RemoveEmptyEntries);
            PointF[] array2 = new PointF[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int num = array[i].IndexOf(',');
                float num2 = Convert.ToSingle(array[i].Substring(0, num));
                float num3 = Convert.ToSingle(array[i].Substring(num + 1));
                array2[i] = new PointF(width * (num2 + dx) / soureWidth, height * (num3 + dy) / sourceHeight);
            }
            return array2;
        }
    }
}
