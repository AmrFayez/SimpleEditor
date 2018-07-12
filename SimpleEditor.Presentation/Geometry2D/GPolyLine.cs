using System.Collections.Generic;
using System.Drawing;

namespace SimpleEditor.Presentation.Geometry2D
{
    public class GPolyLine : GShape
    {
        public List<GLine> Lines { get; set; }
        public GPolyLine()
        {
            Stroke = GLine.LineStroke;
            Width = GLine.LineWidth;
            Lines = new List<GLine>();
        }
        public override void Draw(Graphics g)
        {
            Pen.Brush = Stroke;
            Pen.Width = Width;
            Lines.ForEach(e => e.Draw(g));
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
                    var res = Intersection.CirclePolyLine((GCircle)gShape, this);

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

            else if (gShape is GPolyLine)
            {
                foreach (var line in Lines)
                {
                    foreach (var pLine in ((GPolyLine)gShape).Lines)
                    {
                        var res = Intersection.LineLine(line, pLine);

                        if (res.IntersectionPoints.Count == 0) continue;

                        IntersectionResults.Add(res);
                    }

                }
            }
            else if (gShape is GArc)
            {
                IntersectionResult res=new IntersectionResult();
                foreach (var line in Lines)
                {
                     Intersection.ArcLine((GArc)gShape, line);
                    if (res.IntersectionPoints.Count == 0) return;
                    IntersectionResults.Add(res);
                }
                
            }
        }
    }
}
