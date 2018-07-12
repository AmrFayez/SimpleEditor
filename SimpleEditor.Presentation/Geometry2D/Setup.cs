using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEditor.Presentation.Geometry2D
{
    public class Setup
    {
        // general Point Configuration
        public static float PenWidth { get; set; }
        public static Brush PenBrush { get; set; }
        public static Brush DefaultFill { get; set; }
        public static int PointRadius { get; set; }
        public static Brush PointFill { get; set; }
        public static Brush PointStroke { get; set; }

        //Line Configuration
        public static float Tolerance { get; set; }
        public static void Configure()
        {
            // 
            Tolerance = 0.0001f;
            //default pen
            PenBrush = Brushes.Black;
            PenWidth = 2;
            DefaultFill = Brushes.Black;
            //set point confighuration
            PointRadius = 3;
            PointFill = Brushes.Orange;
            PointStroke = Brushes.Orange;
            GShape.Pen = new Pen(Setup.PenBrush, Setup.PenWidth);

            // Line Fonfiguration
            GLine.LineStroke = Brushes.Blue;
            GLine.LineWidth = 2;
            GLine.PointFill = Brushes.MediumOrchid;
            GLine.PointStroke = Brushes.MediumOrchid;
            GLine.PointRadius = 2;

            //circle Configuration
            GCircle.CircleFill = Brushes.Transparent;
            GCircle.CircleStroke = Brushes.Black;
            GCircle.CircleWidth = 2;
            GCircle.CenterPointFill = Brushes.LightGreen;
            GCircle.CenterPointStroke = Brushes.LightGreen;

            //Arc Configuration
            GArc.ArcFill = Brushes.Transparent;
            GArc.ArcStroke = Brushes.Black;
            GArc.ArcWidth = 2;
            GArc.CenterPointFill = Brushes.LightGreen;
            GArc.CenterPointStroke = Brushes.LightGreen;
        }
    }
}