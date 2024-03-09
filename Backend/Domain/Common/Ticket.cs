using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Ticket : Base
    {
        public int OwnerID;
        public string Source;
        public string Destination;
        public DateTime DepartureTime;
        public DateTime ArrivalTime;
    }
}
