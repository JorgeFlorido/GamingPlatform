using Microsoft.AspNetCore.Identity;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.Interfaces;

namespace UserService.Application.Services
{
  public class UsersService : IUsersService
  {
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<IdentityUser> _passwordHasher;

    public UsersService(IUserRepository userRepository, IPasswordHasher<IdentityUser> passwordHasher)
    {
      _userRepository = userRepository;
      _passwordHasher = passwordHasher;
    }

    public async Task<UserResponse> RegisterAsync(string username, string email, string password)
    {
      string hashedPassword = HashPassword(password);

      var user = new User(username, email, hashedPassword);
      await _userRepository.AddAsync(user);

      return new UserResponse(user.Id, user.Username, user.Email);
    }

    public async Task<UserResponse> GetUserByIdAsync(Guid userId)
    {
      var user = await _userRepository.GetByIdAsync(userId);
      return user == null ? throw new Exception("User not found") : new UserResponse(user.Id, user.Username, user.Email);
    }

    public async Task<List<UserResponse>> GetUsersAsync()
    {
      var users = await _userRepository.GetAllAsync();
      return users.Select(user => new UserResponse(user.Id, user.Username, user.Email)).ToList();
    }

    private string HashPassword(string password)
    {
      var tempUser = new IdentityUser();
      string hashedPassword = _passwordHasher.HashPassword(tempUser, password);
      return hashedPassword;
    }
  }
}
