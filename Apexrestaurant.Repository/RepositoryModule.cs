using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;
using Apexrestaurant.Repository.RCustomer;


namespace Apexrestaurant.Repository
{
    public class RepositoryModule
    {
        public static void Register(IServiceCollection services, string connection, string migrationsAssembly)
        {
            services.AddDbContext<RestaurantContext>(options => options.UseMySQL(connection, builder => builder.MigrationsAssembly(migrationsAssembly)));
            services.AddTransient<ICustomerRepository, CustomerRepository>();//
        }
    }
}