using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Domain.Interviews;
using System.Linq;
using Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Services.Interviews
{
    public class ScheduleService : IScheduleService
    {
        private IRepository<Schedule> _repository;

        public ScheduleService(IRepository<Schedule> repository)
        {
            _repository = repository;
        }
        public void Create(Schedule Schedule)
        {
             _repository.Insert(Schedule);
        }

        public void Delete(Schedule Schedule)
        {
             _repository.Delete(Schedule);
        }

        
        public Schedule GetById(long Id)
        {
            return _repository.Get(Id);
        }

       
        public IEnumerable<Schedule> RequestList(long UserId)
        {
            return _repository.Table
                .Include(c=> c.Sender)
                .Include(c => c.Invinted)
                .Where(c => c.InvitedId == UserId)
                 .AsEnumerable();
        }

        public IEnumerable<Schedule> SentList(long UserId)
        {
            return _repository.Table
                .Include(c => c.Sender)
                 .Include(c => c.Invinted)
                .Where(c => c.SenderId == UserId)
                .AsEnumerable();
        }

        public void Update(Schedule Schedule)
        {
             _repository.Update(Schedule);
        }
    }
}