namespace Domain;

public class Ticket
{
    private static int _idCounter = 0;
    public int ID { get; } = ++_idCounter;
    public int ConnectionID { get; set; }
    public int StartStationID { get; set; }
    public int EndStationID { get; set; }
    public int SeatID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Ticket(int connectionID, int startStationID, int endStationID, int seatID, string firstName, string lastName, string email, string phone)
    {
        ConnectionID = connectionID;
        SeatID = seatID;
        StartStationID = startStationID;
        EndStationID = endStationID;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
}
