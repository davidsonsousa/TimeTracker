using Newtonsoft.Json.Linq;
using System;

namespace TimeTracker.Data.EditModels
{
    public class BaseEditModel : IEditModel
    {
        public bool IsNew
        {
            get
            {
                return Id == 0 && VanityId == Guid.Empty;
            }
        }

        public int Id { get; set; }

        public Guid VanityId { get; set; }

        public override string ToString()
        {
            var jsonResult = new JObject(new JProperty("Id", Id), new JProperty("VanityId", VanityId));
            return jsonResult.ToString();
        }
    }
}
