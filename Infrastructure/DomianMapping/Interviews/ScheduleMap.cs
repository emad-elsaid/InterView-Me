
using Core.Domain.Interviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DomianMapping.Interviews
{
    public class ScheduleMap : BaseEntityTypeConfiguration<Schedule>
    {
        public override void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Requester).WithMany()
               .HasForeignKey(c => c.RequesterUserId);

            builder.HasOne(c => c.Interviewer).WithMany()
              .HasForeignKey(c => c.InterviewerUserId);
            base.Configure(builder);
        }
    }
}
