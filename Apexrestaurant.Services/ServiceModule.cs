using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Apexrestaurant.Services.SCustomer;
namespace Apexrestaurant.Services
{
    public class ServiceModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ICustomerService,CustomerService>();
        }
    }
}