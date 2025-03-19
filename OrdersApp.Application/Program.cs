using Microsoft.Extensions.DependencyInjection;
using OrdersApp.Application.Data;
using OrdersApp.Application.DependencyInjection;
using OrdersApp.Application.Helpers;
using OrdersApp.Application.Repositories;
using OrdersApp.Application.Services;

var configuration = DependencyInjection.LoadConfiguration();
var services = new ServiceCollection();

services.AddDbContext(configuration);
services.AddScoped<ApplicationDbContext>();
services.AddScoped<IOrderRepository, OrderRepository>();
services.AddScoped<IOrderService, OrderService>();
services.AddRepositories();
services.BuildServiceProvider();

await using var serviceProvider = services.BuildServiceProvider();

var orderRepository = serviceProvider.GetRequiredService<IOrderRepository>();
var orderService = serviceProvider.GetRequiredService<IOrderService>();

Console.WriteLine("----------------------------");
Console.WriteLine("-Welcome to the orders app!-");
Console.WriteLine("----------------------------");

while (true)
{
    Console.WriteLine("1.Create order");
    Console.WriteLine("2.Send order to the warehouse");
    Console.WriteLine("3.Ship orders");
    Console.WriteLine("4.Check all orders");
    Console.WriteLine("5.Get order by id");
    Console.WriteLine("6.Delete order");
    Console.WriteLine("7.Update order");
    Console.WriteLine("8.Exit App");
    Console.WriteLine("Please enter your choice: ");
    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            var entity = CreateOrderHelper.CreateOrder();
            await orderRepository.CreateOrderAsync(entity);
            break;
        case "2":
            await orderService.SendOrderToTheWarehouseAsync();
            break;
        case "3":
            await orderService.ShipOrderAsync();
            break;
        case "4":
            await orderService.ShowOrdersAsync();
            break;
        case "5":
            await orderService.GetOrderByIdAsync();
            break;
        case "6":
            await orderService.DeleteOrderAsync();
            break;
        case "7":
            await orderService.UpdateOrderAsync();
            break;
        case "8":
            Environment.Exit(0);
            break;
    }
    
}