using library.DTOs;
using library.Entities;
using library.Services;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Members;

[Authorize]
public class ShowUserOrdersAndBorrows : PageModel
{
    public List<UserBorrowView> UserBorrowViews { get; set; } = new();
    public List<UserOrderView> UserOrderViews { get; set; } = new();
    public Member MemberToView { get; set; } = new();
    private readonly IBorrowService _borrowService;
    private readonly IOrderService _orderService;
    private readonly MemberService _memberService;
    public ShowUserOrdersAndBorrows(IBorrowService borrowService, IOrderService orderService, MemberService memberService)
    {
        _borrowService = borrowService;
        _orderService = orderService;
        _memberService = memberService;
    }
    public void OnGet(int userId)
    {
        UserBorrowViews = new List<UserBorrowView>(_borrowService.GetUsersBorrow(userId));
        UserOrderViews = new List<UserOrderView>(_orderService.GetUsersOrder(userId));
        MemberToView = _memberService.GetMemberById(userId)!;
    }
}