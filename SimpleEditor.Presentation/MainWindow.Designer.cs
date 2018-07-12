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
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lbl_info = new System.Windows.Forms.ToolStripLabel();
            this.editorWindow = new SimpleEditor.Presentation.controls.EditorControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_File = new System.Windows.Forms.TabPage();
            this.btn_new = new System.Windows.Forms.Button();
            this.tab_Draw = new System.Windows.Forms.TabPage();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Arc = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Circle = new System.Windows.Forms.Button();
            this.btn_PolyLine = new System.Windows.Forms.Button();
            this.btn_line = new System.Windows.Forms.Button();
            this.btn_Rectangle = new System.Windows.Forms.Button();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_File.SuspendLayout();
            this.tab_Draw.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(775, 425);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.editorWindow);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1184, 611);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1184, 661);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_info});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(98, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // lbl_info
            // 
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(86, 22);
            this.lbl_info.Text = "toolStripLabel1";
            // 
            // editorWindow
            // 
            this.editorWindow.AutoScroll = true;
            this.editorWindow.BackColor = System.Drawing.Color.AliceBlue;
            this.editorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorWindow.Location = new System.Drawing.Point(0, 62);
            this.editorWindow.Name = "editorWindow";
            this.editorWindow.Size = new System.Drawing.Size(1184, 549);
            this.editorWindow.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_File);
            this.tabControl1.Controls.Add(this.tab_Draw);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1184, 62);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 1;
            // 
            // tab_File
            // 
            this.tab_File.Controls.Add(this.btn_new);
            this.tab_File.Location = new System.Drawing.Point(4, 22);
            this.tab_File.Name = "tab_File";
            this.tab_File.Padding = new System.Windows.Forms.Padding(3);
            this.tab_File.Size = new System.Drawing.Size(1176, 36);
            this.tab_File.TabIndex = 0;
            this.tab_File.Text = "File";
            this.tab_File.UseVisualStyleBackColor = true;
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(17, 5);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(28, 28);
            this.btn_new.TabIndex = 25;
            this.btn_new.Text = "&New";
            this.btn_new.UseVisualStyleBackColor = true;
            // 
            // tab_Draw
            // 
            this.tab_Draw.Controls.Add(this.btn_Clear);
            this.tab_Draw.Controls.Add(this.btn_Arc);
            this.tab_Draw.Controls.Add(this.btn_Remove);
            this.tab_Draw.Controls.Add(this.btn_Circle);
            this.tab_Draw.Controls.Add(this.btn_PolyLine);
            this.tab_Draw.Controls.Add(this.btn_line);
            this.tab_Draw.Controls.Add(this.btn_Rectangle);
            this.tab_Draw.Location = new System.Drawing.Point(4, 22);
            this.tab_Draw.Name = "tab_Draw";
            this.tab_Draw.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Draw.Size = new System.Drawing.Size(1176, 36);
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
            // btn_Arc
            // 
            this.btn_Arc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Arc.BackgroundImage")));
            this.btn_Arc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Arc.Location = new System.Drawing.Point(171, 4);
            this.btn_Arc.Name = "btn_Arc";
            this.btn_Arc.Size = new System.Drawing.Size(28, 28);
            this.btn_Arc.TabIndex = 28;
            this.btn_Arc.UseVisualStyleBackColor = true;
            this.btn_Arc.Click += new System.EventHandler(this.btn_Arc_Click);
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab_File.ResumeLayout(false);
            this.tab_Draw.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lbl_info;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_File;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.TabPage tab_Draw;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Arc;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Circle;
        private System.Windows.Forms.Button btn_PolyLine;
        private System.Windows.Forms.Button btn_line;
        private System.Windows.Forms.Button btn_Rectangle;
        private controls.EditorControl editorWindow;
    }
}