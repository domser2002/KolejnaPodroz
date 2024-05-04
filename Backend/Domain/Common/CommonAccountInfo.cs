using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CommonAccountInfo : Base
{
    [Required]
    [ForeignKey("userID")]
    [Required]
    [MaxLength(50)]
    [Required]
    [MaxLength(100)]
    [Required]
    [MaxLength(50)]
}
