using KMeans.Model;

namespace KMeans.Controllers.DistanceController
{
    public interface IDistance
    {
        double Compare(Point a, Point b);
    }
}