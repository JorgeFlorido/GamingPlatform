namespace UserService.Domain.Entities
{
  public class User
  {
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string HashedPassword { get; private set; }

    public User(string username, string email, string hashedPassword)
    {
      Id = Guid.NewGuid();
      Username = username;
      Email = email;
      HashedPassword = hashedPassword;
    }
  }
}
