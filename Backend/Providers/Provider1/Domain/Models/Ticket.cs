namespace ProviderDomain.Models;

public class Ticket
{
    private static int _idCounter = 0;
    public int ID { get; } = ++_idCounter;
    public int JourneyID { get; set; } = 0;
    public int StartConnectionID { get; set; } = 0;
    public int EndConnectionID { get; set; } = 0;
    public int? SeatNumber { get; set; }
    public decimal Price { get; set; } = 0;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Ticket() { }
    public Ticket(int connectionID, int startStationID, int endStationID, int? seatNumber, decimal price, string firstName, string lastName, string email, string phone)
    {
        JourneyID = connectionID;
        StartConnectionID = startStationID;
        EndConnectionID = endStationID;
        SeatNumber = seatNumber;
        Price = price;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
}
