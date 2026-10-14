using FluentValidation;

namespace Stores.BusinessLogic.Product
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(150).WithMessage("Product name cannot be longer than 150 characters.")
                .When(x => x.Name != null); 

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.")
                .When(x => x.Price.HasValue); 

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative.")
                .When(x => x.Stock.HasValue);
        }
    }
}