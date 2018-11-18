using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Users;
namespace Services.Users
{
   public interface IUserService
   {
        void Create(User user);

        void Update(User user);

        void Delete(User user);

        IEnumerable<User> List();

        User GetById(long Id);

        User GetByEmail(string Email);

    }
}