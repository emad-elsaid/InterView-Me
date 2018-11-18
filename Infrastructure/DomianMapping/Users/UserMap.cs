
using Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DomianMapping.Users
{
    public class ScheduleMap : BaseEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.Name).HasMaxLength(200);
           
            base.Configure(builder);
        }
    }
}
