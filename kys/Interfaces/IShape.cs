using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Interfaces
{
    public interface IShape
    {
        void DrawShape(Point startPoint, Point endPoint);
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}
