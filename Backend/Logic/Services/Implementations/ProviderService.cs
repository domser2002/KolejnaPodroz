using Domain.Common;
using Infrastructure.Interfaces;

namespace Logic.Services.Implementations;

public class ProviderService(IDataRepository repository)
{
    private readonly IDataRepository _repository = repository;
    public bool AddProvider(Provider provider)
    {
        if (provider is null)
        {
            return false;
        }

        if (!_repository.ProviderRepository.Add(provider))
        {
            return false;
        }

        return true;
    }
    public bool RemoveProvider(int providerID)
    {
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
