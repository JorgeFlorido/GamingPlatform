using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
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
      return services;
    }

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RegisterUserHandler>());
      return services;
    }

    public static IServiceCollection AddKafkaServices(this IServiceCollection services, IConfiguration configuration)
    {
      var bootstrapServers = configuration.GetSection("Kafka:BootstrapServers").Value;

      var config = new ProducerConfig
      {
        BootstrapServers = bootstrapServers
      };

      services.AddSingleton(new KafkaEventPublisher(config));
      return services;
    }
  }
}