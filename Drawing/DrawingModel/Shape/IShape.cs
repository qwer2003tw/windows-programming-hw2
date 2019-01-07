// file:	Shape.cs
//
// summary:	Implements the shape class

using Windows.Foundation;

namespace DrawingModel.Shape
{
    /// <summary>   Interface for shape. </summary>
    ///
    /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public interface IShape
    {
        /// <summary>   Gets or sets the x coordinate 1. </summary>
        ///
        /// <value> The x coordinate 1. </value>

        double X1
        {
            get;
            set;
        }

        /// <summary>   Gets or sets the x coordinate 2. </summary>
        ///
        /// <value> The x coordinate 2. </value>

        double X2
        {
            get;
            set;
        }

        /// <summary>   Gets or sets the y coordinate 1. </summary>
        ///
        /// <value> The y coordinate 1. </value>

        double Y1
        {
            get;
            set;
        }

        /// <summary>   Gets or sets the y coordinate 2. </summary>
        ///
        /// <value> The y coordinate 2. </value>

        double Y2
        {
            get;
            set;
        }

        /// <summary>   Draws the given graphics. </summary>
        ///
        /// <param name="graphics">     The graphics. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>

        void Draw(IGraphics graphics, bool isRedLine = false);

        /// <summary>   Query if 'point' is inside. </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>   True if inside, false if not. </returns>

        bool IsInside(Point point);
    }
}