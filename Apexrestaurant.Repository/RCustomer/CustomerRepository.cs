using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apexrestaurant.Repository.Domain;

namespace Apexrestaurant.Repository.RCustomer
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(RestaurantContext dbContext){
            DbContext = dbContext;
        }
    }
}