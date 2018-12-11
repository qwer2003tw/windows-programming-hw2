// file:	Diamond.cs
//
// summary:	Implements the diamond class

using System;

namespace DrawingModel
{
    /// <summary>   A diamond. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public class Diamond : IShape
    {
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

        public void Draw(IGraphics graphics)
        {
            graphics.DrawDiamond(X1, Y1, X2, Y2);
        }
    }
}
