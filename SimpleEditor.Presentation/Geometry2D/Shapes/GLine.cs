using System.Drawing;

namespace SimpleEditor.Presentation.Geometry2D
{
    public class GLine : GShape
    {
        #region Static Properties


        public static Brush LineStroke { get; set; }
        public static float LineWidth { get; set; }
        public static float PointRadius { get; set; }
        public static Brush PointFill { get; set; }
        public static Brush PointStroke { get; set; }
        #endregion

        #region Properties
        public PointF StartPoint { get; set; }
        public PointF EndPoint { get; set; }
        #endregion

        #region Constructors
        public GLine(PointF startPoint, PointF endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Stroke = LineStroke;
            Width = LineWidth;
        }
        #endregion

        #region Methods
        public override void IntersectWith(GShape gShape)
        {
            if (gShape is GCircle)
            {
                var res = Intersection.CircleLine((GCircle)gShape, this);

                if (res.IntersectionPoints.Count > 0)
                {
                    IntersectionResults.Add(res);
                }

            }
            else if (gShape is GLine)
            {
                var res = Intersection.LineLine((GLine)gShape, this);

                if (res.IntersectionPoints.Count > 0)
                {
                    IntersectionResults.Add(res);
                }
            }

            else if (gShape is GRectangle)
            {
                foreach (var line in ((GRectangle)gShape).Lines)
                {
                    var res = Intersection.LineLine(line, this);

                    if (res.IntersectionPoints.Count > 0)
                    {
                        IntersectionResults.Add(res);
                    }
                }
            }
            else if (gShape is GPolyLine)
            {
                foreach (var line in ((GPolyLine)gShape).Lines)
                {
                    var res = Intersection.LineLine(line, this);

                    if (res.IntersectionPoints.Count > 0)
                    {
                        IntersectionResults.Add(res);
                    }
                }

            }
            else if (gShape is GCurve)
            {
                var res = Intersection.CurveLine((GCurve)gShape, this);
                if (res.IntersectionPoints.Count == 0) return;
                IntersectionResults.Add(res);
            }
        }
        //set pen brush
        public override void Draw(Graphics g)
        {
            Pen.Brush = Stroke;
            Pen.Width = Width;

            g.DrawLine(Pen, StartPoint, EndPoint);
            Editor2D.DrawPoint(g, StartPoint, PointFill, PointStroke);
            Editor2D.DrawPoint(g, EndPoint, PointFill, PointStroke);
            //draw intersected points
            DrawIntersectedPoints(g);
        }
        #endregion


    }
}
