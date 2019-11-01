using Microsoft.Extensions.DependencyInjection;
using System;
using TimeTracker.Common.Handlers;
using TimeTracker.Common.Requests;
using TimeTracker.Infrastructure;

namespace TimeTracker.Common.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly TimeTrackerContext _context;
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(TimeTrackerContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public TResult Dispatch<TResult>(IQuery<TResult> query)
        {
            return RunQuery(query);
        }

        private TResult RunQuery<TResult>(IQuery<TResult> query)
        {
            var queryHandler = _serviceProvider.GetService<IQueryHandler<TResult>>();

            if (queryHandler is null)
            {
                throw new ArgumentException($"Handler not registered for type {typeof(TResult).Name}");
            }

            return queryHandler.RunQuery(query);
        }
    }
}
