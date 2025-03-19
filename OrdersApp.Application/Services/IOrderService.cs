using OrdersApp.Application.Models;

namespace OrdersApp.Application.Services;

public interface IOrderService
{
    Task<Order?> GetOrderByIdAsync();
    Task UpdateOrderAsync();
    Task DeleteOrderAsync();
    Task SendOrderToTheWarehouseAsync();
    Task ShipOrderAsync();
    Task ShowOrdersAsync();
}