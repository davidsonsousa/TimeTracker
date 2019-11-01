using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTracker.Infrastructure.Models
{
    public class BaseModel
    {
        [NotMapped]
        public bool IsNew
        {
            get
            {
                return Id == 0 && VanityId == Guid.Empty;
            }
        }

        [Key]
        public int Id { get; set; }
        public Guid VanityId { get; set; }
        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            var jsonResult = new JObject(
                                        new JProperty("Id", Id),
                                        new JProperty("VanityId", VanityId)
                                        );
            return jsonResult.ToString();
        }
    }
}
