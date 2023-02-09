using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.Services;
using Core.Concrete.Entities;
using Data;
using Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Maps;
using Services.Middlewares;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class IOCExtensions
    {
        //Services:
        public static void AddBaseServices(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Server=localhost;Database=PersonelData;Trusted_Connection=true;MultipleActiveResultSets=true;"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //AutoMaper için özel mapprofile yapıları oluşturulur ve burada dahil edilir.
            var map_config = new MapperConfiguration(p =>
            {
                p.AddProfile(new PersonProfiles());
                p.AddProfile(new DepartmentProfiles());
            });

            IMapper mapper = map_config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddDbContext<UserContext>(o => o.UseSqlServer(@"Server=localhost;Database=LayeredIdentityDB;Trusted_Connection=true;MultipleActiveResultSets=true;"));
            services
                .AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();
            

        }

        //Middlewares
        public static IApplicationBuilder AddExceptionCenter(this IApplicationBuilder app) => app.UseMiddleware<ExceptionCenter>();

        public static IApplicationBuilder AddRequestedInformationCheck(this IApplicationBuilder app) => app.UseMiddleware<RequestedInformationCheck>();

        public static IApplicationBuilder AddSecurityHeaderOptions(this IApplicationBuilder app) => app.UseMiddleware<SecurityHeadersOptions>();
    }
}
