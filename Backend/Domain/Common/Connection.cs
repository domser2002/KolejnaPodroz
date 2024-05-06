namespace Domain.Common;

public class Connection
{
    public int ID { get; set; }
    public List<string> Stations { get; set; } = new();
    public List<DateTime> DepartureTimes { get; set; } = new();
    public List<DateTime> ArrivalTimes { get; set; } = new();
    public List<Provider> Providers { get; set; } = new();
}
