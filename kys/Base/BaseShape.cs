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
        public BaseShape(Point startPoint, Point endPoint, string shapeName, string penColor, float penWidth)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            ShapeName = shapeName;
            PenColor = penColor;
            PenWidth = penWidth;
        }
        public string ShapeName { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public string PenColor { get; set; }
        public float PenWidth { get; set; }
        public bool IsSelected { get; set; }
        public void DrawShape(Point startPoint, Point endPoint)
        {

        }
        public void SelectShape(float startPointX, float startPointY, float mousePointX, float mousePointY, float endPointX, float endPointY)
        {
                if (startPointX <= mousePointX && startPointY >= mousePointY && endPointX >= mousePointX && endPointY <= mousePointY)
                {

                    IsSelected = true;
                    return;
                }
                else if (startPointX >= mousePointX && startPointY >= mousePointY && endPointX <= mousePointX && endPointY <= mousePointY)
                {

                    IsSelected = true;
                    return;
                }
                else if (startPointX <= mousePointX && startPointY <= mousePointY && endPointX >= mousePointX && endPointY >= mousePointY)
                {

                    IsSelected = true;
                    return;
                }
                else if (startPointX >= mousePointX && startPointY <= mousePointY && endPointX <= mousePointX && endPointY >= mousePointY)
                {

                    IsSelected = true;
                    return;
                }
            IsSelected = false;
        }
        
    }
}
