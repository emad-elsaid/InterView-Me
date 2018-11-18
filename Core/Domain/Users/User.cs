
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Users
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public byte[] Password { get; set; }

        public byte[] PasswordSalt { get; set; }

        public Guid GUID { get; set; }

        public int AccessFailedCount { get; set; }

        public string PhoneNumber { get; set; }

        public string Name { get; set; }
        
        public DateTime? LastLoginDateTime { get; set; }

        public long Gender { get; set; }

      
    }
}
