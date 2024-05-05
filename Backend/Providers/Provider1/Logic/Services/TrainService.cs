using Domain.Models;

namespace Logic.Services;

public class TrainService
{
    public static List<Train> Trains { get; set; } = new();
    public bool AddTrain(Train train)
    {
        if(Trains.Any(t => t.ID == train.ID))
        {
            return false;
        }
        Trains.Add(train);
        return true;
    }
    public Train? GetTrainByID(int ID)
    {
        return Trains.FirstOrDefault(t => t.ID == ID);
    }
    public void RemoveTrainByID(int ID)
    {
        Trains.RemoveAll(t => t.ID == ID);
    }
    public bool EditTrain(Train train)
    {
        var trainIndex = Trains.FindIndex(t => t.ID == train.ID);
        if (trainIndex == -1)
        {
            return false;
        }
        Trains[trainIndex] = train;
        return true;
    }
}
