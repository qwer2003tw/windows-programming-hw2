// file:	ShapeFactory.cs
//
// summary:	Implements the shape factory class

using DrawingModel.Shape.Implement;

namespace DrawingModel
{
    /// <summary>   A shape factory. </summary>
    public static class ShapeFactory
    {
        /// <summary>   Gets a diamond. </summary>
        ///
        /// <param name="x1">   The first x value. </param>
        /// <param name="y1">   The first y value. </param>
        /// <param name="x2">   The second x value. </param>
        /// <param name="y2">   The second y value. </param>
        ///
        /// <returns>   The diamond. </returns>

        public static Diamond GetDiamond(double x1, double y1, double x2, double y2)
        {
            return new Diamond(x1, y1, x2, y2);
        }

        /// <summary>   Gets a line. </summary>
        ///
        /// <param name="x1">   The first x value. </param>
        /// <param name="y1">   The first y value. </param>
        /// <param name="x2">   The second x value. </param>
        /// <param name="y2">   The second y value. </param>
        ///
        /// <returns>   The line. </returns>

        public static Line GetLine(double x1, double y1, double x2, double y2)
        {
            return new Line(x1, y1, x2, y2);
        }

        /// <summary>   Gets an ellipse. </summary>
        ///
        /// <param name="x1">   The first x value. </param>
        /// <param name="y1">   The first y value. </param>
        /// <param name="x2">   The second x value. </param>
        /// <param name="y2">   The second y value. </param>
        ///
        /// <returns>   The ellipse. </returns>

        public static Ellipse GetEllipse(double x1, double y1, double x2, double y2)
        {
            return new Ellipse(x1, y1, x2, y2);
        }
    }
}
