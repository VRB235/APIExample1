using APIBank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using APIExample1.Connections.Services;

namespace APIExample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccesor;
        private string _docId;
        public AccountsController (IConfiguration configuration, IHttpContextAccessor httpContextAccesor)
        {
            _httpContextAccesor = httpContextAccesor;
            _configuration = configuration;
            var identity = httpContextAccesor.HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> user = identity.Claims.ToList();
            _docId = user[0].Value.ToString();
        }
        [HttpGet("get-accounts")]
        public async Task<IActionResult> GetAccounts()
        {
           List<Account> accounts = await APIBankService.GetAccounts(_configuration, _docId);

            if(accounts != null)
            {
                accounts = accounts.Where(a => a.AmountAvailable > 5000).ToList();
            }
            else
            {
                return NoContent();
            }

            return Ok(accounts);
        }
    }
}
