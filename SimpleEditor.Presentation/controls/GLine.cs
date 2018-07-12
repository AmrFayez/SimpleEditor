using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;





namespace SimpleEditor.Presentation.controls
{
    public partial class GLine : UserControl
    {
      
        public Point Start { get; set; }
        public Point End { get; set; }
        
        public GLine(Point start,Point end)
        {
            Start = start=new Point(5,5);
            End = end= new Point(100, 150);
            InitializeComponent();
            Size = new Size(1000, 1000);
            MinimumSize = new Size(1000, 1000);
            Width = 1000;
        }
        public GLine()
        {

        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            // to draw the control using base OnPaint
           // base.OnPaint(pevent);
            Pen DrawPen = new Pen(Brushes.Red /*LineStyle.Stroke*/,5/*LineStyle.Width*/);
            //GraphicsPath shape = new GraphicsPath();
            //shape.AddLine(Start, End);

            //pevent.Graphics.FillPath(Brushes.Transparent, shape);
            //pevent.Graphics.DrawPath(DrawPen, shape);
            //shape.AddRectangle(new RectangleF(Start.X, Start.Y, End.X, End.Y));
            pevent.Graphics.DrawLine(new Pen(Brushes.Red), new Point(5,5), new Point(500,10));
           // pevent.Graphics.DrawRectangle(new Pen(Brushes.Blue), new Rectangle(5, 5, 100, 100));
            //arbitary Shape
           
            


        }
    }

}

