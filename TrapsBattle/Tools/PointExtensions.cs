using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace TrapsBattle.Tools
{
    static class PointExtensions
    {
        public static Point AddPoint(this Point point, Point otherPoint)
        {
            Point result;

            result.X = point.X + otherPoint.X;
            result.Y = point.Y + otherPoint.Y;

            return result;
        }

        public static Point SubtractPoint(this Point point, Point otherPoint)
        {
            Point result;

            result.X = point.X - otherPoint.X;
            result.Y = point.Y - otherPoint.Y;

            return result;
        }
    }
}
