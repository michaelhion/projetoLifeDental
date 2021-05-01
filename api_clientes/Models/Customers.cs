using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_clientes.Models
{
    public class Customers
    {
        //[Key()]
        public  int id { get; set; }
        public string name { get; set; }
        public string street { get; set; }
        public string city{ get; set; }

        public string state { get; set; }
        public decimal credit_limit { get; set; }
    }
}
