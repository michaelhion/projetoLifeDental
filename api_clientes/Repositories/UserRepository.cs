using api_clientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_clientes.Repositories
{
    public static class UserRepository
    {
        public static Users Get(string username, string password)
        {
            var users = new List<Users>();
            users.Add(new Users { Id = 1, Username = "admin", Password = "admin", Role = "admin" });
            users.Add(new Users { Id = 2, Username = "cliente", Password = "cliente", Role = "cliente" });
            users.Add(new Users { Id = 2, Username = "vendedor", Password = "vendedor", Role = "vendedor" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
