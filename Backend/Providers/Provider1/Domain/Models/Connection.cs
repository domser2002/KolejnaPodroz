namespace ProviderDomain.Models;

public class Connection
{
    private static int _idCounter = 0;
    public int ID { get; } = ++_idCounter;
    public (int StationID, DateTime Time) StartStationTime { get; set; }
    public (int StationID, DateTime Time) EndStationTime { get; set; }
    public List<Seat>? Seats { get; set; }
    public Connection((int StationID, DateTime Time) startStationTime, (int StationID, DateTime Time) endStationTime, List<Seat>? seats = null)
    {
        StartStationTime = startStationTime;
        EndStationTime = endStationTime;
        Seats = seats;
    }
}
