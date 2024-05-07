using Domain.Common;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FakeDataRepositories
{
    public class FakeConnectionRepository : IConnectionRepository
    {
        private readonly List<Connection> Connections = [];

        public FakeConnectionRepository() 
        {
            Connection connection1 = new Connection();
            connection1.ID = 1;
            connection1.Stations = new List<string> { "Warszawa, Lublin, Stalowa Wola" };
            connection1.DepartureTimes = new List<DateTime> {
                new DateTime(year:2024, month: 5, day: 8, hour:12, minute:10, second:0),
                new DateTime(year:2024, month: 5, day: 8, hour:14, minute:10, second:0),
                new DateTime(year:2024, month: 5, day: 8, hour:16, minute:10, second:0)
            };
            connection1.ArrivalTimes = new List<DateTime> {
                new DateTime(year:2024, month: 5, day: 8, hour:12, minute:0, second:0),
                new DateTime(year:2024, month: 5, day: 8, hour:14, minute:0, second:0),
                new DateTime(year:2024, month: 5, day: 8, hour:16, minute:0, second:0)
            };
            connection1.Providers = new List<Provider>();

            Connection connection2 = new Connection();
            connection2.ID = 2;
            connection2.Stations = new List<string> { "Opole", "Lubin", "Otwock" };
            connection2.ArrivalTimes = new List<DateTime> {
                new DateTime(year:2024, month: 5, day: 9, hour:12, minute:0, second:0),
                new DateTime(year:2024, month: 5, day: 9, hour:14, minute:0, second:0),
                new DateTime(year:2024, month: 5, day: 9, hour:16, minute:0, second:0)
            };
            connection2.DepartureTimes = new List<DateTime> {
                new DateTime(year:2024, month: 5, day: 9, hour:12, minute:10, second:0),
                new DateTime(year:2024, month: 5, day: 9, hour:14, minute:10, second:0),
                new DateTime(year:2024, month: 5, day: 9, hour:16, minute:10, second:0)
            };
            connection2.Providers = new List<Provider>();

            Connections.Add(connection1);
            Connections.Add(connection2);
        }

        public IEnumerable<Connection> GetAll()
        {
            return Connections;
        }

        public Connection? GetByID(int id)
        {
            return Connections.FirstOrDefault(a => a.ID == id);
        }

        public bool Add(Connection Connection)
        {
            Connections.Add(Connection);
            return true;
        }

        public bool Update(Connection Connection)
        {
            int index = Connections.FindIndex(u => u.ID == Connection.ID);
            if (index != -1)
            {
                Connections.RemoveAt(index);
                Connections.Add(Connection);
                return true;
            }
            return false;
        }

        public bool Delete(Connection Connection)
        {
            return Connections.Remove(Connection);
        }
    }
}
