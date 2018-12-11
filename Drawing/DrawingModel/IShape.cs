// file:	Shape.cs
//
// summary:	Implements the shape class

namespace DrawingModel
{
    /// <summary>   Interface for shape. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public interface IShape
    {
        /// <summary>   Draws the given graphics. </summary>
        ///
        /// <param name="graphics"> The graphics. </param>

        void Draw(IGraphics graphics);
    }
}