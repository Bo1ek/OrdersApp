using OrdersApp.Application.Enums;
using OrdersApp.Application.Exceptions;
using OrdersApp.Application.Models;
using OrdersApp.Application.Repositories;

namespace OrdersApp.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> GetOrderByIdAsync()
    {
        Console.WriteLine("Please enter the order Id you want to get.");
        var orderId = int.Parse(Console.ReadLine());
        try
        {
            var order =  await _orderRepository.GetOrderByIdAsync(orderId);
            Console.WriteLine(
            $"OrderId : {order.orderId} | Price: {order.price} | Product name: {order.productName} |" +
            $" Client type: {order.clientType}  | Address: {order.adress} | Status: {order.orderStatus} | Payment Method: {order.paymentMethod}");
        }
        catch (OrderNotFoundException)
        {
            Console.WriteLine("Order was not found. Pass proper order Id.");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Invalid order Id. Pass proper order Id.");
        }

        return null;
    }

    public async Task UpdateOrderAsync()
    {
        Console.WriteLine("Please enter the order Id you want to update.");
        var orderId = int.Parse(Console.ReadLine());
        var order =  await _orderRepository.GetOrderByIdAsync(orderId);
        Console.WriteLine("Enter which property do u want to update?");
        Console.WriteLine($"1.Price -- Current price - {order.price}");
        Console.WriteLine($"2.Product name -- Current product name -- {order.productName} ");
        Console.WriteLine($"3.Client type -- Current client type - {order.clientType}");
        Console.WriteLine($"4.Order status -- Current order status - {order.orderStatus}");
        Console.WriteLine($"5.Payment method -- Current payment method - {order.paymentMethod}");
        Console.WriteLine($"6.Address -- Current address - {order.adress}");
        
        var choice = Console.ReadLine();
        try
        {
            switch (choice)
            {
                case "1" :
                    Console.WriteLine("Enter new price: ");
                    var newPrice = decimal.Parse(Console.ReadLine());
                    order.price = newPrice;
                    break;
                case "2" :
                    Console.WriteLine("Enter new product name: ");
                    var newProductName = Console.ReadLine();
                    order.productName = newProductName;
                    break;
                case "3" :
                    Console.WriteLine("Enter new client type: ");
                    Enum.TryParse(Console.ReadLine(), out ClientTypes newClientType);
                    if (Enum.IsDefined(typeof(ClientTypes), newClientType)) 
                        order.clientType = newClientType;
                    else
                        Console.WriteLine("Invalid client type. Pass proper client type.");
                    break;
                case "4" :
                    Console.WriteLine("Enter new order status: ");
                    Enum.TryParse(Console.ReadLine(), out OrderStatuses newOrderStatus);
                    if (Enum.IsDefined(typeof(OrderStatuses), newOrderStatus))
                        order.orderStatus = newOrderStatus;
                    else
                        Console.WriteLine("Invalid order status. Pass proper order status.");
                    break;
                case "5" :
                    Console.WriteLine("Enter new payment method: ");
                    Enum.TryParse(Console.ReadLine(), out PaymentMethods newPaymentMethod);
                    if (Enum.IsDefined(typeof(PaymentMethods), newPaymentMethod))
                        order.paymentMethod = newPaymentMethod;
                    else 
                        Console.WriteLine("Invalid payment method. Pass proper payment method.");
                    break;
                case "6":
                    Console.WriteLine("Enter new address: ");
                    var newAddress = Console.ReadLine();
                    order.adress = newAddress;
                    break;
                default: 
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            await _orderRepository.UpdateOrderAsync(orderId);
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
            await _orderRepository.DeleteOrderAsync(orderId);
            Console.WriteLine($"Order with order id: {orderId} deleted.");
        }
        catch (OrderNotFoundException)
        {
            Console.WriteLine("Order was not found. Pass proper order Id.");
        }
    }

    public async Task SendOrderToTheWarehouseAsync()
    {
        Console.WriteLine("Please enter the order Id you want to send to the warehouse:");
        var orderId = int.Parse(Console.ReadLine());
        try
        {
            await _orderRepository.SendOrderToTheWarehouseAsync(orderId);
        }
        catch (OrderNotFoundException)
        {
            Console.WriteLine("Order was not found. Pass proper order Id.");
        }
    }

    public async Task ShipOrderAsync()
    {
        Console.WriteLine("Please enter the order Id you want to ship:");
        var orderId = int.Parse(Console.ReadLine());
        try
        {
            await _orderRepository.ShipOrderAsync(orderId);
        }
        catch (OrderNotFoundException)
        {
            Console.WriteLine("Order was not found. Pass proper order Id.");
        }
        catch (ShipOrderMethodLongerThan5Seconds)
        {
            Console.WriteLine("ShipOrder Method was executed for longer than 5 seconds. There was an error with executing this method.");
        }
    }

    public async Task ShowOrdersAsync()
    {
        var orders = await _orderRepository.GetOrdersAsync();
        foreach (var order in orders)
            Console.WriteLine(
                $"OrderId : {order.orderId} | Price: {order.price} | Product name: {order.productName} |" +
                $" Client type: {order.clientType}  | Address: {order.adress} | Status: {order.orderStatus} | Payment Method: {order.paymentMethod}");
    }
}