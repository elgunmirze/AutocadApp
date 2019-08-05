using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocad.App
{
    public static class Distance
    {
        public static double Calculate(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
        public static double RoughCalculate(Point p1, Point p2)
        {
            var deltaX = Math.Abs(p2.X - p1.X);
            var deltaY = Math.Abs(p2.Y - p1.Y);
            return deltaX > deltaY ? deltaX : deltaY;
        }
    }
}
