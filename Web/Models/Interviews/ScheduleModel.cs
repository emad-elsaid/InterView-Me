using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Users;

namespace Web.Models.Interviews
{
    public class ScheduleModel : BaseModel
    {
        /// <summary>
        /// User who made interview request
        /// </summary>
        public long SenderId { get; set; }

        /// <summary>
        /// selected interviewer
        /// </summary>
        public long InvitedId { get; set; }

        public string Description { get; set; }

        public bool IsApporoved { get; set; }

        public virtual UserModel Sender { get; set; }

        public virtual UserModel Invited { get; set; }
    }
}
