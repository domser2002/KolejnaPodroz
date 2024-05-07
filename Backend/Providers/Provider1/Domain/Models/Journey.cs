namespace Domain.Models;

public class Journey
{
    private static int _idCounter = 0;
    public int ID { get; } = ++_idCounter;
    public int TrainID { get; set; }
    public List<Connection>? Connections { get; set; }
    public List<Seat>? Seats { get; set; }
    public Journey(int trainID, List<Connection>? connections = null, List<Seat>? seats = null)
    {
        TrainID = trainID;
        Connections = connections;
        Seats = seats;
    }
}
