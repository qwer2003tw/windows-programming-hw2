using System;
using Windows.Foundation;

namespace DrawingModel.Shape.Impl
{
    public class Ellipse : IShape
    {
        public Ellipse(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
        /// <summary>   Gets or sets the x coordinate 1. </summary>
        ///
        /// <value> The x coordinate 1. </value>

        public double X1
        {
            get; set;
        }

        /// <summary>   Gets or sets the y coordinate 1. </summary>
        ///
        /// <value> The y coordinate 1. </value>

        public double Y1
        {
            get; set;
        }

        /// <summary>   Gets or sets the x coordinate 2. </summary>
        ///
        /// <value> The x coordinate 2. </value>

        public double X2
        {
            get; set;
        }

        /// <summary>   Gets or sets the y coordinate 2. </summary>
        ///
        /// <value> The y coordinate 2. </value>

        public double Y2
        {
            get; set;
        }

        public void Draw(IGraphics graphics, bool isRedLine)
        {
            graphics.DrawEllipse(this.X1, this.Y1, this.X2, this.Y2, isRedLine);
        }

        public bool IsInside(Point point)
        {
            const double DOUBLE = 2.0;
            double center1 = (X1 + X2) / DOUBLE;
            double center2 = (Y1 + Y2) / DOUBLE;
            double length1 = center1 - X1;
            double length2 = center2 - Y1;
            double result = (Math.Pow(point.X - center1, DOUBLE) / Math.Pow(length1, DOUBLE)) + (Math.Pow((point.Y - center2), DOUBLE) / Math.Pow(length2, DOUBLE));
            return result <= 1;
        }
    }
}
