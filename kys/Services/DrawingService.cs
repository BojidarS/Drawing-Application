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
        
        public RectangleShape DrawRectangle(Point startPoint, Point endPoint, Pen pen, Graphics g, Graphics graph, string shapeName, string penColor)
        {
            var rectangle = new RectangleShape(startPoint, endPoint, pen, g, graph, shapeName, penColor);
            rectangle.DrawShape(startPoint, endPoint);
            return rectangle;
        }
        public CircleShape DrawCircle(Point startPoint, Point endPoint, Pen pen, Graphics g, Graphics graph, string shapeName, string penColor)
        {
            var circle = new CircleShape(startPoint, endPoint, pen, g, graph, shapeName, penColor);
            circle.DrawShape(startPoint, endPoint);
            return circle;
        }
        public LineShape DrawLine(Point startPoint, Point endPoint, Pen pen, Graphics g, Graphics graph, string shapeName, string penColor)
        {
            var line = new LineShape(startPoint, endPoint, pen, g, graph, shapeName, penColor);
            line.DrawShape(startPoint, endPoint);
            return line;
        }
    }
}
