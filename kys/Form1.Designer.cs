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
            rectanglebtn = new Button();
            savebtn = new Button();
            colorselector = new PictureBox();
            sizebar = new NumericUpDown();
            eraserbtn = new Button();
            brushbtn = new Button();
            clearbtn = new Button();
            canvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)colorselector).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sizebar).BeginInit();
            SuspendLayout();
            // 
            // canvas
            // 
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
            // rectanglebtn
            // 
            rectanglebtn.Location = new Point(9, 253);
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
            colorselector.Location = new Point(9, 197);
            colorselector.Name = "colorselector";
            colorselector.Size = new Size(78, 50);
            colorselector.TabIndex = 4;
            colorselector.TabStop = false;
            colorselector.Click += colorselector_Click;
            // 
            // sizebar
            // 
            sizebar.Location = new Point(9, 168);
            sizebar.Name = "sizebar";
            sizebar.Size = new Size(75, 23);
            sizebar.TabIndex = 3;
            sizebar.ValueChanged += pbsize_Change;
            // 
            // eraserbtn
            // 
            eraserbtn.BackColor = Color.FromArgb(192, 255, 255);
            eraserbtn.Location = new Point(9, 128);
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
            brushbtn.Location = new Point(9, 88);
            brushbtn.Name = "brushbtn";
            brushbtn.Size = new Size(75, 34);
            brushbtn.TabIndex = 1;
            brushbtn.Text = "Brush";
            brushbtn.UseVisualStyleBackColor = false;
            brushbtn.Click += brushbtn_Click;
            // 
            // clearbtn
            // 
            clearbtn.Location = new Point(9, 59);
            clearbtn.Name = "clearbtn";
            clearbtn.Size = new Size(75, 23);
            clearbtn.TabIndex = 0;
            clearbtn.Text = "CLEAR";
            clearbtn.UseVisualStyleBackColor = true;
            clearbtn.Click += clearbtn_Click;
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
    }
}