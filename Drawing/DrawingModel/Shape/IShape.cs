// file:	Shape.cs
//
// summary:	Implements the shape class

using Windows.Foundation;

namespace DrawingModel.Shape
{
    /// <summary>   Interface for shape. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public interface IShape
    {
        double X1 { get; set; }
        double X2 { get; set; }
        double Y1 { get; set; }
        double Y2 { get; set; }
        /// <summary>   Draws the given graphics. </summary>
        ///
        /// <param name="graphics"> The graphics. </param>

        void Draw(IGraphics graphics, bool isRedLine);
        bool IsInside(Point point);
    }
}