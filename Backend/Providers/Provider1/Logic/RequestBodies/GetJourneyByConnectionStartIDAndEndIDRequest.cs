namespace Logic.RequestBodies;

public record GetJourneyByConnectionStartIDAndEndIDRequest
    (
        int? startID,
        int? endID
    );
