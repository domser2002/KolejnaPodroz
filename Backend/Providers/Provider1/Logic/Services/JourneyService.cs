using Domain.Models;

namespace Logic.Services;

public class JourneyService
{
    public readonly TrainService _trainService;
    public static List<Journey> Journeys { get; set; } = new();
    public JourneyService(TrainService trainService)
    {
        _trainService = trainService;
    }
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
    public List<Journey>? GetJourneysByStartIDAndEndID(int? startID, int? endID)
    {
        var journeys = new List<Journey>();
        foreach (var journey in Journeys.Where(j => j.Connections != null))
        {
            int startIndex = journey.Connections!.FindIndex(c => c.StartStationTime.StationID == startID);
            int endIndex = journey.Connections.FindIndex(c => c.EndStationTime.StationID == endID);
            if (startIndex < endIndex)
            {
                journeys.Add(journey);
            }
        }
        return journeys.Any() ? journeys : null;
    }
    public List<Journey>? FilterJourneys(FilterJourneysRequest request)
    {
        var journeys = new List<Journey>();
        foreach (var journey in Journeys.Where(j => j.Connections != null))
        {
            int startIndex = journey.Connections!.FindIndex(c => c.StartStationTime.StationID == request.startID);
            int endIndex = journey.Connections.FindIndex(c => c.EndStationTime.StationID == request.endID);
            if (startIndex > endIndex)
                continue;

            if(request.startDateTime < journey.Connections[startIndex].StartStationTime.Time 
                || request.endDateTime > journey.Connections[endIndex].EndStationTime.Time)
                continue;

            if(request.trainType != null)
            {
                var train = _trainService.GetTrainByID(journey.TrainID);
                if (train == null)
                    continue;
            }
            journeys.Add(journey);
        }
        return journeys.Any() ? journeys : null;
    }
}
