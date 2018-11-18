using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Data;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Interviews;
using Services.Users;
using Swashbuckle.AspNetCore.Swagger;
using Web.Infrastructure;
using Web.Validators.Shared;
using Web.Validators.Users;
namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #region FluentValidation Register
            services.AddMvc().AddFluentValidation(c =>
            {
                c.RegisterValidatorsFromAssemblyContaining<LoginInfoValidator>();

                c.RegisterValidatorsFromAssemblyContaining<UserValidator>();

            });
            #endregion
            
            #region JWT Config
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region IOC Config
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IDBContext), typeof(ApplicationContext));
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ITokenProvider, TokenProvider>();
            services.AddTransient<IUserprincipal, Userprincipal>();
            services.AddTransient<IEncryptionService, EncryptionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IScheduleService, ScheduleService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();
            #endregion

            #region AutoMapper Config
            var _mapperConfiguration = new MapperConfiguration(cfg =>
            {

            });
            AutoMapperConfiguration.Init(_mapperConfiguration);

            #endregion

            #region Swagger Config
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SwaggerAddRequiredHeaderParameter>();
                c.SwaggerDoc("v1", new Info { Description = "InterView Me", Title = "InterView web api documentation", Version = "v1" });
                c.DescribeAllEnumsAsStrings();
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseMvc();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Application web api documentation");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
