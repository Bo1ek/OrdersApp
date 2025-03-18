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
        try
        {
            await _orderRepository.UpdateOrderAsync(orderId);
        }
        catch (OrderNotFoundException)
        {
            Console.WriteLine("Order was not found. Pass proper order Id.");
        }
    }

    public async Task DeleteOrderAsync()
    {
        Console.WriteLine("Please enter the order Id you want to delete.");
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
        Console.WriteLine("Please enter the order Id you want to send to the warehouse.");
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
        Console.WriteLine("Please enter the order Id you want to ship.");
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
            Console.WriteLine("ShipOrder Method executed longer than 5 seconds. There was an error with executing this method.");
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