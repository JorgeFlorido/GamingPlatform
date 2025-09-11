using UserService.Application.DTOs;

namespace UserService.Application.Interfaces
{
  public interface IUsersService
  {
    Task<UserResponse> RegisterAsync(string username, string email, string password);
    Task<UserResponse> GetUserByIdAsync(Guid userId);
    Task<List<UserResponse>> GetUsersAsync();
  }
}
