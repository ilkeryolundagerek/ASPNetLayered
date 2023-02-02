using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.Services;
using Data;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Maps;
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
        public static void AddBaseServices(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Server=localhost;Database=LayeredDB;User Id=sa;Password=1;MultipleActiveResultSets=true;"));
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
    }
}
