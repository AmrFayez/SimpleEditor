using MathNet.Numerics.LinearAlgebra.Double;
using SimpleEditor.Presentation.Common;
using SimpleEditor.Presentation.controls;
using SimpleEditor.Presentation.Geometry2D;
using SimpleEditor.Presentation.Geometry2D.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEditor.Presentation
{
    public partial class MainWindow : Form
    {
        #region  Drawing Properties


        #endregion

        #region Constructor
        public MainWindow()
        {
            
            InitializeComponent();

            editor2D.Editor.StatusBar.Label = lbl_Status;
            KeyPreview = true;
            //var g = editor2DWindow.CreateGraphics();
            //
            tabControl1.SelectTab(1);
            //panel1.SizeChanged += Panel1_SizeChanged;
            
        }

        //private void panel1_sizechanged(object sender, eventargs e)
        //{
        //    editor2Dwindow.size = panel1.size;
        //    editor2Dwindow.invalidate();
        //    editor2Dwindow.refresh();
        //}
        //protected override void OnSizeChanged(EventArgs e)
        //{
        //    base.OnSizeChanged(e);
        //    editor2DWindow.Invalidate();
        //    editor2DWindow.Refresh();
        //}
        #endregion

        #region Control Events


        #endregion


        #region Menue Buttons Events
        private void btn_new_Click(object sender, EventArgs e)
        {

        }
        private void btn_line_Click(object sender, EventArgs e)
        {
            editor2D.Editor.ActiveCommand = DrawCommands.Line;

        }
        private void btn_Rectangle_Click(object sender, EventArgs e)
        {
            editor2D.Editor.ActiveCommand = DrawCommands.Rectangle;
        }
        private void btn_Circle_Click(object sender, EventArgs e)
        {
            editor2D.Editor.ActiveCommand = DrawCommands.Circle;
        }
        private void btn_Curve_Click(object sender, EventArgs e)
        {
            editor2D.Editor.ActiveCommand = DrawCommands.Parabola;
        }
        private void btn_PolyLine_Click(object sender, EventArgs e)
        {
            editor2D.Editor.ActiveCommand = DrawCommands.PolyLine;
            //editor2D.EditorAddShape(tempPolyLine);

        }
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            // TestCurveCurve();
           // TestMidPointFunction();
            //curve();
            editor2D.Editor.ActiveCommand = DrawCommands.Noun;

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {

            editor2D.Editor.Clear();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            editor2D.Editor.ProcessCmdKey(ref msg, keyData);

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

       

        #region Visualization Test Methods
        //public void TestCurveBoundries()
        //{
        //    var p1 = new PointF(100, 100);
        //    var p2 = new Point(200, 100);
        //    var p3 = new PointF(150, 50);
        //    var p = new Pen(Brushes.Red, 3);
        //    GCurve gc = new GCurve(p1, p3, p2);
        //    gc.Draw(g);
        //    var cp1 = new PointF(gc.Collider.Xmin, gc.Collider.Ymax);
        //    var cp2 = new PointF(gc.Collider.Xmax, gc.Collider.Ymin);

        //    GRectangle rec = new GRectangle(cp1, cp2);
        //    rec.Draw(g);
        //}
        //public void TestMidPointFunction()
        //{
        //    var p1 = new PointF(100, 100);
        //    var p2 = new Point(200, 100);
        //    var p3 = new PointF(150, 50);
        //    var mid = p1.Mid(p3);
        //    var mid2 = p3.Mid(p2);
            
        //    var g = editor2DWindow.CreateGraphics();
        //    GCurve c = new GCurve(p1, p3, p2);
            
        //    c.Draw(g);
         
        //   // Polynomial polynomial = new Polynomial(new List<PointF>() { p1, p2, p3 });
        //   //var p= polynomial.FromX(mid.X);

        //   // var gcurve = new GCurve(p1, p, p3);
        //   // gcurve.Draw(g);

        //   // var pp = polynomial.FromX(mid2.X);
        //   // Editor2D.DrawPoint(g, p);
        //   // Editor2D.DrawPoint(g, pp);
        //   // Editor2D.DrawPoint(g, p1);
        //   // Editor2D.DrawPoint(g, p2);
        //   // Editor2D.DrawPoint(g, p3);
         
        //}
        ////public void TestCurveCurve()
        ////{
        ////    var p1 = new PointF(100, 100);
        ////    var p2 = new Point(200, 100);
        ////    var p3 = new PointF(150, 50);
        ////    var p = new Pen(Brushes.Red, 3);
        ////    GCurve gc = new GCurve(p1, p3, p2);
        ////    gc.Draw(g);
        ////    var cp1 = new PointF(gc.Collider.Xmin, gc.Collider.Ymax);
        ////    var cp2 = new PointF(gc.Collider.Xmax, gc.Collider.Ymin);

        ////    GRectangle rec = new GRectangle(cp1, cp2);
        ////    rec.Draw(g);
        ////    //curve 2

        ////    var r1 = new PointF(100, 80);
        ////    var r2 = new Point(200, 80);
        ////    var r3 = new PointF(150, 180);
        ////    var r = new Pen(Brushes.Red, 3);
        ////    GCurve c2 = new GCurve(r1, r3, r2);
        ////    c2.Draw(g);
        ////    var c2c1 = new PointF(c2.Collider.Xmin, c2.Collider.Ymax);
        ////    var c2c2 = new PointF(c2.Collider.Xmax, c2.Collider.Ymin);

        ////    GRectangle rec2 = new GRectangle(c2c1, c2c2);
        ////    var coll = gc.Collider.Collide(c2.Collider);
        ////    rec2.Draw(g);
        ////  gc.IntersectWith(c2);
        ////    gc.Draw(g);
        ////    c2.Draw(g);
        ////}
        //public void curve()
        //{
            

        //    var g = editor2DWindow.CreateGraphics();
        //    var p1 = new PointF(100, 100);
        //    var p2 = new Point(200, 100);
        //    var p3 = new PointF(150, 150);
        //    GParabola gr = new GParabola( p1 ,p2 ,p3 );
        //    gr.Draw(g);
        //   // var p = new Pen(Brushes.Red, 3);
        //    GCurve gc = new GCurve(p1, p3, p2);
        //   // Polynomial n = new Polynomial(gc);
        //   // List<GCurve> curves = new List<GCurve>();
        //   // var s1 = gc.Divide();
        //   // s1.ForEach(e => curves.AddRange(e.Divide()));
        //   gc.Draw(g);
        //   // curves.ForEach(d => d.Draw(g));
        //}
        #endregion

    }
}
