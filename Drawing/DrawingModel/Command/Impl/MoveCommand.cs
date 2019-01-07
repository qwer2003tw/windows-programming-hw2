// file:	Command\Impl\MoveCommand.cs
//
// summary:	Implements the move command class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Command.Implement
{
    /// <summary>   A move command. </summary>
    public class MoveCommand : ICommand
    {
        /// <summary>   Excutes this object. </summary>
        public void Execute()
        {
            throw new NotImplementedException();
        }

        /// <summary>   Unexcutes this object. </summary>
        public void DoNotExecute()
        {
            throw new NotImplementedException();
        }
    }
}
