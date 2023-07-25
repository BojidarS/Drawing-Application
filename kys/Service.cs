using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw
{
    public class Service
    {
        Rectangle rect;
        
        
        public Rectangle GetRect(Point starting, Point current)
        {
            rect = new Rectangle();
            rect.X = Math.Min(starting.X, current.X);
            rect.Y = Math.Min(starting.Y, current.Y);
            rect.Width = Math.Abs(starting.X - current.X);
            rect.Height = Math.Abs(starting.Y - current.Y);
            return rect;
        }
    }
}
