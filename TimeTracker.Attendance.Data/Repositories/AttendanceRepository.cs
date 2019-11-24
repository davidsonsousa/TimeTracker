using System;
using TimeTracker.Attendance.Core.Interfaces;

namespace TimeTracker.Attendance.Data.Repositories
{
    public class AttendanceRepository : IAttendanceRepository, IDisposable
    {
        private bool disposed = false;
        private readonly AttendanceContext _context;

        public AttendanceRepository(AttendanceContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
