using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Services
{
    public class ShapeService
    {
        public string SelectShape(float startPointX, float startPointY, float mousePointX, float mousePointY, float endPointX, float endPointY)
        {
            if (startPointX <= mousePointX && startPointY >= mousePointY && endPointX >= mousePointX && endPointY <= mousePointY)
            {

                return "Selected";
            }
            return "Nothing Selected";
        }
    }
}
