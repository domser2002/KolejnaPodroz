using Domain.Common;
using Domain.Server;
using Domain.User;

namespace Logic;

public static class Server
{
    private static List<Session> userSessions = [];
    private static List<Session> adminSessions = [];
    public static void CreateUserSession(int userID, string token)
    {
        Session session = new()
        {
            ID = userID,
            Token = token,
            LoginTime = DateTime.Now,
            IdleMaxMinutes = 15
        };
        userSessions.Add(session);
    }
    public static Session? CreateAdminSession(int adminID, string token)
    {
        Session session = new()
        {
            ID = adminID,
            Token = token,
            LoginTime = DateTime.Now,
            IdleMaxMinutes = 10
        };
        userSessions.Add(session);
        return session;
    }
    public static List<Connection> GetConnections(string source, string destination) 
    { 
        throw new NotImplementedException(); 
    }
    public static List<Advertisment> GetAds() 
    { 
        throw new NotImplementedException(); 
    }
    public static void CalculateRankings(int userID)
    {
        throw new NotImplementedException();
    }
    public static void UpdateDatabase()
    {
        throw new NotImplementedException();
    }
    public static bool ValidateDatabase()
    {
        throw new NotImplementedException();
    }
    public static void StartTechnicalBreak()
    {
        throw new NotImplementedException();
    }
    public static void EndTechnicalBreak()
    {
        throw new NotImplementedException();
    }
}
