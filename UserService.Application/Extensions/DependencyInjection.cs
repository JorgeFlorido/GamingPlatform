using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Handlers;
using UserService.Application.Interfaces;
using UserService.Application.Services;

namespace UserService.Application.Extensions
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddScoped<IUsersService, UsersService>();
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RegisterUserHandler>());
      return services;
    }
  }
}