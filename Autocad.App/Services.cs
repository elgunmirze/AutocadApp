using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocad.App
{
    public static class Services
    {
        public static List<Point> Sort(List<Point> pointList)
        {
            var sortedList = new List<Point>();
            var startPoint = pointList[0];

            while (pointList.Count > 1)
            {
                sortedList.Add(startPoint);
                pointList.RemoveAt(pointList.IndexOf(startPoint));
                var closestPointIndex = 0;
                var closestDistance = double.MaxValue;
                for (var i = 0; i < pointList.Count; i++)
                {
                    var pointDistance = Distance.RoughCalculate(startPoint, pointList[i]);
                    if (pointDistance > closestDistance)
                        continue;
                    var distance = Distance.Calculate(startPoint, pointList[i]);
                    if (distance < closestDistance)
                    {
                        closestPointIndex = i;
                        closestDistance = distance;
                    }
                }
                startPoint = pointList[closestPointIndex];
            }

            sortedList.Add(startPoint);
            return sortedList;
        }
    }
}
