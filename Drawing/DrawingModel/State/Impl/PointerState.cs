using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.State.Impl
{
    public class PointerState : IState
    {
        Model _model;
        public PointerState(Model model)
        {
            _model = model;
        }
    }
}
