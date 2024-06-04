using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDataRepository
    {
        public IAdminRepository AdminRepository { get; set; }
        public IComplaintRepository ComplaintRepository { get; set; }
        public IDiscountRepository DiscountRepository { get; set; }
        public IProviderRepository ProviderRepository { get; set; }
        public ITicketRepository TicketRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IConnectionRepository ConnectionRepository { get; set; }
        public IStationRepository StationRepository { get; set; }
        public IStopDetailsRepository StopDetailsRepository { get; set; }
        public IStatisticsRepository StatisticsRepository { get; set; }
        public IStatisticsCategoryRepository StatisticsCategoryRepository { get; set; }
    }
}
