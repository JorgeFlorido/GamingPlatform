using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Application.Services
{
  public class UserRegistrationService
  {
    private readonly IUserRepository _userRepository;

    public UserRegistrationService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<User> RegisterAsync(string username, string email, string password)
    {
      // 🔒 TODO: Hash password

      var user = new User(username, email, password);
      await _userRepository.AddAsync(user);
      return user;
    }
  }
}
