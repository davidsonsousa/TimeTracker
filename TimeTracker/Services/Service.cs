using TimeTracker.Data;

namespace TimeTracker.Services
{
    public sealed partial class Service
    {
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
