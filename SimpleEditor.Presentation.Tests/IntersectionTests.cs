using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleEditor.Presentation.Common;
using SimpleEditor.Presentation.Geometry2D;

namespace SimpleEditor.Presentation.Tests
{
    [TestClass]
    public class IntersectionTests
    {
        [TestMethod]
        public void CircleCircle()
        {
            GCircle c1 = new GCircle(new PointF(5,5),10);
            GCircle c2= new GCircle(new PointF(0, 0), 20);
            c1.IntersectWith(c2);
            var ss = c1.IntersectionResults;
            Assert.IsTrue(c1.IntersectionResults.Count > 0);
        }
        [TestMethod]
        public void DistanceTest()
        {
            var p = new PointF(1, 1);
            var c = new PointF(5, 4);
            var distance = p.Distance(c);
            Assert.AreEqual(distance, 5);
        }
    }
}
