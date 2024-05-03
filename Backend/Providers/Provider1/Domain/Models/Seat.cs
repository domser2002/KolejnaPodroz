namespace Domain.Models;

public class Seat
{
    private static int _idCounter = 0;
    public int ID { get; } = ++_idCounter;
    public int Number { get; set; }
    public SeatType SeatType { get; set; }
    public bool Taken { get; set; }
    public Seat(int number, SeatType seatType, bool taken = false)
    {
        Number = number;
        SeatType = seatType;
        Taken = taken;
    }
}
