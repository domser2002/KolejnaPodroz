using Domain.Common;
using Infrastructure.Interfaces;

namespace Logic.Services.Implementations;

public class DatabaseService(IDataRepository repository)
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

    public bool InsertProvider(Provider provider)
    {
        throw new NotImplementedException();
    }

    public bool UpdateProvider(int id, Provider provider)
    {
        throw new NotImplementedException();
    }

    public bool RemoveProvider(int provider)
    {
        throw new NotImplementedException();
    }

    public Provider GetProvider(int provider)
    {
        throw new NotImplementedException();
    }
}
