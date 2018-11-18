using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        private readonly IEncryptionService _encryptionService;

        public UserController(IUserService UserService , IEncryptionService encryptionService)
        {
            _UserService = UserService;
            _encryptionService = encryptionService;
        }

        [AllowAnonymous]
        [HttpPost]
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

       
    }
}