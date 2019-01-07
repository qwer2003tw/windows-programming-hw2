// file:	State\Impl\PointerState.cs
//
// summary:	Implements the pointer state class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.State.Implement
{
    /// <summary>   A pointer state. </summary>
    public class PointerState : IState
    {
        /// <summary>   The model. </summary>
        Model _model;

        /// <summary>   Constructor. </summary>
        ///
        /// <param name="model">    The model. </param>

        public PointerState(Model model)
        {
            _model = model;
        }
    }
}
