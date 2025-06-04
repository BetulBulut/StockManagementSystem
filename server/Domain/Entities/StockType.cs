namespace StockManagementSystem.Domain.Entities;

public class StockType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public List<Stock> Stocks { get; set; } = new List<Stock>();
    public List<StockUnit> StockUnits { get; set; } = new List<StockUnit>();
}

