using Domain.Common;
using Infrastructure.DataRepositories;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;

namespace Logic.Services.Implementations;

public class ProviderService(IDataRepository repository, IDatabaseService dbService) : IProviderService
{
    private readonly IDataRepository _repository = repository;
    private readonly IDatabaseService _dbService = dbService;
    public int AddProvider(Provider? provider)
    {
        if (provider is null) return -1;
        if(_repository is DataRepository)
        {
            String query = $"INSERT INTO [dbo].[Provider] ([Name], [AdditionalInfo], [Email])\r\nVALUES ('{provider.Name}', '{provider.AdditionalInfo}', '{provider.Email}');\r\n";
            List<object[]> response = _dbService.ExecuteSQL(query);
            if(response != null)
            {
                return 1;
            }
            return -1;
        }
        return _repository.ProviderRepository.Add(provider);
    }
    public bool RemoveProvider(int providerID)
    {
        if(_repository is DataRepository)
        {
            String query = $"DELETE FROM [dbo].[Provider]\r\nWHERE [ID] = {providerID};\r\n";
            List<object[]> response = _dbService.ExecuteSQL(query);
            if (response != null)
            {
                return true;
            }
            return false;
        }

        Provider? provider = _repository.ProviderRepository.GetByID(providerID);
        if (provider is null || !_repository.ProviderRepository.Delete(provider))
        {
            return false;
        }

        return true;
    }
    private void EditAddProvider()
    {
        Provider provider = new();
        FillForm(provider);
        AddProvider(provider);
    }

    public bool EditProvider(Provider newProvider)
    {
        Provider? provider = GetProviderByID(newProvider.ID);
        if (provider is not null)
        {
            if(_repository is DataRepository)
            {
                String query = $"UPDATE [dbo].[Provider]\r\nSET [Name] = '{newProvider.Name}',\r\n    [AdditionalInfo] = '{newProvider.AdditionalInfo}',\r\n    [Email] = '{newProvider.Email}'\r\nWHERE [ID] = {newProvider.ID};\r\n";
                _dbService.ExecuteSQL(query);
                List<object[]> response = _dbService.ExecuteSQL(query);
                if (response != null)
                {
                    return true;
                }
                return false;
            }

            _repository.ProviderRepository.Update(newProvider);
            return true;
        }
        return false;
    }

    
    private void FillForm(Provider provider)
    {
        throw new NotImplementedException();
    }

    public Provider? GetProviderByID(int id)
    {
        return _repository.ProviderRepository.GetByID(id);
    }
}
