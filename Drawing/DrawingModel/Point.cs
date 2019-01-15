namespace DrawingModel
{
    public class Point
    {
        public Point(double firstPoint, double secondPoint)
        {
            this.X = firstPoint;
            this.Y = secondPoint;
        }
        public double X
        {
            get;
            set;
        }
        public double Y
        {
            get;
            set;
        }
    }
}
