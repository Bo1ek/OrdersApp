namespace OrdersApp.Application.Enums;

public enum OrderStatuses
{
    New = 1,
    InWarehouse, 
    Shipped,
    ReturnedToClient,
    Error,
    Closed
}