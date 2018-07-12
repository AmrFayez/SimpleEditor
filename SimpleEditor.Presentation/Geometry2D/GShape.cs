using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEditor.Presentation.Geometry2D
{
    [Serializable]
    public abstract class GShape
    {
        public static Pen Pen { get; set; } 
        public Brush Stroke { get; set; }
        public Brush Fill { get; set; }
        public float Width { get; set; }
        public List<IntersectionResult> IntersectionResults { get; set; }
        public GShape() :this(Setup.PenBrush,Setup.DefaultFill,Setup.PenWidth)
        {
            
        }

        public GShape(Brush stroke, Brush fill, float width)
        {
            Stroke = stroke;
            Fill = fill;
            Width = width;
            IntersectionResults = new List<IntersectionResult>();
        }

        public virtual void Draw(Graphics g)
        {

        }
        public virtual void IntersectWith(GShape gShape)
        {

        }
        public virtual void DrawIntersectedPoints(Graphics g)
        {
            if (IntersectionResults.Count==0)
            {
                return;
            }
            var points = IntersectionResults.Select(p => p.IntersectionPoints).SelectMany(d => d).ToList();
            GeometryEngine.DrawPoint(g, points);
        }

        public  void ResetPen()
        {
            Pen.Brush = Brushes.Black;
            Pen.Width = 2;
        }
    }
}
