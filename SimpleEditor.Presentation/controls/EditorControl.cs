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
    public partial class EditorControl : UserControl
    {
        
        public EditorControl()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
           // DoubleBuffered = true;
            base.OnLoad(e);
            this.Dock = DockStyle.Fill;
            BackColor = Color.AliceBlue;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.StandardDoubleClick, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }


    }
}
