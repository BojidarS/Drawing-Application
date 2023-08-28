using Draw.Base;
using Draw.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Draw.Figures
{
    public class LineShape:BaseShape
    {
        [JsonConstructor]
        public LineShape(Point startPoint, Point endPoint, Graphics g, Graphics graph, string shapeName, string penColor, float penWidth) : base(startPoint, endPoint, shapeName, penColor, penWidth)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            CurrentPen = new Pen(Color.Black, 5);
            CurrentPen.Width = penWidth;
            DrawingGraphics = g;
            CanvasGraphics = graph;
            var startIndex = penColor.IndexOf('[') + 1;
            var endIndex = penColor.IndexOf(']');
            var toRead = (endIndex - startIndex);
            var actualPenColor = penColor.Substring(startIndex, toRead);
            if (Regex.IsMatch(actualPenColor, @"^[a-zA-Z]+$") == true)
            {
                CurrentPen.Color = System.Drawing.Color.FromName(actualPenColor);
            }
            else
            {
                string[] argb;
                List<int> converted = new List<int>();
                argb = Regex.Split(actualPenColor, @"\D+");

                for (int i = 0; i < argb.Length; i++)
                {
                    if (i > 0)
                    {
                        converted.Add(Convert.ToInt32(argb[i]));
                    }
                }
                CurrentPen.Color = System.Drawing.Color.FromArgb(converted[0], converted[1], converted[2], converted[3]);
            }
        }
        public Graphics DrawingGraphics { get; set; }
        public Graphics CanvasGraphics { get; set; }
        public Pen CurrentPen { get; set; }
        public  Point StartPoint {get; set;}
        public Point EndPoint { get; set; }
        public string PenColor { get; set; }

        public void DrawShape(Point startPoint, Point endPoint)
        {
            DrawingGraphics.DrawLine(CurrentPen, startPoint, endPoint);
            CanvasGraphics.DrawLine(CurrentPen, startPoint, endPoint);
        }
    }
}
