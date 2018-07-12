using SimpleEditor.Presentation.controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           
        }
        public override void IntersectWith(GShape gShape)
        {

        }

    }
}
