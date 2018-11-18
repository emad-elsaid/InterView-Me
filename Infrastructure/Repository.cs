using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;
namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDBContext _applicationContext;
        private DbSet<T> entities;
        public Repository(IDBContext applicationContext)
        {
            _applicationContext = applicationContext;
            entities = _applicationContext.Set<T>();
        }
        public IQueryable<T> Table { get { return entities.AsNoTracking(); } }

        public void  Delete(T entity)
        {
            if (entity == null)
                throw new NullReferenceException("entity");
            entities.Remove(entity);
            _applicationContext.SaveChanges();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(long id)
        {
            return entities.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new NullReferenceException("entity");
              entities.Add(entity);
            _applicationContext.SaveChanges();
        }

        public Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public  void SaveChanges()
        {
            _applicationContext.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new NullReferenceException("entity");

            _applicationContext.SaveChanges();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
