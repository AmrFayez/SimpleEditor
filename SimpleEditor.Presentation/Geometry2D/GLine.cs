using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEditor.Presentation.Geometry2D
{
    public class GLine : GShape, IIntersect
    {
        public static Brush LineStroke { get; set; }
        public static float LineWidth { get; set; }
        public static float PointRadius { get; set; }
        public static Brush PointFill { get; set; }
        public static Brush PointStroke { get; set; }
        public PointF StartPoint { get; set; }
        public PointF EndPoint { get; set; }
        public GLine(PointF startPoint, PointF endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Stroke =LineStroke;
            Width = LineWidth;
        }
        public override void IntersectWith(GShape gShape)
        {
            if (gShape is GCircle)
            {
                var res = GeometryEngine.CircleLine((GCircle)gShape, this);

                if (res.IntersectionPoints.Count > 0)
                {
                    IntersectionResults.Add(res);
                }

            }
            else if (gShape is GLine)
            {
                var res = GeometryEngine.LineLine((GLine)gShape, this);

                if (res.IntersectionPoints.Count > 0)
                {
                    IntersectionResults.Add(res);
                }
            }

            else if (gShape is GRectangle)
            {
                foreach (var line in ((GRectangle)gShape).Lines)
                {
                    var res = GeometryEngine.LineLine(line, this);

                    if (res.IntersectionPoints.Count > 0)
                    {
                        IntersectionResults.Add(res);
                    }
                }
            }
        }
        //set pen brush
        public override void Draw(Graphics g)
        {
            Pen.Brush = Stroke;
            Pen.Width = Width;
           
            g.DrawLine(Pen, StartPoint, EndPoint);
            GeometryEngine.DrawPoint(g, StartPoint,PointFill,PointStroke);
            GeometryEngine.DrawPoint(g, EndPoint, PointFill, PointStroke);
            //draw intersected points
            DrawIntersectedPoints(g);
        }
    }
}
