namespace PaymentService.Application.Interfaces
{
  public interface IPaymentProviderStrategy
  {
    IPaymentProvider GetProvider(Guid providerId);
  }
}
