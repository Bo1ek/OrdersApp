using Microsoft.Extensions.DependencyInjection;
using OrdersApp.Application.Data;
using OrdersApp.Application.DependencyInjection;
using OrdersApp.Application.Repositories;

var configuration = DependencyInjection.LoadConfiguration();
var services = new ServiceCollection();

services.AddDbContext(configuration);
services.AddScoped<ApplicationDbContext>();
services.AddScoped<IOrderRepository, OrderRepository>();
services.AddRepositories();
services.BuildServiceProvider();
await using var serviceProvider = services.BuildServiceProvider();
var orderRepository = serviceProvider.GetRequiredService<IOrderRepository>();
while (true)
{
    Console.WriteLine("Welcome to the orders app!");
    Console.WriteLine("1.Create order");
    Console.WriteLine("2.Send order to the warehouse");
    Console.WriteLine("3.Ship orders");
    Console.WriteLine("4.Check all orders");
    Console.WriteLine("5.Exit App");
    Console.WriteLine("Please enter your choice: ");
    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            await orderRepository.CreateOrderAsync();
            break;
        case "2":

            break;
        case "3":

            break;
        case "4":
            
            break;
        case "5":
            
            break;
    }
    
}