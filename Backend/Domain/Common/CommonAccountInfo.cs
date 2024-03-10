using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class CommonAccountInfo
    {
        public string FirstName = string.Empty;
        public string LastName = string.Empty;
        public string Email = string.Empty;
        public List<int> TicketIDs = new();
    }
}
