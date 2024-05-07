using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Admin;

public class Admin : Base
{
    [Required]
    public bool Accepted { get; set; }
}
