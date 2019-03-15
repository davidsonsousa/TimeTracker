using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Data.EditModels
{
    public interface IEditModel
    {
        bool IsNew { get; }

        int Id { get; set; }
        Guid VanityId { get; set; }
    }
}
