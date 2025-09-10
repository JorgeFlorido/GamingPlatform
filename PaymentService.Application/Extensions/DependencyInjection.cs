using Microsoft.Extensions.DependencyInjection;
using PaymentService.Application.Handlers;
using PaymentService.Application.Interfaces;
using PaymentService.Application.Providers;
using PaymentService.Application.Services;

namespace PaymentService.Application.Extensions
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddScoped<IPaymentProvider, MockProviderA>();
      services.AddScoped<IPaymentProvider, MockProviderB>();

      services.AddScoped<IPaymentsService, PaymentsService>();
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<MakePaymentHandler>());
      return services;
    }
  }
}
