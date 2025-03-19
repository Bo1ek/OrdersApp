namespace OrdersApp.Application.Exceptions;

public class OrderNotFoundException(int orderId) : Exception($"Order with id {orderId} not found");
