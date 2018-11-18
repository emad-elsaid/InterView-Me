
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace Web.Infrastructure
{
    public class Userprincipal : IUserprincipal
    {
        private IHttpContextAccessor _httpContext;
        public Userprincipal(IHttpContextAccessor httpcontext) => _httpContext = httpcontext;

       
        public string Name()
        {
            return _httpContext.HttpContext.User.Identity.Name;
        }
        public long UserId()
        {
            return Convert.ToInt64( _httpContext.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

        }

    }
    
}
