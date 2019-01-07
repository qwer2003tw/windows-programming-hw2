// file:	State\Impl\DrawingState.cs
//
// summary:	Implements the drawing state class

namespace DrawingModel.State.Implement
{
    /// <summary>   A drawing state. </summary>
    public class DrawingState : IState
    {
        /// <summary>   The context. </summary>
        private Model _context;
        /// <summary>   The graphics. </summary>
        private IGraphics _graphics;
        /// <summary>   Type of the draw. </summary>
        private DrawType _drawType;

        /// <summary>   True if is mouse down, false if not. </summary>
        private bool _isMouseDown;

        /// <summary>   Constructor. </summary>
        ///
        /// <param name="context">  The context. </param>
        /// <param name="graphics"> The graphics. </param>
        /// <param name="drawType"> Type of the draw. </param>

        public DrawingState(Model context, IGraphics graphics, DrawType drawType)
        {
            _context = context;
            _graphics = graphics;
            _drawType = drawType;
        }

    }
}
