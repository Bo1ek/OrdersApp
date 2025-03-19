namespace OrdersApp.Application.Exceptions;

public class ShipOrderMethodLongerThan5Seconds(int orderId) : Exception($"Order with ID {orderId} " +
                                                                        $"was cancelled due to it's long execution. ");