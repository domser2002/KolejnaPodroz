using Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class RankingServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test] 
        public void CanReturn_GetRankingByUser_ReturnsPersonalRanking ()
        {
            RankingService rankingService = new RankingService();
            Assert.IsNotNull(rankingService.GetByUser(1));
        }

        [Test]
        public void CanReturn_GetRankingByCategory_ReturnsRanking()
        {
            RankingService rankingService = new RankingService();
            Assert.IsNotNull(rankingService.GetByCategory("ilość przejazdów"));
        }

    }
}
