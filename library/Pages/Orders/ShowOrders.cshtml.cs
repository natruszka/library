using library.DTOs;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Orders;
[Authorize]
public class ShowOrders : PageModel
{
    public List<OrderView> OrderViews { get; set; } = new();
    private readonly IOrderService _orderService;

    public ShowOrders(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public async Task OnGet()
    {
        OrderViews = new List<OrderView>(_orderService.GetOrderViews());
    }
}