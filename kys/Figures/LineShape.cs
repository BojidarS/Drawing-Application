using Draw.Base;
using Draw.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Draw.Figures
{
    public class LineShape:BaseShape
    {
        [JsonConstructor]
        public LineShape(Point startPoint, Point endPoint, Pen pen, Graphics g, Graphics graph, string shapeName) : base(startPoint, endPoint, shapeName)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            CurrentPen = pen;
            DrawingGraphics = g;
            CanvasGraphics = graph;
        }
        public Graphics DrawingGraphics { get; set; }
        public Graphics CanvasGraphics { get; set; }
        public Pen CurrentPen { get; set; }
        public  Point StartPoint {get; set;}
        public Point EndPoint { get; set; }

        public void DrawShape(Point startPoint, Point endPoint)
        {
            DrawingGraphics.DrawLine(CurrentPen, startPoint, endPoint);
            CanvasGraphics.DrawLine(CurrentPen, startPoint, endPoint);
        }
    }
}
