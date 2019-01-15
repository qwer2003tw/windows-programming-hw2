// file:	PresentationModel\WindowsFormsGraphicsAdapter.cs
//
// summary:	Implements the windows forms graphics adapter class

using DrawingModel;
using System.Drawing;

namespace DrawingForm.PresentationModel
{
    /// <summary>   The windows forms graphics adapter. </summary>
    ///
    /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public class WindowsFormsGraphicsAdapter : IGraphics
    {
        /// <summary>   The two. </summary>
        private const int TWO = 2;
        /// <summary>   The graphics. </summary>
        private readonly Graphics _graphics;

        /// <summary>   Constructor. </summary>
        ///
        /// <param name="graphics"> The graphics. </param>
        ///
        /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public WindowsFormsGraphicsAdapter(Graphics graphics)
        {
            this._graphics = graphics;
        }

        /// <summary>   Clears all. </summary>
        ///
        /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        /// <summary>   Draw diamond. </summary>
        ///
        /// <param name="x1">           The first x value. </param>
        /// <param name="y1">           The first y value. </param>
        /// <param name="x2">           The second x value. </param>
        /// <param name="y2">           The second y value. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>
        ///
        /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void DrawDiamond(DrawingModel.Point point1, DrawingModel.Point point2, bool isRedLine)
        {
            int middleX = (int)(point1.X + (point2.X - point1.X) / TWO);
            int middleY = (int)(point1.Y + (point2.Y - point1.Y) / TWO);
            System.Drawing.Point[] points = { new System.Drawing.Point(middleX, (int)point1.Y),
                new System.Drawing.Point((int)point1.X, middleY),
                new System.Drawing.Point(middleX, (int)point2.Y),
                new System.Drawing.Point((int)point2.X, middleY) };
            _graphics.FillPolygon(Brushes.BlueViolet, points);
            _graphics.DrawPolygon(isRedLine ? Pens.Red : Pens.Black, points);
        }

        /// <summary>   Draw ellipse. </summary>
        ///
        /// <param name="x1">           The first x value. </param>
        /// <param name="y1">           The first y value. </param>
        /// <param name="x2">           The second x value. </param>
        /// <param name="y2">           The second y value. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>

        public void DrawEllipse(DrawingModel.Point point1, DrawingModel.Point point2, bool isRedLine)
        {
            _graphics.DrawEllipse(isRedLine ? Pens.Red : Pens.Black, (float)point1.X, (float)point1.Y, (float)(point2.X - point1.X), (float)(point2.Y - point1.Y));
        }

        /// <summary>   Draw line. </summary>
        ///
        /// <param name="point1">           The first x value. </param>
        /// <param name="point2">           The second y value. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>
        ///
        /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void DrawLine(DrawingModel.Point point1, DrawingModel.Point point2, bool isRedLine)
        {
            _graphics.DrawLine(isRedLine ? Pens.Red : Pens.Black, (float)point1.X, (float)point1.Y, (float)point2.X, (float)point2.Y);
        }
    }
}
