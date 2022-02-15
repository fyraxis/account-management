using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public interface IAccountRepository
    {
        bool TryGetAccountBalance(string accountId, out int balance);    
    }
}
