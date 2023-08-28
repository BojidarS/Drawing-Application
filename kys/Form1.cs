using Draw;
using Draw.Base;
using Draw.Figures;
using Draw.Interfaces;
using Draw.Services;
using Microsoft.Win32;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace kys
{
    public partial class Form1 : Form
    {
        List<BaseShape> shapes;
        public Point startingPoint = new Point();
        public Point currentPoint = new Point();
        public Point oldPoint = new Point();
        string penColor = "Color [Black]";
        string selectedShape;
        float penWidth;
        public Graphics g;
        bool shapeSelected = false;
        public Graphics graph;
        bool moveSelected = false;
        public Pen myPen = new Pen(Color.Black, 5);
        List<BaseShape> selectShape;
        bool shapeToolSelected = false;
        bool deleteSelected = false;
        Bitmap surface;
        DrawingService drawingService;
        FileService fileService;
        ShapeService shapeService;
        bool brushSelected = true;

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
            shapeService = new ShapeService();
            selectShape = new List<BaseShape>();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            oldPoint = e.Location; // dont touch
            startingPoint = e.Location;
            Rectangle drawOutline;
            if (selectToolSelected == true || deleteSelected == true)
            {
                drawingService.DeselectShapes(shapes);
                foreach (BaseShape shape in shapes)
                {
                    shape.SelectShape(shape.StartPoint.X, shape.StartPoint.Y, e.X, e.Y, shape.EndPoint.X, shape.EndPoint.Y);
                }
                canvas.Invalidate();
                g.Clear(canvas.BackColor);
                drawingService.DrawAllShapes(shapes, g, graph);

            }
            if (deleteSelected == true)
            {
                foreach (BaseShape shape in shapes.ToList())
                {
                    if (shape.IsSelected == true)
                    {
                        graph.Clear(canvas.BackColor);
                        g.Clear(canvas.BackColor);
                        shapes.Remove(shape);
                        canvas.Invalidate();
                        drawingService.DrawAllShapes(shapes, g, graph);
                    }
                }
            }

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            x_mouse_label.Text = "X: " + e.X;
            y_mouse_label.Text = "Y: " + e.Y;
            if (e.Button == MouseButtons.Left && brushSelected == true)
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
            else if (e.Button == MouseButtons.Left && moveSelected == true)
            {
                foreach (BaseShape shape in shapes)
                {
                    currentPoint = e.Location;
                    if (shape.IsSelected == true)
                    {
                        var originalShape = selectShape[0];
                        //var offset = originalShape.StartPoint + e.Location;
                        var offset = new Point(originalShape.StartPoint.X + e.X, originalShape.StartPoint.Y + e.Y);
                        //shape.StartPoint += offset;
                        var origStartX = offset.X + originalShape.StartPoint.X;
                        var origStartY = offset.Y + originalShape.StartPoint.Y;
                        var origEndX = offset.X + originalShape.EndPoint.X;
                        var origEndY = offset.Y + originalShape.EndPoint.Y;
                        var orignStartPoint = new Point(origStartX, origStartY);
                        var orignEndPoint = new Point(origEndX, origEndY);
                        shape.StartPoint = orignStartPoint;
                        shape.EndPoint = orignEndPoint;

                    }
                }
                //canvas.Invalidate();
                drawingService.DrawAllShapes(shapes, g, graph);
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
                penColor = cd.Color.ToString();
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
            penWidth = (float)sizebar.Value;
        }

        private void rectanglebtn_Click(object sender, EventArgs e)
        {
            shapeToolSelected = true;
            selectedShape = "Rectangle";
            selectToolSelected = false;
            moveSelected = false;
            deleteSelected = false;
            brushSelected = false;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedShape == "Rectangle" && shapeToolSelected == true)
            {
                //var rectangle = new RectangleShape(startingPoint, oldPoint, pen, g, graph, selectedShape);
                //rectangle.DrawShape(startingPoint, oldPoint); //service
                var rectangle = drawingService.DrawRectangle(startingPoint, oldPoint, g, graph, selectedShape, penColor, penWidth);
                shapes.Add(rectangle);
            }
            else if (selectedShape == "Circle" && shapeToolSelected == true)
            {
                CircleShape circle = drawingService.DrawCircle(startingPoint, oldPoint, g, graph, selectedShape, penColor, penWidth);
                shapes.Add(circle);
            }
            else if (selectedShape == "Line" && shapeToolSelected == true)
            {
                LineShape line = drawingService.DrawLine(startingPoint, oldPoint, g, graph, selectedShape, penColor, penWidth);
                shapes.Add(line);
            }
        }



        private void circle_btn_Click(object sender, EventArgs e)
        {
            shapeToolSelected = true;
            selectedShape = "Circle";
            selectToolSelected = false;
            deleteSelected = false;
            brushSelected = false;
        }

        private void line_btn_Click(object sender, EventArgs e)
        {
            selectedShape = "Line";
            shapeToolSelected = true;
            selectToolSelected = false;
            deleteSelected = false;
            brushSelected = false;
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
                            var startIndex = item.PenColor.IndexOf('[') + 1;
                            var endIndex = item.PenColor.IndexOf(']');
                            var toRead = (endIndex - startIndex);
                            var actualPenColor = item.PenColor.Substring(startIndex, toRead);
                            if (Regex.IsMatch(actualPenColor, @"^[a-zA-Z]+$") == true)
                            {
                                myPen.Color = System.Drawing.Color.FromName(actualPenColor);
                            }
                            else
                            {
                                var arbgColor = myPen.Color.ToArgb();
                                myPen.Color = System.Drawing.Color.FromArgb(arbgColor);
                            }
                            var rectangle = drawingService.DrawRectangle(item.StartPoint, item.EndPoint, g, graph, item.ShapeName, item.PenColor, item.PenWidth);
                            break;
                        case "Circle":
                            var circle = new CircleShape(item.StartPoint, item.EndPoint, g, graph, item.ShapeName, item.PenColor, item.PenWidth);
                            circle.DrawShape(item.StartPoint, item.EndPoint);
                            break;
                        case "Line":
                            var line = new LineShape(item.StartPoint, item.EndPoint, g, graph, item.ShapeName, item.PenColor, item.PenWidth);
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
            moveSelected = false;
            deleteSelected = false;
            brushSelected = false;
        }

        private void move_btn_Click(object sender, EventArgs e)
        {
            moveSelected = true;
            shapeToolSelected = false;
            selectToolSelected = false;
            deleteSelected = false;
            brushSelected = false;
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            deleteSelected = true;
            selectToolSelected = false;
            moveSelected = false;
            shapeToolSelected = false;
            brushSelected = false;
        }
    }
}