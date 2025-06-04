using AutoMapper;
using StockManagementSystem.Domain.Entities;
using StockManagementSystem.Domain.Schema;
using StockManagementSystem.Domain.Enums;

namespace StockManagementSystem.Application.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        // StockType
        CreateMap<StockType, StockTypeResponse>();
        CreateMap<CreateStockTypeRequest, StockType>();
        CreateMap<UpdateStockTypeRequest, StockType>();

        // Stock
        CreateMap<Stock, StockResponse>();
        CreateMap<CreateStockRequest, Stock>()
            .ForMember(dest => dest.Class, opt => opt.MapFrom(src => ParseStockClassEnum(src.Class)));
        CreateMap<UpdateStockRequest, Stock>()
            .ForMember(dest => dest.Class, opt => opt.MapFrom(src => ParseStockClassEnum(src.Class)));

        // StockUnit
        CreateMap<StockUnit, StockUnitResponse>()
            .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit.ToString()))
            .ForMember(dest => dest.PurchaseCurrency, opt => opt.MapFrom(src => src.PurchaseCurrency.HasValue ? src.PurchaseCurrency.ToString() : null))
            .ForMember(dest => dest.SaleCurrency, opt => opt.MapFrom(src => src.SaleCurrency.HasValue ? src.SaleCurrency.ToString() : null));

        CreateMap<StockUnitRequest, StockUnit>()
            .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => ParseUnitEnum(src.Unit)))
            .ForMember(dest => dest.PurchaseCurrency, opt => opt.MapFrom(src => ParseCurrencyEnum(src.PurchaseCurrency)))
            .ForMember(dest => dest.SaleCurrency, opt => opt.MapFrom(src => ParseCurrencyEnum(src.SaleCurrency)));

        CreateMap<UpdateStockUnitRequest, StockUnit>()
            .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => ParseUnitEnum(src.Unit)))
            .ForMember(dest => dest.PurchaseCurrency, opt => opt.MapFrom(src => ParseCurrencyEnum(src.PurchaseCurrency)))
            .ForMember(dest => dest.SaleCurrency, opt => opt.MapFrom(src => ParseCurrencyEnum(src.SaleCurrency)));
    }

    private static UnitEnum ParseUnitEnum(string unit)
    {
        return Enum.TryParse<UnitEnum>(unit, out var val) ? val : UnitEnum.Piece;
    }

    private static CurrencyEnum? ParseCurrencyEnum(string currency)
    {
        return Enum.TryParse<CurrencyEnum>(currency, out var val) ? val : (CurrencyEnum?)null;
    }

    private static StockClassEnum ParseStockClassEnum(string classValue)
    {
        return Enum.TryParse<StockClassEnum>(classValue, out var val) ? val : StockClassEnum.RawMaterial;
    }
}