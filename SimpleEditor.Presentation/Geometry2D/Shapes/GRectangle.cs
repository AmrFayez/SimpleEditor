using System.Collections.Generic;
using System.Drawing;

namespace SimpleEditor.Presentation.Geometry2D
{
    public class GRectangle : GShape
    {

        public PointF FirstCorner { get; set; }
        public PointF SecondCorner { get; set; }
        public List<GLine> Lines { get; set; }

        public GRectangle(PointF firstCorner, PointF secondCorner)
        {
            FirstCorner = firstCorner;
            SecondCorner = secondCorner;
            Stroke = GLine.LineStroke;
            Width = GLine.LineWidth;
            Lines = new List<GLine>();
        }

        public override void Draw(Graphics g)
        {
            if (Lines.Count != 0)
            {
                Lines.Clear();
            }

            Pen.Brush = Stroke;
            Pen.Width = Width;
            var width = FirstCorner.X - SecondCorner.X;
            var height = FirstCorner.Y - SecondCorner.Y;
            var p1 = new PointF(FirstCorner.X, FirstCorner.Y - height);
            var p2 = new PointF(FirstCorner.X - width, FirstCorner.Y);
            Lines.Add(new GLine(FirstCorner, p1) { DrawPoints=false});
            Lines.Add(new GLine(FirstCorner, p2) { DrawPoints = false });
            Lines.Add(new GLine(SecondCorner, p1) { DrawPoints = false });
            Lines.Add(new GLine(SecondCorner, p2) { DrawPoints = false });
            foreach (var line in Lines)
            {
                line.Draw(g);
            }
            DrawIntersectedPoints(g);
        }

        public override void IntersectWith(GShape gShape)
        {
            IntersectionResult result;
            if (gShape is GLine)
            {
                foreach (var line in Lines)
                {
                    result = Intersection.LineLine((GLine)gShape, line);

                    if (result.IntersectionPoints.Count > 0)
                    {
                        IntersectionResults.Add(result);
                    }
                }
            }
            else if (gShape is GCircle)
            {
                foreach (var line in Lines)
                {
                    result = Intersection.CircleRectangle((GCircle)gShape, this);

                    if (result.IntersectionPoints.Count == 0) return;

                    IntersectionResults.Add(result);
                }
            }
            else if (gShape is GRectangle)
            {
                foreach (var line in Lines)
                {
                    foreach (var recLine in ((GRectangle)gShape).Lines)
                    {
                        result = Intersection.LineLine(line, recLine);

                        if (result.IntersectionPoints.Count == 0) continue;

                        IntersectionResults.Add(result);
                    }

                }
            }

            else if (gShape is GPolyLine)
            {
                foreach (var line in Lines)
                {
                    foreach (var pLine in ((GPolyLine)gShape).Lines)
                    {
                        result = Intersection.LineLine(line, pLine);

                        if (result.IntersectionPoints.Count == 0) continue;

                        IntersectionResults.Add(result);
                    }

                }
            }

            else if (gShape is GCurve)
            {
                result = Intersection.CurveRectangle( (GCurve)gShape,this);

                if (result.IntersectionPoints.Count == 0) return;

                IntersectionResults.Add(result);
            }
        }

    }
}
