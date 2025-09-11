using PaymentService.Api.HostedServices;

namespace PaymentService.Api.Extensions
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddHostedServices(this IServiceCollection services)
    {
      services.AddHostedService<UserCreatedConsumerHostedService>();
      return services;
    }
  }
}
