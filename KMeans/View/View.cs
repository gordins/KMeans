using System;
using KMeans.Controllers.AlgorithmController;

namespace KMeans.View
{
    public class View
    {
        public static void Show(Algorithm algorithm)
        {
            Console.WriteLine("Centroids: ");

            foreach (var centroid in algorithm.Centroids)
                Console.WriteLine(centroid);
            Console.WriteLine("Points: ");

            foreach (var point in algorithm.Points)
                Console.WriteLine(point);
        }
    }
}