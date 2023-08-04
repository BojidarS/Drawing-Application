using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Draw.Base
{
    public class BaseShape
    {
        public BaseShape(Point startPoint, Point endPoint, string shapeName)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            ShapeName = shapeName;
        }
        public string ShapeName { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public void DrawShape(Point startPoint, Point endPoint)
        {

        }
    }
}
