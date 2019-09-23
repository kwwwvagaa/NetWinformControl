// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 2019-09-23
//
// ***********************************************************************
// <copyright file="UCCurve.cs">
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    /// <summary>
    /// Class UCCurve.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCCurve : UserControl
    {
        /// <summary>
        /// The value count maximum
        /// </summary>
        private const int value_count_max = 4096;

        /// <summary>
        /// The value maximum left
        /// </summary>
        private float value_max_left = 100f;

        /// <summary>
        /// The value minimum left
        /// </summary>
        private float value_min_left = 0f;

        /// <summary>
        /// The value maximum right
        /// </summary>
        private float value_max_right = 100f;

        /// <summary>
        /// The value minimum right
        /// </summary>
        private float value_min_right = 0f;

        /// <summary>
        /// The value segment
        /// </summary>
        private int value_Segment = 5;

        /// <summary>
        /// The value is abscissa strech
        /// </summary>
        private bool value_IsAbscissaStrech = false;

        /// <summary>
        /// The value strech data count maximum
        /// </summary>
        private int value_StrechDataCountMax = 300;

        /// <summary>
        /// The value is render dash line
        /// </summary>
        private bool value_IsRenderDashLine = true;

        /// <summary>
        /// The text format
        /// </summary>
        private string textFormat = "HH:mm";

        /// <summary>
        /// The value interval abscissa text
        /// </summary>
        private int value_IntervalAbscissaText = 100;

        /// <summary>
        /// The random
        /// </summary>
        private Random random = null;

        /// <summary>
        /// The value title
        /// </summary>
        private string value_title = "";

        /// <summary>
        /// The left right
        /// </summary>
        private int leftRight = 50;

        /// <summary>
        /// Up dowm
        /// </summary>
        private int upDowm = 50;

        /// <summary>
        /// The data list
        /// </summary>
        private Dictionary<string, CurveItem> data_list = null;

        /// <summary>
        /// The data text
        /// </summary>
        private string[] data_text = null;

        /// <summary>
        /// The auxiliary lines
        /// </summary>
        private List<AuxiliaryLine> auxiliary_lines;

        /// <summary>
        /// The auxiliary labels
        /// </summary>
        private List<AuxiliaryLable> auxiliary_Labels;

        /// <summary>
        /// The mark texts
        /// </summary>
        private List<MarkText> MarkTexts;

        /// <summary>
        /// The font size9
        /// </summary>
        private Font font_size9 = null;

        /// <summary>
        /// The font size12
        /// </summary>
        private Font font_size12 = null;

        /// <summary>
        /// The brush deep
        /// </summary>
        private Brush brush_deep = null;

        /// <summary>
        /// The pen normal
        /// </summary>
        private Pen pen_normal = null;

        /// <summary>
        /// The pen dash
        /// </summary>
        private Pen pen_dash = null;

        /// <summary>
        /// The color normal
        /// </summary>
        private Color color_normal = Color.DeepPink;

        /// <summary>
        /// The color deep
        /// </summary>
        private Color color_deep = Color.DimGray;

        /// <summary>
        /// The color dash
        /// </summary>
        private Color color_dash = Color.FromArgb(232, 232, 232);

        /// <summary>
        /// The color mark font
        /// </summary>
        private Color color_mark_font = Color.DodgerBlue;

        /// <summary>
        /// The brush mark font
        /// </summary>
        private Brush brush_mark_font = Brushes.DodgerBlue;

        /// <summary>
        /// The format left
        /// </summary>
        private StringFormat format_left = null;

        /// <summary>
        /// The format right
        /// </summary>
        private StringFormat format_right = null;

        /// <summary>
        /// The format center
        /// </summary>
        private StringFormat format_center = null;

        /// <summary>
        /// The is render right coordinate
        /// </summary>
        private bool isRenderRightCoordinate = true;

        /// <summary>
        /// The curve name width
        /// </summary>
        private int curveNameWidth = 100;

        /// <summary>
        /// The components
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 获取或设置控件的背景色。
        /// </summary>
        /// <value>The color of the back.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Browsable(true)]
        [Description("获取或设置控件的背景色")]
        [Category("自定义")]
        [DefaultValue(typeof(Color), "Transparent")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the value maximum left.
        /// </summary>
        /// <value>The value maximum left.</value>
        [Category("自定义")]
        [Description("获取或设置图形的左纵坐标的最大值，该值必须大于最小值")]
        [Browsable(true)]
        [DefaultValue(100f)]
        public float ValueMaxLeft
        {
            get
            {
                return value_max_left;
            }
            set
            {
                value_max_left = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value minimum left.
        /// </summary>
        /// <value>The value minimum left.</value>
        [Category("自定义")]
        [Description("获取或设置图形的左纵坐标的最小值，该值必须小于最大值")]
        [Browsable(true)]
        [DefaultValue(0f)]
        public float ValueMinLeft
        {
            get
            {
                return value_min_left;
            }
            set
            {
                value_min_left = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value maximum right.
        /// </summary>
        /// <value>The value maximum right.</value>
        [Category("自定义")]
        [Description("获取或设置图形的右纵坐标的最大值，该值必须大于最小值")]
        [Browsable(true)]
        [DefaultValue(100f)]
        public float ValueMaxRight
        {
            get
            {
                return value_max_right;
            }
            set
            {
                value_max_right = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value minimum right.
        /// </summary>
        /// <value>The value minimum right.</value>
        [Category("自定义")]
        [Description("获取或设置图形的右纵坐标的最小值，该值必须小于最大值")]
        [Browsable(true)]
        [DefaultValue(0f)]
        public float ValueMinRight
        {
            get
            {
                return value_min_right;
            }
            set
            {
                value_min_right = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value segment.
        /// </summary>
        /// <value>The value segment.</value>
        [Category("自定义")]
        [Description("获取或设置图形的纵轴分段数")]
        [Browsable(true)]
        [DefaultValue(5)]
        public int ValueSegment
        {
            get
            {
                return value_Segment;
            }
            set
            {
                value_Segment = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is abscissa strech.
        /// </summary>
        /// <value><c>true</c> if this instance is abscissa strech; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("获取或设置所有的数据是否强制在一个界面里显示")]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool IsAbscissaStrech
        {
            get
            {
                return value_IsAbscissaStrech;
            }
            set
            {
                value_IsAbscissaStrech = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the strech data count maximum.
        /// </summary>
        /// <value>The strech data count maximum.</value>
        [Category("自定义")]
        [Description("获取或设置拉伸模式下的最大数据量")]
        [Browsable(true)]
        [DefaultValue(300)]
        public int StrechDataCountMax
        {
            get
            {
                return value_StrechDataCountMax;
            }
            set
            {
                value_StrechDataCountMax = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is render dash line.
        /// </summary>
        /// <value><c>true</c> if this instance is render dash line; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("获取或设置虚线是否进行显示")]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool IsRenderDashLine
        {
            get
            {
                return value_IsRenderDashLine;
            }
            set
            {
                value_IsRenderDashLine = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color lines and text.
        /// </summary>
        /// <value>The color lines and text.</value>
        [Category("自定义")]
        [Description("获取或设置坐标轴及相关信息文本的颜色")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "DimGray")]
        public Color ColorLinesAndText
        {
            get
            {
                return color_deep;
            }
            set
            {
                color_deep = value;
                InitializationColor();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color dash lines.
        /// </summary>
        /// <value>The color dash lines.</value>
        [Category("自定义")]
        [Description("获取或设置虚线的颜色")]
        [Browsable(true)]
        public Color ColorDashLines
        {
            get
            {
                return color_dash;
            }
            set
            {
                color_dash = value;
                if (pen_dash != null)
                    pen_dash.Dispose();
                pen_dash = new Pen(color_dash);
                pen_dash.DashStyle = DashStyle.Custom;
                pen_dash.DashPattern = new float[2]
				{
					5f,
					5f
				};
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the interval abscissa text.
        /// </summary>
        /// <value>The interval abscissa text.</value>
        [Category("自定义")]
        [Description("获取或设置纵向虚线的分隔情况，单位为多少个数据")]
        [Browsable(true)]
        [DefaultValue(100)]
        public int IntervalAbscissaText
        {
            get
            {
                return value_IntervalAbscissaText;
            }
            set
            {
                value_IntervalAbscissaText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text add format.
        /// </summary>
        /// <value>The text add format.</value>
        [Category("自定义")]
        [Description("获取或设置实时数据新增时文本相对应于时间的格式化字符串，默认HH:mm")]
        [Browsable(true)]
        [DefaultValue("HH:mm")]
        public string TextAddFormat
        {
            get
            {
                return textFormat;
            }
            set
            {
                textFormat = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Category("自定义")]
        [Description("获取或设置图标的标题信息")]
        [Browsable(true)]
        [DefaultValue("")]
        public string Title
        {
            get
            {
                return value_title;
            }
            set
            {
                value_title = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is render right coordinate.
        /// </summary>
        /// <value><c>true</c> if this instance is render right coordinate; otherwise, <c>false</c>.</value>
        [Category("自定义")]
        [Description("获取或设置是否显示右侧的坐标系信息")]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool IsRenderRightCoordinate
        {
            get
            {
                return isRenderRightCoordinate;
            }
            set
            {
                isRenderRightCoordinate = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the curve name.
        /// </summary>
        /// <value>The width of the curve name.</value>
        [Browsable(true)]
        [Description("获取或设置曲线名称的布局宽度")]
        [Category("自定义")]
        [DefaultValue(100)]
        public int CurveNameWidth
        {
            get
            {
                return curveNameWidth;
            }
            set
            {
                if (value > 10)
                {
                    curveNameWidth = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCCurve" /> class.
        /// </summary>
        public UCCurve()
        {
            InitializeComponent();
            random = new Random();
            data_list = new Dictionary<string, CurveItem>();
            auxiliary_lines = new List<AuxiliaryLine>();
            MarkTexts = new List<MarkText>();
            auxiliary_Labels = new List<AuxiliaryLable>();
            format_left = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            };
            format_right = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Far
            };
            format_center = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            font_size9 = new Font("微软雅黑", 9f);
            font_size12 = new Font("微软雅黑", 12f);
            InitializationColor();
            pen_dash = new Pen(color_deep);
            pen_dash.DashStyle = DashStyle.Custom;
            pen_dash.DashPattern = new float[2]
			{
				5f,
				5f
			};
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        /// <summary>
        /// Initializations the color.
        /// </summary>
        private void InitializationColor()
        {
            if (pen_normal != null)
                pen_normal.Dispose();
            if (brush_deep != null)
                brush_deep.Dispose();
            pen_normal = new Pen(color_deep);
            brush_deep = new SolidBrush(color_deep);
        }

        /// <summary>
        /// Sets the curve text.
        /// </summary>
        /// <param name="descriptions">The descriptions.</param>
        public void SetCurveText(string[] descriptions)
        {
            data_text = descriptions;
            Invalidate();
        }

        /// <summary>
        /// Sets the left curve.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        /// <param name="lineColor">Color of the line.</param>
        public void SetLeftCurve(string key, float[] data, Color? lineColor = null)
        {
            SetCurve(key, true, data, lineColor, 1f, false);
        }

        /// <summary>
        /// Sets the left curve.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        /// <param name="lineColor">Color of the line.</param>
        /// <param name="isSmooth">if set to <c>true</c> [is smooth].</param>
        public void SetLeftCurve(string key, float[] data, Color? lineColor, bool isSmooth = false)
        {
            SetCurve(key, true, data, lineColor, 1f, isSmooth);
        }

        /// <summary>
        /// Sets the right curve.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        /// <param name="lineColor">Color of the line.</param>
        public void SetRightCurve(string key, float[] data, Color? lineColor = null)
        {
            SetCurve(key, false, data, lineColor, 1f, false);
        }

        /// <summary>
        /// Sets the right curve.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        /// <param name="lineColor">Color of the line.</param>
        /// <param name="isSmooth">if set to <c>true</c> [is smooth].</param>
        public void SetRightCurve(string key, float[] data, Color? lineColor, bool isSmooth = false)
        {
            SetCurve(key, false, data, lineColor, 1f, isSmooth);
        }

        /// <summary>
        /// Sets the curve.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="isLeft">if set to <c>true</c> [is left].</param>
        /// <param name="data">The data.</param>
        /// <param name="lineColor">Color of the line.</param>
        /// <param name="thickness">The thickness.</param>
        /// <param name="isSmooth">if set to <c>true</c> [is smooth].</param>
        public void SetCurve(string key, bool isLeft, float[] data, Color? lineColor, float thickness, bool isSmooth)
        {
            if (data_list.ContainsKey(key))
            {
                if (data == null)
                {
                    data = new float[0];
                }
                data_list[key].Data = data;
            }
            else
            {
                if (data == null)
                {
                    data = new float[0];
                }
                data_list.Add(key, new CurveItem
                {
                    Data = data,
                    MarkText = new string[data.Length],
                    LineThickness = thickness,
                    LineColor = lineColor ?? ControlHelper.Colors[data_list.Count + 13],
                    IsLeftFrame = isLeft,
                    IsSmoothCurve = isSmooth
                });
                if (data_text == null)
                {
                    data_text = new string[data.Length];
                }
            }
            Invalidate();
        }

        /// <summary>
        /// Removes the curve.
        /// </summary>
        /// <param name="key">The key.</param>
        public void RemoveCurve(string key)
        {
            if (data_list.ContainsKey(key))
            {
                data_list.Remove(key);
            }
            if (data_list.Count == 0)
            {
                data_text = new string[0];
            }
            Invalidate();
        }

        /// <summary>
        /// Removes all curve.
        /// </summary>
        public void RemoveAllCurve()
        {
            int count = data_list.Count;
            data_list.Clear();
            if (data_list.Count == 0)
            {
                data_text = new string[0];
            }
            if (count > 0)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Removes all curve data.
        /// </summary>
        public void RemoveAllCurveData()
        {
            int count = data_list.Count;
            foreach (KeyValuePair<string, CurveItem> item in data_list)
            {
                item.Value.Data = new float[0];
                item.Value.MarkText = new string[0];
            }
            data_text = new string[0];
            if (count > 0)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Gets the curve item.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>CurveItem.</returns>
        public CurveItem GetCurveItem(string key)
        {
            if (data_list.ContainsKey(key))
            {
                return data_list[key];
            }
            return null;
        }

        /// <summary>
        /// Saves to bitmap.
        /// </summary>
        /// <returns>Bitmap.</returns>
        public Bitmap SaveToBitmap()
        {
            return SaveToBitmap(base.Width, base.Height);
        }

        /// <summary>
        /// Saves to bitmap.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>Bitmap.</returns>
        public Bitmap SaveToBitmap(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            OnPaint(new PaintEventArgs(graphics, new Rectangle(0, 0, width, height)));
            return bitmap;
        }

        /// <summary>
        /// Adds the curve data.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        /// <param name="markTexts">The mark texts.</param>
        /// <param name="isUpdateUI">if set to <c>true</c> [is update UI].</param>
        private void AddCurveData(string key, float[] values, string[] markTexts, bool isUpdateUI)
        {
            if ((values != null && values.Length < 1) || !data_list.ContainsKey(key))
            {
                return;
            }
            CurveItem CurveItem = data_list[key];
            if (CurveItem.Data != null)
            {
                if (value_IsAbscissaStrech)
                {
                    ControlHelper.AddArrayData(ref CurveItem.Data, values, value_StrechDataCountMax);
                    ControlHelper.AddArrayData(ref CurveItem.MarkText, markTexts, value_StrechDataCountMax);
                }
                else
                {
                    ControlHelper.AddArrayData(ref CurveItem.Data, values, 4096);
                    ControlHelper.AddArrayData(ref CurveItem.MarkText, markTexts, 4096);
                }
                if (isUpdateUI)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Adds the curve time.
        /// </summary>
        /// <param name="count">The count.</param>
        private void AddCurveTime(int count)
        {
            AddCurveTime(count, DateTime.Now.ToString(textFormat));
        }

        /// <summary>
        /// Adds the curve time.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="text">The text.</param>
        private void AddCurveTime(int count, string text)
        {
            if (data_text != null)
            {
                string[] array = new string[count];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = text;
                }
                if (value_IsAbscissaStrech)
                {
                    ControlHelper.AddArrayData(ref data_text, array, value_StrechDataCountMax);
                }
                else
                {
                    ControlHelper.AddArrayData(ref data_text, array, 4096);
                }
            }
        }

        /// <summary>
        /// Adds the curve data.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void AddCurveData(string key, float value)
        {
            AddCurveData(key, new float[1]
			{
				value
			});
        }

        /// <summary>
        /// Adds the curve data.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="markText">The mark text.</param>
        public void AddCurveData(string key, float value, string markText)
        {
            AddCurveData(key, new float[1]
			{
				value
			}, new string[1]
			{
				markText
			});
        }

        /// <summary>
        /// Adds the curve data.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        public void AddCurveData(string key, float[] values)
        {
            AddCurveData(key, values, null);
        }

        /// <summary>
        /// Adds the curve data.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        /// <param name="markTexts">The mark texts.</param>
        public void AddCurveData(string key, float[] values, string[] markTexts)
        {
            if (markTexts == null)
            {
                markTexts = new string[values.Length];
            }
            AddCurveData(key, values, markTexts, false);
            if (values != null && values.Length != 0)
            {
                AddCurveTime(values.Length);
            }
            Invalidate();
        }

        /// <summary>
        /// Adds the curve data.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <param name="values">The values.</param>
        public void AddCurveData(string[] keys, float[] values)
        {
            AddCurveData(keys, values, null);
        }

        /// <summary>
        /// Adds the curve data.
        /// </summary>
        /// <param name="axisText">The axis text.</param>
        /// <param name="keys">The keys.</param>
        /// <param name="values">The values.</param>
        public void AddCurveData(string axisText, string[] keys, float[] values)
        {
            AddCurveData(axisText, keys, values, null);
        }

        /// <summary>
        /// Adds the curve data.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <param name="values">The values.</param>
        /// <param name="markTexts">The mark texts.</param>
        /// <exception cref="ArgumentNullException">keys
        /// or
        /// values</exception>
        /// <exception cref="Exception">两个参数的数组长度不一致。
        /// or
        /// 两个参数的数组长度不一致。</exception>
        public void AddCurveData(string[] keys, float[] values, string[] markTexts)
        {
            if (keys == null)
            {
                throw new ArgumentNullException("keys");
            }
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            if (markTexts == null)
            {
                markTexts = new string[keys.Length];
            }
            if (keys.Length != values.Length)
            {
                throw new Exception("两个参数的数组长度不一致。");
            }
            if (keys.Length != markTexts.Length)
            {
                throw new Exception("两个参数的数组长度不一致。");
            }
            for (int i = 0; i < keys.Length; i++)
            {
                AddCurveData(keys[i], new float[1]
				{
					values[i]
				}, new string[1]
				{
					markTexts[i]
				}, false);
            }
            AddCurveTime(1);
            Invalidate();
        }

        /// <summary>
        /// Adds the curve data.
        /// </summary>
        /// <param name="axisText">The axis text.</param>
        /// <param name="keys">The keys.</param>
        /// <param name="values">The values.</param>
        /// <param name="markTexts">The mark texts.</param>
        /// <exception cref="ArgumentNullException">keys
        /// or
        /// values</exception>
        /// <exception cref="Exception">两个参数的数组长度不一致。
        /// or
        /// 两个参数的数组长度不一致。</exception>
        public void AddCurveData(string axisText, string[] keys, float[] values, string[] markTexts)
        {
            if (keys == null)
            {
                throw new ArgumentNullException("keys");
            }
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            if (markTexts == null)
            {
                markTexts = new string[keys.Length];
            }
            if (keys.Length != values.Length)
            {
                throw new Exception("两个参数的数组长度不一致。");
            }
            if (keys.Length != markTexts.Length)
            {
                throw new Exception("两个参数的数组长度不一致。");
            }
            for (int i = 0; i < keys.Length; i++)
            {
                AddCurveData(keys[i], new float[1]
				{
					values[i]
				}, new string[1]
				{
					markTexts[i]
				}, false);
            }
            AddCurveTime(1, axisText);
            Invalidate();
        }

        /// <summary>
        /// Sets the curve visible.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        public void SetCurveVisible(string key, bool visible)
        {
            if (data_list.ContainsKey(key))
            {
                CurveItem CurveItem = data_list[key];
                CurveItem.Visible = visible;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the curve visible.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        public void SetCurveVisible(string[] keys, bool visible)
        {
            foreach (string key in keys)
            {
                if (data_list.ContainsKey(key))
                {
                    CurveItem CurveItem = data_list[key];
                    CurveItem.Visible = visible;
                }
            }
            Invalidate();
        }

        /// <summary>
        /// Adds the left auxiliary.
        /// </summary>
        /// <param name="value">The value.</param>
        public void AddLeftAuxiliary(float value)
        {
            AddLeftAuxiliary(value, ColorLinesAndText);
        }

        /// <summary>
        /// Adds the left auxiliary.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lineColor">Color of the line.</param>
        public void AddLeftAuxiliary(float value, Color lineColor)
        {
            AddLeftAuxiliary(value, lineColor, 1f, true);
        }

        /// <summary>
        /// Adds the left auxiliary.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lineColor">Color of the line.</param>
        /// <param name="lineThickness">The line thickness.</param>
        /// <param name="isDashLine">if set to <c>true</c> [is dash line].</param>
        public void AddLeftAuxiliary(float value, Color lineColor, float lineThickness, bool isDashLine)
        {
            AddAuxiliary(value, lineColor, lineThickness, isDashLine, true);
        }

        /// <summary>
        /// Adds the right auxiliary.
        /// </summary>
        /// <param name="value">The value.</param>
        public void AddRightAuxiliary(float value)
        {
            AddRightAuxiliary(value, ColorLinesAndText);
        }

        /// <summary>
        /// Adds the right auxiliary.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lineColor">Color of the line.</param>
        public void AddRightAuxiliary(float value, Color lineColor)
        {
            AddRightAuxiliary(value, lineColor, 1f, true);
        }

        /// <summary>
        /// Adds the right auxiliary.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lineColor">Color of the line.</param>
        /// <param name="lineThickness">The line thickness.</param>
        /// <param name="isDashLine">if set to <c>true</c> [is dash line].</param>
        public void AddRightAuxiliary(float value, Color lineColor, float lineThickness, bool isDashLine)
        {
            AddAuxiliary(value, lineColor, lineThickness, isDashLine, false);
        }

        /// <summary>
        /// Adds the auxiliary.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lineColor">Color of the line.</param>
        /// <param name="lineThickness">The line thickness.</param>
        /// <param name="isDashLine">if set to <c>true</c> [is dash line].</param>
        /// <param name="isLeft">if set to <c>true</c> [is left].</param>
        private void AddAuxiliary(float value, Color lineColor, float lineThickness, bool isDashLine, bool isLeft)
        {
            auxiliary_lines.Add(new AuxiliaryLine
            {
                Value = value,
                LineColor = lineColor,
                PenDash = new Pen(lineColor)
                {
                    DashStyle = DashStyle.Custom,
                    DashPattern = new float[2]
					{
						5f,
						5f
					}
                },
                PenSolid = new Pen(lineColor),
                IsDashStyle = isDashLine,
                IsLeftFrame = isLeft,
                LineThickness = lineThickness,
                LineTextBrush = new SolidBrush(lineColor)
            });
            Invalidate();
        }

        /// <summary>
        /// Removes the auxiliary.
        /// </summary>
        /// <param name="value">The value.</param>
        public void RemoveAuxiliary(float value)
        {
            int num = 0;
            for (int num2 = auxiliary_lines.Count - 1; num2 >= 0; num2--)
            {
                if (auxiliary_lines[num2].Value == value)
                {
                    auxiliary_lines[num2].Dispose();
                    auxiliary_lines.RemoveAt(num2);
                    num++;
                }
            }
            if (num > 0)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Removes all auxiliary.
        /// </summary>
        public void RemoveAllAuxiliary()
        {
            int count = auxiliary_lines.Count;
            auxiliary_lines.Clear();
            if (count > 0)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Adds the auxiliary label.
        /// </summary>
        /// <param name="auxiliaryLable">The auxiliary lable.</param>
        public void AddAuxiliaryLabel(AuxiliaryLable auxiliaryLable)
        {
            auxiliary_Labels.Add(auxiliaryLable);
        }

        /// <summary>
        /// Removes the auxiliary lable.
        /// </summary>
        /// <param name="auxiliaryLable">The auxiliary lable.</param>
        public void RemoveAuxiliaryLable(AuxiliaryLable auxiliaryLable)
        {
            if (auxiliary_Labels.Remove(auxiliaryLable))
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Removes all auxiliary lable.
        /// </summary>
        public void RemoveAllAuxiliaryLable()
        {
            int count = auxiliary_Labels.Count;
            auxiliary_Labels.Clear();
            if (count > 0)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Adds the mark text.
        /// </summary>
        /// <param name="markText">The mark text.</param>
        public void AddMarkText(MarkText markText)
        {
            MarkTexts.Add(markText);
            if (data_list.Count > 0)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Adds the mark text.
        /// </summary>
        /// <param name="strCurveKey">The string curve key.</param>
        /// <param name="intValueIndex">Index of the int value.</param>
        /// <param name="strText">The string text.</param>
        /// <param name="textColor">Color of the text.</param>
        public void AddMarkText(string strCurveKey, int intValueIndex, string strText, Color? textColor = null)
        {
            AddMarkText(new MarkText() { CurveKey = strCurveKey, PositionStyle = MarkTextPositionStyle.Auto, Text = strText, TextColor = textColor, Index = intValueIndex });
        }

        /// <summary>
        /// Removes the mark text.
        /// </summary>
        /// <param name="markText">The mark text.</param>
        public void RemoveMarkText(MarkText markText)
        {
            MarkTexts.Remove(markText);
            if (data_list.Count > 0)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Removes all mark text.
        /// </summary>
        public void RemoveAllMarkText()
        {
            MarkTexts.Clear();
            if (data_list.Count > 0)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.MouseMove" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.MouseEventArgs" />。</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            bool flag = false;
            foreach (KeyValuePair<string, CurveItem> item in data_list)
            {
                if (item.Value.TitleRegion.Contains(e.Location))
                {
                    flag = true;
                    break;
                }
            }
            Cursor = (flag ? Cursors.Hand : Cursors.Arrow);
        }

        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.MouseEventArgs" />。</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            foreach (KeyValuePair<string, CurveItem> item in data_list)
            {
                if (item.Value.TitleRegion.Contains(e.Location))
                {
                    item.Value.LineRenderVisiable = !item.Value.LineRenderVisiable;
                    Invalidate();
                    break;
                }
            }
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                Graphics graphics = e.Graphics;
                graphics.SetGDIHigh();
                if (BackColor != Color.Transparent)
                {
                    graphics.Clear(BackColor);
                }
                int width = base.Width;
                int height = base.Height;
                if (width < 120 || height < 60)
                {
                    return;
                }
                Point[] array = new Point[4]
                {
				    new Point(leftRight - 1, upDowm - 8),
				    new Point(leftRight - 1, height - upDowm),
				    new Point(width - leftRight, height - upDowm),
				    new Point(width - leftRight, upDowm - 8)
                };
                graphics.DrawLine(pen_normal, array[0], array[1]);
                graphics.DrawLine(pen_normal, array[1], array[2]);
                if (isRenderRightCoordinate)
                {
                    graphics.DrawLine(pen_normal, array[2], array[3]);
                }

                if (!string.IsNullOrEmpty(value_title))
                {
                    graphics.DrawString(value_title, font_size9, brush_deep, new Rectangle(0, 0, width - 1, 20), format_center);
                }

                if (data_list.Count > 0)
                {
                    float num = leftRight + 10;
                    foreach (KeyValuePair<string, CurveItem> item in data_list)
                    {
                        if (item.Value.Visible)
                        {
                            var titleSize=graphics.MeasureString(item.Key, Font);
                            SolidBrush solidBrush = item.Value.LineRenderVisiable ? new SolidBrush(item.Value.LineColor) : new SolidBrush(Color.FromArgb(80, item.Value.LineColor));
                            graphics.FillRectangle(solidBrush, num + 8f, 24f, 20f, 14f);
                            graphics.DrawString(item.Key, Font, solidBrush, new PointF(num + 30f, 24f+(14 - titleSize.Height) / 2));
                            item.Value.TitleRegion = new RectangleF(num, 24f, 60f, 18f);
                            solidBrush.Dispose();
                            num += titleSize.Width + 30;
                        }
                    }
                }


                for (int i = 0; i < auxiliary_Labels.Count; i++)
                {
                    if (!string.IsNullOrEmpty(auxiliary_Labels[i].Text))
                    {
                        int num2 = (auxiliary_Labels[i].LocationX > 1f) ? ((int)auxiliary_Labels[i].LocationX) : ((int)(auxiliary_Labels[i].LocationX * (float)width));
                        int num3 = (int)graphics.MeasureString(auxiliary_Labels[i].Text, Font).Width + 3;
                        Point[] points = new Point[6]
					{
						new Point(num2, 11),
						new Point(num2 + 10, 20),
						new Point(num2 + num3 + 10, 20),
						new Point(num2 + num3 + 10, 0),
						new Point(num2 + 10, 0),
						new Point(num2, 11)
					};
                        graphics.FillPolygon(auxiliary_Labels[i].TextBack, points);
                        graphics.DrawString(auxiliary_Labels[i].Text, Font, auxiliary_Labels[i].TextBrush, new Rectangle(num2 + 7, 0, num3 + 3, 20), format_center);
                    }
                }
                ControlHelper.PaintTriangle(graphics, brush_deep, new Point(leftRight - 1, upDowm - 8), 4, GraphDirection.Upward);
                if (isRenderRightCoordinate)
                {
                    ControlHelper.PaintTriangle(graphics, brush_deep, new Point(width - leftRight, upDowm - 8), 4, GraphDirection.Upward);
                }
                for (int j = 0; j < auxiliary_lines.Count; j++)
                {
                    if (auxiliary_lines[j].IsLeftFrame)
                    {
                        auxiliary_lines[j].PaintValue = ControlHelper.ComputePaintLocationY(value_max_left, value_min_left, height - upDowm - upDowm, auxiliary_lines[j].Value) + (float)upDowm;
                    }
                    else
                    {
                        auxiliary_lines[j].PaintValue = ControlHelper.ComputePaintLocationY(value_max_right, value_min_right, height - upDowm - upDowm, auxiliary_lines[j].Value) + (float)upDowm;
                    }
                }
                for (int k = 0; k <= value_Segment; k++)
                {
                    float value = (float)((double)k * (double)(value_max_left - value_min_left) / (double)value_Segment + (double)value_min_left);
                    float num4 = ControlHelper.ComputePaintLocationY(value_max_left, value_min_left, height - upDowm - upDowm, value) + (float)upDowm;
                    if (IsNeedPaintDash(num4))
                    {
                        graphics.DrawLine(pen_normal, leftRight - 4, num4, leftRight - 1, num4);
                        RectangleF layoutRectangle = new RectangleF(0f, num4 - 9f, leftRight - 4, 20f);
                        graphics.DrawString(value.ToString(), font_size9, brush_deep, layoutRectangle, format_right);
                        if (isRenderRightCoordinate)
                        {
                            float num5 = (float)k * (value_max_right - value_min_right) / (float)value_Segment + value_min_right;
                            graphics.DrawLine(pen_normal, width - leftRight + 1, num4, width - leftRight + 4, num4);
                            layoutRectangle.Location = new PointF(width - leftRight + 4, num4 - 9f);
                            graphics.DrawString(num5.ToString(), font_size9, brush_deep, layoutRectangle, format_left);
                        }
                        if (k > 0 && value_IsRenderDashLine)
                        {
                            graphics.DrawLine(pen_dash, leftRight, num4, width - leftRight, num4);
                        }
                    }
                }
                if (value_IsRenderDashLine)
                {
                    if (value_IsAbscissaStrech)
                    {
                        float num6 = (float)(width - leftRight * 2) * 1f / (float)(value_StrechDataCountMax - 1);
                        int num7 = CalculateDataCountByOffect(num6);
                        for (int l = 0; l < value_StrechDataCountMax; l += num7)
                        {
                            if (l > 0 && l < value_StrechDataCountMax - 1)
                            {
                                graphics.DrawLine(pen_dash, (float)l * num6 + (float)leftRight, upDowm, (float)l * num6 + (float)leftRight, height - upDowm - 1);
                            }
                            if (data_text != null && l < data_text.Length && (float)l * num6 + (float)leftRight < (float)(data_text.Length - 1) * num6 + (float)leftRight - 40f)
                            {
                                graphics.DrawString(layoutRectangle: new Rectangle((int)((float)l * num6), height - upDowm + 1, leftRight * 2, upDowm), s: data_text[l], font: font_size9, brush: brush_deep, format: format_center);
                            }
                        }
                        string[] array2 = data_text;
                        if (array2 != null && array2.Length > 1)
                        {
                            if (data_text.Length < value_StrechDataCountMax)
                            {
                                graphics.DrawLine(pen_dash, (float)(data_text.Length - 1) * num6 + (float)leftRight, upDowm, (float)(data_text.Length - 1) * num6 + (float)leftRight, height - upDowm - 1);
                            }
                            graphics.DrawString(layoutRectangle: new Rectangle((int)((float)(data_text.Length - 1) * num6 + (float)leftRight) - leftRight, height - upDowm + 1, leftRight * 2, upDowm), s: data_text[data_text.Length - 1], font: font_size9, brush: brush_deep, format: format_center);
                        }
                    }
                    else if (value_IntervalAbscissaText > 0)
                    {
                        int num8 = width - 2 * leftRight + 1;
                        for (int m = leftRight; m < width - leftRight; m += value_IntervalAbscissaText)
                        {
                            if (m != leftRight)
                            {
                                graphics.DrawLine(pen_dash, m, upDowm, m, height - upDowm - 1);
                            }
                            if (data_text == null)
                            {
                                continue;
                            }
                            int num9 = (num8 > data_text.Length) ? data_text.Length : num8;
                            if (m - leftRight < data_text.Length && num9 - (m - leftRight) > 40)
                            {
                                if (data_text.Length <= num8)
                                {
                                    graphics.DrawString(layoutRectangle: new Rectangle(m - leftRight, height - upDowm + 1, leftRight * 2, upDowm), s: data_text[m - leftRight], font: font_size9, brush: brush_deep, format: format_center);
                                }
                                else
                                {
                                    graphics.DrawString(layoutRectangle: new Rectangle(m - leftRight, height - upDowm + 1, leftRight * 2, upDowm), s: data_text[m - leftRight + data_text.Length - num8], font: font_size9, brush: brush_deep, format: format_center);
                                }
                            }
                        }
                        string[] array3 = data_text;
                        if (array3 != null && array3.Length > 1)
                        {
                            if (data_text.Length >= num8)
                            {
                                graphics.DrawString(layoutRectangle: new Rectangle(width - leftRight - leftRight, height - upDowm + 1, leftRight * 2, upDowm), s: data_text[data_text.Length - 1], font: font_size9, brush: brush_deep, format: format_center);
                            }
                            else
                            {
                                graphics.DrawLine(pen_dash, data_text.Length + leftRight - 1, upDowm, data_text.Length + leftRight - 1, height - upDowm - 1);
                                graphics.DrawString(layoutRectangle: new Rectangle(data_text.Length + leftRight - 1 - leftRight, height - upDowm + 1, leftRight * 2, upDowm), s: data_text[data_text.Length - 1], font: font_size9, brush: brush_deep, format: format_center);
                            }
                        }
                    }
                }
                for (int n = 0; n < auxiliary_lines.Count; n++)
                {
                    if (auxiliary_lines[n].IsLeftFrame)
                    {
                        graphics.DrawLine(auxiliary_lines[n].GetPen(), leftRight - 4, auxiliary_lines[n].PaintValue, leftRight - 1, auxiliary_lines[n].PaintValue);
                        graphics.DrawString(layoutRectangle: new RectangleF(0f, auxiliary_lines[n].PaintValue - 9f, leftRight - 4, 20f), s: auxiliary_lines[n].Value.ToString(), font: font_size9, brush: auxiliary_lines[n].LineTextBrush, format: format_right);
                    }
                    else
                    {
                        graphics.DrawLine(auxiliary_lines[n].GetPen(), width - leftRight + 1, auxiliary_lines[n].PaintValue, width - leftRight + 4, auxiliary_lines[n].PaintValue);
                        graphics.DrawString(layoutRectangle: new RectangleF(width - leftRight + 4, auxiliary_lines[n].PaintValue - 9f, leftRight - 4, 20f), s: auxiliary_lines[n].Value.ToString(), font: font_size9, brush: auxiliary_lines[n].LineTextBrush, format: format_left);
                    }
                    graphics.DrawLine(auxiliary_lines[n].GetPen(), leftRight, auxiliary_lines[n].PaintValue, width - leftRight, auxiliary_lines[n].PaintValue);
                }
                if (value_IsAbscissaStrech)
                {
                    foreach (MarkText MarkText in MarkTexts)
                    {
                        foreach (KeyValuePair<string, CurveItem> item2 in data_list)
                        {
                            if (item2.Value.Visible && item2.Value.LineRenderVisiable && !(item2.Key != MarkText.CurveKey))
                            {
                                float[] data = item2.Value.Data;
                                if (data != null && data.Length > 1)
                                {
                                    float num10 = (float)(width - leftRight * 2) * 1f / (float)(value_StrechDataCountMax - 1);
                                    if (MarkText.Index >= 0 && MarkText.Index < item2.Value.Data.Length)
                                    {
                                        PointF pointF = new PointF((float)leftRight + (float)MarkText.Index * num10, ControlHelper.ComputePaintLocationY(item2.Value.IsLeftFrame ? value_max_left : value_max_right, item2.Value.IsLeftFrame ? value_min_left : value_min_right, height - upDowm - upDowm, item2.Value.Data[MarkText.Index]) + (float)upDowm);
                                        graphics.FillEllipse(new SolidBrush(MarkText.TextColor ?? item2.Value.LineColor), new RectangleF(pointF.X - 3f, pointF.Y - 3f, 6f, 6f));
                                        switch ((MarkText.PositionStyle == MarkTextPositionStyle.Auto) ? MarkText.CalculateDirectionFromDataIndex(item2.Value.Data, MarkText.Index) : MarkText.PositionStyle)
                                        {
                                            case MarkTextPositionStyle.Left:
                                                graphics.DrawString(MarkText.Text, Font, new SolidBrush(MarkText.TextColor ?? item2.Value.LineColor), new RectangleF(pointF.X - 100f, pointF.Y - (float)Font.Height, 100 - MarkText.MarkTextOffect, Font.Height * 2), format_right);
                                                break;
                                            case MarkTextPositionStyle.Up:
                                                graphics.DrawString(MarkText.Text, Font, new SolidBrush(MarkText.TextColor ?? item2.Value.LineColor), new RectangleF(pointF.X - 100f, pointF.Y - (float)Font.Height - (float)MarkText.MarkTextOffect, 200f, Font.Height + 2), format_center);
                                                break;
                                            case MarkTextPositionStyle.Right:
                                                graphics.DrawString(MarkText.Text, Font, new SolidBrush(MarkText.TextColor ?? item2.Value.LineColor), new RectangleF(pointF.X + (float)MarkText.MarkTextOffect, pointF.Y - (float)Font.Height, 100f, Font.Height * 2), format_left);
                                                break;
                                            case MarkTextPositionStyle.Down:
                                                graphics.DrawString(MarkText.Text, Font, new SolidBrush(MarkText.TextColor ?? item2.Value.LineColor), new RectangleF(pointF.X - 100f, pointF.Y + (float)MarkText.MarkTextOffect, 200f, Font.Height + 2), format_center);
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    foreach (CurveItem value2 in data_list.Values)
                    {
                        if (value2.Visible && value2.LineRenderVisiable)
                        {
                            float[] data2 = value2.Data;
                            if (data2 != null && data2.Length > 1)
                            {
                                float num11 = (float)(width - leftRight * 2) * 1f / (float)(value_StrechDataCountMax - 1);
                                PointF[] array4 = new PointF[value2.Data.Length];
                                for (int num12 = 0; num12 < value2.Data.Length; num12++)
                                {
                                    array4[num12].X = (float)leftRight + (float)num12 * num11;
                                    array4[num12].Y = ControlHelper.ComputePaintLocationY(value2.IsLeftFrame ? value_max_left : value_max_right, value2.IsLeftFrame ? value_min_left : value_min_right, height - upDowm - upDowm, value2.Data[num12]) + (float)upDowm;
                                    if (!string.IsNullOrEmpty(value2.MarkText[num12]))
                                    {
                                        using (Brush brush = new SolidBrush(value2.LineColor))
                                        {
                                            graphics.FillEllipse(brush, new RectangleF(array4[num12].X - 3f, array4[num12].Y - 3f, 6f, 6f));
                                            switch (MarkText.CalculateDirectionFromDataIndex(value2.Data, num12))
                                            {
                                                case MarkTextPositionStyle.Left:
                                                    graphics.DrawString(value2.MarkText[num12], Font, brush, new RectangleF(array4[num12].X - 100f, array4[num12].Y - (float)Font.Height, 100 - MarkText.MarkTextOffect, Font.Height * 2), format_right);
                                                    break;
                                                case MarkTextPositionStyle.Up:
                                                    graphics.DrawString(value2.MarkText[num12], Font, brush, new RectangleF(array4[num12].X - 100f, array4[num12].Y - (float)Font.Height - (float)MarkText.MarkTextOffect, 200f, Font.Height + 2), format_center);
                                                    break;
                                                case MarkTextPositionStyle.Right:
                                                    graphics.DrawString(value2.MarkText[num12], Font, brush, new RectangleF(array4[num12].X + (float)MarkText.MarkTextOffect, array4[num12].Y - (float)Font.Height, 100f, Font.Height * 2), format_left);
                                                    break;
                                                case MarkTextPositionStyle.Down:
                                                    graphics.DrawString(value2.MarkText[num12], Font, brush, new RectangleF(array4[num12].X - 100f, array4[num12].Y + (float)MarkText.MarkTextOffect, 200f, Font.Height + 2), format_center);
                                                    break;
                                            }
                                        }
                                    }
                                }
                                using (Pen pen2 = new Pen(value2.LineColor, value2.LineThickness))
                                {
                                    if (value2.IsSmoothCurve)
                                    {
                                        graphics.DrawCurve(pen2, array4);
                                    }
                                    else
                                    {
                                        graphics.DrawLines(pen2, array4);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (MarkText MarkText2 in MarkTexts)
                    {
                        foreach (KeyValuePair<string, CurveItem> item3 in data_list)
                        {
                            if (item3.Value.Visible && item3.Value.LineRenderVisiable && !(item3.Key != MarkText2.CurveKey))
                            {
                                float[] data3 = item3.Value.Data;
                                if (data3 != null && data3.Length > 1 && MarkText2.Index >= 0 && MarkText2.Index < item3.Value.Data.Length)
                                {
                                    PointF pointF2 = new PointF(leftRight + MarkText2.Index, ControlHelper.ComputePaintLocationY(item3.Value.IsLeftFrame ? value_max_left : value_max_right, item3.Value.IsLeftFrame ? value_min_left : value_min_right, height - upDowm - upDowm, item3.Value.Data[MarkText2.Index]) + (float)upDowm);
                                    graphics.FillEllipse(new SolidBrush(MarkText2.TextColor ?? item3.Value.LineColor), new RectangleF(pointF2.X - 3f, pointF2.Y - 3f, 6f, 6f));
                                    switch ((MarkText2.PositionStyle == MarkTextPositionStyle.Auto) ? MarkText.CalculateDirectionFromDataIndex(item3.Value.Data, MarkText2.Index) : MarkText2.PositionStyle)
                                    {
                                        case MarkTextPositionStyle.Left:
                                            graphics.DrawString(MarkText2.Text, Font, new SolidBrush(MarkText2.TextColor ?? item3.Value.LineColor), new RectangleF(pointF2.X - 100f, pointF2.Y - (float)Font.Height, 100 - MarkText.MarkTextOffect, Font.Height * 2), format_right);
                                            break;
                                        case MarkTextPositionStyle.Up:
                                            graphics.DrawString(MarkText2.Text, Font, new SolidBrush(MarkText2.TextColor ?? item3.Value.LineColor), new RectangleF(pointF2.X - 100f, pointF2.Y - (float)Font.Height - (float)MarkText.MarkTextOffect, 200f, Font.Height + 2), format_center);
                                            break;
                                        case MarkTextPositionStyle.Right:
                                            graphics.DrawString(MarkText2.Text, Font, new SolidBrush(MarkText2.TextColor ?? item3.Value.LineColor), new RectangleF(pointF2.X + (float)MarkText.MarkTextOffect, pointF2.Y - (float)Font.Height, 100f, Font.Height * 2), format_left);
                                            break;
                                        case MarkTextPositionStyle.Down:
                                            graphics.DrawString(MarkText2.Text, Font, new SolidBrush(MarkText2.TextColor ?? item3.Value.LineColor), new RectangleF(pointF2.X - 100f, pointF2.Y + (float)MarkText.MarkTextOffect, 200f, Font.Height + 2), format_center);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    foreach (CurveItem value3 in data_list.Values)
                    {
                        if (value3.Visible && value3.LineRenderVisiable)
                        {
                            float[] data4 = value3.Data;
                            if (data4 != null && data4.Length > 1)
                            {
                                int num13 = width - 2 * leftRight + 1;
                                PointF[] array5;
                                if (value3.Data.Length <= num13)
                                {
                                    array5 = new PointF[value3.Data.Length];
                                    for (int num14 = 0; num14 < value3.Data.Length; num14++)
                                    {
                                        array5[num14].X = leftRight + num14;
                                        array5[num14].Y = ControlHelper.ComputePaintLocationY(value3.IsLeftFrame ? value_max_left : value_max_right, value3.IsLeftFrame ? value_min_left : value_min_right, height - upDowm - upDowm, value3.Data[num14]) + (float)upDowm;
                                        DrawMarkPoint(graphics, value3.MarkText[num14], array5[num14], value3.LineColor, MarkText.CalculateDirectionFromDataIndex(value3.Data, num14));
                                    }
                                }
                                else
                                {
                                    array5 = new PointF[num13];
                                    for (int num15 = 0; num15 < array5.Length; num15++)
                                    {
                                        int num16 = num15 + value3.Data.Length - num13;
                                        array5[num15].X = leftRight + num15;
                                        array5[num15].Y = ControlHelper.ComputePaintLocationY(value3.IsLeftFrame ? value_max_left : value_max_right, value3.IsLeftFrame ? value_min_left : value_min_right, height - upDowm - upDowm, value3.Data[num16]) + (float)upDowm;
                                        DrawMarkPoint(graphics, value3.MarkText[num16], array5[num15], value3.LineColor, MarkText.CalculateDirectionFromDataIndex(value3.Data, num16));
                                    }
                                }
                                using (Pen pen3 = new Pen(value3.LineColor, value3.LineThickness))
                                {
                                    if (value3.IsSmoothCurve)
                                    {
                                        graphics.DrawCurve(pen3, array5);
                                    }
                                    else
                                    {
                                        graphics.DrawLines(pen3, array5);
                                    }
                                }
                            }
                        }
                    }
                }
                base.OnPaint(e);
            }
            catch (Exception exc)
            {
                e.Graphics.DrawString(exc.Message, this.Font, Brushes.Black, 10, 10);
            }
        }

        /// <summary>
        /// Draws the mark point.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="markText">The mark text.</param>
        /// <param name="center">The center.</param>
        /// <param name="color">The color.</param>
        /// <param name="markTextPosition">The mark text position.</param>
        private void DrawMarkPoint(Graphics g, string markText, PointF center, Color color, MarkTextPositionStyle markTextPosition)
        {
            if (!string.IsNullOrEmpty(markText))
            {
                using (Brush brush = new SolidBrush(color))
                {
                    DrawMarkPoint(g, markText, center, brush, markTextPosition);
                }
            }
        }

        /// <summary>
        /// Draws the mark point.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="markText">The mark text.</param>
        /// <param name="center">The center.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="markTextPosition">The mark text position.</param>
        private void DrawMarkPoint(Graphics g, string markText, PointF center, Brush brush, MarkTextPositionStyle markTextPosition)
        {
            if (!string.IsNullOrEmpty(markText))
            {
                g.FillEllipse(brush, new RectangleF(center.X - 3f, center.Y - 3f, 6f, 6f));
                switch (markTextPosition)
                {
                    case MarkTextPositionStyle.Left:
                        g.DrawString(markText, Font, brush, new RectangleF(center.X - 100f, center.Y - (float)Font.Height, 100 - MarkText.MarkTextOffect, Font.Height * 2), format_right);
                        break;
                    case MarkTextPositionStyle.Up:
                        g.DrawString(markText, Font, brush, new RectangleF(center.X - 100f, center.Y - (float)Font.Height - (float)MarkText.MarkTextOffect, 200f, Font.Height + 2), format_center);
                        break;
                    case MarkTextPositionStyle.Right:
                        g.DrawString(markText, Font, brush, new RectangleF(center.X + (float)MarkText.MarkTextOffect, center.Y - (float)Font.Height, 100f, Font.Height * 2), format_left);
                        break;
                    case MarkTextPositionStyle.Down:
                        g.DrawString(markText, Font, brush, new RectangleF(center.X - 100f, center.Y + (float)MarkText.MarkTextOffect, 200f, Font.Height + 2), format_center);
                        break;
                }
            }
        }

        /// <summary>
        /// Determines whether [is need paint dash] [the specified paint value].
        /// </summary>
        /// <param name="paintValue">The paint value.</param>
        /// <returns><c>true</c> if [is need paint dash] [the specified paint value]; otherwise, <c>false</c>.</returns>
        private bool IsNeedPaintDash(float paintValue)
        {
            for (int i = 0; i < auxiliary_lines.Count; i++)
            {
                if (Math.Abs(auxiliary_lines[i].PaintValue - paintValue) < (float)font_size9.Height)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Calculates the data count by offect.
        /// </summary>
        /// <param name="offect">The offect.</param>
        /// <returns>System.Int32.</returns>
        private int CalculateDataCountByOffect(float offect)
        {
            if (value_IntervalAbscissaText > 0)
            {
                return value_IntervalAbscissaText;
            }
            if (offect > 40f)
            {
                return 1;
            }
            offect = 40f / offect;
            return (int)Math.Ceiling(offect);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">为 true 则释放托管资源和非托管资源；为 false 则仅释放非托管资源。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.Transparent;
            base.Name = "HslCurve";
            base.Size = new System.Drawing.Size(417, 205);
            ResumeLayout(false);
        }
    }
}
