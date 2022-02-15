using backend.DataAccess;

namespace backend.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public bool TryGetAccountBalance(string accountId, out int balance)
        {
            return SQLiteDataAccess.TryGetAccountBalance(accountId, out balance);
        }
    }
}
