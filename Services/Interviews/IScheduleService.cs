using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Interviews;
namespace Services.Interviews
{
   public interface IScheduleService
   {
        void Create(Schedule Schedule);

        void Update(Schedule Schedule);

        void Delete(Schedule Schedule);

        IEnumerable<Schedule> SentList(long UserId);

        IEnumerable<Schedule> RequestList(long UserId);
        Schedule GetById(long Id);

      

    }
}