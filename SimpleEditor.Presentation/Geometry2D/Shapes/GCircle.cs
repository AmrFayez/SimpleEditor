using System.Drawing;

namespace SimpleEditor.Presentation.Geometry2D
{
    public class GCircle : GShape  
    {
        #region Static Properties

        
        public static Brush CircleFill { get; set; }
        public static Brush CircleStroke { get; set; }
        public static float CircleWidth { get; set; }
        public static Brush CenterPointFill { get; set; }
        public static Brush CenterPointStroke { get; set; }
        #endregion

        #region Properties


        public PointF Center { get; set; }
        public float Radius { get; set; }
        #endregion


        #region Constructors

        
        public GCircle(PointF center, float radius)
        {
            Center = center;
            Radius = radius;
            Stroke = CircleStroke;
            Fill = CircleFill;
            Width = CircleWidth;
        }
        #endregion

        #region Methods
        public override void Draw(Graphics g)
        {
            //drawing center
            var c = new PointF(Center.X - Radius, Center.Y - Radius);
            var rec = new RectangleF(c, new SizeF(Radius * 2, Radius * 2));
            //set the pen brush first;
            Pen.Brush = Stroke;
            Pen.Width = Width;
            g.DrawEllipse(Pen, rec);
            g.FillEllipse(Fill, rec);
            Editor2D.DrawPoint(g, Center, CenterPointFill, CenterPointStroke);
            ResetPen();
            DrawIntersectedPoints(g);
        }
        public override void IntersectWith(GShape gShape)
        {
            IntersectionResult res;
            if (gShape is GCircle)
            {
                 res = Intersection.CircleCircle(this, (GCircle)gShape);

                if (res.IntersectionPoints.Count == 0) return;

                IntersectionResults.Add(res);
            }
            else if (gShape is GLine)
            {
                  res = Intersection.CircleLine(this, (GLine)gShape);

                if (res.IntersectionPoints.Count == 0) return;

                IntersectionResults.Add(res);
            }
            else if (gShape is GRectangle)
            {
                  res = Intersection.CircleRectangle(this, (GRectangle)gShape);

                if (res.IntersectionPoints.Count == 0) return;

                IntersectionResults.Add(res);

            }
            else if (gShape is GPolyLine)
            {
                foreach (var line in ((GPolyLine)gShape).Lines)
                {
                      res = Intersection.CircleLine( this, line);

                    if (res.IntersectionPoints.Count > 0)
                    {
                        IntersectionResults.Add(res);
                    }
                }

            }
          
        }
        #endregion

    }
}
