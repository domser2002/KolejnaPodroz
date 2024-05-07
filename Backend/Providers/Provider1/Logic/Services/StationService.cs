using Domain.Models;

namespace Logic.Services;

public class StationService
{
    public static List<Station> Stations { get; set; } = new();
    public StationService()
    {
        GenerateFakeData();
    }
    public void GenerateFakeData()
    {
        var station1 = new Station("Station1", "Address1");
        var station2 = new Station("Station2", "Address2");
        var station3 = new Station("Station3", "Address3");
        var station4 = new Station("Station4", "Address4");
        var station5 = new Station("Station5", "Address5");
        var station6 = new Station("Station6", "Address6");
        Stations.Add(station1);
        Stations.Add(station2);
        Stations.Add(station3);
        Stations.Add(station4);
        Stations.Add(station5);
        Stations.Add(station6);
    }
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
