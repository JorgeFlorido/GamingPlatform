using PaymentService.Application.Interfaces;

namespace PaymentService.Application.Providers
{
  internal class PaymentProviderStrategy : IPaymentProviderStrategy
  {
    private readonly Dictionary<Guid, IPaymentProvider> _providers;
    private readonly IPaymentProvider _defaultProvider;

    public PaymentProviderStrategy(IEnumerable<IPaymentProvider> providers, IPaymentProvider defaultProvider)
    {
      _providers = providers.ToDictionary(p => p.Id, p => p);
      _defaultProvider = defaultProvider;
    }

    public IPaymentProvider GetProvider(Guid providerId)
    {
      return _providers.TryGetValue(providerId, out var provider)
          ? provider
          : _defaultProvider;
    }
  }
}
