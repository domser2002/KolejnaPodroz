namespace Domain;

public class Connection
{
    private static int _idCounter = 0;
    public int ID { get; } = ++_idCounter;
    public int TrainID { get; set; }
    public List<(int, DateTime)>? StationIDsTimes { get; set; }
    public Connection(int trainID, List<(int, DateTime)>? stationIDsTimes = null)
    {
        TrainID = trainID;
        StationIDsTimes = stationIDsTimes;
    }
}
