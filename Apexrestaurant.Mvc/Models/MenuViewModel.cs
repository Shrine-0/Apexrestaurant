using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apexrestaurant.Mvc.Models
{
    public class Menu
    {
        public int Id {get ; set;}
        public string Name {get; set;}
        public double price {get; set;}
        public bool avialabilty {get;set;}
    }
}