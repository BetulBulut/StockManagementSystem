namespace StockManagementSystem.Domain.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime InsertedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; }
}