using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.User
{
    public class Ticket : Base
    {
        public int OwnerID;
        public Connection Connection = new();
    }
}
