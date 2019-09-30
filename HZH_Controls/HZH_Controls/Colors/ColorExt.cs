using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HZH_Controls
{
    public static class ColorExt
    {
        #region 重置内置的颜色    English:Reset color
        public static void ResetColor(
            this BasisColors type,
            Color light,
            Color medium,
            Color dark)
        {
            BasisColors.Light = light;
            BasisColors.Medium = medium;
            BasisColors.Dark = dark;
        }

        public static void ResetColor(
            this BorderColors type,
            Color green,
            Color blue,
            Color red,
            Color yellow)
        {
            BorderColors.Green = green;
            BorderColors.Blue = blue;
            BorderColors.Red = red;
            BorderColors.Yellow = yellow;
        }

        public static void ResetColor(
            this GradientColors type,
            Color[] orange,
            Color[] lightGreen,
            Color[] green,
            Color[] blue,
            Color[] blueGreen,
            Color[] lightViolet,
            Color[] violet,
            Color[] gray
            )
        {
            if (orange != null && orange.Length == 2)
                GradientColors.Orange = orange;
            if (orange != null && orange.Length == 2)
                GradientColors.LightGreen = lightGreen;
            if (orange != null && orange.Length == 2)
                GradientColors.Green = green;
            if (orange != null && orange.Length == 2)
                GradientColors.Blue = blue;
            if (orange != null && orange.Length == 2)
                GradientColors.BlueGreen = blueGreen;
            if (orange != null && orange.Length == 2)
                GradientColors.LightViolet = lightViolet;
            if (orange != null && orange.Length == 2)
                GradientColors.Violet = violet;
            if (orange != null && orange.Length == 2)
                GradientColors.Gray = gray;
        }
        public static void ResetColor(
            this LineColors type,
            Color moreLight,
            Color light,
            Color dark,
            Color moreDark)
        {
            LineColors.MoreLight = moreLight;
            LineColors.Light = light;
            LineColors.Dark = dark;
            LineColors.MoreDark = moreDark;
        }
        public static void ResetColor(
            this StatusColors type,
            Color primary,
            Color success,
            Color warning,
            Color danger,
            Color info
        )
        {
            StatusColors.Primary = primary;
            StatusColors.Success = success;
            StatusColors.Warning = warning;
            StatusColors.Danger = danger;
            StatusColors.Info = info;
        }
        public static void ResetColor(
            this TableColors type,
            Color green,
            Color blue,
            Color red,
            Color yellow,
            Color gray
       )
        {
            TableColors.Green = green;
            TableColors.Blue = blue;
            TableColors.Red = red;
            TableColors.Yellow = yellow;
            TableColors.Gray = gray;
        }

        public static void ResetColor(
            this TextColors type,
            Color moreLight,
            Color light,
            Color dark,
            Color moreDark)
        {
            TextColors.MoreLight = moreLight;
            TextColors.Light = light;
            TextColors.Dark = dark;
            TextColors.MoreDark = moreDark;
        }
        #endregion

        #region 获取一个内置颜色    English:Get a built-in color
        /// <summary>
        /// 功能描述:获取一个内置颜色    English:Get a built-in color
        /// 作　　者:HZH
        /// 创建日期:2019-09-30 11:08:04
        /// 任务编号:POS
        /// </summary>
        /// <param name="t">t</param>
        /// <returns>颜色列表</returns>
        public static Color[] GetInternalColor<T>(T t)
        {
            Type type = null;
            if (t is BasisColorsTypes)
            {
                type = typeof(BasisColors);
            }
            if (type == null)
                return new Color[] { Color.Empty };
            else
            {
                string strName = t.ToString();
                var pi = type.GetProperty(strName);
                if (pi == null)
                    return new Color[] { Color.Empty };
                else
                {
                    var c = pi.GetValue(null, null);
                    if (c == null)
                        return new Color[] { Color.Empty };
                    else if (c is Color[])
                        return (Color[])c;
                    else
                        return new Color[] { (Color)c };
                }
            }
        }
        #endregion
    }
}
