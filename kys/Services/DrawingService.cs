using Draw.Base;
using Draw.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Services
{
    public class DrawingService
    {
        
        public RectangleShape DrawRectangle(Point startPoint, Point endPoint, Graphics g, Graphics graph, string shapeName, string penColor, float penWidth)
        {
            var rectangle = new RectangleShape(startPoint, endPoint, g, graph, shapeName, penColor,penWidth);
            rectangle.DrawShape(startPoint, endPoint);
            return rectangle;
        }
        public CircleShape DrawCircle(Point startPoint, Point endPoint, Graphics g, Graphics graph, string shapeName, string penColor, float penWidth)
        {
            var circle = new CircleShape(startPoint, endPoint, g, graph, shapeName, penColor, penWidth);
            circle.DrawShape(startPoint, endPoint);
            return circle;
        }
        public LineShape DrawLine(Point startPoint, Point endPoint, Graphics g, Graphics graph, string shapeName, string penColor, float penWidth)
        {
            var line = new LineShape(startPoint, endPoint, g, graph, shapeName, penColor, penWidth);
            line.DrawShape(startPoint, endPoint);
            return line;
        }
        public Rectangle DrawSelectedShape(Graphics g, Point StartPoint, Point EndPoint)
        {
            Rectangle rect = new Rectangle();
            rect.X = Math.Min(StartPoint.X, EndPoint.X);
            rect.Y = Math.Min(StartPoint.Y, EndPoint.Y);
            rect.Width = Math.Abs(StartPoint.X - (EndPoint.X));
            rect.Height = Math.Abs(StartPoint.Y - (EndPoint.Y));
            Pen pen = new Pen(Color.Azure, 5);
            g.DrawRectangle(pen, rect);
            return rect;
        }
        public void DrawAllShapes(List<BaseShape> shapes, Graphics g, Graphics graph)
        {
            foreach (var shape in shapes)
            {
                string oldColor = shape.PenColor;
                switch (shape.ShapeName)
                {
                    case "Rectangle":
                        if (shape.IsSelected == true)
                        {
                            shape.PenColor = "Color[Azure]";
                        }
                        DrawRectangle(shape.StartPoint, shape.EndPoint, g, graph, shape.ShapeName, shape.PenColor, shape.PenWidth);
                        break;
                    case "Circle":
                        if (shape.IsSelected == true)
                        {
                            shape.PenColor = "Color[Azure]";
                        }
                        DrawCircle(shape.StartPoint, shape.EndPoint, g, graph, shape.ShapeName, shape.PenColor, shape.PenWidth);
                        break;
                    case "Line":
                        if (shape.IsSelected == true)
                        {
                            shape.PenColor = "Color[Azure]";
                        }
                        DrawLine(shape.StartPoint, shape.EndPoint, g, graph, shape.ShapeName, shape.PenColor, shape.PenWidth);
                        break;
                }
                shape.PenColor = oldColor;
            }
        }
        public void DeselectShapes(List<BaseShape> shapes)
        {
            foreach (BaseShape shape in shapes)
            {
                shape.IsSelected = false;
            }
        }
    }
}
