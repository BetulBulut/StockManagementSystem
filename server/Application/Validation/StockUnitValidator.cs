using FluentValidation;
using StockManagementSystem.Domain.Schema;

namespace StockManagementSystem.Application.Validation
{
    public class CreateStockUnitRequestValidator : AbstractValidator<StockUnitRequest>
    {
        public CreateStockUnitRequestValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Kod alanı boş olamaz.")
                .MaximumLength(50).WithMessage("Kod en fazla 50 karakter olabilir.");

            RuleFor(x => x.StockTypeId)
                .GreaterThan(0).WithMessage("Geçerli bir stok tipi seçiniz.");

            RuleFor(x => x.Unit)
                .NotEmpty().WithMessage("Birim alanı boş olamaz.")
                .MaximumLength(30).WithMessage("Birim en fazla 30 karakter olabilir.");

            RuleFor(x => x.PurchasePrice)
                .GreaterThanOrEqualTo(0).When(x => x.PurchasePrice.HasValue)
                .WithMessage("Alış fiyatı negatif olamaz.");

            RuleFor(x => x.SalePrice)
                .GreaterThanOrEqualTo(0).When(x => x.SalePrice.HasValue)
                .WithMessage("Satış fiyatı negatif olamaz.");

            RuleFor(x => x.PaperWeight)
                .MaximumLength(20).When(x => !string.IsNullOrEmpty(x.PaperWeight))
                .WithMessage("Kağıt gramajı en fazla 20 karakter olabilir.");
        }
    }

    public class UpdateStockUnitRequestValidator : AbstractValidator<UpdateStockUnitRequest>
    {
        public UpdateStockUnitRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir Id giriniz.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Kod alanı boş olamaz.")
                .MaximumLength(50).WithMessage("Kod en fazla 50 karakter olabilir.");

            RuleFor(x => x.StockTypeId)
                .GreaterThan(0).WithMessage("Geçerli bir stok tipi seçiniz.");

            RuleFor(x => x.Unit)
                .NotEmpty().WithMessage("Birim alanı boş olamaz.")
                .MaximumLength(30).WithMessage("Birim en fazla 30 karakter olabilir.");

            RuleFor(x => x.PurchasePrice)
                .GreaterThanOrEqualTo(0).When(x => x.PurchasePrice.HasValue)
                .WithMessage("Alış fiyatı negatif olamaz.");

            RuleFor(x => x.SalePrice)
                .GreaterThanOrEqualTo(0).When(x => x.SalePrice.HasValue)
                .WithMessage("Satış fiyatı negatif olamaz.");

            RuleFor(x => x.PaperWeight)
                .MaximumLength(20).When(x => !string.IsNullOrEmpty(x.PaperWeight))
                .WithMessage("Kağıt gramajı en fazla 20 karakter olabilir.");
        }
    }
}