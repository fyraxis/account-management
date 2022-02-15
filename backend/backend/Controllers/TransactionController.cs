using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        // GET /transaction/023d2024-24bc-42c9-ab24-689eef6ea0f9 returns the transaction
        [HttpGet("{transaction_id}")]
        [Route("transaction/{transaction_id}")]
        public ActionResult<Transaction> Transaction(string transaction_id)
        {
            if (!_transactionRepository.TryGetTransaction(transaction_id, out Transaction transaction))
            {
                return NotFound("Transaction not found.");
            }

            return transaction;
        }

        // GET /max_transaction_volume returns accounts with maximum transaction volumes
        [HttpGet]
        [Route("max_transaction_volume")]
        public ActionResult<MaxTransactionVolume> MaxTransactionVolume()
        {
            return _transactionRepository.GetMaxTransactionVolume();
        }

        // POST /amount creates a new transaction for the account and amount specified
        [HttpPost]
        [Route("amount")]
        public ActionResult Amount([Required, FromHeader(Name = "Transaction-Id")] string transaction_id, [FromBody] Transaction newTransaction)
        {
            if (!Guid.TryParse(transaction_id, out var _))
                return BadRequest();
            if (!Guid.TryParse(newTransaction.Account_Id, out var _))
                return BadRequest();
            _transactionRepository.AddTransaction(transaction_id, newTransaction);
            return Ok();
        }

    }
}
