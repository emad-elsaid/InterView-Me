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
        public long RequesterUserId { get; set; }

        /// <summary>
        /// selected interviewer
        /// </summary>
        public long InterviewerUserId { get; set; }

        public string RequesterEmail { get; set; }

        public string InterviewerEmail { get; set; }

        public string RequesterName { get; set; }

        public bool IsApporoved { get; set; }
    }
}
