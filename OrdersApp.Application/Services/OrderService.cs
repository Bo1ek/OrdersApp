using OrdersApp.Application.Enums;
using OrdersApp.Application.Exceptions;
using OrdersApp.Application.Models;
using OrdersApp.Application.Repositories;
using static System.Enum;

namespace OrdersApp.Application.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    public async Task<Order?> GetOrderByIdAsync()
    {
        Console.WriteLine("Please enter the order Id you want to get.");
        var orderId = int.Parse(Console.ReadLine());
        try
        {
            var order = await orderRepository.GetOrderByIdAsync(orderId);
            Console.WriteLine(
                $"OrderId : {order.OrderId} | Price: {order.Price} | Product name: {order.ProductName} |" +
                $" Client type: {order.ClientType}  | Address: {order.Address} | Status: {order.OrderStatus} | Payment Method: {order.PaymentMethod}");
        }
        catch (OrderNotFoundException)
        {
            Console.WriteLine("Order was not found. Pass proper order Id.");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Invalid order Id. Pass proper order Id.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return null;
    }

    public async Task UpdateOrderAsync()
    {
        Console.WriteLine("Please enter the order Id you want to update.");
        var orderId = int.Parse(Console.ReadLine());
        
        var order =  await orderRepository.GetOrderByIdAsync(orderId);
        Console.WriteLine("Enter which property do u want to update?");
        Console.WriteLine($"1.Price -- Current price - {order.Price}");
        Console.WriteLine($"2.Product name -- Current product name -- {order.ProductName} ");
        Console.WriteLine($"3.Client type -- Current client type - {order.ClientType}");
        Console.WriteLine($"4.Order status -- Current order status - {order.OrderStatus}");
        Console.WriteLine($"5.Payment method -- Current payment method - {order.PaymentMethod}");
        Console.WriteLine($"6.Address -- Current address - {order.Address}");
        
        var choice = Console.ReadLine();
        try
        {
            switch (choice)
            {
                case "1" :
                    Console.WriteLine("Enter new price: ");
                    var newPrice = decimal.Parse(Console.ReadLine());
                    order.Price = newPrice;
                    break;
                case "2" :
                    Console.WriteLine("Enter new product name: ");
                    var newProductName = Console.ReadLine();
                    order.ProductName = newProductName;
                    break;
                case "3" :
                    Console.WriteLine("Enter new client type: ");
                    TryParse(Console.ReadLine(), out ClientTypes newClientType);
                    if (IsDefined(typeof(ClientTypes), newClientType)) 
                        order.ClientType = newClientType;
                    else
                        Console.WriteLine("Invalid client type. Pass proper client type.");
                    break;
                case "4" :
                    Console.WriteLine("Enter new order status: ");
                    TryParse(Console.ReadLine(), out OrderStatuses newOrderStatus);
                    if (IsDefined(typeof(OrderStatuses), newOrderStatus))
                        order.OrderStatus = newOrderStatus;
                    else
                        Console.WriteLine("Invalid order status. Pass proper order status.");
                    break;
                case "5" :
                    Console.WriteLine("Enter new payment method: ");
                    TryParse(Console.ReadLine(), out PaymentMethods newPaymentMethod);
                    if (IsDefined(typeof(PaymentMethods), newPaymentMethod))
                        order.PaymentMethod = newPaymentMethod;
                    else 
                        Console.WriteLine("Invalid payment method. Pass proper payment method.");
                    break;
                case "6":
                    Console.WriteLine("Enter new address: ");
                    var newAddress = Console.ReadLine();
                    order.Address = newAddress;
                    break;
                default: 
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            await orderRepository.UpdateOrderAsync(orderId);
        }
        catch (OrderNotFoundException)
        {
            Console.WriteLine("Order was not found. Pass proper order Id.");
        }
    }

    public async Task DeleteOrderAsync()
    {
        Console.WriteLine("Please enter the order Id you want to delete:");
        var orderId = int.Parse(Console.ReadLine());
        try
        {
            await orderRepository.DeleteOrderAsync(orderId);
            Console.WriteLine($"Order with order id: {orderId} deleted.");
        }
        catch (OrderNotFoundException)
        {
            Console.WriteLine("Order was not found. Pass proper order Id.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task SendOrderToTheWarehouseAsync()
    {
        Console.WriteLine("Please enter the order Id you want to send to the warehouse:");
        var orderId = int.Parse(Console.ReadLine());
        try
        {
            await orderRepository.SendOrderToTheWarehouseAsync(orderId);
        }
        catch (OrderNotFoundException)
        {
            Console.WriteLine("Order was not found. Pass proper order Id.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task ShipOrderAsync()
    {
        Console.WriteLine("Please enter the order Id you want to ship:");
        var orderId = int.Parse(Console.ReadLine());
        try
        {
            await orderRepository.ShipOrderAsync(orderId);
        }
        catch (OrderNotFoundException)
        {
            Console.WriteLine("Order was not found. Pass proper order Id.");
        }
        catch (ShipOrderMethodLongerThan5Seconds)
        {
            Console.WriteLine("ShipOrder Method was executed for longer than 5 seconds. There was an error with executing this method.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task ShowOrdersAsync()
    {
        var orders = await orderRepository.GetOrdersAsync();
        foreach (var order in orders)
            Console.WriteLine(
                $"OrderId : {order.OrderId} | Price: {order.Price} | Product name: {order.ProductName} |" +
                $" Client type: {order.ClientType}  | Address: {order.Address} | Status: {order.OrderStatus} | Payment Method: {order.PaymentMethod}");
    }
}