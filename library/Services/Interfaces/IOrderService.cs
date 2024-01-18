using library.DTOs;
using library.Entities;

namespace library.Services.Interfaces;

public interface IOrderService
{
    IList<Order> GetAllOrders();
    ICollection<OrderView> GetOrderViews();
    ICollection<UserOrderView> GetUsersOrder(int userId);
    Task AddNewOrder(OrderDto orderDto);
    Order GetOrderById(int orderId);
}