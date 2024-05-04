using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Ranking : Base
    {
        [Required]
        [MaxLength(50)]
        public string category = "";
        public List<(int UserID, int num)> ranking { get; set; } = new();
    }
}
