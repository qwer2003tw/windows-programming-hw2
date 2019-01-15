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
        /// <param name="point1.X">           The first x value. </param>
        /// <param name="point1.Y">           The first y value. </param>
        /// <param name="point2.X">           The second x value. </param>
        /// <param name="point2.Y">           The second y value. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>
        ///
        /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void DrawDiamond(DrawingModel.Point point1, DrawingModel.Point point2, bool isRedLine)
        {
            Windows.UI.Xaml.Shapes.Polygon shape = new Windows.UI.Xaml.Shapes.Polygon();
            int middleX = (int)(point1.X + (point2.X - point1.X) / TWO);
            int middleY = (int)(point1.Y + (point2.Y - point1.Y) / TWO);

            PointCollection points = new PointCollection();
            points.Add(new Windows.Foundation.Point(middleX, (int)point1.Y));
            points.Add(new Windows.Foundation.Point((int)point1.X, middleY));
            points.Add(new Windows.Foundation.Point(middleX, (int)point2.Y));
            points.Add(new Windows.Foundation.Point((int)point2.X, middleY));
            shape.Points = points;
            shape.Margin = new Windows.UI.Xaml.Thickness(THICK);
            shape.Fill = new SolidColorBrush(Colors.AliceBlue);
            shape.Stroke = new SolidColorBrush(isRedLine ? Colors.Red : Colors.Black);
            _canvas.Children.Add(shape);
        }

        /// <summary>   Draw ellipse. </summary>
        ///
        /// <param name="point1.X">           The first x value. </param>
        /// <param name="point1.Y">           The first y value. </param>
        /// <param name="point2.X">           The second x value. </param>
        /// <param name="point2.Y">           The second y value. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>

        public void DrawEllipse(DrawingModel.Point point1, DrawingModel.Point point2, bool isRedLine)
        {
            Windows.UI.Xaml.Shapes.Ellipse shape = new Windows.UI.Xaml.Shapes.Ellipse();
            shape.Fill = new SolidColorBrush(Colors.AliceBlue);
            shape.Stroke = new SolidColorBrush(isRedLine ? Colors.Red : Colors.Black);
            shape.Width = Math.Abs(point2.X - point1.X);
            shape.Height = Math.Abs(point2.Y - point1.Y);
            Canvas.SetTop(shape, (point1.Y < point2.Y) ? point1.Y : point2.Y);
            Canvas.SetLeft(shape, (point1.X < point2.X) ? point1.X : point2.X);
            _canvas.Children.Add(shape);
        }

        /// <summary>   Draw line. </summary>
        ///
        /// <param name="point1.X">           The first x value. </param>
        /// <param name="point1.Y">           The first y value. </param>
        /// <param name="point2.X">           The second x value. </param>
        /// <param name="point2.Y">           The second y value. </param>
        /// <param name="isRedLine">    True if is red line, false if not. </param>
        ///
        /// ### <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void DrawLine(DrawingModel.Point point1, DrawingModel.Point point2, bool isRedLine)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = point1.X;
            line.Y1 = point1.Y;
            line.X2 = point2.X;
            line.Y2 = point2.Y;
            line.Stroke = new SolidColorBrush(isRedLine ? Colors.Red : Colors.Black);
            _canvas.Children.Add(line);
        }
    }
}
