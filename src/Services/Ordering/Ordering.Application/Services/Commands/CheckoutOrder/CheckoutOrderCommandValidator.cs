using amznStore.Services.Ordering.Application.Commands;
using FluentValidation;

namespace amznStore.Services.Ordering.Application.Validators
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(p => p.BuyerId)
                .NotEmpty().WithMessage("{BuyerId} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{BuyerId} must not exceed 50 characters.");

            RuleFor(p => p.EmailAddress)
               .NotEmpty().WithMessage("{EmailAddress} is required.");

            RuleFor(p => p.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is required.")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero.");
        }
    }
}
