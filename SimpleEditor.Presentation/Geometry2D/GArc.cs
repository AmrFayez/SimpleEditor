using System;
using System.Drawing;

namespace SimpleEditor.Presentation.Geometry2D
{
    [Obsolete("Need To be Fixed")]
    public class GArc : GShape
    {

        #region StaticProperties
        public static Brush ArcFill { get; set; }
        public static Brush ArcStroke { get; set; }
        public static float ArcWidth { get; set; }
        public static Brush CenterPointFill { get; set; }
        public static Brush CenterPointStroke { get; set; }
        #endregion

        #region Properties
        
        public PointF Start { get; set; }
        public float MajorAxe { get; set; }
        public float MinorAxe { get; set; }
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }
        public PointF Center { get; set; }
        #endregion

        public GArc(PointF start, float diameter, float height, float startAngle, float sweepAngle)
        {
            Start = start;
            MajorAxe = diameter;
            MinorAxe = height;
            StartAngle = startAngle;
            SweepAngle = sweepAngle;
            Stroke = ArcStroke;
            Fill = ArcFill;
            Width = ArcWidth;
        }

        public override void IntersectWith(GShape gShape)
        {
            IntersectionResult res;
            //if (gShape is GLine)
            //{
            //    res = Intersection.ArcLine(this, (GLine)gShape);
            //    if (res.IntersectionPoints.Count == 0) return;
            //    IntersectionResults.Add(res);
            //}

             if (gShape is GRectangle)
            {
                new IntersectionResult();
                foreach (var line in ((GRectangle)gShape).Lines)
                {
                  res=  Intersection.ArcLine(this, line);
                    if (res.IntersectionPoints.Count == 0) return;
                    IntersectionResults.Add(res);
                }

            }

        }
        public override void Draw(Graphics g)
        {

            //set Pen Properties Before Drawing
            Pen.Brush = Stroke;
            Pen.Width = Width;
            g.DrawArc(Pen, Start.X, Start.Y, MajorAxe, MinorAxe, StartAngle, SweepAngle);
            ResetPen();
            DrawIntersectedPoints(g);
        }
        public void CalculatePosition()
        {

        }
      
    }
}
