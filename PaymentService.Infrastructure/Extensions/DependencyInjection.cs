using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentService.Domain.Interfaces;
using PaymentService.Infrastructure.Persistence;
using PaymentService.Infrastructure.Repositories;

namespace PaymentService.Infrastructure.Extensions
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<PaymentDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("PaymentDb")));
      services.AddScoped<IPaymentRepository, PaymentRepository>();
      return services;
    }
  }
}
