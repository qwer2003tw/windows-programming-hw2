// file:	PresentationModel\WindowsStoreGraphicsAdaptor.cs
//
// summary:	Implements the windows store graphics adaptor class

using DrawingModel;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace DrawingApp.PresentationModel
{
    /// <summary>   The windows store graphics adaptor. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    class WindowsStoreGraphicsAdaptor : IGraphics
    {
        /// <summary>   The canvas. </summary>
        Canvas _canvas;

        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="canvas">   The canvas. </param>

        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        /// <summary>   Clears all. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        /// <summary>   Draw diamond. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="x1">   The first x value. </param>
        /// <param name="y1">   The first y value. </param>
        /// <param name="x2">   The second x value. </param>
        /// <param name="y2">   The second y value. </param>

        public void DrawDiamond(double x1, double y1, double x2, double y2)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>   Draw line. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="x1">   The first x value. </param>
        /// <param name="y1">   The first y value. </param>
        /// <param name="x2">   The second x value. </param>
        /// <param name="y2">   The second y value. </param>

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }
    }
}
