// file:	Model.cs
//
// summary:	Implements the model class

using System.Collections.Generic;

namespace DrawingModel
{
    /// <summary>   A model. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public class Model
    {
        /// <summary>   Values that represent draw types. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public enum DrawType { Line, Diamond, None };
        /// <summary>   Event queue for all listeners interested in _modelChanged events. </summary>
        public event ModelChangedEventHandler _modelChanged;

        /// <summary>   Delegate for handling ModelChanged events. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public delegate void ModelChangedEventHandler();
        /// <summary>   The first point x coordinate. </summary>
        double _firstPointX;
        /// <summary>   The first point y coordinate. </summary>
        double _firstPointY;
        /// <summary>   True if is pressed, false if not. </summary>
        bool _isPressed = false;
        /// <summary>   The lines. </summary>
        readonly List<Line> _lines = new List<Line>();
        /// <summary>   The diamonds. </summary>
        readonly List<Diamond> _diamonds = new List<Diamond>();
        /// <summary>   The line. </summary>
        readonly Line _line = new Line();
        /// <summary>   The diamond. </summary>
        readonly Diamond _diamond = new Diamond();

        /// <summary>   Type of the draw. </summary>
        DrawType _drawType = DrawType.None;

        /// <summary>   Pointer pressed. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>

        public void PointerPressed(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                switch (_drawType)
                {
                    case DrawType.Line:
                        _line.X1 = _firstPointX;
                        _line.Y1 = _firstPointY;
                        break;
                    case DrawType.Diamond:
                        _diamond.X1 = _firstPointX;
                        _diamond.Y1 = _firstPointY;
                        break;
                }

                _isPressed = true;
            }
        }

        /// <summary>   Pointer moved. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>

        public void PointerMoved(double x, double y)
        {
            if (_isPressed)
            {
                switch (_drawType)
                {
                    case DrawType.Line:
                        _line.X2 = x;
                        _line.Y2 = y;
                        break;
                    case DrawType.Diamond:
                        _diamond.X2 = x;
                        _diamond.Y2 = y;
                        break;
                }
                NotifyModelChanged();
            }
        }

        /// <summary>   Pointer released. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="x">    The x coordinate. </param>
        /// <param name="y">    The y coordinate. </param>

        public void PointerReleased(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                switch (_drawType)
                {
                    case DrawType.Line:
                        var line = new Line();
                        line.X1 = _firstPointX;
                        line.Y1 = _firstPointY;
                        line.X2 = x;
                        line.Y2 = y;
                        _lines.Add(line);
                        break;
                    case DrawType.Diamond:
                        var diamond = new Diamond();
                        diamond.X1 = _firstPointX;
                        diamond.Y1 = _firstPointY;
                        diamond.X2 = x;
                        diamond.Y2 = y;
                        _diamonds.Add(diamond);
                        break;
                }
                NotifyModelChanged();
            }
        }

        /// <summary>   Clears this object to its blank/initial state. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void Clear()
        {
            _isPressed = false;
            _lines.Clear();
            _diamonds.Clear();
            NotifyModelChanged();
        }

        /// <summary>   Draws the given graphics. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="graphics"> The graphics. </param>

        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (var line in _lines)
                line.Draw(graphics);
            foreach (var diamond in _diamonds)
                diamond.Draw(graphics);
            if (_isPressed)
            {
                switch (_drawType)
                {
                    case DrawType.Line:
                        _line.Draw(graphics);
                        break;
                    case DrawType.Diamond:
                        _diamond.Draw(graphics);
                        break;
                }

            }

        }

        /// <summary>   Change to line. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void ChangeToLine()
        {
            _drawType = DrawType.Line;
        }

        /// <summary>   Change to diamond. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void ChangeToDiamond()
        {
            _drawType = DrawType.Diamond;
        }

        /// <summary>   Notifies the model changed. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
