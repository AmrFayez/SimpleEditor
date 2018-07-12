using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleEditor.Presentation.Geometry2D;
using System.Drawing.Drawing2D;

namespace SimpleEditor.Presentation.controls
{
    public partial class GCircle : UserControl
    {
        //public static int DefaultRadius { get; set; } = 20;
        //public static GStyle DefaultStyle { get; set; } 
        public PointF Center { get; set; }
        public int Radius { get; set; }
        //public GStyle Style { get; set; }
        public GCircle() : this(default(PointF), 0)
        {
          
           
           
        }

        public GCircle(PointF center, int radius)
        {
            Center = center;
            Radius = radius;
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
            BackColor = Color.Transparent;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            var c = new PointF(Center.X - Radius, Center.Y - Radius);
            pevent.Graphics.DrawEllipse(new Pen(Brushes.Red), new RectangleF(c, new SizeF(Radius * 2, Radius * 2)));

        }
        
    }
}
