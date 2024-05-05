using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Logic.Services;

public class ConnectionService
{
    public static List<Connection> Connections { get; set; } = new();
    public bool AddConnection(Connection connection)
    {
        if(Connections.Any(c => c.ID == connection.ID))
        {
            return false;
        }
        Connections.Add(connection);
        return true;
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
    public List<Connection>? GetConnectionsByStartIDAndEndID(int startID, int endID)
    {
        var connections = new List<Connection>();
        foreach(var connection in Connections)
        {
            int startStationIndex = connection.StationIDsTimes?.FindIndex(s => s.ID == startID) ?? -1;
            int endStationIndex = connection.StationIDsTimes?.FindIndex(s => s.ID == endID) ?? -1;
            if(startStationIndex != -1 && startStationIndex < endStationIndex)
            {
                connections.Add(connection);
            }
        }
        return connections.Any() ? connections : null;
    }
}
