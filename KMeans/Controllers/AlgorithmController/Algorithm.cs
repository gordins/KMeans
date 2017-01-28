using System;
using System.Collections.Generic;
using System.Linq;
using KMeans.Controllers.DistanceController;
using KMeans.Model;

namespace KMeans.Controllers.AlgorithmController
{
    public class Algorithm
    {
        public List<Point> Centroids;
        public int Clusters;
        public IDistance Distance;
        public List<Point> Points;

        public Algorithm(IDistance distance, int clusters, List<Point> points, List<Point> centroids)
        {
            if ((distance == null) || (points == null) || (points.Count <= 1) || (clusters <= 1) ||
                (clusters >= points.Count))
                return;
            if (centroids != null)
            {
                if (clusters != centroids.Count)
                    return;
                Centroids = centroids;
            }
            else
            {
                var random = new Random();
                Centroids = new List<Point>(clusters);
                for (var i = 0; i < clusters; i++)
                    Centroids.Add(new Point(points[random.Next(points.Count)]));
            }
            Distance = distance;
            Clusters = clusters;
            Points = points;
            for (var i = 0; i < Clusters; i++)
                Centroids[i].Cluster = i;
        }

        public void Cluster()
        {
            var iterations = 0;
            var improved = true;
            while (improved && (iterations < 100))
            {
                Console.WriteLine("\nCentroids updated:");

                View.View.Show(this);
                foreach (var point in Points)
                {
                    var distance = Distance.Compare(point, Centroids[0]);
                    point.Cluster = 0;
                    for (var i = 1; i < Clusters; i++)
                        if (distance > Distance.Compare(point, Centroids[i]))
                            point.Cluster = i;
                }

                Console.WriteLine("\nClusters updated:");
                View.View.Show(this);

                var oldCentroids = new List<Point>();
                for (var i = 0; i < Clusters; i++)
                    oldCentroids.Add(new Point(Centroids[i]));

                for (var i = 0; i < Clusters; i++)
                {
                    var newX = 0.0;
                    var newY = 0.0;
                    var cluster = i;
                    var clusterPoints = new List<Point>(Points.Where(p => p.Cluster == cluster));
                    if (clusterPoints.Count == 0) continue;
                    foreach (var point in clusterPoints)
                    {
                        newX += point.X;
                        newY += point.Y;
                    }
                    Centroids[i].X = newX/clusterPoints.Count;
                    Centroids[i].Y = newY/clusterPoints.Count;
                }
                improved = false;
                for (var i = 0; i < Clusters; i++)
                {
                    if ((Math.Abs(Centroids[i].X - oldCentroids[i].X) < 0.0001) &&
                        (Math.Abs(Centroids[i].Y - oldCentroids[i].Y) < 0.0001)) continue;
                    improved = true;
                    break;
                }
                iterations++;
            }
            Console.WriteLine("\nCentroids updated:");
            View.View.Show(this);
        }
    }
}