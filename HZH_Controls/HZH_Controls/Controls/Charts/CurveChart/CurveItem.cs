using System.Drawing;

namespace HZH_Controls.Controls
{
	public class CurveItem
	{
		public float[] Data = null;

		public string[] MarkText = null;

		public float LineThickness
		{
			get;
			set;
		}

		public bool IsSmoothCurve
		{
			get;
			set;
		}

		public Color LineColor
		{
			get;
			set;
		}

		public bool IsLeftFrame
		{
			get;
			set;
		}

		public bool Visible
		{
			get;
			set;
		}

		public bool LineRenderVisiable
		{
			get;
			set;
		}

		public RectangleF TitleRegion
		{
			get;
			set;
		}
        private string renderFormat = "{0}";

        public string RenderFormat
        {
            get { return renderFormat; }
            set { renderFormat = value; }
        }
	


		public CurveItem()
		{
			LineThickness = 1f;
			IsLeftFrame = true;
			Visible = true;
			LineRenderVisiable = true;
			TitleRegion = new RectangleF(0f, 0f, 0f, 0f);
		}
	}
}
