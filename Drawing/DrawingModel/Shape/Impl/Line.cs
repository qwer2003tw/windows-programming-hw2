// file:	Line.cs
//
// summary:	Implements the line class

using System;
using Windows.Foundation;

namespace DrawingModel.Shape.Impl
{
    /// <summary>   A line. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public class Line : IShape
    {
        private const double MINIMUM_DISTANCE = 5;

        public Line(double x1, double y1, double x2, double y2)
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
            graphics.DrawLine(X1, Y1, X2, Y2, isRedLine);
        }

        public bool IsInside(Point point)
        {
            const int SQUARE = 2;
            double length = Math.Sqrt(Math.Pow(X2 - X1, SQUARE) + Math.Pow(Y2 - Y1, SQUARE));
            double distance1 = X2 - X1;
            double distance2 = Y1 - point.Y;
            double distance3 = X1 - point.X;
            double distance4 = Y2 - Y1;
            return Math.Abs(distance1 * distance2 - distance3 * distance4) / length <= MINIMUM_DISTANCE;
        }
    }
}
