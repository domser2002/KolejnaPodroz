using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Complaint : Base
    {
        public int UserID;
        [Required]
        [MaxLength(50)]
        public string Title = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Content = string.Empty;
        [MaxLength(250)]
        public string Response = string.Empty;
        [Required]
        public bool IsResponded;
    }
}
