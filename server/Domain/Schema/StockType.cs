namespace StockManagementSystem.Domain.Schema;

public class CreateStockTypeRequest : BaseRequest
{
    public string Name { get; set; } = string.Empty;
}

public class UpdateStockTypeRequest : BaseRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class StockTypeResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
