using System.Text;

namespace KMeans.Model
{
    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point()
        {
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public int Cluster { get; set; } = -1;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder("x : ");
            stringBuilder.Append(X).Append(", y : ").Append(Y).Append(", cluster: ").Append(Cluster);
            return stringBuilder.ToString();
        }
    }
}