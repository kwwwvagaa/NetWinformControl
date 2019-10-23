// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-30
//
// ***********************************************************************
// <copyright file="ColorExt.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HZH_Controls
{
    /// <summary>
    /// Class ColorExt.
    /// </summary>
    public static class ColorExt
    {
        #region 重置内置的颜色    English:Reset color
        /// <summary>
        /// Resets the color.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="light">The light.</param>
        /// <param name="medium">The medium.</param>
        /// <param name="dark">The dark.</param>
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

        /// <summary>
        /// Resets the color.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        /// <param name="red">The red.</param>
        /// <param name="yellow">The yellow.</param>
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

        /// <summary>
        /// Resets the color.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="orange">The orange.</param>
        /// <param name="lightGreen">The light green.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        /// <param name="blueGreen">The blue green.</param>
        /// <param name="lightViolet">The light violet.</param>
        /// <param name="violet">The violet.</param>
        /// <param name="gray">The gray.</param>
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
        /// <summary>
        /// Resets the color.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="moreLight">The more light.</param>
        /// <param name="light">The light.</param>
        /// <param name="dark">The dark.</param>
        /// <param name="moreDark">The more dark.</param>
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
        /// <summary>
        /// Resets the color.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="primary">The primary.</param>
        /// <param name="success">The success.</param>
        /// <param name="warning">The warning.</param>
        /// <param name="danger">The danger.</param>
        /// <param name="info">The information.</param>
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
        /// <summary>
        /// Resets the color.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        /// <param name="red">The red.</param>
        /// <param name="yellow">The yellow.</param>
        /// <param name="gray">The gray.</param>
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

        /// <summary>
        /// Resets the color.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="moreLight">The more light.</param>
        /// <param name="light">The light.</param>
        /// <param name="dark">The dark.</param>
        /// <param name="moreDark">The more dark.</param>
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
        /// <typeparam name="T"></typeparam>
        /// <param name="t">t</param>
        /// <returns>颜色列表</returns>
        public static Color[] GetInternalColor<T>(T t)
        {
            Type type = null;
            if (t is BasisColorsTypes)
            {
                type = typeof(BasisColors);
            }
            else if (t is BorderColorsTypes)
            {
                type = typeof(BorderColors);
            }
            else if (t is GradientColorsTypes)
            {
                type = typeof(GradientColors);
            }
            else if (t is LineColorsTypes)
            {
                type = typeof(LineColors);
            }
            else if (t is StatusColorsTypes)
            {
                type = typeof(StatusColors);
            }
            else if (t is TableColorsTypes)
            {
                type = typeof(TableColors);
            }
            else if (t is TextColorsTypes)
            {
                type = typeof(TextColors);
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
