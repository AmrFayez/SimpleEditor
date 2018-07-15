using SimpleEditor.Presentation.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEditor.Presentation.Geometry2D.Shapes
{
    public class GParabola : GShape


    {
        #region  Static Properties

        
        public static Brush ParabolaFill { get; set; }
        public static Brush ParabolaStroke { get; set; }
        public static float ParabolaWidth { get; set; }
        public static Brush ParabolaPointFill { get; set; }
        public static Brush ParabolaPointStroke { get; set; }
        #endregion
        public Polynomial Polynomial { get; set; }
        public int Step { get; set; }
        public List<PointF> Points { get; set; }
        public List<PointF> PathPoints { get; set; }
        

        public GParabola() : this(default(PointF), default(PointF), default(PointF))
        {

        }
        public GParabola(PointF p1, PointF p2, PointF p3)
        {
            Step = 10;
            Points = new List<PointF>() { p1, p2, p3 };
            PathPoints = new List<PointF>();

            Width = ParabolaWidth;
            Stroke = ParabolaStroke;
        }
        public override void Draw(Graphics g)
        {
            DrawAsParabola(g);
            DrawIntersectedPoints(g);
        }
        public void DrawAsParabola(Graphics g)
        {
            PathPoints.Clear();
            if (Points[1].X == Points[2].X || Points[1].Y == Points[2].Y)
            {
                Points[2] = Points[0].Mid(Points[1]);
            }
            if (Points[0].X == Points[2].X || Points[0].Y == Points[2].Y)
            {
                Points[2] = Points[0].Mid(Points[2]);
            }
            Polynomial = new Polynomial(Points);
            var sorted = Points.OrderBy(e => e.X).ToList();
            var p1 = sorted[0];
            var p2 = sorted[1];
            var p3 = sorted[2];


            for (int i = 0; p1.X + (i * Step) <= p3.X; i += 1)
            {
                PathPoints.Add(Polynomial.FromX(p1.X + i * Step));
            }
            var path = new GraphicsPath();
            path.AddLines(PathPoints.ToArray());

            var pen = (Pen)Pen.Clone();
            pen.Brush = Stroke;
            pen.Width = Width;
            g.DrawPath(pen, path);
            pen.Dispose();
        }
        public override void IntersectWith(GShape gShape)
        {
            IntersectionResult res;

            if (gShape is GLine)
            {
                res = Intersection.ParabolaLine(this, (GLine)gShape);

                if (res.IntersectionPoints.Count == 0) return;

                IntersectionResults.Add(res);
            }
            else if (gShape is GParabola)
            {
                res = Intersection.ParabolaParabola(this, (GParabola)gShape);

                if (res.IntersectionPoints.Count == 0) return;

                IntersectionResults.Add(res);
            }
            else if (gShape is GCircle)
            {
                res = Intersection.ParabolaCircle(this, (GCircle)gShape);

                if (res.IntersectionPoints.Count == 0) return;

                IntersectionResults.Add(res);

            }

        }


    }
}
