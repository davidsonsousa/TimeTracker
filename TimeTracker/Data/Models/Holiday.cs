using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracker.Data.Models
{
    public class Holiday : BaseModel
    {
        #region Relationship

        public virtual Calendar Calendar { get; set; }

        #endregion

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
