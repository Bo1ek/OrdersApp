using Microsoft.Extensions.DependencyInjection;
using OrdersApp.Application.Data;
using OrdersApp.Application.DependencyInjection;

var configuration = DependencyInjection.LoadConfiguration();
var serviceProvider = new ServiceCollection()
    .AddDbContext(configuration);
serviceProvider.AddScoped<ApplicationDbContext>();
serviceProvider.BuildServiceProvider();



while (true)
{
    Console.WriteLine("Welcome to the orders app!");
    Console.WriteLine("Please select an option: ");
    Console.WriteLine("1.Create order");
    Console.WriteLine("2.Send order to the warehouse");
    Console.WriteLine("3.Ship orders");
    Console.WriteLine("4.Check all orders");
    Console.WriteLine("5.Exit App");
    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":

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