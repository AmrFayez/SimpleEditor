using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Width = width;
            Height = height;
            HorizontalSpacing = 20;
            VerticalSpacing = 20;
            MajorLineSpacing = 5;
            Stroke = Brushes.Black;

            MajorLineStroke = Brushes.Red;
            MajorLineWidth = 1.5f;
            LineWidth = .2f;
        }

        public void Generate()
        {
            Lines.Clear();
            //draw Horizontal grid
            float counter = 0;
            float majorSpacingCounter=5;
            while (counter * VerticalSpacing < Height)
            {

                if (majorSpacingCounter == MajorLineSpacing)
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
                    majorSpacingCounter = 0;
                }
                else
                {


                    Lines.Add(
                        new GLine(
                            new PointF(StartPoint.X, counter * VerticalSpacing),
                            new PointF(StartPoint.X + Width, counter * VerticalSpacing))
                        {
                            Stroke = Stroke,
                            Width = LineWidth,
                            DrawPoints = false
                        });
                }
                counter++;
                majorSpacingCounter++;
            }
            //draw Vertical grid
            counter = 0;
            majorSpacingCounter = 0;
            while (counter * HorizontalSpacing < Width)
            {

                if (majorSpacingCounter==MajorLineSpacing)
                {
                    Lines.Add(
                        new GLine(
                        new PointF(counter * HorizontalSpacing, StartPoint.Y),
                        new PointF(counter * HorizontalSpacing, StartPoint.Y + Height))
                        {
                            //change the width of major line
                            Width = MajorLineWidth,
                            Stroke = MajorLineStroke,
                            DrawPoints = false
                        });
                    majorSpacingCounter = 0;
                }
                else
                {


                    Lines.Add(
                        new GLine(
                            new PointF(counter * HorizontalSpacing, StartPoint.Y),
                            new PointF(counter * HorizontalSpacing, StartPoint.Y + Height))
                        {
                            //change the width of major line
                            Width = LineWidth,
                            Stroke = Stroke,
                            DrawPoints = false
                        });

                }
                counter++;
                majorSpacingCounter++;
            }

        }
        public void Scale(float ratio)
        {
             //  ratio = 1 - ratio;
               // Width = Width + Width * ratio;
               // Height = Height + Height * ratio;
                HorizontalSpacing = HorizontalSpacing + ratio*20;
                VerticalSpacing = VerticalSpacing +  ratio*20;
            //  MajorLineSpacing = MajorLineSpacing + MajorLineSpacing ;
            //   LineWidth = LineWidth + LineWidth * ratio;
            Debug.WriteLine($"vSpacing:{ VerticalSpacing},HzSpacing:{HorizontalSpacing }");

        }

        internal void Translate(int offsetX, int offsetY)
        {
            StartPoint = new PointF(StartPoint.X - offsetX, StartPoint.Y - offsetY);
        }
    }
}
