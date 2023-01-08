using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apexrestaurant.Repository.Domain;
using Apexrestaurant.Services.SCustomer;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Apexrestaurant.Api.Controllers
{
    [Route("api/customer")]
   // [ApiController]
    public class CustomerController : ControllerBase
    {
        //private readonly string _connectionString = "server=127.0.0.1;database=ApexRestaurantDB;Uid=root;password=forlorn123X";
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] Customer model)
        {
            _customerService.Insert(model);
            return Ok();
        }
        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] Customer model)
        {
            _customerService.Update(model);
            return Ok();
        }
        [HttpDelete]
        [Route("")]
        public IActionResult Delete([FromBody] Customer model)
        {
            _customerService.Delete(model);
            return Ok();
        }
        
        // [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     List<string> values =  new List<string>();
        //     using(var connection=new MySqlConnection(_connectionString))
        //     {
        //         connection.Open();
        //         using (var command  = new MySqlCommand("SELECT * FROM Customers",connection))
        //         using (var reader = command.ExecuteReader())
        //         {
        //             while(reader.Read())
        //             {
        //                 values.Add(reader["value"].ToString());
        //             }
        //         }

        //     }
        //     return values;
        // }
    }

}