using Domain.Models;

namespace Logic.Services;

public class StationService
{
    public List<Station> Stations { get; set; } = new();
    public void AddStation(Station station)
    {
        Stations.Add(station);
    }
    public Station? GetStationByID(int ID)
    {
        return Stations.FirstOrDefault(s => s.ID == ID);
    }
    public void RemoveStationByID(int ID)
    {
        Stations.RemoveAll(s => s.ID == ID);
    }
    public bool EditStation(Station station)
    {
        var stationIndex = Stations.FindIndex(s => s.ID == station.ID);
        if (stationIndex == -1)
        {
            return false;
        }
        Stations[stationIndex] = station;
        return true;
    }
}
