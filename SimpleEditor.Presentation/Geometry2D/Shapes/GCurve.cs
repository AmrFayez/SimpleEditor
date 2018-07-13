using SimpleEditor.Presentation.Common;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SimpleEditor.Presentation.Geometry2D
{
    public class GCurve : GShape
    {

        #region StaticProperties
        public static Brush CurveFill { get; set; }
        public static Brush CurveStroke { get; set; }
        public static float CurveWidth { get; set; }
        public static Brush CurvePointFill { get; set; }
        public static Brush CurvePointStroke { get; set; }
        public static float minCurveSegment { get; set; } = 2;
        #endregion

        #region Properties
        public PointF Start { get; set; }
        public PointF End { get; set; }
        public PointF Center { get; set; }

        #endregion

        public GCurve(PointF start, PointF center, PointF end)
        {
            Start = start;
            End = end;
            Center = center;
            Stroke = CurveStroke;
            Fill = CurveFill;
            Width = CurveWidth;
            CalcCollider();
        }

        public List<GCurve> Divide()
        {
            var result = new List<GCurve>();

            result.Add(new GCurve(Start, Polynomial.MidPoint(this), Center));
            result.Add(new GCurve(Center, Polynomial.MidPoint(this), End));
            return result;
        }

        public override void IntersectWith(GShape gShape)
        {
            IntersectionResult res;

            if (gShape is GLine)
            {
                res = Intersection.CurveLine(this, (GLine)gShape);

                if (res.IntersectionPoints.Count == 0) return;

                IntersectionResults.Add(res);
            }
            else if (gShape is GRectangle)
            {
                res = Intersection.CurveRectangle(this, (GRectangle)gShape);

                if (res.IntersectionPoints.Count == 0) return;

                IntersectionResults.Add(res);
            }

            else if (gShape is GCurve)
            {
                    res = Intersection.CurveCurve(this, (GCurve)gShape);

                    if (res.IntersectionPoints.Count == 0) return;
                    IntersectionResults.Add(res);
            }
        }
        public override void Draw(Graphics g)
        {

            //set Pen Properties Before Drawing
            Pen.Brush = Stroke;
            Pen.Width = Width;
            g.DrawCurve(Pen, new[] { Start, Center, End });
            ResetPen();
            DrawIntersectedPoints(g);
        }

        public override void CalcCollider()
        {
            List<PointF> pointSet = new List<PointF>()
            {
                Start,Center,End
            };
            var lx = pointSet.OrderBy(e => e.X);
            var ly = pointSet.OrderBy(p => p.Y);
            //set Collider Properties
            Collider.Xmin = lx.First().X;
            Collider.Xmax = lx.Last().X;
            Collider.Ymin = ly.First().Y;
            Collider.Ymax = ly.Last().Y;

        }
    }
}
