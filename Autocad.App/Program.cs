using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocad.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Point[] points = new[]
{
                new Point {X = 2, Y = 2},
                new Point {X = 5, Y = 6},
                new Point {X = 3, Y = 4},
                new Point {X = 7, Y = 4}
            };

            var sortedPoints = Services.Sort(points.ToList());
            var result = Calculate(sortedPoints);


            Point[] intersectPoints = new[]
            {
                new Point {X = 2, Y = 2},
                new Point {X = 3, Y = 4},
                new Point {X = 5, Y = 6},
                new Point {X = 5, Y = 4}
            };


            var isIntersect = Intersect.IsIntersect(intersectPoints[0], intersectPoints[1],
                intersectPoints[2], intersectPoints[3]);

            Console.WriteLine($"Sum of all line's length: {result}");
            Console.WriteLine($"IsIntersect: {isIntersect}");
            Console.ReadLine();
        }

        private static double Calculate(List<Point> points)
        {
            if (points.Count < 2) return 0;

            int i = 0;
            double totalDistance = 0;
            var firstPoint = points.First();
            var initialPoints = new List<Point>();
            points.ForEach(p =>
            {
                initialPoints.Add(new Point { X = p.X, Y = p.Y });
            });

            points.RemoveAt(0);

            foreach (var p in points)
            {
                var startPoint = initialPoints[i];
                totalDistance += Distance.Calculate(startPoint, p);
                i++;
            }

            totalDistance += Distance.Calculate(points.Last(), firstPoint);
            return totalDistance;
        }
    }
}
