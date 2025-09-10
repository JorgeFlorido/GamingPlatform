using MediatR;
using PaymentService.Application.Commands;
using PaymentService.Application.DTOs;
using PaymentService.Application.Interfaces;

namespace PaymentService.Application.Handlers
{
  public class MakePaymentHandler : IRequestHandler<MakePaymentCommand, PaymentResult>
  {
    private readonly IPaymentsService _paymentService;

    public MakePaymentHandler(IPaymentsService paymentService)
    {
      _paymentService = paymentService;
    }

    public Task<PaymentResult> Handle(MakePaymentCommand request, CancellationToken cancellationToken)
    {
      return _paymentService.MakePaymentAsync(
          request.UserId,
          request.PaymentId,
          request.PaymentProviderId,
          request.Amount,
          request.Currency,
          cancellationToken);
    }
  }
}
