using System;
using KMeans.Model;

namespace KMeans.Controllers.DistanceController
{
    public class EuclidianDistance : IDistance
    {
        public double Compare(Point a, Point b)
        {
            if ((a != null) && (b != null))
                return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
            return 0;
        }
    }
}