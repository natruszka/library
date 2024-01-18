using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Orders;
[Authorize]
public class AddOrder : PageModel
{
    private readonly IOrderService _orderService;

    public AddOrder(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public void OnGet(string isbn)
    {
        
    }
}