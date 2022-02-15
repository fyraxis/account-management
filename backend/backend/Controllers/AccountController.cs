using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain;
using backend.Repositories;
using RestSharp;

namespace backend.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // GET /balance/5ba6e1b0-e3e7-483a-919a-a2fc17629a90 return the balance for the specified account
        [HttpGet("{account_id}")]
        [Route("balance/{account_id}")]
        public ActionResult<JsonObject> Balance(string account_id)
        {
            if(!_accountRepository.TryGetAccountBalance(account_id, out int balance))
            {
                return NotFound("Account not found.");
            }

            var result = new JsonObject();
            result.Add("balance", balance);
            return result;
        }
    }
}
