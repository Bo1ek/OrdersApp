using OrdersApp.Application.Models;

namespace OrdersApp.Application.Repositories;
public interface IOrderRepository
{
    Task CreateOrderAsync(Order entity);
    Task<Order> GetOrderByIdAsync(int orderId);
    Task<List<Order>> GetOrdersAsync();
    Task UpdateOrderAsync(int orderId);
    Task DeleteOrderAsync(int orderId);
    Task SendOrderToTheWarehouseAsync(int orderId);
    Task ShipOrderAsync(int orderId);

}