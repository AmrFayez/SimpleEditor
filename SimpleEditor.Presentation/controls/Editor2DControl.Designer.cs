using SimpleEditor.Presentation.Geometry2D;
using System;
using System.Windows.Forms;

namespace SimpleEditor.Presentation.controls
{
    partial class Editor2DControl
    {
        public PictureBox PictureBox { get; set; }
        public Form MainWindow { get; set; }
        public Editor2D Editor { get; set; }
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            AutoScroll = true;
            Controls.Add(this.PictureBox);
            Dock = System.Windows.Forms.DockStyle.Fill;
            //Picture Box
            PictureBox.BackColor = System.Drawing.SystemColors.Window;
            PictureBox.Location = new System.Drawing.Point(8, 8);
            PictureBox.Name = "editorWindow";
            Editor = new Editor2D(PictureBox);
            PictureBox.Size = new System.Drawing.Size((int)(this.Width * Editor.MaxZoom),
                (int)(this.Height * Editor.MaxZoom));
            PictureBox.TabIndex = 10;
            PictureBox.TabStop = false;

            
        }
        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            PictureBox.Size = Size;
            
        }

        #endregion
    }
}
