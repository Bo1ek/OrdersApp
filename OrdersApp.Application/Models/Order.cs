using System.ComponentModel.DataAnnotations;
using OrdersApp.Application.Enums;

namespace OrdersApp.Application.Models;

public class Order
{
    [Key]
    public int orderId { get; set; }
    public decimal price { get; set; }
    public string productName { get; set; }
    public ClientTypes clientType { get; set; }
    public OrderStatuses orderStatus { get; set; } = OrderStatuses.New;
    public PaymentMethods paymentMethod { get; set; }
    public string adress { get; set; }
};
