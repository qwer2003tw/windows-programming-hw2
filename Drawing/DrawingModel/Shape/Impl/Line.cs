// file:	Line.cs
//
// summary:	Implements the line class

using System;

namespace DrawingModel.Shape.Implement
{
    /// <summary>   A line. </summary>
    ///
    /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public class Line : IShape
    {
        /// <summary>   The minimum distance. </summary>
        private const double MINIMUM_DISTANCE = 5;

        /// <summary>   Constructor. </summary>
        ///
        /// <param name="x1">   The x coordinate 1. </param>
        /// <param name="y1">   The y coordinate 1. </param>
        /// <param name="x2">   The x coordinate 2. </param>
        /// <param name="y2">   The y coordinate 2. </param>

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
        /// <param name="graphics">     The graphics. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>
        ///
        /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void Draw(IGraphics graphics, bool isRedLine)
        {
            Point point1 = new Point(X1, Y1);
            Point point2 = new Point(X2, Y2);
            graphics.DrawLine(point1, point2, isRedLine);
        }

        /// <summary>   Query if 'point' is inside. </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>   True if inside, false if not. </returns>

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
