using Domain.Models;

namespace Logic.Services;

public class ConnectionService
{
    public static List<Connection> Connections { get; set; } = new();
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
