using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEditor.Presentation.Geometry2D
{
    public class GArc : GShape
    {
        public static Brush ArcFill { get; set; }
        public static Brush ArcStroke { get; set; }
        public static float ArcWidth { get; set; }
        public static Brush CenterPointFill { get; set; }
        public static Brush CenterPointStroke { get; set; }
        public PointF Start { get; set; }
        public float Diameter { get; set; }
        public float Height { get; set; }
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }

        public GArc(PointF start, float diameter, float height, float startAngle, float sweepAngle)
        {
            Start = start;
            Diameter = diameter;
            Height = height;
            StartAngle = startAngle;
            SweepAngle = sweepAngle;
            Stroke = ArcStroke;
            Fill = ArcFill;
            Width = ArcWidth;
        }

        public override void IntersectWith(GShape gShape)
        {
            IntersectionResult res;
            if (gShape is GLine)
            {
                res = Intersection.ArcLine(this, (GLine)gShape);
                if (res.IntersectionPoints.Count == 0) return;
                IntersectionResults.Add(res);
            }

        }
        public override void Draw(Graphics g)
        {

            //set Pen Properties Before Drawing
            Pen.Brush = Stroke;
            Pen.Width = Width;
            g.DrawArc(Pen, Start.X, Start.Y, Diameter, Height, StartAngle, SweepAngle);
            ResetPen();
            DrawIntersectedPoints(g);
        }
    }
}
