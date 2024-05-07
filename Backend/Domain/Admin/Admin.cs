using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Admin;

public class Admin : Base
{
    [Required]
    public bool Accepted { get; set; } = false;
    [Required] 
    public bool Verified { get; set; }  = false;
    public string FirebaseID { get; set; } = string.Empty;
}
