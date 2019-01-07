// file:	Command\CommandManager.cs
//
// summary:	Implements the command manager class

using System.Collections.Generic;

namespace DrawingModel.Command
{
    /// <summary>   Manager for commands. </summary>
    public class CommandManager
    {
        /// <summary>   Stack of pasts. </summary>
        private Stack<ICommand> _pastStack;
        /// <summary>   Stack of futures. </summary>
        private Stack<ICommand> _futureStack;

        /// <summary>   Default constructor. </summary>
        public CommandManager()
        {
            _pastStack = new Stack<ICommand>();
            _futureStack = new Stack<ICommand>();
        }

        /// <summary>   Gets a value indicating whether the have next step. </summary>
        ///
        /// <value> True if have next step, false if not. </value>

        public bool HaveNextStep
        {
            get
            {
                return _futureStack.Count > 0;
            }
        }

        /// <summary>   Gets a value indicating whether the have previous step. </summary>
        ///
        /// <value> True if have previous step, false if not. </value>

        public bool HavePreviousStep
        {
            get
            {
                return _pastStack.Count > 0;
            }
        }

        /// <summary>   Executes the new command operation. </summary>
        ///
        /// <param name="command">  The command. </param>

        public void ExecuteNewCommand(ICommand command)
        {
            command.Execute();
            _futureStack.Clear();
            _pastStack.Push(command);
        }

        /// <summary>   Executes the forward step operation. </summary>
        public void ExecuteForwardStep()
        {
            ICommand command = _futureStack.Pop();
            command.Execute();
            _pastStack.Push(command);
        }

        /// <summary>   Executes the backward step operation. </summary>
        public void ExecuteBackwardStep()
        {
            ICommand command = _pastStack.Pop();
            command.DoNotExecute();
            _futureStack.Push(command);
        }
    }
}
