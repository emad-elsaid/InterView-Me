using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
   public class BaseEntity
    {
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public  DateTime ? LastUpdatedDate { get; set; }
    }
}
