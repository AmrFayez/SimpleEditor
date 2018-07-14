using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEditor.Presentation.Geometry2D
{
    public class Grid
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public float HorizontalSpacing { get; set; }
        public float VerticalSpacing { get; set; }
        public float MajorLineSpacing { get; set; }
        public List<GLine> Lines { get; set; }
        public Brush Stroke { get; set; }
        public float LineWidth { get; set; }
        public Brush MajorLineStroke { get; set; }
        public float MajorLineWidth { get; set; }
        public PointF StartPoint { get; set; }
        public Image GridBitMap { get; set; }

        public Grid(int width, int height)
        {
            Lines = new List<GLine>();
            Width = width + 30;
            Height = height + 30;
            HorizontalSpacing = 20;
            VerticalSpacing = 20;
            MajorLineSpacing = 90;
            Stroke = Brushes.Black;

            MajorLineStroke = Brushes.Red;
            MajorLineWidth = 1f;
            LineWidth = .2f;
        }

        public void Generate()
        {
            Lines.Clear();
            //draw Horizontal grid
            float counter = 0;

            while (counter * VerticalSpacing < Height)
            {

                if (counter*VerticalSpacing%MajorLineSpacing  == 0 &&counter>2)
                {
                    Lines.Add(
                        new GLine(
                             new PointF(StartPoint.X, counter * VerticalSpacing),
                             new PointF(StartPoint.X + Width, counter * VerticalSpacing))
                        {
                            //change the width of major line
                            Width = MajorLineWidth,
                            Stroke = MajorLineStroke,
                            DrawPoints = false
                        });
                }
                else
                {


                    Lines.Add(
                        new GLine(
                            new PointF(StartPoint.X, counter * VerticalSpacing),
                            new PointF(StartPoint.X+Width, counter * VerticalSpacing))
                        {
                            Stroke = Stroke,
                            Width = LineWidth,
                            DrawPoints = false
                        });
                }
                counter++;
            }
            //draw Vertical grid
            counter = 0;
            while (counter * HorizontalSpacing < Width)
            {

                if (counter * HorizontalSpacing % MajorLineSpacing == 0&&counter > 2)
                {
                    Lines.Add(
                        new GLine(
                        new PointF(counter * HorizontalSpacing, StartPoint.Y),
                        new PointF(counter * HorizontalSpacing, StartPoint.Y+Height))
                        {
                            //change the width of major line
                            Width = MajorLineWidth,
                            Stroke = MajorLineStroke,
                            DrawPoints = false
                        });
                }
                else
                {


                    Lines.Add(
                        new GLine(
                            new PointF(counter * HorizontalSpacing, StartPoint.Y),
                            new PointF(counter * HorizontalSpacing, StartPoint.Y+Height))
                        {
                            //change the width of major line
                            Width = LineWidth,
                            Stroke = Stroke,
                            DrawPoints = false
                        });

                }
                counter++;
            }

        }
        public void Scale(float ratio)
        {
            
            if (ratio <= 1 && ratio > 0)
            {
                ratio = -(1 - ratio);
            }
            Width = Width + Width * ratio;
            Height = Height + Height * ratio;
            HorizontalSpacing = HorizontalSpacing + HorizontalSpacing * ratio * 2;
            VerticalSpacing = VerticalSpacing + VerticalSpacing * ratio * 2;
            LineWidth = LineWidth + LineWidth * ratio / 2;
            MajorLineWidth = MajorLineWidth + MajorLineWidth * ratio / 2;
        }

        internal void Translate(int offsetX, int offsetY)
        {
            StartPoint = new PointF(StartPoint.X -offsetX, StartPoint.Y - offsetY);
        }
    }
}
