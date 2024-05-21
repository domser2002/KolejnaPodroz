namespace ProviderLogic.RequestBodies;

public record AddTicketRequest
    (
        int journeyID,
        int? seatNumber,
        int startConnectionID,
        int endConnectionID,
        string firstName,
        string lastName,
        string email,
        string phone
    );
