using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DomianMapping
{
    public interface IMapConfiguration
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
