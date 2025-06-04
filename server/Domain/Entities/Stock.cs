using StockManagementSystem.Domain.Enums;

namespace StockManagementSystem.Domain.Entities;

public class Stock: BaseEntity
{
    public StockClassEnum Class { get; set; } = StockClassEnum.RawMaterial; // Stok Sınıfı (örn: Hammadde, Mamül)

    public int StockTypeId { get; set; }
    public StockType? StockType { get; set; }

    public int StockUnitId { get; set; } // Stok Birim Adı
    public StockUnit? StockUnit { get; set; }

    public int Quantity { get; set; }

    public string ShelfInfo { get; set; } = string.Empty;

    public string CabinetInfo { get; set; } = string.Empty;

    public int CriticalQuantity { get; set; }

}
