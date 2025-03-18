using OrdersApp.Application.Enums;
using OrdersApp.Application.Models;
using OrdersApp.Application.Validators;

namespace OrdersApp.Application.Helpers;

public static class CreateOrderHelper
{
    public static Order CreateOrder()
    {
        Console.WriteLine("Enter orders price:");
        var price = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Enter products name: ");
        var productName = Console.ReadLine();

        Console.WriteLine("Please select client type: ");
        Console.WriteLine($"Client types: \n 1. {ClientTypes.Company} \n 2. {ClientTypes.Individual} ");
        var clientType = (ClientTypes)Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Please select order status: ");
        Console.WriteLine($"Order statutes: \n 1.{OrderStatuses.New} \n 2.{OrderStatuses.InWarehouse}" + 
                          $"\n 3.{OrderStatuses.Shipped} \n 4.{OrderStatuses.ReturnedToClient} " + 
                          $"\n 5.{OrderStatuses.Error} \n 6.{OrderStatuses.Closed}");
        var orderStatus = (OrderStatuses)Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Please select payment method: ");
        Console.WriteLine($"Client types: \n 1. {PaymentMethods.Cash} \n 2. {PaymentMethods.Card} ");
        var paymentMethod = (PaymentMethods)Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Please enter adress:");
        var adress = Console.ReadLine();
        var order = new Order()
        {
            price = price,
            productName = productName,
            clientType = clientType,
            orderStatus = orderStatus,
            paymentMethod = paymentMethod,
            adress = adress,
        };
        
        var validator = new CreateOrderValidator();
        var result = validator.Validate(order);
        if (result.IsValid)
        {
            Console.WriteLine("The Validation was successfull!");
            return order;
        }
        else
        {
            Console.WriteLine("Validation error:");
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"{error.PropertyName}: {error.ErrorMessage}");
            }
            throw new Exception("Data was not valid.");
        }
        
    }
}