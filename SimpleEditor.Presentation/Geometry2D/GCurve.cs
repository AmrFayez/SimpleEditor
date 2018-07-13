using System.Drawing;

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
        #endregion

        #region Properties
        public PointF Start { get; set; }
        public PointF End { get; set; }
        public PointF Center { get; set; }
        
        #endregion

        public GCurve(PointF start, PointF center,PointF end)
        {
            Start = start;
            End = end;
            Center = center;
            Stroke = CurveStroke;
            Fill = CurveFill;
            Width = CurveWidth;
        }

        public override void IntersectWith(GShape gShape)
        {
            IntersectionResult res;
            

        }
        public override void Draw(Graphics g)
        {

            //set Pen Properties Before Drawing
            Pen.Brush = Stroke;
            Pen.Width = Width;
            g.DrawCurve(Pen, new[] { Start,Center,End});
            ResetPen();
            DrawIntersectedPoints(g);
        }
        public void CalculatePosition()
        {

        }

    }
}
