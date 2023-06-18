using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceRegistiration
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")), ServiceLifetime.Transient);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IOrderRepository, EfEntityOrderRepository>();
            //services.AddScoped<IOrderService, OrderManager>();

            //services.AddScoped<IColorRepository, EfEntityColorRepository>();
            //services.AddScoped<IColorService, ColorManager>();

            //services.AddScoped<ICategoryRepository, EfEntityCategoryRepository>();
            //services.AddScoped<ICategoryService, CategoryManager>();

            //services.AddScoped<IProvinceRepository, EfEntityProvinceRepository>();
            //services.AddScoped<IProvinceService, ProvinceManager>();

            //services.AddScoped<IStoreRepository, EfEntityStoreRepository>();
            //services.AddScoped<IStoreService, StoreManager>();

            //services.AddScoped<IBookRepository, EfEntityBookRepository>();
            //services.AddScoped<IBookService, BookManager>();
        }
    }
}
