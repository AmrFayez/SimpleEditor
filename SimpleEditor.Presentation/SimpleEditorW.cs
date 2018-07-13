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
                tempShape.Draw(g);
            }

            ge.Paint(g);
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
                    case DrawCommands.Arc:

                        #region Old
                        //if (clickCount == 1)
                        //{
                        //var arcWidth = p2.X - p1.X;
                        //var arcHeight = p2.Y - p1.Y;
                        //arcWidth = Math.Abs(arcWidth);
                        //arcHeight = Math.Abs(arcHeight);
                        //if (arcWidth == 0)
                        //{
                        //    arcWidth = 5;

                        //}
                        //if (arcHeight == 0)
                        //{
                        //    arcHeight = 5;
                        //}
                        //if (tempArc == null)
                        //{

                        //    tempShape = tempArc = new GArc(p1, arcWidth, arcHeight, 0, 180);
                        //}
                        //else
                        //{

                        //    tempArc.MajorAxe = arcWidth;
                        //    tempArc.MinorAxe = arcHeight;
                        //}


                        //}

                        //else if (clickCount == 2)
                        //{
                        //    var height = Math.Abs(p1.Y - p2.Y);
                        //    height = Math.Abs(height);
                        //    if (height == 0)
                        //    {
                        //        height = 5;
                        //    }


                        //    tempArc.MinorAxe = height;


                        //}
                        #endregion

                        #region Method #1

                        if (clickCount == 1)
                        {
                            tempShape = new GLine(p1, p2);
                        }
                        else if (clickCount == 2)
                        {
                            var d = p2.Distance(p1);
                            float arcWidth;
                            float arcHeight;
                            if (tempArc == null)
                            {
                                var l = ((GLine)tempShape);

                                arcWidth = l.EndPoint.X - l.StartPoint.X;
                                arcHeight = l.EndPoint.Y - l.StartPoint.Y;
                                arcWidth = Math.Abs(arcWidth);
                                arcHeight = Math.Abs(arcHeight);
                                if (arcHeight == 0)
                                {
                                    arcHeight = 1;

                                }
                                if (arcWidth == 0)
                                {
                                    arcWidth = 1;
                                }

                                tempShape = tempArc = new GArc(l.StartPoint, arcWidth, arcHeight, 0, d);
                            }
                            else
                            {
                                arcHeight = p2.Sub(p1).Y;
                                tempArc.SweepAngle = d;
                                tempArc.Start =
                                    new PointF(
                                        tempArc.Start.X,
                                    tempArc.Start.Y);

                                if (p2.X - p1.X > 0)
                                {
                                    tempArc.StartAngle = -180;
                                }
                                else
                                {
                                    tempArc.StartAngle = 0;
                                }
                            }

                        }
                        else if (clickCount == 3)
                        {
                            ge.AddShape(tempShape);
                        }

                        #endregion
                        #region Method 2

                        #endregion
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
        private void btn_Arc_Click(object sender, EventArgs e)
        {
            ge.ActiveCommand = DrawCommands.Arc;
        }
        private void btn_PolyLine_Click(object sender, EventArgs e)
        {
            ge.ActiveCommand = DrawCommands.PolyLine;
            //ge.AddShape(tempPolyLine);

        }
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            //var start = new PointF(100, 100);
            //var end = new PointF(200, 60);
            //var p = new PointF(130, 20);
            //var l = new GLine(start, end);
            //var c = start.Add(end.Sub(start).Scale(.5f));
            //l.Draw(g);
            //GeometryEngine.DrawPoint(g,p );
            //var dx = end.X-start.X;
            //var dy =  p.Y - c.Y;
            //dy = Math.Abs(dy);
            //dx = Math.Abs(dx);
           
            ////var r= new GRectangle(new PointF( 75, 75),new PointF(125,125));
            ////var c = new GCircle(new PointF(100, 100), 25);
            ////c.Draw(g);
            //// r.Draw(g);
            //var startAngle = Math.Acos((start.Normalize()).Dot(new PointF(1, 0).Normalize())).ToDegrees();
            //var endAngle = Math.Acos((end.Normalize()).Dot(new PointF(1, 0).Normalize())).ToDegrees();
            //g.DrawArc(new Pen(Brushes.Red, 3), new RectangleF(c.X-dx/2 ,c.Y-dy/2, dx, dy ), -180, 180);
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {

            ge.Shapes.Clear();
            ge.ActiveCommand = DrawCommands.Noun;
            editorWindow.Invalidate();
            tempShape = null;

        }


        #endregion


    }
}
