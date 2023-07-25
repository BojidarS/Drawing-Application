using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw
{
    public class RectangleForm
    {
        private Point start;
        private Point current;
        private Point end;

        public Point Start { get { return start; } set {  start = value; } }
        public Point Current { get { return current; } set { current = value; } }
        public Point End { get { return end; } set { end = value; } }
        


    }
}
