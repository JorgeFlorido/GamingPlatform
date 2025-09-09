namespace UserService.Application.DTOs
{
  public record RegisterUserRequest
  {
    public string Username { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
  }
}
