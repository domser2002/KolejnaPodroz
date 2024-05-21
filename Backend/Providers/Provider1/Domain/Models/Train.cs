using ProviderDomain.Enums;

namespace ProviderDomain.Models;

public class Train
{
    private static int _idCounter = 0;
    public int ID { get; } = ++_idCounter;
    public string Name { get; set; }
    public TrainType TrainType { get; set; }
    public List<Seat>? Seats { get; set; }
    public Train(string name, TrainType trainType, List<Seat>? seats = null)
    {
        Name = name;
        TrainType = trainType;
        Seats = seats;
    }
}
