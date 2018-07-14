using SimpleEditor.Presentation.Common;
using SimpleEditor.Presentation.Geometry2D;
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
    public partial class SimpleEditorW : Form
    {
        #region  Drawing Properties

        private Editor2D editor;
        
        #endregion

        #region Constructor
        public SimpleEditorW()
        {
            InitializeComponent();
            KeyPreview = true;
           
           editor = new Editor2D(editorWindow);
            tabControl1.SelectTab(1);
        }
        #endregion

        #region Control Events
        

        #endregion

       
        #region Menue Buttons Events
        private void btn_new_Click(object sender, EventArgs e)
        {

        }
        private void btn_line_Click(object sender, EventArgs e)
        {
            editor.ActiveCommand = DrawCommands.Line;

        }
        private void btn_Rectangle_Click(object sender, EventArgs e)
        {
            editor.ActiveCommand = DrawCommands.Rectangle;
        }
        private void btn_Circle_Click(object sender, EventArgs e)
        {
            editor.ActiveCommand = DrawCommands.Circle;
        }
        private void btn_Curve_Click(object sender, EventArgs e)
        {
            editor.ActiveCommand = DrawCommands.Curve;
        }
        private void btn_PolyLine_Click(object sender, EventArgs e)
        {
            editor.ActiveCommand = DrawCommands.PolyLine;
            //editor.AddShape(tempPolyLine);

        }
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            //   TestCurveCurve();
            editor.ActiveCommand = DrawCommands.Noun;
            
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {

            editor.Clear();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
           editor.ProcessCmdKey(ref msg, keyData);

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
        //    var p2 = new Point(200, 60);
        //    var p3 = p1.Mid(p2);
        //    GeometryEngine.DrawPoint(g,p1);
        //    GeometryEngine.DrawPoint(g, p2);
        //    GeometryEngine.DrawPoint(g, p3);
        //}
        //public void TestCurveCurve()
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
        //    //curve 2

        //    var r1 = new PointF(100, 80);
        //    var r2 = new Point(200, 80);
        //    var r3 = new PointF(150, 180);
        //    var r = new Pen(Brushes.Red, 3);
        //    GCurve c2 = new GCurve(r1, r3, r2);
        //    c2.Draw(g);
        //    var c2c1 = new PointF(c2.Collider.Xmin, c2.Collider.Ymax);
        //    var c2c2 = new PointF(c2.Collider.Xmax, c2.Collider.Ymin);

        //    GRectangle rec2 = new GRectangle(c2c1, c2c2);
        //    var coll = gc.Collider.Collide(c2.Collider);
        //    rec2.Draw(g);
        //  gc.IntersectWith(c2);
        //    gc.Draw(g);
        //    c2.Draw(g);
        //}
        //public void curve()
        //{
        //    var p1 = new PointF(100, 100);
        //    var p2 = new Point(200, 100);
        //    var p3 = new PointF(140, 150);
        //    var p = new Pen(Brushes.Red, 3);
        //    GCurve gc = new GCurve(p1, p3, p2);
        //    Polynomial n = new Polynomial(gc);
        //    List<GCurve> curves=new List<GCurve>();
        //   var s1= gc.Divide();
        //    s1.ForEach( e=> curves.AddRange(e.Divide()));
        //    gc.Draw(g);
        //    curves.ForEach(d => d.Draw(g));
        //}
        #endregion

    }
}
