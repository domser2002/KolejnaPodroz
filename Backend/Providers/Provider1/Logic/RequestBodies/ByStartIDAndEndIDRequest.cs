namespace Logic.RequestBodies;

public record GetConnectionByStartIDAndEndIDRequest
    (
        int startID,
        int endID
    );
