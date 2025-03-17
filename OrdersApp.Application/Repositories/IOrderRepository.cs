using OrdersApp.Application.Models;

namespace OrdersApp.Application.Repositories;
public interface IOrderRepository
{
    Task CreateOrderAsync();
    Order GetOrderById(int orderId);
    List<Order> GetOrders();
    Task UpdateOrder(int orderId);
    Task DeleteOrder(int orderId);
    bool Exists(int orderId);

}