using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain
{
    public class MaxTransactionVolume
    {
        public int MaxVolume { get; set; }

        public List<String> Accounts { get; set; }

        public MaxTransactionVolume()
        {

        }

        public MaxTransactionVolume(int maxVolume, List<string> accounts)
        {
            MaxVolume = maxVolume;
            Accounts = accounts;
        }
    }
}
