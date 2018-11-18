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
        public long RequesterUserId { get; set; }

        /// <summary>
        /// selected interviewer
        /// </summary>
        public long InterviewerUserId { get; set; }

        public DateTime ?   ApprovalDate { get; set; }

        public virtual User Requester { get; set; }

        public virtual User Interviewer { get; set; }

    }
}
