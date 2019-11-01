using Microsoft.Extensions.DependencyInjection;
using System;
using TimeTracker.Common.Handlers;
using TimeTracker.Common.Requests;
using TimeTracker.Infrastructure;

namespace TimeTracker.Common.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly TimeTrackerContext _context;
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(TimeTrackerContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public void Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
            RunCommand(command);
        }

        private void RunCommand<TParameter>(TParameter command) where TParameter : ICommand
        {
            var commandHandler = _serviceProvider.GetService<ICommandHandler<TParameter>>();

            if (commandHandler == null)
            {
                throw new ArgumentException($"Handler no registered for type {typeof(TParameter).Name}");
            }

            commandHandler.RunCommand(command);
        }
    }
}
