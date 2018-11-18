using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Infrastructure
{
   public interface IUserprincipal
    {
        long UserId();
        string Name();

       

    }
}
