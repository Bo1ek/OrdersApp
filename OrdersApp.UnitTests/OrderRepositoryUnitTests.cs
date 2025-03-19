using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrdersApp.Application.Enums;
using OrdersApp.Application.Models;
using OrdersApp.Application.Repositories;
using OrdersApp.Application.Data;

namespace OrdersApp.UnitTests;

public class OrderRepositoryUnitTests : IDisposable
{
    private ServiceProvider _serviceProvider;

    public OrderRepositoryUnitTests() 
    {
        Setup();
    }
    public void Setup()
    {
        var services = new ServiceCollection();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("TestDatabase"));
        
        services.AddScoped<IOrderRepository, OrderRepository>();
        
        _serviceProvider = services.BuildServiceProvider();
    }
    
    [Fact]
    public async Task CreateOrderAsync_WhenDataIsValid_ShouldAddOrderToDatabase()
    {
        
        // Arrange
        using (var scope = _serviceProvider.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var repository = scopedServices.GetRequiredService<IOrderRepository>();
            var dbContext = scopedServices.GetRequiredService<ApplicationDbContext>();
            
            var order = new Order
            (
                1,
                14.00m,
                "Product 1",
                ClientTypes.Company,
                OrderStatuses.New,
                PaymentMethods.Card,
                "Ulica Testów 14"
            );
            // Act 
            await repository.CreateOrderAsync(order);
            
            // Assert 
            var addedOrder = dbContext.Orders.Find(order.OrderId);
            Assert.NotNull(addedOrder);
            Assert.Equal(order.ProductName, addedOrder.ProductName);
        }
    }
    [Fact]
    public async Task CreateOrderAsync_WhenDataIsInvalid_ShouldThrowException()
    {
        
        // Arrange
        using (var scope = _serviceProvider.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var repository = scopedServices.GetRequiredService<IOrderRepository>();
            var order = new Order
            (
                1,
                14.00m,
                "",
                ClientTypes.Company,
                OrderStatuses.New,
                PaymentMethods.Card,
                "Ulica Testów 14"
            );
            // Act 
            await repository.CreateOrderAsync(order);
            
            // Assert 
            await Assert.ThrowsAsync<ArgumentException>(async () => await repository.CreateOrderAsync(order));
        }
    }

    public void Dispose()
    {
        _serviceProvider.Dispose();
    }
}