using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.User;

namespace Domain.Common;

public class CommonAccountInfo : Base
{
    [Required]
    [ForeignKey("userID")]
    public int UserID { get; set; }
    [Required]
    [MaxLength(50)]
    public string FirstName {  get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string LastName {  get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;
    [Required]
    public bool Verified { get; set; }
}
