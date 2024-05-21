using Domain.Common;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;

namespace Logic.Services.Implementations;

public class PaymentService : IPaymentService
{
    public bool ProceedPayment(Payment payment)
    {
        if(payment is null) return false;
        Thread.Sleep(1000);
        if(payment.Code is null) return false;
        Thread.Sleep(1000);
        if(payment.Code.Length != 6 || !payment.Code.All(c => c >= '0' && c <= '9')) return false;
        Thread.Sleep(2000);
        return true;
    }
}
