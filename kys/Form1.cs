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

        string selectedShape;

        public Graphics g;

        public Graphics graph;

        public Pen pen = new Pen(Color.Black, 5);

        bool shapeToolSelected = false;

        Bitmap surface;

        DrawingService drawingService;

        bool selectToolSelected = false;

        public Form1()
        {
            InitializeComponent();

            g = canvas.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            pen.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);

            surface = new Bitmap(canvas.Width, canvas.Height);

            graph = Graphics.FromImage(surface);

            canvas.BackgroundImage = surface;
            canvas.BackgroundImageLayout = ImageLayout.None;

            pen.Width = (float)sizebar.Value;
            shapes = new List<BaseShape>();
            drawingService = new DrawingService();
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
                g.DrawLine(pen, oldPoint, currentPoint);
                graph.DrawLine(pen, oldPoint, currentPoint);

                oldPoint = currentPoint;
            }
            else if (e.Button == MouseButtons.Left && shapeToolSelected == true)
            {
                oldPoint = e.Location;
            }
        }

        private void eraserbtn_Click(object sender, EventArgs e)
        {
            pen.Color = canvas.BackColor;
            shapeToolSelected = false;
        }

        private void brushbtn_Click(object sender, EventArgs e)
        {
            pen.Color = colorselector.BackColor;
            shapeToolSelected = false;
        }

        private void colorselector_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                pen.Color = cd.Color;
                colorselector.BackColor = cd.Color;
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            graph.Clear(canvas.BackColor);
            canvas.Invalidate();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string shapesfigure = JsonSerializer.Serialize(shapes);

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
                        //System.IO.File.Copy(@"D:\config.json", sfd.FileName, true);
                        //File.WriteAllText(System.IO.Path.GetDirectoryName(sfd.FileName), shapesfigure);
                        File.WriteAllText(stringPath, shapesfigure);
                        break;
                }
            }
        }

        private void pbsize_Change(object sender, EventArgs e)
        {
            pen.Width = (float)sizebar.Value;
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
                var rectangle = drawingService.DrawRectangle(startingPoint, oldPoint, pen, g, graph, selectedShape);
                shapes.Add(rectangle);
            }
            else if (selectedShape == "Circle" && shapeToolSelected == true)
            {
                CircleShape circle = drawingService.DrawCircle(startingPoint, oldPoint, pen, g, graph, selectedShape);
                shapes.Add(circle);
            }
            else if (selectedShape == "Line" && shapeToolSelected == true)
            {
                var line = new LineShape(startingPoint, oldPoint, pen, g, graph, selectedShape);
                line.DrawShape(startingPoint, oldPoint);//service
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
                string filePath = dialog.FileName;
                string jsonString = File.ReadAllText(filePath);
                var shape = JsonSerializer.Deserialize<List<BaseShape>>(jsonString);
                foreach (var item in shape)
                {
                    switch (item.ShapeName)
                    {
                        case "Rectangle":
                            var rectangle = new RectangleShape(item.StartPoint, item.EndPoint, pen, g, graph, item.ShapeName);
                            rectangle.DrawShape(item.StartPoint, item.EndPoint);
                            break;
                        case "Circle":
                            var circle = new CircleShape(item.StartPoint, item.EndPoint, pen, g, graph, item.ShapeName);
                            circle.DrawShape(item.StartPoint, item.EndPoint);
                            break;
                        case "Line":
                            var line = new LineShape(item.StartPoint, item.EndPoint, pen, g, graph, item.ShapeName);
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