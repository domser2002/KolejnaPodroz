using Logic.Services.Interfaces;
using Domain.Common;

namespace Logic.Services.Decorators
{
    public class PaymentServiceDecorator : IPaymentService
    {
        private readonly IPaymentService _innerPaymentService;
        private readonly IAdminService _adminService;

        public PaymentServiceDecorator(IPaymentService innerPaymentService, IAdminService adminService)
        {
            _innerPaymentService = innerPaymentService;
            _adminService = adminService;
        }

        public bool ProceedPayment(Payment payment)
        {
            if (CheckCondition())
            {
                return _innerPaymentService.ProceedPayment(payment);
            }
            else
            {
                throw new TechnicalBreakException("Technical Break");
            }
        }

        private bool CheckCondition()
        {
            return !_adminService.IsTechnicalBreak();
        }
    }
}
