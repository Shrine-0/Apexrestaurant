using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Apexrestaurant.Mvc.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneRes { get; set; }
        public string PhoneMob { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}