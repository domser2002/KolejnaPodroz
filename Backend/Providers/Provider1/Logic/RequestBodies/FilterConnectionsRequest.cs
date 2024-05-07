public record FilterJourneysRequest
    (
        int? startID,
        int? endID,
        DateTime? startDateTime,
        DateTime? endDateTime,
        int? trainType
    );