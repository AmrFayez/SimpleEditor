using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEditor.Presentation.Common
{
   public static class NumericExtensions
    {
        public static float ToDegrees(this float n)
        {

            return (float)( n * 180 / Math.PI);

        }
        public static float ToDegrees(this double n)
        {

            return (float)(n * 180 / Math.PI);

        }
    }
}
