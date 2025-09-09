using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Domain.Interfaces;
using UserService.Infrastructure.Persistence;
using UserService.Infrastructure.Repositories;

namespace UserService.Infrastructure.Extensions
{
  public static class InfrastructureServiceCollectionExtensions
  {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<UserDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
      services.AddScoped<IUserRepository, UserRepository>();
      return services;
    }
  }
}
