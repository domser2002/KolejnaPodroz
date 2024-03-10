using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Admin;

namespace Domain.Common
{
    public class Connection
    {
        public List<string> Stations = new();
        public List<DateTime> DepartureTimes = new();
        public DateTime ArrivalTime;
        public List<Provider> Providers = new();
    }
}
