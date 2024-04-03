using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Server
{
    public class Advertisment : Base
    {
        [Required]
        [MaxLength(50)]
        public string CompanyName = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Content = string.Empty;
    }
}
