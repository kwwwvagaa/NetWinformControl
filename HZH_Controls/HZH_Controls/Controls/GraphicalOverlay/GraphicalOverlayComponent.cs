using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    [DefaultEvent("Paint")]
    public partial class GraphicalOverlayComponent : Component
    {
        public event EventHandler<PaintEventArgs> Paint;
        
        public GraphicalOverlayComponent()
        {
            InitializeComponent();
        }

        public GraphicalOverlayComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        private Control owner;
        [Browsable(true), Category("自定义属性"), Description("父控件"), Localizable(true)]    
        public Control Owner
        {
            get { return owner; }
            set
            {
                // The owner form cannot be set to null.
                if (value == null)
                    return;

                // The owner form can only be set once.
                if (owner != null)
                    return;

                // Save the form for future reference.
                owner = value;

                // Handle the form's Resize event.
                owner.Resize += new EventHandler(Form_Resize);

                // Handle the Paint event for each of the controls in the form's hierarchy.
                ConnectPaintEventHandlers(owner);
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            owner.Invalidate(true);
        }

        private void ConnectPaintEventHandlers(Control control)
        {

            Type type = control.GetType();
            System.Reflection.PropertyInfo pi = type.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(control, true, null);
           
            
            control.Paint -= new PaintEventHandler(Control_Paint);
            control.Paint += new PaintEventHandler(Control_Paint);

            control.ControlAdded -= new ControlEventHandler(Control_ControlAdded);
            control.ControlAdded += new ControlEventHandler(Control_ControlAdded);

            // Recurse the hierarchy.
            foreach (Control child in control.Controls)
                ConnectPaintEventHandlers(child);
        }

        private void Control_ControlAdded(object sender, ControlEventArgs e)
        {
            // Connect the paint event handler for the new control.
            ConnectPaintEventHandlers(e.Control);
        }

        private void Control_Paint(object sender, PaintEventArgs e)
        {
            if (e == null) return;

            // As each control on the form is repainted, this handler is called.

            Control control = sender as Control;
            Point location;

            // Determine the location of the control's client area relative to the form's client area.
            if (control == owner)
                // The form's client area is already form-relative.
                location = control.Location;
            else
            {
                // The control may be in a hierarchy, so convert to screen coordinates and then back to form coordinates.
                location = owner.PointToClient(control.Parent.PointToScreen(control.Location));

                // If the control has a border shift the location of the control's client area.
                location += new Size((control.Width - control.ClientSize.Width) / 2, (control.Height - control.ClientSize.Height) / 2);
            }

            // Translate the location so that we can use form-relative coordinates to draw on the control.
            if (control != owner)
                e.Graphics.TranslateTransform(-location.X, -location.Y);

            // Fire a paint event.
            OnPaint(sender, e);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            // Fire a paint event.
            // The paint event will be handled in Form1.graphicalOverlay1_Paint().

            if (Paint != null)
                Paint(sender, e);
        }
    }
}

namespace System.Windows.Forms
{
    using System.Drawing;

    public static class Extensions
    {
        public static Rectangle Coordinates(this Control control)
        {
            // Extend System.Windows.Forms.Control to have a Coordinates property.
            // The Coordinates property contains the control's form-relative location.
            Rectangle coordinates;
            Form form = (Form)control.TopLevelControl;

            if (control == form)
                coordinates = form.ClientRectangle;
            else
                coordinates = form.RectangleToClient(control.Parent.RectangleToScreen(control.Bounds));

            return coordinates;
        }
    }
}
