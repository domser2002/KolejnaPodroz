namespace Domain.Server;

public class AdminSession
{
    // Same comment as in UserSession.
    public int AdminID { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime LoginTime { get; set; }
}
