namespace Domain.Server
{
    public class UserSession
    {
        // Why do we have two different session classes? What is the difference? If the only difference is maximum idle duration then 
        // shouldn't it just be a field?
        public int UserID { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime LoginTime { get; set; }
    }
}
