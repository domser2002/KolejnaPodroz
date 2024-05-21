using ProviderDomain.Enums;
using ProviderDomain.Models;

namespace ProviderLogic.Services;

public class ConnectionService
{
    public static List<Connection> Connections { get; set; } = new();
    public ConnectionService()
    {
        GenerateFakeData();
    }
    public void GenerateFakeData()
    {
        var connection1 = new Connection((1, DateTime.Now), (2, DateTime.Now.AddHours(1)));
        var connection2 = new Connection((2, DateTime.Now.AddHours(1)), (3, DateTime.Now.AddHours(2)));
        var connection3 = new Connection((3, DateTime.Now.AddHours(2)), (4, DateTime.Now.AddHours(3)));
        var connection4 = new Connection((4, DateTime.Now.AddHours(3)), (5, DateTime.Now.AddHours(4)));
        var connection5 = new Connection((5, DateTime.Now.AddHours(4)), (6, DateTime.Now.AddHours(5)));

        var connection6 = new Connection((1, DateTime.Now.AddHours(-7)), (5, DateTime.Now.AddHours(-5)));
        var connection7 = new Connection((5, DateTime.Now.AddHours(-3)), (6, DateTime.Now.AddHours(-2)));

        var connection8 = new Connection((4, DateTime.Now.AddHours(-2)), (3, DateTime.Now.AddHours(-1)));
        var connection9 = new Connection((3, DateTime.Now.AddHours(-1)), (1, DateTime.Now.AddHours(-2)));

        Connections.Add(connection1);
        Connections.Add(connection2);
        Connections.Add(connection3);
        Connections.Add(connection4);
        Connections.Add(connection5);
        Connections.Add(connection6);
        Connections.Add(connection7);
        Connections.Add(connection8);
        Connections.Add(connection9);

        foreach(var connection in Connections)
        {
            var seats = new List<Seat>();
            for (int i = 0; i < 100; i++)
            {
                seats.Add(new Seat(i, i < 80 ? SeatType.Economy : SeatType.Business));
            }
            connection.Seats = seats;
        }
    }
    public Connection? GetConnectionByID(int ID)
    {
        return Connections.FirstOrDefault(c => c.ID == ID);
    }
    public void RemoveConnectionByID(int ID)
    {
        Connections.RemoveAll(c => c.ID == ID);
    }
    public bool EditConnection(Connection connection)
    {
        var connectionIndex = Connections.FindIndex(c => c.ID == connection.ID);
        if (connectionIndex == -1)
        {
            return false;
        }
        Connections[connectionIndex] = connection;
        return true;
    }
}
