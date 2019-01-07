// file:	Command\Impl\DrawCommand.cs
//
// summary:	Implements the draw command class

using DrawingModel.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Command.Implement
{
    /// <summary>   A draw command. </summary>
    public class DrawCommand : ICommand
    {
        /// <summary>   The model. </summary>
        private Model _model;
        /// <summary>   The shape. </summary>
        private IShape _shape;

        /// <summary>   Constructor. </summary>
        ///
        /// <param name="model">    The model. </param>
        /// <param name="shape">    The shape. </param>

        public DrawCommand(Model model, IShape shape)
        {
            _model = model;
            _shape = shape;
        }

        /// <summary>   Excutes this object. </summary>
        public void Execute()
        {
            _model.AddNewShape(_shape);
        }

        /// <summary>   Unexcutes this object. </summary>
        public void DoNotExecute()
        {
            _model.RemoveShape(_shape);
        }
    }
}
