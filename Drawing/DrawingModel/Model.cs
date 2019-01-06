// file:	Model.cs
//
// summary:	Implements the model class

using DrawingModel.Shape;
using DrawingModel.Shape.Impl;
using DrawingModel.State.Impl;
using System.Collections.Generic;
using Windows.Foundation;

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

        public delegate void ModelChangedEventHandler();
        /// <summary>   Event queue for all listeners interested in _modelChanged events. </summary>
        public event ModelChangedEventHandler _modelChanged;
        /// <summary>   Event queue for all listeners interested in _modelChanged events. </summary>

        /// <summary>   The first point x coordinate. </summary>
        double _firstPointX;
        /// <summary>   The first point y coordinate. </summary>
        double _firstPointY;
        /// <summary>   True if is pressed, false if not. </summary>
        bool _isPressed = false;
        ///// <summary>   The lines. </summary>
        //readonly List<Line> _lines = new List<Line>();
        ///// <summary>   The diamonds. </summary>
        //readonly List<Diamond> _diamonds = new List<Diamond>();
        readonly List<IShape> _shapes = new List<IShape>();
        IShape _shape;
        IState _state;
        IGraphics _graphics;


        /// <summary>   Type of the draw. </summary>
        DrawType _drawType = DrawType.None;

        public Model(IGraphics graphics)
        {
            _graphics = graphics;
        }
        public void ChangeToDrawingState(DrawType _drawType)
        {
            IState newState = new DrawingState(this, _graphics, _drawType);
            _state = newState;
        }


        public void ChangeToPointerState()
        {
            IState newState = new PointerState(this);
            _state = newState;
            //if (_updatePointerEvent != null)
            //    _updatePointerEvent();
        }

        /// <summary>   Pointer pressed. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="pointX">   The x coordinate. </param>
        /// <param name="pointY">   The y coordinate. </param>

        public void PressPointer(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                _firstPointX = pointX;
                _firstPointY = pointY;
                switch (_drawType)
                {
                    case DrawType.Line:
                        _shape = ShapeFactory.GetLine(_firstPointX, _firstPointY, 0, 0);
                        break;
                    case DrawType.Diamond:
                        _shape = ShapeFactory.GetDiamond(_firstPointX, _firstPointY, 0, 0);
                        break;
                    case DrawType.Ellipse:
                        _shape = ShapeFactory.GetEllipse(_firstPointX, _firstPointY, 0, 0);
                        break;
                }
                _isPressed = true;
            }
        }
        public IShape GetSelectedShape(Point point)
        {
            return _shapes.FindLast(shape => shape.IsInside(point));
        }

        /// <summary>   Pointer moved. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="pointX">   The x coordinate. </param>
        /// <param name="pointY">   The y coordinate. </param>

        public void MovePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _shape.X2 = pointX;
                _shape.Y2 = pointY;
                NotifyModelChanged();
            }
        }

        /// <summary>   Pointer released. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="pointX">   The x coordinate. </param>
        /// <param name="pointY">   The y coordinate. </param>

        public void ReleasePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                ReleaseShape(pointX, pointY);
                NotifyModelChanged();
            }
        }

        /// <summary>   Clears this object to its blank/initial state. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        /// <summary>   Draws the given graphics. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="graphics"> The graphics. </param>

        public void Draw(IGraphics graphics, bool isRedLine = false)
        {
            graphics.ClearAll();
            foreach (var shape in _shapes)
                shape.Draw(graphics, isRedLine);
            if (_isPressed)
            {
                _shape.Draw(graphics, isRedLine);
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
        public void ChangeToEllipse()
        {
            _drawType = DrawType.Ellipse;
        }

        private void ReleaseShape(double pointX, double pointY)
        {
            IShape shape;

            switch (_drawType)
            {
                case DrawType.Line:
                    shape = ShapeFactory.GetLine(_firstPointX, _firstPointY, pointX, pointY);
                    break;
                case DrawType.Diamond:
                    shape = ShapeFactory.GetDiamond(_firstPointX, _firstPointY, pointX, pointY);
                    break;
                case DrawType.Ellipse:
                    shape = ShapeFactory.GetEllipse(_firstPointX, _firstPointY, pointX, pointY);
                    break;
                default:
                    throw new KeyNotFoundException();
            }
            _shapes.Add(shape);
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
