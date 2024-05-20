using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;

public class Connection : Base
{

    public List<string> Stations { get; set; } = new();

    public List<DateTime> DepartureTimes { get; set; } = new();

    public List<DateTime> ArrivalTimes { get; set; } = new();

    public List<Provider> Providers { get; set; } = new();
}
