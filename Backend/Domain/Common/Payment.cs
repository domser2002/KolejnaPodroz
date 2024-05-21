using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    // temporary class used for mocking payments
    public class Payment
    {
        public decimal Value { get; set; }
        public string Code { get; set; } = string.Empty;
    }
}
