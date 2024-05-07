using Infrastructure.Interfaces;
using Logic.Services.Interfaces;

namespace Logic.Services.Implementations;

public class PaymentService(IDataRepository repository) : IPaymentService
{
    private readonly IDataRepository _repository = repository; 
    public void ProceedPayment()
    {
        throw new NotImplementedException();
    }
}
