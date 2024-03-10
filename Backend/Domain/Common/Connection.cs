using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Connection
    {
        public List<string> Stations = new();
        public List<DateTime> DepartureTimes = new();
        public List<DateTime> ArrivalTimes = new();
        public List<Provider> Providers = new();
    }
}
