using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;

public class Connection : Base
{

    public List<StopDetails> Stops { get; set; } = [];
    [Required]
    public int ProviderID { get; set; }
}
