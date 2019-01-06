// file:	PresentationModel\WindowsFormsGraphicsAdapter.cs
//
// summary:	Implements the windows forms graphics adapter class

using DrawingModel;
using System.Drawing;

namespace DrawingForm.PresentationModel
{
    /// <summary>   The windows forms graphics adapter. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public class WindowsFormsGraphicsAdapter : IGraphics
    {
        /// <summary>   The two. </summary>
        private const int TWO = 2;
        /// <summary>   The graphics. </summary>
        private readonly Graphics _graphics;

        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="graphics"> The graphics. </param>

        public WindowsFormsGraphicsAdapter(Graphics graphics)
        {
            this._graphics = graphics;
        }

        /// <summary>   Clears all. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        /// <summary>   Draw diamond. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="x1">   The first x value. </param>
        /// <param name="y1">   The first y value. </param>
        /// <param name="x2">   The second x value. </param>
        /// <param name="y2">   The second y value. </param>

        public void DrawDiamond(double x1, double y1, double x2, double y2, bool isRedLine)
        {
            int middleX = (int)(x1 + (x2 - x1) / TWO);
            int middleY = (int)(y1 + (y2 - y1) / TWO);
            Point[] points = { new Point(middleX, (int)y1),
                new Point((int)x1, middleY),
                new Point(middleX, (int)y2),
                new Point((int)x2, middleY) };
            _graphics.FillPolygon(Brushes.BlueViolet, points);
            _graphics.DrawPolygon(isRedLine ? Pens.Red : Pens.Black, points);
        }

        public void DrawEllipse(double x1, double y1, double x2, double y2, bool isRedLine)
        {
            _graphics.DrawEllipse(isRedLine ? Pens.Red : Pens.Black, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }

        /// <summary>   Draw line. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="x1">   The first x value. </param>
        /// <param name="y1">   The first y value. </param>
        /// <param name="x2">   The second x value. </param>
        /// <param name="y2">   The second y value. </param>

        public void DrawLine(double x1, double y1, double x2, double y2, bool isRedLine)
        {
            _graphics.DrawLine(isRedLine ? Pens.Red : Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }
    }
}
