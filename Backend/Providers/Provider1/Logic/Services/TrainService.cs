using Domain.Models;
using Domain.Enums;

namespace Logic.Services;

public class TrainService
{
    public static List<Train> Trains { get; set; } = new();
    public TrainService()
    {
        GenerateFakeData();
    }
    public void GenerateFakeData()
    {
        var train1 = new Train("Train1", TrainType.Regional, null);
        var train2 = new Train("Train2", TrainType.InterCity, null);
        var train3 = new Train("Train3", TrainType.HighSpeed, null);
        Trains.Add(train1);
        Trains.Add(train2);
        Trains.Add(train3);
        foreach(var train in Trains)
        {
            var seats = new List<Seat>();
            for (int i = 0; i < 100; i++)
            {
                seats.Add(new Seat(i, i < 80 ? SeatType.Economy : SeatType.Business));
            }
            train.Seats = seats;
        }
    }
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
