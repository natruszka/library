using System.Security.Claims;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> OnGet(string isbn)
    {
        try
        {
            var userId = User.Claims.First(c => c.Type == ClaimTypes.Sid).Value;
            await _orderService.AddNewOrder(Convert.ToInt32(userId), isbn);
            return RedirectToPage("/Orders/ShowOrders");
        }
        catch
        {
            return RedirectToPage("/Books/ShowBooks");
        }
    }
}