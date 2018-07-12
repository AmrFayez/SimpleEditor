using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEditor.Presentation.Common
{
  public static  class PointExtension
    {
        public static PointF Sub(this PointF p1, PointF p2)
        {
            return new PointF(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static PointF Add(this PointF p1, PointF p2)
        {
            return new PointF(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static PointF Scale(this PointF p1, float value)
        {
            return new PointF(p1.X * value, p1.Y * value);
        }
        public static float Dot(this PointF p1, PointF P2)
        {
            return p1.X * P2.X + p1.Y * P2.Y;
        }
        public static double Distance(this PointF p,PointF other)
        {

            return Math.Sqrt(
                  Math.Pow(p.X - other.X, 2) +
                  Math.Pow(p.Y - other.Y, 2)
                  );

        }
        public static double Cross(this PointF p,PointF other)
        {
            return (p.X * other.Y) - (p.Y * other.X);
        }
    }
}
