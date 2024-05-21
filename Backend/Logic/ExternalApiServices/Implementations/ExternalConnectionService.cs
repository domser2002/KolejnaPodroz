using Domain.Common;
using Logic.ExternalApiServices.Interfaces;

namespace Logic.ExternalApiServices.Implementations;

public class ExternalConnectionService : IExternalConnectionService
{
    private HttpClient _httpClient;
    public ExternalConnectionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public Connection GetConnectionById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Connection> GetConnectionsByUser(int userId)
    {
        throw new NotImplementedException();
    }
}
