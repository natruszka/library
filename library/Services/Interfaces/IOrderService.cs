using library.DTOs;
using library.Entities;

namespace library.Services.Interfaces;

public interface IOrderService
{
    IList<Order> GetAllOrders();
    ICollection<OrderView> GetOrderViews();
    ICollection<UserOrderView> GetUsersOrder(int userId);
    Task AddNewOrder(int userId, string isbn);
    Order GetOrderById(int orderId);
}