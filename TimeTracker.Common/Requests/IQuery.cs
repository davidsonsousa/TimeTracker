using System.Threading.Tasks;

namespace TimeTracker.Common.Requests
{
    public interface IQueryAsync<TResult> : IQuery<Task<TResult>>
    {
    }

    public interface IQuery<TResult> : IQuery
    {
    }

    public interface IQuery
    {
    }
}
