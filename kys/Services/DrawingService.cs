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
        
        public RectangleShape DrawRectangle(Point startPoint, Point endPoint, Pen pen, Graphics g, Graphics graph, string shapeName)
        {
            var rectangle = new RectangleShape(startPoint, endPoint, pen, g, graph, shapeName);
            rectangle.DrawShape(startPoint, endPoint);
            return rectangle;
        }
        public CircleShape DrawCircle(Point startPoint, Point endPoint, Pen pen, Graphics g, Graphics graph, string shapeName)
        {
            var circle = new CircleShape(startPoint, endPoint, pen, g, graph, shapeName);
            circle.DrawShape(startPoint, endPoint); //service
            return circle;
        }
    }
}
