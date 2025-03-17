using FluentValidation;
using OrdersApp.Application.Models;

namespace OrdersApp.Application.Validators;

public class CreateOrderValidator : AbstractValidator<Order>
{
    public CreateOrderValidator()
    {
        RuleFor(o => o.clientType)
            .NotNull()
            .WithMessage("Client type cannot be null.")
            .NotEmpty()
            .WithMessage("Client type cannot be empty.")
            .IsInEnum();
        
        RuleFor(o => o.orderStatus)
            .NotNull()
            .WithMessage("Order status cannot be null.")
            .NotEmpty()
            .WithMessage("Order status cannot be empty.")
            .IsInEnum();
        
        RuleFor(o => o.paymentMethod)
            .NotNull()
            .WithMessage("Payment method cannot be null.")
            .NotEmpty()
            .WithMessage("Payment method cannot be empty.")
            .IsInEnum();

        RuleFor(o => o.price)
            .NotNull()
            .WithMessage("Price cannot be null.")
            .NotEmpty()
            .WithMessage("Price cannot be empty.")
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero.");

        RuleFor(o => o.adress)
            .NotNull()
            .WithMessage("Adress cannot be null.")
            .NotEmpty()
            .WithMessage("Adress cannot be empty.")
            .MinimumLength(3)
            .WithMessage("Adress must be at least 3 characters long.")
            .MaximumLength(100)
            .WithMessage("Adress cannot be longer than 100 characters.");

    }
}