using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Provider : Base
{
    [Required]
    [MaxLength(50)]
    [MaxLength(250)]
    [Required]
    [MaxLength(50)]
    // may need additional fields
}
}
