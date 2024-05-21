using Connection = Domain.Common.Connection;
using ProviderJourney = ProviderDomain.Models.Journey;
using ProviderConnection = ProviderDomain.Models.Connection;
using ProviderStation = ProviderDomain.Models.Station;
using Logic.ExternalApiServices.Interfaces;
using System.Text.Json;

namespace Logic.ExternalApiServices.Implementations;

public class ExternalConnectionService : IExternalConnectionService
{
    private HttpClient _httpClient;
    public ExternalConnectionService(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri("https://localhost:7087");
        _httpClient = httpClient;
    }
    public Connection? GetConnectionById(int id)
    {
        var response = _httpClient.GetAsync($"Journey/{id}").Result;
        if (response.IsSuccessStatusCode)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            var journey = JsonSerializer.Deserialize<ProviderJourney>(content);
            return MapJourneyToConnection(journey!);
        }
        return null;
    }

    public IEnumerable<Connection> GetConnectionsByUser(int userId)
    {
        throw new NotImplementedException();
    }
    private Connection MapJourneyToConnection(ProviderJourney journey)
    {
        var connection = new Connection();
        foreach(var providerConnectionID in journey.ConnectionIDs!)
        {
            var response = _httpClient.GetAsync($"Connection/{providerConnectionID}").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var providerConnection = JsonSerializer.Deserialize<ProviderConnection>(content);
            response = _httpClient.GetAsync($"Station/{providerConnection!.StartStationTime.StationID}").Result;
            content = response.Content.ReadAsStringAsync().Result;
            var startStation = JsonSerializer.Deserialize<ProviderStation>(content);
            connection.Stations.Add(startStation!.Name);
            connection.DepartureTimes.Add(providerConnection.StartStationTime.Time);
            
            if(providerConnectionID == journey.ConnectionIDs.Last())
            {
                response = _httpClient.GetAsync($"Station/{providerConnection!.EndStationTime.StationID}").Result;
                content = response.Content.ReadAsStringAsync().Result;
                var endStation = JsonSerializer.Deserialize<ProviderStation>(content);
                connection.Stations.Add(endStation!.Name);
                connection.DepartureTimes.Add(providerConnection.EndStationTime.Time);
            }
        }
        return connection;
    }
}
