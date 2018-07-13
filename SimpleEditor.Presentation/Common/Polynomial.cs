using SimpleEditor.Presentation.Geometry2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEditor.Presentation.Common
{
  public  class Polynomial
    {
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
        public List<PointF> Points { get; set; }
        public Polynomial(List<PointF>points)
        {
            Points = points;
            Initialize();
        }
        public Polynomial(GCurve curve):
            this(new List<PointF>() { curve.Start, curve.Center, curve.End })
        {

        }

       public  PointF MidPoint()
        {
            var x = Points[1].Mid(Points[2]).X;
            var y = A * x * x + B * x + C;
            return new PointF(x, y);
        }

        private void Initialize()
        {
            var p1 = Points[0];
            var p2 = Points[1];
            var p3 = Points[2];
            A = p1.X * (p3.Y - p2.Y) +
                p2.X * (p1.Y - p3.Y) +
                p3.X * (p2.Y - p1.Y) /
                ((p1.X - p2.X) * (p1.X - p3.X) * (p2.X - p3.X));
            B = (p2.Y - p1.Y) / (p2.X - p1.X) - A * (p1.X - p2.X);
            C = p1.Y - A * (p1.X * p1.X) - B * p1.X;


        }

        internal static PointF MidPoint(GCurve gCurve)
        {
          return  new Polynomial(gCurve).MidPoint();
        }
    }

}
