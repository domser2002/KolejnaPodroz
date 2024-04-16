using Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class StatisticsServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanReturn_GetStatisticsByUser_ReturnsStatistics()
        {
            StatisticsService statisticsService = new StatisticsService();
            Assert.IsNotNull(statisticsService.GetByUser(1));
        }
    }
}
