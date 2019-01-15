// file:	Diamond.cs
//
// summary:	Implements the diamond class


namespace DrawingModel.Shape.Implement
{
    /// <summary>   A diamond. </summary>
    ///
    /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public class Diamond : IShape
    {
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="x1">   The x coordinate 1. </param>
        /// <param name="y1">   The y coordinate 1. </param>
        /// <param name="x2">   The x coordinate 2. </param>
        /// <param name="y2">   The y coordinate 2. </param>

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
        /// <param name="graphics">     The graphics. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>
        ///
        /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void Draw(IGraphics graphics, bool isRedLine)
        {
            graphics.DrawDiamond(X1, Y1, X2, Y2, isRedLine);
        }

        /// <summary>   Query if 'point' is inside. </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>   True if inside, false if not. </returns>

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

        /// <summary>   Check point inside. </summary>
        ///
        /// <param name="firstPoint">   The first point. </param>
        /// <param name="secondPoint">  The second point. </param>
        /// <param name="point">        The point. </param>
        /// <param name="isAbove">      True if is above, false if not. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>

        private bool CheckPointInside(Point firstPoint, Point secondPoint, Point point, bool isAbove)
        {
            double slope = (secondPoint.Y - firstPoint.Y) / (secondPoint.X - firstPoint.X);
            double bias = firstPoint.Y - slope * firstPoint.X;
            return isAbove ? (point.Y < point.X * slope + bias) : (point.Y > point.X * slope + bias);
        }
    }
}
