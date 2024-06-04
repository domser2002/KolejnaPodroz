using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using Infrastructure.FakeDataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class DataRepository(DomainDBContext context) : IDataRepository
    {
        public IAdminRepository AdminRepository { get; set; } = new AdminRepository(context);
        public IComplaintRepository ComplaintRepository { get; set; } = new ComplaintRepository(context);
        public IDiscountRepository DiscountRepository { get; set; } = new DiscountRepository(context);
        public IProviderRepository ProviderRepository { get; set; } = new ProviderRepository(context);
        public ITicketRepository TicketRepository { get; set; } = new TicketRepository(context);
        public IUserRepository UserRepository { get; set; } = new UserRepository(context);
        public IConnectionRepository ConnectionRepository { get; set; } = new ConnectionRepository(context);

        public IStatisticsRepository StatisticsRepository { get; set; } = new StatisticsRepository(context);
        public IStationRepository StationRepository { get; set; } = new StationRepository(context);
        public IStopDetailsRepository StopDetailsRepository { get; set; } = new StopDetailsRepository(context);
        public IStatisticsCategoryRepository StatisticsCategoryRepository { get; set; } = new StatisticsCategoryRepository(context);
    }
}
