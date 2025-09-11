using MediatR;
using PaymentService.Application.Commands;
using PaymentService.Application.Interfaces;

namespace PaymentService.Application.Handlers
{
  internal class CreateWalletHandler : IRequestHandler<CreateWalletCommand, Guid>
  {
    private readonly IWalletService _walletService;

    public CreateWalletHandler(IWalletService walletService)
    {
      _walletService = walletService;
    }

    public async Task<Guid> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
      return await _walletService.CreateWalletAsync(request.UserId, request.Currency);
    }
  }
}
