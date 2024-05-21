namespace ProviderLogic.RequestBodies;

using ProviderDomain.Enums;

public record FilterJourneysRequest
    (
        int? startID,
        int? endID,
        DateTime? startDateTime,
        DateTime? endDateTime,
        TrainType? trainType
    );