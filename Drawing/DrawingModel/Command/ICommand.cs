// file:	Command\ICommand.cs
//
// summary:	Declares the ICommand interface

namespace DrawingModel.Command
{
    /// <summary>   Interface for command. </summary>
    public interface ICommand
    {
        /// <summary>   Excutes this object. </summary>
        void Execute();
        /// <summary>   Unexcutes this object. </summary>
        void DoNotExecute();
    }
}
