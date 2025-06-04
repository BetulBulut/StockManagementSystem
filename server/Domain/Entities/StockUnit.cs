using StockManagementSystem.Domain.Enums;

namespace StockManagementSystem.Domain.Entities;

public class StockUnit : BaseEntity
{

    public string Code { get; set; } = string.Empty;

    public int StockTypeId { get; set; }
    public StockType? StockType { get; set; }

    public UnitEnum Unit { get; set; } = UnitEnum.Piece;

    public string? Description { get; set; }

    public decimal? PurchasePrice { get; set; }
    public CurrencyEnum? PurchaseCurrency { get; set; } = CurrencyEnum.TRY;

    public decimal? SalePrice { get; set; }
    public CurrencyEnum? SaleCurrency { get; set; } = CurrencyEnum.TRY;

    public string? PaperWeight { get; set; }

}

