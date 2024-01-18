using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Borrows;
[Authorize]
public class AddBorrow : PageModel
{
    public void OnGet()
    {
        
    }
}