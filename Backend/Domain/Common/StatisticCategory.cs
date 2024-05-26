using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class StatisticCategory:Base
    {
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; } = string.Empty;
    }
}
