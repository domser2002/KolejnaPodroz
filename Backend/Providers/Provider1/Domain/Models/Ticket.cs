namespace Domain.Models;

public class Ticket
{
    private static int _idCounter = 0;
    public int ID { get; } = ++_idCounter;
    public int JourneyID { get; set; } = 0;
    public int StartStationID { get; set; } = 0;
    public int EndStationID { get; set; } = 0;
    public int SeatID { get; set; } = 0;
    public decimal Price { get; set; } = 0;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Ticket() { }
    public Ticket(int connectionID, int startStationID, int endStationID, int seatID, decimal price, string firstName, string lastName, string email, string phone)
    {
        JourneyID = connectionID;
        SeatID = seatID;
        StartStationID = startStationID;
        EndStationID = endStationID;
        Price = price;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
}
