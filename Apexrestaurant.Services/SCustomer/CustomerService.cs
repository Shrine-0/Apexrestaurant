using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apexrestaurant.Repository.Domain;
using Apexrestaurant.Repository.RCustomer;
namespace Apexrestaurant.Services.SCustomer
{
    public class CustomerService : GenericService<Customer> , ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository ) : base (customerRepository)
        {

        }
    }
}