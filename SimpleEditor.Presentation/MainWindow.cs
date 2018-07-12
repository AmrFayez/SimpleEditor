﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleEditor.Presentation;
using SimpleEditor.Presentation.Common;
using SimpleEditor.Presentation.Geometry2D;

namespace SimpleEditor.Presentation
{
    public partial class MainWindow : Form
    {

        #region  Drawing Properties
        PointF p1;
        PointF p2;
        PointF p3;
        PointF delta_Y;
        public GeometryEngine ge { get; set; } = new GeometryEngine();
        private int clickCount;
        public Graphics g;
        private GShape tempShape;
        private GPolyLine tempPolyLine;
        bool exitPolyLine;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            editorWindow.MouseDown += EditorWindow_MouseDown;
            editorWindow.MouseMove += EditorWindow_MouseMove;
            editorWindow.MouseUp += EditorWindow_MouseUp;
            editorWindow.Paint += EditorWindow_Paint;
            editorWindow.KeyPress += EditorWindow_KeyPress; ;
            g = editorWindow.CreateGraphics();
            Setup.Configure();

        }

        private void EditorWindow_KeyPress(object sender, KeyPressEventArgs e)
        {

            switch (e.KeyChar)
            {
                case '\u001b':
                    exitPolyLine = true;
                    clickCount = 0;
                    var t = tempPolyLine;
                    ge.ActiveCommand = DrawCommands.Noun;
                    tempShape = null;
                    tempPolyLine = null;
                    break;
                default:
                    break;
            }

        }

        private void EditorWindow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (tempShape != null)
            {
                tempShape.Draw(g);
            }

            ge.Paint(g);
        }

        #region Mouse Events
        private void EditorWindow_MouseDown(object sender, MouseEventArgs e)
        {
            
            if ((clickCount >=1 ||ge.Shapes.Count>0) && ge.ActiveCommand == DrawCommands.PolyLine)
            {
                clickCount++;
                tempPolyLine.Lines.Add((GLine)tempShape);
                p1 = p2 = new PointF(e.X, e.Y);
                tempShape = new GLine(p1, p2);
                if (clickCount>=1)
                {
                    clickCount = 0;
                }
            }
           else if (ge.ActiveCommand != DrawCommands.Noun)
            {
                clickCount ++;
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
                        if (!exitPolyLine)
                        {
                            if (tempShape != null)
                            {
                                ((GLine)tempShape).EndPoint = p2;
                            }
                            else
                            {
                                tempShape = new GLine(p1, p2);
                            }
                        }

                        break;
                    case DrawCommands.Arc:
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

                    if ((tempPolyLine.Lines.Count >= 1))
                    {
                        
                        var dist = tempPolyLine.Lines.FirstOrDefault().EndPoint.Distance(p2);
                       // exitPolyLine = dist < 5;
                    }

                    if (!exitPolyLine&&tempShape !=null)
                    {

                        var l = (GLine)tempShape;
                        clickCount++;
                        if (clickCount>=1)
                        {
                            clickCount = 1;
                        }
                        
                    }
                    if (exitPolyLine)
                    {
                        ge.ActiveCommand = DrawCommands.Noun;
                        clickCount = 0;
                        tempShape = null;
                        tempPolyLine = null;
                        exitPolyLine =! exitPolyLine;
                    }
                    
                    break;
                case DrawCommands.Arc:
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

        }
        private void btn_PolyLine_Click(object sender, EventArgs e)
        {
            ge.ActiveCommand = DrawCommands.PolyLine;
                        tempPolyLine = new GPolyLine();
            ge.AddShape(tempPolyLine);
           
        }
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            //GPolyLine polyLine = new GPolyLine(
            //    (new List<PointF>
            //    {
            //        new PointF(5,5),
            //         new PointF(0, 50),

            //         new PointF(50, 50),
            //          new PointF(50, 5),

            //           // new PointF(0, 0),
            //    }));
            //polyLine.Draw(g);
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {

            ge.Shapes.Clear();
            ge.ActiveCommand = DrawCommands.Noun;
            editorWindow.Invalidate();
            tempShape = null;

        }

        #endregion
        protected override void OnResize(EventArgs e)
        {

            ContentPanel.Size = new Size(this.Width, this.Height);
            ContentPanel.Invalidate();
            editorWindow.Width = this.Width;
            editorWindow.Height = this.Height;
            editorWindow.Size = new Size(this.Width, this.Height);
            ContentPanel.Invalidate();
        }


    }
}