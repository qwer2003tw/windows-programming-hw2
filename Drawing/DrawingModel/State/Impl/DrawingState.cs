namespace DrawingModel.State.Impl
{
    public class DrawingState : IState
    {
        private Model _context;
        private IGraphics _graphics;
        private DrawType _drawType;

        private bool _isMouseDown;
        public DrawingState(Model context, IGraphics graphics, DrawType drawType)
        {
            _context = context;
            _graphics = graphics;
            _drawType = drawType;
        }

    }
}
