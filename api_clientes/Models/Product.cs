using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_clientes.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
        public int id_categories { get; set; }
    }
}
