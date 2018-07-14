namespace SimpleEditor.Presentation
{
    partial class SimpleEditorW
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleEditorW));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_File = new System.Windows.Forms.TabPage();
            this.btn_new = new System.Windows.Forms.Button();
            this.tab_Draw = new System.Windows.Forms.TabPage();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Curve = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Circle = new System.Windows.Forms.Button();
            this.btn_PolyLine = new System.Windows.Forms.Button();
            this.btn_line = new System.Windows.Forms.Button();
            this.btn_Rectangle = new System.Windows.Forms.Button();
            this.editorWindow = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tab_File.SuspendLayout();
            this.tab_Draw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_File);
            this.tabControl1.Controls.Add(this.tab_Draw);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1284, 62);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 2;
            // 
            // tab_File
            // 
            this.tab_File.Controls.Add(this.btn_new);
            this.tab_File.Location = new System.Drawing.Point(4, 22);
            this.tab_File.Name = "tab_File";
            this.tab_File.Padding = new System.Windows.Forms.Padding(3);
            this.tab_File.Size = new System.Drawing.Size(1276, 36);
            this.tab_File.TabIndex = 0;
            this.tab_File.Text = "File";
            this.tab_File.UseVisualStyleBackColor = true;
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(17, 5);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(45, 28);
            this.btn_new.TabIndex = 25;
            this.btn_new.Text = "&New";
            this.btn_new.UseVisualStyleBackColor = true;
            // 
            // tab_Draw
            // 
            this.tab_Draw.Controls.Add(this.btn_Clear);
            this.tab_Draw.Controls.Add(this.btn_Curve);
            this.tab_Draw.Controls.Add(this.btn_Remove);
            this.tab_Draw.Controls.Add(this.btn_Circle);
            this.tab_Draw.Controls.Add(this.btn_PolyLine);
            this.tab_Draw.Controls.Add(this.btn_line);
            this.tab_Draw.Controls.Add(this.btn_Rectangle);
            this.tab_Draw.Location = new System.Drawing.Point(4, 22);
            this.tab_Draw.Name = "tab_Draw";
            this.tab_Draw.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Draw.Size = new System.Drawing.Size(1276, 36);
            this.tab_Draw.TabIndex = 1;
            this.tab_Draw.Text = "Draw";
            this.tab_Draw.UseVisualStyleBackColor = true;
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Clear.BackgroundImage")));
            this.btn_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Clear.Location = new System.Drawing.Point(243, 4);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(28, 28);
            this.btn_Clear.TabIndex = 29;
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Curve
            // 
            this.btn_Curve.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Curve.BackgroundImage")));
            this.btn_Curve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Curve.Location = new System.Drawing.Point(171, 4);
            this.btn_Curve.Name = "btn_Curve";
            this.btn_Curve.Size = new System.Drawing.Size(28, 28);
            this.btn_Curve.TabIndex = 28;
            this.btn_Curve.UseVisualStyleBackColor = true;
            this.btn_Curve.Click += new System.EventHandler(this.btn_Curve_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Remove.BackgroundImage")));
            this.btn_Remove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Remove.Location = new System.Drawing.Point(207, 4);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(28, 28);
            this.btn_Remove.TabIndex = 27;
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Circle
            // 
            this.btn_Circle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Circle.BackgroundImage")));
            this.btn_Circle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Circle.Location = new System.Drawing.Point(97, 4);
            this.btn_Circle.Name = "btn_Circle";
            this.btn_Circle.Size = new System.Drawing.Size(28, 28);
            this.btn_Circle.TabIndex = 26;
            this.btn_Circle.UseVisualStyleBackColor = true;
            this.btn_Circle.Click += new System.EventHandler(this.btn_Circle_Click);
            // 
            // btn_PolyLine
            // 
            this.btn_PolyLine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_PolyLine.BackgroundImage")));
            this.btn_PolyLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_PolyLine.Location = new System.Drawing.Point(134, 4);
            this.btn_PolyLine.Name = "btn_PolyLine";
            this.btn_PolyLine.Size = new System.Drawing.Size(28, 28);
            this.btn_PolyLine.TabIndex = 25;
            this.btn_PolyLine.UseVisualStyleBackColor = true;
            this.btn_PolyLine.Click += new System.EventHandler(this.btn_PolyLine_Click);
            // 
            // btn_line
            // 
            this.btn_line.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_line.BackgroundImage")));
            this.btn_line.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_line.Location = new System.Drawing.Point(23, 4);
            this.btn_line.Name = "btn_line";
            this.btn_line.Size = new System.Drawing.Size(28, 28);
            this.btn_line.TabIndex = 24;
            this.btn_line.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_line.UseVisualStyleBackColor = true;
            this.btn_line.Click += new System.EventHandler(this.btn_line_Click);
            // 
            // btn_Rectangle
            // 
            this.btn_Rectangle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Rectangle.BackgroundImage")));
            this.btn_Rectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Rectangle.Location = new System.Drawing.Point(60, 4);
            this.btn_Rectangle.Name = "btn_Rectangle";
            this.btn_Rectangle.Size = new System.Drawing.Size(28, 28);
            this.btn_Rectangle.TabIndex = 23;
            this.btn_Rectangle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Rectangle.UseVisualStyleBackColor = true;
            this.btn_Rectangle.Click += new System.EventHandler(this.btn_Rectangle_Click);
            // 
            // editorWindow
            // 
            this.editorWindow.BackColor = System.Drawing.SystemColors.Window;
            this.editorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorWindow.Location = new System.Drawing.Point(0, 62);
            this.editorWindow.Name = "editorWindow";
            this.editorWindow.Size = new System.Drawing.Size(1284, 549);
            this.editorWindow.TabIndex = 9;
            this.editorWindow.TabStop = false;
            // 
            // SimpleEditorW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 611);
            this.Controls.Add(this.editorWindow);
            this.Controls.Add(this.tabControl1);
            this.Name = "SimpleEditorW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimpleEditorW";
            this.tabControl1.ResumeLayout(false);
            this.tab_File.ResumeLayout(false);
            this.tab_Draw.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editorWindow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_File;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.TabPage tab_Draw;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Curve;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Circle;
        private System.Windows.Forms.Button btn_PolyLine;
        private System.Windows.Forms.Button btn_line;
        private System.Windows.Forms.Button btn_Rectangle;
        private System.Windows.Forms.PictureBox editorWindow;
    }
}