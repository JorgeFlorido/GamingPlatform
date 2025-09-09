using UserService.Application.DTOs;

namespace UserService.Application.Interfaces
{
  public interface IUserRegistrationService
  {
    Task<UserResponse> RegisterUserAsync(string username, string email, string password);
  }
}
