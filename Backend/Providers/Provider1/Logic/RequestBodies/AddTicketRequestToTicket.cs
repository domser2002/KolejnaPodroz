namespace Logic.RequestBodies;

public record AddTicketRequestToTicket
    (
        int ConnectionID,
        int SeatID,
        int StartStationID,
        int EndStationID,
        string FirstName,
        string LastName,
        string Email,
        string Phone
    );
