using SimpleEditor.Presentation.Common;
using SimpleEditor.Presentation.Geometry2D.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static System.Math;
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
            IntersectionResult result = new IntersectionResult();
            var coll = c1.Collider.Collide(c2.Collider);
            if (c1.Collider.Area >= GCurve.minCurveSegment &&
                c1.Collider.Area >= GCurve.minCurveSegment && c1.Collider.Collide(c2.Collider) && coll)
            {
                var set1 = c1.Divide();
                var set2 = c2.Divide();
                foreach (var s1 in set1)
                {
                    foreach (var s2 in set2)
                    {
                        result.IntersectionPoints.AddRange(CurveCurve(s1, s2).IntersectionPoints);
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

        #region Parabola Intersections
        public static IntersectionResult ParabolaLine(GParabola p, GLine l)
        {
            IntersectionResult result = new IntersectionResult();
            var lineeqn = l.GetLineEqn();
            var peqn = p.Polynomial;
            var a = peqn.A;
            var b = peqn.B - lineeqn[0];
            var c = peqn.C - lineeqn[1];
            var roots = Polynomial.GetRoots(a, b, c);
            if (roots == null)
            {
                return result;
            }
            foreach (var root in roots)
            {
                if (root < l.EndPoint.X && root > l.StartPoint.X)
                {
                    var y = root * lineeqn[0] + lineeqn[1];
                    var point = new PointF(root, y);
                    if (PointLine(l, point)) ;
                    {
                        result.IntersectionPoints.Add(point);
                    }

                }

            }
            return result;

        }

        public static IntersectionResult ParabolaRectangle(GCurve c, GRectangle r)
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
        public static IntersectionResult ParaoblaPolyLine(GCurve c, GPolyLine pl)
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
        public static IntersectionResult ParabolaParabola(GParabola p1, GParabola p2)
        {
            IntersectionResult result = new IntersectionResult();
            var poly1 = p1.Polynomial;
            var poly2 = p2.Polynomial;
            var a = poly1.A - poly2.A;
            var b = poly1.B - poly2.B;
            var c = poly1.C - poly2.C;
            var roots = Polynomial.GetRoots(a, b, c);
            var s1 = p1.Points.OrderBy(e => e.X).ToList();
            var s2 = p2.Points.OrderBy(d => d.X).ToList();
            var xMin = Math.Max(s1[0].X, s2[0].X);
            var xMax = Math.Min(s1[2].X, s2[2].X);
            if (roots == null)
            {
                return result;
            }
            foreach (var root in roots)
            {
                if (xMin <= root && root <= xMax)
                {
                    var intersectPoint1 = poly1.FromX(root);
                    result.IntersectionPoints.Add(intersectPoint1);

                }

            }
            return result;

        }
        public static IntersectionResult ParabolaCircle(GParabola parabola, GCircle circle)
        {
            

            IntersectionResult result = new IntersectionResult();
           // https://en.wikipedia.org/wiki/Quartic_function#Nature_of_the_roots
            var h = circle.Center.X;
            var k = circle.Center.Y;
            var r = circle.Radius;
            var poly = parabola.Polynomial;
            var a = poly.A * poly.A;
            var b = 2 * poly.A * poly.B;
            var c = (2 * poly.A * poly.C) - (2 * poly.A * k) + (b * b) + 1;
            var d = (2 * b * c) - (2 * b * k) - (2 * h);
            var e = (c * c - 2 * c * k + h * h + k * k - r * r);
            var p = (8 * a * c - 3 * b * b) / (8 * a * a);
            var q = (b * b * b - 4 * a * b * c + 8 * a * a * d) / (8 * Pow(a, 3));
            var delta_0 = c * c - 3 * b * d + 12 * a * e;
            var delta_1 = 2 * c * c * c - 9 * b * c * d + 27 * b * b * e + 27 * a * d * d - 72 * a * c * e;
            
            var delta = 256 * Pow(a, 3) * Pow(e, 3) - 192 * (a * a * b * d * e * e)
                - 128 * (a * a * c * c * e * e) + 144 * (a * a * c * d * d * e)
                - 27 * (a * a * Pow(d, 4)) + 144 * (a * b * b * c * e * e)
                - 6 * (a * b * b * d * d * e) - 80 * (a * b * c*c *d*e)
                + 18 * (a * b * c * Pow(d, 3)) + 16 * (a * Pow(c, 4) * e)
                - 4 * (a * Pow(c, 3) * d * d) - 27 * (Pow(b, 4) * e * e) +
                18 * (Pow(b, 3) * c * d * e) - 4 * (Pow(b, 3) * Pow(d, 3))
                - 4 * (b * b * Pow(c, 3) * e) + (b * b * c * c * d * d);

            var delta_diff = -27 * delta;

            double Q, S;
            if (delta>0)
            {
                var phy = Math.Acos(delta_1 /
                    (2 * Sqrt(Pow(delta_0, 3))
                    ));
                S = .5 * Sqrt(-(2 / 3) * p + (2 / 3 * a) * Sqrt(delta_0) * Cos(phy / 3));
            }

            else
            {
                Q = Pow(
              (delta_1 + Sqrt(delta_diff)) / 2
              , 1 / 3);
                S = .5 * Sqrt(
                -(2 / 3) * p + (1 / ((3 * a)) * (Q + delta_0 / Q))
                );

            }           
           
            if (delta != 0 && delta == 0)
            {

            }
            float t1, t2, t3, t4;
            //check for roots
            var d1 = -4 * S * S - 2 * p + q / S;
            if (d1 <= Setup.Tolerance)
                {
                    t1 = (float)(-b / 4 * a - S + .5 * Sqrt(d1));
                    t2 = (float)(-b / 4 * a - S - .5 * Sqrt(d1));
                }
            var d2 = -4 * S * S - 2 * p - q / S;
            if (d2 <= Setup.Tolerance)
            {
                t3 = (float)(-b / 4 * a - S + .5 * Sqrt(d2));
                t4 = (float)(-b / 4 * a - S - .5 * Sqrt(d2));
            }


            return result;
        }
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
