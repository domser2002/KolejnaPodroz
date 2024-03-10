using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server
{
    public class AdminSession
    {
        public string Token = string.Empty;
        public int AdminID;
        public DateTime LoginTime;
    }
}
