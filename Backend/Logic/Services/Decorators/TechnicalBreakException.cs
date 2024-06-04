using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Decorators
{
    public class TechnicalBreakException : Exception
    {
        public TechnicalBreakException() : base("Technical Break")
        {
        }

        public TechnicalBreakException(string message) : base(message)
        {
        }

        public TechnicalBreakException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
