using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
public class Complaint : Base
{
        public int UserID;
    [Required]
    public int ComplainantID { get; set; }
    [Required]
    [MaxLength(50)]
    [Required]
    [MaxLength(250)]
    [MaxLength(250)]
    [Required]
}
