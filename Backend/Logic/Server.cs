﻿using Domain.Common;
using Domain.Server;

namespace Logic;

public class Server
{
    public UserSession? CreateUserSession(int userID, string token)
    {
        throw new NotImplementedException();
    }
    public AdminSession? CreateAdminSession(int adminID, string token)
    {
        throw new NotImplementedException();
    }
    public List<Connection> GetConnections(string source, string destination) 
    { 
        throw new NotImplementedException(); 
    }
    public List<Advertisment> GetAds() 
    { 
        throw new NotImplementedException(); 
    }
    public void CalculateRankings(int userID)
    {
        throw new NotImplementedException();
    }
    public void UpdateDatabase()
    {
        throw new NotImplementedException();
    }
    public bool ValidateDatabase()
    {
        throw new NotImplementedException();
    }
    public void StartTechnicalBreak()
    {
        throw new NotImplementedException();
    }
    public void EndTechnicalBreak()
    {
        throw new NotImplementedException();
    }
}