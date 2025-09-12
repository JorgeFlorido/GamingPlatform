namespace UserService.Domain.Entities
{
  public class OutboxMessage
  {
    public Guid Id { get; set; }
    public string? Type { get; set; }
    public string? Payload { get; set; }
    public string? Topic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ProcessedOn { get; set; }
    public bool Processed { get; set; }
    public string? Error { get; set; }
  }
}
