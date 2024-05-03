namespace Domain;

public class Station
{
    private static int _idCounter = 0;
    public int ID { get; } = ++_idCounter;
    public string Name { get; set; }
    public string Address { get; set; }
    public Station(string name, string address)
    {
        Name = name;
        Address = address;
    }
}
