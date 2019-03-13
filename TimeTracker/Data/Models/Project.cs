using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracker.Data.Models
{
    public class Project : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
