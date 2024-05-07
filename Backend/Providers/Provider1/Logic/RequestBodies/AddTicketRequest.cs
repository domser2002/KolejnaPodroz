namespace Logic.RequestBodies;

public record AddTicketRequest
    (
        int JourneyID,
        int? seatNumber,
        int startConnectionID,
        int endConnectionID,
        string FirstName,
        string LastName,
        string Email,
        string Phone
    );
