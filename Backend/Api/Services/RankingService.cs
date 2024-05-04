using Domain.Common;

namespace Api.Services
{
    public class RankingService
    {
        DomainDBContext ddbContext = new DomainDBContext();
        public PersonalRanking GetByUser(int userID)
        {
            PersonalRanking pr = new PersonalRanking();
            var ranking = ddbContext.Ranking.Find("ilość przejazdów");
            int rank = ranking.ranking.FindIndex((tuple) => tuple.userId== userID);
            pr.personalRanking.Add(("ilość przejazdów", rank));
            return pr;
        }

        public Ranking GetByCategory(string category)
        {
            return ddbContext.Ranking.Find(category);
        }
        public bool Update(int userID,Ranking ranking) 
        {
            throw new NotImplementedException();
        }
    }
}
