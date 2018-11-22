using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Users;
using Web.Infrastructure;
using Web.Models.Users;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        private readonly IEncryptionService _encryptionService;
        private readonly IUserprincipal _userprincipal;
        public UserController(IUserService UserService , IEncryptionService encryptionService, IUserprincipal userprincipal)
        {
            _UserService = UserService;
            _encryptionService = encryptionService;
            _userprincipal = userprincipal;
        }

        [AllowAnonymous]
        [HttpPost]
        [EnableCors("MyPolicy")]

        public IActionResult Register([FromBody] UserModel user)
        {
            byte[] passwordHash, passwordSalt;
            _encryptionService.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
            var entity = user.ToEntity();
            entity.PasswordSalt = passwordSalt;
            entity.Password = passwordHash;
            entity.AccessFailedCount = 0;
            entity.GUID = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            entity.EmailConfirmed = true;
             _UserService.Create(entity);
            return Ok(entity.ToModel());
        }

        [HttpGet]

        [EnableCors("MyPolicy")]

        public IEnumerable<UserModel> Get()
        {
            var List = _UserService.List().Where(c => c.Id != _userprincipal.UserId());
            return List.Select(u => u.ToModel());
        }
       
    }
}