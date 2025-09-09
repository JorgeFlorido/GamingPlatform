namespace UserService.Application.DTOs
{
  public record UserResponse
  {
    public Guid Id { get; init; }
    public string Username { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public UserResponse(Guid id, string username, string email)
    {
      Id = id;
      Username = username;
      Email = email;
    }
  }
}
