using Microsoft.EntityFrameworkCore;
using OrdersApp.Application.Data;
using OrdersApp.Application.Enums;
using OrdersApp.Application.Exceptions;
using OrdersApp.Application.Models;

namespace OrdersApp.Application.Repositories;

public class OrderRepository(ApplicationDbContext context) : IOrderRepository
{
    public async Task CreateOrderAsync(Order entity)
    {
        await context.Orders.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int orderId)
    {
        if (!await ExistsAsync(orderId)) 
            throw new OrderNotFoundException(orderId);
        
        return await context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId) ?? throw new OrderNotFoundException(orderId);
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await context.Orders.ToListAsync();
    }

    public async Task UpdateOrderAsync(int orderId)
    {
        if (!await ExistsAsync(orderId))
            throw new OrderNotFoundException(orderId);
        
        await context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int orderId)
    {
        var orderToRemove = await context.Orders.FindAsync(orderId);
        
        if (orderToRemove == null)
            throw new OrderNotFoundException(orderId);
        
        context.Orders.Remove(orderToRemove);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int orderId)
    {
        return await context.Orders.AnyAsync(o => o.OrderId == orderId);
    }

    public async Task SendOrderToTheWarehouseAsync(int orderId)
    {
        var orderToTransfer = await context.Orders.FindAsync(orderId);
        
        if (orderToTransfer == null)
            throw new OrderNotFoundException(orderId);
        
        if (orderToTransfer.OrderStatus == OrderStatuses.InWarehouse)
            Console.WriteLine("Order status is already in the warehouse.");
        
        if (orderToTransfer.Price <= 2500 && orderToTransfer.PaymentMethod == PaymentMethods.Cash)
        {
            orderToTransfer.OrderStatus = OrderStatuses.ReturnedToClient;
            Console.WriteLine("Order status cannot be sent to the warehouse due to its low price and payment method. " +
                              "Please insert price higher than 2500 or change payment method to card.");
        }
        orderToTransfer.OrderStatus = OrderStatuses.InWarehouse;
    }
    public async Task ShipOrderAsync (int orderId)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var orderToTransfer = await context.Orders.FindAsync(orderId);
        
        if (orderToTransfer == null)
            throw new OrderNotFoundException(orderId);
        
        if (orderToTransfer.OrderStatus == OrderStatuses.Shipped)
            Console.WriteLine("Order is already shipped.");
        
        orderToTransfer.OrderStatus = OrderStatuses.Shipped;
        watch.Stop();
        
        if (watch.ElapsedMilliseconds >= 5000)
            throw new ShipOrderMethodLongerThan5Seconds(orderId);
        await context.SaveChangesAsync();

    }
}