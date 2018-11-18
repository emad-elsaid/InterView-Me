using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Infrastructure
{
    public interface ITokenProvider
    {
        string GenerateTokenIdentity(string Id, string Name);
        string GenerateTokenIdentity(string Id, string Name, DateTime Expires);
    }
}
