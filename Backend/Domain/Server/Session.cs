namespace Domain.Server;

public class Session
{
    // Same comment as in UserSession.
    public int ID { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime LoginTime { get; set; }
    public int IdleMaxMinutes { get; set; }
}
