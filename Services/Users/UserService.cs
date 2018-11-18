using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Domain.Users;
using System.Linq;
using Core.Data;

namespace Services.Users
{
    public class UserService : IUserService
    {
        private IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public void Create(User user)
        {
             _repository.Insert(user);
        }

        public void Delete(User user)
        {
             _repository.Delete(user);
        }

        public User GetByEmail(string Email)
        {
            return _repository.Table.FirstOrDefault(c => c.Email == Email);


        }

        public User GetById(long Id)
        {
            return _repository.Get(Id);
        }

        public IEnumerable<User> List()
        {
            return _repository.GetAll();
        }

        public void Update(User user)
        {
             _repository.Update(user);
        }
    }
}