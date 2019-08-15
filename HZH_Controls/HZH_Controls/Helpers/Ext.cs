// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：Ext.cs
// 创建日期：2019-08-15 16:05:40
// 功能描述：Ext
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HZH_Controls
{
    public static partial class Ext
    {
        public static T CloneModel<T>(this T classObject) where T : class
        {
            T result;
            if (classObject == null)
            {
                result = default(T);
            }
            else
            {
                object obj = Activator.CreateInstance(typeof(T));
                PropertyInfo[] properties = typeof(T).GetProperties();
                PropertyInfo[] array = properties;
                for (int i = 0; i < array.Length; i++)
                {
                    PropertyInfo propertyInfo = array[i];
                    if (propertyInfo.CanWrite)
                        propertyInfo.SetValue(obj, propertyInfo.GetValue(classObject, null), null);
                }
                result = (obj as T);
            }
            return result;
        }

        #region 转换为base64字符串
        /// <summary>
        /// 功能描述:转换为base64字符串
        /// 作　　者:HZH
        /// 创建日期:2019-03-29 10:12:38
        /// 任务编号:POS
        /// </summary>
        /// <param name="data">data</param>
        /// <returns>返回值</returns>
        public static string ToBase64Str(this string data)
        {
            if (data.IsEmpty())
                return string.Empty;
            byte[] buffer = Encoding.Default.GetBytes(data);
            return Convert.ToBase64String(buffer);
        }
        #endregion
        /// <summary>
        /// 转换为坐标
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static System.Drawing.Point ToPoint(this string data)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(data, @"^\s*\d+(\.\d+)?\s*\,\s*\d+(\.\d+)?\s*$"))
            {
                return System.Drawing.Point.Empty;
            }
            else
            {
                string[] strs = data.Split(',');
                return new System.Drawing.Point(strs[0].ToInt(), strs[1].ToInt());
            }
        }

        #region 数值转换
        /// <summary>
        /// 转换为整型
        /// </summary>
        /// <param name="data">数据</param>
        public static int ToInt(this object data)
        {
            if (data == null)
                return 0;
            if (data is bool)
            {
                return (bool)data ? 1 : 0;
            }
            int result;
            var success = int.TryParse(data.ToString(), out result);
            if (success)
                return result;
            try
            {
                return Convert.ToInt32(ToDouble(data, 0));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换为可空整型
        /// </summary>
        /// <param name="data">数据</param>
        public static int? ToIntOrNull(this object data)
        {
            if (data == null)
                return null;
            int result;
            bool isValid = int.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 转换为双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static double ToDouble(this object data)
        {
            if (data == null)
                return 0;
            double result;
            return double.TryParse(data.ToString(), out result) ? result : 0;
        }

        /// <summary>
        /// 转换为双精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static double ToDouble(this object data, int digits)
        {
            return Math.Round(ToDouble(data), digits, System.MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 转换为可空双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static double? ToDoubleOrNull(this object data)
        {
            if (data == null)
                return null;
            double result;
            bool isValid = double.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 转换为高精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static decimal ToDecimal(this object data)
        {
            if (data == null)
                return 0;
            decimal result;
            return decimal.TryParse(data.ToString(), out result) ? result : 0;
        }

        /// <summary>
        /// 转换为高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal ToDecimal(this  object data, int digits)
        {
            return Math.Round(ToDecimal(data), digits, System.MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 转换为可空高精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static decimal? ToDecimalOrNull(this  object data)
        {
            if (data == null)
                return null;
            decimal result;
            bool isValid = decimal.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 转换为可空高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal? ToDecimalOrNull(this object data, int digits)
        {
            var result = ToDecimalOrNull(data);
            if (result == null)
                return null;
            return Math.Round(result.Value, digits, System.MidpointRounding.AwayFromZero);
        }

        #endregion

        #region 日期转换
        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="data">数据</param>
        public static DateTime ToDate(this object data)
        {
            try
            {
                if (data == null)
                    return DateTime.MinValue;
                if (System.Text.RegularExpressions.Regex.IsMatch(data.ToStringExt(), @"^\d{8}$"))
                {
                    string strValue = data.ToStringExt();
                    return new DateTime(strValue.Substring(0, 4).ToInt(), strValue.Substring(4, 2).ToInt(), strValue.Substring(6, 2).ToInt());
                }
                DateTime result;
                return DateTime.TryParse(data.ToString(), out result) ? result : DateTime.MinValue;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        /// <param name="data">数据</param>
        public static DateTime? ToDateOrNull(this object data)
        {
            try
            {
                if (data == null)
                    return null;
                if (System.Text.RegularExpressions.Regex.IsMatch(data.ToStringExt(), @"^\d{8}$"))
                {
                    string strValue = data.ToStringExt();
                    return new DateTime(strValue.Substring(0, 4).ToInt(), strValue.Substring(4, 2).ToInt(), strValue.Substring(6, 2).ToInt());
                }
                DateTime result;
                bool isValid = DateTime.TryParse(data.ToString(), out result);
                if (isValid)
                    return result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region 布尔转换
        /// <summary>
        /// 转换为布尔值
        /// </summary>
        /// <param name="data">数据</param>
        public static bool ToBool(this object data)
        {
            if (data == null)
                return false;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            bool result;
            return bool.TryParse(data.ToString(), out result) && result;
        }

        /// <summary>
        /// 获取布尔值
        /// </summary>
        private static bool? GetBool(this object data)
        {
            switch (data.ToString().Trim().ToLower())
            {
                case "0":
                    return false;
                case "1":
                    return true;
                case "是":
                    return true;
                case "否":
                    return false;
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    return null;
            }
        }

        /// <summary>
        /// 转换为可空布尔值
        /// </summary>
        /// <param name="data">数据</param>
        public static bool? ToBoolOrNull(this object data)
        {
            if (data == null)
                return null;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            bool result;
            bool isValid = bool.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        #endregion

        #region 字符串转换
        /// <summary>
        /// 字符串转换为byte[]
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string data)
        {
            return System.Text.Encoding.GetEncoding("GBK").GetBytes(data);
        }
        public static byte[] ToBytesDefault(this string data)
        {
            return System.Text.Encoding.Default.GetBytes(data);
        }
        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="data">数据</param>
        public static string ToStringExt(this object data)
        {
            return data == null ? string.Empty : data.ToString();
        }
        #endregion

        /// <summary>
        /// 安全返回值
        /// </summary>
        /// <param name="value">可空值</param>
        public static T SafeValue<T>(this T? value) where T : struct
        {
            return value ?? default(T);
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this Guid? value)
        {
            if (value == null)
                return true;
            return IsEmpty(value.Value);
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this Guid value)
        {
            if (value == Guid.Empty)
                return true;
            return false;
        }
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this object value)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #region 是否数字
        /// <summary>
        /// 功能描述:是否数字
        /// 作　　者:HZH
        /// 创建日期:2019-03-06 09:03:05
        /// 任务编号:POS
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>返回值</returns>
        public static bool IsNum(this string value)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d+(\.\d*)?$");
        }
        #endregion

    }
}
