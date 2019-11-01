using System.Linq;
using TimeTracker.Common.Requests;
using TimeTracker.Infrastructure;

namespace TimeTracker.Common.Handlers
{
    public abstract class CommandHandlerBase<TCommand, TAggregateRoot> : ICommandHandler<TCommand>
            where TCommand : ICommand
            where TAggregateRoot : class
    {
        private readonly TimeTrackerContext _context;

        protected CommandHandlerBase(TimeTrackerContext context)
        {
            _context = context;
        }

        protected IQueryable<TAggregateRoot> DbSet
        {
            get
            {
                return _context.Set<TAggregateRoot>();
            }
        }

        protected IQueryable<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        protected void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Execute the command against the database
        /// </summary>
        /// <param name="command"></param>
        protected abstract void RunCommandInternal(TCommand command);

        public void RunCommand(TCommand command)
        {
            RunCommandInternal(command);
        }
    }
}
