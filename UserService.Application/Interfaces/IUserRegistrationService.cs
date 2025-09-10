using UserService.Application.DTOs;

namespace UserService.Application.Interfaces
{
  public interface IUserRegistrationService
  {
    Task<UserResponse> RegisterAsync(string username, string email, string password);
  }
}
