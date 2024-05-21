namespace ProviderLogic.RequestBodies;

public record GetJourneyByConnectionStartIDAndEndIDRequest
    (
        int? startID,
        int? endID
    );
