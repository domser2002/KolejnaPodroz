namespace Domain.Models;

public class Seat
{
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
