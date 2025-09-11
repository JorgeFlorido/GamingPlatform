using MediatR;

namespace PaymentService.Application.Commands
{
  public record CreateWalletCommand : IRequest<Guid>
  {
    public Guid UserId { get; init; }
    public string Currency { get; init; }
    public CreateWalletCommand(Guid userId, string currency)
    {
      UserId = userId;
      Currency = currency;
    }
  }
}
