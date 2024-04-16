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
        public string Name {  get; set; }
        [MaxLength(250)]
        public string AdditionalInfo {  get; set; }
        [Required]
        [MaxLength(50)]
        public string Email {  get; set; }
        // may need additional fields
    }
}
