using Domain.Common;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;

namespace Logic.Services.Implementations;

public class PaymentService : IPaymentService
{
    public bool ProceedPayment(Payment payment)
    {
        Thread.Sleep(1000);
        if(payment.Code.Length != 6) return false;
        Thread.Sleep(2000);
        return true;
    }
}
