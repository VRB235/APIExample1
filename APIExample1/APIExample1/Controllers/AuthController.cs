using APIExample1.Connections.Services;
using APIExample1.Entities;
using APIExample1.Models;
using APIRESTOficinaVirtual.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APIExample1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public List<User> data;
        public IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccesor;
        private string _docId;
        private string _phone;
        public AuthController(IConfiguration configuration, IHttpContextAccessor httpContextAccesor)
        {
            _configuration = configuration;
            data = DbContext.FillUsers();
            var identity = httpContextAccesor.HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> user = identity.Claims.ToList();
            _docId = user.Count > 0 ? user[0].Value.ToString() : null;
            _phone = user.Count > 0 ? user[1].Value.ToString() : null;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = data.Where(u => u.Phone == loginVM.ID).FirstOrDefault();
            if(user == null)
            {
                return Conflict("Teléfono o contraseña incorrecta");
            }
            if(user.Password != loginVM.Password)
            {
                return Conflict("Teléfono o contraseña incorrecta");
            }

            var persons = await APIBankService.GetPersons(_configuration);

            var person = persons.Where(p => p.PhoneNumber == loginVM.ID).FirstOrDefault();

            var token = Cryptography.GenerateToken(person.DocumentID,loginVM.ID);
            return Ok(token);
        }
        [Authorize]
        [HttpGet("{documentId}")]
        public async Task<IActionResult> Logout()
        {
            var user = data.Where(u => u.Phone == _phone).FirstOrDefault();
            if (user == null)
            {
                return Conflict("Usuario inexistente");
            }
            return Ok("Sesión cerrada");
        }
    }
}
