namespace ProviderDomain.Models;

public class Journey
{
    private static int _idCounter = 0;
    public int ID { get; } = ++_idCounter;
    public int TrainID { get; set; }
    public List<int>? ConnectionIDs { get; set; }
    public Journey(int trainID, List<int>? connectionIDs = null)
    {
        TrainID = trainID;
        ConnectionIDs = connectionIDs;
    }
}
