using System.ComponentModel.DataAnnotations;

namespace Domain.Common;

public class Provider : Base
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(250)]
    public string AdditionalInfo { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;
    // may need additional fields
}
