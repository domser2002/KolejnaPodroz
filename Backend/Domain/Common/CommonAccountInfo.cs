using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class CommonAccountInfo : Base
    {
        [Required]
        [ForeignKey("userID")]
        public int UserID;
        [Required]
        [MaxLength(50)]
        public string FirstName = string.Empty;
        [Required]
        [MaxLength(100)]
        public string LastName = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Email = string.Empty;
        public List<int> TicketIDs = new();
    }
}
