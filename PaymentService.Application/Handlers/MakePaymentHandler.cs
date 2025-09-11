using MediatR;
using PaymentService.Application.Commands;
using PaymentService.Application.DTOs;
using PaymentService.Application.Interfaces;

namespace PaymentService.Application.Handlers
{
  internal class MakePaymentHandler : IRequestHandler<MakePaymentCommand, PaymentResult>
  {
    private readonly IPaymentsService _paymentService;

    public MakePaymentHandler(IPaymentsService paymentService)
    {
      _paymentService = paymentService;
    }

    public async Task<PaymentResult> Handle(MakePaymentCommand request, CancellationToken cancellationToken)
    {
      return await _paymentService.MakePaymentAsync(
          request.UserId,
          request.PaymentId,
          request.PaymentProviderId,
          request.Amount,
          request.Currency,
          cancellationToken);
    }
  }
}
