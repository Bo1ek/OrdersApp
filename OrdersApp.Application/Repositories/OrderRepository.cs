using OrdersApp.Application.Data;
using OrdersApp.Application.Enums;
using OrdersApp.Application.Exceptions;
using OrdersApp.Application.Helpers;
using OrdersApp.Application.Models;

namespace OrdersApp.Application.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task CreateOrderAsync()
    {
        var entity = CreateOrderHelper.CreateOrder();
        await _context.Orders.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public Order GetOrderById(int orderId)
    {
        return _context.Orders.FirstOrDefault(o => o.orderId == orderId) ?? throw new OrderNotFoundException(orderId);
    }

    public List<Order> GetOrders()
    {
        return  _context.Orders.ToList();
    }

    public async Task UpdateOrder(int orderId)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (!Exists(orderId))
            throw new OrderNotFoundException(orderId);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrder(int orderId)
    {
        var orderToRemove = await _context.Orders.FindAsync(orderId);
        if (orderToRemove == null)
            throw new OrderNotFoundException(orderId);
        _context.Orders.Remove(orderToRemove);
        await _context.SaveChangesAsync();
    }

    public bool Exists(int orderId)
    {
        return _context.Orders.Any(o => o.orderId == orderId);
    }
}