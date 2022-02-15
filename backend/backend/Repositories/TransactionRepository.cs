using backend.Domain;
using backend.DataAccess;

namespace backend.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public void AddTransaction(string transactionId, Transaction newTransaction)
        {
            SQLiteDataAccess.SaveTransaction(transactionId, newTransaction);
        }

        public MaxTransactionVolume GetMaxTransactionVolume()
        {
            return SQLiteDataAccess.GetMaxTransactionVolume();
        }

        public bool TryGetTransaction(string transactionId, out Transaction transaction)
        {
            return SQLiteDataAccess.TryGetTransaction(transactionId, out transaction);
        }
    }
}
