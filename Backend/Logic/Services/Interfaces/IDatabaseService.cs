using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Interfaces
{
    public interface IDatabaseService
    {
        public List<Object[]> ExecuteSQL(string sql);
        public void Backup();
    }
}
