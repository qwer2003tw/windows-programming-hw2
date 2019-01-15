// file:	PresentationModel\WindowsStoreGraphicsAdaptor.cs
//
// summary:	Implements the windows store graphics adaptor class

using DrawingModel;
using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace DrawingApp.PresentationModel
{
    /// <summary>   The windows store graphics adaptor. </summary>
    ///
    /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    class WindowsStoreGraphicsAdaptor : IGraphics
    {
        /// <summary>   The two. </summary>
        private const int TWO = 2;
        /// <summary>   The thick. </summary>
        private const int THICK = 25;
        /// <summary>   The canvas. </summary>
        Canvas _canvas;

        /// <summary>   Constructor. </summary>
        ///
        /// <param name="canvas">   The canvas. </param>
        ///
        /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        /// <summary>   Clears all. </summary>
        ///
        /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void ClearAll()
        {
            _canvas.Children.Clear();
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

        public void DrawDiamond(double x1, double y1, double x2, double y2, bool isRedLine)
        {
            Windows.UI.Xaml.Shapes.Polygon shape = new Windows.UI.Xaml.Shapes.Polygon();
            int middleX = (int)(x1 + (x2 - x1) / TWO);
            int middleY = (int)(y1 + (y2 - y1) / TWO);

            PointCollection points = new PointCollection();
            points.Add(new Windows.Foundation.Point(middleX, (int)y1));
            points.Add(new Windows.Foundation.Point((int)x1, middleY));
            points.Add(new Windows.Foundation.Point(middleX, (int)y2));
            points.Add(new Windows.Foundation.Point((int)x2, middleY));
            shape.Points = points;
            shape.Margin = new Windows.UI.Xaml.Thickness(THICK);
            shape.Fill = new SolidColorBrush(Colors.AliceBlue);
            shape.Stroke = new SolidColorBrush(isRedLine ? Colors.Red : Colors.Black);
            _canvas.Children.Add(shape);
        }

        /// <summary>   Draw ellipse. </summary>
        ///
        /// <param name="x1">           The first x value. </param>
        /// <param name="y1">           The first y value. </param>
        /// <param name="x2">           The second x value. </param>
        /// <param name="y2">           The second y value. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>

        public void DrawEllipse(double x1, double y1, double x2, double y2, bool isRedLine)
        {
            Windows.UI.Xaml.Shapes.Ellipse shape = new Windows.UI.Xaml.Shapes.Ellipse();
            shape.Fill = new SolidColorBrush(Colors.AliceBlue);
            shape.Stroke = new SolidColorBrush(isRedLine ? Colors.Red : Colors.Black);
            shape.Width = Math.Abs(x2 - x1);
            shape.Height = Math.Abs(y2 - y1);
            Canvas.SetTop(shape, (y1 < y2) ? y1 : y2);
            Canvas.SetLeft(shape, (x1 < x2) ? x1 : x2);
            _canvas.Children.Add(shape);
        }

        /// <summary>   Draw line. </summary>
        ///
        /// <param name="x1">           The first x value. </param>
        /// <param name="y1">           The first y value. </param>
        /// <param name="x2">           The second x value. </param>
        /// <param name="y2">           The second y value. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>
        ///
        /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void DrawLine(double x1, double y1, double x2, double y2, bool isRedLine)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(isRedLine ? Colors.Red : Colors.Black);
            _canvas.Children.Add(line);
        }
    }
}
