using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_clientes.Contexts;
using api_clientes.Models;
using api_clientes.Repositories;
using api_clientes.Services;
using Microsoft.AspNetCore.Authorization;

namespace api_clientes.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        //[AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authentication([FromBody]Users model)
        {
            // Recupera o usuário
            var user = UserRepository.Get(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GegerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}
