namespace PaymentService.Domain.Entities
{
  public class PaymentProvider
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
  }
}
