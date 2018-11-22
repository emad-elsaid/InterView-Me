﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Core.Domain.Interviews.Schedule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<long>("InvitedId");

                    b.Property<bool>("IsApporoved");

                    b.Property<DateTime?>("LastUpdatedDate");

                    b.Property<long>("SenderId");

                    b.HasKey("Id");

                    b.HasIndex("InvitedId");

                    b.HasIndex("SenderId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("Core.Domain.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<Guid>("GUID");

                    b.Property<short>("Gender");

                    b.Property<DateTime?>("LastLoginDateTime");

                    b.Property<DateTime?>("LastUpdatedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<byte[]>("Password");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Domain.Interviews.Schedule", b =>
                {
                    b.HasOne("Core.Domain.Users.User", "Invinted")
                        .WithMany()
                        .HasForeignKey("InvitedId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Domain.Users.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
