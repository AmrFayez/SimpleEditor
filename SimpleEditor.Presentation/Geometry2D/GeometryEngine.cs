using SimpleEditor.Presentation.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SimpleEditor.Presentation.Geometry2D
{
    public class GeometryEngine
    {

        #region Properties
      public  Editor2D Editor2D { get; set; }
        public List<GShape> Shapes
        {
            get;
            set;
        }
        private List<GShape> ActiveSet { get; set; }
        #endregion
        #region Constructors
        public GeometryEngine()
        {
            Shapes = new List<GShape>();
           
            Setup.Configure();
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
       

        #endregion




    }
}
