using Domain.Common;

namespace Api.Services
{
    public class StatisticsService
    {
        DomainDBContext ddbContext = new DomainDBContext();
        public Statistics GetByUser(int userID)
        {
            Statistics statistics = new Statistics();
         Domain.User.User u =   ddbContext.User.Find(userID);
         var ls = u.ListTickets();
         int NumOfRides = ls.Count;
            statistics.statistics.Add(("ilość przejazdów", NumOfRides));
        return statistics;
        }
        public bool Update(int userID, Statistics statistics)
        {
            throw new NotImplementedException(); 
        }
    }
}
