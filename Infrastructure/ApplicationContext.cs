using Core.Domain;
using Infrastructure.DomianMapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Core.Data;
namespace Infrastructure
{
   public class ApplicationContext : DbContext,IDBContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        /// <summary>
        /// Create new from DBSET Base function with conistrain BaseEntity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Using Reflection to Create Models from Model Configurations Classes 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                           (type.BaseType?.IsGenericType ?? false)
                               && (type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityTypeConfiguration<>)
                                   ));
            typeConfigurations.ToList().ForEach(c => { ((IMapConfiguration)Activator.CreateInstance(c)).ApplyConfiguration(modelBuilder); });
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
