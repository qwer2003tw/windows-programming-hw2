// file:	IGraphics.cs
//
// summary:	Declares the IGraphics interface

namespace DrawingModel
{
    /// <summary>   Interface for graphics. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public interface IGraphics
    {
        /// <summary>   Clears all. </summary>
        void ClearAll();

        /// <summary>   Draw line. </summary>
        ///
        /// <param name="x1">   The first x value. </param>
        /// <param name="y1">   The first y value. </param>
        /// <param name="x2">   The second x value. </param>
        /// <param name="y2">   The second y value. </param>

        void DrawLine(double x1, double y1, double x2, double y2);

        /// <summary>   Draw diamond. </summary>
        ///
        /// <param name="x1">   The first x value. </param>
        /// <param name="y1">   The first y value. </param>
        /// <param name="x2">   The second x value. </param>
        /// <param name="y2">   The second y value. </param>

        void DrawDiamond(double x1, double y1, double x2, double y2);

    }
}
