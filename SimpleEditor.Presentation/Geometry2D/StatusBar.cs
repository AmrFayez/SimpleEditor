using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEditor.Presentation.Geometry2D
{
    public class StatusBar
    {
        public ToolStripStatusLabel Label { get; set; }
        public static Color DefaultColor { get; set; }
        public static Color ErrorColor { get; set; }
        public static Color WarningColor { get; set; }
        public StatusBar():this(null)
        {

        }
        public StatusBar(ToolStripStatusLabel label)
        {
            Label = label;
        }
        public void Message(string text)
        {
            Label.Text = text;
            Label.ForeColor = DefaultColor;
        }
        public void Message(string text, Color color)
        {
            Label.Text = text;
            Label.ForeColor = color;
        }
        public void ErrorMessage(string text)
        {
            Label.Text = text;
            Label.ForeColor = ErrorColor;
        }
        public void WarrningMessage(string text)
        {
            Label.Text = text;
            Label.ForeColor = WarningColor;
        }
    }
}
