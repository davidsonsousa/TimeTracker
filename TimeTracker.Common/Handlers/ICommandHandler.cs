using TimeTracker.Common.Requests;

namespace TimeTracker.Common.Handlers
{
    public interface ICommandHandler<in TParameter> where TParameter : ICommand
    {
        void RunCommand(TParameter command);
    }
}
