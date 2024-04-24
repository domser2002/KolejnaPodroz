using System.ComponentModel.DataAnnotations;

namespace Domain.Common;

public class Provider : Base
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(250)]
    public string AdditionalInfo { get; set; }
    [Required]
    [MaxLength(50)]
    public string Email { get; set; }
    // may need additional fields
}
