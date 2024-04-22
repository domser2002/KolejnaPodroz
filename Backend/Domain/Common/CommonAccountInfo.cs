using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;

public class CommonAccountInfo : Base
{
    [Required]
    [ForeignKey("userID")]
    public int UserID { get; set; }
    [Required]
    [MaxLength(50)]
    public string FirstName {  get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName {  get; set; }
    [Required]
    [MaxLength(50)]
    public string Email {  get; set; }
    public List<int> TicketIDs { get; set; } = new();
}
