using UserService.Api.HostedServices;

namespace UserService.Api.Extensions
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddHostedServices(this IServiceCollection services)
    {
      services.AddHostedService<OutboxPublisherHostedService>();
      return services;
    }
  }
}
