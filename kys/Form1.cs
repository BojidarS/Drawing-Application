using Draw;
using Draw.Base;
using Draw.Figures;
using Draw.Interfaces;
using Draw.Services;
using System.Drawing;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace kys
{
    public partial class Form1 : Form
    {
        List<BaseShape> shapes;
        public Point startingPoint = new Point();
        public Point currentPoint = new Point();
        public Point oldPoint = new Point();
        string penColor;
        string selectedShape;

        public Graphics g;

        public Graphics graph;

        public Pen myPen = new Pen(Color.Black, 5);

        bool shapeToolSelected = false;

        Bitmap surface;

        DrawingService drawingService;
        FileService fileService;

        bool selectToolSelected = false;

        public Form1()
        {
            InitializeComponent();

            g = canvas.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            myPen.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);

            surface = new Bitmap(canvas.Width, canvas.Height);

            graph = Graphics.FromImage(surface);

            canvas.BackgroundImage = surface;
            canvas.BackgroundImageLayout = ImageLayout.None;

            myPen.Width = (float)sizebar.Value;
            shapes = new List<BaseShape>();
            drawingService = new DrawingService();
            fileService = new FileService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            oldPoint = e.Location; // dont touch
            startingPoint = e.Location;
            if(shapeToolSelected == true)
            {
                foreach(BaseShape shape in shapes)
                {
                    //if (startingPoint => shape.StartPoint || oldPoint <= shape.EndPoint)
                    //{
                    //    select_btn.Text = "Selected";
                    //}
                }
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && shapeToolSelected == false && selectToolSelected == false)
            {
                currentPoint = e.Location;
                g.DrawLine(myPen, oldPoint, currentPoint);
                graph.DrawLine(myPen, oldPoint, currentPoint);

                oldPoint = currentPoint;
            }
            else if (e.Button == MouseButtons.Left && shapeToolSelected == true)
            {
                oldPoint = e.Location;
            }
        }

        private void eraserbtn_Click(object sender, EventArgs e)
        {
            myPen.Color = canvas.BackColor;
            shapeToolSelected = false;
        }

        private void brushbtn_Click(object sender, EventArgs e)
        {
            myPen.Color = colorselector.BackColor;
            shapeToolSelected = false;
        }

        private void colorselector_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                myPen.Color = cd.Color;
                colorselector.BackColor = cd.Color;
                penColor = myPen.Color.ToString();
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            graph.Clear(canvas.BackColor);
            canvas.Invalidate();
            shapes.Clear();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Png Files (*png) | *.png|Json files (*.json) | *.json";
            sfd.FilterIndex = 2;
            sfd.DefaultExt = "png";
            sfd.AddExtension = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string stringPath = sfd.FileName;
                switch (sfd.FilterIndex)
                {
                    case 1:
                        surface.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case 2:
                        fileService.SaveFile(shapes, stringPath);
                        break;
                }
            }
        }

        private void pbsize_Change(object sender, EventArgs e)
        {
            myPen.Width = (float)sizebar.Value;
        }

        private void rectanglebtn_Click(object sender, EventArgs e)
        {
            shapeToolSelected = true;
            selectedShape = "Rectangle";
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedShape == "Rectangle" && shapeToolSelected == true)
            {
                //var rectangle = new RectangleShape(startingPoint, oldPoint, pen, g, graph, selectedShape);
                //rectangle.DrawShape(startingPoint, oldPoint); //service
                var rectangle = drawingService.DrawRectangle(startingPoint, oldPoint, myPen, g, graph, selectedShape, penColor);
                shapes.Add(rectangle);
            }
            else if (selectedShape == "Circle" && shapeToolSelected == true)
            {
                CircleShape circle = drawingService.DrawCircle(startingPoint, oldPoint, myPen, g, graph, selectedShape, penColor);
                shapes.Add(circle);
            }
            else if (selectedShape == "Line" && shapeToolSelected == true)
            {
                LineShape line = drawingService.DrawLine(startingPoint, oldPoint, myPen, g, graph, selectedShape, penColor);
                shapes.Add(line);
            }
        }

        

        private void circle_btn_Click(object sender, EventArgs e)
        {
            shapeToolSelected = true;
            selectedShape = "Circle";
        }

        private void line_btn_Click(object sender, EventArgs e)
        {
            selectedShape = "Line";
            shapeToolSelected = true;
        }

        private void load_btn_Click(object sender, EventArgs e)
        {
            //string jsonString = File.ReadAllText(@"D:\config.json");
            //var shape = JsonSerializer.Deserialize<List<BaseShape>>(jsonString);
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var load = fileService.LoadFile(dialog.FileName);
                foreach (var item in load)
                {
                    switch (item.ShapeName)
                    {
                        case "Rectangle":
                            var rectangle = drawingService.DrawRectangle(item.StartPoint, item.EndPoint, myPen, g, graph, item.ShapeName, item.PenColor);
                            break;
                        case "Circle":
                            var circle = new CircleShape(item.StartPoint, item.EndPoint, myPen, g, graph, item.ShapeName, item.PenColor);
                            circle.DrawShape(item.StartPoint, item.EndPoint);
                            break;
                        case "Line":
                            var line = new LineShape(item.StartPoint, item.EndPoint, myPen, g, graph, item.ShapeName, item.PenColor);
                            line.DrawShape(item.StartPoint, item.EndPoint);
                            break;
                    }
                }
            }
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            selectToolSelected = true;
            shapeToolSelected = false;
        }
    }
}