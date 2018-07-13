using SimpleEditor.Presentation.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SimpleEditor.Presentation.Geometry2D
{
    public class Intersection
    {
        #region Intersection Methods

        #region Line Intersections
        public static bool PointLine(GLine l, PointF p)
        {
            var d1 = l.StartPoint.Distance(p);
            var d2 = l.EndPoint.Distance(p);
            var length = l.StartPoint.Distance(l.EndPoint);
            var delta = d1 + d2;
            if (delta >= length - Setup.Tolerance && delta <= length + Setup.Tolerance)
            {
                return true;
            }
            else return false;
        }
        public static IntersectionResult LineLine(GLine l1, GLine l2)
        {
            var result = new IntersectionResult();
            var p = l1.StartPoint;
            var q = l2.StartPoint;
            var r = (l1.EndPoint).Sub(l1.StartPoint);
            var s = (l2.EndPoint).Sub(l2.StartPoint);
            var t = (float)((q.Sub(p)).Cross(s) / r.Cross(s));
            var point = p.Add((r.Scale(t)));
            if (PointLine(l2, point) && PointLine(l1, point))
            {
                result.IntersectionPoints.Add(point);
            }

            return result;
        }
        #endregion

        #region Circle Intersection
        public static IntersectionResult CircleCircle(GCircle c1, GCircle c2)
        {
            IntersectionResult result = new IntersectionResult();
            // the distance between 2 circles
            var d = c1.Center.Distance(c2.Center);
            if (d > c1.Radius + c2.Radius)
            {
                // return mo intersection
                return result;
            }

            else if (d < Math.Abs(c1.Radius - c2.Radius))
            {
                //Circle inside each other 
                // no intersections
                return result;
            }

            else if (d == 0 && c1.Radius == c2.Radius)
            {
                //then the circles are coincident
                return result;
            }
            else
            {
                result.IntersectionType = IntersectionType.Collide;
                //calculate intersection points
                double a, h;

                a = (c1.Radius * c1.Radius - c2.Radius * c2.Radius + d * d) / (2 * d);
                h = Math.Sqrt(Math.Abs(c1.Radius * c1.Radius - a * a));
                var P0 = c1.Center;
                var P1 = c2.Center;
                PointF P2 = P0.Add(P1.Sub(P0).Scale((float)(a / d)));

                float x3, y3, x4, y4;
                x3 = (float)(P2.X + h * (P1.Y - P0.Y) / d);
                y3 = (float)(P2.Y - h * (P1.X - P0.X) / d);
                x4 = (float)(P2.X - h * (P1.Y - P0.Y) / d);
                y4 = (float)(P2.Y + h * (P1.X - P0.X) / d);
                result.IntersectionPoints.Add(new PointF(x3, y3));
                result.IntersectionPoints.Add(new PointF(x4, y4));

                return result;
            }

        }
        public static IntersectionResult CircleLine(GCircle circle, GLine line)
        {
            var result = new IntersectionResult();
            float a, b, c, d, sqrt_d, t1, t2;
            PointF v;
            v = line.EndPoint.Sub(line.StartPoint);
            a = v.Dot(v);
            b = 2 * v.Dot(line.StartPoint.Sub(circle.Center));
            c = line.StartPoint.Dot(line.StartPoint)
                + circle.Center.Dot(circle.Center)
                - 2 * line.StartPoint.Dot(circle.Center)
                - circle.Radius * circle.Radius;
            d = b * b - 4 * a * c;


            // no intersection
            if (d < 0)
            {
                return result;
            }

            //  the line tangent to the circle
            else if (d <= .0000001)
            {
                t1 = -b / (2 * a);
                result.IntersectionType = IntersectionType.Tangent;
                var p1 = new PointF(line.StartPoint.X + t1 * v.X, line.StartPoint.Y + t1 * v.Y);
                result.IntersectionPoints.Add(p1);
                return result;
            }
            else
            {
                result.IntersectionType = IntersectionType.Collide;
                // there is possible 2 solutions
                sqrt_d = (float)Math.Sqrt(d);
                t1 = (-b + sqrt_d) / (2 * a);
                t2 = (-b - sqrt_d) / (2 * a);
                //check if the 2 intersection point contained in the line
                if ((0 <= t1 && t1 <= 1))
                {
                    var p1 = new PointF(line.StartPoint.X + t1 * v.X, line.StartPoint.Y + t1 * v.Y);
                    result.IntersectionPoints.Add(p1);
                }
                if (0 <= t2 && t2 <= 1)
                {
                    var p2 = new PointF(line.StartPoint.X + t2 * v.X, line.StartPoint.Y + t2 * v.Y);
                    result.IntersectionPoints.Add(p2);
                }
                return result;
            }
        }

        public static IntersectionResult CircleRectangle(GCircle circle, GRectangle rec)
        {
            var result = new IntersectionResult();
            foreach (var line in rec.Lines)
            {
                var intersect = CircleLine(circle, line);
                if (intersect.IntersectionPoints.Count > 0)
                {
                    result.IntersectionPoints.
                        AddRange(intersect.IntersectionPoints);
                }
            }
            return result;

        }
        public static IntersectionResult CirclePolyLine(GCircle circle, GPolyLine pl)
        {
            var result = new IntersectionResult();
            foreach (var line in pl.Lines)
            {
                var intersect = CircleLine(circle, line);
                if (intersect.IntersectionPoints.Count > 0)
                {
                    result.IntersectionPoints.
                        AddRange(intersect.IntersectionPoints);
                }
            }
            return result;

        }
        #endregion

        #region Arc Intersection
        public static IntersectionResult ArcCircle(GCircle circle, GLine line)
        {
            var result = new IntersectionResult();
            return result;
        }

        public static IntersectionResult ArcLine(GArc arc, GLine line)
        {
            var result = new IntersectionResult();
            double dx = line.EndPoint.X - line.StartPoint.X;
            double dy = line.EndPoint.Y - line.StartPoint.Y;
            double theta = Math.Atan2(dy, dx);
            var d = line.StartPoint.Distance(line.EndPoint);
            double r = d - ((arc.MajorAxe * arc.MinorAxe) /
                Math.Sqrt(Math.Pow(arc.MinorAxe * Math.Cos(theta), 2)
                + Math.Pow(arc.MajorAxe * Math.Sin(theta), 2)));

            result.IntersectionPoints.Add(
                new PointF((float)(line.StartPoint.X + r * Math.Cos(theta)),
                  (float)(line.StartPoint.Y + r * Math.Sin(theta)))
                  );
            return result;
        }

        public static IntersectionResult ArcArc(GArc arc, GLine line)
        {
            var result = new IntersectionResult();
            var d = line.EndPoint.Sub(line.StartPoint);
            var al = Math.Atan(d.Y / d.X);
            var endAngle = arc.StartAngle - arc.SweepAngle;
            //no intersection
            if (al < arc.StartAngle || al > endAngle)
            {
                return result;
            }
            else
            {

            }
            return result;
        }
        #endregion

        #region Curve Intersections
        public static IntersectionResult CurveLine(GCurve c, GLine l)
        {
            IntersectionResult result = new IntersectionResult();
            var l1 = new GLine(c.Center, c.Start);
            var l2 = new GLine(c.Center, c.End);
            var lines = new List<GLine>();
            lines.AddRange(Divide(l1, .25f));
            lines.AddRange(Divide(l2, .25f));
            //intersect line 1
            IntersectionResult temp;
            foreach (var line in lines)
            {
                temp = LineLine(l, line);
                if (temp.IntersectionPoints.Count != 0)
                {
                    result.IntersectionPoints.AddRange(temp.IntersectionPoints);
                }
            }

            return result;

        }

        public static IntersectionResult CurveRectangle(GCurve c, GRectangle r)
        {
            IntersectionResult result = new IntersectionResult();
            foreach (var line in r.Lines)
            {
                var temp = CurveLine(c, line);
                if (temp.IntersectionPoints.Count != 0)

                {
                    result.IntersectionPoints.AddRange(temp.IntersectionPoints);
                }
            }
            return result;
        }
        public static IntersectionResult CurvePolyLine(GCurve c, GPolyLine pl)
        {
            IntersectionResult result = new IntersectionResult();
            foreach (var line in pl.Lines)
            {
                var temp = CurveLine(c, line);
                if (temp.IntersectionPoints.Count != 0)

                {
                    result.IntersectionPoints.AddRange(temp.IntersectionPoints);
                }
            }
            return result;
        }

        /// <summary>
        /// use  Divide & Conquer Algorithm
        /// </summary>
        /// <param name="c1">Curve 1</param>
        /// <param name="c2">Curve 2</param>
        /// <returns></returns>
        /// http://processingjs.nihongoresources.com/intersections/
        public static IntersectionResult CurveCurve(GCurve c1, GCurve c2)
        {
            IntersectionResult result =new IntersectionResult();
            var coll = c1.Collider.Collide(c2.Collider);
            if (c1.Collider.Area >= GCurve.minCurveSegment &&
                c1.Collider.Area >= GCurve.minCurveSegment && c1.Collider.Collide(c2.Collider) &&coll)
            {
                var set1 = c1.Divide();
                var set2 = c2.Divide();
                foreach (var s1 in set1)
                {
                    foreach (var s2 in set2)
                    {
                      result.IntersectionPoints.AddRange( CurveCurve(s1, s2).IntersectionPoints);
                    }

                }

                return result;
            }
            //if true treat them as line
            else if (c1.Collider.Area <= GCurve.minCurveSegment &&
                    c1.Collider.Area <= GCurve.minCurveSegment && c1.Collider.Collide(c2.Collider))
            {
                var l1 = new GLine(c1.Start, c1.End);
                var l2 = new GLine(c2.Start, c2.End);
                var res = LineLine(l1, l2);
                if (res.IntersectionPoints.Count != 0)
                {
                    result.IntersectionPoints.AddRange(res.IntersectionPoints);
                }
                return result;
            }
            //there are no intersection points between the two curves
            else
            {
                return result;
            }

        }
        public static IntersectionResult CurveCircle(GCurve c, GCurve pl)
        {
            IntersectionResult result = new IntersectionResult();
            //foreach (var line in pl.Lines)
            //{
            //    var temp = CurveLine(c, line);
            //    if (temp.IntersectionPoints.Count != 0)

            //    {
            //        result.IntersectionPoints.AddRange(temp.IntersectionPoints);
            //    }
            //}
            return result;
        }
        #endregion
        #endregion
        public static void Intersect(GShape s1, GShape s2)
        {

        }
        public static List<GLine> Divide(GLine l, float maxDistance)
        {
            List<GLine> result = new List<GLine>();
            var distance = l.EndPoint.Distance(l.StartPoint);
            var direction = (l.EndPoint.Sub(l.StartPoint)).Normalize();
            var count = Equal(distance, maxDistance);
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    result.Add(new GLine(l.StartPoint, l.StartPoint.Add(direction.Scale(maxDistance))));
                }
                else
                {
                    var startPoint = result.LastOrDefault().EndPoint;
                    var line = new GLine(startPoint, l.StartPoint.Add(direction.Scale(maxDistance * i)));
                    result.Add(line);
                }
            }



            return result;

        }
        public static double Equal(double distance, double maxDistance)
        {
            List<double> res = new List<double>();
            var no = Math.Round(distance / maxDistance);
            return no;
        }
    }
}
