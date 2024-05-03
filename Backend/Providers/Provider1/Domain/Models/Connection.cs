namespace Domain.Models;

public class Connection
{
    private static int _idCounter = 0;
    public int ID { get; } = ++_idCounter;
    public int TrainID { get; set; }
    public List<(int, DateTime)>? StationIDsTimes { get; set; }
    public List<Seat>? Seats { get; set; }
    public Connection(int trainID, List<(int, DateTime)>? stationIDsTimes = null, List<Seat>? seats = null)
    {
        TrainID = trainID;
        StationIDsTimes = stationIDsTimes;
        Seats = seats;
    }
}
