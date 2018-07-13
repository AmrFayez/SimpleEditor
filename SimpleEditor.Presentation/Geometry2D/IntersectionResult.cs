using System.Collections.Generic;
using System.Drawing;

namespace SimpleEditor.Presentation.Geometry2D
{
    /// <summary>
    /// keep  Data about the  intersection happend
    /// </summary>
    public class IntersectionResult
    {
        public List<PointF> IntersectionPoints { get; set; }
        public GShape IntersectedWith{ get; set; }
        public IntersectionType IntersectionType { get; set; }
        public IntersectionResult()
        {
            IntersectionPoints = new List<PointF>();
        }
    }
}
