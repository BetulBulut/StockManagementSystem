namespace StockManagementSystem.Domain.Schema;

public class BaseResponse
{
    public int Id { get; set; }
    public DateTime InsertedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; }
}