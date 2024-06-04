using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Station : Base
    {
        public string Name { get; set; } = string.Empty;
        public List<StopDetails> StopDetails { get; set; } = [];
    }
}
