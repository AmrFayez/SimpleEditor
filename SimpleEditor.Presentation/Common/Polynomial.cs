using SimpleEditor.Presentation.Geometry2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace SimpleEditor.Presentation.Common
{
    
    public class Polynomial
    {
        public enum Position
        {
            Start,Center
        }
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
        public List<PointF> Points { get; set; }
        public Polynomial(List<PointF> points)
        {
            Points = points;
            Initialize();
        }
        public Polynomial(GCurve curve) :
            this(new List<PointF>() { curve.Start, curve.Center, curve.End })
        {

        }

        public PointF MidPoint(Position position)
        {
            if (position==Position.Start)
            {
                var x = Points[0].Mid(Points[1]).X;
                var y = A * x * x + B * x + C;
                return new PointF(x, y);
            }
            else  
          
            {
                var x = Points[1].Mid(Points[2]).X;
                var y = A * x * x + B * x + C;
                return new PointF(x, y);
            }
           
           
        }

        private void Initialize()
        {
            var p1 = Points[0];
            var p2 = Points[1];
            var p3 = Points[2];
            #region old


            //A = p1.X * (p3.Y - p2.Y) +
            //    p2.X * (p1.Y - p3.Y) +
            //    p3.X * (p2.Y - p1.Y) /
            //    ((p1.X - p2.X) * (p1.X - p3.X) * (p2.X - p3.X));
            //B = (p2.Y - p1.Y) / (p2.X - p1.X) - A * (p1.X - p2.X);
            //C = p1.Y - A * (p1.X * p1.X) - B * p1.X;
            #endregion
            //A_1=-x_1^2+x_2^2
            var A1 = -(p1.X * p1.X) + (p2.X * p2.X);
            var B1 = -p1.X + p2.X;
            var D1 = -p1.Y + p2.Y;

            var A2 = -(p2.X * p2.X) + (p3.X * p3.X);
            var B2 = -p2.X + p3.X;
            var D2 = -p2.Y + p3.Y;
            var Bmulti = -(B2 / B1);
            var A3 = Bmulti * A1 + A2;
            var D3 = Bmulti * D1 + D2;
            A = D3 / A3;
            B = (D1 - A1 * A) / B1;
            C = p1.Y - A * (p1.X * p1.X) - B * p1.X;


        }

       
    }

}
