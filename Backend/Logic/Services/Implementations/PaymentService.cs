using Infrastructure.Interfaces;

namespace Logic.Services.Implementations;

public class PaymentService(IDataRepository repository)
{
    private readonly IDataRepository _repository = repository; 
    public void ProceedPayment()
    {
        throw new NotImplementedException();
    }
}
