using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Complaint : Base
    {
        public int UserID;
        public string Title = string.Empty;
        public string Content = string.Empty;
        public string Response = string.Empty;
        public bool IsResponded;
    }
}
