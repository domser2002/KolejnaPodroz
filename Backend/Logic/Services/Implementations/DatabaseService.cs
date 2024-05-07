using Domain.Common;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;

namespace Logic.Services.Implementations;

public class DatabaseService(IDataRepository repository) : IDatabaseService
{
    private readonly IDataRepository _repository = repository;
    public void ExecuteSQL(string sql)
    {
        throw new NotImplementedException();
    }
    public void Backup()
    {
        throw new NotImplementedException();
    }
}
