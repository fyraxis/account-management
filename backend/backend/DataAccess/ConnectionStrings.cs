using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess
{
    public class ConnectionStrings
    {
        private ConnectionStrings()
        {

        }

        public static ConnectionStrings Instance { get; protected set; } = new ConnectionStrings();

        public string Default { get; set; }
    }
}
