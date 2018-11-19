using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interviews;
using Web.Infrastructure;
using Web.Models.Interviews;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly IUserprincipal _userprincipal;
        public ScheduleController(IScheduleService scheduleService, IUserprincipal userprincipal )
        {
            _scheduleService = scheduleService;
            _userprincipal = userprincipal;
        }
        
        [HttpGet("RequestList")]
        [EnableCors("MyPolicy")]
        public IEnumerable<ScheduleModel> RequestList()
        {
            var List = _scheduleService.RequestList(_userprincipal.UserId());
            return List.Select(l => l.ToModel());
        }

        [HttpGet("SentList")]
        [EnableCors("MyPolicy")]
        public IEnumerable<ScheduleModel> SentList()
        {
            var List = _scheduleService.SentList(_userprincipal.UserId());
            return List.Select(l => l.ToModel());
        }

        // GET: api/Schedule/5
        [HttpGet("{id}", Name = "Get")]
        [EnableCors("MyPolicy")]
        public ScheduleModel Get(int id)
        {
            var entity = _scheduleService.GetById(id);
            return entity.ToModel();
        }

        // POST: api/Schedule
        [HttpPost]
        [EnableCors("MyPolicy")]
        public void Post([FromBody] ScheduleModel model)
        {
            model.RequesterUserId = _userprincipal.UserId();
            var entity = model.ToEntity();
            entity.CreatedDate = DateTime.Now;            
            _scheduleService.Create(entity);
        }

      

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [EnableCors("MyPolicy")]
        public void Delete(int id)
        {
            var entity = _scheduleService.GetById(id);           
            _scheduleService.Delete(entity);
        }
    }
}
