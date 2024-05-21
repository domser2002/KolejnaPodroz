using Domain.Common;

namespace Logic.ExternalApiServices.Interfaces;

public interface IExternalConnectionService
{
    public Connection GetConnectionById(int id);
    public IEnumerable<Connection> GetConnectionsByUser(int userId);
}
