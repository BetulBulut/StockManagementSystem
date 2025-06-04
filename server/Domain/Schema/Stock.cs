namespace StockManagementSystem.Domain.Schema;

public class CreateStockRequest : BaseRequest
{
    public string Class { get; set; } = string.Empty;
    public int StockTypeId { get; set; }
    public int StockUnitId { get; set; }
    public int Quantity { get; set; }
    public string ShelfInfo { get; set; } = string.Empty;
    public string CabinetInfo { get; set; } = string.Empty;
    public int CriticalQuantity { get; set; }
}

public class UpdateStockRequest : BaseRequest
{
    public int Id { get; set; }
    public string Class { get; set; } = string.Empty;
    public int StockTypeId { get; set; }
    public int StockUnitId { get; set; }
    public int Quantity { get; set; }
    public string ShelfInfo { get; set; } = string.Empty;
    public string CabinetInfo { get; set; } = string.Empty;
    public int CriticalQuantity { get; set; }
}

public class StockResponse : BaseResponse
{
    public int StockTypeId { get; set; }
    public int StockUnitId { get; set; }
    public string Class { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string ShelfInfo { get; set; } = string.Empty;
    public string CabinetInfo { get; set; } = string.Empty;
    public int CriticalQuantity { get; set; }
}