using library.DTOs;
using library.Entities;

namespace library.Services.Interfaces;

public interface IOrderService
{

    ICollection<OrderView> GetOrderViews();
    ICollection<UserOrderView> GetUsersOrder(int userId);
    Task AddNewOrder(int userId, string isbn);

}