using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Transport.Infrastructure.Data;
using System;
using System.Net;


namespace Transport.WebAppMvc
{
    public static class ConfigureServices
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration config)
        {

            //DBContext 
            var sConnectionString = config.GetConnectionString("SqlConnectionString");
            services.AddDbContext<TransportDbContext>(option => { option.UseSqlServer(sConnectionString); });

            //Repository
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();

            //services.AddTransient<ExceptionMiddleware>();


            ////AutoMapper
            //services.AddAutoMapper(typeof(MappingConfig));

        }


    }
}
