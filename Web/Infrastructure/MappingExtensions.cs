using AutoMapper;
using Core.Domain;
using Core.Domain.Interviews;
using Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.Interviews;
using Web.Models.Users;

namespace Web.Infrastructure
{
    public static class MappingExtensions
    {

        private static TDestination Map<TDestination>(this object source)
        {

            return AutoMapperConfiguration.Mapper.Map<TDestination>(source);
        }

        private static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>()
                .IgnoreAllNonExisting();
            });
            var mapper = config.CreateMapper();
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

      
        public static TModel ToModel<TModel>(this BaseEntity entity) where TModel : BaseModel
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return entity.Map<TModel>();
        }

        public static TModel ToModel<TEntity, TModel>(this TEntity entity, TModel model)
            where TEntity : BaseEntity where TModel : BaseModel
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return entity.MapTo(model);
        }

    
        public static TEntity ToEntity<TEntity>(this BaseModel model) where TEntity : BaseEntity
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return model.Map<TEntity>();
        }


        public static TEntity ToEntity<TEntity, TModel>(this TModel model, TEntity entity)
            where TEntity : BaseEntity where TModel : BaseModel
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return model.MapTo(entity);
        }

        #region Custom Mapper
        public static User ToEntity(this UserModel model)

        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, User>()
                .ForMember(c => c.Password, g => g.Ignore())
                .IgnoreAllNonExisting();
            });
            var mapper = config.CreateMapper();
            var entity = mapper.Map<UserModel, User>(model);
            return entity;
        }

        public static UserModel ToModel(this User entity)

        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, User>()
                .ForMember(c => c.Password, g => g.Ignore())
                .IgnoreAllNonExisting();
            });
            var mapper = config.CreateMapper();
            var model = mapper.Map<User, UserModel>(entity);
            return model;
        }


        public static Schedule ToEntity(this ScheduleModel model)

        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ScheduleModel, Schedule>()

                .IgnoreAllNonExisting();
            });
            var mapper = config.CreateMapper();
            var entity = mapper.Map<ScheduleModel, Schedule>(model);
            return entity;
        }

        public static ScheduleModel ToModel(this Schedule entity)

        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ScheduleModel, Schedule>()
                .IgnoreAllNonExisting();
            });
            var mapper = config.CreateMapper();
            var model = mapper.Map<Schedule, ScheduleModel>(entity);
            model.Invinted = entity.Invinted.ToModel();
            model.Sender = entity.Sender.ToModel();
         
            return model;
        }

        #endregion

        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>
           (this IMappingExpression<TSource, TDestination> expression)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance;
            var sourceType = typeof(TSource);
            var destinationProperties = typeof(TDestination).GetProperties(flags);

            foreach (var property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name, flags) == null)
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return expression;
        }
    }
}
