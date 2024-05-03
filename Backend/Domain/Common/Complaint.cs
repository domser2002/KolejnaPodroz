using System.ComponentModel.DataAnnotations;

namespace Domain.Common;

public class Complaint : Base
{
    [Required]
    public int ComplainantID { get; set; }
    [Required]
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;  
    [Required]
    [MaxLength(250)]
    public string Content {  get; set; } = string.Empty;
    [MaxLength(250)]
    public string Response { get; set; } = string.Empty;
    [Required]
    public bool IsResponded { get; set; }
}
