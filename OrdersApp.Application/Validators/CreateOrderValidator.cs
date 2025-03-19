using FluentValidation;
using OrdersApp.Application.Models;

namespace OrdersApp.Application.Validators;
public class CreateOrderValidator : AbstractValidator<Order>
{
    public CreateOrderValidator()
    {
        RuleFor(o => o.ClientType)
            .NotNull()
            .WithMessage("Client type cannot be null.")
            .NotEmpty()
            .WithMessage("Client type cannot be empty.")
            .IsInEnum();
        
        RuleFor(o => o.OrderStatus)
            .NotNull()
            .WithMessage("Order status cannot be null.")
            .NotEmpty()
            .WithMessage("Order status cannot be empty.")
            .IsInEnum();
        
        RuleFor(o => o.PaymentMethod)
            .NotNull()
            .WithMessage("Payment method cannot be null.")
            .NotEmpty()
            .WithMessage("Payment method cannot be empty.")
            .IsInEnum();

        RuleFor(o => o.Price)
            .NotNull()
            .WithMessage("Price cannot be null.")
            .NotEmpty()
            .WithMessage("Price cannot be empty.")
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero.");

        RuleFor(o => o.Address)
            .NotNull()
            .WithMessage("Address cannot be null.")
            .NotEmpty()
            .WithMessage("Address cannot be empty.")
            .MinimumLength(3)
            .WithMessage("Address must be at least 3 characters long.")
            .MaximumLength(100)
            .WithMessage("Address cannot be longer than 100 characters.");

    }
}