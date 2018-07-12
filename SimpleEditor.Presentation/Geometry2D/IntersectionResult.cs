using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEditor.Presentation.Geometry2D
{
    public class IntersectionResult
    {
        public List<PointF> IntersectionPoints { get; set; }
        public GShape IntersectedShape { get; set; }
        public IntersectionType IntersectionType { get; set; }
        public IntersectionResult()
        {
            IntersectionPoints = new List<PointF>();
        }
    }
}
