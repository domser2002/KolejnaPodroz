using Domain.Common;
using System.ComponentModel.DataAnnotations;

public class Advertisment : Base
{
    [Required]
    [MaxLength(50)]
    [Required]
    [MaxLength(250)]
}
