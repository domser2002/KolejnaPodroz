using Logic.Services;

namespace Api.FakeData;

public class FakeDataGenerator
{
    private readonly ConnectionService _connectionService;
    private readonly JourneyService _journeyService;
    private readonly StationService _stationService;
    private readonly TicketService _ticketService;
    private readonly TrainService _trainService;

    public FakeDataGenerator(ConnectionService connectionService, JourneyService journeyService, StationService stationService, TicketService ticketService, TrainService trainService)
    {
        _connectionService = connectionService;
        _journeyService = journeyService;
        _stationService = stationService;
        _ticketService = ticketService;
        _trainService = trainService;
    }
}
