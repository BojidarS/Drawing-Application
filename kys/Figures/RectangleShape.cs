using Draw.Base;
using Draw.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Draw.Figures
{
    public class RectangleShape:BaseShape
    {
        [JsonConstructor]
        public RectangleShape(Point startPoint, Point endPoint, Pen pen, Graphics g, Graphics graph, string shapeName, string penColor) : base(startPoint, endPoint, shapeName, penColor)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            CurrentPen = pen;
            DrawingGraphics = g;
            CanvasGraphics = graph;
            var startIndex = penColor.IndexOf('[')+1;
            var endIndex = penColor.IndexOf(']');
            var toRead = (endIndex - startIndex);
            var actualPenColor = penColor.Substring(startIndex, toRead);
            if (Regex.IsMatch(actualPenColor, @"^[a-zA-Z]+$") == true)
            {
                CurrentPen.Color = System.Drawing.Color.FromName(actualPenColor);
            }
            else
            {
                var arbgColor = CurrentPen.Color.ToArgb();
                CurrentPen.Color = System.Drawing.Color.FromArgb(arbgColor);
            }
            
        }
        public Graphics DrawingGraphics { get; set; }
        public Graphics CanvasGraphics { get; set; }
        public Pen CurrentPen { get; set; }
        public  Point StartPoint {get; set;}
        public Point EndPoint { get; set; }
        public string PenColor { get; set; }
        public Color LoadedColor { get; set; }
        public void DrawShape(Point startPoint, Point endPoint)
        {
            
            DrawingGraphics.DrawRectangle(CurrentPen, GetRecta());
            CanvasGraphics.DrawRectangle(CurrentPen, GetRecta());
        }
        public Rectangle GetRecta()
        {
            var rect = new Rectangle();
            rect.X = Math.Min(StartPoint.X, EndPoint.X);
            rect.Y = Math.Min(StartPoint.Y, EndPoint.Y);
            rect.Width = Math.Abs(StartPoint.X - EndPoint.X);
            rect.Height = Math.Abs(StartPoint.Y - EndPoint.Y);
            return rect;
        }


    }
}
