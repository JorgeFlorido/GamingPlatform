using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Application.Services
{
  public class UserRegistrationService : IUserRegistrationService
  {
    private readonly IUserRepository _userRepository;

    public UserRegistrationService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<UserResponse> RegisterAsync(string username, string email, string password)
    {
      // 🔒 TODO: Hash password

      var user = new User(username, email, password);
      await _userRepository.AddAsync(user);
      return new UserResponse(user.Id, user.Username, user.Email);
    }
  }
}
