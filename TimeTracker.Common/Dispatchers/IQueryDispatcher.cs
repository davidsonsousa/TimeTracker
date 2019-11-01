using TimeTracker.Common.Requests;

namespace TimeTracker.Common.Dispatchers
{
    public interface IQueryDispatcher
    {
        TResult Dispatch<TResult>(IQuery<TResult> query);

        //Task<TResult> SendAsync<TResult>(IQueryAsync<TResult> query);
    }
}
