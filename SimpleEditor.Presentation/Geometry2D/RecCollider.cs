using System;

namespace SimpleEditor.Presentation.Geometry2D
{
    /// <summary>
    /// it represent rectanhular boundry around the shape
    /// </summary>
    public class RecCollider
    {
        
        public float Xmin { get; set; }
        public float Ymin { get; set; }
        public float Xmax { get; set; }
        public float Ymax { get; set; }

        public float Area { get { return (Xmax - Xmin) * (Ymax - Ymin); } }
        public RecCollider(float xmin, float ymin, float xmax, float ymax)
        {
            Xmin = xmin;
            Ymin = ymin;
            Xmax = xmax;
            Ymax = ymax;
        }
        public RecCollider()
        {

        }

        /// <summary>
        /// returns true of there is overlap
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        internal bool Collide(RecCollider other)
        {
            // If one rectangle is on left side of other
            if (Ymax<other. Ymin && Ymin<other.Ymin)
            {
                return false;
            }
            // If one rectangle is above other
            if (Xmax<other.Xmin && other.Xmin>Xmax)
            {
                return false;
            }
            return true;
        }
    }
}
