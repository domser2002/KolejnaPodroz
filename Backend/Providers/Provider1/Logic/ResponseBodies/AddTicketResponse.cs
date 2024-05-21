namespace ProviderLogic.ResponseBodies;

public record AddTicketResponse
    (
        int TicketID,
        decimal price
    );
