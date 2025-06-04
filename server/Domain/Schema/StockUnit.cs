using StockManagementSystem.Domain.Schema;

namespace StockManagementSystem.Domain.Schema;

public class StockUnitRequest : BaseRequest
{
    public string Code { get; set; } = string.Empty;
    public int StockTypeId { get; set; }
    public string Unit { get; set; } = string.Empty; // Enum string olarak alınabilir
    public string? Description { get; set; }
    public decimal? PurchasePrice { get; set; }
    public string? PurchaseCurrency { get; set; } // Enum string olarak alınabilir
    public decimal? SalePrice { get; set; }
    public string? SaleCurrency { get; set; } // Enum string olarak alınabilir
    public string? PaperWeight { get; set; }
}

public class UpdateStockUnitRequest : BaseRequest
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public int StockTypeId { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal? PurchasePrice { get; set; }
    public string? PurchaseCurrency { get; set; }
    public decimal? SalePrice { get; set; }
    public string? SaleCurrency { get; set; }
    public string? PaperWeight { get; set; }
}

public class StockUnitResponse : BaseResponse
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public int StockTypeId { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal? PurchasePrice { get; set; }
    public string? PurchaseCurrency { get; set; }
    public decimal? SalePrice { get; set; }
    public string? SaleCurrency { get; set; }
    public string? PaperWeight { get; set; }
}