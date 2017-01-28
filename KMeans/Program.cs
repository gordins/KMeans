using System.Collections.Generic;
using KMeans.Controllers.AlgorithmController;
using KMeans.Controllers.DistanceController;
using KMeans.Model;

namespace KMeans
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var points = new List<Point>
            {
                new Point(-9, 0),
                new Point(-8, 0),
                new Point(-7, 0),
                new Point(-6, 0),
                new Point(-5, 0),
                new Point(9, 0),
                new Point(8, 0),
                new Point(7, 0),
                new Point(6, 0),
                new Point(5, 0),
                new Point(9, 0),
                new Point(8, 0),
                new Point(7, 0),
                new Point(6, 0),
                new Point(5, 0)
            };
            var centroids = new List<Point>(2) {new Point(-20, 0), new Point(-10, 0)};

            var algorithm = new Algorithm(new EuclidianDistance(), 2, points, centroids);
            algorithm.Cluster();
        }
    }
}