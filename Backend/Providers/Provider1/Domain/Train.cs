namespace Domain;

public class Train
{
    private static int _idCounter = 0;
    public int ID { get; } = ++_idCounter;
    public string Name { get; set; }
    public List<Seat>? Seats { get; set; }
    public Train(string name, List<Seat>? seats = null)
    {
        Name = name;
        Seats = seats;
    }
}
