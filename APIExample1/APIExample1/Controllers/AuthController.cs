using APIExample1.Entities;
using APIExample1.Models;
using APIRESTOficinaVirtual.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExample1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public List<User> data;
        public AuthController()
        {
            data = DbContext.FillUsers();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = data.Where(u => u.DocumentId == loginVM.ID).FirstOrDefault();
            if(user == null)
            {
                return Conflict("Usuario o contraseña incorrecta");
            }
            if(user.Password != loginVM.Password)
            {
                return Conflict("Usuario o contraseña incorrecta");
            }
            var token = Cryptography.GenerateToken(loginVM.ID);
            return Ok(token);
        }
        [Authorize]
        [HttpGet("{documentId}")]
        public async Task<IActionResult> Logout(string documentId)
        {
            var user = data.Where(u => u.DocumentId == documentId).FirstOrDefault();
            if (user == null)
            {
                return Conflict("Usuario inexistente");
            }
            return Ok("Sesión cerrada");
        }
    }
}
