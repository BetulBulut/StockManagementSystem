using FluentValidation;
using StockManagementSystem.Domain.Schema;

namespace StockManagementSystem.Application.Validation
{
    public class CreateStockTypeRequestValidator : AbstractValidator<CreateStockTypeRequest>
    {
        public CreateStockTypeRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Stok tipi adı boş olamaz.")
                .MaximumLength(100).WithMessage("Stok tipi adı en fazla 100 karakter olabilir.");
        }
    }

    public class UpdateStockTypeRequestValidator : AbstractValidator<UpdateStockTypeRequest>
    {
        public UpdateStockTypeRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir Id giriniz.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Stok tipi adı boş olamaz.")
                .MaximumLength(100).WithMessage("Stok tipi adı en fazla 100 karakter olabilir.");
        }
    }
}