using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class BaseModel
    {
        public long id { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime? LastUpdatedDate { get; set; }
    }
}
