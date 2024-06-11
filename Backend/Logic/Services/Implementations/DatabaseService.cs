using Domain.Common;
using Infrastructure.DataContexts;
using Infrastructure.DataRepositories;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services.Implementations;

public class DatabaseService(IDataRepository repository, DomainDBContext context) : IDatabaseService
{
    private readonly IDataRepository _repository = repository;
    private readonly DomainDBContext _context = context;

    /*
    public DatabaseService(DomainDBContext context)
    {
        _context = context;
    }
    */


    public List<Object[]> ExecuteSQL(string sql)
    {
        if(_repository is not DataRepository)
        {
            throw new Exception("Can not execute SQL query on Data Repository that is not connected to SQL server");
        }

        var command = _context.Database.GetDbConnection().CreateCommand();
        command.CommandText = sql;
        _context.Database.OpenConnection();

        using var result = command.ExecuteReader();
        var data = new List<object[]>();

        while(result.Read()) 
        {
            var values = new object[result.FieldCount];
            result.GetValues(values);
            data.Add(values);
        }

        return data;
    }
    public void Backup()
    {
        throw new NotImplementedException();
    }
}
