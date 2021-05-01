using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_clientes.Models
{
    public class NaturalPerson
    {

        public int id { get; set; }
        public int id_customers { get; set; }

        public long cpf { get; set; }

    }
}
