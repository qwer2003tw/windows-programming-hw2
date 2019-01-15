// file:	Model.cs
//
// summary:	Implements the model class

using DrawingModel.Command;
using DrawingModel.Command.Implement;
using DrawingModel.Shape;
using DrawingModel.State.Implement;
using System.Collections.Generic;

namespace DrawingModel
{
    /// <summary>   A model. </summary>

    public class Model
    {
        /// <summary>   Values that represent draw types. </summary>

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
        /// <summary>   Manager for command. </summary>
        private CommandManager _commandManager;

        /// <summary>   &lt;summary&gt;   The lines. </summary>

        readonly List<IShape> _shapes = new List<IShape>();
        /// <summary>   The shape. </summary>
        IShape _shape;
        /// <summary>   The state. </summary>
        IState _state;
        /// <summary>   The graphics. </summary>
        IGraphics _graphics;

        /// <summary>   Type of the draw. </summary>
        DrawType _drawType = DrawType.None;

        /// <summary>   Constructor. </summary>
        ///
        /// <param name="graphics"> The graphics. </param>

        public Model(IGraphics graphics)
        {
            _commandManager = new CommandManager();
            _graphics = graphics;
        }

        /// <summary>   Gets a value indicating whether the have next step. </summary>
        ///
        /// <value> True if have next step, false if not. </value>

        public bool HaveNextStep
        {
            get
            {
                return _commandManager.HaveNextStep;
            }
        }

        /// <summary>   Gets a value indicating whether the have previous step. </summary>
        ///
        /// <value> True if have previous step, false if not. </value>

        public bool HavePreviousStep
        {
            get
            {
                return _commandManager.HavePreviousStep;
            }
        }

        /// <summary>   Change to drawing state. </summary>
        ///
        /// <param name="drawType"> Type of the draw. </param>

        public void ChangeToDrawingState(DrawType drawType)
        {
            IState newState = new DrawingState(this, _graphics, drawType);
            _state = newState;
        }

        /// <summary>   Change to pointer state. </summary>
        public void ChangeToPointerState()
        {
            IState newState = new PointerState(this);
            _state = newState;
        }

        /// <summary>   Pointer pressed. </summary>
        ///
        /// <param name="pointX">   The x coordinate. </param>
        /// <param name="pointY">   The y coordinate. </param>

        public void PressPointer(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                _firstPointX = pointX;
                _firstPointY = pointY;
                if (_drawType == DrawType.Line)
                    _shape = ShapeFactory.GetLine(_firstPointX, _firstPointY, 0, 0);
                else if (_drawType == DrawType.Diamond)
                    _shape = ShapeFactory.GetDiamond(_firstPointX, _firstPointY, 0, 0);
                else if (_drawType == DrawType.Ellipse)
                    _shape = ShapeFactory.GetEllipse(_firstPointX, _firstPointY, 0, 0);
                _isPressed = true;
            }
        }

        /// <summary>   Gets selected shape. </summary>
        ///
        /// <param name="point">    The point. </param>
        ///
        /// <returns>   The selected shape. </returns>

        public IShape GetSelectedShape(Point point)
        {
            return _shapes.FindLast(shape => shape.IsInside(point));
        }

        /// <summary>   Pointer moved. </summary>
        ///
        /// <param name="pointX">   The x coordinate. </param>
        /// <param name="pointY">   The y coordinate. </param>

        public void MovePointer(double pointX, double pointY)
        {
            if (_isPressed && _shape != null)
            {
                _shape.X2 = pointX;
                _shape.Y2 = pointY;
                NotifyModelChanged();
            }
        }

        /// <summary>   Pointer released. </summary>
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

        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        /// <summary>   Draws the given graphics. </summary>
        ///
        /// <param name="graphics">     The graphics. </param>
        /// <param name="isRedLine">    (Optional) True if is red line, false if not. </param>

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

        /// <summary>   Draw list. </summary>
        public void DrawList()
        {
            _graphics.ClearAll();
            foreach (IShape shape in _shapes)
            {
                shape.Draw(_graphics);
            }
        }

        /// <summary>   Change to line. </summary>

        public void ChangeToLine()
        {
            _drawType = DrawType.Line;
        }

        /// <summary>   Change to diamond. </summary>

        public void ChangeToDiamond()
        {
            _drawType = DrawType.Diamond;
        }

        /// <summary>   Change to ellipse. </summary>
        public void ChangeToEllipse()
        {
            _drawType = DrawType.Ellipse;
        }

        /// <summary>   Adds a new shape. </summary>
        ///
        /// <param name="shape">    The shape. </param>

        public void AddNewShape(IShape shape)
        {
            _shapes.Add(shape);
            //DrawList();
        }

        /// <summary>   Removes the shape described by shape. </summary>
        ///
        /// <param name="shape">    The shape. </param>

        public void RemoveShape(IShape shape)
        {
            _shapes.Remove(shape);
            //DrawList();
        }

        /// <summary>   Go forward. </summary>
        public void GoForward()
        {
            _commandManager.ExecuteForwardStep();
        }

        /// <summary>   Go backward. </summary>
        public void GoBackward()
        {
            _commandManager.ExecuteBackwardStep();
        }

        /// <summary>   Releases the shape. </summary>
        ///
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        ///
        /// <param name="pointX">   The x coordinate. </param>
        /// <param name="pointY">   The y coordinate. </param>

        private void ReleaseShape(double pointX, double pointY)
        {
            IShape shape;
            if (_drawType == DrawType.Line)
                shape = ShapeFactory.GetLine(_firstPointX, _firstPointY, pointX, pointY);
            else if (_drawType == DrawType.Diamond)
                shape = ShapeFactory.GetDiamond(_firstPointX, _firstPointY, pointX, pointY);
            else if (_drawType == DrawType.Ellipse)
                shape = ShapeFactory.GetEllipse(_firstPointX, _firstPointY, pointX, pointY);
            else
                return;
            ICommand newCommand = new DrawCommand(this, shape);
            _commandManager.ExecuteNewCommand(newCommand);
        }

        /// <summary>   Notifies the model changed. </summary>

        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
