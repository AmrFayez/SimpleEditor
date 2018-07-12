using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEditor.Presentation.Common
{
    public static class PointExtension
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
        public static float Distance(this PointF p, PointF other)
        {

            return (float)Math.Sqrt(
                  Math.Pow(p.X - other.X, 2) +
                  Math.Pow(p.Y - other.Y, 2)
                  );

        }
        public static float Cross(this PointF p, PointF other)
        {
            return (p.X * other.Y) - (p.Y * other.X);
        }
        public static float AngleTo(this PointF p, PointF other)
        {
            return (float)(Math.Abs(
                    Math.Atan2(
                        (p.X * other.Y) - (other.X * p.Y),
                        (p.X * other.X) + (p.Y * other.Y))) *
                        180 / Math.PI);



        }

        public static PointF Normalize(this PointF p)
        {
            var l = p.Length();
            return new PointF(p.X / l, p.Y / l);

        }
        public static float Length(this PointF p)
        {

          return ((float) Math.Sqrt((p.X * p.X) + (p.Y * p.Y)));

        }
    }
}
