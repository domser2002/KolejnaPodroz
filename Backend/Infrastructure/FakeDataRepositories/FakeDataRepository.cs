using Infrastructure.DataRepositories;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FakeDataRepositories
{
    public class FakeDataRepository : IDataRepository
    { 
        public IAdminRepository AdminRepository { get; set; } = new FakeAdminRepository();
        public IComplaintRepository ComplaintRepository { get; set; } = new FakeComplaintRepository();
        public IDiscountRepository DiscountRepository { get; set; } = new FakeDiscountRepository();
        public IProviderRepository ProviderRepository { get; set; } = new FakeProviderRepository();
        public ITicketRepository TicketRepository { get; set; } = new FakeTicketRepository();
        public IUserRepository UserRepository { get; set; } = new FakeUserRepository();

        public IConnectionRepository ConnectionRepository { get; set; } = new FakeConnectionRepository(); 

        public IStatisticsRepository StatisticsRepository { get; set; } = new FakeStatisticsRepository();
        public IStationRepository StationRepository { get; set; } = new FakeStationRepository();
        public IStopDetailsRepository StopDetailsRepository { get; set; } = new FakeStopDetailsRepository();
        public IStatisticsCategoryRepository StatisticsCategoryRepository { get; set; } = new FakeStatisticsCategoryRepository();
    }
}
