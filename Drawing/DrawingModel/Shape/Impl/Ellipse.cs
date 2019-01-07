// file:	Shape\Impl\Ellipse.cs
//
// summary:	Implements the ellipse class

using System;
using Windows.Foundation;

namespace DrawingModel.Shape.Implement
{
    /// <summary>   An ellipse. </summary>
    public class Ellipse : IShape
    {
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="x1">   The x coordinate 1. </param>
        /// <param name="y1">   The y coordinate 1. </param>
        /// <param name="x2">   The x coordinate 2. </param>
        /// <param name="y2">   The y coordinate 2. </param>

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

        /// <summary>   Draws the given graphics. </summary>
        ///
        /// <param name="graphics">     The graphics. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>

        public void Draw(IGraphics graphics, bool isRedLine)
        {
            graphics.DrawEllipse(this.X1, this.Y1, this.X2, this.Y2, isRedLine);
        }

        /// <summary>   Query if 'point' is inside. </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>   True if inside, false if not. </returns>

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
