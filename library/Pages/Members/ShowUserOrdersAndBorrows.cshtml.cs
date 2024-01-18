using library.DTOs;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Members;

public class ShowUserOrdersAndBorrows : PageModel
{
    public List<UserBorrowView> UserBorrowViews { get; set; } = new();
    public List<UserOrderView> UserOrderViews { get; set; } = new();
    private readonly IBorrowService _borrowService;
    private readonly IOrderService _orderService;

    public ShowUserOrdersAndBorrows(IBorrowService borrowService, IOrderService orderService)
    {
        _borrowService = borrowService;
        _orderService = orderService;
    }
    public void OnGet(int userId)
    {
        UserBorrowViews = new List<UserBorrowView>(_borrowService.GetUsersBorrow(userId));
        UserOrderViews = new List<UserOrderView>(_orderService.GetUsersOrder(userId));
    }
}