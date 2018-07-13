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
        PointF p1;
        PointF p2;
        PointF delta_Y;
        public GeometryEngine ge = new GeometryEngine();
        private int clickCount;
        public Graphics g;
        private GShape tempShape;
        private GPolyLine tempPolyLine;
        private GArc tempArc;
        #endregion

        #region Constructor
        public SimpleEditorW()
        {
            InitializeComponent();

            editorWindow.MouseDown += EditorWindow_MouseDown;
            editorWindow.MouseMove += EditorWindow_MouseMove;
            editorWindow.MouseUp += EditorWindow_MouseUp;
            editorWindow.Paint += EditorWindow_Paint;
            editorWindow.KeyPress += EditorWindow_KeyPress;
            editorWindow.MouseDoubleClick += EditorWindow_MouseDoubleClick;
            tabControl1.SelectTab(1);
            g = editorWindow.CreateGraphics();

            Setup.Configure();
        }
        #endregion

        #region Control Events
        private void EditorWindow_KeyPress(object sender, KeyPressEventArgs e)
        {

            switch (e.KeyChar)
            {
                //case '\u001b':
                //    clickCount = 0;
                //    var t = tempPolyLine;
                //    ge.ActiveCommand = DrawCommands.Noun;
                //    tempShape = null;
                //    tempPolyLine = null;
                //    break;
                //default:
                //    break;
            }

        }

        private void EditorWindow_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (tempShape != null)
            {
                tempShape.Draw(e.Graphics);
            }

            ge.Paint(e.Graphics);

        }
        protected override void OnResize(EventArgs e)
        {


            editorWindow.Size = Size;

        }

        #endregion

        #region Mouse Events
        private void EditorWindow_MouseDown(object sender, MouseEventArgs e)
        {

            if (ge.ActiveCommand != DrawCommands.Noun)
            {
                clickCount++;
                p1 = p2 = new PointF(e.X, e.Y);
            }


        }
        private void EditorWindow_MouseMove(object sender, MouseEventArgs e)
        {

            if (ge.ActiveCommand != DrawCommands.Noun && clickCount >= 1)
            {
                delta_Y = p2.Sub(e.Location);
                p2 = new PointF(e.X, e.Y);

                switch (ge.ActiveCommand)
                {
                    case DrawCommands.Line:
                        tempShape = new GLine(p1, p2);
                        break;
                    case DrawCommands.Circle:
                        tempShape = new GCircle(p1, (float)p1.Distance(p2));
                        break;
                    case DrawCommands.Rectangle:

                        tempShape = new GRectangle(p1, p2);
                        break;
                    case DrawCommands.PolyLine:
                        tempShape = tempPolyLine;
                        if (clickCount == 1)
                        {
                            if (tempPolyLine == null)
                            {
                                tempPolyLine = new GPolyLine();
                                tempPolyLine.Lines.Add(new GLine(p1, p2));
                            }
                            else
                            {
                                tempPolyLine.Lines.LastOrDefault().EndPoint = p2;
                            }

                        }
                        else if (clickCount == 2)
                        {
                            //check end line position to exit or continue drawing.

                            var prevLine = tempPolyLine.Lines.LastOrDefault();
                            tempPolyLine.Lines.Add(new GLine(prevLine.EndPoint, p2));

                            if (p2.Distance(tempPolyLine.Lines.FirstOrDefault().StartPoint) < Setup.Snap)
                            {
                                ge.AddShape(tempShape);
                                clickCount = 0;
                                tempShape = null;
                                tempPolyLine = null;
                                //ge.ActiveCommand = DrawCommands.Noun;
                            }
                            else
                            {
                                clickCount--;
                            }


                        }

                        break;
                    case DrawCommands.Curve:


                        if (clickCount == 1)
                        {
                            tempShape = new GLine(p1, p2);
                        }

                        else if (clickCount == 2)
                        {

                            if (tempShape is GCurve)
                            {
                                ((GCurve)tempShape).Center = p2;
                            }
                            else
                            {
                                var l = (GLine)tempShape;
                                tempShape = new GCurve(l.StartPoint, p2, l.EndPoint);
                            }


                        }
                        else if (clickCount == 3)
                        {
                            ((GCurve)tempShape).Center = p2;
                            ge.AddShape(tempShape);
                            clickCount = 0;
                        }

                        break;
                    case DrawCommands.Clear:
                        break;
                    case DrawCommands.Noun:
                        break;
                    default:
                        break;
                }
                editorWindow.Invalidate();

            }


        }

        private void EditorWindow_MouseUp(object sender, MouseEventArgs e)
        {


            switch (ge.ActiveCommand)
            {
                case DrawCommands.Line:

                    if (clickCount >= 2)
                    {

                        ge.AddShape(tempShape);
                        clickCount = 0;
                        tempShape = null;
                    }
                    break;
                case DrawCommands.Circle:
                    if (clickCount >= 2)
                    {
                        ge.AddShape(tempShape);
                        clickCount = 0;
                        tempShape = null;
                    }
                    break;
                case DrawCommands.Rectangle:
                    if (clickCount >= 2)
                    {
                        ge.AddShape(tempShape);
                        clickCount = 0;
                        tempShape = null;

                    }
                    break;
                case DrawCommands.PolyLine:


                    break;
                case DrawCommands.Arc:

                    if (clickCount == 3)
                    {
                        clickCount = 0;
                        ge.AddShape(tempArc);
                        tempShape = null;
                        tempArc = null;
                        ge.ActiveCommand = DrawCommands.Noun;

                    }
                    break;
                case DrawCommands.Clear:
                    break;
                case DrawCommands.Noun:
                    break;
                default:
                    break;
            }
            editorWindow.Invalidate();



        }
        private void EditorWindow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ge.ActiveCommand == DrawCommands.PolyLine)
            {
                ge.AddShape(tempShape);
                clickCount = 0;
                tempShape = null;
                tempPolyLine = null;
            }
        }
        #endregion

        #region Menue Buttons Events
        private void btn_new_Click(object sender, EventArgs e)
        {

        }
        private void btn_line_Click(object sender, EventArgs e)
        {
            ge.ActiveCommand = DrawCommands.Line;

        }
        private void btn_Rectangle_Click(object sender, EventArgs e)
        {
            ge.ActiveCommand = DrawCommands.Rectangle;
        }
        private void btn_Circle_Click(object sender, EventArgs e)
        {
            ge.ActiveCommand = DrawCommands.Circle;
        }
        private void btn_Curve_Click(object sender, EventArgs e)
        {
            ge.ActiveCommand = DrawCommands.Curve;
        }
        private void btn_PolyLine_Click(object sender, EventArgs e)
        {
            ge.ActiveCommand = DrawCommands.PolyLine;
            //ge.AddShape(tempPolyLine);

        }
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            //   TestCurveCurve();
            curve();
            
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {

            ge.Shapes.Clear();
            ge.ActiveCommand = DrawCommands.Noun;
            editorWindow.Invalidate();
            tempShape = null;

        }


        #endregion

        #region Visualization Test Methods
        public void TestCurveBoundries()
        {
            var p1 = new PointF(100, 100);
            var p2 = new Point(200, 100);
            var p3 = new PointF(150, 50);
            var p = new Pen(Brushes.Red, 3);
            GCurve gc = new GCurve(p1, p3, p2);
            gc.Draw(g);
            var cp1 = new PointF(gc.Collider.Xmin, gc.Collider.Ymax);
            var cp2 = new PointF(gc.Collider.Xmax, gc.Collider.Ymin);

            GRectangle rec = new GRectangle(cp1, cp2);
            rec.Draw(g);
        }
        public void TestMidPointFunction()
        {
            var p1 = new PointF(100, 100);
            var p2 = new Point(200, 60);
            var p3 = p1.Mid(p2);
            GeometryEngine.DrawPoint(g,p1);
            GeometryEngine.DrawPoint(g, p2);
            GeometryEngine.DrawPoint(g, p3);
        }
        public void TestCurveCurve()
        {
            var p1 = new PointF(100, 100);
            var p2 = new Point(200, 100);
            var p3 = new PointF(150, 50);
            var p = new Pen(Brushes.Red, 3);
            GCurve gc = new GCurve(p1, p3, p2);
            gc.Draw(g);
            var cp1 = new PointF(gc.Collider.Xmin, gc.Collider.Ymax);
            var cp2 = new PointF(gc.Collider.Xmax, gc.Collider.Ymin);

            GRectangle rec = new GRectangle(cp1, cp2);
            rec.Draw(g);
            //curve 2

            var r1 = new PointF(100, 80);
            var r2 = new Point(200, 80);
            var r3 = new PointF(150, 180);
            var r = new Pen(Brushes.Red, 3);
            GCurve c2 = new GCurve(r1, r3, r2);
            c2.Draw(g);
            var c2c1 = new PointF(c2.Collider.Xmin, c2.Collider.Ymax);
            var c2c2 = new PointF(c2.Collider.Xmax, c2.Collider.Ymin);

            GRectangle rec2 = new GRectangle(c2c1, c2c2);
            var coll = gc.Collider.Collide(c2.Collider);
            rec2.Draw(g);
          gc.IntersectWith(c2);
            gc.Draw(g);
            c2.Draw(g);
        }
        public void curve()
        {
            var p1 = new PointF(100, 100);
            var p2 = new Point(200, 100);
            var p3 = new PointF(150, 50);
            var p = new Pen(Brushes.Red, 3);
            GCurve gc = new GCurve(p1, p3, p2);
           var s1= gc.Divide();
            s1.ForEach(e => e.Draw(g));
            gc.Draw(g);
            
        }
        #endregion

    }
}
