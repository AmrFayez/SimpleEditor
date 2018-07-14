using SimpleEditor.Presentation.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEditor.Presentation.Geometry2D
{
  public  class Editor2D
    {
        #region Properties

        public PictureBox EditorWindow { get; set; }
        public GeometryEngine GeometryEngine { get; set; }
        public Grid  Grid { get; set; }
        public DrawCommands ActiveCommand { get; set; }
        #endregion

        #region Constructors
        public Editor2D(PictureBox editorWindow)
        {
            EditorWindow = editorWindow;
            GeometryEngine = new GeometryEngine();
            //grid
            Grid = new Grid(editorWindow.Width,editorWindow.Height);
            Grid.Generate();
            // wiring the mouse events
            EditorWindow.MouseDown += EditorWindow_MouseDown;
            EditorWindow.MouseMove += EditorWindow_MouseMove;
            EditorWindow.MouseUp += EditorWindow_MouseUp;
            EditorWindow.Paint += EditorWindow_Paint;
            EditorWindow.KeyPress += EditorWindow_KeyPress;
            EditorWindow.MouseDoubleClick += EditorWindow_MouseDoubleClick;
            EditorWindow.MouseWheel += EditorWindow_MouseWheel;

        }
        #endregion

        #region Zoom and Pan Properties

        Point mouseDown;
        int startx = 0;                         // offset of image when mouse was pressed
        int starty = 0;
        int offsetX = 0;                         // current offset of image
        int offsetY = 0;

        bool mousepressed = false;  // true as long as left mousebutton is pressed
        float zoom = 1;
        #endregion

        #region  Drawing Properties

        PointF p1;
        PointF p2;
        PointF delta_Y;
        private int clickCount;
        public Graphics g;
        private GShape tempShape;
        private GPolyLine tempPolyLine;

        #endregion

        #region Editor Window Events Wiring
        private void EditorWindow_MouseDown(object sender, MouseEventArgs e)
        {

            if (ActiveCommand != DrawCommands.Noun)
            {
                clickCount++;
                p1 = p2 = new PointF(e.X, e.Y);
            }
            else
            {
                MouseEventArgs mouse = e as MouseEventArgs;

                if (mouse.Button == MouseButtons.Left)
                {
                    if (!mousepressed)
                    {
                        mousepressed = true;
                        mouseDown = mouse.Location;
                        startx = offsetX;
                        starty = offsetY;
                    }
                }
            }

        }
        private void EditorWindow_MouseMove(object sender, MouseEventArgs e)
        {

            if (ActiveCommand != DrawCommands.Noun && clickCount >= 1)
            {
                delta_Y = p2.Sub(e.Location);
                p2 = new PointF(e.X, e.Y);

                switch (ActiveCommand)
                {
                    case DrawCommands.Line:
                        tempShape = new GLine(p1, p2);
                        break;
                    case DrawCommands.Circle:
                        tempShape = new GCircle(p1.Sub(new PointF(offsetX,offsetY)), (float)p1.Distance(p2));
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
                               GeometryEngine.AddShape(tempShape);
                                clickCount = 0;
                                tempShape = null;
                                tempPolyLine = null;
                                // ActiveCommand = DrawCommands.Noun;
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
                            GeometryEngine.AddShape(tempShape);
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
                EditorWindow.Invalidate();

            }
            else if (clickCount == 0)
            {
                MouseEventArgs mouse = e as MouseEventArgs;

                if (mouse.Button == MouseButtons.Left)
                {
                    Point mousePosNow = mouse.Location;

                    int deltaX = mousePosNow.X - mouseDown.X; // the distance the mouse has been moved since mouse was pressed
                    int deltaY = mousePosNow.Y - mouseDown.Y;

                    offsetX = (int)(startx + (deltaX / zoom));  // calculate new offset of image based on the current zoom factor
                    offsetY = (int)(starty + (deltaY / zoom));

                    EditorWindow.Refresh();
                }
            }
            
        }

        private void EditorWindow_MouseUp(object sender, MouseEventArgs e)
        {


            switch (ActiveCommand)
            {
                case DrawCommands.Line:
                    if (clickCount >= 2)
                    {

                        GeometryEngine.AddShape(tempShape);
                        clickCount = 0;
                        tempShape = null;
                    }
                    break;
                case DrawCommands.Circle:
                    if (clickCount >= 2)
                    {
                        GeometryEngine.AddShape(tempShape);
                        clickCount = 0;
                        tempShape = null;
                    }
                    break;
                case DrawCommands.Rectangle:
                    if (clickCount >= 2)
                    {
                        GeometryEngine.AddShape(tempShape);
                        clickCount = 0;
                        tempShape = null;

                    }
                    break;
                case DrawCommands.PolyLine:
                    break;

                case DrawCommands.Clear:
                    break;
                case DrawCommands.Noun:

                    break;
                default:
                    break;
            }
            mousepressed = false;
            EditorWindow.Invalidate();



        }
        private void EditorWindow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ActiveCommand != DrawCommands.Noun)
            {
                
                
                
                if (clickCount==2 && ActiveCommand != DrawCommands.PolyLine)
                {
                   
                    clickCount = 0;
                    return;
                }

                ActiveCommand = DrawCommands.Noun;
                GeometryEngine.AddShape(tempShape);
                tempShape = null;
                tempPolyLine = null;
                clickCount = 0;
            }
               
        }

        private void EditorWindow_KeyPress(object sender, KeyPressEventArgs e)
        {

            switch (e.KeyChar)
            {
                case '\u001b':

                    ActiveCommand = DrawCommands.Noun;

                    break;
                default:
                    break;
            }

        }

        private void EditorWindow_MouseWheel(object sender, MouseEventArgs e)
        {
            float oldzoom = zoom;

            if (e.Delta > 0)
            {
                zoom += 0.1F;
            }

            else if (e.Delta < 0)
            {
                zoom = Math.Max(zoom - 0.1F, 0.01F);
            }

            MouseEventArgs mouse = e as MouseEventArgs;
            Point mousePosNow = mouse.Location;

            int x = mousePosNow.X - EditorWindow.Location.X;    // Where location of the mouse in the pictureframe
            int y = mousePosNow.Y - EditorWindow.Location.Y;

            int oldimagex = (int)(x / oldzoom);  // Where in the IMAGE is it now
            int oldimagey = (int)(y / oldzoom);

            int newimagex = (int)(x / zoom);     // Where in the IMAGE will it be when the new zoom i made
            int newimagey = (int)(y / zoom);

            offsetX = newimagex - oldimagex + offsetX;  // Where to move image to keep focus on one point
            offsetY = newimagey - oldimagey + offsetY;
            //Grid.Scale(zoom);
            //Grid.Translate(offsetX, offsetY);
            //Grid.Generate();
            EditorWindow.Invalidate();  // calls imageBox_Paint
        }

        private void EditorWindow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.ScaleTransform(zoom, zoom);
            //  e.Graphics.DrawImage(img, imgx, imgy);
            e.Graphics.TranslateTransform(offsetX, offsetY);
            
            if (Grid.Lines.Count!=0)
            {
                foreach (var line in Grid.Lines)
                {
                    line.Draw(e.Graphics);
                }
            }
            
            if (tempShape != null)
            {
                tempShape.Draw(e.Graphics);
            }

            Paint(e.Graphics);
           

        }

        public void ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {

                    case Keys.Right:
                        offsetX -= (int)(EditorWindow.Width * 0.1F / zoom);
                        EditorWindow.Refresh();
                        break;

                    case Keys.Left:
                        offsetX += (int)(EditorWindow.Width * 0.1F / zoom);
                        EditorWindow.Refresh();
                        break;

                    case Keys.Down:
                        offsetY -= (int)(EditorWindow.Height * 0.1F / zoom);
                        EditorWindow.Refresh();
                        break;

                    case Keys.Up:
                        offsetY += (int)(EditorWindow.Height * 0.1F / zoom);
                        EditorWindow.Refresh();
                        break;

                    case Keys.PageDown:
                        offsetY -= (int)(EditorWindow.Height * 0.90F / zoom);
                        EditorWindow.Refresh();
                        break;

                    case Keys.PageUp:
                        offsetY += (int)(EditorWindow.Height * 0.90F / zoom);
                        EditorWindow.Refresh();
                        break;

                    case Keys.Escape:
                        ActiveCommand = DrawCommands.Noun;
                        break;
                }
            }


        }
        #endregion

        #region Method
        public void Paint(Graphics g)
        {
            if (GeometryEngine.Shapes.Count == 0)
            {
                return;
            }
            foreach (var shape in GeometryEngine.Shapes)
            {
                shape.Draw(g);
            }

        }
        public static void DrawPoint(Graphics g, PointF p, Brush Fill = null, Brush Stroke = null)
        {
            Fill = Fill ?? Setup.PointFill;
            Stroke = Stroke ?? Setup.PointStroke;
            var rect = new RectangleF(
                    new PointF(p.X - Setup.PointRadius, p.Y - Setup.PointRadius),
                    new SizeF(Setup.PointRadius * 2, Setup.PointRadius * 2));

            g.FillEllipse(Fill, rect);
            GShape.Pen.Brush = Stroke;
            g.DrawEllipse(GShape.Pen, rect);
        }
        public static void DrawPoint(Graphics g, List<PointF> points, Brush Fill = null, Brush Stroke = null)
        {
            if (points == null)
            {
                return;
            }
            foreach (var p in points)
            {
                DrawPoint(g, p);
            }

        }
        public void Clear()
        {
            GeometryEngine.Shapes.Clear();
            ActiveCommand = DrawCommands.Noun;
            EditorWindow.Invalidate();
        }
        #endregion
    }
}
