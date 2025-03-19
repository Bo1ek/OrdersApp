using System.ComponentModel.DataAnnotations;
using OrdersApp.Application.Enums;

namespace OrdersApp.Application.Models;
public class Order
{
    [Key]
    public int OrderId { get; set; }
    public decimal Price { get; set; }
    [MaxLength(100)]
    public string ProductName { get; set; }
    public ClientTypes ClientType { get; set; }
    public OrderStatuses OrderStatus { get; set; } = OrderStatuses.New;
    public PaymentMethods PaymentMethod { get; set; }
    [MaxLength(100)]
    public string Address { get; set; }
    public Order(int orderId, decimal price, string productName, ClientTypes clientType, OrderStatuses orderStatus, PaymentMethods paymentMethod, string address)
    {
        OrderId = orderId;
        Price = price;
        ProductName = productName;
        ClientType = clientType;
        OrderStatus = orderStatus;
        PaymentMethod = paymentMethod;
        Address = address;
    }

    public Order()
    {
        
    }
};
