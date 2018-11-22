using Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Interviews
{
   public class Schedule : BaseEntity
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

        public bool   IsApporoved { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Invinted { get; set; }

    }
}
