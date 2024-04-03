using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Provider : Base
    {
        [Required]
        [MaxLength(50)]
        public string Name = string.Empty;
        [MaxLength(250)]
        public string AdditionalInfo = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Email = string.Empty;
        // may need additional fields
    }
}
