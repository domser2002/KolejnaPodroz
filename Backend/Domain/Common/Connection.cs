using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;

public class Connection : Base
{
    [Required]
    public int ConnectionID { get; set; }
    [NotMapped]
    public List<string> Stations { get; set; } = new();

    [NotMapped]
    public List<DateTime> DepartureTimes { get; set; } = new();
    [NotMapped]
    public List<DateTime> ArrivalTimes { get; set; } = new();
    [NotMapped]
    public List<Provider> Providers { get; set; } = new();
}
