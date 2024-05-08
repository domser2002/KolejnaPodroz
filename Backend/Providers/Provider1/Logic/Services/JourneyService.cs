using Domain.Models;

namespace Logic.Services;

public class JourneyService
{
    private readonly TrainService _trainService;
    private readonly ConnectionService _connectionService;
    public static List<Journey> Journeys { get; set; } = new();
    public JourneyService(TrainService trainService, ConnectionService connectionService)
    {
        _trainService = trainService;
        _connectionService = connectionService;
        GenerateFakeData();
    }
    public void GenerateFakeData()
    {
        var journey1 = new Journey(1, new List<int> { 1, 2, 3, 4, 5 });
        var journey2 = new Journey(2, new List<int> { 1, 5 });
        var journey3 = new Journey(3, new List<int> { 4, 3 });

        Journeys.Add(journey1);
        Journeys.Add(journey2);
        Journeys.Add(journey3);
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
    public List<Journey>? GetJourneysByConnectionsStartIDAndEndID(int? startID, int? endID)
    {
        var journeys = new List<Journey>();
        foreach (var journey in Journeys.Where(j => j.ConnectionIDs != null))
        {
            int startIndex = journey.ConnectionIDs!.FindIndex(cid => cid == startID);
            int endIndex = journey.ConnectionIDs.FindIndex(cid => cid == endID);
            if (startIndex != -1 && startIndex < endIndex)
            {
                journeys.Add(journey);
            }
        }
        return journeys.Any() ? journeys : null;
    }
    //public List<Journey>? FilterJourneys(FilterJourneysRequest request)
    //{
    //    if (request.startID == null && request.endID != null)
    //        return null;

    //    var journeys = new List<Journey>();
    //    foreach (var journey in Journeys.Where(j => j.ConnectionIDs != null))
    //    {
    //        int startIndex = journey.ConnectionIDs!.FindIndex(cid => cid == request.startID);
    //        int endIndex = journey.ConnectionIDs.FindIndex(cid => cid == request.endID);
    //        if (startIndex == -1 || (endIndex != -1 && startIndex > endIndex))
    //            continue;

    //        var startConnection = _connectionService.GetConnectionByID(journey.ConnectionIDs[startIndex]);
    //        Connection? endConnection = null;
    //        if(endIndex != -1)
    //            endConnection = _connectionService.GetConnectionByID(journey.ConnectionIDs[endIndex]);

    //        if(startConnection != null && request.startDateTime != null)
    //        {
    //            if (request.startDateTime < startConnection.StartStationTime.Time)
    //            {
    //                if (endConnection != null && request.endDateTime < endConnection.EndStationTime.Time)
    //                {
    //                    continue;
    //                }
    //            }
    //            else
    //                continue;
    //        }

    //        if(request.trainType != null)
    //        {
    //            var train = _trainService.GetTrainByID(journey.TrainID);
    //            if (train == null)
    //                continue;
    //        }
    //        journeys.Add(journey);
    //    }
    //    return journeys.Any() ? journeys : null;
    //}
}
