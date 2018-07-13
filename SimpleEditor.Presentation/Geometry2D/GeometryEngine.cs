using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace SimpleEditor.Presentation.Geometry2D
{
    [Serializable]
    public class GeometryEngine
    {

        #region Properties
        public  List<GShape> Shapes
        {
            get;
            set;
        }
        public List<GShape> ActiveSet { get; set; }
        public DrawCommands ActiveCommand { get; set; }
        #endregion

        #region Constructors
        public GeometryEngine()
        {
            Shapes = new List<GShape>();
        }
        #endregion

        public void AddShape(GShape gShape)
        {
            Shapes.Add(gShape);
            //return if empty
            if (Shapes.Count == 0)
            {
                return;
            }
            CheckIntersection(gShape);
        }
        private void CheckIntersection(GShape gShape)
        {
            //check intersection
            // more optimized algo will be done here
            if (Shapes.Count <= 1)
            {
                return;
            }
            foreach (var shape in Shapes.Take(Shapes.Count - 1))
            {
                gShape.IntersectWith(shape);
            }
        }
        private void GetActiveSet(GShape gShape)
        {
            if (Shapes.Count <= 1)
            {
                return;
            }

            foreach (var shape in Shapes.Take(Shapes.Count - 1))
            {
                gShape.IntersectWith(shape);
            }
        }

        #region Draw Methods
        public void Paint(Graphics g)
        {
            if (Shapes.Count == 0)
            {
                return;
            }
            foreach (var shape in Shapes)
            {
                shape.Draw(g);
            }

        }
        public static void DrawPoint(Graphics g, PointF p, Brush Fill = null, Brush Stroke = null)
        {
            Fill = Fill ?? Setup.PointFill;
            Stroke = Stroke ?? Setup.PointStroke;
            var rect = new RectangleF(
                    new PointF(p.X - Setup.PointRadius, p.Y - Setup.PointRadius),
                    new SizeF(Setup.PointRadius * 2, Setup.PointRadius * 2));

            g.FillEllipse(Fill, rect);
            GShape.Pen.Brush = Stroke;
            g.DrawEllipse(GShape.Pen, rect);
        }
        public static void DrawPoint(Graphics g, List<PointF> points, Brush Fill = null, Brush Stroke = null)
        {
            if (points == null)
            {
                return;
            }
            foreach (var p in points)
            {
                DrawPoint(g, p);
            }

        }
        #endregion

    }
}
