using SimpleEditor.Presentation.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Lines.Add(new GLine(FirstCorner, p1));
            Lines.Add(new GLine(FirstCorner, p2));
            Lines.Add(new GLine(SecondCorner, p1));
            Lines.Add(new GLine(SecondCorner, p2));
            foreach (var line in Lines)
            {
                line.Draw(g);
            }
            DrawIntersectedPoints(g);
        }

        public override void IntersectWith(GShape gShape)
        {
            if (gShape is GLine)
            {
                foreach (var line in Lines)
                {
                    var res = Intersection.LineLine((GLine)gShape, line);

                    if (res.IntersectionPoints.Count > 0)
                    {
                        IntersectionResults.Add(res);
                    }
                }
            }
            else if (gShape is GCircle)
            {
                foreach (var line in Lines)
                {
                    var res = Intersection.CircleRectangle((GCircle)gShape, this);

                    if (res.IntersectionPoints.Count == 0) return;

                    IntersectionResults.Add(res);
                }
            }
            else if (gShape is GRectangle)
            {
                foreach (var line in Lines)
                {
                    foreach (var recLine in ((GRectangle)gShape).Lines)
                    {
                        var res = Intersection.LineLine(line, recLine);

                        if (res.IntersectionPoints.Count == 0) continue;

                        IntersectionResults.Add(res);
                    }

                }
            }
        }

    }
}
