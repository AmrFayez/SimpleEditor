namespace SimpleEditor.Presentation
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Size = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.editor2D = new SimpleEditor.Presentation.controls.Editor2DControl();
            this.tabControl1.SuspendLayout();
            this.tab_File.SuspendLayout();
            this.tab_Draw.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.RightToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(1010, 62);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 2;
            // 
            // tab_File
            // 
            this.tab_File.Controls.Add(this.btn_new);
            this.tab_File.Location = new System.Drawing.Point(4, 22);
            this.tab_File.Name = "tab_File";
            this.tab_File.Padding = new System.Windows.Forms.Padding(3);
            this.tab_File.Size = new System.Drawing.Size(1002, 36);
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
            this.tab_Draw.Size = new System.Drawing.Size(1002, 36);
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
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.editor2D);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(978, 346);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 62);
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            this.toolStripContainer1.RightToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.Size = new System.Drawing.Size(1010, 398);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_Status,
            this.lbl_Size,
            this.toolStripStatusLabel2,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1010, 27);
            this.statusStrip1.TabIndex = 0;
            // 
            // lbl_Status
            // 
            this.lbl_Status.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(42, 22);
            this.lbl_Status.Text = "X:0,Y:0";
            // 
            // lbl_Size
            // 
            this.lbl_Size.Margin = new System.Windows.Forms.Padding(100, 3, 0, 2);
            this.lbl_Size.Name = "lbl_Size";
            this.lbl_Size.Size = new System.Drawing.Size(27, 22);
            this.lbl_Size.Text = "Size";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 22);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem2});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 25);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem3.Text = "50%";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem2.Text = "100%";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(32, 99);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(30, 20);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(30, 20);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(30, 20);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // editor2D
            // 
            this.editor2D.AutoScroll = true;
            this.editor2D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor2D.Location = new System.Drawing.Point(0, 0);
            this.editor2D.MainWindow = null;
            this.editor2D.Name = "editor2D";
            this.editor2D.Size = new System.Drawing.Size(978, 346);
            this.editor2D.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 460);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple 2D Editor";
            this.tabControl1.ResumeLayout(false);
            this.tab_File.ResumeLayout(false);
            this.tab_Draw.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Status;
        private controls.Editor2DControl editor2D;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Size;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}