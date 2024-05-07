namespace Logic.RequestBodies;

public record GetJourneyByStartIDAndEndIDRequest
    (
        int? startID,
        int? endID
    );
