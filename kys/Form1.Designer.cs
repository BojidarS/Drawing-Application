namespace kys
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            canvas = new Panel();
            delete_btn = new Button();
            move_btn = new Button();
            select_btn = new Button();
            load_btn = new Button();
            line_btn = new Button();
            circle_btn = new Button();
            rectanglebtn = new Button();
            savebtn = new Button();
            colorselector = new PictureBox();
            sizebar = new NumericUpDown();
            eraserbtn = new Button();
            brushbtn = new Button();
            clearbtn = new Button();
            x_mouse_label = new Label();
            y_mouse_label = new Label();
            canvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)colorselector).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sizebar).BeginInit();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.Controls.Add(y_mouse_label);
            canvas.Controls.Add(x_mouse_label);
            canvas.Controls.Add(delete_btn);
            canvas.Controls.Add(move_btn);
            canvas.Controls.Add(select_btn);
            canvas.Controls.Add(load_btn);
            canvas.Controls.Add(line_btn);
            canvas.Controls.Add(circle_btn);
            canvas.Controls.Add(rectanglebtn);
            canvas.Controls.Add(savebtn);
            canvas.Controls.Add(colorselector);
            canvas.Controls.Add(sizebar);
            canvas.Controls.Add(eraserbtn);
            canvas.Controls.Add(brushbtn);
            canvas.Controls.Add(clearbtn);
            canvas.Dock = DockStyle.Fill;
            canvas.Location = new Point(0, 0);
            canvas.Name = "canvas";
            canvas.Size = new Size(800, 450);
            canvas.TabIndex = 0;
            canvas.MouseDown += canvas_MouseDown;
            canvas.MouseMove += canvas_MouseMove;
            canvas.MouseUp += canvas_MouseUp;
            // 
            // delete_btn
            // 
            delete_btn.Location = new Point(9, 424);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(75, 23);
            delete_btn.TabIndex = 12;
            delete_btn.Text = "Delete";
            delete_btn.UseVisualStyleBackColor = true;
            delete_btn.Click += delete_btn_Click;
            // 
            // move_btn
            // 
            move_btn.Location = new Point(9, 396);
            move_btn.Name = "move_btn";
            move_btn.Size = new Size(75, 23);
            move_btn.TabIndex = 11;
            move_btn.Text = "Move";
            move_btn.UseVisualStyleBackColor = true;
            move_btn.Click += move_btn_Click;
            // 
            // select_btn
            // 
            select_btn.Location = new Point(9, 367);
            select_btn.Name = "select_btn";
            select_btn.Size = new Size(75, 23);
            select_btn.TabIndex = 10;
            select_btn.Text = "Select";
            select_btn.UseVisualStyleBackColor = true;
            select_btn.Click += select_btn_Click;
            // 
            // load_btn
            // 
            load_btn.Location = new Point(9, 57);
            load_btn.Name = "load_btn";
            load_btn.Size = new Size(75, 23);
            load_btn.TabIndex = 9;
            load_btn.Text = "LOAD";
            load_btn.UseVisualStyleBackColor = true;
            load_btn.Click += load_btn_Click;
            // 
            // line_btn
            // 
            line_btn.Location = new Point(9, 338);
            line_btn.Name = "line_btn";
            line_btn.Size = new Size(75, 23);
            line_btn.TabIndex = 8;
            line_btn.Text = "Line";
            line_btn.UseVisualStyleBackColor = true;
            line_btn.Click += line_btn_Click;
            // 
            // circle_btn
            // 
            circle_btn.Location = new Point(9, 309);
            circle_btn.Name = "circle_btn";
            circle_btn.Size = new Size(75, 23);
            circle_btn.TabIndex = 7;
            circle_btn.Text = "Circle";
            circle_btn.UseVisualStyleBackColor = true;
            circle_btn.Click += circle_btn_Click;
            // 
            // rectanglebtn
            // 
            rectanglebtn.Location = new Point(9, 280);
            rectanglebtn.Name = "rectanglebtn";
            rectanglebtn.Size = new Size(75, 23);
            rectanglebtn.TabIndex = 6;
            rectanglebtn.Text = "Rectangle";
            rectanglebtn.UseVisualStyleBackColor = true;
            rectanglebtn.Click += rectanglebtn_Click;
            // 
            // savebtn
            // 
            savebtn.Location = new Point(9, 12);
            savebtn.Name = "savebtn";
            savebtn.Size = new Size(75, 41);
            savebtn.TabIndex = 5;
            savebtn.Text = "SAVE";
            savebtn.UseVisualStyleBackColor = true;
            savebtn.Click += savebtn_Click;
            // 
            // colorselector
            // 
            colorselector.BackColor = Color.Black;
            colorselector.Location = new Point(9, 224);
            colorselector.Name = "colorselector";
            colorselector.Size = new Size(78, 50);
            colorselector.TabIndex = 4;
            colorselector.TabStop = false;
            colorselector.Click += colorselector_Click;
            // 
            // sizebar
            // 
            sizebar.Location = new Point(9, 195);
            sizebar.Name = "sizebar";
            sizebar.Size = new Size(75, 23);
            sizebar.TabIndex = 3;
            sizebar.ValueChanged += pbsize_Change;
            // 
            // eraserbtn
            // 
            eraserbtn.BackColor = Color.FromArgb(192, 255, 255);
            eraserbtn.Location = new Point(9, 155);
            eraserbtn.Name = "eraserbtn";
            eraserbtn.Size = new Size(75, 34);
            eraserbtn.TabIndex = 2;
            eraserbtn.Text = "Eraser";
            eraserbtn.UseVisualStyleBackColor = false;
            eraserbtn.Click += eraserbtn_Click;
            // 
            // brushbtn
            // 
            brushbtn.BackColor = Color.FromArgb(255, 192, 192);
            brushbtn.Location = new Point(9, 115);
            brushbtn.Name = "brushbtn";
            brushbtn.Size = new Size(75, 34);
            brushbtn.TabIndex = 1;
            brushbtn.Text = "Brush";
            brushbtn.UseVisualStyleBackColor = false;
            brushbtn.Click += brushbtn_Click;
            // 
            // clearbtn
            // 
            clearbtn.Location = new Point(9, 86);
            clearbtn.Name = "clearbtn";
            clearbtn.Size = new Size(75, 23);
            clearbtn.TabIndex = 0;
            clearbtn.Text = "CLEAR";
            clearbtn.UseVisualStyleBackColor = true;
            clearbtn.Click += clearbtn_Click;
            // 
            // x_mouse_label
            // 
            x_mouse_label.AutoSize = true;
            x_mouse_label.Location = new Point(699, 12);
            x_mouse_label.Name = "x_mouse_label";
            x_mouse_label.Size = new Size(38, 15);
            x_mouse_label.TabIndex = 13;
            x_mouse_label.Text = "label1";
            // 
            // y_mouse_label
            // 
            y_mouse_label.AutoSize = true;
            y_mouse_label.Location = new Point(743, 11);
            y_mouse_label.Name = "y_mouse_label";
            y_mouse_label.Size = new Size(38, 15);
            y_mouse_label.TabIndex = 14;
            y_mouse_label.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(canvas);
            Name = "Form1";
            Text = "Drawing Application";
            Load += Form1_Load;
            canvas.ResumeLayout(false);
            canvas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)colorselector).EndInit();
            ((System.ComponentModel.ISupportInitialize)sizebar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel canvas;
        private Button eraserbtn;
        private Button brushbtn;
        private Button clearbtn;
        private PictureBox colorselector;
        private NumericUpDown sizebar;
        private Button savebtn;
        private Button rectanglebtn;
        private Button circle_btn;
        private Button line_btn;
        private Button load_btn;
        private Button select_btn;
        private Button move_btn;
        private Button delete_btn;
        private Label y_mouse_label;
        private Label x_mouse_label;
    }
}