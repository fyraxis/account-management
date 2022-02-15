using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain;

namespace backend.Repositories
{
    public interface ITransactionRepository
    {
        void AddTransaction(string transactionId, Transaction newTransaction);

        MaxTransactionVolume GetMaxTransactionVolume();

        bool TryGetTransaction(string transactionId, out Transaction transaction);
    }
}
