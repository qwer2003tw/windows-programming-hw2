// file:	Diamond.cs
//
// summary:	Implements the diamond class

using System;
using Windows.Foundation;

namespace DrawingModel.Shape.Impl
{
    /// <summary>   A diamond. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public class Diamond : IShape
    {
        public Diamond(double x1, double y1, double x2, double y2)
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

        /// <summary>   Draws the given graphics. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="graphics"> The graphics. </param>

        public void Draw(IGraphics graphics, bool isRedLine)
        {
            graphics.DrawDiamond(X1, Y1, X2, Y2, isRedLine);
        }

        public bool IsInside(Point point)
        {
            const double DOUBLE = 2.0;
            double middleX = (X1 + X2) / DOUBLE;
            double middleY = (Y1 + Y2) / DOUBLE;
            Point top = new Point(middleX, Y1);
            Point right = new Point(X2, middleY);
            Point bottom = new Point(middleX, Y2);
            Point left = new Point(X1, middleY);
            return CheckPointInside(left, top, point, false) && CheckPointInside(top, right, point, false) && CheckPointInside(left, bottom, point, true) && CheckPointInside(bottom, right, point, true);
        }
        private bool CheckPointInside(Point firstPoint, Point secondPoint, Point point, bool isAbove)
        {
            double slope = (secondPoint.Y - firstPoint.Y) / (secondPoint.X - firstPoint.X);
            double bias = firstPoint.Y - slope * firstPoint.X;
            return isAbove ? (point.Y < point.X * slope + bias) : (point.Y > point.X * slope + bias);
        }
    }
}
