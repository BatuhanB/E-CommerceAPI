using Commerce.Application.Constants.Messages.Products;
using Commerce.Domain.Entities;
using FluentValidation;

namespace Commerce.Application.Validators.Products
{
    public class AddProductValidator : AbstractValidator<Product>
    {
        public AddProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProductMessages.ProductNameCanNotBeNull())
                .MinimumLength(3)
                .WithMessage(ProductMessages.ProductNameMinLength());
            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProductMessages.ProductPriceCanNotBeNull())
                .Must(x=>x >= 0)
                .WithMessage(ProductMessages.ProductPriceMinValue());
            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProductMessages.ProductStockCanNotBeNull())
                .Must(x=>x >= 0)
                .WithMessage(ProductMessages.ProductStockMinValue());
            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProductMessages.ProductStockCanNotBeNull())
                .LessThanOrEqualTo(1000)
                .WithMessage(ProductMessages.ProductStockLessThanThousand());
        }
    }
}
