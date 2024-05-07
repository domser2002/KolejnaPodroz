using Domain.Models;

namespace Logic.Services;

public class JourneyService
{
    public static List<Journey> Journeys { get; set; } = new();
    public bool AddJourney(Journey journey)
    {
        if(Journeys.Any(c => c.ID == journey.ID))
        {
            return false;
        }
        Journeys.Add(journey);
        return true;
    }
    public Journey? GetJourneyByID(int ID)
    {
        return Journeys.FirstOrDefault(c => c.ID == ID);
    }
    public void RemoveJourneyByID(int ID)
    {
        Journeys.RemoveAll(c => c.ID == ID);
    }
    public bool EditJourney(Journey journey)
    {
        var journeyIndex = Journeys.FindIndex(c => c.ID == journey.ID);
        if (journeyIndex == -1)
        {
            return false;
        }
        Journeys[journeyIndex] = journey;
        return true;
    }
    public List<Journey>? GetJourneysByStartIDAndEndID(int startID, int endID)
    {
        var journeys = new List<Journey>();
        foreach(var journey in Journeys)
        {
            int startStationIndex = journey.StationIDsTimes?.FindIndex(s => s.ID == startID) ?? -1;
            int endStationIndex = journey.StationIDsTimes?.FindIndex(s => s.ID == endID) ?? -1;
            if(startStationIndex != -1 && startStationIndex < endStationIndex)
            {
                journeys.Add(journey);
            }
        }
        return journeys.Any() ? journeys : null;
    }
    public List<Journey>? FilterJourneys(FilterJourneysRequest request)
    {
        return null;
    }
}
