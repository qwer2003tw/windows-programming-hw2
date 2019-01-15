// file:	IGraphics.cs
//
// summary:	Declares the IGraphics interface

namespace DrawingModel
{
    /// <summary>   Interface for graphics. </summary>
    ///
    /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public interface IGraphics
    {
        /// <summary>   Clears all. </summary>
        void ClearAll();

        /// <summary>   Draw line. </summary>
        ///
        /// <param name="x1">           The first x value. </param>
        /// <param name="y1">           The first y value. </param>
        /// <param name="x2">           The second x value. </param>
        /// <param name="y2">           The second y value. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>

        void DrawLine(Point point1, Point point2, bool isRedLine);

        /// <summary>   Draw diamond. </summary>
        ///
        /// <param name="x1">           The first x value. </param>
        /// <param name="y1">           The first y value. </param>
        /// <param name="x2">           The second x value. </param>
        /// <param name="y2">           The second y value. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>

        void DrawDiamond(Point point1, Point point2, bool isRedLine);

        /// <summary>   Draw ellipse. </summary>
        ///
        /// <param name="x1">           The first x value. </param>
        /// <param name="y1">           The first y value. </param>
        /// <param name="x2">           The second x value. </param>
        /// <param name="y2">           The second y value. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>

        void DrawEllipse(Point point1, Point point2, bool isRedLine);
    }
}
