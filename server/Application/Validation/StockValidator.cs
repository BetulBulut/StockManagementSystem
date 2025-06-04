using FluentValidation;
using StockManagementSystem.Domain.Schema;

namespace StockManagementSystem.Application.Validation
{
    public class CreateStockRequestValidator : AbstractValidator<CreateStockRequest>
    {
        public CreateStockRequestValidator()
        {
            RuleFor(x => x.Class)
                .NotEmpty().WithMessage("Stok sınıfı boş olamaz.")
                .MaximumLength(50).WithMessage("Stok sınıfı en fazla 50 karakter olabilir.");

            RuleFor(x => x.StockTypeId)
                .GreaterThan(0).WithMessage("Geçerli bir stok tipi seçiniz.");

            RuleFor(x => x.StockUnitId)
                .GreaterThan(0).WithMessage("Geçerli bir stok birimi seçiniz.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Miktar negatif olamaz.");

            RuleFor(x => x.ShelfInfo)
                .MaximumLength(50).WithMessage("Raf bilgisi en fazla 50 karakter olabilir.");

            RuleFor(x => x.CabinetInfo)
                .MaximumLength(50).WithMessage("Dolap bilgisi en fazla 50 karakter olabilir.");

            RuleFor(x => x.CriticalQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Kritik miktar negatif olamaz.");
        }
    }

    public class UpdateStockRequestValidator : AbstractValidator<UpdateStockRequest>
    {
        public UpdateStockRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir Id giriniz.");

            RuleFor(x => x.Class)
                .NotEmpty().WithMessage("Stok sınıfı boş olamaz.")
                .MaximumLength(50).WithMessage("Stok sınıfı en fazla 50 karakter olabilir.");

            RuleFor(x => x.StockTypeId)
                .GreaterThan(0).WithMessage("Geçerli bir stok tipi seçiniz.");

            RuleFor(x => x.StockUnitId)
                .GreaterThan(0).WithMessage("Geçerli bir stok birimi seçiniz.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Miktar negatif olamaz.");

            RuleFor(x => x.ShelfInfo)
                .MaximumLength(50).WithMessage("Raf bilgisi en fazla 50 karakter olabilir.");

            RuleFor(x => x.CabinetInfo)
                .MaximumLength(50).WithMessage("Dolap bilgisi en fazla 50 karakter olabilir.");

            RuleFor(x => x.CriticalQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Kritik miktar negatif olamaz.");
        }
    }
}